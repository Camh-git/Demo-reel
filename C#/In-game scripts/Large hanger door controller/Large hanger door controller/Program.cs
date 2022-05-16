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
        public Program()
        {
            //Load storage
            //backup incase load fails
            List<string> Backup = new List<string>();
            Backup.Add(Stuff.Status);
            Backup.Add(Stuff.Stored_arg);
            Backup.Add(Stuff.Prefix);
            try
            {
                string[] Storage_info = Storage.Split(',');
                Stuff.Status = Storage_info[0].Split(':')[1];
                Stuff.Stored_arg = Storage_info[1].Split(':')[1];
                Stuff.Prefix = Storage_info[2].Split(':')[1];
                Stuff.Depress_time = Convert.ToInt32(Storage_info[3].Split(':')[1]);
            }
            catch {
                //The first 2 variables are set to blank since we cant recover their actual values if the storage import fails since they are currently blank
                //but we can at least remove any corruption/errors that may have occured along the way. eg.on the first time stored arg = "PREFIXPREFIXPREFIX"
                Stuff.Status = "";
                Stuff.Stored_arg = "";
                Stuff.Prefix = "LHD";
                Echo("Failed to load settings, restoring defaults, ignore if first run");
            }
            Update_blocks();
        }

        public void Save()
        {
            ///<summary>Saves the Status, Stored arg, prefix and press time variables to the built-in storage file</summary>
            string Storage_backup = Storage;
            try
            {
                Storage = "";
                Storage += "STATUS:" + Stuff.Status +",";
                Storage += "STORED_ARG:" + Stuff.Stored_arg+",";
                Storage += "PREFIX:" + Stuff.Prefix+",";
                Storage += "Press_time:" + Stuff.Depress_time;
            }
            catch
            {
                Storage = Storage_backup;
                Echo("Failed to update storage, backup restored, current storage is:\n" + Storage);
            }
        }

        public class Info_and_blocks
        {
            /// <summary>Repo for system blocks and information</summary>
            public IMyPistonBase Main_piston;
            public IMyPistonBase Rise_piston;
            public IMyMotorAdvancedStator Hinge;
            public IMyShipMergeBlock Hanger_merge;
            public IMyShipMergeBlock Door_merge;
            public List<IMyAirtightHangarDoor> Hanger_door = new List<IMyAirtightHangarDoor>();
            public List<IMyAirtightHangarDoor> Door_extension = new List<IMyAirtightHangarDoor>();

            //Optional blocks
            public List<IMyAirVent> Vents = new List<IMyAirVent>();
            public List<IMyInteriorLight> Warning_lights = new List<IMyInteriorLight>();
            public List<IMyReflectorLight> Rotating_warning_lights = new List<IMyReflectorLight>();
            public List<IMySoundBlock> Alarm = new List<IMySoundBlock>();

            public int Timer_count = 0;
            public string Stored_arg = "";
            public string Status = "UNKNOWN";
            public string Prefix = "LHD";
            public int Depress_time = 20;

            public Info_and_blocks()
            { }
        }
        Info_and_blocks Stuff = new Info_and_blocks();

        public void Update_blocks ()
        {
            ///<summary>Fetches the blocks used in the system and assignes them to their objects. Uses pre-asigned tags</summary>
            
            List<IMyFunctionalBlock> Repo = new List<IMyFunctionalBlock>(); //this exists so that single blocks can be used with tags, since getblocksoftype wants lists
            GridTerminalSystem.GetBlocksOfType(Repo, b => b.CustomName.Contains(Stuff.Prefix + "MP]"));
            Stuff.Main_piston = Repo[0] as IMyPistonBase;
            GridTerminalSystem.GetBlocksOfType(Repo, b => b.CustomName.Contains(Stuff.Prefix + "RP]"));
            Stuff.Rise_piston = Repo[0] as IMyPistonBase;
            GridTerminalSystem.GetBlocksOfType(Repo, b => b.CustomName.Contains(Stuff.Prefix + "H]"));
            Stuff.Hinge = Repo[0] as IMyMotorAdvancedStator;
            GridTerminalSystem.GetBlocksOfType(Repo, b => b.CustomName.Contains(Stuff.Prefix + "HM]"));
            Stuff.Hanger_merge = Repo[0] as IMyShipMergeBlock;
            GridTerminalSystem.GetBlocksOfType(Repo, b => b.CustomName.Contains(Stuff.Prefix + "DM]"));
            Stuff.Door_merge = Repo[0] as IMyShipMergeBlock;
            GridTerminalSystem.GetBlocksOfType(Stuff.Hanger_door, b => b.CustomName.Contains(Stuff.Prefix + "D]"));
            GridTerminalSystem.GetBlocksOfType(Stuff.Door_extension, b => b.CustomName.Contains(Stuff.Prefix + "DE]"));

            //Optional blocks
            GridTerminalSystem.GetBlocksOfType(Stuff.Vents, b => b.CustomName.Contains(Stuff.Prefix + "V]"));
            GridTerminalSystem.GetBlocksOfType(Repo, b => b.CustomName.Contains(Stuff.Prefix + "L]"));
            foreach(IMyFunctionalBlock B in Repo) //Sort the two possible types of light that just got picked up into their groups
            {
                string type_string = GridTerminalSystem.GetBlockWithName(B.CustomName).GetType().ToString();
                type_string = type_string.Split('.')[type_string.Split('.').Length - 1];
                switch (type_string)
                {
                    case "MyInteriorLight":
                        IMyInteriorLight L = GridTerminalSystem.GetBlockWithName(B.CustomName) as IMyInteriorLight;
                        Stuff.Warning_lights.Add(L);
                        break;
                    case "MyReflectorLight":
                        IMyReflectorLight RL = GridTerminalSystem.GetBlockWithName(B.CustomName) as IMyReflectorLight;
                        Stuff.Rotating_warning_lights.Add(RL);
                        break;
                    case "MyFunctionalBlock":
                        Echo("Error: type of block: " + B.CustomName + " resolved to IMyFunctionalBlock\n");
                        break;
                    default:
                        Echo("Error: block: " + B.CustomName + " did not resolve to any valid type, please ensure it is a light block, its type was:" + type_string + "\n");
                        break;
                }
            }
            GridTerminalSystem.GetBlocksOfType(Stuff.Alarm, b => b.CustomName.Contains(Stuff.Prefix + "A]"));
        }
        public void End_timer()
        {
            ///<summary>Ends the timer, clears stored arg and resets timer to 0 </summary>
            Stuff.Stored_arg = "";
            Stuff.Timer_count = 0;
            Runtime.UpdateFrequency = UpdateFrequency.None;
        }
        public void Open()
        {
            ///<summary>Begins the door open process</summary>
            foreach (IMyAirVent V in Stuff.Vents)
            { V.Depressurize = true; }
            foreach (IMyLightingBlock L in Stuff.Warning_lights)
            { L.Enabled = true; }
            foreach (IMyReflectorLight L in Stuff.Rotating_warning_lights)
            { L.Enabled = true; }
            foreach (IMySoundBlock A in Stuff.Alarm)
            { A.SelectedSound = "Alert 2"; A.Play(); }

            Stuff.Status = "OPENING";
            Stuff.Stored_arg = "DEPRESS_WAIT";
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
            Echo("Opening: waiting for depress");
        }

        public void Close()
        {
            ///<summary>Begins the door close process</summary>
            Stuff.Main_piston.Enabled = true;
            Stuff.Main_piston.Velocity = 1;
            Stuff.Rise_piston.Enabled = true;
            Stuff.Rise_piston.Velocity = 1;
            Stuff.Hinge.Enabled = true;
            Stuff.Hinge.RotorLock = false;
            Stuff.Hinge.TargetVelocityRPM = -1;

            foreach (IMyLightingBlock L in Stuff.Warning_lights)
            { L.Enabled = true; }
            foreach (IMyReflectorLight L in Stuff.Rotating_warning_lights)
            { L.Enabled = true; }
            foreach (IMySoundBlock A in Stuff.Alarm)
            { A.Play(); }

            Stuff.Status = "CLOSING";
            Stuff.Stored_arg = "CLOSE_1";
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
            Echo("Closing");
        }

        public void Main(string argument, UpdateType updateSource)
        {
            //This method works through 3 types of arg in order: stored args, args with variables as payload, args with only 1 option
            if (Stuff.Stored_arg != "")
            {
                switch (Stuff.Stored_arg)
                {
                    case "DEPRESS_WAIT":
                        if (Stuff.Timer_count >= Stuff.Depress_time)
                        {
                            foreach(IMyAirtightHangarDoor D in Stuff.Hanger_door)
                            { D.Enabled = true; D.OpenDoor(); }
                            foreach (IMyAirtightHangarDoor D in Stuff.Door_extension)
                            { D.Enabled = true; D.OpenDoor(); }
                            Stuff.Timer_count = 0;
                            Stuff.Stored_arg = "OPEN_1";
                        }
                        else { Stuff.Timer_count++; Echo("Depress wait: " + Stuff.Timer_count); }
                        break;

                    case "OPEN_1":
                        if (Stuff.Timer_count > 1) //The hanger door blocks don't need to be fully open, just not making contact 
                        {
                            Stuff.Door_merge.Enabled = false;
                            Stuff.Hanger_merge.Enabled = false;

                            Stuff.Main_piston.Enabled = true; //Move the door out a bit to ensure it clears
                            Stuff.Main_piston.Velocity = 1;

                            Stuff.Hinge.Enabled = true;
                            Stuff.Hinge.RotorLock = false;
                            Stuff.Hinge.TargetVelocityRPM = 1;

                            Stuff.Timer_count = 0;
                            Stuff.Stored_arg = "OPEN_2";
                        }
                        else { Stuff.Timer_count++; }
                        break;
                    case "OPEN_2":
                        if (Stuff.Timer_count > 5)
                        {
                            foreach (IMyAirtightHangarDoor D in Stuff.Hanger_door)
                            { D.Enabled = false; }
                            foreach (IMyAirtightHangarDoor D in Stuff.Door_extension)
                            { D.Enabled = false; }

                            Stuff.Main_piston.Velocity = -1;
                            Stuff.Rise_piston.Enabled = true;
                            Stuff.Rise_piston.Velocity = -1;

                            Stuff.Timer_count = 0;
                            Stuff.Stored_arg = "OPEN_END";
                        }
                        else { Stuff.Timer_count++; }
                        break;
                    case "OPEN_END":
                        if(Stuff.Timer_count >4)
                        {
                            Stuff.Main_piston.Enabled = false;
                            Stuff.Rise_piston.Enabled = false;
                            Stuff.Hinge.TargetVelocityRPM = 0;
                            Stuff.Hinge.RotorLock = true;
                            Stuff.Hinge.Enabled = false;

                            foreach(IMyLightingBlock L in Stuff.Warning_lights)
                            { L.Enabled = false; }
                            foreach(IMyReflectorLight L in Stuff.Rotating_warning_lights)
                            { L.Enabled = false; }
                            foreach(IMySoundBlock A in Stuff.Alarm)
                            { A.Stop(); }

                            End_timer();
                            Stuff.Status = "OPEN";
                            Save();
                        }
                        else { Stuff.Timer_count++; }
                        break;
                    case "CLOSE_1":  //wait until the door has swung down, lock rise piston and hinge, begin merge
                        if(Stuff.Timer_count > 9)
                        {
                            Stuff.Rise_piston.Enabled = false;
                            Stuff.Hinge.TargetVelocityRPM = 0;
                            Stuff.Hinge.RotorLock = true;
                            Stuff.Hinge.Enabled = false;
                           

                            Stuff.Door_merge.Enabled = true;
                            Stuff.Hanger_merge.Enabled = true;

                            Stuff.Main_piston.Velocity = -1;
                            Stuff.Stored_arg = "CLOSE_2";
                            Stuff.Timer_count = 0;
                        }
                        else { Stuff.Timer_count++; }
                        break;
                    case "CLOSE_2": // wait until merge is complete, disable piston close hanger doors
                        if (Stuff.Door_merge.IsConnected)
                        {
                            Echo("Merged");
                            foreach (IMyAirtightHangarDoor D in Stuff.Hanger_door)
                            { D.Enabled = true; D.CloseDoor(); }
                            foreach (IMyAirtightHangarDoor D in Stuff.Door_extension)
                            { D.Enabled = true; D.CloseDoor(); }

                            Stuff.Main_piston.Enabled = false;

                            Stuff.Stored_arg = "CLOSE_END";
                            Stuff.Timer_count = 0;
                        }
                        else {
                            Stuff.Timer_count++;
                            if (Stuff.Timer_count > 8)
                            {
                                Echo("ERROR: Merge attempt timed out after 10 seconds, disabling piston and merge blocks");
                                End_timer();
                                Stuff.Main_piston.Enabled = false;
                                Stuff.Door_merge.Enabled = false;
                                Stuff.Hanger_merge.Enabled = false;
                            }     
                            else if (Stuff.Main_piston.CurrentPosition < 1.5)
                            {
                                Echo("ERROR: Door retract piston retracted fully without merging, disabling piston and merge blocks");
                                End_timer();
                                Stuff.Main_piston.Enabled = false;
                                Stuff.Door_merge.Enabled = false;
                                Stuff.Hanger_merge.Enabled = false;
                            }
                        }

                        break;
                    case "CLOSE_END": //Begin press, end timer, kill warning systems
                        if (Stuff.Timer_count > 7)
                        {
                            foreach(IMyAirVent V in Stuff.Vents)
                            { V.Depressurize = false; }

                            foreach (IMyLightingBlock L in Stuff.Warning_lights)
                            { L.Enabled = false; }
                            foreach (IMyReflectorLight L in Stuff.Rotating_warning_lights)
                            { L.Enabled = false; }
                            foreach (IMySoundBlock A in Stuff.Alarm)
                            { A.Stop(); }

                            foreach (IMyAirtightHangarDoor D in Stuff.Hanger_door)
                            { D.Enabled = false;}
                            foreach (IMyAirtightHangarDoor D in Stuff.Door_extension)
                            { D.Enabled = false;}

                            End_timer();
                            Stuff.Status = "CLOSED";
                            Save();
                        }
                        else { Stuff.Timer_count++; }
                        break;

                    default:
                        Echo("ERROR: Stored arg did not match any recognised command, the arg was: " + argument);
                        break;
                }
            }
            else if (argument.Contains(':'))
            {
                switch(argument.Split(':')[0].ToUpper())
                {
                    case "PREFIX":
                        Stuff.Prefix = argument.Split(':')[1];
                        Save();
                        break;
                    case "DEPRESS":
                    case "DEPRESS_TIME":
                    case "TIME":
                    case "TIMER":
                        Stuff.Depress_time = Convert.ToInt32(argument.Split(':')[1]);
                        Save();
                        break;
                    default:
                        Echo("ERROR: Arg with variable did not match a valid command, the arg was: " + argument.Split(':')[0]);
                        break;
                }
            }
            else
            {
                switch (argument.ToUpper())
                {
                    case "OPEN":
                        Open();
                        break;

                    case "CLOSE":
                        Close();
                        break;
                    case "TOGGLE":
                        Echo("TOGGLING");
                        switch (Stuff.Status.ToUpper())
                        {
                            case "OPEN":
                                Echo("TOGGLE: closing");
                                Close();
                                break;
                            case "CLOSED":
                                Echo("TOGGLE: opening");
                                Open();
                                break;
                            case "OPENING":
                            case "CLOSING":
                                Echo("INFO: Door status is" + Stuff.Status + ", please wait for this proccess to finish, if this is an error call open or close manualy");
                                break;
                            default:
                                Echo("ERROR: Status did not match any expected value, it was: " + Stuff.Status);
                                break;
                        }
                        break;

                    case "HELP":
                        break;
                    case "SAVE":
                        Save();
                        Echo("Saved");
                        break;
                    case "PREFIX":
                        Echo(Stuff.Prefix);
                        break;
                    case "STATUS":
                        Echo(Stuff.Status);
                        break;
                    case "CLEAR_STORE":
                    case "CLEAR_STORED":
                    case "END_TIMER":
                        End_timer();
                        Echo("Cleared stored arg and timer");
                        break;

                    default:
                        Echo("ERROR: Argument did not match any recognised command, the argument was: " + argument);
                        break;
                }    
            }
        }
    }
}
