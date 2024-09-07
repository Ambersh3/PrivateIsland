using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateIsland_Client
{
    /// <summary>
    /// VIEW LICENSE.txt FOR LICENSE
    /// </summary>
    public partial class Notification : Form
    {
        private int secondsOpen = 0;

        public Notification(string Text)
        {
            InitializeComponent();
            Globals.NotificationsOpen++;
            NotificationBodyTxt.Text = Text;
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Globals.NotificationsOpen--;
            this.Close();
        }

        private void AutoCloseWorker_Tick(object sender, EventArgs e)
        {
            try
            {
                secondsOpen++;
                try { CloseBtn.Text = (8 - secondsOpen).ToString(); } catch { CloseBtn.Text = "~"; }

                if (secondsOpen > 7)
                {
                    Globals.NotificationsOpen--;
                    this.Close();
                }
            }
            catch { }
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            try
            {
                Refresh();
                Visible = true;

                Opacity = 0;
                while (Opacity < 0.92)
                {
                    Opacity += 0.01;
                    Refresh();
                }
            }
            catch
            {
                Opacity = 1;
            }
        }
    }
}
