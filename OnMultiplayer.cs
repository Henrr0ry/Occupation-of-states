using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Occupation_of_states
{
    public partial class OnMultiplayer : Form
    {
        public OnMultiplayer()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            MyIPbox.Text = GetLocalIP();
        }
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "?";
        }
        int ZoomPicture = 1;
        int MapDrawX = 0;
        int MapDrawY = 0;
        bool MapMove = false;
        int MouseX, MouseY;
        public static int Money1 = 10000;
        public static int Money2 = 10000;
        public static int PlayerPopulation1;
        public static int PlayerPopulation2;
        public static int Farm1 = 10, Farm2 = 10, Mine1 = 10, Mine2 = 10;
        public static int Food1 = 10000, Food2 = 10000, Iron1 = 10000, Iron2 = 10000;
        public static string Name1, Name2, StartS1, StartS2;
        public static int Scientist1, Scientist2, player1XP, player2XP;
        int StateFocusNum = 0;
        bool ready = false;
        public static int AtMarrine1 = 100, AtTank1 = 0, AtPlane1 = 0, DeMarrine1 = 0, DeTank1 = 0, DePlane1 = 0;
        public static int AtMarrine2 = 100, AtTank2 = 0, AtPlane2 = 0, DeMarrine2 = 0, DeTank2 = 0, DePlane2 = 0;
        public static int AtMarrine1lvl = 1, AtTank1lvl = 0, AtPlane1lvl = 0, DeMarrine1lvl = 1, DeTank1lvl = 0, DePlane1lvl = 0, FFarm1lvl = 1, FLab1lvl = 1, FMine1lvl = 1, SNuke1lvl = 0, SHacker1lvl = 0;
        public static int AtMarrine2lvl = 1, AtTank2lvl = 0, AtPlane2lvl = 0, DeMarrine2lvl = 1, DeTank2lvl = 0, DePlane2lvl = 0, FFarm2lvl = 1, FLab2lvl = 1, FMine2lvl = 1, SNuke2lvl = 0, SHacker2lvl = 0;
        public static int Hacker1 = 0, Hacker2 = 0, Nuke1 = 0, Nuke2 = 0;
        public static bool TurnFirst = true;
        int LevelPaint;
        int Taxes1 = 1, Taxes2 = 1;
        Random Rand = new Random();
        int EventNum = 0;
        int CityLvl1 = 1, CityLvl2 = 1;
        public static int Feel1 = 5, Feel2 = 5;
        public static string MoneySign = null, MapPath = null, FlagPath = null, NameMap = null;
        public static dynamic DataPath = null, FolderPath = null, FullPath = null;

        public void UpdateView()
        {
            Money1Box.Text = Convert.ToString(Money1) + MoneySign;
            Money2Box.Text = Convert.ToString(Money2) + MoneySign;
            InventoryBox1.Text = "Population: " + PlayerPopulation1 + Environment.NewLine + "Scientlis: " + Scientist1 + Environment.NewLine + "Mine: " + Mine1 + Environment.NewLine +
                "Farm: " + Farm1 + Environment.NewLine + "Marrine: " + AtMarrine1 + Environment.NewLine + "Tank: " + AtTank1 + Environment.NewLine +
                "Fly fither: " + AtPlane1 + Environment.NewLine + "Defensive marine: " + DeMarrine1 + Environment.NewLine + "Bomb Mine: " + DeTank1 + Environment.NewLine +
                "Antillary: " + DePlane1 + Environment.NewLine + "Iron: " + Iron1 + Environment.NewLine + "Food: " + Food1 + Environment.NewLine + "XP: " + player1XP +
                Environment.NewLine + "Hacker: " + Hacker1 + Environment.NewLine + "Nuke: " + Nuke1;
            InventoryBox2.Text = "Population: " + PlayerPopulation2 + Environment.NewLine + "Scientlis: " + Scientist2 + Environment.NewLine + "Mine: " + Mine2 + Environment.NewLine +
                "Farm: " + Farm2 + Environment.NewLine + "Marrine: " + AtMarrine2 + Environment.NewLine + "Tank: " + AtTank2 + Environment.NewLine +
                "Fly fither: " + AtPlane2 + Environment.NewLine + "Defensive marine: " + DeMarrine2 + Environment.NewLine + "Bomb Mine: " + DeTank2 + Environment.NewLine +
                "Antillary: " + DePlane2 + Environment.NewLine + "Iron: " + Iron2 + Environment.NewLine + "Food: " + Food2 + Environment.NewLine + "XP: " + player2XP +
                Environment.NewLine + "Hacker: " + Hacker2 + Environment.NewLine + "Nuke: " + Nuke2;
        }

        public void ChangeTurn()
        {
            ControlPanel.Visible = false;
            AttackPanel.Visible = false;
            BuyPanel.Visible = false;
            ResearchPanel.Visible = false;
            HomePanel.Visible = false;
            ErrLabel1.Visible = false;
            ErrLabel2.Visible = false;
            ErrLabel3.Visible = false;
            ErrLabel4.Visible = false;
            ErrLabel5.Visible = false;
            EventNum = Rand.Next(0, 7);
            if (TurnFirst == true)
            {
                TurnFirst = false;
                TurnPanel.Image = Properties.Resources.Turn2_0;
                TurnLabel.Text = Name2 + " Turn";
                TurnLabel.BackColor = Color.Red;
                ControlPanel.BackColor = Color.Red;
                StrSend = "yourturn";
                SendData();
            }
            else
            {
                StrSend = "myturn";
                SendData();
                TurnFirst = true;
                ControlPanel.Visible = false;
                TurnPanel.Image = Properties.Resources.Turn1_0;
                TurnLabel.Text = Name1 + " Turn";
                TurnLabel.BackColor = Color.DeepSkyBlue;
                ControlPanel.BackColor = Color.DeepSkyBlue;
                Iron1 += Mine1 * 10 * FMine1lvl;
                Food1 += Farm1 * 10 * FFarm1lvl;
                Food1 -= PlayerPopulation1;
                Money1 += (PlayerPopulation1 * Taxes1) / 10000;
                player1XP += Scientist1 * 10;
                AddIron.Text = "+ " + Mine1 * 10 * FMine1lvl + " Irons";
                AddFood.Text = "+ " + ((Farm1 * 10 * FFarm1lvl) - PlayerPopulation1) + " Foods";
                AddMoney.Text = "+ " + (PlayerPopulation1 * Taxes1) / 10000 + " Money";
                AddXP.Text = "+ " + Scientist1 * 10 + " XP";
                if (Food1 <= -1)
                {
                    ErrLabel5.Visible = true;
                    Feel1--;
                }
                else
                    Feel1++;
                if (Feel1 > 5)
                    Feel1 = 5;
                if (player1XP > 10000)
                    player1XP = 10000;
                if (EventNum <= 1)
                {
                    EventBox.BackgroundImage = Properties.Resources.Event1;
                    AddEvent.Text = "Nothing special, just another day";
                }
                if (EventNum == 2)
                {
                    EventBox.BackgroundImage = Properties.Resources.Event2;
                    AddEvent.Text = "Tornado destroy your farm field -1000 food";
                    Food1 -= 1000;
                }
                if (EventNum == 3)
                {
                    EventBox.BackgroundImage = Properties.Resources.Event3;
                    AddEvent.Text = "Your sientist do random discovery +50 xp";
                    player1XP += 50;
                }
                if (EventNum == 4)
                {
                    EventBox.BackgroundImage = Properties.Resources.Event4;
                    AddEvent.Text = "Someone do bank robbery - 20 000 money";
                    Money1 -= 20000;
                }
                if (EventNum == 5)
                {
                    EventBox.BackgroundImage = Properties.Resources.Event5;
                    AddEvent.Text = "Your Army was found +50 Marrine";
                    player1XP += 500;
                }
                if (EventNum == 6)
                {
                    EventBox.BackgroundImage = Properties.Resources.Event6;
                    AddEvent.Text = "Your factory was destroyed -1000 irons";
                    Iron1 -= 1000;
                }
            }
            if(Feel1 < 0)
            {
                VLabel.Text = Name2;
                DLabel.Text = Name1;
                EndPanel.Visible = true;
                ControlPanel.Visible = false;
                EndPanel.BackColor = Color.Red;
                StrSend = "youwin";
                SendData();
            }
        }

        //STATES DESCRIPTION DATABASE    
        public static string[] NameState = new string[41];
        public static int[] Population = new int[41];
        public static string[] CapitalCity = new string[41];
        public static int[] IronMine = new int[41];
        public static int[] FoodsProduction = new int[41];
        public static bool[] OccuState1 = new bool[41];
        public static bool[] OccuState2 = new bool[41];
        public static Point[] StatePoint = new Point[41];
        public static bool[] StateDestroy = new bool[41];
        public static int LongInt = 10;

        private void ChatBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    ChatHistory.SelectionColor = Color.Blue;
                    ChatHistory.SelectedText += Name1 + "> " + ChatBox.Text + Environment.NewLine;
                    StrSend = "m-" + ChatBox.Text;
                    SendData();
                    ChatBox.Text = null;
                    break;
            }
        }

        public static void CreateStateDescription()
        {
            String word = "1";
            int i = 0;
            char c;
            int phase = 0;
            int X = 0, Y = 0;
            try
            {
                StreamReader reader = new StreamReader(FullPath);
                do
                {
                    for (; phase < 5;)
                    {
                        c = Convert.ToChar(reader.Read());
                        word += c;
                        if (phase == 0 && c != '|')
                            NameMap = word;
                        if (phase == 1 && c != '|')
                            MapPath = word;
                        if (phase == 2 && c != '|')
                            FlagPath = word;
                        if (phase == 3 && c != '|')
                        {
                            LongInt = Convert.ToInt32(word);
                            NameState = new string[LongInt];
                            Population = new int[LongInt];
                            CapitalCity = new string[LongInt];
                            IronMine = new int[LongInt];
                            FoodsProduction = new int[LongInt];
                            OccuState1 = new bool[LongInt];
                            OccuState2 = new bool[LongInt];
                            StatePoint = new Point[LongInt];
                            StateDestroy = new bool[LongInt];
                        }
                        if (phase == 4 && c != '|')
                            MoneySign = word;
                        if (c == '|')
                        {
                            phase++;
                            word = null;
                        }
                    }
                    c = Convert.ToChar(reader.Read());
                    //NAME
                    if (c != '-' && phase == 5 && c != '|' && c != '/')
                    {
                        word += c;
                        NameState[i] = word;
                    }
                    else if (phase == 5)
                    {
                        i++;
                        word = null;
                    }
                    //POPULATION
                    if (c != '-' && phase == 6 && c != '|' && c != '/')
                    {
                        word += c;
                        Population[i] = Convert.ToInt32(word);
                    }
                    else if (phase == 6)
                    {
                        i++;
                        word = null;
                    }
                    //CAPITAL CITY
                    if (c != '-' && phase == 7 && c != '|' && c != '/')
                    {
                        word += c;
                        CapitalCity[i] = word;
                    }
                    else if (phase == 7)
                    {
                        i++;
                        word = null;
                    }
                    //MINE
                    if (c != '-' && phase == 8 && c != '|' && c != '/')
                    {
                        word += c;
                        IronMine[i] = Convert.ToInt32(word);
                    }
                    else if (phase == 8)
                    {
                        i++;
                        word = null;
                    }
                    //FOOD PRODUCTION
                    if (c != '-' && phase == 9 && c != '|' && c != '/')
                    {
                        word += c;
                        FoodsProduction[i] = Convert.ToInt32(word);
                    }
                    else if (phase == 9)
                    {
                        i++;
                        word = null;
                    }
                    //STATE POINT
                    if (c != '-' && phase == 10 && c != '|' && c != '/')//{X=755,Y=530}
                    {
                        word += c;
                        if (word == "{X=")
                        {
                            word = null;
                            for (; c != ',';)
                            {
                                c = Convert.ToChar(reader.Read());
                                if (c != ',')
                                    word += c;
                            }
                            X = Convert.ToInt32(word);
                            word = null;
                        }
                        if (word == "Y=")
                        {
                            word = null;
                            for (; c != '}';)
                            {
                                c = Convert.ToChar(reader.Read());
                                if (c != '}')
                                    word += c;
                            }
                            Y = Convert.ToInt32(word);
                            word = null;
                            StatePoint[i] = new Point(X, Y);
                        }
                    }
                    else if (phase == 10)
                    {
                        i++;
                        word = null;
                    }
                    //PHASE CHANGE
                    if (c == '|')
                    {
                        phase++;
                        i = 0;
                        word = null;
                    }
                } while (c != '/' && i < LongInt * 2);

                for (int a = 0; a < LongInt; a++)
                {
                    OccuState1[a] = false;
                    OccuState2[a] = false;
                    StateDestroy[a] = false;
                }
            }
            catch
            {
                MessageBox.Show("Map file is corrupted! " + FullPath, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        //END OF STATES DESCRIPTION DATABASE
        private void MainMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.Europe_Map1, MapDrawX, MapDrawY, Properties.Resources.Europe_Map1.Width * ZoomPicture, Properties.Resources.Europe_Map1.Height * ZoomPicture);

            //x is Label && x.Top >= Cursor.Position.Y - 40 - MainMap.Top && x.Top <= Cursor.Position.Y + 25 - MainMap.Top && x.Left >= Cursor.Position.X - 100 - MainMap.Left && x.Left <= Cursor.Position.X + 2 - MainMap.Left
            Point Bod1 = new Point(Cursor.Position.Y - 40 - MainMap.Top, Cursor.Position.X - 100 - MainMap.Left);
            Point Bod2 = new Point(Cursor.Position.Y + 25 - MainMap.Top, Cursor.Position.X + 2 - MainMap.Left);
            kp.DrawRectangle(Pens.Blue, Cursor.Position.X - 100 - MainMap.Left, Cursor.Position.Y - 50 - MainMap.Top, Cursor.Position.X + 2 - MainMap.Left - (Cursor.Position.X - 100 - MainMap.Left), Cursor.Position.Y + 10 - MainMap.Top - (Cursor.Position.Y - 40 - MainMap.Top));
        }

        private void comboBoxState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartS1 = comboBoxState1.Text;
        }

        public void EuropeMap_Load(object sender, EventArgs e)
        {
            if (MainSettings.Default.FullScreen == true)
                this.FormBorderStyle = FormBorderStyle.None;
            else
                this.FormBorderStyle = FormBorderStyle.Sizable;


            Name1 = UsersSettings.Default.Name1;
            NameBox1.Text = Name1;
            StartS1 = UsersSettings.Default.StartState1;
            //
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
            }
            catch
            {
                LogoBox1.Image = Properties.Resources.Icon1;
            }
            UpdateView();
            // multiplayer
            if (MainSettings.Default.LobbyCreate == true)
            {
                MyPortbox.Text = "23";
                CoPortbox.Text = "30";
                PanelLabel.Text = "Created Lobby";
                FullPath = Application.StartupPath + MainSettings.Default.LoadPathText;
                char c = '1';
                int phase = 0;
                word = null;
                for (int i = 0;i < MainSettings.Default.LoadPathText.Length;i++)
                {
                    c = Convert.ToChar(MainSettings.Default.LoadPathText[i]);
                    if (phase == 1 && c != Path.DirectorySeparatorChar)
                    {
                        FolderPath += Convert.ToString(c);
                    }
                    else if (phase == 2 && c != Path.DirectorySeparatorChar)
                    {
                        DataPath += Convert.ToString(c);
                        word = null;
                    }
                    if (c == Path.DirectorySeparatorChar)
                        phase++;
                   // MessageBox.Show("i= " + i + "c=" + c + " phase=" + phase + Environment.NewLine + FolderPath + DataPath);
                } 
            }
            else
            {
                MainSettings.Default.LoadPathText = null;
                StartS1 = null;
                MyPortbox.Text = "30";
                CoPortbox.Text = "23";
                PanelLabel.Text = "Join Lobby";
                BtnReady.Text = "Try Join";
                labelState.Visible = true;
                comboBoxState1.Visible = true;
            }
            CityBox1.Text = StartS1;
            Name2 = null;
            StartS2 = null;
        }

        private void Attack_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
            AttackPanel.Visible = true;
            Atbox.Text = NameState[StateFocusNum];
            this.tabControl2.SelectedTab = this.tabPage5;
                AtMarrineBox.Maximum = AtMarrine1;
                AtTankBox.Maximum = AtTank1;
                AtPlaneBox.Maximum = AtPlane1;
                if (Nuke1 > 0)
                {
                    RedbtnBox.Image = Properties.Resources.RedBtn1;
                    RedbtnBox.Enabled = true;
                    Atbox2.Enabled = true;
                }
                else
                {
                    RedbtnBox.Image = Properties.Resources.RedBtn0;
                    RedbtnBox.Enabled = false;
                    Atbox2.Enabled = false;
                }
                if (Hacker1 > 0)
                {
                    LaptopBox.Image = Properties.Resources.Laptop1;
                    LaptopBox.Enabled = true;
                }
                else
                {
                    LaptopBox.Image = Properties.Resources.Laptop0;
                    LaptopBox.Enabled = false;
                }
            
        }

        private void BtnControlResearch_Click(object sender, EventArgs e)
        {
            SpecialNbox.BackgroundImage = Properties.Resources.LVLempty;
            SpecialHbox.BackgroundImage = Properties.Resources.LVLempty;
            Image Full = Properties.Resources.LVLfull;
            ResearchPanel.Visible = true;

                if (player1XP <= 10000)
                progressBar1.Value = player1XP;
                XPlabel.Text = player1XP + " XP";
                if (AtMarrine1lvl > 1)
                    AttackM2box.BackgroundImage = Full;
                if (AtMarrine1lvl > 2)
                    AttackM3box.BackgroundImage = Full;
                if (AtTank1lvl > 0)
                    AttackT1box.BackgroundImage = Full;
                if (AtTank1lvl > 1)
                    AttackT2box.BackgroundImage = Full;
                if (AtTank1lvl > 2)
                    AttackT3box.BackgroundImage = Full;
                if (AtPlane1lvl > 0)
                    AttackP1box.BackgroundImage = Full;
                if (AtPlane1lvl > 1)
                    AttackP2box.BackgroundImage = Full;
                if (AtPlane1lvl > 2)
                    AttackP3box.BackgroundImage = Full;
                if (DeMarrine1lvl > 1)
                    DefendeM2box.BackgroundImage = Full;
                if (DeMarrine1lvl > 2)
                    DefendeM3box.BackgroundImage = Full;
                if (DeTank1lvl > 0)
                    DefendeT1box.BackgroundImage = Full;
                if (DeTank1lvl > 1)
                    DefendeT2box.BackgroundImage = Full;
                if (DeTank1lvl > 2)
                    DefendeT3box.BackgroundImage = Full;
                if (DePlane1lvl > 0)
                    DefendeP1box.BackgroundImage = Full;
                if (DePlane1lvl > 1)
                    DefendeP2box.BackgroundImage = Full;
                if (DePlane1lvl > 2)
                    DefendeP3box.BackgroundImage = Full;
                if (FFarm1lvl > 1)
                    FarmF2box.BackgroundImage = Full;
                if (FFarm1lvl > 2)
                    FarmF3box.BackgroundImage = Full;
                if (FLab1lvl > 1)
                    FarmL2box.BackgroundImage = Full;
                if (FLab1lvl > 2)
                    FarmL3box.BackgroundImage = Full;
                if (FMine1lvl > 1)
                    FarmM2box.BackgroundImage = Full;
                if (FMine1lvl > 2)
                    FarmM3box.BackgroundImage = Full;
                if (SNuke1lvl > 0)
                    SpecialNbox.BackgroundImage = Full;
                if (SHacker1lvl > 0)
                    SpecialHbox.BackgroundImage = Full;
            
        }

        private void UpgradeBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;

                if (UpgradeBox.Tag == "A1")
                    LevelPaint = AtMarrine1lvl;
                if (UpgradeBox.Tag == "A2")
                    LevelPaint = AtTank1lvl;
                if (UpgradeBox.Tag == "A3")
                    LevelPaint = AtPlane1lvl;
                if (UpgradeBox.Tag == "D1")
                    LevelPaint = DeMarrine1lvl;
                if (UpgradeBox.Tag == "D2")
                    LevelPaint = DeTank1lvl;
                if (UpgradeBox.Tag == "D3")
                    LevelPaint = DePlane1lvl;
                if (UpgradeBox.Tag == "F1")
                    LevelPaint = FFarm1lvl;
                if (UpgradeBox.Tag == "F2")
                    LevelPaint = FLab1lvl;
                if (UpgradeBox.Tag == "F3")
                    LevelPaint = FMine1lvl;
                if (UpgradeBox.Tag == "N")
                    LevelPaint = SNuke1lvl;
                if (UpgradeBox.Tag == "H")
                    LevelPaint = SHacker1lvl;
            
            if (LevelPaint == 1)
                kp.DrawImage(Properties.Resources.LVL1, 0, 0);
            if (LevelPaint == 2)
                kp.DrawImage(Properties.Resources.LVL2, 0, 0);
            if (LevelPaint == 3)
                kp.DrawImage(Properties.Resources.LVL3, 0, 0);
        }

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {

                if (UpgradeBox.Tag == "A1" && AtMarrine1lvl < 3 && player1XP >= 1000)
                {
                    player1XP -= 1000;
                    AtMarrine1lvl++;
                }
                else
                if (UpgradeBox.Tag == "A2" && AtTank1lvl < 3 && player1XP >= 6000)
                {
                    player1XP -= 6000;
                    AtTank1lvl++;
                }
                else
                if (UpgradeBox.Tag == "A3" && AtPlane1lvl < 3 && player1XP >= 5000)
                {
                    player1XP -= 5000;
                    AtPlane1lvl++;
                }
                else
                if (UpgradeBox.Tag == "D1" && DeMarrine1lvl < 3 && player1XP >= 1000)
                {
                    player1XP -= 1000;
                    DeMarrine1lvl++;
                }
                else
                if (UpgradeBox.Tag == "D2" && DeTank1lvl < 3 && player1XP >= 5000)
                {
                    player1XP -= 5000;
                    DeTank1lvl++;
                }
                else
                if (UpgradeBox.Tag == "D3" && DePlane1lvl < 3 && player1XP >= 4500)
                {
                    player1XP -= 4500;
                    DePlane1lvl++;
                }
                else
                if (UpgradeBox.Tag == "F1" && FLab1lvl < 3 && player1XP >= 4000)
                {
                    player1XP -= 8000;
                    FLab1lvl++;
                }
                else
                if (UpgradeBox.Tag == "F2" && FFarm1lvl < 3 && player1XP >= 2500)
                {
                    player1XP -= 2500;
                    FFarm1lvl++;
                }
                else
                if (UpgradeBox.Tag == "F3" && FMine1lvl < 3 && player1XP >= 2500)
                {
                    player1XP -= 2500;
                    FMine1lvl++;
                }
                else
                if (UpgradeBox.Tag == "N" && SNuke1lvl < 1 && player1XP >= 8000)
                {
                    player1XP -= 8000;
                    SNuke1lvl++;
                }
                else
                if (UpgradeBox.Tag == "H" && SHacker1lvl < 1 && player1XP >= 5000)
                {
                    player1XP -= 5000;
                    SHacker1lvl++;
                }
                else
                {
                    ErrLabel4.Visible = true;
                    return;
                }
            Image Empty = Properties.Resources.LVLempty;
            AttackM2box.BackgroundImage = Empty;
            AttackM3box.BackgroundImage = Empty;
            AttackT1box.BackgroundImage = Empty;
            AttackT2box.BackgroundImage = Empty;
            AttackT3box.BackgroundImage = Empty;
            AttackP1box.BackgroundImage = Empty;
            AttackP2box.BackgroundImage = Empty;
            AttackP3box.BackgroundImage = Empty;
            DefendeM2box.BackgroundImage = Empty;
            DefendeM3box.BackgroundImage = Empty;
            DefendeT1box.BackgroundImage = Empty;
            DefendeT2box.BackgroundImage = Empty;
            DefendeT3box.BackgroundImage = Empty;
            DefendeP1box.BackgroundImage = Empty;
            DefendeP2box.BackgroundImage = Empty;
            DefendeP3box.BackgroundImage = Empty;
            FarmF2box.BackgroundImage = Empty;
            FarmF3box.BackgroundImage = Empty;
            FarmL2box.BackgroundImage = Empty;
            FarmL3box.BackgroundImage = Empty;
            FarmM2box.BackgroundImage = Empty;
            FarmM3box.BackgroundImage = Empty;
            SpecialNbox.BackgroundImage = Empty;
            SpecialHbox.BackgroundImage = Empty;
            StrSend = "yourturn";
            SendData();
            UpdateView();
        }

        private void SetUpgrade1_Click(object sender, EventArgs e)
        {
            foreach (Control x in tabPage1.Controls)
            {
                if (x is PictureBox && x.Top <= Cursor.Position.Y - ResearchPanel.Top - 156 && x.Top >= Cursor.Position.Y - 80 - ResearchPanel.Top - 156 && x.Left >= Cursor.Position.X - 80 - ResearchPanel.Left - 25 && x.Left <= Cursor.Position.X + 40 - ResearchPanel.Left - 25)
                {
                    UpgradeBox.BackgroundImage = x.BackgroundImage;
                    if (x.Tag == "A1")
                        UpgradeBox.Image = Properties.Resources.LVLMarine;
                    if (x.Tag == "A2")
                        UpgradeBox.Image = Properties.Resources.LVLTank;
                    if (x.Tag == "A3")
                        UpgradeBox.Image = Properties.Resources.LVLPlane;
                    x.Invalidate();
                    UpgradeBox.Tag = null;
                    UpgradeBox.Tag = x.Tag;
                }
            }
            UpgradeBox.Refresh();
        }
        private void SetUpgrade2_Click(object sender, EventArgs e)
        {
            foreach (Control x in tabPage2.Controls)
            {
                if (x is PictureBox && x.Top <= Cursor.Position.Y - ResearchPanel.Top - 156 && x.Top >= Cursor.Position.Y - 80 - ResearchPanel.Top - 156 && x.Left >= Cursor.Position.X - 80 - ResearchPanel.Left - 25 && x.Left <= Cursor.Position.X + 40 - ResearchPanel.Left - 25)
                {
                    UpgradeBox.BackgroundImage = x.BackgroundImage;
                    if (x.Tag == "D1")
                        UpgradeBox.Image = Properties.Resources.LVLDefender;
                    if (x.Tag == "D2")
                        UpgradeBox.Image = Properties.Resources.LVLBomb;
                    if (x.Tag == "D3")
                        UpgradeBox.Image = Properties.Resources.LVLAntillery;
                    x.Invalidate();
                    UpgradeBox.Tag = null;
                    UpgradeBox.Tag = x.Tag;
                }
            }
            UpgradeBox.Refresh();
        }
        private void SetUpgrade3_Click(object sender, EventArgs e)
        {
            foreach (Control x in tabPage3.Controls)
            {
                if (x is PictureBox && x.Top <= Cursor.Position.Y - ResearchPanel.Top - 156 && x.Top >= Cursor.Position.Y - 80 - ResearchPanel.Top - 156 && x.Left >= Cursor.Position.X - 80 - ResearchPanel.Left - 25 && x.Left <= Cursor.Position.X + 40 - ResearchPanel.Left - 25)
                {
                    UpgradeBox.BackgroundImage = x.BackgroundImage;
                    if (x.Tag == "F1")
                        UpgradeBox.Image = Properties.Resources.LVLLab;
                    if (x.Tag == "F2")
                        UpgradeBox.Image = Properties.Resources.LVLFarm;
                    if (x.Tag == "F3")
                        UpgradeBox.Image = Properties.Resources.LVLMine;
                    x.Invalidate();
                    UpgradeBox.Tag = null;
                    UpgradeBox.Tag = x.Tag;
                }
            }
            UpgradeBox.Refresh();
        }

        private void SpecialNbox_Click(object sender, EventArgs e)
        {
            UpgradeBox.BackgroundImage = SpecialNbox.BackgroundImage;
            UpgradeBox.Image = Properties.Resources.LVLNuke;
            UpgradeBox.Tag = "N";
            UpgradeBox.Refresh();
        }

        private void SpecialHbox_Click(object sender, EventArgs e)
        {
            UpgradeBox.BackgroundImage = SpecialHbox.BackgroundImage;
            UpgradeBox.Image = Properties.Resources.LVLHacker;
            UpgradeBox.Tag = "H";
            UpgradeBox.Refresh();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = false;
            AttackPanel.Visible = false;
            BuyPanel.Visible = false;
            ResearchPanel.Visible = false;
            ControlPanel.Visible = true;
        }
        bool doone = false;
        private void LaptopBox_Click(object sender, EventArgs e)
        {
            if (doone == false)
            {
                doone = true;
                LaptopBox.Image = Properties.Resources.Laptop2;
                LaptopBox.Refresh();
                BtnLeave01.Enabled = false;
                HackerTimer.Start();
            }
        }

        private void HackerTimer_Tick(object sender, EventArgs e)
        {
                Hacker1--;
                EnemyInventory.Visible = false;
            EndTurn();
            UpdateView();
            HackerTimer.Stop();
            doone = false;
        }

        private void RedbtnBox_Click(object sender, EventArgs e)
        {
            if (Atbox2.Text != "")
            {
                ErrLabel7.Visible = false;
                if (RedbtnBox.Tag == "2")
                {
                    RedbtnBox.Enabled = false;
                    RedbtnBox.Image = Properties.Resources.RedBtn3;
                    NukeTimer.Start();
                }
                else
                {
                    RedbtnBox.Tag = "2";
                    RedbtnBox.Image = Properties.Resources.RedBtn2;
                }
            }
            else
                ErrLabel7.Visible = true;
        }
        private void NukeTimer_Tick(object sender, EventArgs e)
        {
            NukeTimer.Stop();
            RedbtnBox.Tag = null;
            for (int a = 0; a < LongInt; a++)
            {
                if (NameState[a] == Atbox2.Text)
                    StateFocusNum = a;
            }
            Bitmap bm = (Bitmap)MainMap.BackgroundImage;
            new FillColorClass().FloodFill(ref bm, Color.DimGray, StatePoint[StateFocusNum]);
            MainMap.BackgroundImage = bm;
            StrSend = "nukedstate-" + StateFocusNum;
            SendData();
            if (OccuState1[StateFocusNum] == true)
            {
                PlayerPopulation1 -= Population[StateFocusNum];
                Mine1 -= IronMine[StateFocusNum];
                Farm1 -= FoodsProduction[StateFocusNum];
                OccuState1[StateFocusNum] = false;
            }
            if (OccuState2[StateFocusNum] == true)
            {
                PlayerPopulation1 += Population[StateFocusNum];
                Mine1 += IronMine[StateFocusNum];
                Farm1 += FoodsProduction[StateFocusNum];
                OccuState2[StateFocusNum] = false;
            }
            if (NameState[StateFocusNum] == StartS1)
            {
                VLabel.Text = Name2;
                DLabel.Text = Name1;
                EndPanel.Visible = true;
                ControlPanel.Visible = false;
                BuyPanel.Visible = false;
                AttackPanel.Visible = false;
                ResearchPanel.Visible = false;
                HomePanel.Visible = false;
                EndPanel.BackColor = Color.Red;
            }
            else
            if (NameState[StateFocusNum] == StartS2)
            {
                VLabel.Text = Name1;
                DLabel.Text = Name2;
                EndPanel.Visible = true;
                ControlPanel.Visible = false;
                ControlPanel.Visible = false;
                BuyPanel.Visible = false;
                AttackPanel.Visible = false;
                ResearchPanel.Visible = false;
                HomePanel.Visible = false;
                EndPanel.BackColor = Color.Blue;
            }
            else
            {
                StateDestroy[StateFocusNum] = true;
                EndTurn();
                UpdateView(); 
            }
        }

        private void EuropeMap_SizeChanged(object sender, EventArgs e)
        {
            TurnPanel.Left = (this.Width / 2) - (TurnPanel.Width / 2);
            TurnLabel.Left = (this.Width / 2) - (TurnLabel.Width / 2);

            PanelPlayer1.Top = this.Height - 350;
            PanelPlayer2.Top = this.Height - 350;
            PanelPlayer2.Left = this.Width - 460;
            StatesDescriptionsBox.Left = this.Width - 460;
            if (this.Height <= 500)
                this.Height = 500;
            if (this.Width <= 1000)
                this.Width = 1000;

            ControlPanel.Left = (this.Width / 2) - (ControlPanel.Width / 2);
            ControlPanel.Top = (this.Height / 2) - (ControlPanel.Height / 2);
            BuyPanel.Left = (this.Width / 2) - (BuyPanel.Width / 2);
            BuyPanel.Top = (this.Height / 2) - (BuyPanel.Height / 2);
            AttackPanel.Left = (this.Width / 2) - (AttackPanel.Width / 2);
            AttackPanel.Top = (this.Height / 2) - (AttackPanel.Height / 2);
            ResearchPanel.Left = (this.Width / 2) - (ResearchPanel.Width / 2);
            ResearchPanel.Top = (this.Height / 2) - (ResearchPanel.Height / 2);
            HomePanel.Left = (this.Width / 2) - (HomePanel.Width / 2);
            HomePanel.Top = (this.Height / 2) - (HomePanel.Height / 2);
            EndPanel.Left = (this.Width / 2) - (EndPanel.Width / 2);
            EndPanel.Top = (this.Height / 2) - (EndPanel.Height / 2);
            PauseMenu.Left = (this.Width / 2) - (PauseMenu.Width / 2);
            PauseMenu.Top = (this.Height / 2) - (PauseMenu.Height / 2);

            ChatPanel.Top = this.Height - 650;
            panelConnect.Left = (this.Width / 2) - (panelConnect.Width / 2);
            panelConnect.Top = (this.Height / 2) - (panelConnect.Height / 2);
        }

        private void EuropeMap_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    MessageBox.Show("Move: " + MapMove + "MouseX: " + MouseX + Environment.NewLine + "CursorY: " + Cursor.Position.Y + "CursorX: " + Cursor.Position.X);
                    break;
                case Keys.F11:
                    if (MainSettings.Default.FullScreen == false)
                    {
                        MainSettings.Default.FullScreen = true;
                        MainSettings.Default.Save();
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        MainSettings.Default.FullScreen = false;
                        MainSettings.Default.Save();
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                        this.WindowState = FormWindowState.Maximized;
                    }
                    break;
                case Keys.F5:
                    if (MainSettings.Default.CMDmultiON == true)
                    {
                        CommandPrompt cmd = new CommandPrompt();
                        cmd.Show();
                    }
                    else
                        MessageBox.Show("CMD IS SET OFFLINE!", "OCCUPAION OF STATES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Keys.F2:
                    MainMap.Refresh();
                    break;
                case Keys.Escape:
                    PauseMenu.Visible = true;
                    break;
            }
        }

        private void LogoState_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            Image flag = Image.FromFile(Application.StartupPath + FlagPath);
            kp.DrawImage(flag, (StateFocusNum * -85),0,flag.Width,57);
        }
        private void StateLabel_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (TurnFirst == true)
                    foreach (Control x in MainMap.Controls)
                    {
                        //x is Label && x.Top >= Cursor.Position.Y - 40 && x.Top <= Cursor.Position.Y + 40 && x.Left >= Cursor.Position.X - x.Width && x.Left <= Cursor.Position.X + x.Width
                        //x is Label && FocusBox.Bounds.IntersectsWith(x.Bounds)
                        if (x is Label && x.Top >= Cursor.Position.Y - 50 - MainMap.Top && x.Top <= Cursor.Position.Y + 10 - MainMap.Top && x.Left >= Cursor.Position.X - 100 - MainMap.Left && x.Left <= Cursor.Position.X + 2 - MainMap.Left)
                        {
                            StateFocusNum = Convert.ToInt32(x.Tag);
                            MainMap.Tag = x.Tag;
                            StatesDescriptionsBox.Visible = true;
                            StateNameBox.Text = NameState[StateFocusNum];
                            DescriptionBox.Text = "Capital city: " + CapitalCity[StateFocusNum] + Environment.NewLine + "State population: " + Population[StateFocusNum] + Environment.NewLine
                                + "Farming: " + FoodsProduction[StateFocusNum] + Environment.NewLine + "Mining: " + IronMine[StateFocusNum];
                            LogoState.Refresh();
                        }
                    }
            }
            catch { }
        }

        private void StateLabel_MouseLeave(object sender, EventArgs e)
        {
            StatesDescriptionsBox.Visible = false;
        }

        private void btnMidle_Click(object sender, EventArgs e)
        {
            MainMap.Left = 0;
            MainMap.Top = 0;
        }

        private void LVL1_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.LVL1, 0, 0);
        }

        private void LVL2_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.LVL2, 0, 0);
        }

        private void LVL3_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            kp.DrawImage(Properties.Resources.LVL3, 0, 0);
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    MapMove = true;
                    Cursor = Cursors.SizeAll;
                        break;
            }     
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    MapMove = false;
                    Cursor = Cursors.Arrow;
                    break;
            }
        }


        private void MapMoveTimer1_Tick(object sender, EventArgs e)
        {
            if (MapMove == true)
            {
            MouseX =  Cursor.Position.X;
            MouseY =  Cursor.Position.Y;
            }
            else
            {
                MouseX = 0;
                MouseY = 0;
            }
            System.Threading.Thread.Sleep(10);
            if (MapMove == true)
            {
                MainMap.Left += Cursor.Position.X - MouseX;
                MainMap.Top += Cursor.Position.Y - MouseY;
            }
            else
            {
                MouseX = 0;
                MouseY = 0;
            }
        }

        private void BtnControlAttack_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
            AttackPanel.Visible = true;
            this.tabControl2.SelectedTab = this.tabPage5;
                AtMarrineBox.Maximum = AtMarrine1;
                AtTankBox.Maximum = AtTank1;
                AtPlaneBox.Maximum = AtPlane1;
                if (AtTank1lvl > 0)
                {
                    Box2.BackgroundImage = Properties.Resources.LVLfull;
                    AtTankBox.Enabled = true;
                }
                if (AtPlane1lvl > 0)
                {
                    Box3.BackgroundImage = Properties.Resources.LVLfull;
                    AtPlaneBox.Enabled = true;
                }
                if (Nuke1 > 0)
                {
                    RedbtnBox.Image = Properties.Resources.RedBtn1;
                    RedbtnBox.Enabled = true;
                    Atbox2.Enabled = true;
                }
                else
                {
                    RedbtnBox.Image = Properties.Resources.RedBtn0;
                    RedbtnBox.Enabled = false;
                    Atbox2.Enabled = false;
                }
                if (Hacker1 > 0)
                {
                    LaptopBox.Image = Properties.Resources.Laptop1;
                    LaptopBox.Enabled = true;
                }
                else
                {
                    LaptopBox.Image = Properties.Resources.Laptop0;
                    LaptopBox.Enabled = false;
                }
            
        }
        private void BtnControlBuy_Click(object sender, EventArgs e)
        {
            ControlPanel.Visible = false;
            BuyPanel.Visible = true;

                if (AtTank1lvl > 0)
                {
                    BuyTankbox.BackgroundImage = Properties.Resources.LVLfull;
                    A2Box.Enabled = true;
                }
                if (DeTank1lvl > 0)
                {
                    BuyBombbox.BackgroundImage = Properties.Resources.LVLfull;
                    D2Box.Enabled = true;
                }
                if (AtPlane1lvl > 0)
                {
                    BuyPlanebox.BackgroundImage = Properties.Resources.LVLfull;
                    A3Box.Enabled = true;
                }
                if (DePlane1lvl > 0)
                {
                    buyAntilerybox.BackgroundImage = Properties.Resources.LVLfull;
                    D3Box.Enabled = true;
                }
                if (SHacker1lvl > 0)
                {
                    BuyHackerBox.BackgroundImage = Properties.Resources.LVLfull;
                    SHBox.Enabled = true;
                }
                if (SNuke1lvl > 0)
                {
                    BuyNukeBox.BackgroundImage = Properties.Resources.LVLfull;
                    SNBox.Enabled = true;
                }
            
        }
        private void BtnBuy_Click(object sender, EventArgs e)
        {
            try {
                ready = true;
                    Money1 -= Convert.ToInt32(A1Box.Value * 100 + A2Box.Value * 300 + A3Box.Value * 400 + D1Box.Value * 100 + D2Box.Value * 200 + D3Box.Value * 300 + F1Box.Value * 100 + F2Box.Value * 1000 + F3Box.Value * 200 + SHBox.Value * 50000 + SNBox.Value * 14000);
                    Iron1 -= Convert.ToInt32(A1Box.Value * 5 + A2Box.Value * 100 + A3Box.Value * 80 + D1Box.Value * 10 + D2Box.Value * 30 + D3Box.Value * 80 + F1Box.Value * 30 + F2Box.Value * 100 + F3Box.Value * 100 + SHBox.Value * 20 + SNBox.Value * 120);
                    PlayerPopulation1 -= Convert.ToInt32(A1Box.Value + A2Box.Value * 5 + A3Box.Value * 2 + D1Box.Value + D2Box.Value + D3Box.Value * 5 + F1Box.Value + F2Box.Value + F3Box.Value + SHBox.Value + SNBox.Value * 100);
                    if (Money1 > -1 && Iron1 > -1 && PlayerPopulation1 > -1)
                    {
                        AtMarrine1 += Convert.ToInt32(A1Box.Value);
                        AtTank1 += Convert.ToInt32(A2Box.Value);
                        AtPlane1 += Convert.ToInt32(A3Box.Value);
                        DeMarrine1 += Convert.ToInt32(D1Box.Value);
                        DeTank1 += Convert.ToInt32(D2Box.Value);
                        DePlane1 += Convert.ToInt32(D3Box.Value);
                        Farm1 += Convert.ToInt32(F1Box.Value);
                        Scientist1 += Convert.ToInt32(F2Box.Value);
                        Mine1 += Convert.ToInt32(F3Box.Value);
                        Hacker1 += Convert.ToInt32(SHBox.Value);
                        Nuke1 += Convert.ToInt32(SNBox.Value);
                    }
                    else
                    {
                        Money1 += Convert.ToInt32(A1Box.Value * 100 + A2Box.Value * 300 + A3Box.Value * 400 + D1Box.Value * 100 + D2Box.Value * 200 + D3Box.Value * 300 + F1Box.Value * 100 + F2Box.Value * 1000 + F3Box.Value * 200 + SHBox.Value * 50000 + SNBox.Value * 14000);
                        Iron1 += Convert.ToInt32(A1Box.Value * 5 + A2Box.Value * 100 + A3Box.Value * 80 + D1Box.Value * 10 + D2Box.Value * 30 + D3Box.Value * 80 + F1Box.Value * 30 + F2Box.Value * 100 + F3Box.Value * 100 + SHBox.Value * 20 + SNBox.Value * 120);
                        PlayerPopulation1 += Convert.ToInt32(A1Box.Value + A2Box.Value * 5 + A3Box.Value * 2 + D1Box.Value + D3Box.Value * 5 + F1Box.Value + F2Box.Value + F3Box.Value + SHBox.Value + SNBox.Value * 100);
                        ErrLabel1.Visible = true;
                        ready = false;
                    }
            }
            catch
            {
            }
            if (ready == true)
            {
                BuyTankbox.BackgroundImage = Properties.Resources.LVLempty;
                A2Box.Enabled = false;
                BuyBombbox.BackgroundImage = Properties.Resources.LVLempty;
                D2Box.Enabled = false;
                BuyPlanebox.BackgroundImage = Properties.Resources.LVLempty;
                A3Box.Enabled = false;
                buyAntilerybox.BackgroundImage = Properties.Resources.LVLempty;
                D3Box.Enabled = false;
                BuyHackerBox.BackgroundImage = Properties.Resources.LVLempty;
                SHBox.Enabled = false;
                BuyNukeBox.BackgroundImage = Properties.Resources.LVLempty;
                SNBox.Enabled = false;
                A1Box.Value = 0;
                A2Box.Value = 0;
                A3Box.Value = 0;
                D1Box.Value = 0;
                D2Box.Value = 0;
                D3Box.Value = 0;
                F1Box.Value = 0;
                F2Box.Value = 0;
                F3Box.Value = 0;
                SHBox.Value = 0;
                SNBox.Value = 0;
                EndTurn();
                UpdateView();
            }
        }

        private void BtnControlHome_Click(object sender, EventArgs e)
        {
            HomePanel.Visible = true;
            ControlPanel.Visible = false;

                CityLabel.Text = StartS1;
                CityLvlLabel.Text = Convert.ToString(CityLvl1);
                TaxesBox.Maximum = CityLvl1;
                TaxesBox.Value = Taxes1;
                TaxesLabel.Text = Convert.ToString(Taxes1);
                if (Feel1 == 5)
                    FeelBox.Image = Properties.Resources.Feel5;
                if (Feel1 == 4)
                    FeelBox.Image = Properties.Resources.Feel4;
                if (Feel1 == 3)
                    FeelBox.Image = Properties.Resources.Feel3;
                if (Feel1 == 2)
                    FeelBox.Image = Properties.Resources.Feel2;
                if (Feel1 == 1)
                    FeelBox.Image = Properties.Resources.Feel1;
                CityUpBtn.Text = "Upgrade " + CityLvl1 * 10000 + " irons";
            
        }

        private void TaxesBox_Scroll(object sender, EventArgs e)
        {
                Taxes1 = TaxesBox.Value;
                TaxesLabel.Text = Convert.ToString(Taxes1);
        }

        private void CityUpBtn_Click(object sender, EventArgs e)
        {
            if (Iron1 >= CityLvl1 * 10000)
            {
                Iron1 -= CityLvl1 * 10000;
                CityLvl1++;
                EndTurn();
            }
            else
                ErrLabel6.Visible = true;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (Atbox.Text != "")
            {
                for (int i = 0; i < LongInt; i++)
                {
                    if (NameState[i] == Atbox.Text)
                        StateFocusNum = i;
                }

                    if (OccuState1[StateFocusNum] == true)
                    {
                        ErrLabel3.Visible = true;
                        return;
                    }
                    int ChMarrine = Convert.ToInt32(AtMarrineBox.Value);
                    int ChTank = Convert.ToInt32(AtTankBox.Value);
                    int ChPlane = Convert.ToInt32(AtPlaneBox.Value);
                    int damage = 0;
                    damage += ChMarrine * 10 + ChTank * 100 + ChPlane * 90;
                    AtMarrine1 -= ChMarrine;
                    AtTank1 -= ChTank;
                    AtPlane1 -= ChPlane;
                    int protection = 0;
                    protection += DeMarrine2 * 10 + DeTank2 * 100 + DePlane2 * 90;
                    if (OccuState2[StateFocusNum] == false && StateDestroy[StateFocusNum] == false)
                    {
                        OccuState1[StateFocusNum] = true;
                        PlayerPopulation1 += Population[StateFocusNum];
                        Mine1 += IronMine[StateFocusNum];
                        Farm1 += FoodsProduction[StateFocusNum];
                        Bitmap bm = (Bitmap)MainMap.BackgroundImage;
                        new FillColorClass().FloodFill(ref bm, Color.Blue, StatePoint[StateFocusNum]);
                        MainMap.BackgroundImage = bm;
                        StrSend = "mystate-" + StateFocusNum;
                        SendData();
                    }
                    else
                    if (damage > protection && OccuState2[StateFocusNum] == true && StateDestroy[StateFocusNum] == false)
                    {
                        StrSend = "mystate-" + StateFocusNum;
                        SendData();
                        OccuState2[StateFocusNum] = false;
                        OccuState1[StateFocusNum] = true;
                        DeMarrine2 -= ChMarrine;
                        DeTank2 -= ChTank;
                        DePlane2 -= ChPlane;
                        PlayerPopulation1 += Population[StateFocusNum];
                        Mine1 += IronMine[StateFocusNum];
                        Farm1 += FoodsProduction[StateFocusNum];
                        Bitmap bm = (Bitmap)MainMap.BackgroundImage;
                        new FillColorClass().FloodFill(ref bm, Color.Blue, StatePoint[StateFocusNum]);
                        MainMap.BackgroundImage = bm;
                        PlayerPopulation2 -= Population[StateFocusNum];
                        Mine2 -= IronMine[StateFocusNum];
                        Farm2 -= FoodsProduction[StateFocusNum];
                    }
                    else
                    {
                        MessageBox.Show("you lose");
                    }
                if (NameState[StateFocusNum] == StartS1)
                {
                    VLabel.Text = Name2;
                    DLabel.Text = Name1;
                    EndPanel.Visible = true;
                    ControlPanel.Visible = false;
                    BuyPanel.Visible = false;
                    AttackPanel.Visible = false;
                    ResearchPanel.Visible = false;
                    HomePanel.Visible = false;
                    EndPanel.BackColor = Color.Red;
                    StrSend = "youwin";
                    SendData();
                }
                else
                if (NameState[StateFocusNum] == StartS2)
                {
                    VLabel.Text = Name1;
                    DLabel.Text = Name2;
                    EndPanel.Visible = true;
                    ControlPanel.Visible = false;
                    ControlPanel.Visible = false;
                    BuyPanel.Visible = false;
                    AttackPanel.Visible = false;
                    ResearchPanel.Visible = false;
                    HomePanel.Visible = false;
                    EndPanel.BackColor = Color.Blue;
                    StrSend = "iwin";
                    SendData();
                }
                else
                {
                    AtMarrineBox.Value = 0;
                    AtTankBox.Value = 0;
                    AtPlaneBox.Value = 0;
                    AtTankBox.Enabled = false;
                    AtPlaneBox.Enabled = false;
                    EndTurn();
                    UpdateView();
                }
            }
            else
                ErrLabel2.Visible = true;
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            PauseMenu.Visible = true;
        }
        private void BtnContinue_Click(object sender, EventArgs e)
        {
            PauseMenu.Visible = false;
            string h = "";
            for (int d = 0; d < 41; d++)
                h += StatePoint[d] + "-";
            InventoryBox2.Text = h;
        }
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            StrSend = "youwin";
            SendData();
            this.Close();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Want you realy exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StrSend = "youwin";
                SendData();
                Application.Exit();
            }
        }
        private void BtnConsole_Click(object sender, EventArgs e)
        {
            if (MainSettings.Default.CMDmultiON == true)
            {
                CommandPrompt cmd = new CommandPrompt();
                cmd.Show();
            }
            else
                MessageBox.Show("CMD IS SET OFFLINE!", "OCCUPAION OF STATES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //END

        //ONLINE MULTIPLAYER
        Socket sck;
        EndPoint epLocal, epRemote;
        private string StrSend, StrRecive, word, message;
        private bool SecondReady = false, IReady = false;
        string Profile2;
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])aResult.AsyncState;

                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    StrRecive = eEncoding.GetString(receivedData);
                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote,new AsyncCallback(MessageCallBack), buffer);

                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Err4.Visible = true;
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Err4.Visible = false;
            if (MyIPbox.Text != "" && MyPortbox.Text != "" && CoIPbox.Text != "" && CoPortbox.Text != "")
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(MyIPbox.Text), Convert.ToInt32(MyPortbox.Text));
                sck.Bind(epLocal);
                //connect
                epRemote = new IPEndPoint(IPAddress.Parse(CoIPbox.Text), Convert.ToInt32(CoPortbox.Text));
                sck.Connect(epRemote);
                //listen
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                Err5.Visible = true;
                BtnReady.Enabled = true;
            }
            catch
            {
                Err4.Visible = true;
            }
        }
        int ComLevel = 0;
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            if (IReady && SecondReady)
            {
                if (MainSettings.Default.LobbyCreate == true)
                {
                    System.Threading.Thread.Sleep(100);
                    StrSend = "myturn";
                    SendData();
                }
                else
                {
                    ControlPanel.Visible = false;
                }
                StartTimer.Stop();
            }
            if (Name2 == null && ComLevel == 0)
            {
                StrSend = "whatname";
                SendData();
            }
            if (Profile2 == null && ComLevel == 1)
            {
                StrSend = "whaticon";
                SendData();
            }
            if (FolderPath == null && MainSettings.Default.LobbyCreate == false && ComLevel == 2)
            {
                StrSend = "whatfolder";
                SendData();
            }
            if (DataPath == null && MainSettings.Default.LobbyCreate == false && ComLevel == 3)
            {
                StrSend = "whatmap";
                SendData();
            }
            if (MainSettings.Default.LobbyCreate == true && ComLevel == 2)
                ComLevel = 4;
            if (MainSettings.Default.LobbyCreate == true && ComLevel == 3)
                ComLevel = 4;
            if (StartS2 == null && ComLevel == 4)
            {
                StrSend = "whatsstate";
                SendData();
            }
            if (Name2 != null && StartS2 != null && FolderPath != null && DataPath != null && StartS1 != null)
            {
                IReady = true;
                StrSend = "iready";
                SendData();
                CreateStateDescription();

                for (int i = 0; i < LongInt; i++)
                {
                    Label label = new Label();
                    label.Location = new Point(StatePoint[i].X * 2, StatePoint[i].Y * 2);
                    label.Name = "label" + i;
                    label.Text = NameState[i];
                    label.Tag = Convert.ToString(i);
                    label.BackColor = Color.Transparent;
                    label.MouseEnter += StateLabel_MouseEnter;
                    label.MouseLeave += StateLabel_MouseLeave;
                    //label.Click += Attack_Click;
                    MainMap.Controls.Add(label);

                    Atbox.Items.Add(NameState[i]);
                    Atbox2.Items.Add(NameState[i]);
                }
                MainMap.BackgroundImage = (Bitmap)Image.FromFile(Application.StartupPath + MapPath);
                Image ni = Image.FromFile(Application.StartupPath + MapPath);
                MainMap.Width = ni.Width * 2;
                MainMap.Height = ni.Height * 2;
                buy1.Text += MoneySign;
                buy2.Text += MoneySign;
                buy3.Text += MoneySign;
                buy4.Text += MoneySign;
                buy5.Text += MoneySign;
                buy6.Text += MoneySign;
                buy7.Text += MoneySign;
                buy8.Text += MoneySign;
                buy9.Text += MoneySign;
                buy10.Text += MoneySign;
                buy11.Text += MoneySign;

                CityBox1.Text = StartS1;

                if (MainSettings.Default.CMDmultiON == false)
                    BtnConsole.Visible = false;
                for (int i = 0; i < LongInt; i++)
                {
                    if (StartS1 == NameState[i])
                    {
                        PlayerPopulation1 = Population[i];
                        Farm1 += FoodsProduction[i];
                        Mine1 += IronMine[i];
                        Bitmap bm = (Bitmap)MainMap.BackgroundImage;
                        new FillColorClass().FloodFill(ref bm, Color.Blue, StatePoint[i]);
                        MainMap.BackgroundImage = bm;
                        OccuState1[i] = true;
                    }
                    if (SS2 == i)
                    {
                        PlayerPopulation2 = Population[i];
                        Farm2 += FoodsProduction[i];
                        Mine2 += IronMine[i];
                        Bitmap bm = (Bitmap)MainMap.BackgroundImage;
                        new FillColorClass().FloodFill(ref bm, Color.Red, StatePoint[i]);
                        MainMap.BackgroundImage = bm;
                        OccuState2[i] = true;
                        StartS2 = NameState[i];
                    }
                }
                NameBox2.Text = Name2;
                CityBox2.Text = StartS2;

                UpdateView();
                panelConnect.Visible = false;
            }
        }
        private void BtnReady_Click(object sender, EventArgs e)
        {
            Err6.Visible = true;
            StartTimer.Start();
        }

        private void SendData()
        {
            try
            {
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                byte[] sendingMessage = new byte[1500];
                sendingMessage = aEncoding.GetBytes(StrSend);

                sck.Send(sendingMessage);
            }
            catch 
            {
                MessageBox.Show("FATAL CONNECTION ERROR", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool DoOne = false;
        int DBphase = 0;
        int SS2 = 0;
        private void UpdateData()
        {
            try
            {
                for (int i = 0; i < StrRecive.Length; i++)
                {
                    word += StrRecive[i];
                    //UPDATE LOCAL DATA
                    if (word == "m-")
                    {
                        message = null;
                        for (int j = 2; j < StrRecive.Length; j++)
                            message += StrRecive[j];
                        ChatHistory.SelectionColor = Color.Red;
                        string m1 = NameBox2.Text + "> " + message + Environment.NewLine;
                        ChatHistory.SelectedText += Environment.NewLine + m1;
                    }
                    if (word == "folder-")
                    {
                        word = null;
                        for (int j = 7; j < StrRecive.Length; j++)
                            word += StrRecive[j];
                        FolderPath = word;
                        ComLevel = 3;
                    }
                    if (word == "map-" && FolderPath != null)
                    {
                        try
                        {
                            word = null;
                            for (int j = 4; j < StrRecive.Length; j++)
                                word += StrRecive[j];
                            DataPath = word;
                            char c = '1';
                            int phase = 0;
                            ChatBox.Clear();
                            ChatBox.Text = Application.StartupPath;
                            ChatBox.Text += @"\";
                            ChatBox.Text += FolderPath;
                            ChatBox.Text += @"\";
                            ChatBox.Text += DataPath;
                            FullPath = ChatBox.Text;
                            ChatBox.Clear();
                            word = null;
                            StreamReader reader = new StreamReader(FullPath);
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
                                    word = null;
                                }
                                if (c == '|')
                                    phase++;
                            } while (phase < 6);
                            //start state
                            CreateStateDescription();
                        }
                        catch
                        {
                            MessageBox.Show("Map file is corrupted! ", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        ComLevel = 4;
                    }
                    if (word == "myname-")
                    {
                        word = null;
                        for (int j = 7; j < StrRecive.Length; j++)
                            word += StrRecive[j];
                        Name2 = word;
                        NameBox2.Text = Name2;
                        ComLevel = 1;
                    }
                    if (word == "mymoney-")
                    {
                        word = null;
                        for (int j = 8; j < StrRecive.Length; j++)
                            word += StrRecive[j];
                        Money2 = Convert.ToInt32(word);
                    }
                    if (word == "startstate-")
                    {
                        word = null;
                        for (int j = 11; j < StrRecive.Length; j++)
                            word += StrRecive[j];
                        SS2 = Convert.ToInt32(word);
                        StartS2 = "-";
                    }
                    if (word == "myicon-")
                    {
                        ChatBox.Clear();
                        string IconPath;
                        ChatBox.Text = Application.StartupPath;
                        ChatBox.Text += @"\";
                        ChatBox.Text += @"player_icons";
                        ChatBox.Text += @"\";
                        ChatBox.Text += Name2;
                        ChatBox.Text += @"_icon.png";
                        IconPath = ChatBox.Text;
                        ChatBox.Clear();
                        try
                        {
                            word = null;
                            Profile2 += StrRecive[7];
                            if (Profile2 == "1")
                                LogoBox2.Image = Properties.Resources.Icon1;
                            else if (Profile2 == "2")
                                LogoBox2.Image = Properties.Resources.Icon2;
                            else if (Profile2 == "3")
                                LogoBox2.Image = Properties.Resources.Icon3;
                            else if (Profile2 == "4")
                                LogoBox2.Image = Properties.Resources.Icon4;
                            else if (Profile2 == "5")
                                LogoBox2.Image = Properties.Resources.Icon5;
                            else if (Profile2 == "6")
                                LogoBox2.Image = Image.FromFile(IconPath);
                            else
                                LogoBox2.Image = Properties.Resources.Icon1;
                        }
                        catch
                        {
                            MessageBox.Show(Profile2 + "error icon ty kkt" + IconPath);
                            LogoBox2.Image = Properties.Resources.Icon1;
                        }
                        LogoBox2.Refresh();
                        ComLevel = 2;
                    }
                    //SEND DATA BACK
                    if (word == "whatmap")
                    {
                        StrSend = "map-" + DataPath;
                        SendData();
                    }
                    if (word == "whatfolder")
                    {
                        StrSend = "folder-" + FolderPath;
                        SendData();
                    }
                    if (word == "whatname")
                    {
                        StrSend = "myname-" + Name1;
                        SendData();
                    }
                    if (word == "whatmoney")
                    {
                        StrSend = "mymoney-" + Money1;
                        SendData();
                    }
                    if (word == "whaticon")
                    {
                        StrSend = "myicon-1";
                        if (UsersSettings.Default.ProfileLast1 == 2)
                            StrSend = "myicon-2";
                        if (UsersSettings.Default.ProfileLast1 == 3)
                            StrSend = "myicon-3";
                        if (UsersSettings.Default.ProfileLast1 == 4)
                            StrSend = "myicon-4";
                        if (UsersSettings.Default.ProfileLast1 == 5)
                            StrSend = "myicon-5";
                        if (UsersSettings.Default.ProfileLast1 == 6)
                            StrSend = "myicon-6";
                        SendData();
                    }
                    if (word == "whatsstate" && StartS1 != null)
                    {
                        for (int j = 0; j < LongInt; j++)
                        {
                            if (StartS1 == NameState[j])
                            {
                                StrSend = "startstate-" + Convert.ToString(j);
                                SendData();
                            }
                        }
                    }
                    if (word == "iready")
                    {
                        SecondReady = true;
                    }
                    //START COMMUNICATING
                    if (word == "myturn")
                    {
                        TurnLabel.Text = Name2 + " Turn";
                        TurnLabel.BackColor = Color.Red;
                        TurnPanel.Image = Properties.Resources.Turn2_0;
                        AttackPanel.Visible = false;
                        BuyPanel.Visible = false;
                        ResearchPanel.Visible = false;
                        ControlPanel.Visible = false;
                        HomePanel.Visible = false;
                    }
                    if (word == "yourturn")
                    {
                        ControlPanel.Visible = true;
                        AttackPanel.Visible = false;
                        BuyPanel.Visible = false;
                        ResearchPanel.Visible = false;
                        HomePanel.Visible = false;
                        ErrLabel1.Visible = false;
                        ErrLabel2.Visible = false;
                        ErrLabel3.Visible = false;
                        ErrLabel4.Visible = false;
                        ErrLabel5.Visible = false;
                        EventNum = Rand.Next(0, 7);
                        createDB();
                        TurnPanel.Image = Properties.Resources.Turn1_0;
                        TurnLabel.Text = Name1 + " Turn";
                        TurnLabel.BackColor = Color.DeepSkyBlue;
                        ControlPanel.BackColor = Color.DeepSkyBlue;
                        Iron1 += Mine1 * 10 * FMine1lvl;
                        Food1 += Farm1 * 10 * FFarm1lvl;
                        Food1 -= PlayerPopulation1;
                        Money1 += (PlayerPopulation1 * Taxes1) / 10000;
                        player1XP += Scientist1 * 10;
                        AddIron.Text = "+ " + Mine1 * 10 * FMine1lvl + " Irons";
                        AddFood.Text = "+ " + ((Farm1 * 10 * FFarm1lvl) - PlayerPopulation1) + " Foods";
                        AddMoney.Text = "+ " + (PlayerPopulation1 * Taxes1) / 10000 + " Money";
                        AddXP.Text = "+ " + Scientist1 * 10 + " XP";
                        if (Food1 <= -1)
                        {
                            ErrLabel5.Visible = true;
                            Feel1--;
                        }
                        else
                            Feel1++;
                        if (Feel1 > 5)
                            Feel1 = 5;
                        if (player1XP > 10000)
                            player1XP = 10000;
                        if (EventNum <= 1)
                        {
                            EventBox.BackgroundImage = Properties.Resources.Event1;
                            AddEvent.Text = "Nothing special, just another day";
                        }
                        if (EventNum == 2)
                        {
                            EventBox.BackgroundImage = Properties.Resources.Event2;
                            AddEvent.Text = "Tornado destroy your farm field -1000 food";
                            Food1 -= 1000;
                        }
                        if (EventNum == 3)
                        {
                            EventBox.BackgroundImage = Properties.Resources.Event3;
                            AddEvent.Text = "Your sientist do random discovery +50 xp";
                            player1XP += 50;
                        }
                        if (EventNum == 4)
                        {
                            EventBox.BackgroundImage = Properties.Resources.Event4;
                            AddEvent.Text = "Someone do bank robbery - 20 000 money";
                            Money1 -= 20000;
                        }
                        if (EventNum == 5)
                        {
                            EventBox.BackgroundImage = Properties.Resources.Event5;
                            AddEvent.Text = "Your Army was found +50 Marrine";
                            player1XP += 500;
                        }
                        if (EventNum == 6)
                        {
                            EventBox.BackgroundImage = Properties.Resources.Event6;
                            AddEvent.Text = "Your factory was destroyed -1000 irons";
                            Iron1 -= 1000;
                        }
                        if (Feel1 < 0)
                        {
                            VLabel.Text = Name2;
                            DLabel.Text = Name1;
                            EndPanel.Visible = true;
                            ControlPanel.Visible = false;
                            EndPanel.BackColor = Color.Red;
                            StrSend = "youwin";
                            SendData();
                        }
                    }
                
                    //sf
                    if (word == "DBupdate-")
                    {
                        DBphase = 0;
                        word = null;
                        for (int j = 9; j < StrRecive.Length; j++)
                        {
                            if (StrRecive[j] != '-')
                                word += StrRecive[j];
                            if (DBphase == 0 && StrRecive[j] == '-')
                                Money2 = Convert.ToInt32(word);
                            if (DBphase == 1 && StrRecive[j] == '-')
                                PlayerPopulation2 = Convert.ToInt32(word);
                            if (DBphase == 2 && StrRecive[j] == '-')
                                Scientist2 = Convert.ToInt32(word);
                            if (DBphase == 3 && StrRecive[j] == '-')
                                Mine2 = Convert.ToInt32(word);
                            if (DBphase == 4 && StrRecive[j] == '-')
                                Farm2 = Convert.ToInt32(word);
                            if (DBphase == 5 && StrRecive[j] == '-')
                                AtMarrine2 = Convert.ToInt32(word);
                            if (DBphase == 6 && StrRecive[j] == '-')
                                AtTank2 = Convert.ToInt32(word);
                            if (DBphase == 7 && StrRecive[j] == '-')
                                AtPlane2 = Convert.ToInt32(word);
                            if (DBphase == 8 && StrRecive[j] == '-')
                                DeMarrine2 = Convert.ToInt32(word);
                            if (DBphase == 9 && StrRecive[j] == '-')
                                DeTank2 = Convert.ToInt32(word);
                            if (DBphase == 10 && StrRecive[j] == '-')
                                DePlane2 = Convert.ToInt32(word);
                            if (DBphase == 11 && StrRecive[j] == '-')
                                Iron2 = Convert.ToInt32(word);
                            if (DBphase == 12 && StrRecive[j] == '-')
                                Food2 = Convert.ToInt32(word);
                            if (DBphase == 13 && StrRecive[j] == '-')
                                player2XP = Convert.ToInt32(word);
                            if (DBphase == 14 && StrRecive[j] == '-')
                                Hacker2 = Convert.ToInt32(word);
                            if (DBphase == 15 && StrRecive[j] == '-')
                                Nuke2 = Convert.ToInt32(word);
                            //phase++
                            if (StrRecive[j] == '-')
                            {
                                word = null;
                                DBphase++;
                            }
                        }
                        InventoryBox2.Text = "Population: " + PlayerPopulation2 + Environment.NewLine + "Scientlis: " + Scientist2 + Environment.NewLine + "Mine: " + Mine2 + Environment.NewLine +
                        "Farm: " + Farm2 + Environment.NewLine + "Marrine: " + AtMarrine2 + Environment.NewLine + "Tank: " + AtTank2 + Environment.NewLine +
                        "Fly fither: " + AtPlane2 + Environment.NewLine + "Defensive marine: " + DeMarrine2 + Environment.NewLine + "Bomb Mine: " + DeTank2 + Environment.NewLine +
                        "Antillary: " + DePlane2 + Environment.NewLine + "Iron: " + Iron2 + Environment.NewLine + "Food: " + Food2 + Environment.NewLine + "XP: " + player2XP +
                        Environment.NewLine + "Hacker: " + Hacker2 + Environment.NewLine + "Nuke: " + Nuke2;
                    }
                    if (word == "mystate-")//statefocusnum
                    {
                        word = null;
                        for (int j = 8; j < StrRecive.Length; j++)
                            word += StrRecive[j];
                        StateFocusNum = Convert.ToInt32(word);
                        //occupate
                        if (OccuState1[StateFocusNum] == true)
                        {
                            DeMarrine1 -= Rand.Next(0, AtMarrine2);
                            DeTank1 -= Rand.Next(0, AtTank2);
                            DePlane1 -= Rand.Next(0, AtPlane2);
                            PlayerPopulation1 -= Population[StateFocusNum];
                            Mine1 -= IronMine[StateFocusNum];
                            Farm1 -= FoodsProduction[StateFocusNum];
                        }
                        Bitmap bm = (Bitmap)MainMap.BackgroundImage;
                        new FillColorClass().FloodFill(ref bm, Color.Red, StatePoint[StateFocusNum]);
                        MainMap.BackgroundImage = bm;
                        OccuState2[StateFocusNum] = true;
                        OccuState1[StateFocusNum] = false;
                        createDB();
                    }
                    if (word == "nukedstate-")//statefocusnum
                    {
                        word = null;
                        for (int j = 11; j < StrRecive.Length; j++)
                            word += StrRecive[j];
                        //nuked
                        StateFocusNum = Convert.ToInt32(word);
                        Bitmap bm = (Bitmap)MainMap.BackgroundImage;
                        new FillColorClass().FloodFill(ref bm, Color.DimGray, StatePoint[StateFocusNum]);
                        MainMap.BackgroundImage = bm;
                        if (OccuState1[StateFocusNum] == true)
                        {
                            PlayerPopulation1 -= Population[StateFocusNum];
                            Mine1 -= IronMine[StateFocusNum];
                            Farm1 -= FoodsProduction[StateFocusNum];
                            OccuState1[StateFocusNum] = false;
                        }
                        if (OccuState2[StateFocusNum] == true)
                        {
                            PlayerPopulation1 += Population[StateFocusNum];
                            Mine1 += IronMine[StateFocusNum];
                            Farm1 += FoodsProduction[StateFocusNum];
                            OccuState2[StateFocusNum] = false;
                        }
                        if (NameState[StateFocusNum] == StartS1)
                        {
                            VLabel.Text = Name2;
                            DLabel.Text = Name1;
                            EndPanel.Visible = true;
                            ControlPanel.Visible = false;
                            BuyPanel.Visible = false;
                            AttackPanel.Visible = false;
                            ResearchPanel.Visible = false;
                            HomePanel.Visible = false;
                            EndPanel.BackColor = Color.Red;
                        }
                        else
                        if (NameState[StateFocusNum] == StartS2)
                        {
                            VLabel.Text = Name1;
                            DLabel.Text = Name2;
                            EndPanel.Visible = true;
                            ControlPanel.Visible = false;
                            ControlPanel.Visible = false;
                            BuyPanel.Visible = false;
                            AttackPanel.Visible = false;
                            ResearchPanel.Visible = false;
                            HomePanel.Visible = false;
                            EndPanel.BackColor = Color.Blue;
                        }
                        else
                        {
                            StateDestroy[StateFocusNum] = true;
                            EndTurn();
                            UpdateView();
                            createDB();
                        }
                    }
                    if (word == "iwin")
                    {
                        VLabel.Text = NameBox2.Text;
                        DLabel.Text = NameBox1.Text;
                        EndPanel.Visible = true;
                        ControlPanel.Visible = false;
                        BuyPanel.Visible = false;
                        AttackPanel.Visible = false;
                        ResearchPanel.Visible = false;
                        HomePanel.Visible = false;
                        EndPanel.BackColor = Color.Red;
                    }
                    if (word == "youwin")
                    {
                        VLabel.Text = NameBox1.Text;
                        DLabel.Text = NameBox2.Text;
                        EndPanel.Visible = true;
                        ControlPanel.Visible = false;
                        ControlPanel.Visible = false;
                        BuyPanel.Visible = false;
                        AttackPanel.Visible = false;
                        ResearchPanel.Visible = false;
                        HomePanel.Visible = false;
                        EndPanel.BackColor = Color.Blue;
                    }
                }
            }
            catch { MessageBox.Show("Communication Error:" + StrRecive + "(last on:" + word + ")"); }
            UpdateView();
            word = null;
        }

        public void createDB()
        {
            StrSend = "DBupdate-";
            StrSend += Money1 + "-" + PlayerPopulation1 + "-" + Scientist1 + "-" + Mine1 + "-" + Farm1 + "-" + AtMarrine1 + "-" + AtTank1 + "-" + AtPlane1 + "-" + DeMarrine1 + "-" + DeTank1 + "-" + DePlane1 + "-" + Iron1 + "-" + Food1 + "-" +player1XP + "-" + Hacker1 + "-" + Nuke1;
            SendData();
        }

        private void EndTurn()
        {
            TurnLabel.Text = Name2 + " Turn";
            TurnLabel.BackColor = Color.Red;
            TurnPanel.Image = Properties.Resources.Turn2_0;
            AttackPanel.Visible = false;
            BuyPanel.Visible = false;
            ResearchPanel.Visible = false;
            ControlPanel.Visible = false;
            HomePanel.Visible = false;
            StrSend = "yourturn";
            SendData();
        }

    }
}
