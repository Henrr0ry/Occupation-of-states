using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;


namespace Occupation_of_states
{
    public partial class CreateMenu : Form
    {
        public CreateMenu()
        {
            InitializeComponent();
        }
        bool Ready = false;

        //
        //OFFLINE MULTIPLAYER AND LOAD PATH
        //
        private void CreateMenu_Load(object sender, EventArgs e)
        {
            if (MainSettings.Default.ModePlay == 1)
            {
                panel3.Visible = true;
                BtnCreateBot.Visible = true;
                ModeIcon.Image = Properties.Resources.PvB;
            }
            if(MainSettings.Default.ModePlay == 2)
            {
                panel3.Visible = false;
                BtnCreateBot.Visible = false;
                ModeIcon.Image = Properties.Resources.PvPOff;
            }
            if (MainSettings.Default.ModePlay == 3)
            {
                panel4.Visible = true;
                BtnCreateLobby.Visible = true;
                ModeIcon.Image = Properties.Resources.PvPOn;
                btnCreate.Visible = false;
                BtnCreateBot.Visible = false;
            }
            try
            {
                if (UsersSettings.Default.ProfileLast1 == 1)
                    LogoBox1.Image = Properties.Resources.Icon1;
                if (UsersSettings.Default.ProfileLast1 == 2)
                    LogoBox1.Image = Properties.Resources.Icon2;
                if (UsersSettings.Default.ProfileLast1 == 3)
                    LogoBox1.Image = Properties.Resources.Icon3;
                if (UsersSettings.Default.ProfileLast1 == 4)
                    LogoBox1.Image = Properties.Resources.Icon4;
                if (UsersSettings.Default.ProfileLast1 == 5)
                    LogoBox1.Image = Properties.Resources.Icon5;
                if (UsersSettings.Default.ProfileLast1 == 6)
                    LogoBox1.Image = Image.FromFile(UsersSettings.Default.Profile1);
                LogoBox1.Refresh();
                if (UsersSettings.Default.ProfileLast2 == 1)
                    LogoBox2.Image = Properties.Resources.Icon1;
                if (UsersSettings.Default.ProfileLast2 == 2)
                    LogoBox2.Image = Properties.Resources.Icon2;
                if (UsersSettings.Default.ProfileLast2 == 3)
                    LogoBox2.Image = Properties.Resources.Icon3;
                if (UsersSettings.Default.ProfileLast2 == 4)
                    LogoBox2.Image = Properties.Resources.Icon4;
                if (UsersSettings.Default.ProfileLast2 == 5)
                    LogoBox2.Image = Properties.Resources.Icon5;
                if (UsersSettings.Default.ProfileLast2 == 6)
                    LogoBox2.Image = Image.FromFile(UsersSettings.Default.Profile2);
                LogoBox2.Refresh();
            }
            catch
            {
                LogoBox1.Image = Properties.Resources.Icon1;
                LogoBox2.Image = Properties.Resources.Icon1;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Err1.Visible = false;
            Err2.Visible = false;
            Err3.Visible = false;
            try
            {
                if (NameBox1.Text != "" && comboBoxState1.Text != "" && NameBox2.Text != "" && comboBoxState2.Text != "")
                {
                    if (NameBox1.Text != NameBox2.Text && comboBoxState1.Text != comboBoxState2.Text)
                    {
                        UsersSettings.Default.Name1 = NameBox1.Text;
                        UsersSettings.Default.StartState1 = comboBoxState1.Text;
                        UsersSettings.Default.Name2 = NameBox2.Text;
                        UsersSettings.Default.StartState2 = comboBoxState2.Text;
                        UsersSettings.Default.Save();
                        Ready = true;
                    }
                    else
                        Err3.Visible = true;
                }
                else
                    Err1.Visible = true;
            }
            catch
            {
                MessageBox.Show("Image Error 404", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBoxMap.Text != "" && Ready == true)
            {
                OffMultiplayer offmulti = new OffMultiplayer();
                offmulti.ShowDialog();
                this.Close();
            }
            if (comboBoxMap.Text == "" && Ready == false)
                Err2.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetBox1_Click(object sender, EventArgs e)
        {
            LogoBox1.Image = Properties.Resources.Icon1;
            UsersSettings.Default.ProfileLast1 = 1;
            UsersSettings.Default.Save();
        }

        private void SetBox2_Click(object sender, EventArgs e)
        {
            LogoBox1.Image = Properties.Resources.Icon2;
            UsersSettings.Default.ProfileLast1 = 2;
            UsersSettings.Default.Save();
        }

        private void SetBox3_Click(object sender, EventArgs e)
        {
            LogoBox1.Image = Properties.Resources.Icon3;
            UsersSettings.Default.ProfileLast1 = 3;
            UsersSettings.Default.Save();
        }

        private void SetBox4_Click(object sender, EventArgs e)
        {
            LogoBox1.Image = Properties.Resources.Icon4;
            UsersSettings.Default.ProfileLast1 = 4;
            UsersSettings.Default.Save();
        }

        private void SetBox5_Click(object sender, EventArgs e)
        {
            LogoBox1.Image = Properties.Resources.Icon5;
            UsersSettings.Default.ProfileLast1 = 5;
            UsersSettings.Default.Save();
        }

        private void ImportBox6_Click(object sender, EventArgs e)
        {
            UsersSettings.Default.ProfileLast1 = 6;
            var dialog = new OpenFileDialog();

            dialog.Title = "Choose your Player Icon";
            dialog.Filter = "bmp files (*.png)|*.png";
            dialog.InitialDirectory = @"C:\Downloads\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LogoBox1.Image = new Bitmap(dialog.FileName);
                UsersSettings.Default.Profile1 = dialog.FileName;
                UsersSettings.Default.Save();
                //save player icon
                if (!Directory.Exists(Application.StartupPath + @"\player_icons"))
                    Directory.CreateDirectory("player_icons");
                if (!File.Exists(Application.StartupPath + @"\player_icons\" + NameBox1.Text + "_icon.png"))
                {
                    sdialog.InitialDirectory = Application.StartupPath + @"\player_icons";
                    sdialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                    sdialog.FileName = NameBox1.Text + "_icon.png";
                    if (sdialog.ShowDialog() == DialogResult.OK)
                    {
                        Image imageToConvert = LogoBox1.Image;
                        imageToConvert.Save(sdialog.FileName);
                    }
                    sdialog.Dispose();
                }
            }
            dialog.Dispose();
        }

        private void SetBox6_Click(object sender, EventArgs e)
        {
            LogoBox2.Image = Properties.Resources.Icon1;
            UsersSettings.Default.ProfileLast2 = 1;
            UsersSettings.Default.Save();
        }

        private void SetBox7_Click(object sender, EventArgs e)
        {
            LogoBox2.Image = Properties.Resources.Icon2;
            UsersSettings.Default.ProfileLast2 = 2;
            UsersSettings.Default.Save();
        }

        private void SetBox8_Click(object sender, EventArgs e)
        {
            LogoBox2.Image = Properties.Resources.Icon3;
            UsersSettings.Default.ProfileLast2 = 3;
            UsersSettings.Default.Save();
        }

        private void SetBox9_Click(object sender, EventArgs e)
        {
            LogoBox2.Image = Properties.Resources.Icon4;
            UsersSettings.Default.ProfileLast2 = 4;
            UsersSettings.Default.Save();
        }

        private void SetBox10_Click(object sender, EventArgs e)
        {
            LogoBox2.Image = Properties.Resources.Icon5;
            UsersSettings.Default.ProfileLast2 = 5;
            UsersSettings.Default.Save();
        }

        private void ImportBox2_Click(object sender, EventArgs e)
        {
            UsersSettings.Default.ProfileLast2 = 6;
            var dialog2 = new OpenFileDialog();

            dialog2.Title = "Choose your Player Icon";
            dialog2.Filter = "bmp files (*.png)|*.png";
            dialog2.InitialDirectory = @"C:\Downloads\";

            if (dialog2.ShowDialog() == DialogResult.OK)
            {
                LogoBox2.Image = new Bitmap(dialog2.FileName);
                UsersSettings.Default.Profile2 = dialog2.FileName;
                UsersSettings.Default.Save();
                //save player icon
                if (!Directory.Exists(Application.StartupPath + @"\player_icons"))
                    Directory.CreateDirectory("player_icons");
                if (!File.Exists(Application.StartupPath + @"\player_icons\" + NameBox2.Text + "_icon.png"))
                {
                    sdialog.InitialDirectory = Application.StartupPath + @"\player_icons";
                    sdialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                    sdialog.FileName = NameBox2.Text + "_icon.png";
                    if (sdialog.ShowDialog() == DialogResult.OK)
                    {
                        Image imageToConvert = LogoBox2.Image;
                        imageToConvert.Save(sdialog.FileName);
                    }
                    sdialog.Dispose();
                }
                dialog2.Dispose();
            }
        }

        private void comboBoxMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxState1.Items.Clear();
                comboBoxState2.Items.Clear();
                comboBoxBot.Items.Clear();
                string word = "";
                char c = '1';
                int phase = 0;

                if (comboBoxMap.Text == "Europe")
                    MainSettings.Default.LoadPathText = @"\map_data\Europe.dat";
                if (comboBoxMap.Text == "South America")
                    MainSettings.Default.LoadPathText = @"\map_data\South_america.dat";
                if (comboBoxMap.Text == "Africa")
                    MainSettings.Default.LoadPathText = @"\map_data\Africa.dat";

                if (comboBoxMap.Text == "My Own..")
                {
                    OpenFileDialog openfile = new OpenFileDialog();
                    openfile.ShowDialog();
                    MainSettings.Default.LoadPathText = openfile.InitialDirectory  + openfile.FileName;
                }
                   StreamReader reader = new StreamReader(Application.StartupPath + MainSettings.Default.LoadPathText);
                do
                {
                    c = Convert.ToChar(reader.Read());
                    if (phase == 5 && c != '|' && c != '-')
                    {
                        word += c;
                    }
                    else if (phase == 5)
                    {
                        comboBoxState1.Items.Add(word);
                        comboBoxState2.Items.Add(word);
                        comboBoxBot.Items.Add(word);
                        word = null;
                    }
                    if (c == '|')
                        phase++;
                } while (phase < 6);
            }
            catch
            {
                MessageBox.Show("Map file is corrupted!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        //SINGLEPLAYER
        //

        private void Difficult1_Click(object sender, EventArgs e)
        {
            MainSettings.Default.BotDifficult = 1;
            LogoBot.Image = Properties.Resources.IconBot1;
            NameBoxBot.Text = "Easy_Bot";
        }

        private void Difficult2_Click(object sender, EventArgs e)
        {
            MainSettings.Default.BotDifficult = 2;
            LogoBot.Image = Properties.Resources.IconBot2;
            NameBoxBot.Text = "Normal_Bot";
        }

        private void Difficult3_Click(object sender, EventArgs e)
        {
            MainSettings.Default.BotDifficult = 3;
            LogoBot.Image = Properties.Resources.IconBot3;
            NameBoxBot.Text = "Hard_Bot";
        }

        private void Difficult4_Click(object sender, EventArgs e)
        {
            var imput = MessageBox.Show("This Bot is Cheater, do you want to play with him?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (imput == DialogResult.Yes)
            {
                MainSettings.Default.BotDifficult = 4;
                LogoBot.Image = Properties.Resources.IconBot4;
                NameBoxBot.Text = "Ch34t3r_B0t";
            }
        }

        private void BtnCreateBot_Click(object sender, EventArgs e)
        {
            Err1.Visible = false;
            Err2.Visible = false;
            Err3.Visible = false;
            try
            {
                if (NameBox1.Text != "" && comboBoxState1.Text != "" && NameBoxBot.Text != "" && comboBoxBot.Text != "")
                {
                    if (NameBox1.Text != NameBoxBot.Text && comboBoxState1.Text != comboBoxBot.Text)
                    {
                        UsersSettings.Default.Name1 = NameBox1.Text;
                        UsersSettings.Default.StartState1 = comboBoxState1.Text;
                        UsersSettings.Default.Name2 = NameBoxBot.Text;
                        UsersSettings.Default.StartState2 = comboBoxBot.Text;
                        UsersSettings.Default.Save();
                        Ready = true;
                    }
                    else
                        Err3.Visible = true;
                }
                else
                    Err1.Visible = true;
            }
            catch
            {
                MessageBox.Show("Image Error 404", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBoxMap.Text != "" && Ready == true)
            {
                OffSingleplayer single = new OffSingleplayer();
                single.ShowDialog();
                this.Close();
            }
            if (comboBoxMap.Text == "" && Ready == false)
                Err2.Visible = true;
        }

        //ONLINE MULTIPLAYER

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            Err4.Visible = false;
            try
            {
                if (NameBox1.Text != "")
                {
                    MainSettings.Default.LobbyCreate = false;
                    UsersSettings.Default.Name1 = NameBox1.Text;
                    UsersSettings.Default.Save();
                    OnMultiplayer onmulti = new OnMultiplayer();
                    onmulti.ShowDialog();
                    this.Close();
                }
                else
                    Err4.Visible = true;
            }
            catch
            {
                MessageBox.Show("Image Error 404", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreateLobby_Click(object sender, EventArgs e)
        {
            Err2.Visible = false;
            try
            {
                if (NameBox1.Text != "" && comboBoxState1.Text != "")
                {
                    UsersSettings.Default.Name1 = NameBox1.Text;
                    UsersSettings.Default.StartState1 = comboBoxState1.Text;
                    UsersSettings.Default.Save();
                    Ready = true;
                }
            }
            catch
            {
                MessageBox.Show("Image Error 404", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBoxMap.Text != "" && Ready == true)
            {
                MainSettings.Default.LobbyCreate = true;
                OnMultiplayer onmulti = new OnMultiplayer();
                onmulti.ShowDialog();
                this.Close();
            }
            if (comboBoxMap.Text == "" && Ready == false)
                Err2.Visible = true;
        }
    }
}
