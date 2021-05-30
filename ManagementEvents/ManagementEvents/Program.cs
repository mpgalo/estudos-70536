using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace ManagementEvents
{
    class Program
    {
        public const String IP_Enabled = "IPEnabled";
        public const String IP_Address = "IPAddress";
        public const String IP_Subnet = "IPSubnet";
        public const String DNS_HostName = "DNSHostName";
        public const String DNS_Domain = "DNSDomain";

        static void Main(string[] args)
        {
            EnumerateLogicalDrives();
            EnumerateAllNetworkAdapters();
            EnumeratePausedServices();

            //Permite escutar um determinado evento de um serviço
            //QueryServices();
        }

        public static void EnumerateLogicalDrives()
        {

            //Somente necessita autenticação em maquinas remotas
            //ConnectionOptions DemoOptions = new ConnectionOptions();
            //DemoOptions.Username = "\\e060111";
            //DemoOptions.Password = "Outubro2010";
            //ManagementScope DemoScope = new ManagementScope("\\micp100682");
            //ObjectQuery DemoQuery = new ObjectQuery("SELECT Size, Name FROM Win32_LogicalDisk where DriveType=3");
            //ManagementObjectSearcher DemoSearcher = new ManagementObjectSearcher(DemoScope, DemoQuery);
            //ManagementObjectCollection AllObjects = DemoSearcher.Get();
            //foreach (ManagementObject DemoObject in AllObjects)
            //{
            //    Console.WriteLine("Resource Name: " + DemoObject["Name"].ToString());
            //    Console.WriteLine("Resource Size: " + DemoObject["Size"].ToString());
            //}

            ManagementObjectSearcher DemoQuery = new ManagementObjectSearcher("SELECT Size, Name FROM Win32_LogicalDisk where DriveType=3");
            ManagementObjectCollection DemoQueryCollection = DemoQuery.Get();
            foreach (ManagementObject DemoManager in DemoQueryCollection)
            {
                Console.WriteLine("Resource Name: " + DemoManager["Name"].ToString());
                Console.WriteLine("Resource Size: " + DemoManager["Size"].ToString());
            }
        }


        public static void EnumerateAllNetworkAdapters()
        {
            ManagementObjectSearcher DemoQuery = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection DemoQueryCollection = DemoQuery.Get();
            foreach (ManagementObject DemoManager in DemoQueryCollection)
            {
                Console.WriteLine("Description : " + DemoManager["Description"]);
                Console.WriteLine("MacAddress : " + DemoManager["MacAddress"]);

                try
                {
                    String[] IPAddresses = DemoManager[IP_Address] as String[];
                    String[] IPSubnets = DemoManager[IP_Subnet] as String[];
                    Console.WriteLine(DNS_HostName + " : " + DemoManager[DNS_HostName]);
                    Console.WriteLine(DNS_Domain + " : " + DemoManager[DNS_Domain]);
                    foreach (String IPAddress in IPAddresses)
                    {
                        Console.WriteLine(IP_Address + " : " + IPAddress);
                    }
                    foreach (String IPSubnet in IPSubnets)
                    {
                        Console.WriteLine(IP_Subnet + " : " + IPSubnet);
                    }
                }
                catch { }

            }
        }

        private static void EnumeratePausedServices()
        {
            ManagementObjectSearcher DemoSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Started = FALSE");
            ManagementObjectCollection AllObjects = DemoSearcher.Get();
            foreach (ManagementObject PausedService in AllObjects)
            {
                Console.WriteLine("Service = " + PausedService["Caption"]);
            }
        }

        public static void QueryServices()
        {
            EventQuery DemoQuery = new EventQuery();
            DemoQuery.QueryString = "SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance isa \"Win32_Service\" AND TargetInstance.State = 'Paused'";
            ManagementEventWatcher DemoWatcher = new ManagementEventWatcher(DemoQuery);
            DemoWatcher.Options.Timeout = new TimeSpan(0, 0, 100);
            Console.WriteLine("Open an application to trigger WaitForNextEvent");
            ManagementBaseObject Event = DemoWatcher.WaitForNextEvent();
            DemoWatcher.Stop();
        }

    }
}
