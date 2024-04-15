using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Occupation_of_states
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMultiplayerOff_Click(object sender, EventArgs e)
        {
            MainSettings.Default.ModePlay = 2;
            CreateMenu Cmenu = new CreateMenu();
            Cmenu.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (MainSettings.Default.FullScreen == true)
                this.FormBorderStyle = FormBorderStyle.None;
            else
                this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            VersionLabel.Text = "Game Version " + Application.ProductVersion;
            MainPanel.Visible = true;
        }

        private void MainMenu_SizeChanged(object sender, EventArgs e)
        {
            MainPanel.Left = (this.Width - MainPanel.Width) / 2;
            MainPanel.Top = (this.Height - MainPanel.Height) / 2;
            VersionLabel.Top = this.Height  - 70;
            VersionLabel.Left = this.Width - (VersionLabel.Width + 20);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings fmSettings = new FormSettings();
            fmSettings.ShowDialog();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            bntMultiplayerOff.BackColor = Color.Blue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            bntMultiplayerOff.BackColor = Color.BlueViolet;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Want you realy exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMultiplayerOn_Click(object sender, EventArgs e)
        {
            MainSettings.Default.ModePlay = 3;
            CreateMenu createm = new CreateMenu();
            createm.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayPanel.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PlayPanel.Visible = false;
        }

        private void btnSingleplayer_Click(object sender, EventArgs e)
        {
            MainSettings.Default.ModePlay = 1;
            CreateMenu createm = new CreateMenu();
            createm.ShowDialog();
        }
        //
        //ANIMATION BUTTONS
        //
        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.BackgroundImage = Properties.Resources.BtnMenu2;
        }

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.BtnMenu2;
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            BtnExit.BackgroundImage = Properties.Resources.BtnMenu2;
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.BackgroundImage = Properties.Resources.BtnMenu2;
            BtnCreatorMap.BackgroundImage = Properties.Resources.BtnMenu2;
        }

        private void btnMultiplayerOn_MouseEnter(object sender, EventArgs e)
        {
            btnMultiplayerOn.BackgroundImage = Properties.Resources.BtnLong2;
        }

        private void bntMultiplayerOff_MouseEnter(object sender, EventArgs e)
        {
            bntMultiplayerOff.BackgroundImage = Properties.Resources.BtnLong2;
        }

        private void btnSingleplayer_MouseEnter(object sender, EventArgs e)
        {
            btnSingleplayer.BackgroundImage = Properties.Resources.BtnLong2;
        }

        private void bntAnimate_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.BackgroundImage = Properties.Resources.BtnMenu1;
            btnSettings.BackgroundImage = Properties.Resources.BtnMenu1;
            BtnCreatorMap.BackgroundImage = Properties.Resources.BtnMenu1;
            BtnExit.BackgroundImage = Properties.Resources.BtnMenu1;
            btnBack.BackgroundImage = Properties.Resources.BtnMenu1;

            btnSingleplayer.BackgroundImage = Properties.Resources.BtnLong1;
            bntMultiplayerOff.BackgroundImage = Properties.Resources.BtnLong1;
            btnMultiplayerOn.BackgroundImage = Properties.Resources.BtnLong1;
        }

        private void BtnCreatorMap_Click(object sender, EventArgs e)
        {
            CreatorMap creator = new CreatorMap();
            creator.ShowDialog();
        }
    }
}
