using System;
using System.Text;
using System.Windows;
using System.Management;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace Hardware_and_Sofware_Monitor_Program
{
    public partial class MainWindow : Window
    {
        public float temperature;

        public MainWindow()
        {
            InitializeComponent();
            GetInstalledApps();
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(5000);
            dispatcherTimer.Start();
        }
        
        private void gomb_1_Click(object sender, RoutedEventArgs e)
        {
            String a1 = Environment.MachineName;
            text_1.Text = a1;
            String a2 = Environment.UserName;
            text_2.Text = a2;
            int a6 = Environment.ProcessorCount;
            text_6.Text = Convert.ToString(a6);
            String a3 = (Environment.OSVersion.ToString());
            text_3.Text = a3;
            String a5 = (Environment.OSVersion.Platform.ToString());
            text_5.Text = a5;
            String a7 = Environment.CurrentDirectory;
            text_7.Text = a7;
            String a8 = Environment.SystemDirectory;
            text_8.Text = a8;
            String a9 = Environment.UserDomainName;
            text_9.Text = a9;
            Process currentProcess = Process.GetCurrentProcess();
            Process currentProcess1 = Process.GetCurrentProcess();
            long usedMemory = currentProcess.PrivateMemorySize64 / 1000000;
            text_10.Text = usedMemory.ToString();
        }

        private void gomb_2_Click(object sender, RoutedEventArgs e)
        {
            text_1.Text = "";
            text_2.Text = "";
            text_3.Text = "";
            text_5.Text = "";
            text_6.Text = "";
            text_7.Text = "";
            text_8.Text = "";
            text_9.Text = "";
            text_10.Text = "";
        }

        public void GetInstalledApps()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {

                        try
                        {
                            listBox.Items.Add(sk.GetValue("Kiírás"));
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                label.Content = listBox.Items.Count.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectQuery Sq = new SelectQuery("Win32_Processor");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();
            foreach (ManagementObject mo in osDetailsCollection)
            {
                sb.AppendLine(string.Format("Name : {0}", (string)mo["Name"]));
                sb.AppendLine(string.Format("Availability: {0}", (ushort)mo["Availability"]));
                sb.AppendLine(string.Format("Architecture: {0}", (ushort)mo["Architecture"]));
                sb.AppendLine(string.Format("AddressWidth: {0}", (ushort)mo["AddressWidth"]));
                sb.AppendLine(string.Format("Caption: {0}", (string)mo["Caption"]));
                sb.AppendLine(string.Format("InstallDate: {0}", Convert.ToDateTime(mo["InstallDate"]).ToString()));
                sb.AppendLine(string.Format("ConfigManagerUserConfig: {0}", (string)mo["ConfigManagerUserConfig"]));
                sb.AppendLine(string.Format("CpuStatus : {0}", (ushort)mo["CpuStatus"]));
                sb.AppendLine(string.Format("CreationClassName : {0}", (string)mo["CreationClassName"]));
                sb.AppendLine(string.Format("CurrentClockSpeed : {0}", mo["CurrentClockSpeed"]).ToString());
                sb.AppendLine(string.Format("CurrentVoltage : {0}", (ushort)mo["CurrentVoltage"]));
                sb.AppendLine(string.Format("DataWidth : {0}", (ushort)mo["DataWidth"]));
                sb.AppendLine(string.Format("Description: {0}", (string)mo["Description"]));
                sb.AppendLine(string.Format("DeviceID : {0}", (string)mo["DeviceID"]));
                sb.AppendLine(string.Format("ErrorCleared: {0}", (string)mo["ErrorCleared"]));
                sb.AppendLine(string.Format("ErrorDescription : {0}", (string)mo["ErrorDescription"]));
                sb.AppendLine(string.Format("ExtClock : {0}", mo["ExtClock"]).ToString());
                sb.AppendLine(string.Format("Family : {0}", (ushort)mo["Family"]));
                sb.AppendLine(string.Format("L2CacheSize : {0}", mo["L2CacheSize"]).ToString());
                sb.AppendLine(string.Format("L2CacheSpeed : {0}", mo["L2CacheSpeed"]).ToString());
                sb.AppendLine(string.Format("L3CacheSize : {0}", mo["L3CacheSize"]).ToString());
                sb.AppendLine(string.Format("L3CacheSpeed : {0}", mo["L3CacheSpeed"]).ToString());
                sb.AppendLine(string.Format("LastErrorCode : {0}", mo["LastErrorCode"]).ToString());
                sb.AppendLine(string.Format("Level : {0}", (ushort)mo["Level"]));
                sb.AppendLine(string.Format("LoadPercentage: {0}", (ushort)mo["LoadPercentage"]));
                sb.AppendLine(string.Format("Manufacturer: {0}", (string)mo["Manufacturer"]));
                sb.AppendLine(string.Format("MaxClockSpeed : {0}", mo["MaxClockSpeed"]).ToString());
                sb.AppendLine(string.Format("NumberOfCores : {0}", mo["NumberOfCores"]).ToString());
                sb.AppendLine(string.Format("OtherFamilyDescription: {0}", (string)mo["OtherFamilyDescription"]));
                sb.AppendLine(string.Format("NumberOfLogicalProcessors : {0}", mo["NumberOfLogicalProcessors"]).ToString());
                sb.AppendLine(string.Format("PNPDeviceID: {0}", (string)mo["PNPDeviceID"]));
                sb.AppendLine(string.Format("PowerManagementSupported : {0}", mo["PowerManagementSupported"].ToString()));
                sb.AppendLine(string.Format("ProcessorId: {0}", (string)mo["ProcessorId"]));
                sb.AppendLine(string.Format("ProcessorType : {0}", (ushort)mo["ProcessorType"]));
                sb.AppendLine(string.Format("Role: {0}", (string)mo["Role"]));
                sb.AppendLine(string.Format("SocketDesignation : {0}", mo["SocketDesignation"]).ToString());
                sb.AppendLine(string.Format("Status : {0}", (string)mo["Status"]));
                sb.AppendLine(string.Format("StatusInfo: {0}", (ushort)mo["StatusInfo"]));
                sb.AppendLine(string.Format("Stepping : {0}", (string)mo["Stepping"]));
                sb.AppendLine(string.Format("SystemCreationClassName : {0}", (string)mo["SystemCreationClassName"]));
                sb.AppendLine(string.Format("SystemName: {0}", (string)mo["SystemName"]));
                sb.AppendLine(string.Format("UniqueId : {0}", (string)mo["UniqueId"]));
                sb.AppendLine(string.Format("UpgradeMethod: {0}", (ushort)mo["UpgradeMethod"]));
                sb.AppendLine(string.Format("Version: {0}", (string)mo["Version"]));
                sb.AppendLine(string.Format("VoltageCaps : {0}", mo["VoltageCaps"]).ToString());
            }
            MessageBox.Show(sb.ToString());
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            PerformanceCounter memPref = new PerformanceCounter("Memory", "Available MBytes");
            PerformanceCounter cpuPerf = new PerformanceCounter("Processor", "% Processzor idő", "_Egész");
            var computer = new Computer();
            computer.CPUEnabled = true;
            computer.Open();

            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                            temperature = sensor.Value.GetValueOrDefault();
                    }
                }
            }
            temp.Content = temperature;
            cpuUsage.Content = (int)cpuPerf.NextValue() + "%";
            Thread.Sleep(100);
            ramUsage.Content = memPref.NextValue() + "Mb";
        }
    }
}