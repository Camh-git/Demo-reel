public Program()
        {
            // The constructor
            string[] Storage_data = Storage.Split(',');
            try
            {
                Info.prefix = Storage_data[0].Split(':')[1];
                Info.Current_alert = Storage_data[1].Split(':')[1];
                Info.Lock_brig_on_alert = Convert.ToBoolean(Storage_data[2].Split(':')[1]);
                Info.Has_caller = Convert.ToBoolean(Storage_data[3].Split(':')[1]);
                Info.Disable_weps_on_all_clear = Convert.ToBoolean(Storage_data[4].Split(':')[1]);
                Info.SD_info["Code"] = Storage_data[5].Split(':')[1];
            }
            catch { Echo("Failed to load settings, ignore if first run"); }
        }
        public void Save()
        {
            string Backup = Storage;
            try
            {
                Storage = "";
                Storage += "prefix:" + Info.prefix + ",";
                Storage += "Current_alert:" + Info.Current_alert + ",";
                Storage += "Lock_brig_on_alert:" + Info.Lock_brig_on_alert + ",";
                Storage += "Caller:" + Info.Has_caller + ",";
                Storage += "Disable_weps_on_AC:" + Info.Disable_weps_on_all_clear + ",";
                Storage += "SD_CODE:" + Info.SD_info["Code"] + ",";
                Storage += "RA_colour:" + Info.Red_alert_colour + ",";
                Storage += "YA_colour:" + Info.Yellow_alert_colour + ",";
                Storage += "BA_colour:" + Info.Blue_alert_colour + ",";
                Storage += "GA_colour:" + Info.Green_alert_colour + ",";

            }
            catch
            {
                Storage = Backup;
                Echo("Failed to update storage, backup restored, current storage is:\n" + Storage);
            }
        }
        /* Collection objects */
        public class Info_collection
        {
            public Color Red_alert_colour = new Color(255, 0, 0, 0);            
            public Color Yellow_alert_colour = new Color(255, 255, 0, 0);
            public Color Blue_alert_colour = new Color(0, 0, 255, 0);
            public Color Green_alert_colour = new Color(0, 255, 0, 0);
            public Dictionary<string, string> SD_info = new Dictionary<string, string>(2);
            public String Current_alert = "N";  //Options: N "None", "R" red, "Y",Yellow, "B" blue, "G" green
            public string Stored_arg = "";
            public int Timer_Counter = 0;
            public bool Pending_RA = false;
            public bool Lock_brig_on_alert = false;
            public bool Has_caller = false; 
            public bool Disable_weps_on_all_clear = false;
            public string prefix = "ALT";
            public Dictionary<string, bool> Power_status = new Dictionary<string, bool>();
            public Dictionary<string, string> Bat_status = new Dictionary<string, string>();

            public Info_collection()
            {               
                SD_info.Add("Code", "");
                SD_info.Add("Status", "UNARMED");
            }
        }
        public class Block_collection
        {
            //Alert blocks
            public List<IMyTextPanel> Alert_pannels = new List<IMyTextPanel>();
            public List<Pannel_settings> Alt_panel_defaults = new List<Pannel_settings>();
            public List<IMyReflectorLight> Alt_rot_lights = new List<IMyReflectorLight>();
            public List<IMyInteriorLight> Alt_lights = new List<IMyInteriorLight>();
            public List<IMyUserControllableGun> Weapons = new List<IMyUserControllableGun>();
            public List<IMyLargeGatlingTurret> Gun_turrets = new List<IMyLargeGatlingTurret>();
            public List<IMyLargeMissileTurret> Missile_turrets = new List<IMyLargeMissileTurret>();
            public IMySoundBlock Alert_siren;

            //misc other
            public List<IMyWarhead> Destruct_blocks = new List<IMyWarhead>();
            public bool initalised = false;
            public bool alt_pannel_defs_set = false;
            public IMyTextSurface This_screen;

           
            public List<IMySoundBlock> Hanger_audio_warning = new List<IMySoundBlock>(); //also used by some alerts
            public List <IMyDoor> Escape_doors = new List<IMyDoor>(); //doors that should be active in alerts
            public List <IMyDoor> Restricted_doors = new List<IMyDoor>(); //doors that should be locked in alerts
            public List<IMyDoor> Brig_doors = new List<IMyDoor>(); //so that the brig can be locked seperatly from all restricted doors
            public List<IMyAirtightHangarDoor> Brig_bulkheads = new List<IMyAirtightHangarDoor>();
            public IMyProgrammableBlock Caller;

            public Block_collection()
            { }
        }      
        public void Update_Block_collection(UpdateType updateSource)
        {
            IMyTextSurfaceProvider oPanel = Me as IMyTextSurfaceProvider;
            sys_blocks.This_screen = oPanel.GetSurface(0);
            sys_blocks.This_screen.ContentType = ContentType.TEXT_AND_IMAGE;
            sys_blocks.This_screen.FontSize = 3;
            sys_blocks.This_screen.Alignment = TextAlignment.CENTER;

            string tag = "[" + Info.prefix;
            //this can be used to add/update the blocks used in block collections, since i cant get block collections constructor to take updatesource and be public
            List<IMySoundBlock> sounds = new List<IMySoundBlock>();
            GridTerminalSystem.GetBlocksOfType(sounds, b => b.CustomName.Contains(tag + "S]"));
            if (sounds.Any()) { sys_blocks.Alert_siren = sounds[0]; }          
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Escape_doors, b => b.CustomName.Contains(tag + "ED]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Restricted_doors, b => b.CustomName.Contains(tag + "RD]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Brig_doors, b => b.CustomName.Contains(tag + "BD]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Alert_pannels, b => b.CustomName.Contains(tag + "P"));
            List<IMyFunctionalBlock> lights = new List<IMyFunctionalBlock>();
            GridTerminalSystem.GetBlocksOfType(lights, b => b.CustomName.Contains(tag + "L]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Weapons, b => b.CustomName.Contains(tag + "W]"));
            GridTerminalSystem.GetBlocksOfType(sys_blocks.Brig_bulkheads, b => b.CustomName.Contains(tag + "BLD]"));
            foreach (IMyFunctionalBlock B in lights)
            {
                //This whole setup is here to allow the user to tag all their lights with [prefixL], the things we do for UX.
                string type_string = GridTerminalSystem.GetBlockWithName(B.CustomName).GetType().ToString();
                type_string = type_string.Split('.')[type_string.Split('.').Length - 1]; //this is needed since everything is technicaly Sandbox.Game.Entities.x
                switch (type_string)
                {
                    case "MyInteriorLight":
                        IMyInteriorLight L = GridTerminalSystem.GetBlockWithName(B.CustomName) as IMyInteriorLight;
                        sys_blocks.Alt_lights.Add(L);
                        break;
                    case "MyReflectorLight":
                        IMyReflectorLight RL = GridTerminalSystem.GetBlockWithName(B.CustomName) as IMyReflectorLight;
                        sys_blocks.Alt_rot_lights.Add(RL);
                        break;
                    case "MyFunctionalBlock":
                        Echo("Error: type of block: " + B.CustomName + " resolved to IMyFunctionalBlock\n");
                        break;
                    default:
                        Echo("Error: block: " + B.CustomName + " did not resolve to any valid type, please ensure it is a light block, its type was:" + type_string + "\n");
                        break;
                }
            }
            lights.Clear();

            if (sys_blocks.alt_pannel_defs_set == false)
            {
                Echo("pannel defaults updated: " + DateTime.Now);
                Set_pannel_defs();
            }
            sys_blocks.initalised = true;
            Fetch_power_settings();
            Echo("Blocks updated: " + DateTime.Now);
        }

        public Info_collection Info = new Info_collection();
        public Block_collection sys_blocks = new Block_collection();

        /* End of collection objects */

        public void Main(string argument, UpdateType updateSource)
        {
            if (sys_blocks.initalised == false)
            { Update_Block_collection(updateSource); }
            //clean input
            string arg = argument.ToUpper();
            
            if (Info.Stored_arg != "")
            {
                switch(Info.Stored_arg)
                {
                    case "ALT_EMG_DOOR_LOCK":
                        Manage_alert("ALT_EMG_DOOR_LOCK");
                        break;
                    case "RA_LOCK_RES_DOORS":
                        foreach (IMyDoor D in sys_blocks.Restricted_doors)
                        { D.Enabled = false; }
                        End_timer();
                        break;
                    case "ALT_GREEN_CD":
                        Info.Timer_Counter++;
                        if (Info.Timer_Counter >= 6)
                        {
                            Manage_alert("ALT_GREEN");
                        }
                        break;
                    case "LOCK_BRIG_DOOR":
                        foreach (IMyDoor D in sys_blocks.Brig_doors)
                        { D.Enabled = false; }
                        End_timer();
                        break;
                    default:
                        Echo("ALERT CONTROLLER: ERROR: The stored arg paramater does not match any known command. storged ar: " + Info.Stored_arg);
                        break;
                }
            }
            if (arg.Contains("ALT_"))
            {
                Manage_alert(arg);
                return;
            }
            else if (arg.Contains("SET_CALLER:"))
            {
                Set_caller(arg.Split(':')[1]);
                return;
            }
            else if (arg.Contains("SET_PREFIX:"))
            {
                Info.prefix = arg.Split(':')[1];
                Echo("Alert controler: prefix updated to: " + Info.prefix);
            }
            else if (arg.Contains("CHANGE_COLOUR:") || arg.Contains("CHANGE_COLOR:"))
            {
                //selects the target colour, then converts the hex colour input to the games format
                //uses the format:  CHANGE_COLOUR:target:hexColour  eg: CHANGE_COLOUR:COMBAT:ffffff
                switch (arg.Split(':')[1])
                {
                    case "RED":
                    case "COMBAT":
                        Info.Red_alert_colour = new Color(Convert.ToUInt32(arg.Split(':')[2], 16));
                        break;
                    case "YELLOW":
                    case "HAZARD":
                        Info.Yellow_alert_colour = new Color(Convert.ToUInt32(arg.Split(':')[2], 16));
                        break;
                    case "BLUE":
                    case "WARNING":
                    case "CAUTION":
                        Info.Blue_alert_colour = new Color(Convert.ToUInt32(arg.Split(':')[2], 16));
                        break;
                    case "GREEN":
                    case "ALLCLEAR":
                    case "ALL_CLEAR":
                        Info.Green_alert_colour = new Color(Convert.ToUInt32(arg.Split(':')[2], 16));
                        break;
                    default:
                        Echo("ERROR: change colour did not match any available colour, options are: RED,YELLOW,BLUE,GREEN or COMBAT,HAZARD,WARNING/CAUTION,ALLCLEAR");
                        return;
                }
                Echo("Updated colour of alert: " + arg.Split(':')[1] + " to: " + arg.Split(':')[2]);                
            }
            else if (arg.Contains("RESET_COLOUR:"))
            {
                switch(arg.Split(':')[1])
                {
                    case "RED":
                    case "COMBAT":
                        Info.Red_alert_colour = new Color(255, 0, 0, 0);
                        break;
                    case "YELLOW":
                    case "HAZARD":
                        Info.Yellow_alert_colour = new Color(255, 255, 0, 0);
                        break;
                    case "BLUE":
                    case "WARNING":
                    case "CAUTION":
                        Info.Blue_alert_colour = new Color(0, 0, 255, 0);
                        break;
                    case "GREEN":
                    case "ALLCLEAR":
                    case "ALL_CLEAR":
                        Info.Green_alert_colour = new Color(0, 255, 0, 0);
                        break;
                    default:
                        Echo("ERROR: reset colour did not match any available colour, options are: RED,YELLOW,BLUE,GREEN or COMBAT,HAZARD,WARNING/CAUTION,ALLCLEAR");
                        break;
                }
            }
            /*Misc commands with only one input option*/
            switch (arg)
            {
                case "HELP":
                    Help();
                    break;
                case "HELP_BASIC":
                    Help_basic();
                    break;
                case "HELP_TAGS":
                    Help_tags();
                    break;
                case "HELP_FUNCTIONS":
                    Help_functions();
                    break;
                case "HELP_LONG":
                    Help_basic();
                    Help_tags();
                    Help_functions();
                    break;
                case "INIT":
                    Update_Block_collection(updateSource);
                    break;
                case "RESET_PREFIX":
                    Info.prefix = "ALT";
                    break;
                case "RESET_ALL_COLOURS":
                case "RESET_COLOURS":
                    Info.Red_alert_colour = new Color (255, 0, 0, 0);                   
                    Info.Yellow_alert_colour = new Color(255, 255, 0, 0);
                    Info.Blue_alert_colour = new Color(0, 0, 255, 0);
                    Info.Green_alert_colour = new Color(0, 255, 0, 0);
                    Echo("Colours reset to defaults");
                    break;
                case "TOGGLE_DISARM":
                    if (Info.Disable_weps_on_all_clear)
                    { Info.Disable_weps_on_all_clear = false; }
                    else { Info.Disable_weps_on_all_clear = true; }
                    break;
                case "TOGGLE_AUTO_LOCKDOWN":
                    if (Info.Lock_brig_on_alert)
                    {
                        Info.Lock_brig_on_alert = false;
                        Echo("EXP Controler: Brig set to not lock on alert");
                    }
                    else
                    {
                        Info.Lock_brig_on_alert = true;
                        Echo("EXP Controler: Brig auto lock on red alert enabled");
                    }
                    break;
                case "SET_POWER":
                case "FETCH_POWER":
                case "FETCH_POWER_SETTINGS":
                case "POWER_SETTINGS":
                    Fetch_power_settings();
                    break;
                case "FULL_POWER":
                case "MAX_POWER":
                    Set_full_power();
                    break;
                case "RESET_POWER":
                case "APPLY_POWER":
                    Apply_power_settings();
                    break;
                case "SAVE":
                    Save();
                    break;
                case "STORAGE":
                case "SHOW_STORAGE":
                    Echo(Storage);
                    break;
                case "SHOW_POWER":
                case "SHOW_POWER SETTINGS":
                case "DISPLAY_POWER":
                case "DISPLAY_POWER_SETTINGS":
                    Echo("The current power settings are:\n");
                    foreach(KeyValuePair<string,bool> P in Info.Power_status)
                    { 
                        if(P.Value == true)
                        { Echo(P.Key + ", Online\n"); }
                        else { Echo(P.Key + ", Offline\n"); }
                    }
                    Echo("The current battery settings are:\n");
                    foreach(KeyValuePair<string,string> P in Info.Bat_status)
                    {
                        switch (P.Value)
                        {
                            case "AUTO":
                                Echo(P.Key + ", AUTO\n");
                                break;
                            case "RECHARGE":
                                Echo(P.Key + ", RECHARGE\n");
                                break;
                            case "DISCHARGE":
                                Echo(P.Key + ", DISCHARGE\n");
                                break;
                            default:
                                Echo("ERROR: no valid charge setting recorded for: " + P.Key + ", value was: " + P.Value);
                                break;
                        }
                    }
                    break;
                default:
                    Echo("ALERT CONTROLLER: ERROR: Input does not match any recognised command, input was: " + arg);
                    break;
            }           
            
        }
        public void Manage_alert(string argument)
        {
            switch (argument.ToUpper())
            {
                case "ALT_FIN":                                      //Final alert    "Self destruct"
                    if (Info.Current_alert == "F")
                    {
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        { L.Enabled = false; }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        { L.Enabled = false; }
                        sys_blocks.Alert_siren.Stop();
                        foreach (IMySoundBlock B in sys_blocks.Hanger_audio_warning)
                        { B.Stop(); }
                        Reset_pannels();
                        Info.Current_alert = "N";
                        Set_this_screen();
                        Apply_power_settings();
                    }
                    else
                    {
                        Check_other_alert("F");
                        bool Even = false;
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.Enabled = true;
                            if (Even)
                            { L.SetValue("Color", Info.Red_alert_colour); Even = false; }
                            else { L.SetValue("Color", Info.Yellow_alert_colour); Even = true; }

                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.Enabled = true;
                            if (Even)
                            { L.SetValue("Color", Info.Red_alert_colour); Even = false; }
                            else { L.SetValue("Color", Info.Yellow_alert_colour); Even = true; }

                        }

                        foreach (IMySoundBlock B in sys_blocks.Hanger_audio_warning)
                        { B.Play(); }
                        sys_blocks.Alert_siren.Play();
                        set_pannels("FINAL");
                        Info.Current_alert = "F";
                        Set_this_screen();
                        Set_full_power();
                    }
                    break;

                case "ALT_BLACK":                                    //Black alert    "Abandon ship"
                    if (Info.Current_alert == "A")
                    {
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        { L.Enabled = false; }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        { L.Enabled = false; }
                        sys_blocks.Alert_siren.Stop();
                        foreach (IMySoundBlock B in sys_blocks.Hanger_audio_warning)
                        { B.Stop(); }
                        Reset_pannels();
                        Info.Current_alert = "N";
                        Set_this_screen();
                        Apply_power_settings();

                    }
                    else
                    {
                        Check_other_alert("A");
                        bool Even = false;
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.Enabled = true;
                            if (Even)
                            { L.SetValue("Color", Info.Red_alert_colour); Even = false; }
                            else { L.SetValue("Color", Info.Blue_alert_colour); Even = true; }

                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.Enabled = true;
                            if (Even)
                            { L.SetValue("Color", Info.Red_alert_colour); Even = false; }
                            else { L.SetValue("Color", Info.Blue_alert_colour); Even = true; }

                        }
                        foreach (IMySoundBlock B in sys_blocks.Hanger_audio_warning)
                        { B.Play(); }
                        sys_blocks.Alert_siren.Play();
                        set_pannels("BLACK");
                        Info.Current_alert = "A";
                        Set_this_screen();
                        Set_full_power();

                    }
                    break;

                case "ALT_RED":                                      //Red  alert     "Combat alert"
                    if (Info.Current_alert == "R")
                    {
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        { L.Enabled = false; }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        { L.Enabled = false; }
                        foreach (IMyLargeGatlingTurret T in sys_blocks.Gun_turrets)
                        { T.Enabled = false; }
                        foreach (IMyLargeMissileTurret T in sys_blocks.Missile_turrets)
                        { T.Enabled = false; }
                        sys_blocks.Alert_siren.Stop();
                        try
                        { foreach (IMyAdvancedDoor D in sys_blocks.Escape_doors) { D.CloseDoor(); } }
                        catch { Echo("Failed to close escape door(s)"); }
                        foreach (IMyDoor D in sys_blocks.Restricted_doors) { D.Enabled = true; D.OpenDoor(); }
                        Info.Stored_arg = "ALT_EMG_DOOR_LOCK";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                        Echo("Red alert ended");
                        Info.Current_alert = "N";
                        Reset_pannels();
                        Set_this_screen();
                        Manage_alert("ALT_GREEN");
                    }
                    else
                    {
                        Check_other_alert("R");
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.SetValue("Color", Info.Red_alert_colour);
                            L.Enabled = true;
                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.SetValue("Color", Info.Red_alert_colour);
                            L.Enabled = true;
                        }
                        foreach (IMyLargeGatlingTurret T in sys_blocks.Gun_turrets)
                        { T.Enabled = true; }
                        foreach (IMyLargeMissileTurret T in sys_blocks.Missile_turrets)
                        { T.Enabled = true; }
                        foreach (IMyUserControllableGun G in sys_blocks.Weapons)
                        { G.Enabled = true; }
                        foreach(IMyDoor D in sys_blocks.Escape_doors)
                        { D.Enabled = true; }
                        foreach(IMyDoor D in sys_blocks.Restricted_doors)
                        { D.CloseDoor(); }
                        Info.Stored_arg = "RA_LOCK_RES_DOORS";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                        sys_blocks.Alert_siren.SelectedSound = "Alert 1";
                        sys_blocks.Alert_siren.Play();
                        Info.Current_alert = "R";
                        Set_this_screen();
                        Set_full_power();
                        set_pannels("RED");
                        if (Info.Lock_brig_on_alert && sys_blocks.Brig_bulkheads[0].Status.ToString().ToUpper() == "OPEN")
                        {
                            Brig_lockdown();
                        }
                        Echo("Red alert set");
                    }
                    break;

                case "ALT_YELLOW":                                 //Yellow alert    "Hazard alert"
                    if (Info.Current_alert == "Y")
                    {
                        if (Info.Pending_RA == true)
                        { Run_pending_RA(); }
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        { L.Enabled = false; }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        { L.Enabled = false; }
                        sys_blocks.Alert_siren.Stop();
                        Info.Current_alert = "N";
                        Set_this_screen();
                        Reset_pannels();
                        Apply_power_settings();

                        Echo("Hazard alert ended");
                    }
                    else
                    {
                        Check_other_alert("Y");
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.SetValue("Color", Info.Yellow_alert_colour);
                            L.Enabled = true;
                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.SetValue("Color", Info.Yellow_alert_colour);
                            L.Enabled = true;
                        }
                        sys_blocks.Alert_siren.Play();
                        Info.Current_alert = "Y";
                        Set_this_screen();
                        Set_full_power();
                        set_pannels("YELLOW");
                        Echo("Hazard alert set");
                    }
                    break;

                case "ALT_BLUE":                                         //Blue alert    "Caution"
                    if (Info.Current_alert == "B")
                    {
                        if (Info.Pending_RA == true)
                        { Run_pending_RA(); }
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.Enabled = false;
                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.Enabled = false;
                        }
                        Info.Current_alert = "N";
                        Set_this_screen();
                        Echo("Caution ended");
                    }
                    else
                    {
                        Check_other_alert("B");
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.SetValue("Color", Info.Blue_alert_colour);
                            L.Enabled = true;
                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.SetValue("Color", Info.Blue_alert_colour);
                            L.Enabled = true;
                        }
                        Info.Current_alert = "B";
                        Set_this_screen();
                        Echo("Caution set");
                    }
                    break;

                case "ALT_GREEN":                                      //Green alert   "All clear"
                    if (Info.Current_alert == "G")
                    {
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        { L.Enabled = false; }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        { L.Enabled = false; }
                        try { foreach (IMyDoor D in sys_blocks.Escape_doors) { D.Enabled = false; } } catch { } 
                          //incase this was called by Red & stole its close timer. here to let doors close 1st
                        sys_blocks.Alert_siren.Stop();
                        Reset_pannels();
                        Info.Current_alert = "N";
                        Set_this_screen();
                        End_timer();
                        Echo("All clear completed");
                    }
                    else
                    {
                        Check_other_alert("G");
                        foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                        {
                            L.SetValue("Color", Info.Green_alert_colour);
                            L.Enabled = true;
                        }
                        foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                        {
                            L.SetValue("Color", Info.Green_alert_colour);
                            L.Enabled = true;
                        }
                        if (Info.Disable_weps_on_all_clear)
                        {
                            foreach (IMyUserControllableGun G in sys_blocks.Weapons)
                            { G.Enabled = false; }
                        }
                        sys_blocks.Alert_siren.SelectedSound = "Alert 2";
                        sys_blocks.Alert_siren.Play();
                        set_pannels("GREEN");
                        Info.Current_alert = "G";
                        Set_this_screen();
                        try { Apply_power_settings(); } catch { Echo("Warning: failed to apply power settings, please check manually"); }
                        Info.Stored_arg = "ALT_GREEN_CD";
                        Runtime.UpdateFrequency = UpdateFrequency.Update100;
                        Echo("Activated all clear");
                    }
                    break;

                case "ALT_EMG_DOOR_LOCK":
                    foreach (IMyDoor D in sys_blocks.Escape_doors) { D.Enabled = false; }
                    End_timer();
                    break;

                case "ALT_CLEAR_RA":
                    //lights, guns,sirens,doors off
                    foreach (IMyReflectorLight L in sys_blocks.Alt_rot_lights)
                    { L.Enabled = false; }
                    foreach (IMyInteriorLight L in sys_blocks.Alt_lights)
                    { L.Enabled = false; }
                    foreach (IMyLargeGatlingTurret T in sys_blocks.Gun_turrets)
                    { T.Enabled = false; }
                    foreach (IMyLargeMissileTurret T in sys_blocks.Missile_turrets)
                    { T.Enabled = false; }
                    sys_blocks.Alert_siren.Stop();
                    try { foreach(IMyDoor D in sys_blocks.Escape_doors) { D.CloseDoor(); } } catch { Echo("Failed to close escape door(s)"); }
                    Info.Stored_arg = "ALT_EMG_DOOR_LOCK";
                    Runtime.UpdateFrequency = UpdateFrequency.Update100;
                    Info.Current_alert = "N";
                    Set_this_screen();
                    Reset_pannels();
                    try { Apply_power_settings(); } catch { Echo("Warning: failed to apply power settings, please check manually"); }
                    break;

                default:
                    Echo("Error: alert argument does not match to any configured alert state");
                    break;
            }
        }
        public void SD(string Code, string Command)
        {
            if (Code.ToUpper() == Info.SD_info["Code"].ToUpper())
            {
                if (Command.ToUpper() == "RESET" || Command.ToUpper() == "SAFE" || Command.ToUpper() == "ABORT")
                {
                    foreach (IMyWarhead W in sys_blocks.Destruct_blocks)
                    { W.StopCountdown(); }
                    Info.SD_info["Status"] = "UNARMED";
                    Echo("EXP Controler: INFO: Self-destruct aborted, system set to unarmed.");
                }
                else if (Command.ToUpper() == "Progress")
                {
                    if (Info.SD_info["Status"] == "UNARMED")
                    {
                        Info.SD_info["Status"] = "ARMED";
                        Echo("EXP Controler: WARNING: SELF-DESTRUCT ARMED");
                    }
                    else if (Info.SD_info["Status"] == "ARMED")
                    {
                        foreach (IMyWarhead W in sys_blocks.Destruct_blocks)
                        { W.StartCountdown(); }
                        Info.SD_info["Status"] = "FIRING";
                        Manage_alert("ALT_FIN");
                        Echo("EXP Controler: CRITICAL ALERT: SELF DESTRUCT ");
                    }
                    else if (Info.SD_info["Status"] == "LOCKED")
                    {
                        Info.SD_info["Status"] = "UNARMED";
                        Echo("EXP Controler: ALERT: Self-destruct system unlocked");
                    }
                    else if (Info.SD_info["Status"] == "FIRING")
                    {
                        foreach (IMyWarhead W in sys_blocks.Destruct_blocks)
                        { W.StopCountdown(); }
                        Info.SD_info["Status"] = "UNARMED";
                        Manage_alert("ALT_FIN");
                        Echo("EXP Controler: INFO: Self-destruct aborted, system set to unarmed.");
                    }
                    else
                    {
                        Echo("EXP Controler: WARNING: Self-destruct system status is unknown, reseting to Unarmed");
                        Info.SD_info["Status"] = "UNARMED";
                    }
                }
                else
                {
                    foreach (IMyWarhead W in sys_blocks.Destruct_blocks)
                    { W.StopCountdown(); }
                    Info.SD_info["Status"] = "UNARMED";
                    Echo("EXP Controler: WARNING: Correct SD password was input, but and unrecognised command was issued. Safing system");
                }
            }
            else
            {
                Echo("EXP Controler: CRITICAL ALERT: UNATHORISED ATTEMPT TO USE THE SELF-DESTRUCT, RECOMEND IMMEDIATE SECURITY MEASURES");
                Info.SD_info["Status"] = "LOCKED";
            }
        }

        /* Pannel handeling methods */
        public class Pannel_settings
        {
            public ContentType ContType = ContentType.NONE;
            public String Script = "";
            public string Text = "";
            public String Font = "";
            public float FontSize = 0;
            public TextAlignment Alignment = TextAlignment.CENTER;
            public float TxtPadding = 0;
            public List<string> Imgs = new List<string>();
            public Color BackgroundColour = new Color();
            public Color FontColour = new Color();
        }
        public void set_pannels(String arg)
        {
            //this method sets up pannels based on the alert setting- use Reset_pannels() to return them to default, set default with Set_panel_defaults()
            if (sys_blocks.Alert_pannels.Count == sys_blocks.Alt_panel_defaults.Count)
            {
                if (arg.ToUpper() == "FINAL")
                {
                    foreach (IMyTextPanel T in sys_blocks.Alert_pannels)
                    {
                        T.ContentType = ContentType.TEXT_AND_IMAGE;
                        T.WriteText("");
                        T.BackgroundColor = Color.Blue;
                        T.FontColor = Color.Red;
                        T.FontSize = 2;
                        T.TextPadding = 2;
                        T.Alignment = TextAlignment.CENTER;
                        T.ClearImagesFromSelection();
                        T.WriteText("!!!!!!!!!!!!!!!!!!!!!\n\n!! SELF DESTRUCT !!\nEXIT IMMEDIATELY\n\n!!!!!!!!!!!!!!");
                        if (T.CustomName.Contains("[ALPU]"))
                        {
                            T.WriteText("!!!!!!!!!!!!!!!!!!!!!\n^^^^^^^^^^^^^^\n\n!! SELF DESTRUCT !! \nEXIT IMMEDIATELY\n\n^^^^^^^^^^^^^^\n!!!!!!!!!!!!!!!!!!!!");
                        }
                        else if (T.CustomName.Contains("[ALPR]"))
                        {
                            T.WriteText("!!!!!!!!!!!!!!!!!!!!!\n>>>>>>>>>>>>>>\n\n!! SELF DESTRUCT !!\nEXIT IMMEDIATELY\n\n>>>>>>>>>>>>>>\n!!!!!!!!!!!!!!!!!!!!");
                        }
                        else if (T.CustomName.Contains("[ALPD]"))
                        {
                            T.WriteText("!!!!!!!!!!!!!!!!!!!!!\nVVVVVVVVVVVVVV\n\n!! SELF DESTRUCT !!\nEXIT IMMEDIATELY\n\nVVVVVVVVVVVVVV\n!!!!!!!!!!!!!!!!!!!!");
                        }
                        else if (T.CustomName.Contains("[ALPL]"))
                        {
                            T.WriteText("!!!!!!!!!!!!!!!!!!!!!\n<<<<<<<<<<<<<<\n\n!! SELF DESTRUCT !!\nEXIT IMMEDIATELY\n\n<<<<<<<<<<<<<<\n!!!!!!!!!!!!!!!!!!!!");
                        }
                    }
                }
                else if (arg.ToUpper() == "BLACK")
                {
                    foreach (IMyTextPanel T in sys_blocks.Alert_pannels)
                    {
                        T.ContentType = ContentType.TEXT_AND_IMAGE;
                        T.WriteText("");
                        T.BackgroundColor = Color.Blue;
                        T.FontColor = Color.Yellow;
                        T.FontSize = 2;
                        T.TextPadding = 2;
                        T.Alignment = TextAlignment.CENTER;
                        T.ClearImagesFromSelection();
                        T.WriteText("!!!!!!!!!!!!!!\n\nABANDON SHIP\n\nALL HANDS TO\nESCAPE PODS\n!!!!!!!!!!!!!!");

                    }
                }
                else if (arg.ToUpper() == "RED")
                {
                    foreach (IMyTextPanel T in sys_blocks.Alert_pannels)
                    {
                        //setting the rotation based on ther orientation tag
                        T.ContentType = ContentType.TEXT_AND_IMAGE;
                        T.WriteText("");
                        T.BackgroundColor = Color.Red;
                        T.FontColor = Color.Green;
                        T.FontSize = 2;
                        T.TextPadding = 2;
                        T.Alignment = TextAlignment.CENTER;
                        T.ClearImagesFromSelection();
                        if (T.CustomName.Contains("[ALTPU]"))
                        {
                            T.WriteText("^^^^^^^^^^^^^^\n\nRED ALERT\n!! NEAREST !!\n!! ESCAPE  !!\n\n^^^^^^^^^^^^^^");
                        }
                        else if (T.CustomName.Contains("[ALTPR]"))
                        {
                            T.WriteText(">>>>>>>>>>>>>>\n\nRED ALERT\n!! NEAREST !!\n!! ESCAPE  !!\n\n>>>>>>>>>>>>>>");
                        }
                        else if (T.CustomName.Contains("[ALTPD]"))
                        {
                            T.WriteText("VVVVVVVVVVVVVV\n\nRED ALERT\n!! NEAREST !!\n!! ESCAPE  !!\n\nVVVVVVVVVVVVVV");
                        }
                        else if (T.CustomName.Contains("[ALTPL]"))
                        {
                            T.WriteText("<<<<<<<<<<<<<<\n\nRED ALERT\n!! NEAREST !!\n!! ESCAPE  !!\n\n<<<<<<<<<<<<<<");
                        }
                        else
                        {
                            T.WriteText("\n\n\nRED ALERT\n!! BE AWARE !!\n!! DANGER  !!\n\n\n");
                        }
                    }
                    //\n!! GENERAL QUATERS !!\n\n!! ALL HANDS TO ACTION STATIONS !!\n!! SET CONDITION 1 throughout the ship !!
                    //\n!! HAZARD ALERT  !!\n\nSET CONDITION 2 throughout the ship\nBrace, prep for depress\nStandby for IAM
                    //!!!!!!!!!!!!!!\n\nABANDON SHIP\n\nCOMMENCE EVACUATION PROCEDURE\n\n!!!!!!!!!!!!!!
                }
                else if (arg.ToUpper() == "YELLOW")
                {
                    foreach (IMyTextPanel T in sys_blocks.Alert_pannels)
                    {
                        T.ContentType = ContentType.TEXT_AND_IMAGE;
                        T.BackgroundColor = Color.GreenYellow;
                        T.FontColor = Color.Blue;
                        T.FontSize = 2;
                        T.TextPadding = 2;
                        T.Alignment = TextAlignment.CENTER;
                        T.ClearImagesFromSelection();
                        T.WriteText("\n HAZARD ALERT \n\n Continue normaly but: \n  be prepared to brace \n Check escape route \n\n");
                    }
                }
                else if (arg.ToUpper() == "GREEN")
                {
                    foreach (IMyTextPanel T in sys_blocks.Alert_pannels)
                    {
                        T.ContentType = ContentType.TEXT_AND_IMAGE;
                        T.BackgroundColor = Color.Green;
                        T.FontColor = Color.White;
                        T.FontSize = 3;
                        T.TextPadding = 2;
                        T.Alignment = TextAlignment.CENTER;
                        T.ClearImagesFromSelection();
                        T.WriteText("ALL CLEAR\n\n ALERT OVER \n\n ALL CLEAR");
                    }
                }
                Echo("ALT: Set pannels");
            }
            else
            {
                Echo("Set_pannels: ERROR: alert pannel and pannel default lists are different sizes, operation skiped");
            }
        }
        public void Reset_pannels()
        {
            //Reset each pannel to their default (no alert) set up, changes pannels using [ALP] tag
            if (sys_blocks.Alert_pannels.Count == sys_blocks.Alt_panel_defaults.Count)
            {
                for (int i = 0; i < sys_blocks.Alert_pannels.Count(); i++)
                {

                    sys_blocks.Alert_pannels[i].ContentType = sys_blocks.Alt_panel_defaults[i].ContType;
                    try { sys_blocks.Alert_pannels[i].Script = sys_blocks.Alt_panel_defaults[i].Script; } catch { }
                    try
                    {
                        sys_blocks.Alert_pannels[i].WriteText(sys_blocks.Alt_panel_defaults[i].Text);
                        sys_blocks.Alert_pannels[i].Font = sys_blocks.Alt_panel_defaults[i].Font;
                        sys_blocks.Alert_pannels[i].FontSize = sys_blocks.Alt_panel_defaults[i].FontSize;
                        sys_blocks.Alert_pannels[i].Alignment = sys_blocks.Alt_panel_defaults[i].Alignment;
                        sys_blocks.Alert_pannels[i].TextPadding = sys_blocks.Alt_panel_defaults[i].TxtPadding;
                        sys_blocks.Alert_pannels[i].ClearImagesFromSelection();
                        List<string> imgs = new List<string>();

                        foreach (string s in sys_blocks.Alt_panel_defaults[i].Imgs)
                        {
                            sys_blocks.Alert_pannels[i].AddImageToSelection(s);
                        }
                    }
                    catch { }
                    sys_blocks.Alert_pannels[i].FontColor = sys_blocks.Alt_panel_defaults[i].FontColour;
                    sys_blocks.Alert_pannels[i].BackgroundColor = sys_blocks.Alt_panel_defaults[i].BackgroundColour;
                }
            }
            else
            {
                Echo("Reset_pannels: ERROR: alert pannel and pannel default lists are different sizes, operation skiped");
            }
        }
        public void Set_pannel_defs()
        {
            if (Info.Current_alert == "N")
            {
                List<Pannel_settings> backup = new List<Pannel_settings>(sys_blocks.Alt_panel_defaults);
                sys_blocks.Alt_panel_defaults.Clear();
                try
                {
                    for (int i = 0; i < sys_blocks.Alert_pannels.Count(); i++)
                    {
                        Pannel_settings ps = new Pannel_settings();
                        ps.ContType = sys_blocks.Alert_pannels[i].ContentType;
                        try { ps.Script = sys_blocks.Alert_pannels[i].Script; } catch { }
                        try
                        {
                            ps.Text = sys_blocks.Alert_pannels[i].GetText();
                            ps.Font = sys_blocks.Alert_pannels[i].Font;
                            ps.FontSize = sys_blocks.Alert_pannels[i].FontSize;
                            ps.Alignment = sys_blocks.Alert_pannels[i].Alignment;
                            ps.TxtPadding = sys_blocks.Alert_pannels[i].TextPadding;
                            List<string> imgs = new List<string>();
                            sys_blocks.Alert_pannels[i].GetSelectedImages(imgs);
                            foreach (string s in imgs)
                            {
                                ps.Imgs.Add(s);
                            }
                        }
                        catch { }
                        ps.FontColour = sys_blocks.Alert_pannels[i].FontColor;
                        ps.BackgroundColour = sys_blocks.Alert_pannels[i].BackgroundColor;

                        sys_blocks.Alt_panel_defaults.Add(ps);
                    }
                    backup.Clear();
                    Echo("Set_pannel_defaults: Successfully set: " + sys_blocks.Alt_panel_defaults.Count + " pannels");
                }
                catch
                {
                    sys_blocks.Alt_panel_defaults.Clear();
                    for (int i = 0; i < sys_blocks.Alert_pannels.Count(); i++)
                    {
                        sys_blocks.Alt_panel_defaults.Add(backup[i]);
                        backup.Clear();
                    }
                    Echo("Set_pannel_defaults: ERROR: Failed to set new pannel defaults, current versions restored");
                }
            }
            else
            {
                Echo("Set_pannel_defaults: ERROR: Cannot set pannel defaults while an alert is running");
            }
        }
        /* End of pannel handeling methods */

        /* Misc methods */
        public void End_timer()
        {
            Info.Stored_arg = "";
            Info.Timer_Counter = 0;
            Runtime.UpdateFrequency = UpdateFrequency.None;
        }
        public void Run_pending_RA()
        {
            if (Info.Pending_RA == true)
            {
                Manage_alert("ALT_CLEAR_RA");
            }
            Info.Pending_RA = false;
        }
        public void Check_other_alert(string caller)
        {
            switch (Info.Current_alert) //if another alert is currently running call it again to cancel it before continuing
            {
                case "F":
                    if (caller != "F")
                    { Manage_alert("ALT_FIN"); }
                    break;
                case "A":
                    if (caller != "A")
                    { Manage_alert("ALT_BLACK"); }
                    break;
                case "R":
                    Echo("Check_alert: Red alert detected, RA will run again breifly after alert to reset properly");
                    Info.Pending_RA = true;
                    break;
                case "Y":
                    if (caller != "Y")
                    { Manage_alert("ALT_YELLOW"); }
                    break;
                case "B":
                    if (caller != "B")
                    { Manage_alert("ALT_BLUE"); }
                    break;
                case "G":
                    if (caller != "G")
                    { Manage_alert("ALT_GREEN"); }
                    break;
                case "N":
                    Echo("Check_alert: No alert");
                    break;
                default:
                    Echo("Check_alert: ERROR: No valid alert setting");
                    break;
            }
        }
        public void Set_SD_PW(string Current_pw, string New_pw)
        {
            if (Current_pw.ToUpper() == Info.SD_info["Code"].ToUpper())
            {
                Info.SD_info["Code"] = New_pw;
                Echo("EXP Controler: SD password successfully updated");
                if (Info.SD_info["Status"] == "LOCKED")
                { Info.SD_info["Status"] = "UNARMED"; Echo("EXP Controler: SD unlocked due to reset, current status: " + Info.SD_info["Status"]); }
            }
            else
            {
                Echo("EXP Controler: WARNING: Failed SD password update, SD locked untill this issue is resolved\nSD password update requires the current password," +
                    "make sure your command resembles: SD_update:oldPW,NewPW");
                Info.SD_info["Status"] = "LOCKED";
            }
        }
        public void Brig_lockdown()
        {
            // controls the brig lockdown based on the status of the lockdown bulkhead
            if (sys_blocks.Brig_bulkheads[0].Status.ToString().ToUpper() == "OPEN" && Brig_LD_BH_equal())
            {
                foreach (IMyAirtightHangarDoor D in sys_blocks.Brig_bulkheads) { D.CloseDoor(); }
                try { foreach (IMyDoor D in sys_blocks.Brig_doors) { D.CloseDoor(); } } catch { }
                //start red alert, get a new cycle to lock the door
                Info.Stored_arg = "LOCK_BRIG_DOOR";
                Runtime.UpdateFrequency = UpdateFrequency.Update100;
                if (Info.Current_alert != "R")
                {
                    Manage_alert("ALT_RED");
                    Echo("BRIG LOCKEDOWN: LOCKDOWN INITIATED, LOCKING BRIG DOOR AND RAISING BULKHEAD, starting alert");
                }
                Echo("BRIG LOCKEDOWN: LOCKDOWN INITIATED, LOCKING BRIG DOOR AND RAISING BULKHEAD");
            }
            else
            {
                foreach (IMyAirtightHangarDoor D in sys_blocks.Brig_bulkheads) { D.OpenDoor(); }
                try { foreach (IMyDoor D in sys_blocks.Brig_doors) { D.Enabled = true; } } catch { }
                Echo("BRIG LOCKDOWN: BRIG LOCKDOWN DISABLED, brig doors may now be opened");
            }
        }
        public bool Brig_LD_BH_equal()
        {
            bool Equal = true;
            foreach (IMyAirtightHangarDoor D in sys_blocks.Brig_bulkheads)
            {
                if (D.Status.ToString().ToUpper() != sys_blocks.Brig_bulkheads[0].Status.ToString().ToUpper())
                {
                    Equal = false; 
                    break;
                }
            }
            return Equal;
        }
        public void Set_caller(string name)
        {
            try
            {
                sys_blocks.Caller = GridTerminalSystem.GetBlockWithName(name) as IMyProgrammableBlock;
                Info.Has_caller = true;
                Echo("ALT: INFO: Caller set as: " + name);
            }
            catch
            {
                Info.Has_caller = false;
                Echo("ALT: ERROR: Failed to get caller, please check ID");
            }
        }
        public void Send_status()
        {
            sys_blocks.Caller.TryRun("SET_CURRENT_ALERT:"+Info.Current_alert);
        }
        public void Set_this_screen()
        {
            switch (Info.Current_alert)
            {
                case "F":
                    sys_blocks.This_screen.FontColor = Color.Red;
                    sys_blocks.This_screen.BackgroundColor = Color.GreenYellow;
                    sys_blocks.This_screen.WriteText("Current alert:\nDestroy");
                    break;
                case "A":
                    sys_blocks.This_screen.FontColor = Color.Red;
                    sys_blocks.This_screen.BackgroundColor = Color.Blue;
                    sys_blocks.This_screen.WriteText("Current alert:\nAbandon");
                    break;
                case "R":
                    sys_blocks.This_screen.FontColor = Color.Yellow;
                    sys_blocks.This_screen.BackgroundColor = Color.Red;
                    sys_blocks.This_screen.WriteText("Current alert:\nCombat alert");
                    break;
                case "Y":
                    sys_blocks.This_screen.FontColor = Color.Black;
                    sys_blocks.This_screen.BackgroundColor = Color.GreenYellow;
                    sys_blocks.This_screen.WriteText("Current alert:\nHazard");
                    break;
                case "B":
                    sys_blocks.This_screen.FontColor = Color.White;
                    sys_blocks.This_screen.BackgroundColor = Color.Blue;
                    sys_blocks.This_screen.WriteText("Current alert:\nCaution");
                    break;
                case "G":
                    sys_blocks.This_screen.FontColor = Color.Black;
                    sys_blocks.This_screen.BackgroundColor = Color.Green;
                    sys_blocks.This_screen.WriteText("Current alert:\nAll clear");
                    break;

                default:
                    sys_blocks.This_screen.FontColor = Color.White;
                    sys_blocks.This_screen.BackgroundColor = Color.Black;
                    sys_blocks.This_screen.WriteText("Current alert:\nNone");
                    break;
            }            
        }
        public void Set_full_power()
        {
            Fetch_power_settings();
            List<IMyPowerProducer> Power = new List<IMyPowerProducer>();
            GridTerminalSystem.GetBlocksOfType(Power);
            foreach (IMyPowerProducer p in Power)
            { p.Enabled = true; }
            foreach (KeyValuePair<string,string> B in Info.Bat_status)
            {
                IMyBatteryBlock bat = GridTerminalSystem.GetBlockWithName(B.Key) as IMyBatteryBlock;
                bat.ChargeMode = ChargeMode.Auto;
            }

            Echo("Full power set");
        }
        public void Fetch_power_settings()
        {
            Info.Power_status.Clear();
            Info.Bat_status.Clear();
            List<IMyPowerProducer> Power = new List<IMyPowerProducer>();
            GridTerminalSystem.GetBlocksOfType(Power);
            foreach (IMyPowerProducer P in Power)
            {
                try
                {
                    if (P.Enabled == true)
                    {
                        Info.Power_status.Add(P.CustomName, true);
                    }
                    else
                    {
                        Info.Power_status.Add(P.CustomName, false);
                    }
                }
                catch { Echo("ERROR: failed to add power source: " + P.CustomName +" to Power_Status, please check it's name isn't repeated"); }
            }
            List<IMyBatteryBlock> bats = new List<IMyBatteryBlock>();
            GridTerminalSystem.GetBlocksOfType(bats);
            foreach (IMyBatteryBlock B in bats)
            {
                if (B.ChargeMode == ChargeMode.Auto)
                {
                    Info.Bat_status.Add(B.CustomName,"AUTO");
                }
                else if (B.ChargeMode == ChargeMode.Recharge)
                {
                    Info.Bat_status.Add(B.CustomName, "RECHARGE");
                }
                else
                {
                    Info.Bat_status.Add(B.CustomName, "DISCHARGE");
                }
            }
            Echo("Power settings updated, logged a total of: " + Power.Count + " blocks");
        }
        public void Apply_power_settings()
        {
            int count_on = 0;
            int count_off = 1;
            foreach (KeyValuePair<string,bool> E in Info.Power_status)
            {
                IMyPowerProducer P = GridTerminalSystem.GetBlockWithName(E.Key) as IMyPowerProducer;
                if (E.Value == true)
                { 
                    P.Enabled = true;
                    count_on++;
                }
                else
                { 
                    P.Enabled = false;
                    count_off++;
                }
            }
            foreach (KeyValuePair<string,string> B in Info.Bat_status)
            {
                IMyBatteryBlock Bat = GridTerminalSystem.GetBlockWithName(B.Key) as IMyBatteryBlock;
                switch(B.Value)
                {
                    case "AUTO":
                        Bat.ChargeMode = ChargeMode.Auto;
                        break;
                    case "RECHARGE":
                        Bat.ChargeMode = ChargeMode.Recharge;
                        break;
                    case "DISCHARGE":
                        Bat.ChargeMode = ChargeMode.Discharge;
                        break;
                    default:
                        Echo("ERROR: no valid charge setting recorded for: " + B.Key + ", value was: " + B.Value);
                        break;
                }
            }
            Echo("Power settings applied to a total of: " + Info.Power_status.Count + " blocks, active blocks: " + count_on + ", inactive blocks: " + count_off);
        }

        public void Help()
        {
            Echo("There are several help options available, please enter them as commands:\n" +
                "Help_basic: Covers the basic alert states\n" +
                "Help_tags: Lists and describes the block tags used by the system\n" +
                "Help_functions: Lists and describes the available secondary functions\n" +
                "Help_long: Displays all of the above help files in order");
        }
        public void Help_basic()
        {
            Echo("This function manages the ship's alert status, their are 6 settings:\n" +
                     "Fin/Self_destruct: Mix of Red and yellow rotating lights + siren, evac screens DESTROYS SHIP AFTER 10S(if equiped)\n" +
                     "Black-Abandon ship: Mix of Red and blue rotating lights + siren, evac screens\n" +
                     "Red/Combat alert: Red rotating lights + siren, evac screens, apu, active weps\n" +
                     "Yellow-Hazard:Yellow rotating lights, warning screesn and alarm, for serious non combat situations\n" +
                     "Blue-Caution: Blue rotating lights for minor/routine serious situations\n" +
                     "Green-All clear: green rotating lights and all clear screens, ends after 10s\n\n" +
                     "Each alert be toggled by calling alt-colour, eg: ALT-RED\n" +
                     "The code for abandon ship is: ALT-BLACK\n" +
                     "The code for slef destruct is: ALT-FIN \n\n" +
                     "This system uses tags to identify the blocks it can use, use the command help_tags (or read on if using help_long) for more info\n\n");
        }
        public void Help_tags()
        {
            string tag = "[" + Info.prefix;
            Echo("TAGS the following tags are used in this script:\n" +
                    "NOTE: These blocks are all technicaly optional, but without lights and a siren the system is kind of pointless\n" +
                    "Siren: " + tag + "S] Use only one\n" +
                    "Lights: " + tag + "L] lights up in the alert colour, typicaly rotating\n" +
                    "Pannels: " + tag + "P] Used to display the alert info/warnings, and point out escape routes\n" +
                    "Escape doors: " + tag + "ED] For normaly locked doors that should open at high alerts to facilitate escape\n" +
                    "  Note: pannels and have a direction added after the P in their tag to point at escape routes, the options are:\n" +
                    "    Upper or further away(U), Down/behind(D), Left(L), Right(R)\n" +
                    "Restricted doors: " + tag + "RD] For (non-brig) doors that should lock on high alert\n" +
                    "Brig doors: " + tag + "BD] To allow the entrance to any brig to respond to an alert\n" +
                    "Brig bulkheads:" + tag + "BLD] Any airtight hanger doors being used as extra brig lockdown\n" +
                    "Weapons: " + tag + "W] A weapon that  the system can toggle on/off\n" +
                    "  Note: The system also automaticaly collects all reactors on a ship to turn them on as needed\n" +
                    "  Note: The prefix for the tag can be changed, see help_functions for more info\n\n");
        }
        public void Help_functions()
        {
            Echo("Extra functions:\n" +
                    "Set_caller: if this block is called by another program, use this to be able to send data back, enter the caller's name after the :\n" +
                    "SET_PREFIX:x Sets the system tag prefix to x, eg: SET_PREFIX:ALERT changes the tag for siren blocks from[ALTS] to [ALERTS]\n" +
                    "RESET_PREFIX Sets the tag prefix back to it's defualt value of ALT\n" +
                    "CHANGE_COLOUR:ALERT:COLOUR Sets the colour of the specificed alert to the input colour(must be hex) EG:CHANGE_COLOUR:COMBAT:FFFFFF\n" +
                    "RESET_COLOUR:ALERT Resets the chosen alert to it's defualt colour\n" +
                    "  Note the options for these two functions are: RED,YELLOW,BLUE,GREEN or COMBAT,HAZARD,WARNING/CAUTION,ALLCLEAR\n" +
                    "HELP Provides access to the help menu\n" +
                    "Init Initalise(or re-initalise) the system and update it's blocks\n" +
                    "TOGGLE DISARM Toggle whether or not to disable weapons when combat alert ends\n" +
                    "FETCH_POWER/POWER_SETTINGS: Save the current power block states\n" +
                    "SHOW_POWER/DISPLAY_POWER: Displays the status of the ship's power blocks\n" +
                    "FULL_POWER/MAX_POWER: Runs FETCH_POWER, then actives everything\n" +
                    "RESET_POWER/APPLY_POWER: Applys the saved power settings\n\n");
        }       
        /* End of misc methods*/
