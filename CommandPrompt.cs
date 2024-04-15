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
    public partial class CommandPrompt : Form
    {
        public CommandPrompt()
        {
            InitializeComponent();
        }
        string Command;
        bool CommandExist = false;
        bool hereFullscreen = false;
        string oldCommand;
        //CMD MINIGAME
        bool GameMode = false;
        static string[] Bomb = new string[30];
        int BombChunk = 0;
        string BombCode = "* * * * * * * * *";
        static string[] AnsverCode = new string[10];
        int FocusNumCode = 0;
        static string[] DisplayCode = new string[10];
        string RemainingTime = "03:00:00";
        int Minute = 3;
        int Second = 0;
        int MiliSecond = 0;
        string sMinute;
        string sSecond;
        string sMiliSecond;
        bool GameIsOnline = false;
        
        string NumCode = "#";
        Random rand = new Random();

        private void CommandPrompt_Load(object sender, EventArgs e)
        {
            CMDbox.ForeColor = Color.Lime;
            CMDbox.SelectedText += @"===================================================================================================" + Environment.NewLine;
            CMDbox.SelectedText += @"  _                                     _    _    __                      _  _        __  _      _ " + Environment.NewLine;
            CMDbox.SelectedText += @" / \  _  _     ._   _. _|_ o  _  ._    / \ _|_   (_ _|_  _. _|_  _   _   /  / \ |\ | (_  / \ |  |_ " + Environment.NewLine;
            CMDbox.SelectedText += @" \_/ (_ (_ |_| |_) (_|  |_ | (_) | |   \_/  |    __) |_ (_|  |_ (/_ _>   \_ \_/ | \| __) \_/ |_ |_ " + Environment.NewLine;
            CMDbox.SelectedText += @"               |                                                                                   " + Environment.NewLine;
            CMDbox.SelectedText += @"===================================================================================================";
        }

        private void CMDbox_Enter(object sender, EventArgs e)
        {
            CMDtext.Focus();
        }

        private void CMDtext_KeyUp(object sender, KeyEventArgs e)
        {
            if (GameMode == false)
            switch(e.KeyCode)
            {
                case Keys.Up:
                    CMDtext.Text = oldCommand;
                    CMDtext.SelectionStart = CMDtext.Text.Length;
                    break;
                case Keys.F11:
                    if (hereFullscreen == false)
                    {
                        hereFullscreen = true;
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Maximized;
                        CMDbox.Width = this.Width;
                        CMDbox.Height = this.Height - 20;
                        CMDtext.Top = this.Height - 20;
                    }
                    else
                    {
                        hereFullscreen = false;
                        this.FormBorderStyle = FormBorderStyle.FixedSingle;
                        this.WindowState = FormWindowState.Normal;
                        CMDbox.Width = this.Width - 15;
                        CMDbox.Height = this.Height - 60;
                        CMDtext.Top = this.Height - 60;
                    }
                    break;
                case Keys.Enter:
                    CMDbox.SelectionColor = Color.DarkGreen;
                    CMDbox.SelectedText += Environment.NewLine + CMDtext.Text;
                    Command = CMDtext.Text;
                    oldCommand = Command;
                    CMDtext.Text = null;
                    CMDbox.SelectionColor = Color.Lime;
                        //Start
                        CMDbox.SelectionStart = CMDbox.Text.Length;
                        CMDbox.ScrollToCaret();
                        if (Command == "list")
                        {
                            CommandExist = true;
                            CMDbox.SelectedText += Environment.NewLine + "--LIST OF APP COMMANDS--";
                            CMDbox.SelectedText += Environment.NewLine + "APP INFO              - write information of application";
                            CMDbox.SelectedText += Environment.NewLine + "APP RESTART           - will restart application";
                            CMDbox.SelectedText += Environment.NewLine + "APP EXIT              - will end application";
                            CMDbox.SelectedText += Environment.NewLine + "CREDIT                - write authors";
                            CMDbox.SelectedText += Environment.NewLine + "LIST                  - write all commands";
                            CMDbox.SelectedText += Environment.NewLine + "FULLSCREEN ON/OFF     - set fullscreen on or off";
                            CMDbox.SelectedText += Environment.NewLine + "CLS                   - clear command prompt";
                            CMDbox.SelectedText += Environment.NewLine + "EXIT                  - hide command prompt";
                            CMDbox.SelectedText += Environment.NewLine + "CMD OFF               - set off switchable command prompt";
                            CMDbox.SelectedText += Environment.NewLine + "NETLOG                - write all communication in online";
                            CMDbox.SelectedText += Environment.NewLine + "                        multiplayer game";
                            CMDbox.SelectedText += Environment.NewLine + "--LIST OF GAME COMMANDS--";
                            CMDbox.SelectedText += Environment.NewLine + "LOGO                  - draw big logo";
                            CMDbox.SelectedText += Environment.NewLine + "GAME INFO             - write information of game";
                            CMDbox.SelectedText += Environment.NewLine + "FEEL                  - write information feel";
                            CMDbox.SelectedText += Environment.NewLine + "OCCUSTATE             - write information of occupation states";
                            CMDbox.SelectedText += Environment.NewLine + "MONEY1                - give player1 10 000 money";
                            CMDbox.SelectedText += Environment.NewLine + "MONEY2                - give player2 10 000 money";
                            CMDbox.SelectedText += Environment.NewLine + "BIGMONEY1             - give player1 1 000 000 money";
                            CMDbox.SelectedText += Environment.NewLine + "BIGMONEY2             - give player2 1 000 000 money";
                            CMDbox.SelectedText += Environment.NewLine + "XP1                   - give player1 1 000 xp";
                            CMDbox.SelectedText += Environment.NewLine + "XP2                   - give player2 1 000 xp";
                            CMDbox.SelectedText += Environment.NewLine + "BIGXP1                - give player1 10 000 xp";
                            CMDbox.SelectedText += Environment.NewLine + "BIGXP2                - give player2 10 000 xp";
                            CMDbox.SelectedText += Environment.NewLine + "HACKER1               - give player1 1 hacker";
                            CMDbox.SelectedText += Environment.NewLine + "HACKER2               - give player2 1 hacker";
                            CMDbox.SelectedText += Environment.NewLine + "NUKE1                 - give player1 1 nuclear bomb";
                            CMDbox.SelectedText += Environment.NewLine + "NUKE2                 - give player2 1 nuclear bomb";
                            CMDbox.SelectedText += Environment.NewLine + "--------------------------";
                            CMDbox.SelectedText += Environment.NewLine + "give command in online game work only to local player";
                        }
                    if (Command == "bomb")
                    {
                        GameMode = true;
                        CommandExist = true;
                        Bomb[1] =  @"_____________________________";
                        Bomb[2] =  @"|                           |";
                        Bomb[3] =  @"|    ___________________    |";
                        Bomb[4] =  @"|   | " + BombCode + "  |   |";
                        Bomb[5] =  @"|   |___________________|   |";
                        Bomb[6] =  @"|                           |";
                        Bomb[7] =  @"|    ┍---┑  ┍---┑  ┍---┑    |";
                        Bomb[8] =  @"|    | 7 |  | 8 |  | 9 |    |";
                        Bomb[9] =  @"|    ┕---┙  ┕---┙  ┕---┙    |";
                        Bomb[10] = @"|    ┍---┑  ┍---┑  ┍---┑    |";
                        Bomb[11] = @"|    | 4 |  | 5 |  | 6 |    |";
                        Bomb[12] = @"|    ┕---┙  ┕---┙  ┕---┙    |";
                        Bomb[13] = @"|    ┍---┑  ┍---┑  ┍---┑    |";
                        Bomb[14] = @"|    | 1 |  | 2 |  | 3 |    |";
                        Bomb[15] = @"|    ┕---┙  ┕---┙  ┕---┙    |";
                        Bomb[16] = @"|    ┍---┑  ┍---┑  ┍---┑    |";
                        Bomb[17] = @"|    | * |  | 0 |  | # |    |";
                        Bomb[18] = @"|    ┕---┙  ┕---┙  ┕---┙    |";
                        Bomb[19] = @"\___________________________/";
                        Bomb[20] = @"  | |   | |                  ";
                        Bomb[21] = @"  | |   | |                  ";
                        Bomb[22] = @"  | |   | |                  ";
                        Bomb[23] = @"__|_|___|_|_________________ ";
                        Bomb[24] = @"|                           |";
                        Bomb[25] = @"|  _____    ______________  |";
                        Bomb[26] = @"|  | "+ NumCode + " |    |  " + RemainingTime +"  |  |";
                        Bomb[27] = @"|  |___|    |____________|  |";
                        Bomb[28] = @"\___________________________/";
                            CMDbox.Text = null;
                            BombChunk = 0;
                            for (int DoThirty = 0; DoThirty < 19; DoThirty++)
                            {
                                BombChunk++;
                                CMDbox.SelectedText += Bomb[BombChunk] + Environment.NewLine;
                            }
                            CMDbox.SelectionColor = Color.Blue;
                            CMDbox.SelectedText += Environment.NewLine + @"______________  ______________";
                            CMDbox.SelectedText += Environment.NewLine + @"|    EXIT    |  |    PLAY    |";
                            CMDbox.SelectedText += Environment.NewLine + @"|   <ESC>    |  |   <ENTER>  |";
                            CMDbox.SelectedText += Environment.NewLine + @"|____________|  |____________|";
                        }
                        if (Command == "cmd off")
                        {
                            CMDbox.SelectionColor = Color.Red;
                            CMDbox.SelectedText += Environment.NewLine + @"_____________________";
                            CMDbox.SelectedText += Environment.NewLine + @"|         _         |";
                            CMDbox.SelectedText += Environment.NewLine + @"|        / \        |";
                            CMDbox.SelectedText += Environment.NewLine + @"|       / _ \       |";
                            CMDbox.SelectedText += Environment.NewLine + @"|      / | | \      |";
                            CMDbox.SelectedText += Environment.NewLine + @"|     /  | |  \     |";
                            CMDbox.SelectedText += Environment.NewLine + @"|    /   |_|   \    |";
                            CMDbox.SelectedText += Environment.NewLine + @"|   /     _     \   |";
                            CMDbox.SelectedText += Environment.NewLine + @"|  /     |_|     \  |";
                            CMDbox.SelectedText += Environment.NewLine + @"| /_______________\ |";
                            CMDbox.SelectedText += Environment.NewLine + @"|___________________|";
                            CMDbox.SelectedText += Environment.NewLine + @"-------------------";
                            CMDbox.SelectedText += Environment.NewLine + "--=COMMAND PROMPT SET OFFLINE=--";
                            MainSettings.Default.CMDonline = false;
                            MainSettings.Default.CMDmultiON = false;
                            MainSettings.Default.Save();
                            CommandExist = true;
                        }
                        if (Command == "app exit")
                        {
                            CommandExist = true;
                            Application.Exit();
                        }
                        if (Command == "help")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Write |LIST| to view all commands or";
                            CMDbox.SelectedText += Environment.NewLine + "write |EXIT| to exit ";
                            CommandExist = true;
                        }
                        if (Command == "money1")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player1 was given 10 000 money";
                            CommandExist = true;
                            OffMultiplayer.Money1 += 10000;
                            OffSingleplayer.Money1 += 10000;
                            OnMultiplayer.Money1 += 10000;
                        }
                        if (Command == "money2" && MainSettings.Default.ModePlay != 3)
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player2 was given 10 000 money";
                            CommandExist = true;
                            OffMultiplayer.Money2 += 10000;
                            OffSingleplayer.Money2 += 10000;
                        }
                        if (Command == "bigmoney1")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player1 was given 1 000 000 money";
                            CommandExist = true;
                            OffMultiplayer.Money1 += 1000000;
                            OffSingleplayer.Money1 += 1000000;
                            OnMultiplayer.Money1 += 1000000;
                        }
                        if (Command == "bigmoney2" && MainSettings.Default.ModePlay != 3)
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player2 was given 1 000 000 money";
                            CommandExist = true;
                            OffMultiplayer.Money2 += 1000000;
                            OffSingleplayer.Money2 += 1000000;
                        }
                        if (Command == "xp1")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player1 was given 1 000 xp";
                            CommandExist = true;
                            OffMultiplayer.player1XP += 1000;
                            OffSingleplayer.player1XP += 1000;
                            OnMultiplayer.player1XP += 1000;
                        }
                        if (Command == "xp2" && MainSettings.Default.ModePlay != 3)
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player2 was given 1 000 xp";
                            CommandExist = true;
                            OffMultiplayer.player2XP += 1000;
                            OffSingleplayer.player2XP += 1000;
                        }
                        if (Command == "bigxp1")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player1 was given 10 000 xp";
                            CommandExist = true;
                            OffMultiplayer.player1XP += 10000;
                            OffSingleplayer.player1XP += 10000;
                            OnMultiplayer.player1XP += 10000;
                        }
                        if (Command == "bigxp2" && MainSettings.Default.ModePlay != 3)
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player2 was given 10 000 xp";
                            CommandExist = true;
                            OffMultiplayer.player2XP += 10000;
                            OffSingleplayer.player2XP += 10000;
                        }
                        if (Command == "hacker1")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player1 was given hacker";
                            CommandExist = true;
                            OffMultiplayer.Hacker1 += 1;
                            OffSingleplayer.Hacker1 += 1;
                            OnMultiplayer.Hacker1 += 1;
                        }
                        if (Command == "hacker2" && MainSettings.Default.ModePlay != 3)
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player2 was given hacker";
                            CommandExist = true;
                            OffMultiplayer.Hacker2 += 1;
                            OffSingleplayer.Hacker2 += 1;
                        }
                        if (Command == "nuke1")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player1 was given nuclear bomb";
                            CommandExist = true;
                            OffMultiplayer.Nuke1 += 1;
                            OffSingleplayer.Nuke1 += 1;
                            OnMultiplayer.Nuke1 += 1;
                        }
                        if (Command == "nuke2" && MainSettings.Default.ModePlay != 3)
                        {
                            CMDbox.SelectedText += Environment.NewLine + "Player2 was given nuclear bomb";
                            CommandExist = true;
                            OffMultiplayer.Nuke2 += 1;
                            OffSingleplayer.Nuke2 += 1;
                        }
                        if (Command == "occustate")
                        {
                            CommandExist = true;
                            CMDbox.SelectedText += Environment.NewLine + "---=OCCUPATE STETES=---";
                            CMDbox.SelectedText += Environment.NewLine + "ID---OCCU1-OCCU2-DESTROY-NAME";
                            string Occu1 = "-", Occu2 = "-", a, destr = "-";
                            for (int i = 0; i < OffSingleplayer.LongInt && MainSettings.Default.ModePlay == 1; i++)
                            {
                                if (OffSingleplayer.OccuState1[i] == true)
                                    Occu1 = "1";
                                if (OffSingleplayer.OccuState1[i] == false)
                                    Occu1 = "0";
                                if (OffSingleplayer.OccuState2[i] == true)
                                    Occu2 = "1";
                                if (OffSingleplayer.OccuState2[i] == false)
                                    Occu2 = "0";
                                if (OffSingleplayer.StateDestroy[i] == true)
                                    destr = "1";
                                if (OffSingleplayer.StateDestroy[i] == false)
                                    destr = "0";
                                if (i < 10)
                                    a = "0";
                                else
                                    a = "";
                                CMDbox.SelectedText += Environment.NewLine + a + i + ".    " + Occu1 + "     " + Occu2 + "      " + destr + "    " + OffSingleplayer.NameState[i]; 
                            }
                            for (int i = 0; i < OffMultiplayer.LongInt && MainSettings.Default.ModePlay == 2; i++)
                            {
                                if (OffMultiplayer.OccuState1[i] == true)
                                    Occu1 = "1";
                                if (OffMultiplayer.OccuState1[i] == false)
                                    Occu1 = "0";
                                if (OffMultiplayer.OccuState2[i] == true)
                                    Occu2 = "1";
                                if (OffMultiplayer.OccuState2[i] == false)
                                    Occu2 = "0";
                                if (OffMultiplayer.StateDestroy[i] == true)
                                    destr = "1";
                                if (OffMultiplayer.StateDestroy[i] == false)
                                    destr = "0";
                                if (i < 10)
                                    a = "0";
                                else
                                    a = "";
                                CMDbox.SelectedText += Environment.NewLine + a + i + ".    " + Occu1 + "     " + Occu2 + "      " + destr + "    " + OffMultiplayer.NameState[i];
                            }
                            for (int i = 0; i < OnMultiplayer.LongInt && MainSettings.Default.ModePlay == 3; i++)
                            {
                                if (OnMultiplayer.OccuState1[i] == true)
                                    Occu1 = "1";
                                if (OnMultiplayer.OccuState1[i] == false)
                                    Occu1 = "0";
                                if (OnMultiplayer.OccuState2[i] == true)
                                    Occu2 = "1";
                                if (OnMultiplayer.OccuState2[i] == false)
                                    Occu2 = "0";
                                if (OnMultiplayer.StateDestroy[i] == true)
                                    destr = "1";
                                if (OnMultiplayer.StateDestroy[i] == false)
                                    destr = "0";
                                if (i < 10)
                                    a = "0";
                                else
                                    a = "";
                                CMDbox.SelectedText += Environment.NewLine + a + i + ".    " + Occu1 + "     " + Occu2 + "      " + destr + "    " + OffMultiplayer.NameState[i];
                            }
                        }
                        if (Command == "fullscreen")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            CMDbox.SelectedText += Environment.NewLine + "--must be specificly write--";
                            CMDbox.SelectedText += Environment.NewLine + "FULLSCREEN OFF";
                            CMDbox.SelectedText += Environment.NewLine + "FULLSCREEN ON";
                            CommandExist = true;
                        }
                        if (Command == "fullscreen on")
                        {
                            MainSettings.Default.FullScreen = true;
                            CMDbox.SelectionColor = Color.Blue;
                            CMDbox.SelectedText += Environment.NewLine + "Fullscreen set ON";
                            CommandExist = true;
                        }
                        if (Command == "fullscreen off")
                        {
                            MainSettings.Default.FullScreen = false;
                        CMDbox.SelectionColor = Color.Red;
                        CMDbox.SelectedText += Environment.NewLine + "Fullscreen set OFF";
                            CommandExist = true;
                        }
                        if (Command == "netlog")
                        {
                            CommandExist = true;
                            CMDbox.SelectedText += Environment.NewLine + "---------------------------------";
                            CMDbox.SelectedText += Environment.NewLine + "====NETWORK COMMUNICATION LOG====";
                            CMDbox.SelectedText += Environment.NewLine + "start at: " + System.DateTime.Now;
                            CMDbox.SelectedText += Environment.NewLine + "to end write: CANCEL";
                            CMDbox.SelectedText += Environment.NewLine + "---------------------------------";
                            if (MainSettings.Default.DataRecieve == "" && MainSettings.Default.DataSend == "")
                            {
                                CMDbox.SelectionColor = Color.Red;
                                CMDbox.SelectedText += Environment.NewLine + Environment.NewLine + "COMMUNICATION LOG IS OFFLINE!";
                            }
                            //else
                            LogUpdateTimer.Start(); 
                        }
                        if (Command == "cancel")
                        {
                            CommandExist = true;
                            LogUpdateTimer.Stop();
                            CMDbox.SelectionColor = Color.Lime;
                            CMDbox.SelectedText += Environment.NewLine + "------LOG END------";
                        }
                        if (Command == "app info")
                        {
                            CMDbox.SelectedText += Environment.NewLine + "--- APPLICATION INFORMATION --- ";
                            CMDbox.SelectedText += Environment.NewLine + "game name: " + Application.ProductName;
                            CMDbox.SelectedText += Environment.NewLine + "game version: " + Application.ProductVersion;
                            CMDbox.SelectedText += Environment.NewLine + "storage location: " + System.Environment.CurrentDirectory;
                            CommandExist = true;
                        }
                        if (Command == "feel")
                        {
                            if (MainSettings.Default.ModePlay == 1)
                            {
                                CMDbox.SelectedText += Environment.NewLine + "Feel1: " + OffSingleplayer.Feel1;
                                CMDbox.SelectedText += Environment.NewLine + "Feel2: " + OffSingleplayer.Feel2;
                                CommandExist = true;
                            }
                            if (MainSettings.Default.ModePlay == 2)
                            {
                                CMDbox.SelectedText += Environment.NewLine + "Feel1: " + OffMultiplayer.Feel1;
                                CMDbox.SelectedText += Environment.NewLine + "Feel2: " + OffMultiplayer.Feel2;
                                CommandExist = true;
                            }
                            if (MainSettings.Default.ModePlay == 3)
                            {
                                CMDbox.SelectedText += Environment.NewLine + "Feel1: " + OnMultiplayer.Feel1;
                                CMDbox.SelectedText += Environment.NewLine + "Feel2: " + OnMultiplayer.Feel2;
                                CommandExist = true;
                            }
                        }
                        if (Command == "game info")
                        {
                            if (MainSettings.Default.ModePlay == 1)
                            {
                                CMDbox.SelectedText += Environment.NewLine + "--- GAME INFORMATION --- ";
                                CMDbox.SelectedText += Environment.NewLine + "--- Player first turn: " + OffSingleplayer.TurnFirst;
                                CMDbox.SelectionColor = Color.Black;
                                CMDbox.SelectionBackColor = Color.Blue;
                                CMDbox.SelectedText += Environment.NewLine + "--PLAYER 1--";
                                CMDbox.SelectedText += Environment.NewLine + "name: " + OffSingleplayer.Name1;
                                CMDbox.SelectedText += Environment.NewLine + "capital city: " + OffSingleplayer.StartS1;
                                CMDbox.SelectedText += Environment.NewLine + "money: " + OffSingleplayer.Money1;
                                CMDbox.SelectedText += Environment.NewLine + "------";
                                CMDbox.SelectionColor = Color.Blue;
                                CMDbox.SelectionBackColor = Color.Black;
                                CMDbox.SelectedText += Environment.NewLine + "Population: " + OffSingleplayer.PlayerPopulation1 + Environment.NewLine + "Scientlis: " + OffSingleplayer.Scientist1 + Environment.NewLine + "Mine: " + OffSingleplayer.Mine1 + Environment.NewLine +
                    "Farm: " + OffSingleplayer.Farm1 + Environment.NewLine + "Marrine: " + OffSingleplayer.AtMarrine1 + Environment.NewLine + "Tank: " + OffSingleplayer.AtTank1 + Environment.NewLine +
                    "Fly fither: " + OffSingleplayer.AtPlane1 + Environment.NewLine + "Defensive marine: " + OffSingleplayer.DeMarrine1 + Environment.NewLine + "Bomb Mine: " + OffSingleplayer.DeTank1 + Environment.NewLine +
                    "Antillary: " + OffSingleplayer.DePlane1 + Environment.NewLine + "hacker: " + OffSingleplayer.Hacker1 + Environment.NewLine + "Nuke: " + OffSingleplayer.Nuke1 + Environment.NewLine;
                                CMDbox.SelectedText += Environment.NewLine + "";
                                CMDbox.SelectionColor = Color.Black;
                                CMDbox.SelectionBackColor = Color.Red;
                                CMDbox.SelectedText += Environment.NewLine + "--PLAYER 2--";
                                CMDbox.SelectedText += Environment.NewLine + "name: " + OffSingleplayer.Name2;
                                CMDbox.SelectedText += Environment.NewLine + "capital city: " + OffSingleplayer.StartS2;
                                CMDbox.SelectedText += Environment.NewLine + "money: " + OffSingleplayer.Money2;
                                CMDbox.SelectedText += Environment.NewLine + "------";
                                CMDbox.SelectionColor = Color.Red;
                                CMDbox.SelectionBackColor = Color.Black;
                                CMDbox.SelectedText += Environment.NewLine + "Population: " + OffSingleplayer.PlayerPopulation2 + Environment.NewLine + "Scientlis: " + OffSingleplayer.Scientist2 + Environment.NewLine + "Mine: " + OffSingleplayer.Mine2 + Environment.NewLine +
                    "Farm: " + OffSingleplayer.Farm2 + Environment.NewLine + "Marrine: " + OffSingleplayer.AtMarrine2 + Environment.NewLine + "Tank: " + OffSingleplayer.AtTank2 + Environment.NewLine +
                    "Fly fither: " + OffSingleplayer.AtPlane2 + Environment.NewLine + "Defensive marine: " + OffSingleplayer.DeMarrine2 + Environment.NewLine + "Bomb Mine: " + OffSingleplayer.DeTank2 + Environment.NewLine +
                    "Antillary: " + OffSingleplayer.DePlane2 + Environment.NewLine + "hacker: " + OffSingleplayer.Hacker2 + Environment.NewLine + "Nuke: " + OffSingleplayer.Nuke2 + Environment.NewLine;
                            }
                            if (MainSettings.Default.ModePlay == 2)
                            {
                                CMDbox.SelectedText += Environment.NewLine + "--- GAME INFORMATION --- ";
                                CMDbox.SelectedText += Environment.NewLine + "--- Player first turn: " + OffMultiplayer.TurnFirst;
                                CMDbox.SelectionColor = Color.Black;
                                CMDbox.SelectionBackColor = Color.Blue;
                                CMDbox.SelectedText += Environment.NewLine + "--PLAYER 1--";
                                CMDbox.SelectedText += Environment.NewLine + "name: " + OffMultiplayer.Name1;
                                CMDbox.SelectedText += Environment.NewLine + "capital city: " + OffMultiplayer.StartS1;
                                CMDbox.SelectedText += Environment.NewLine + "money: " + OffMultiplayer.Money1;
                                CMDbox.SelectedText += Environment.NewLine + "------";
                                CMDbox.SelectionColor = Color.Blue;
                                CMDbox.SelectionBackColor = Color.Black;
                                CMDbox.SelectedText += Environment.NewLine + "Population: " + OffMultiplayer.PlayerPopulation1 + Environment.NewLine + "Scientlis: " + OffMultiplayer.Scientist1 + Environment.NewLine + "Mine: " + OffMultiplayer.Mine1 + Environment.NewLine +
                    "Farm: " + OffMultiplayer.Farm1 + Environment.NewLine + "Marrine: " + OffMultiplayer.AtMarrine1 + Environment.NewLine + "Tank: " + OffMultiplayer.AtTank1 + Environment.NewLine +
                    "Fly fither: " + OffMultiplayer.AtPlane1 + Environment.NewLine + "Defensive marine: " + OffMultiplayer.DeMarrine1 + Environment.NewLine + "Bomb Mine: " + OffMultiplayer.DeTank1 + Environment.NewLine +
                    "Antillary: " + OffMultiplayer.DePlane1 + Environment.NewLine + "hacker: " + OffMultiplayer.Hacker1 + Environment.NewLine + "Nuke: " + OffMultiplayer.Nuke1 + Environment.NewLine;
                                CMDbox.SelectedText += Environment.NewLine + "";
                                CMDbox.SelectionColor = Color.Black;
                                CMDbox.SelectionBackColor = Color.Red;
                                CMDbox.SelectedText += Environment.NewLine + "--PLAYER 2--";
                                CMDbox.SelectedText += Environment.NewLine + "name: " + OffMultiplayer.Name2;
                                CMDbox.SelectedText += Environment.NewLine + "capital city: " + OffMultiplayer.StartS2;
                                CMDbox.SelectedText += Environment.NewLine + "money: " + OffMultiplayer.Money2;
                                CMDbox.SelectedText += Environment.NewLine + "------";
                                CMDbox.SelectionColor = Color.Red;
                                CMDbox.SelectionBackColor = Color.Black;
                                CMDbox.SelectedText += Environment.NewLine + "Population: " + OffMultiplayer.PlayerPopulation2 + Environment.NewLine + "Scientlis: " + OffMultiplayer.Scientist2 + Environment.NewLine + "Mine: " + OffMultiplayer.Mine2 + Environment.NewLine +
                    "Farm: " + OffMultiplayer.Farm2 + Environment.NewLine + "Marrine: " + OffMultiplayer.AtMarrine2 + Environment.NewLine + "Tank: " + OffMultiplayer.AtTank2 + Environment.NewLine +
                    "Fly fither: " + OffMultiplayer.AtPlane2 + Environment.NewLine + "Defensive marine: " + OffMultiplayer.DeMarrine2 + Environment.NewLine + "Bomb Mine: " + OffMultiplayer.DeTank2 + Environment.NewLine +
                    "Antillary: " + OffMultiplayer.DePlane2 + Environment.NewLine + "hacker: " + OffMultiplayer.Hacker2 + Environment.NewLine + "Nuke: " + OffMultiplayer.Nuke2 + Environment.NewLine;
                            }
                            if (MainSettings.Default.ModePlay == 3)
                            {
                                CMDbox.SelectedText += Environment.NewLine + "--- GAME INFORMATION --- ";
                                CMDbox.SelectedText += Environment.NewLine + "--- Player first turn: " + OnMultiplayer.TurnFirst;
                                CMDbox.SelectionColor = Color.Black;
                                CMDbox.SelectionBackColor = Color.Blue;
                                CMDbox.SelectedText += Environment.NewLine + "--PLAYER 1--";
                                CMDbox.SelectedText += Environment.NewLine + "name: " + OnMultiplayer.Name1;
                                CMDbox.SelectedText += Environment.NewLine + "capital city: " + OnMultiplayer.StartS1;
                                CMDbox.SelectedText += Environment.NewLine + "money: " + OnMultiplayer.Money1;
                                CMDbox.SelectedText += Environment.NewLine + "------";
                                CMDbox.SelectionColor = Color.Blue;
                                CMDbox.SelectionBackColor = Color.Black;
                                CMDbox.SelectedText += Environment.NewLine + "Population: " + OnMultiplayer.PlayerPopulation1 + Environment.NewLine + "Scientlis: " + OnMultiplayer.Scientist1 + Environment.NewLine + "Mine: " + OnMultiplayer.Mine1 + Environment.NewLine +
                    "Farm: " + OnMultiplayer.Farm1 + Environment.NewLine + "Marrine: " + OnMultiplayer.AtMarrine1 + Environment.NewLine + "Tank: " + OnMultiplayer.AtTank1 + Environment.NewLine +
                    "Fly fither: " + OnMultiplayer.AtPlane1 + Environment.NewLine + "Defensive marine: " + OnMultiplayer.DeMarrine1 + Environment.NewLine + "Bomb Mine: " + OnMultiplayer.DeTank1 + Environment.NewLine +
                    "Antillary: " + OnMultiplayer.DePlane1 + Environment.NewLine + "hacker: " + OnMultiplayer.Hacker1 + Environment.NewLine + "Nuke: " + OnMultiplayer.Nuke1 + Environment.NewLine;
                                CMDbox.SelectedText += Environment.NewLine + "";
                                CMDbox.SelectionColor = Color.Black;
                                CMDbox.SelectionBackColor = Color.Red;
                                CMDbox.SelectedText += Environment.NewLine + "--PLAYER 2--";
                                CMDbox.SelectedText += Environment.NewLine + "name: " + OnMultiplayer.Name2;
                                CMDbox.SelectedText += Environment.NewLine + "capital city: " + OnMultiplayer.StartS2;
                                CMDbox.SelectedText += Environment.NewLine + "money: " + OnMultiplayer.Money2;
                                CMDbox.SelectedText += Environment.NewLine + "------";
                                CMDbox.SelectionColor = Color.Red;
                                CMDbox.SelectionBackColor = Color.Black;
                                CMDbox.SelectedText += Environment.NewLine + "Population: " + OnMultiplayer.PlayerPopulation2 + Environment.NewLine + "Scientlis: " + OnMultiplayer.Scientist2 + Environment.NewLine + "Mine: " + OnMultiplayer.Mine2 + Environment.NewLine +
                    "Farm: " + OnMultiplayer.Farm2 + Environment.NewLine + "Marrine: " + OnMultiplayer.AtMarrine2 + Environment.NewLine + "Tank: " + OnMultiplayer.AtTank2 + Environment.NewLine +
                    "Fly fither: " + OnMultiplayer.AtPlane2 + Environment.NewLine + "Defensive marine: " + OnMultiplayer.DeMarrine2 + Environment.NewLine + "Bomb Mine: " + OnMultiplayer.DeTank2 + Environment.NewLine +
                    "Antillary: " + OnMultiplayer.DePlane2 + Environment.NewLine + "hacker: " + OnMultiplayer.Hacker2 + Environment.NewLine + "Nuke: " + OnMultiplayer.Nuke2 + Environment.NewLine;
                            }
                            CommandExist = true;
                        }
                        if (Command == "app")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        CMDbox.SelectedText += Environment.NewLine + "--must be specificly write--";
                        CMDbox.SelectedText += Environment.NewLine + "APP INFO";
                        CMDbox.SelectedText += Environment.NewLine + "APP RESTART";
                        CMDbox.SelectedText += Environment.NewLine + "APP EXIT";
                            CommandExist = true;
                        }
                        if (Command == "app restart")
                        {
                            CommandExist = true;
                            Application.Restart();
                        }
                        if (Command == "logo")
                        {
                        CMDbox.SelectedText += Environment.NewLine + @"*******************************************************************";
                        CMDbox.SelectedText += Environment.NewLine + @" ____   __   __   _   _   ____   _____   _____   _   ____   __   _ ";
                        CMDbox.SelectedText += Environment.NewLine + @"/    \ / _\ / _\ | | | | | /\ \ /  _  \ |_   _| | | /    \ |  \ | |";
                        CMDbox.SelectedText += Environment.NewLine + @"| || | ||   ||   | | | | | \/_| | |_| |   | |   | | | || | | \ \| |";
                        CMDbox.SelectedText += Environment.NewLine + @"| || | ||_  ||_  | |_| | | |    |  _  |   | |   | | | || | | |\   |";
                        CMDbox.SelectedText += Environment.NewLine + @"\____/ \__/ \__/ \_____/ |_|    |_| |_|   |_|   |_| \____/ |_| \__|";
                        CMDbox.SelectedText += Environment.NewLine + @"-------------------------------------------------------------------";
                        CMDbox.SelectedText += Environment.NewLine + @" ____   _____         ___   _____   _____   _____   ____   ___     ";
                        CMDbox.SelectedText += Environment.NewLine + @"/    \ |  ___|       /   \ |_   _| /  _  \ |_   _| |  __| /   \";
                        CMDbox.SelectedText += Environment.NewLine + @"| || | |  ___|       |  \    | |   | |_| |   | |   | |__| |  \ ";
                        CMDbox.SelectedText += Environment.NewLine + @"| || | | |            \  \   | |   |  _  |   | |   | |__|  \  \";
                        CMDbox.SelectedText += Environment.NewLine + @"\____/ |_|           |___/   |_|   |_| |_|   |_|   |____| |___/";
                        CMDbox.SelectedText += Environment.NewLine + @"";
                        CMDbox.SelectedText += Environment.NewLine + @"*******************************************************************";
                        CMDbox.SelectedText += Environment.NewLine + @"*************************--THE GAME--******************************";
                        CMDbox.SelectedText += Environment.NewLine + @"*******************************************************************";
                            CommandExist = true;
                        }
                        if (Command == "secret")
                        {
                            CommandExist = true;
                            CMDbox.SelectedText += Environment.NewLine + @"          ______";
                            CMDbox.SelectedText += Environment.NewLine + @"---------|SECRET|---------";
                            CMDbox.SelectedText += Environment.NewLine + @"         |______|";
                            CMDbox.SelectedText += Environment.NewLine + @"             ┌───┐";
                            CMDbox.SelectedText += Environment.NewLine + @"When you win |***| and dog war";
                            CMDbox.SelectedText += Environment.NewLine + @"             └───┘       ┌────┐ ";
                            CMDbox.SelectedText += Environment.NewLine + @"you need place to middle |*O**| ";
                            CMDbox.SelectedText += Environment.NewLine + @"                 ┌─────┐ └────┘  ┌───────┐";
                            CMDbox.SelectedText += Environment.NewLine + @"and when you get |*****| you are |V******|";
                            CMDbox.SelectedText += Environment.NewLine + @"                 └─────┘┌────┐   └───────┘ ";
                            CMDbox.SelectedText += Environment.NewLine + @"because this is your. . |***M|";
                            CMDbox.SelectedText += Environment.NewLine + @"                        └────┘";
                            CMDbox.SelectedText += Environment.NewLine + @"-------------------------";
                        }
                        if (Command == "credit")
                        {
                            CommandExist = true;
                            CMDbox.SelectionColor = Color.Gold;
                            CMDbox.SelectedText += Environment.NewLine + @"The game is by henry005cz and eSHADAP";
                        }
                        if (Command == "doom")
                        {
                            CommandExist = true;
                            CMDbox.SelectionColor = Color.OrangeRed;
                            CMDbox.SelectedText += Environment.NewLine + @"______  _____  _____ ___  ___";
                            CMDbox.SelectedText += Environment.NewLine + @"|  _  \|  _  ||  _  ||  \/  |";
                            CMDbox.SelectedText += Environment.NewLine + @"| | | || | | || | | || .  . |";
                            CMDbox.SelectedText += Environment.NewLine + @"| | | || | | || | | || |\/| |";
                            CMDbox.SelectedText += Environment.NewLine + @"| |/ / \ \_/ /\ \_/ /| |  | |";
                            CMDbox.SelectedText += Environment.NewLine + @"|___/   \___/  \___/ \_|  |_/";
                        }
                        if (Command == "ac/dc")
                        {
                            CommandExist = true;
                        CMDbox.SelectedText += Environment.NewLine + @"-------------------------------------";
                        CMDbox.SelectedText += Environment.NewLine + @" _____   ___   __     _____   ___    ";
                        CMDbox.SelectedText += Environment.NewLine + @"/  _  \ /  _\  \ \   |  _  \ /  _\   ";
                        CMDbox.SelectedText += Environment.NewLine + @"| |_| | | |    _\ \  | | | | | |     ";
                        CMDbox.SelectedText += Environment.NewLine + @"|  _  | | |__  \  _\ | | | | | |_    ";
                        CMDbox.SelectedText += Environment.NewLine + @"|_| |_| \___/   \_\  |_____/ \___/   ";
                        CMDbox.SelectedText += Environment.NewLine + @"----------==ROCK AND ROLL==----------";
                        }
                    if (Command == "cat")
                    {
                        CommandExist = true;
                        CMDbox.SelectionColor = Color.Cyan;
                        CMDbox.SelectedText += Environment.NewLine + @"**************************";
                        CMDbox.SelectedText += Environment.NewLine + @"*****/\************/\*****";
                        CMDbox.SelectedText += Environment.NewLine + @"****/  \**********/  \****";
                        CMDbox.SelectedText += Environment.NewLine + @"***/    ----------    \***";
                        CMDbox.SelectedText += Environment.NewLine + @"**|                    |**";
                        CMDbox.SelectedText += Environment.NewLine + @"**|   _            _   |**";
                        CMDbox.SelectedText += Environment.NewLine + @"**|  /•\          /•\  |**";
                        CMDbox.SelectedText += Environment.NewLine + @"**|  \_/          \_/  |**";
                        CMDbox.SelectedText += Environment.NewLine + @"**|  -~--- _  _ ~~--~  |**";
                        CMDbox.SelectedText += Environment.NewLine + @"**\ --~  _/ \/ \_  -~- /**";
                        CMDbox.SelectedText += Environment.NewLine + @"***\     \__||__/     /***";
                        CMDbox.SelectedText += Environment.NewLine + @"****\                /****";
                        CMDbox.SelectedText += Environment.NewLine + @"*****|    ______    |*****";
                        CMDbox.SelectedText += Environment.NewLine + @"*****|---< K  M >---|*****";
                        CMDbox.SelectedText += Environment.NewLine + @"*****|    \____/    |*****";
                    }
                    if (Command == "victory")
                    {
                        CommandExist = true;
                        CMDbox.SelectionColor = Color.Yellow;
                        CMDbox.SelectedText += Environment.NewLine + @"********************";
                        CMDbox.SelectedText += Environment.NewLine + @"*_*******__*******_*";
                        CMDbox.SelectedText += Environment.NewLine + @"*\\*****/__\*****//*";
                        CMDbox.SelectedText += Environment.NewLine + @"**\\***//**\\***//**";
                        CMDbox.SelectedText += Environment.NewLine + @"***\\_//****\\_//***";
                        CMDbox.SelectedText += Environment.NewLine + @"****\_/******\_/****";
                        CMDbox.SelectedText += Environment.NewLine + @"********************";
                    }
                    if (Command == "cls")
                        {
                        CommandExist = true;
                        CMDbox.Text = null;
                        }
                        if (CommandExist == false)
                        {
                            CMDbox.SelectionColor = Color.Red;
                            CMDbox.SelectedText += Environment.NewLine + "this command is unknown | " + Command;
                            CMDbox.SelectedText += Environment.NewLine +  "write |list| to all commands";
                            CMDbox.SelectionColor = Color.Lime;
                        }
                        CommandExist = false;
                    CMDbox.SelectionStart = CMDbox.Text.Length;
                    CMDbox.ScrollToCaret();
                        if (Command == "exit")
                        {
                            CommandExist = true;
                            this.Close();
                        }
                        break;
                }
        }

        private void MinigameTimer_Tick(object sender, EventArgs e)
        {
            CMDbox.Text = null;

        }

        private void CMDtext_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameMode == true)
            switch (e.KeyCode)
            {
                    case Keys.Escape:
                        ExplosionTimer.Stop();
                        GameMode = false;
                        Minute = 3;
                        Second = 0;
                        MiliSecond = 0;
                        GameIsOnline = false;
                        CMDbox.Text = null;
                        break;
                    case Keys.Enter:
                        if (GameIsOnline == false)
                        {
                            Minute = 3;
                            Second = 0;
                            MiliSecond = 0;
                            FocusNumCode = 0;
                            for(int i = 1; i <= 9; i++)
                            {
                                FocusNumCode++;
                                AnsverCode[FocusNumCode] = Convert.ToString( rand.Next(0, 10));
                                DisplayCode[FocusNumCode] = "*";
                            }
                            FocusNumCode = 1;
                            ExplosionTimer.Start();
                            GameIsOnline = true;
                        }
                        break;
                    case Keys.NumPad0:
                        NumCode = "0";
                        break;
                    case Keys.NumPad1:
                        NumCode = "1";
                        break;
                    case Keys.NumPad2:
                        NumCode = "2";
                        break;
                    case Keys.NumPad3:
                        NumCode = "3";
                        break;
                    case Keys.NumPad4:
                        NumCode = "4";
                        break;
                    case Keys.NumPad5:
                        NumCode = "5";
                        break;
                    case Keys.NumPad6:
                        NumCode = "6";
                        break;
                    case Keys.NumPad7:
                        NumCode = "7";
                        break;
                    case Keys.NumPad8:
                        NumCode = "8";
                        break;
                    case Keys.NumPad9:
                        NumCode = "9";
                        break;
                }
        }

        private void ExplosionTimer_Tick(object sender, EventArgs e)
        {
            CMDtext.Text = null;
            MiliSecond -= 1;
            if (MiliSecond < 1 && Second > 0)
            {
                Second -= 1;
                MiliSecond = 10;
            }
            if (Second < 1 && Minute > 0)
            {
                Minute -= 1;
                Second = 60;
            }

            if (MiliSecond < 10)
                sMiliSecond = "0" + Convert.ToString(MiliSecond);
            else
                sMiliSecond = Convert.ToString(MiliSecond);
            if (Second < 10)
                sSecond = "0" + Convert.ToString(Second);
            else
                sSecond = Convert.ToString(Second);
            if (Minute < 10)
                sMinute = "0" + Convert.ToString(Minute);

            RemainingTime = sMinute + ":" + sSecond + ":" + sMiliSecond;

            Bomb[26] = @"|  | " + NumCode + " |    |  " + RemainingTime + "  |  |";
            //
            if (NumCode == AnsverCode[FocusNumCode])
            {
                DisplayCode[FocusNumCode] = AnsverCode[FocusNumCode];
                FocusNumCode++;
            }


            BombCode = DisplayCode[1] + " " + DisplayCode[2] + " " + DisplayCode[3] + " " + DisplayCode[4] + " " + DisplayCode[5] 
                + " " + DisplayCode[6] + " " + DisplayCode[7] + " " + DisplayCode[8] + " " + DisplayCode[9];

            Bomb[4] = @"|   | " + BombCode + " |   |";
            //
            BombChunk = 0;
            CMDbox.Text = null;
            for (int DoThirty = 0; DoThirty < 28; DoThirty++)
            {
                BombChunk++;
                CMDbox.SelectedText += Bomb[BombChunk] + Environment.NewLine;
            }

            if (FocusNumCode > 9)
            {
                ExplosionTimer.Stop();
                GameIsOnline = false;
                GameMode = false;
                BombCode = "     CANCELED    ";
                Bomb[4] = @"|   | " + BombCode + " |   |";
                BombChunk = 0;
                CMDbox.Text = null;
                for (int DoThirty = 0; DoThirty < 28; DoThirty++)
                {
                    BombChunk++;
                    CMDbox.SelectedText += Bomb[BombChunk] + Environment.NewLine;
                }
            }
            if (Minute == 0 && Second == 0 && MiliSecond == 0)
            {
                ExplosionTimer.Stop();
                GameIsOnline = false;
                GameMode = false;
                CMDbox.Text = null;
                CMDbox.SelectedText += @"                               ________________
                          ____/ (  (    )   )  \___
                         /( (  (  )   _    ))  )   )\
                       ((     (   )(    )  )   (   )  )
                     ((/  ( _(   )   (   _) ) (  () )  )
                    ( (  ( (_)   ((    (   )  .((_ ) .  )_
                   ( (  )    (      (  )    )   ) . ) (   )
                  (  (   (  (   ) (  _  ( _) ).  ) . ) ) ( )
                  ( (  (   ) (  )   (  ))     ) _)(   )  )  )
                 ( (  ( \ ) (    (_  ( ) ( )  )   ) )  )) ( )
                  (  (   (  (   (_ ( ) ( _    )  ) (  )  )   )
                 ( (  ( (  (  )     (_  )  ) )  _)   ) _( ( )
                  ((  (   )(    (     _    )   _) _(_ (  (_ )
                   (_((__(_(__(( ( ( |  ) ) ) )_))__))_)___)
                   ((__)        \|\|lll|l|||/|          \_))
                            (   /(/ (  )  ) )\   )
                          (    ( ( ( | | ) ) )\   )
                           (   /(| / ( )) ) ) )) )
                         (     ( ((((_(|)_)))))     )
                          (      ||\(|(|)|/||     )
                        (        |(||(||)||||        )
                          (     //|/l|||)|\\ \     )
                        (/ / //  /|//||||\\  \ \  \ _)
-------------------------------------------------------------------------------
                                 GAME OVER";
            }

        }

        private void LogUpdateTimer_Tick(object sender, EventArgs e)
        {
            string dataR = "";
            string dataS = "";
            if (MainSettings.Default.DataRecieve != dataR)
            {
                CMDbox.SelectionColor = Color.AliceBlue;
                CMDbox.SelectedText += Environment.NewLine + "Recived: " + MainSettings.Default.DataRecieve;
            }
            if (MainSettings.Default.DataSend != dataS)
            {
                CMDbox.SelectionColor = Color.DarkBlue;
                CMDbox.SelectedText += Environment.NewLine + "Send: " + MainSettings.Default.DataSend;
            }

            dataR = MainSettings.Default.DataRecieve;
            dataS = MainSettings.Default.DataSend;

            CMDbox.SelectionStart = CMDbox.Text.Length;
            CMDbox.ScrollToCaret();
        }
    }
}
