using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Net.NetworkInformation;

namespace ConsoleProfiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //MOSTLY THANKS TO: https://ourcodeworld.com/articles/read/294/how-to-retrieve-basic-and-advanced-hardware-and-software-information-gpu-hard-drive-processor-os-printers-in-winforms-with-c-sharp
            /*OS INFO*/
            Console.WriteLine("OS INFO");
            Console.WriteLine();

            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                Console.WriteLine("Caption  -  " + obj["Caption"]);
                Console.WriteLine("WindowsDirectory  -  " + obj["WindowsDirectory"]);
                Console.WriteLine("ProductType  -  " + obj["ProductType"]);
                Console.WriteLine("SerialNumber  -  " + obj["SerialNumber"]);
                Console.WriteLine("SystemDirectory  -  " + obj["SystemDirectory"]);
                Console.WriteLine("CountryCode  -  " + obj["CountryCode"]);
                Console.WriteLine("CurrentTimeZone  -  " + obj["CurrentTimeZone"]);
                Console.WriteLine("EncryptionLevel  -  " + obj["EncryptionLevel"]);
                Console.WriteLine("OSType  -  " + obj["OSType"]);
                Console.WriteLine("Version  -  " + obj["Version"]);
            }
            /*END OF OS INFO*/

            /*CPU INFO*/
            Console.WriteLine();
            Console.WriteLine("CPU INFO");
            Console.WriteLine();
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                Console.WriteLine("Name  -  " + obj["Name"]);
                Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("Manufacturer  -  " + obj["Manufacturer"]);
                Console.WriteLine("CurrentClockSpeed  -  " + obj["CurrentClockSpeed"]);
                Console.WriteLine("Caption  -  " + obj["Caption"]);
                Console.WriteLine("NumberOfCores  -  " + obj["NumberOfCores"]);
                Console.WriteLine("NumberOfEnabledCore  -  " + obj["NumberOfEnabledCore"]);
                Console.WriteLine("NumberOfLogicalProcessors  -  " + obj["NumberOfLogicalProcessors"]);
                Console.WriteLine("Architecture  -  " + obj["Architecture"]);
                Console.WriteLine("Family  -  " + obj["Family"]);
                Console.WriteLine("ProcessorType  -  " + obj["ProcessorType"]);
                Console.WriteLine("Characteristics  -  " + obj["Characteristics"]);
                Console.WriteLine("AddressWidth  -  " + obj["AddressWidth"]);
            }
            /*END OF CPU INFO*/

            /*MEMORY INFO*/
            Console.WriteLine();
            Console.WriteLine("MEMORY INFO");
            Console.WriteLine();

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("Total Visible Memory: {0} KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0} KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0} KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0} KB", result["FreeVirtualMemory"]);
            }
            /*END OF MEMORY INFO*/

            /*STORAGE INFO*/
            Console.WriteLine();
            Console.WriteLine("STORAGE INFO");
            Console.WriteLine();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);

                    Console.WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);

                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
                    Console.WriteLine("  Root directory:            {0, 12}", d.RootDirectory);
                }
            }
            /*END OF STORAGE INFO*/

            /*GPU INFO*/
            Console.WriteLine();
            Console.WriteLine("GPU INFO");
            Console.WriteLine();

            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                Console.WriteLine("Name  -  " + obj["Name"]);
                Console.WriteLine("Status  -  " + obj["Status"]);
                Console.WriteLine("Caption  -  " + obj["Caption"]);
                Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("AdapterRAM  -  " + obj["AdapterRAM"]);
                Console.WriteLine("AdapterDACType  -  " + obj["AdapterDACType"]);
                Console.WriteLine("Monochrome  -  " + obj["Monochrome"]);
                Console.WriteLine("InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"]);
                Console.WriteLine("DriverVersion  -  " + obj["DriverVersion"]);
                Console.WriteLine("VideoProcessor  -  " + obj["VideoProcessor"]);
                Console.WriteLine("VideoArchitecture  -  " + obj["VideoArchitecture"]);
                Console.WriteLine("VideoMemoryType  -  " + obj["VideoMemoryType"]);
            }
            /*END OF GPU INFO*/

            /*NETWORK INTERFACES*/
            Console.WriteLine();
            Console.WriteLine("NETWORK INTERFACE INFO");
            Console.WriteLine();

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
            }
            else
            {
                foreach (NetworkInterface adapter in nics)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    Console.WriteLine();
                    Console.WriteLine(adapter.Description);
                    Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                    Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                    Console.WriteLine("  Physical Address ........................ : {0}", adapter.GetPhysicalAddress().ToString());
                    Console.WriteLine("  Operational status ...................... : {0}", adapter.OperationalStatus);
                }
            }
            /*END OF NETWORK INTERFACES*/

            /*SOUND INFO*/
            Console.WriteLine();
            Console.WriteLine("SOUND DEVICE INFO");
            Console.WriteLine();

            ManagementObjectSearcher myAudioObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");

            foreach (ManagementObject obj in myAudioObject.Get())
            {
                Console.WriteLine("Name  -  " + obj["Name"]);
                Console.WriteLine("ProductName  -  " + obj["ProductName"]);
                Console.WriteLine("Availability  -  " + obj["Availability"]);
                Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("PowerManagementSupported  -  " + obj["PowerManagementSupported"]);
                Console.WriteLine("Status  -  " + obj["Status"]);
                Console.WriteLine("StatusInfo  -  " + obj["StatusInfo"]);
                Console.WriteLine(String.Empty.PadLeft(obj["ProductName"].ToString().Length, '='));
            }
            /*END OF SOUND INFO*/

            /*PRINTERS*/
            Console.WriteLine();
            Console.WriteLine("PRINTER INFO");
            Console.WriteLine();

            ManagementObjectSearcher myPrinterObject = new ManagementObjectSearcher("select * from Win32_Printer");

            foreach (ManagementObject obj in myPrinterObject.Get())
            {
                Console.WriteLine("Name  -  " + obj["Name"]);
                Console.WriteLine("Network  -  " + obj["Network"]);
                Console.WriteLine("Availability  -  " + obj["Availability"]);
                Console.WriteLine("Is default printer  -  " + obj["Default"]);
                Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                Console.WriteLine("Status  -  " + obj["Status"]);

                Console.WriteLine(String.Empty.PadLeft(obj["Name"].ToString().Length, '='));
            }
            /*END OF PRINTERS*/

            Console.WriteLine();
            Console.WriteLine("Process complete, press enter to exit");
            Console.ReadLine();
        }
    }
}
