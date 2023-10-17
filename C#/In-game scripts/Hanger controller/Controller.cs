public Program()
        {
            Update_block_collection();
            Detect_settings();
            try 
            { 
                string[] Storage_data = Storage.Split(',');
                Info.Prefix = Storage_data[0].Split(':')[1];
                Info.Hanger_ID = Storage_data[1].Split(':')[1];
                Info.Caller_ID = Storage_data[2].Split(':')[1];
                Info.Status = Storage_data[3].Split(':')[1];
                Info.initalised = Convert.ToBoolean(Storage_data[4].Split(':')[1]);
                Info.Close_warning = Convert.ToBoolean(Storage_data[5].Split(':')[1]);
                Info.Radius = (float)Convert.ToDecimal(Storage_data[6].Split(':')[1]);
                Info.Press_time = Convert.ToInt32(Storage_data[7].Split(':')[1]);
            }
            catch { Echo("Failed to load settings, ignore if first run"); }
        }

        public void Save()
        {
            string storage_backup = Storage;           
            try
            {
                Storage = "";
                Storage += "Prefix:" + Info.Prefix + ",";
                Storage += "ID:" + Info.Hanger_ID + ",";
                Storage += "Caller:" + Info.Caller_ID + ",";
                Storage += "Status:" + Info.Status + ",";
                Storage += "Initalised:" + Info.initalised + ",";
                Storage += "Close_warn:" + Info.Close_warning + ",";
                Storage += "Radius:" + Info.Radius + ",";
                Storage += "Press_time:" + Info.Press_time;
                Echo("successfully saved settings");
            }
            catch
            {
                Storage = storage_backup;
                Echo("Failed to update storage, backup restored, current storage is:\n"+Storage);
            }
        }        
        public class Info_collection
        {
            public string Prefix = "HCS";
            public string Hanger_ID = "";
            public string Caller_ID = "";
            public int Timer_Counter = 0;
            public string Stored_arg = "";
            public string Status = "";
            public bool initalised = false;
            public bool Close_warning = true;
            public Dictionary<string, bool> Has_options = new Dictionary<string, bool>(7); //inner,outer,pilot,inpan,outpan,alarm,caller
            public float Radius = 7.5f;
            public double Press_time = 10;
            public Info_collection()
            {
                Has_options.Add("Inner_light(s)", false);
                Has_options.Add("Outer_light(s)", false);
                Has_options.Add("Pilot_light(s)", false);
                Has_options.Add("Inner_pannel(s)", false);
                Has_options.Add("Outer_pannels(s)", false);
                Has_options.Add("Alarm", false);
                Has_options.Add("Caller", false);
            }
        }
        public class Block_collection
        {
            public List<IMyDoor> Hanger_inner_doors = new List<IMyDoor>();
            public List<IMyAirtightHangarDoor> Hanger_outer_door = new List<IMyAirtightHangarDoor>();
            public List<IMyAirVent> Hanger_vents = new List<IMyAirVent>();
            public List<IMyTextSurface> Img_pannel = new List<IMyTextSurface>();
            public List<IMyInteriorLight> Hanger_inner_lights = new List<IMyInteriorLight>();
            public List<IMyInteriorLight> Hanger_outer_lights = new List<IMyInteriorLight>();
            public List<IMyInteriorLight> Pilot_light = new List<IMyInteriorLight>();
            public List<IMyTextPanel> Hanger_inner_pannels = new List<IMyTextPanel>();
            public List<IMyTextPanel> Hanger_outer_pannels = new List<IMyTextPanel>();
            public IMySoundBlock Hanger_alarm;
            public IMyProgrammableBlock Caller;
            public IMyTextSurface This_screen;
        }

        public void Set_ID(string arg)
        {
            Echo(string.Format("HCS: Changing hanger ID from: {} to {}", Info.Hanger_ID, arg));
            Info.Hanger_ID = arg;
        }
        public void Send_status()
        {
            sys_blocks.Caller.TryRun("HCS_SET_STATUS:" + Info.Status);
        }
        public void Update_block_collection()
        {
            IMyTextSurfaceProvider oPanel = Me as IMyTextSurfaceProvider;
            sys_blocks.This_screen = oPanel.GetSurface(0);
            sys_blocks.This_screen.ContentType = ContentType.TEXT_AND_IMAGE;
            sys_blocks.This_screen.FontSize = 3;
            sys_blocks.This_screen.Alignment = TextAlignment.CENTER;

            string Search_string = "[" + Info.Prefix + Info.Hanger_ID;
            Echo("Finding blocks with tags starting with:" + Search_string);
            try //getting the essential blocks
            {
                GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_inner_doors, b => b.CustomName.Contains(Search_string + "E]"));
                GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_outer_door, b => b.CustomName.Contains(Search_string + "D]"));
                GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_vents, b => b.CustomName.Contains(Search_string + "V]"));

                if (!sys_blocks.Hanger_inner_doors.Any())
                { Echo("HCS: CRITICAL: Failed to get Hanger entrance, please ensure it is taged correcty (argument 'help')"); return; }
                if (!sys_blocks.Hanger_outer_door.Any())
                { Echo("HCS: CRITICAL: Failed to get Hanger main door, please ensure it is taged correcty (argument 'help')"); return; }
                if (!sys_blocks.Hanger_vents.Any())
                { Echo("HCS: CRITICAL: Failed to get Hanger vent, please ensure it is taged correcty (argument 'help')"); return; }
            }
            catch
            {
                Echo("HCS: CRITICAL: Failed to get essential blocks, these are the vent and hanger inner and outer doors, please ensure they are taged correctly(argument 'help')");
                return;
            }
            //getting the lights
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_inner_lights, b => b.CustomName.Contains(Search_string + "LI]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_outer_lights, b => b.CustomName.Contains(Search_string + "LO]"));

            if (sys_blocks.Hanger_inner_lights.Any())
            { Info.Has_options["Inner_light(s)"] = true; }
            else { Info.Has_options["Inner_light(s)"] = false; }

            if (sys_blocks.Hanger_outer_lights.Any())
            { Info.Has_options["Outer_light(s)"] = true; }
            else { Info.Has_options["Outer_light(s)"] = false; }

            if (!Info.Has_options["Inner_light(s)"] || !Info.Has_options["Outer_light(s)"])
            {
                Echo("HCS: WARNING: failed to get standard lights (hanger x inner and outer), system will still function but will have no visual indicators, " +
                       "please ensure the lights are taged correctly (argument 'help')");
            }

            try  //getting the surface of the control pannel
            {
                List<IMyButtonPanel> ctrl_pannel = new List<IMyButtonPanel>();
                GridTerminalSystem.GetBlocksOfType(ctrl_pannel, b => b.CustomName.Contains(Search_string + "ICP]"));

                foreach (IMyButtonPanel P in ctrl_pannel)
                {
                    oPanel = P as IMyTextSurfaceProvider;
                    sys_blocks.Img_pannel.Add(oPanel.GetSurface(0));
                }
                foreach (IMyTextSurface TS in sys_blocks.Img_pannel)
                { TS.ContentType = ContentType.TEXT_AND_IMAGE; }
            }
            catch { Echo("HCS: INFO: No inner control pannel detected, please ensure it has the correct tag(argument 'help')"); }

            //getting the pilot light
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Pilot_light, b => b.CustomName.Contains(Search_string + "PL]"));
            if (sys_blocks.Pilot_light.Any())
            { Info.Has_options["Pilot_light(s)"] = true; }
            else { Info.Has_options["Pilot_light(s)"] = false; }

            if (Info.Has_options["Pilot_light(s)"] == false)
            { Echo("HCS: INFO: No pilot light detected, if this is an error use the 'help' argument for the tag"); }

            // getting the pannels, the checks are done this way since they dont always throw when returning null         
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_inner_pannels, b => b.CustomName.Contains(Search_string + "PI]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Hanger_outer_pannels, b => b.CustomName.Contains(Search_string + "PO]"));

            if (sys_blocks.Hanger_inner_pannels.Any())  // bool isempty = !list.any(); if (isempty)
            { Info.Has_options["Inner_pannel(s)"] = true; }
            else
            {
                Info.Has_options["Inner_pannel(s)"] = false;
                Echo("HCS: INFO: No inner pannels detected, if this is an error use the 'help' argument for the tag");
            }

            if (sys_blocks.Hanger_outer_pannels.Any())
            { Info.Has_options["Outer_pannel(s)"] = true; }
            else
            {
                Info.Has_options["Outer_pannel(s)"] = false;
                Echo("HCS: INFO: No outer pannels detected, if this is an error use the 'help' argument for the tag");
            }
            List<IMySoundBlock> Sounds = new List<IMySoundBlock>();
            GridTerminalSystem.GetBlocksOfType(Sounds, b => b.CustomName.Contains(Search_string + "A]"));
            if (Sounds.Any())
            {
                Info.Has_options["Alarm"] = true;
                sys_blocks.Hanger_alarm = Sounds[0];
            }
            else
            {
                Info.Has_options["Alarm"] = false;
                Echo("HCS: INFO: No hanger alarm detected, if this is an error use the 'help' argument for the tag");
            }
            try
            {
                GridTerminalSystem.GetBlockWithName(Info.Caller_ID);
                if (sys_blocks.Caller != null)
                {
                    Info.Has_options["Caller"] = true;
                }
                else { throw new ArgumentException("No caller"); }
            }
            catch
            {
                Info.Has_options["Caller"] = false;
                Echo("HCS: INFO: No caller block detected, if this is an error please use the SET_CALLER command and ensure the name is spelt correctly");
            }

            if (Info.initalised == false)
            {
                Info.initalised = true;
            }
            Echo("Block collection updated");
        }
        public Info_collection Info = new Info_collection();
        public Block_collection sys_blocks = new Block_collection();

        public void Main(string argument, UpdateType updateSource)
        {
            if (Info.Stored_arg != (""))
            {
                switch (Info.Stored_arg.ToUpper())
                {
                    case "HANGER_OPEN_END":
                        Info.Timer_Counter++;
                        if (Info.Timer_Counter >= Info.Press_time/1.4)
                        {
                            foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
                            {
                                if (D.Status.ToString().ToUpper() == "CLOSED") { D.Enabled = false; }
                                else { D.CloseDoor(); Info.Timer_Counter = 0; break; }
                            }
                            Hanger_control("HANGER_OPEN_END");
                        }
                        break;

                    case "HANGER_CLOSE_WARN_START":
                        Info.Timer_Counter++;
                        if (Info.Timer_Counter >= 4)
                        {
                            Info.Timer_Counter = 0;
                            Hanger_control("HANGER_CLOSE_START_W/WARN");
                        }
                        break;

                    case "HANGER_CLOSE_MID":
                        Info.Timer_Counter++;
                        if (Info.Timer_Counter >= 7)
                        {
                            Hanger_control("HANGER_CLOSE_MID");
                        }
                        break;

                    case "HANGER_CLOSE_END":
                        Info.Timer_Counter++;
                        if (Info.Timer_Counter >= Info.Press_time / 1.4)
                        {
                            Hanger_control("HANGER_CLOSE_END");
                        }
                        break;

                    case "AUTO_RESET_START":
                        Info.Timer_Counter++;
                        if (Info.Timer_Counter < 5)
                        {
                            End_timer();
                        }
                        break;

                    default:
                        Echo("ERROR: Invalid stored arg set, arg: " + Info.Stored_arg);
                        break;
                }
                return;
            }

            string arg = argument.ToUpper();
            if (arg.Contains(Info.Prefix.ToUpper() + "_"))
            { Echo("split incoming caller command from: " + arg + " to: " + arg.Split('_')[1]); arg = arg.Split('_')[1]; }
            if (arg.Contains("SET_ID"))
            {
                Set_ID(argument.Split(':')[1]);
                Echo("ID set to: " + Info.Hanger_ID);
                Save();
                return;
            }
            else if (arg.Contains("SET_PREFIX"))
            {
                Info.Prefix = arg.Split(':')[1].ToUpper();
                Save();
                Echo("Prefix set to: " + Info.Prefix);
            }
            else if (arg.Contains("SET_CALLER"))
            {
                Info.Caller_ID = arg.Split(':')[1].ToUpper();
                Echo("Caller_ID set to: " + Info.Caller_ID);
                Update_block_collection();
                Save();
            }
            else if (arg.Contains("SET_RADIUS:"))
            {
                Info.Radius = float.Parse(arg.Split(':')[1]);
                Save();
                Echo("Radius set to: " + Info.Radius);
            }
            else if (arg.Contains("SET_TIME:"))
            {
                Info.Press_time = double.Parse(arg.Split(':')[1]);
                Save();
                Echo("Hanger pressure time set to: " + Info.Press_time);
            }
            else
            {
                switch (arg)
                {
                    case "OPEN":
                        Hanger_control("HANGER_OPEN");
                        break;
                    case "CLOSE":
                        Hanger_control("HANGER_CLOSE");
                        break;
                    case "CHECK_INIT":
                        if (Info.initalised == true)
                        { Echo("System is initalised"); }
                        else
                        { Echo("System is not initalised"); }
                        break;
                    case "HELP":
                        string Tag = "[" + Info.Prefix + Info.Hanger_ID;
                        Echo("This script is designed to control a single hanger, use multiple programmable blocks for mulitple hangers\n " +
                       "This script uses tags to identify it's blocks (see below)\n\n" +
                       "Available commands:\n" +
                       "To open the hanger call this block with the argument as open.\nTo close the hanger do the same but with close. \n\n" +
                       "Helper functions:\n" +
                       "Check_init(Prints if the system is initalised or not)\n" +
                       "Update blocks/ Init/ Initalise/ Re-init/ Re-initalise (Attempts to re-fetch the system's blocks)\n" +
                       "Warn(Toggle a 5 second warning before the hanger starts the close, Warning: disabling can lead to crushed ships)\n" +
                       "Check/Status(prints hanger status)\nReset(Forces the hanger into a proper closed state)\n" +
                       "Set_ID:name, Sets the hanger name to everything after the :, eg: Set_ID:H1 sets the name to H1, this is used in tags so shoud be short\n" +
                       "Set_prefix:prefix, sets the prefix used by the system tags to everything after the : capitalised, default is HCS, eg Set_prefix:hangers\n" +
                       "Show_prefix/prefix: displays the current system prefix\nReset_prefix: sets the system prefix back to the default of 'HCS'\n" +
                       "Set_caller: use with the name of the caller block eg:Set_caller:Controler, or from the caller: prefix_Set_caller:name\n" +
                       "Set_radius: sets the radius of system lights to the value input after the :\n" +
                       "Set_Time: Sets the time the system waits for the hanger to pressure cycle to the input value(checks every 100 ticks, so it may open up to 1.4s later than expected)\n" +
                       "Send_status: send the current status of the hanger to the caller/controling block(requires a caller block)\n" +
                       "Expected tags, each block utilised by the system will need the correct tag to work properly:\n" +
                       "entrance:" + Tag + "E] tag for every entrance to the hanger\n" +
                       "Outer door:" + Tag + "D] for the airtight hanger doors\n" +
                       "Vent:" + Tag + "V]Hanger X vent\n" +
                       "(recomended)Inner light:" + Tag + "LI] For indicator lights located inside the hanger/ship\n" +
                       "(recomended)Outer light:" + Tag + "LO] For indicator lights located outside the hanger door, used to display status to incoming ships\n" +
                       "(opt)Control pannel:" + Tag + "ICP] For the inner button pannel to display a depressurised warning\n" +
                       "(opt)Pilot light:" + Tag + "PL] an extra light positioned to help the pilot see the hanger status\n" +
                       "(opt)Hanger pannels: " + Tag + "PI]/" + Tag + "PO] for text displays, inner/outer determined similar to inner/outer lights(" + Tag + "LI]/" + Tag + "LO])\n" +
                       "(opt)Alarm:" + Tag + "A] to provide an audio warning\n" +
                       "(opt)Caller: use the name of the block that calls this system's block(set using SET_CALLER:name)");
                        break;

                    case "UPDATE_BLOCKS":                        
                    case "INITALISE":
                    case "RE-INIT":
                    case "RE-INITALISE":
                        Update_block_collection();
                        Save();
                        break;
                    case "WARN":
                        if (Info.Close_warning == true)
                        {
                            Info.Close_warning = false;
                            Echo("Hanger close warning disabled, use caution.");
                        }
                        else
                        {
                            Info.Close_warning = true;
                            Echo("Hanger close warning enabled.");
                        }
                        Save();
                        break;
                    case "CHECK":
                    case "STATUS":
                        Status_codes();
                        break;
                    case "SETTINGS":
                    case "CHECK_SETTINGS":
                        Check_settings();
                        break;
                    case "DETECT_SETTINGS":
                    case "DETECT SETTINGS":
                        Detect_settings();
                        break;
                    case "SEND_STATUS":
                        Send_status();
                        break;

                    case "RESET":
                        Echo("WARNING: Attempting to force reset hanger to closed");
                        try
                        {
                            foreach (IMyDoor D in sys_blocks.Hanger_outer_door)
                            { D.CloseDoor(); }
                            foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
                            { D.CloseDoor(); }
                            foreach (IMyAirVent V in sys_blocks.Hanger_vents)
                            { V.Depressurize = false; }
                            foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                            { Light_safe(L); }
                            foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                            { Light_danger(L); }
                            Info.Status = "CLOSED";
                            if (Info.Has_options["Caller"])
                            { Send_status(); }
                            Echo("INFO: Hanger successfully reset to safe(closed) condition");
                        }
                        catch
                        {
                            Echo("ERROR: Failed to reset hanger to safe condition, manual intervention required.");
                        }
                        break;
                    case "SHOW_PREFIX":
                        Echo("HCS: INFO: Prefix is currently: " + Info.Prefix + ", use SET_PREFIX:x to modify it, or RESET_PREFIX to reset it to HCS.");
                        break;
                    case "RESET_PREFIX":
                        Info.Prefix = "HCS";
                        Echo("HCS: INFO: Prefix reset to HCS, use SET_PREFIX:x to modify.");
                        Save();
                        break;
                    case "SAVE":
                        Save();
                        break;
                    case "STORAGE":
                    case "SHOW_STORAGE":
                        Echo(Storage);
                        break;
                    default:
                        Echo("Error: input argument does not match any recognised command, input: " + arg);
                        break;
                }
            }
        }
        public void Display_status(string status ="")
        {
            if ( status == "")
            { status = Info.Status; }
            sys_blocks.This_screen.WriteText("ID: " + Info.Prefix + "" + Info.Hanger_ID + "\nStatus:\n" + status);
            
            switch(status)
            {
                case "CLOSED":
                    sys_blocks.This_screen.FontColor = Color.Green;
                    sys_blocks.This_screen.ClearImagesFromSelection();
                    break;
                case "OPEN":
                case "UNKNOWN":
                    sys_blocks.This_screen.FontColor = Color.Red;
                    sys_blocks.This_screen.AddImageToSelection("Danger");
                    break;
                case "CLOSING":
                case "OPENING":
                    sys_blocks.This_screen.FontColor = Color.Yellow;
                    break;
                default:
                    sys_blocks.This_screen.FontColor = Color.White;
                    sys_blocks.This_screen.ClearImagesFromSelection();
                    break;
            }
        }
        public void Light_in_progress(IMyInteriorLight L)
        {
            L.Color = Color.Yellow;
            L.BlinkIntervalSeconds = 0.6f;
            L.BlinkLength = 50;
            L.Radius = Info.Radius;
        }
        public void Light_safe(IMyInteriorLight L)
        {
            L.Color = Color.Green;
            L.BlinkIntervalSeconds = 5;
            L.BlinkLength = 95;

        }
        public void Light_danger(IMyInteriorLight L)
        {
            L.Color = Color.Red;
            L.BlinkIntervalSeconds = 1;
            L.BlinkLength = 50;
        }

        public void Hanger_control(string arg)
        {
            switch (arg.ToUpper())
            {
                case "HANGER_OPEN":
                    if (Info.Status == "OPEN")
                    {
                        Echo("HCS: Warning: Attempted to open hanger while already open, procedure aborted");
                        return;
                    }
                    Echo("Opening...");
                    foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
                    {if (D.Enabled == false) { D.Enabled = true; }
                        D.CloseDoor(); 
                    }
                    foreach (IMyAirVent V in sys_blocks.Hanger_vents)
                    { V.Depressurize = true; }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                    { Light_in_progress(L); }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                    { Light_in_progress(L); }
                    if (Info.Has_options["Pilot_light(s)"])
                    {
                        foreach (IMyInteriorLight L in sys_blocks.Pilot_light)
                        { Light_in_progress(L); }
                    }
                    if (Info.Has_options["Inner_pannel(s)"])
                    {
                        foreach (IMyTextPanel P in sys_blocks.Hanger_inner_pannels)
                        {
                            P.ContentType = ContentType.TEXT_AND_IMAGE;
                            P.WriteText("OPENING");
                            P.FontColor = Color.Yellow;
                        }
                    }
                    if (Info.Has_options["Outer_pannel(s)"])
                    {
                        foreach (IMyTextPanel P in sys_blocks.Hanger_outer_pannels)
                        {
                            P.ContentType = ContentType.TEXT_AND_IMAGE;
                            P.WriteText("HANGER\nOPENING");
                            P.FontColor = Color.Yellow;
                        }
                    }
                    if (Info.Has_options["Alarm"] == true)
                    { sys_blocks.Hanger_alarm.Play(); }
                    Display_status("OPENING");
                    Info.Stored_arg = "HANGER_OPEN_END";
                    Runtime.UpdateFrequency = UpdateFrequency.Update100;
                    break;

                case "HANGER_OPEN_END":
                    if (Info.Stored_arg == "HANGER_OPEN_END")
                    {
                        foreach (IMyAirtightHangarDoor D in sys_blocks.Hanger_outer_door)
                        { D.OpenDoor(); }
                        foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                        { Light_safe(L); }
                        foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                        { Light_danger(L); }
                        if (Info.Has_options["Pilot_light(s)"])
                        {
                            foreach (IMyInteriorLight L in sys_blocks.Pilot_light)
                            { Light_safe(L); }
                        }
                        if (Info.Has_options["Inner_pannel(s)"])
                        {
                            foreach (IMyTextPanel P in sys_blocks.Hanger_inner_pannels)
                            {
                                P.ContentType = ContentType.TEXT_AND_IMAGE;
                                P.WriteText("OPEN");
                                P.FontColor = Color.Red;
                            }
                        }
                        if (Info.Has_options["Outer_pannel(s)"])
                        {
                            foreach (IMyTextPanel P in sys_blocks.Hanger_outer_pannels)
                            {
                                P.ContentType = ContentType.TEXT_AND_IMAGE;
                                P.WriteText("HANGER\nOPEN");
                                P.FontColor = Color.Green;
                            }
                        }
                        if (Info.Has_options["Alarm"] == true)
                        { sys_blocks.Hanger_alarm.Stop(); }
                        foreach (IMyTextSurface TS in sys_blocks.Img_pannel)
                        {
                            try { TS.AddImageToSelection("Danger"); } catch { }
                        }
                        foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
                        {
                            if (D.Enabled == true) { D.Enabled = false; }
                        }
                        End_timer();
                        Info.Status = "OPEN";
                        Display_status();
                        if (Info.Has_options["Caller"])
                        { Send_status(); }

                        Echo("Hanger open");
                    }
                    else { Echo("ERROR: Cannot directly call HANGER_OPEN_END, call OPEN instead"); }
                    break;

                case "HANGER_CLOSE":
                    Echo("Hanger closing...");
                    if (Info.Status == "CLOSED")
                    {
                        Echo("HCS:Warning: Attempted to close hanger while already closed, procedure aborted");
                        return;
                    }
                    Echo("Hanger closing...");
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                    { Light_in_progress(L); }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                    { Light_in_progress(L); }
                    if (Info.Has_options["Pilot_light(s)"])
                    {
                        foreach (IMyInteriorLight L in sys_blocks.Pilot_light)
                        { Light_danger(L); }
                    }
                    if (Info.Has_options["Inner_pannel(s)"])
                    {
                        foreach (IMyTextPanel P in sys_blocks.Hanger_inner_pannels)
                        {
                            P.ContentType = ContentType.TEXT_AND_IMAGE;
                            P.WriteText("CLOSING");
                            P.FontColor = Color.Yellow;
                        }
                    }
                    if (Info.Has_options["Outer_pannel(s)"])
                    {
                        foreach (IMyTextPanel P in sys_blocks.Hanger_outer_pannels)
                        {
                            P.ContentType = ContentType.TEXT_AND_IMAGE;
                            P.WriteText("WARNING:\nCLOSING");
                            P.FontColor = Color.Red;
                        }
                    }
                    if (Info.Has_options["Alarm"] == true)
                    { sys_blocks.Hanger_alarm.Play(); }

                    if (Info.Close_warning == true)
                    {
                        Info.Stored_arg = "HANGER_CLOSE_WARN_START";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                    }
                    else
                    {
                        foreach (IMyAirtightHangarDoor D in sys_blocks.Hanger_outer_door)
                        { D.CloseDoor(); }

                        Info.Stored_arg = "HANGER_CLOSE_MID";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                    }
                    Display_status("CLOSING");
                    break;

                case "HANGER_CLOSE_START_W/WARN":
                    foreach (IMyAirtightHangarDoor D in sys_blocks.Hanger_outer_door)
                    { D.CloseDoor(); }

                    Info.Stored_arg = "HANGER_CLOSE_MID";
                    break;

                case "HANGER_CLOSE_MID":
                    if (Info.Stored_arg == "HANGER_CLOSE_MID")
                    {
                        foreach (IMyAirVent V in sys_blocks.Hanger_vents)
                        { V.Depressurize = false; }
                        foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                        { Light_danger(L); }
                        if (Info.Has_options["Outer_pannel(s)"])
                        {
                            foreach (IMyTextPanel P in sys_blocks.Hanger_outer_pannels)
                            { P.WriteText("CLOSED"); }
                        }

                        Info.Stored_arg = "HANGER_CLOSE_END";
                    }
                    else { Echo("ERROR: Cannot directly call HANGER_CLOSE_MID, call CLOSE instead"); }
                    break;

                case "HANGER_CLOSE_END":
                    if (Info.Stored_arg == "HANGER_CLOSE_END")
                    {
                        foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                        { Light_safe(L); }
                        if (Info.Has_options["Inner_pannel(s)"])
                        {
                            foreach (IMyTextPanel P in sys_blocks.Hanger_inner_pannels)
                            { P.WriteText("CLOSED"); P.FontColor = Color.Green; }
                        }
                        foreach (IMyTextSurface TS in sys_blocks.Img_pannel)
                        {
                            try { TS.ClearImagesFromSelection(); } catch { }
                        }
                        foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
                        {
                            if (D.Enabled == false) { D.Enabled = true; }
                        }
                        if (Info.Has_options["Alarm"] == true)
                        { sys_blocks.Hanger_alarm.Stop(); }
                        End_timer();
                        Info.Status = "CLOSED";
                        Display_status();
                        if (Info.Has_options["Caller"])
                        { Send_status(); }
                        Echo("Hanger closed");
                    }
                    else { Echo("ERROR: Cannot directly call HANGER_CLOSE_END, call CLOSE instead"); }
                    break;
                case "HCS_EMG_OPEN":                  //Immediately open the hanger in an emergency                 
                    foreach (IMyAirtightHangarDoor D in sys_blocks.Hanger_outer_door)
                    { D.OpenDoor(); }
                    foreach (IMyAirVent V in sys_blocks.Hanger_vents)
                    { V.Depressurize = true; }
                    foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
                    { D.CloseDoor(); }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                    { L.Color = Color.Red; }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                    { L.Color = Color.Yellow; }
                    Display_status("OPEN");
                    break;

                case "HCS_EMG_CLOSE":                  //Immediately close the hanger in an emergency
                    foreach (IMyAirtightHangarDoor D in sys_blocks.Hanger_outer_door)
                    { D.CloseDoor(); }
                    foreach (IMyAirVent V in sys_blocks.Hanger_vents)
                    { V.Depressurize = false; }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
                    { L.Color = Color.Yellow; }
                    foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
                    { L.Color = Color.Red; }
                    Display_status("CLOSED");
                    break;

                default:
                    Echo("ERROR: Hanger argument does not match to any configured hanger command");
                    break;
            }
        }
        public void Status_codes()
        {
            int[] Status_list = new int[5]; //innerD, outerD, vent, innerL, outerL 0= not set, 0< expected results          
            if (sys_blocks.Hanger_inner_doors[0].Status.ToString().ToUpper() == "CLOSED") { Status_list[0] = 3; } else { Status_list[0] = 2; }//1=mixed, 2=open, 3=closed
            foreach (IMyDoor D in sys_blocks.Hanger_inner_doors)
            {
                if (D.Status != sys_blocks.Hanger_inner_doors[0].Status)
                { Status_list[0] = 1; break; }
            }

            if (sys_blocks.Hanger_outer_door[0].Status.ToString().ToUpper() == "CLOSED") { Status_list[1] = 3; } else { Status_list[1] = 2; } //1=mixed, 2=open, 3=closed
            foreach (IMyAirtightHangarDoor D in sys_blocks.Hanger_outer_door)
            {
                if (D.Status != sys_blocks.Hanger_outer_door[0].Status)
                { Status_list[1] = 1; break; }
            }
            if (sys_blocks.Hanger_vents[0].Depressurize == true) { Status_list[2] = 2; } else { Status_list[2] = 3; }//1=mixed 2 = depress, 3 = press
            foreach (IMyAirVent V in sys_blocks.Hanger_vents)
            {
                if (V.Depressurize != sys_blocks.Hanger_vents[0].Depressurize)
                { Status_list[2] = 1; break; }
            }

            //Checking the standard lights
            if (sys_blocks.Hanger_inner_lights[0].Color == Color.Red) { Status_list[3] = 2; } //1=mixed 2=red 3=green 4=yellow 5=unexpected 
            else if (sys_blocks.Hanger_inner_lights[0].Color == Color.Green) { Status_list[3] = 3; }
            else if (sys_blocks.Hanger_inner_lights[0].Color == Color.Yellow) { Status_list[3] = 4; }
            else { Status_list[3] = 5; }
            foreach (IMyInteriorLight L in sys_blocks.Hanger_inner_lights)
            {
                if (L.Color != sys_blocks.Hanger_inner_lights[0].Color)
                { Status_list[3] = 1; break; }
            }

            if (sys_blocks.Hanger_outer_lights[0].Color == Color.Red) { Status_list[4] = 2; } //1=mixed 2=red 3=green 4=yellow 5=unexpected 
            else if (sys_blocks.Hanger_outer_lights[0].Color == Color.Green) { Status_list[4] = 3; }
            else if (sys_blocks.Hanger_outer_lights[0].Color == Color.Yellow) { Status_list[4] = 4; }
            else { Status_list[4] = 5; }
            foreach (IMyInteriorLight L in sys_blocks.Hanger_outer_lights)
            {
                if (L.Color != sys_blocks.Hanger_outer_lights[0].Color)
                { Status_list[4] = 1; break; }
            }

            //output gen    
            String Output = "Check results: "; //expected cases
            if (Status_list[1] == 3 && Status_list[2] == 3 && Status_list[3] == 3 && Status_list[4] == 2)
            { Output += "Hanger is closed normaly"; }
            else if (Status_list[1] == 3 && Status_list[2] == 3)
            { if (Status_list[3] != 3 || Status_list[4] != 2) { Output += "Hanger is closed safely, but the lights are incorrect"; } }
            else if (Status_list[1] == 3 && Status_list[2] != 3)
            { Output += "Hanger is closed, but the vent(s) are in an unexpected condition, possible improper depressurisation"; }
            else if (Status_list[0] == 1 && Status_list[1] == 3 && Status_list[2] == 3)
            { Output += "Hanger is closed safely and the entrances are in mixed states"; }
            else if (Status_list[1] == 3 && Status_list[2] == 2)
            { Output += "Hanger is closed, but is depressurising, vacuum likely"; }
            else if (Status_list[0] == 3 && Status_list[1] == 2 && Status_list[3] == 2 && Status_list[4] == 3)
            { Output += "Hanger is open normaly"; }
            else if (Status_list[0] == 3 && Status_list[1] == 2)
            { if (Status_list[3] != 2 || Status_list[4] != 3) Output += "Hanger is open safely, but the lights are incorrect"; }
            else if (Status_list[0] == 3 && Status_list[1] == 2 && Status_list[2] != 2)
            { Output += "Hanger is open safely, but the vent(s) are in an unexpected condition"; }
            else if (Status_list[0] != 3 && Status_list[1] == 2)
            { Output += "Hanger is open, along with at least one entrance, Warning: possible wider depressurisation."; }
            else  //unexpected cases
            {
                Output += "Hanger is in a mixed state, details:\n";
                switch (Status_list[0])
                {
                    case 1: Output += "Entrances are in mixed states"; break;
                    case 2: Output += "All entrances are open\n"; break;
                    case 3: Output += "All entrances are closed\n"; break;
                    default: Output += "Unable to determine status of inner door\n"; break;
                }
                switch (Status_list[1])
                {
                    case 1: Output += "Outer door segments are in mixed states\n"; break;
                    case 2: Output += "Outer door is open\n"; break;
                    case 3: Output += "Outer door is closed\n"; break;
                    default: Output += "Unable to determine status of outer door\n"; break;
                }
                switch (Status_list[2])
                {
                    case 1: Output += "Vents are in mixed states\n"; break;
                    case 2: Output += "Hanger is depressurising\n"; break;
                    case 3: Output += "Hanger is pressurising\n"; break;
                    default: Output += "Unable to determine status of hanger vent\n"; break;
                }
                switch (Status_list[3])
                {
                    case 1: Output += "Inner lights are mixed colours"; break;
                    case 2: Output += "Inner light is red\n"; break;
                    case 3: Output += "Inner light is green\n"; break;
                    case 4: Output += "Inner light is yellow\n"; break;
                    case 5: Output += "Inner light is an unexpected colour\n"; break;
                    default: Output += "Unable to determine status of inner light\n"; break;
                }
                switch (Status_list[4])
                {
                    case 1: Output += "Outer lights are mixed colours"; break;
                    case 2: Output += "Outer light is red\n"; break;
                    case 3: Output += "Outer light is green\n"; break;
                    case 4: Output += "Outer light is yellow\n"; break;
                    case 5: Output += "Outer light is an unexpected colour\n"; break;
                    default: Output += "Unable to determine status of outer light\n"; break;
                }
            }
            Echo(Output);
        }
        public void End_timer()
        {
            Info.Stored_arg = "";
            Info.Timer_Counter = 0;
            Runtime.UpdateFrequency = UpdateFrequency.None;
        }
        public void Check_settings()
        {
            string Output = "HCS: The hanger's primary settings are as follows:\nHanger ID: " + Info.Hanger_ID + "\nStored arg: " + Info.Stored_arg + "\nStatus: " + Info.Status + "\n";
            if (Info.initalised)
            { Output += "Initalised: True\n"; }
            else { Output += "Initalised: False\n"; }

            if (Info.Close_warning)
            { Output += "Close warning: Enabled\n"; }
            else { Output += "Close warning: Disabled\n"; }

            if (Info.Has_options["Inner_light(s)"] && Info.Has_options["Outer_light(s)"])
            { Output += "Has Standard lights: True\n"; }
            else { Output += "Has Standard lights: False\n"; }

            if (Info.Has_options["Pilot_light(s)"])
            { Output += "Has pilot light: True\n"; }
            else { Output += "Has pilot light: False\n"; }

            if (Info.Has_options["Inner_pannel(s)"] || Info.Has_options["Outer_pannel(s)"])
            { Output += "Has pannels: True\n"; }
            else { Output += "Has pannels: False\n"; }

            if (Info.Has_options["caller"])
            { Output += "Has caller: True\n"; }
            else { Output += "Has Caller: False\n"; }

            Output += "\n extra settings:\n";
            if(Info.Close_warning)
            { Output += "Close warning: false\n"; }
            else { Output += "Close warning: false\n"; }
            Output += "Light radius: " + Info.Radius +"\n";
            Output += "Pressure toggle time: " + Info.Press_time+"\n";

            Output += "Use 'Detect_settings' to change the block settings, use 'Warn' to toggle the closing warning";
            Echo(Output);
        }

        public void Detect_settings()
        {
            if (sys_blocks.Hanger_inner_doors == null || sys_blocks.Hanger_outer_door == null || sys_blocks.Hanger_vents == null)
            {
                Echo("HCS: CRITICAL: Failed to get essential blocks, these are the vent and hanger inner and outer doors, please ensure they are named correctly(argument 'help')");
            }

            if (sys_blocks.Hanger_inner_lights.Any())
            { Info.Has_options["Inner_light(s)"] = true; }
            else
            {
                Info.Has_options["Inner_light(s)"] = false; Echo("HCS: WARNING: failed to get standard lights (hanger x inner and outer), system will still function but will have no visual indicators, " +
                "please ensure the lights are named correctly(argument 'help')");
            }
            if (sys_blocks.Hanger_outer_lights.Any())
            { Info.Has_options["Outer_light(s)"] = true; }
            else { Info.Has_options["Outer_light(s)"] = true; }

            if (!Info.Has_options["Inner_light(s)"] || !Info.Has_options["Outer_light(s)"])
            {
                Echo("HCS: WARNING: failed to get standard lights (hanger x inner and outer), system will still function but will have no visual indicators, " +
                       "please ensure the lights are named correctly(argument 'help')");
            }

            if (sys_blocks.Pilot_light.Any())
            { Info.Has_options["Pilot_light(s)"] = true; }
            else { Info.Has_options["Pilot_light(s)"] = false; Echo("HCS: INFO: No pilot light detected, if this is an error use the 'help' argument for the name if this is wrong"); }

            if (sys_blocks.Hanger_inner_pannels.Any())
            { Info.Has_options["Inner_pannel(s)"] = true; }
            else { Info.Has_options["Inner_pannel(s)"] = false; Echo("HCS: INFO: No hanger inner pannels detected, if this is an error use the 'help' argument for the name if this is wrong"); }

            if (sys_blocks.Hanger_outer_pannels.Any())
            { Info.Has_options["Outer_pannel(s)"] = true; }
            else { Info.Has_options["Outer_pannel(s)"] = false; Echo("HCS: INFO: No hanger outer pannels detected, if this is an error use the 'help' argument for the name if this is wrong"); }

            if (sys_blocks.Hanger_alarm != null)
            { Info.Has_options["Alarm"] = true; }
            else { Info.Has_options["Alarm"] = false; Echo("HCS: INFO: No hanger alarm detecte, if this is an error use the 'help' argument for the name if this is wrong"); }

            string Output = "HCS: Status: " + Info.Status + ", Hanger ID: " + Info.Hanger_ID;
            if (Info.initalised)
            { Output += ", System initalised"; }
            else { Output += ", System not initalised"; }
            if (Info.Close_warning)
            { Output += ", Close warning enabled"; }
            else { Output += ", Close warning disabled"; }

            Echo("HCS: Settings set based on detected blocks");
        }
