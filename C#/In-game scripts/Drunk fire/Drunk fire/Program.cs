using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        public List <IMyThrust> Thrusters = new List<IMyThrust>();
        int Current_thruster = -1;
        string Tag = "[DRNK]";
        public bool Launched = false;

        public Program()
        {
            Tag = Storage;
        }
        public void Save() 
        {
            Storage = Tag;        
        }

        //Main processes the incoming arg and calls the appropriate method
        public void Main(string argument, UpdateType updateSource)
        {
            //If the thrusters have started firing check if a stop has been ordered, if not continue firing
            if (Current_thruster != -1 && argument.ToUpper() != "STOP_FIRING")
            {
                Fire_random();
                return;
            }
            
            switch(argument.ToUpper())
            {
                case "FETCH_THRUSTERS":
                    Fetch_thrusters();
                    break;
                case "FIRE_RANDOM":
                    Fire_random();
                    break;
                case "STOP_FIRING":
                    Stop_firing();
                    break;
                case "HELP":
                    Help();
                    break;
                case "SET_TAG":
                case "TAG":
                case "SETTAG":
                    Set_tag(argument);
                    break;
            }
        }
        public void Fetch_thrusters()
        {
            Thrusters.Clear();
            GridTerminalSystem.GetBlocksOfType(Thrusters, b => b.CustomName.Contains(Tag));
            Launched = true;
        }
        public void Fire_random()
        {
            //Select and fire a random thruster for 1 second
            if (Launched)
            {
                //Note: attempted to run by thruster direction, causes issues if no dedicated cockpit block is present
                //Turn off the current thruster if one is firing
                if(Current_thruster !=-1)
                {
                    Thrusters[Current_thruster].Enabled = false;
                }

                Random R = new Random();
                int I = Current_thruster;
                while(I == Current_thruster)
                {
                    I = R.Next(0,Thrusters.Count);
                }
                Thrusters[I].ThrustOverride = 1.0f;
                Thrusters[I].Enabled = true;
                Runtime.UpdateFrequency = UpdateFrequency.Update100;
                Current_thruster = I;
            }
            Echo("WARNING: Attempted to fire thruster prior to launch.");
        }
        public void Stop_firing()
        {
            //This exists as a way to get out of the otherwise terminal random fire launch, this
            //allows the missile to return to normal flight if the target's AA loses it's lock.
            Runtime.UpdateFrequency = UpdateFrequency.None;
            foreach(IMyThrust T in Thrusters)
            {
                T.ThrustOverride = 0;
                T.Enabled = false;
            }
            Current_thruster = -1;
        }

        //Misc/help functions
        public void Help()
        {
            Echo("This script is designed to serve as a pen aid by allowing" +
                "missiles to thrust in random directions to avoid leading fire" +
                "from hostile point defence (sometimes called drunk fire)\n\n" +

                "To use the system add the tag to the thrusters you want to" +
                "control (these should not be the AI controlled thrusters)\n" +
                "The default tag is[DRNK], this can be change using the Set_tag:" +
                "command, for exaple Set_tag:Random would change the tag to " +
                "[RANDOM], (do not add the [] as part of the command)\n\n" +
                
                "To run the system add this block to the missile's detach" +
                "trigger with the argument 'Fetch_thrusters', this will prevent" +
                "the system from registering thrusters on other missiles, and " +
                "inform it that the missile has been launched, allowing the " +
                "'Fire_random' function to run.\n\n" +

                "Finaly, add this block with the argument 'Fire_random' to the" +
                "missile's 'On lock' action to make it activate at the right time.\n\n" +
                
                "Optionaly you can also add this block to the missiles 'lost lock'" +
                "action with the argument 'Stop_firing' to resume normal flight.");
        }
        public void Set_tag(string Input)
        {
            Input = Input.ToUpper();
            Input = Regex.Replace(Input, "[^A-Za-z0-9 -]", "");
            Input = "[" + Input + "]";
            Tag = Input;
        }
    }
}
