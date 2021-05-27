using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Net.NetworkInformation;

namespace Device_profiler
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        private void Get_info_BTN_Click(object sender, EventArgs e)
        {
            //MOSTLY THANKS TO: https://ourcodeworld.com/articles/read/294/how-to-retrieve-basic-and-advanced-hardware-and-software-information-gpu-hard-drive-processor-os-printers-in-winforms-with-c-sharp
            /*OS INFO*/
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                
                Caption_label.Text = obj["Caption"].ToString();               
                WIN_dir_label.Text = obj["WindowsDirectory"].ToString();               
                Prod_type_label.Text = OS_Switches.prod_type(Convert.ToUInt32(obj["ProductType"]));            
                SN_label.Text = obj["SerialNumber"].ToString();              
                Sys_dir_label.Text = obj["SystemDirectory"].ToString();               
                Country_label.Text = obj["CountryCode"].ToString();              
                Timezone_label.Text = obj["CurrentTimeZone"].ToString();           
                Encryption_label.Text = obj["EncryptionLevel"].ToString();               
                OS_type_label.Text = OS_Switches.OS_type(Convert.ToUInt16(obj["OSType"]));           
                Version_label.Text = obj["Version"].ToString();
            }
            /*END OF OS INFO*/

            /*CPU INFO*/
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {              
                CPU_name_label.Text = obj["Name"].ToString();            
                CPU_ID_label.Text = obj["DeviceID"].ToString();            
                CPU_manufacturer_label.Text = obj["Manufacturer"].ToString();              
                CPU_clock_label.Text = obj["CurrentClockSpeed"].ToString();
                Console.WriteLine("Caption  -  " + obj["Caption"]);
                CPU_caption_label.Text = obj["Caption"].ToString();               
                CPU_core_label.Text = obj["NumberOfCores"].ToString();               
                CPU_enabled_cores_label.Text = obj["NumberOfEnabledCore"].ToString();         
                CPU_logi_cores_label.Text = obj["NumberOfLogicalProcessors"].ToString();
                CPU_architecture_label.Text = CPU_Switches.CPU_architecture(Convert.ToUInt16(obj["Architecture"]));         
                CPU_family_label.Text = obj["Family"].ToString(); //TODO: lookup for family       
                CPU_type_label.Text = CPU_Switches.CPU_Type(Convert.ToUInt16(obj["ProcessorType"]));           
                CPU_chars_label.Text = obj["Characteristics"].ToString(); //TODO: lookup for chars               
                CPU_address_label.Text = obj["AddressWidth"].ToString();
            }
            /*END OF CPU INFO*/

            /*MEMORY INFO*/
            //  ObjectQuery wql = new ObjectQuery();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in searcher.Get())
            {
                Mem_total_label.Text = result["TotalVisibleMemorySize"].ToString();
                Mem_free_label.Text = result["FreePhysicalMemory"].ToString();
                Mem_virtual_label.Text = result["TotalVirtualMemorySize"].ToString();
                Mem_free_virtual_label.Text = result["FreeVirtualMemory"].ToString();                
            }
            ManagementObjectSearcher finder = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");          
            foreach (ManagementObject obj in finder.Get())
            {
                Mem_bank_label_label.Text = obj["BankLabel"].ToString();
                Mem_speed_label.Text = obj["ConfiguredClockSpeed"].ToString();
                Mem_voltage_label.Text = obj["ConfiguredVoltage"].ToString();
                Mem_bus_width_label.Text = obj["TotalWidth"].ToString();
                Mem_desc_label.Text = obj["Description"].ToString();
                Mem_form_factor_label.Text = Memory_Switches.Mem_form_factor(Convert.ToUInt16(obj["FormFactor"]));
                Mem_manufacturer_label.Text = obj["Manufacturer"].ToString();
                Mem_type_label.Text = Memory_Switches.Mem_type(Convert.ToUInt16(obj["MemoryType"]));
            }
            
            /*END OF MEMORY INFO*/

            /*STORAGE INFO*/
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Drive_count_label.Text =" / " + allDrives.Length.ToString() + " found drives";

            Drive_label_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].VolumeLabel.ToString() ;
            Drive_name_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].Name.ToString();       
            Drive_FS_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].DriveFormat.ToString();
            Drive_user_available_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].AvailableFreeSpace.ToString();
            Drive_total_available_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].TotalFreeSpace.ToString();
            Drive_total_size_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].TotalFreeSpace.ToString();
            Drive_root_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].RootDirectory.ToString();

            /*END OF STORAGE INFO*/

            /*GPU INFO*/
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            myVideoObject.Query = new ObjectQuery(string.Format("select * from Win32_VideoController"));
            
        
            foreach (ManagementObject obj in myVideoObject.Get())
            {
                GPU_name_label.Text = obj["name"].ToString();
                GPU_status_label.Text = obj["Status"].ToString();
                GPU_vid_mode_label.Text = obj["VideoModeDescription"].ToString();
                GPU_refresh_rate_label.Text = obj["CurrentRefreshRate"].ToString();
                GPU_ID_label.Text = obj["DeviceID"].ToString();
                GPU_VRAM_label.Text = obj["AdapterRAM"].ToString();
                GPU_VRAM_label.Text = obj["AdapterRAM"].ToString();
                GPU_dac_label.Text = obj["AdapterDACType"].ToString();
                GPU_driver_label.Text = obj["InstalledDisplayDrivers"].ToString();
                GPU_driver_version_label.Text = obj["DriverVersion"].ToString();
                GPU_processor_label.Text = obj["VideoProcessor"].ToString();
                GPU_architecture_label.Text = GPU_Switches.GPU_architecture(Convert.ToUInt16(obj["VideoArchitecture"]));
                GPU_Mem_type_label.Text = GPU_Switches.GPU_Mem_type(Convert.ToUInt16(obj["VideoMemoryType"]));
            }
            /*END OF GPU INFO*/

            /*NETWORK INTERFACES*/
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            NI_count_label.Text = " / " + nics.Length.ToString() + " interfaces found";
            if (nics == null || nics.Length < 1)
            {
                NI_num.Value = 1;
                NI_desc_label.Text = "No network interfaces found";
                NI_type_label.Text = "N.A";
                NI_Address_label.Text = "N.A";
                NI_status_label.Text = "N.A";
            }            
            else
            {
                NI_desc_label.Text = nics[Convert.ToInt32(NI_num.Value)-1].Description.ToString();
                NI_type_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].NetworkInterfaceType.ToString();
                NI_Address_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].GetPhysicalAddress().ToString();
                NI_status_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].OperationalStatus.ToString();
            }
            /*END OF NETWORK INTERFACES*/

            /*SOUND INFO*/
            ManagementObjectSearcher myAudioObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");
            
            List<ManagementObject> audio_devices = new List<ManagementObject>();

            foreach (ManagementObject obj in myAudioObject.Get())
            {
                audio_devices.Add(obj);                           
            }
            Audio_count_label.Text = " / " + audio_devices.Count.ToString() + " audio devices found";

            foreach(ManagementObject obj in audio_devices)
            {
                if (Array.IndexOf(audio_devices.ToArray(), obj) == Audio_num.Value - 1)
                {
                    Audio_name_label.Text = obj["Name"].ToString();
                    Audio_prod_name_label.Text = obj["ProductName"].ToString();
                    Audio_availability_label.Text = Audio_Switches.Audio_availability(Convert.ToUInt16(obj["Availability"]));
                    Audio_device_ID_label.Text = obj["DeviceID"].ToString();
                    Audio_pwr_managed_label.Text = obj["PowerManagementSupported"].ToString();
                    Audio_status_label.Text = obj["Status"].ToString();
                    Audio_status_info_label.Text = Audio_Switches.Audio_Status_info(Convert.ToUInt16(obj["StatusInfo"]));
                }
            }
            /*END OF SOUND INFO*/

            /*PRINTERS*/
            ManagementObjectSearcher myPrinterObject = new ManagementObjectSearcher("select * from Win32_Printer");

            List<ManagementObject> Printers = new List<ManagementObject>();
            foreach (ManagementObject obj in myPrinterObject.Get())
            {
                Printers.Add(obj);                          
            }
            Printer_count_label.Text = " / " + Printers.Count.ToString() + " printers found";

            foreach(ManagementObject obj in Printers)
            {
                if (Array.IndexOf(Printers.ToArray(), obj) == Printer_num.Value - 1)
                {
                    Printer_name_label.Text = obj["Name"].ToString();
                    Printer_network_label.Text = obj["Network"].ToString();
                    Printer_availability_label.Text = Printer_switches.Printer_availability(Convert.ToUInt16(obj["Availability"]));
                    Printer_default_label.Text = obj["Default"].ToString();
                    Printer_ID_label.Text = obj["DeviceID"].ToString();
                    Printer_status_label.Text = obj["Status"].ToString();
                }
            }
            /*END OF PRINTERS*/
        }

        private void Find_result_fields_Click(object sender, EventArgs e)
        {
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            ManagementObjectCollection results = myOperativeSystemObject.Get();

            foreach(ManagementObject result in results)
            {
                
                foreach(var p in result.SystemProperties )
                    Console.WriteLine(p.Value.ToString());                
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Drive_count_label.Text = " / " + allDrives.Length.ToString() + " found drives";

            if (Drive_num.Value <= allDrives.Length && Drive_num.Value > 0)
            {
                Drive_label_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].VolumeLabel.ToString();
                Drive_name_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].Name.ToString();
                Drive_FS_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].DriveFormat.ToString();
                Drive_user_available_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].AvailableFreeSpace.ToString();
                Drive_total_available_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].TotalFreeSpace.ToString();
                Drive_total_size_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].TotalFreeSpace.ToString();
                Drive_root_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].RootDirectory.ToString();
            }
            else if (Drive_num.Value == 0)
            {
                MessageBox.Show("First drive reached, cannot go further","Start of list",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Drive_num.Value = 1;
            }
            else
            {
                MessageBox.Show("Final drive reached, cannot go further","End of list",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Drive_num.Value = allDrives.Length;
            }
        }

        private void NI_num_ValueChanged(object sender, EventArgs e)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            NI_count_label.Text = " / " + nics.Length.ToString() + " Interfaces found";
            if (nics == null || nics.Length < 1)
            {
                NI_num.Value = 1;
                NI_desc_label.Text = "No network interfaces found";
                NI_type_label.Text = "N.A";
                NI_Address_label.Text = "N.A";
                NI_status_label.Text = "N.A";
            }
            else
            {
                if (NI_num.Value <= nics.Length && NI_num.Value > 0)
                {
                    NI_desc_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].Description.ToString();
                    NI_type_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].NetworkInterfaceType.ToString();
                    NI_Address_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].GetPhysicalAddress().ToString();
                    NI_status_label.Text = nics[Convert.ToInt32(NI_num.Value) - 1].OperationalStatus.ToString();
                }
                else if (NI_num.Value == 0)
                {
                    MessageBox.Show("First NIC reached, cannot go further", "Start of list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NI_num.Value = 1;
                }
                else
                {
                    MessageBox.Show("Final NIC reached, cannot go further", "End of list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NI_num.Value = nics.Length;
                }
            }

        }

        private void Audio_num_ValueChanged(object sender, EventArgs e)
        {
            ManagementObjectSearcher myAudioObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");

            List<ManagementObject> audio_devices = new List<ManagementObject>();

            foreach (ManagementObject obj in myAudioObject.Get())
            {
                audio_devices.Add(obj);
            }
            if (Audio_num.Value <= audio_devices.Count && Audio_num.Value > 0)
            {
                foreach (ManagementObject obj in audio_devices)
                {
                    if (Array.IndexOf(audio_devices.ToArray(), obj) == Audio_num.Value - 1)
                    {
                        Audio_name_label.Text = obj["Name"].ToString();
                        Audio_prod_name_label.Text = obj["ProductName"].ToString();
                        Audio_availability_label.Text = Audio_Switches.Audio_availability(Convert.ToUInt16(obj["Availability"]));
                        Audio_device_ID_label.Text = obj["DeviceID"].ToString();
                        Audio_pwr_managed_label.Text = obj["PowerManagementSupported"].ToString();
                        Audio_status_label.Text = obj["Status"].ToString();
                        Audio_status_info_label.Text = Audio_Switches.Audio_Status_info(Convert.ToUInt16(obj["StatusInfo"]));
                    }
                }
            }
            else if (Audio_num.Value == 0)
            {
                MessageBox.Show("First Audio device reached, cannot go further", "Start of list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Audio_num.Value = 1;
            }
            else
            {
                MessageBox.Show("Final Audio device reached, cannot go further", "End of list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Audio_num.Value = audio_devices.Count();
            }
        }

        private void Printer_num_ValueChanged(object sender, EventArgs e)
        {
            ManagementObjectSearcher myPrinterObject = new ManagementObjectSearcher("select * from Win32_Printer");

            List<ManagementObject> Printers = new List<ManagementObject>();
            foreach (ManagementObject obj in myPrinterObject.Get())
            {
                Printers.Add(obj);
            }
            if (Printer_num.Value <= Printers.Count && Printer_num.Value > 0)
            {
                foreach (ManagementObject obj in Printers)
                {
                    if (Array.IndexOf(Printers.ToArray(), obj) == Printer_num.Value - 1)
                    {
                        Printer_name_label.Text = obj["Name"].ToString();
                        Printer_network_label.Text = obj["Network"].ToString();
                        Printer_availability_label.Text = Printer_switches.Printer_availability(Convert.ToUInt16(obj["Availability"]));
                        Printer_default_label.Text = obj["Default"].ToString();
                        Printer_ID_label.Text = obj["DeviceID"].ToString();
                        Printer_status_label.Text = obj["Status"].ToString();
                    }
                }
            }
            else if (Printer_num.Value == 0)
            {
                MessageBox.Show("First Printer reached, cannot go further", "Start of list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Printer_num.Value = 1;                
            }
            else
            {
                MessageBox.Show("Final printer reached, cannot go further", "Start of list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Printer_num.Value = Printers.Count();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Get_info_BTN.PerformClick();
            Update_timer.Start();
            //Setting boxes with multiple elements to the default value, also populates then by trigering the numeric up/down's value changed method
           // Drive_num.Value = NI_num.Value = Audio_num.Value = Printer_num.Value = 1;
        }

        private void Update_frequency_ValueChanged(object sender, EventArgs e)
        {
            Update_timer.Interval = Convert.ToInt32(Update_frequency.Value * 1000);
        }

        private void Update_timer_Tick(object sender, EventArgs e)
        {
            /*Updates the following:
             * CPU: Clock speed
             * Memory: Free physical, Free virtual, Speed, Voltage
             * GPU: Video mode, Refresh rate
             * Storage: user available, total available
             * other areas with multiple entrys can be updated by the user cycling through them (to limit performance hit)
            */
            //CPU
            ManagementObjectSearcher Searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach(ManagementObject obj in Searcher.Get())
            {
                CPU_clock_label.Text = obj["CurrentClockSpeed"].ToString();
            }
            //Memory
            Searcher.Query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            foreach(ManagementObject obj in Searcher.Get())
            {
                Mem_free_label.Text = obj["FreePhysicalMemory"].ToString();
                Mem_free_virtual_label.Text = obj["FreeVirtualMemory"].ToString();
            }
            Searcher.Query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject obj in Searcher.Get())
            {
                Mem_speed_label.Text = obj["ConfiguredClockSpeed"].ToString();
                Mem_voltage_label.Text = obj["ConfiguredVoltage"].ToString();
            }
            //GPU
            Searcher.Query = new ObjectQuery("select * from Win32_VideoController");
            foreach (ManagementObject obj in Searcher.Get())
            {
                GPU_vid_mode_label.Text = obj["VideoModeDescription"].ToString();
                GPU_refresh_rate_label.Text = obj["CurrentRefreshRate"].ToString();               
            }
            //Storage
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Drive_user_available_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].AvailableFreeSpace.ToString();
            Drive_total_available_label.Text = allDrives[Convert.ToInt32(Drive_num.Value) - 1].TotalFreeSpace.ToString();

            // long memory = GC.GetTotalMemory(true);        
            // GC.Collect();
                       
        }

        private void Auto_update_CheckedChanged(object sender, EventArgs e)
        {
            if (Auto_update.Checked == true)
            {                
                Update_timer.Start();
            }
            else
            {
                Update_timer.Stop();
            }
        }
    }
}
