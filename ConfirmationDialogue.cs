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
    public partial class ConfirmationDialogue : Form
    {
        public ConfirmationDialogue(string questionTxt, FormStartPosition startWhere)
        {
            InitializeComponent();
            Theme.UseImmersiveDarkMode(Handle, true);
            
            QuestionBodyTxt.Text = questionTxt;
            StartPosition = startWhere;
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

        private void YesBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void NoBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
