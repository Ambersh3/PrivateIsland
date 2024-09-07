using HidSharp;
using LibreHardwareMonitor.Hardware;
using PrivateIsland_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateIsland_Client
{
    /// <summary>
    /// VIEW LICENSE.txt FOR LICENSE
    /// </summary>
    public partial class PerformanceMonitorWidget : Form
    {
        Computer Device;
        ISensor GPU_Percentage_Sensor;
        ISensor GPU_Heat_Sensor;

        public PerformanceMonitorWidget()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);

            try
            {
                Opacity = Settings.Default.pwidgetopacity;
            }
            catch { }

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                Device = new Computer
                {
                    IsCpuEnabled = true,
                    IsGpuEnabled = true
                };

                Device.Open();
                Device.Accept(new UpdateVisitor());

                foreach (IHardware hardware in Device.Hardware)
                {
                    Console.WriteLine("Hardware: {0}", hardware.Name);

                    foreach (IHardware subhardware in hardware.SubHardware)
                    {
                        foreach (ISensor sensor in subhardware.Sensors)
                        {
                            DetermineIfImportantSensor(sensor);

                            Console.WriteLine("\tSensor: {0}, value: {1}, a: {2}", sensor.Name, sensor.Value, sensor.SensorType);
                        }
                    }

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        DetermineIfImportantSensor(sensor);
                        Console.WriteLine("\tSensor: {0}, value: {1}, a: {2}", sensor.Name, sensor.Value, sensor.SensorType);
                    }
                }
            }).Start();
        }

        private void DetermineIfImportantSensor(ISensor sensor)
        {
            if (sensor.Name.Contains("Core") && sensor.SensorType == SensorType.Temperature)
                GPU_Heat_Sensor = sensor;
            if (sensor.Name.Contains("Core") && sensor.SensorType == SensorType.Load)
                GPU_Percentage_Sensor = sensor;
        }

        private void PerformanceMonitorWorker_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (IHardware hardware in Device.Hardware)
                {
                    hardware.Update();

                    //Console.WriteLine("Hardware: {0}", hardware.Name);
                    foreach (IHardware subhardware in hardware.SubHardware)
                    {
                        foreach (ISensor sensor in subhardware.Sensors)
                        {
                            DetermineIfImportantSensor(sensor);
                            //Console.WriteLine("\tSensor: {0}, value: {1}, a: {2}", sensor.Name, sensor.Value, sensor.SensorType);
                        }
                    }

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        DetermineIfImportantSensor(sensor);
                        //Console.WriteLine("\tSensor: {0}, value: {1}, a: {2}", sensor.Name, sensor.Value, sensor.SensorType);
                    }
                }

                if (GPU_Heat_Sensor is null || GPU_Percentage_Sensor is null)
                    return;

                StatsTxt.Text = $"{(int)Math.Round((double)GPU_Percentage_Sensor.Value, 0)}% {GPU_Heat_Sensor.Value}℃";
            }
            catch { this.Close(); }
        }

        #region Dragging

        private void StatsTxt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private void StatsTxt_DoubleClick(object sender, EventArgs e)
        {
            // deprecated
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatsTxt_Click(object sender, EventArgs e)
        {
            // deprecated
        }

        private void Opacity20_Click(object sender, EventArgs e)
        {
            Opacity = 0.2;

            Settings.Default.pwidgetopacity = 0.2;
            Settings.Default.Save();
        }

        private void Opacity60_Click(object sender, EventArgs e)
        {
            Opacity = 0.6;

            Settings.Default.pwidgetopacity = 0.6;
            Settings.Default.Save();
        }

        private void Opacity40_Click(object sender, EventArgs e)
        {
            Opacity = 0.4;

            Settings.Default.pwidgetopacity = 0.4;
            Settings.Default.Save();
        }

        private void HideWidgetForeverBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.showpwidget = false;
            Settings.Default.Save();
            this.Close();
        }
    }

    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer Device)
        {
            Device.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }

}
