using PrivateIsland_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateIsland_Client
{
    /// <summary>
    /// VIEW LICENSE.txt FOR LICENSE
    /// </summary>
    public partial class MainFrm : Form
    {
        DateTime TimeSinceConnect = DateTime.Now;
        string LastKnownState = "na";
        DateTime TimeOfLaunch = DateTime.Now;

        public MainFrm(string[] args)
        {
            InitializeComponent();
            Theme.UseImmersiveDarkMode(Handle, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void ToggleStateBtn_Click(object sender, EventArgs e)
        {
            switch(ToggleStateBtn.Text)
            {
                case "Connect":
                    StateTxt.Text = "Follow onscreen dialog";
                    Refresh();

                    var CredentialFrm = new DetailsFrm(FormStartPosition.CenterParent);
                    CredentialFrm.ShowDialog();

                    StateTxt.Text = "Please wait";
                    Refresh();

                    if (CredentialFrm.DialogResult == DialogResult.OK)
                    {
                        VPNInstance.Create(
                            "PrivateIslandVPN",
                            CredentialFrm.Host,
                            CredentialFrm.Username,
                            CredentialFrm.Password,
                            CredentialFrm.PSK);

                        ToggleStateBtn.Text = "Disconnect";
                        TimeSinceConnect = DateTime.Now;
                    }
                    break;
                case "Disconnect":
                    StateTxt.Text = "Please wait";
                    Refresh();

                    VPNInstance.Abandon("PrivateIslandVPN");

                    ToggleStateBtn.Text = "Connect";
                    TimeSinceConnect = DateTime.MinValue;
                    break;
            }
        }

        private void StateCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                string[] state = VPNInstance.GetState("PrivateIslandVPN");

                if(state[0] == "Null")
                {
                    if (LastKnownState != state[0])
                    {
                        if((DateTime.Now - TimeOfLaunch).TotalSeconds > 10)
                            if (Globals.NotificationsOpen < 2)
                            {
                                Notification newNotification = new Notification($"You are no longer connected");
                                newNotification.Show();
                            }
                    }
                    LastKnownState = state[0];

                    StateTxt.Text = "Not connected";
                    ToggleStateBtn.Text = "Connect";
                    return;
                }

                if (TimeSinceConnect == DateTime.MinValue && state[0] == "Connected")
                    TimeSinceConnect = DateTime.Now;

                if (TimeSinceConnect == DateTime.MinValue)
                    StateTxt.Text = "Not connected";
                else
                {
                    if(LastKnownState != state[0])
                    {
                        if (Globals.NotificationsOpen < 2)
                        {
                            Notification newNotification = new Notification($"{state[0]} to PrivateIsland");
                            newNotification.Show();
                        }
                    }
                    LastKnownState = state[0];

                    StateTxt.Text = $"Status: {state[0]}\nUptime: {(DateTime.Now - TimeSinceConnect).TotalMinutes.ToString("0.00")} mins";
                }
            }
            catch(Exception ex) { StateCheck.Stop(); throw new Exception(ex.ToString()); }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VPNInstance.GetState("PrivateIslandVPN")[0] == "Connected")
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }    
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (VPNInstance.GetState("PrivateIslandVPN")[0] == "Connected")
            {
                ToggleStateBtn.Text = "Disconnect";
                TimeSinceConnect = DateTime.Now;
            }

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            IntPtr MenuHandle = GetSystemMenu(this.Handle, false);
            InsertMenu(MenuHandle, 5, MF_BYPOSITION, ENPWIDG, "Enable performance widget");
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Default.showpwidget)
                    new PerformanceMonitorWidget().Show();
            }
            catch { }
        }

        #region NativeContextMenu

        /*
         * https://stackoverflow.com/questions/1557904/adding-a-custom-context-menu-item-to-windows-form-title-bar
         */

        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 MF_BYPOSITION = 0x400;
        public const Int32 ENPWIDG = 1000;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND)
            {
                switch (msg.WParam.ToInt32())
                {
                    case ENPWIDG:
                        try
                        {
                            if (!Settings.Default.showpwidget)
                                new PerformanceMonitorWidget().Show();

                            Settings.Default.showpwidget = true;
                            Settings.Default.Save();
                            new Notification("Performance widget enabled").Show();
                        }
                        catch
                        {
                            MessageBox.Show("Failed to enable performance widget. Possible corrupted installation.");
                        }
                        return;
                    default:
                        break;
                }
            }
            base.WndProc(ref msg);
        }
        #endregion
    }
}
