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
        //This program controlls the extend and retract functions of the boarding ramp
        //The deploy/enxtend proccess has 4 steps: extend 1st pannel(ensures ground clearence for the rest), extend all pannels, lower ramp to ground, lock
        //The retract proccess has 4 steps: Raise ramp to vertical, retract all but 1st pannel(^), retract 1st pannel, lock
        public Program()
        {
            //Fetch the hinges and load the status
            Hinges.Clear();
            for (int i = 1; i <= 6; i++)
            {
                Hinges.Add(GridTerminalSystem.GetBlockWithName("Ramp Hinge " + i) as IMyMotorAdvancedStator);
            }
            Echo("Found a total of: " + Hinges.Count() + " Hinges (should be 6)");
            Info.status = Storage;
        }

        public void Save()
        {
            ///<summary>Saves the Status variable to the built-in storage file</summary>
            string Backup = Storage;
            try
            {
                Storage = Info.status;
            }
            catch
            {
                Storage = Backup;
                Echo("ERROR: Failed to save, backup restored. The contents of storage are: " + Storage);
            }
        }

        
        public class Blocks_and_info
        {
            /// <summary>Repo of system info</summary>
            public string status = "None";
            public string Stored_arg = "";
            public int Timer_counter = 0;
            public float Stored_pos = 0;
            
        }
        public Blocks_and_info Info = new Blocks_and_info();
        public List<IMyMotorAdvancedStator> Hinges = new List<IMyMotorAdvancedStator>();


        public void Main(string argument, UpdateType updateSource)
        {
            if (Info.Stored_arg != "")
            {
                switch (Info.Stored_arg.ToUpper())
                {
                    case "EXTEND_START":
                        //Deploy the first pannel
                        Hinges[0].Enabled = true;
                        Hinges[0].RotorLock = false;
                        Hinges[0].TargetVelocityRPM = 3;
                        Info.Stored_arg = "EXTEND_MID_1";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                        break;

                    case "EXTEND_MID_1":
                        //Extend all pannels
                        if (Info.Timer_counter > 2)
                        {
                            foreach (IMyMotorAdvancedStator H in Hinges)
                            {
                                H.Enabled = true;
                                H.RotorLock = false;
                            }
                            Hinges[1].TargetVelocityRPM = 2;
                            Hinges[2].TargetVelocityRPM = -2;
                            Hinges[3].TargetVelocityRPM = -2;
                            Hinges[4].TargetVelocityRPM = 2;
                            Hinges[5].TargetVelocityRPM = 2;
                            Info.Stored_arg = "EXTEND_MID_2";
                            Info.Timer_counter = 0;
                            
                        } else { Info.Timer_counter++; }
                        break;
                    case "EXTEND_MID_2":
                        //Start ramp lowering to floor
                        if (Info.Timer_counter > 3)
                        {
                            Hinges[0].TargetVelocityRPM = -3;
                            Info.Stored_pos = Hinges[0].Angle;
                            Info.Timer_counter = 0;
                            Info.Stored_arg = "EXTEND_FIN";
                            Runtime.UpdateFrequency = UpdateFrequency.Update10;
                        }
                        else { Info.Timer_counter++; }
                        break;
                    case "EXTEND_FIN":
                        //Lock everything in place once the ramp has slowed down from hitting the ground
                        //Impact detected by the angle changing less than the expected 18°/s (10.8° in this timeframe, with a small safety margin)
                        //the timer > 1 stops it getting stuck on the 1st run since it hasn't moved that far yet
                        Echo("DEBUG: previous: " + Info.Stored_pos + "Current: " + Hinges[0].Angle +"Diff: " + Math.Abs(Hinges[0].Angle - Info.Stored_pos));
                        if ((Math.Abs(Hinges[0].Angle - Info.Stored_pos) < 0.01 || Info.Timer_counter > 19) && Info.Timer_counter > 1) 
                        {
                            foreach (IMyMotorAdvancedStator H in Hinges)
                            {
                                H.RotorLock = true;
                                H.Enabled = false;
                            }
                            End_timer();
                            Info.Stored_pos = 0;
                            Info.status = "EXTENDED";
                            Save();
                        } 
                        else { Info.Timer_counter++; }
                        break;

                    case "RETRACT_START":
                        //Raise the ramp from the ground
                        Hinges[0].Enabled = true;
                        Hinges[0].RotorLock = false;
                        Hinges[0].TargetVelocityRPM = 3;
                        Info.Stored_arg = "RETRACT_MID_1";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                        break;

                    case "RETRACT_MID_1":
                        //Retract all pannels but the 1st
                        if (Info.Timer_counter > 0)
                        {
                            foreach (IMyMotorAdvancedStator H in Hinges)
                            {
                                H.Enabled = true;
                                H.RotorLock = false;
                            }
                            Hinges[1].TargetVelocityRPM = -2;
                            Hinges[2].TargetVelocityRPM = 2;
                            Hinges[3].TargetVelocityRPM = 2;
                            Hinges[4].TargetVelocityRPM = -2;
                            Hinges[5].TargetVelocityRPM = -2;
                            Info.Stored_arg = "RETRACT_MID_2";
                            Info.Timer_counter = 0;
                        }
                        else { Info.Timer_counter++; }
                        break;
                    case "RETRACT_MID_2":
                        //Retract the first pannel after the rest are finished
                        if (Info.Timer_counter > 3)
                        {
                            Hinges[0].TargetVelocityRPM = -3;
                            Info.Timer_counter = 0;
                            Info.Stored_arg = "RETRACT_FIN";
                        }
                        else { Info.Timer_counter++; }
                        break;
                    case "RETRACT_FIN":
                        //Lock everything in place once the final pannel has retracted
                        if (Info.Timer_counter > 4)
                        {
                            foreach (IMyMotorAdvancedStator H in Hinges)
                            {
                                H.RotorLock = true;
                                H.Enabled = false;
                            }
                            End_timer();
                            Info.Stored_pos = 0;
                            Info.status = "RETRACTED";
                            Save();
                        }
                        else { Info.Timer_counter++; }
                        break;
                    default:
                        Echo("ERROR: Stored arg did not match any recognised command, it was: " + Info.Stored_arg);
                        break;
                }
            }
            else
            {
                switch(argument.ToUpper())
                {
                    case "TOGGLE":
                        switch(Info.status)
                        {
                            case "RETRACTED":
                                Echo("TOGGLE: selected extend");
                                Info.Stored_arg = "EXTEND_START";
                                Runtime.UpdateFrequency = UpdateFrequency.Update10;
                                break;
                            case "EXTENDED":
                                Echo("TOGGLE: selected retracted");
                                Info.Stored_arg = "RETRACT_START";
                                Runtime.UpdateFrequency = UpdateFrequency.Update10;
                                break;
                            default:
                                //Try to determin position based on main hinge position if no status is available
                                Echo("ERROR: Info.status was neither RETRACTED or EXTENDED, toggle aborted. please use the manual EXTEND or RETRACT command " +
                                    "for your first use.\nStatus: " + Info.status);
                                break;
                        }
                        break;

                    case "OPEN":
                    case "EXTEND":
                        //Deploy the first pannel
                        Info.Stored_arg = "EXTEND_START";
                        Runtime.UpdateFrequency = UpdateFrequency.Update10;
                        break;

                    case "CLOSE":
                    case "RETRACT":
                        Info.Stored_arg = "RETRACT_START";
                        Runtime.UpdateFrequency = UpdateFrequency.Update10;
                        break;

                    case "RESTORE":
                    case "DEFAULTS":
                        foreach(IMyMotorAdvancedStator H in Hinges)
                        {
                            H.Enabled = false;
                            H.RotorLock = true;
                        }
                        Hinges[0].TargetVelocityRPM = 3;
                        Hinges[1].TargetVelocityRPM = -2;
                        Hinges[2].TargetVelocityRPM = 2;
                        Hinges[3].TargetVelocityRPM = 2;
                        Hinges[4].TargetVelocityRPM = -2;
                        Hinges[5].TargetVelocityRPM = -2;

                        //restores the default target RPM for each rotor(retract) and locks them for safety
                        break;

                    default:
                        Echo("ERROR: Argument does not match any recognised input.\nArgument was: " + argument);
                        break;
                }
            }
        }

        public void End_timer()
        {
            ///<summary>Ends the timer, clears stored arg and resets timer to 0 </summary>
            Info.Stored_arg = "";
            Info.Timer_counter = 0;
            Runtime.UpdateFrequency = UpdateFrequency.None;
        }
    }
}
