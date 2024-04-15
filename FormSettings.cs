using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Occupation_of_states
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }
        private void FormSettings_Load(object sender, EventArgs e)
        {
            this.Top += 150;
            if (MainSettings.Default.FullScreen == true)
                checkBoxFullscreen.Checked = true;
            if (MainSettings.Default.CMDonline == true)
                CMDswitch.Checked = true;
            if (MainSettings.Default.CMDmultiON == true)
                CMDswitch1.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkBoxFullscreen.Checked)
                MainSettings.Default.FullScreen = true;
            else
                MainSettings.Default.FullScreen = false;

            if (CMDswitch.Checked == true)
                MainSettings.Default.CMDonline = true;
            else
                MainSettings.Default.CMDonline = false;

            if (CMDswitch1.Checked)
                MainSettings.Default.CMDmultiON = true;
            else
                MainSettings.Default.CMDmultiON = false;

            MainSettings.Default.Save();
            Application.Restart();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
