using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Occupation_of_states
{
    public partial class CreatorMap : Form
    {
        public CreatorMap()
        {
            InitializeComponent();
            bm = new Bitmap(PaintMap.Width, PaintMap.Height);
            kp = Graphics.FromImage(bm);
            kp.Clear(Color.White);
            PaintMap.Image = bm;

            bm1 = new Bitmap(PaintFlag.Width, PaintFlag.Height);
            kp1 = Graphics.FromImage(bm1);
            kp1.Clear(Color.White);
            PaintFlag.Image = bm1;
        }
        Bitmap bm, bm1;
        Graphics kp, kp1;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen Eraser = new Pen(Color.White, 10);
        int ToolUse = 1;
        bool setpoint = false;
        bool Border = false;

        ColorDialog cd = new ColorDialog();
        //CREATE INFORMATION
        string MapName = " ", PathMap, PathFlag, CoinChar;
        int ID = 0, maxID = 0;
        string[] NameState = new string[1];
        string[] CapitalCity = new string[1];
        int[] Population = new int[1];
        int[] Mining = new int[1];
        int[] Farming = new int[1];
        Point[] SPoint = new Point[1];

        //END

        private void PaintMap_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            if (ToolUse == 2 && setpoint == false)
            {
                new FillColorClass().FloodFill(ref bm, ColorMap.BackColor, new Point(e.X, e.Y));
                PaintMap.Image = bm;
            }
            if (setpoint)
            {
                setpoint = false;
                PaintMap.Cursor = Cursors.Cross;
                //PositionBox.Left = PaintMap.Left + Convert.ToInt32(PointXBox.Value);
                PositionBox.Left = e.X + PaintMap.Width;
                PositionBox.Top = e.Y + PaintMap.Height;
                PointXBox.Value = e.X;
                PointYBox.Value = e.Y;
            }
        }

        private void PaintMap_MouseMove(object sender, MouseEventArgs e)
        { try
            {
                Err1.Visible = false;
                if (paint && setpoint == false)
                    if (p.Color == BorderBox.BackColor || p.Color == StateBox.BackColor || p.Color == CloseBox.BackColor || p.Color == EmptyBox.BackColor)
                    {
                        Bitmap bm = (Bitmap)PaintMap.Image;
                        if (ToolUse == 1)
                        {
                            px = e.Location;
                            kp.DrawLine(p, px, py);
                            py = px;
                        }

                        if (ToolUse == 3)
                        {
                            px = e.Location;
                            kp.DrawLine(Eraser, px, py);
                            py = px;
                        }
                        PaintMap.Image = bm;
                        kp = Graphics.FromImage(bm);
                        PaintMap.Refresh();
                    }
            }
            catch { Err1.Visible = true; }
        }

        private void PaintMap_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        private void btnPencil_Click(object sender, EventArgs e)
        {
            ToolUse = 1;
        }

        private void MapSettings_TextChanged(object sender, EventArgs e)
        {
            MapName = MapNameBox.Text;
            //PathMap = MapPathBox.Text;
            //PathFlag = FlagPathBox.Text;
            CoinChar = CoinBox.Text;
        }

        private void Properties_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NameState[ID] = NameBox.Text;
                CapitalCity[ID] = CityBox.Text;
                Population[ID] = Convert.ToInt32(PopulationBox.Value);
                Mining[ID] = Convert.ToInt32(MiningBox.Value);
                Farming[ID] = Convert.ToInt32(FarmingBox.Value);
                SPoint[ID] = new Point(Convert.ToInt32(PointXBox.Value), Convert.ToInt32(PointYBox.Value));
            }
            catch { return; }
        }

        private void IDBox_ValueChanged(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(IDBox.Value);
            IDBox1.Value = ID;
            ZNameBox.Text = NameState[ID];

            NameBox.Text = NameState[ID];
            CityBox.Text = CapitalCity[ID];
            PopulationBox.Value = Population[ID];
            MiningBox.Value = Mining[ID];
            FarmingBox.Value = Farming[ID];
            PointXBox.Value = SPoint[ID].X;
            PointYBox.Value = SPoint[ID].Y;

            PositionBox.Left = PaintMap.Left + Convert.ToInt32(PointXBox.Value);
            PositionBox.Top = PaintMap.Top + Convert.ToInt32(PointYBox.Value);

            PaintFlag.Left = FlagPoint.Left - (85 * ID);
        }

        private void IDBox1_ValueChanged(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(IDBox1.Value);
            IDBox.Value = ID ;
            ZNameBox.Text = NameState[ID];

            NameBox.Text = NameState[ID];
            CityBox.Text = CapitalCity[ID];
            PopulationBox.Value = Population[ID];
            MiningBox.Value = Mining[ID];
            FarmingBox.Value = Farming[ID];
            PointXBox.Value = SPoint[ID].X;
            PointYBox.Value = SPoint[ID].Y;

            PositionBox.Left = PaintMap.Left + Convert.ToInt32(PointXBox.Value);
            PositionBox.Top = PaintMap.Top + Convert.ToInt32(PointYBox.Value);

            PaintFlag.Left = FlagPoint.Left - (85 * ID);
        }

        private void BtnSetPoint_Click(object sender, EventArgs e)
        {
            setpoint = true;
            PaintMap.Cursor = Cursors.Hand;
        }

        private void SetIDBox_ValueChanged(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(SetIDBox.Value);
            maxID = Convert.ToInt32(SetIDBox.Value);
            IDBox.Maximum = ID - 1;
            IDBox1.Maximum = ID - 1;
            NameState = new string[ID];
            CapitalCity = new string[ID];
            Population = new int[ID];
            Mining = new int[ID];
            Farming = new int[ID];
            SPoint = new Point[ID];

            PaintFlag.Width = ID * 85;

            bm1 = new Bitmap(ID * 85, PaintFlag.Height);
            kp1 = Graphics.FromImage(bm1);
            PaintFlag.Image = bm1;
        }

        private void SizeBox_ValueChanged(object sender, EventArgs e)
        {
            PaintMap.Width = Convert.ToInt32(SizeXBox.Value);
            PaintMap.Height = Convert.ToInt32(SizeYBox.Value);
            PointXBox.Maximum = SizeXBox.Value;
            PointYBox.Maximum = SizeYBox.Value;
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            ToolUse = 2;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you realy want to clear your map?", "Clear Map", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                kp = Graphics.FromImage(bm);
                kp.Clear(Color.White);
                PaintMap.Image = bm;
            }
        }

        private void PointBox_ValueChanged(object sender, EventArgs e)
        {
            PositionBox.Left = PaintMap.Left + Convert.ToInt32(PointXBox.Value);
            PositionBox.Top = PaintMap.Top + Convert.ToInt32(PointYBox.Value);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
                PositionBox.Visible = false;
            else
                PositionBox.Visible = true;
        }

        private void BorderBox_Click(object sender, EventArgs e)
        {
            p.Color = BorderBox.BackColor;
            ColorMap.BackColor = BorderBox.BackColor;
        }

        private void StateBox_Click(object sender, EventArgs e)
        {
            p.Color = StateBox.BackColor;
            ColorMap.BackColor = StateBox.BackColor;
        }

        private void CloseBox_Click(object sender, EventArgs e)
        {
            p.Color = CloseBox.BackColor;
            ColorMap.BackColor = CloseBox.BackColor;
        }

        private void EmptyBox_Click(object sender, EventArgs e)
        {
            p.Color = EmptyBox.BackColor;
            ColorMap.BackColor = EmptyBox.BackColor;
        }

        private void FlagBorder_MouseEnter(object sender, EventArgs e)
        {
            Border = true;
        }

        private void FlagBorder_MouseLeave(object sender, EventArgs e)
        {
            Border = false;
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.ShowDialog();
            MainSettings.Default.LoadPathText = openfile.InitialDirectory + openfile.FileName;
            String word = "1";
            int i = 0;
            char c;
            int phase = 0;
            int X = 0, Y = 0;
            StreamReader reader = new StreamReader(MainSettings.Default.LoadPathText);
            try
            {
                do
                {
                    for (; phase < 5;)
                    {
                        c = Convert.ToChar(reader.Read());
                        word += c;
                        if (phase == 0 && c != '|')
                            MapName = word;
                        if (phase == 1 && c != '|')
                            PathMap = word;
                        if (phase == 2 && c != '|')
                            PathFlag = word;
                        if (phase == 3 && c != '|')
                        {
                            MapNameBox.Text = MapName;
                            ID = Convert.ToInt32(word);
                            NameState = new string[ID];
                            Population = new int[ID];
                            CapitalCity = new string[ID];
                            Mining = new int[ID];
                            Farming = new int[ID];
                            SPoint = new Point[ID];
                            if (ID > 1)
                            {
                                IDBox.Maximum = ID - 1;
                                IDBox1.Maximum = ID - 1;
                                SetIDBox.Value = ID;
                            }
                        }
                        if (phase == 4 && c != '|')
                            CoinBox.Text = word;
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
                        Mining[i] = Convert.ToInt32(word);
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
                        Farming[i] = Convert.ToInt32(word);
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
                            SPoint[i] = new Point(X, Y);
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
                } while (c != '/' && i < ID * 2);
            }
            catch
            {
                MessageBox.Show("Map file is corrupted!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void LoadBox2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.ShowDialog();
                string MapPath = openfile.InitialDirectory + openfile.FileName;
                PaintMap.Image = (Bitmap)Image.FromFile(MapPath);
                PaintMap.Width = bm.Width;
                PaintMap.Height = bm.Height;
            } catch { }
        }

        private void LoadBox3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.ShowDialog();
                string FlagPath = openfile.InitialDirectory + openfile.FileName;
                PaintFlag.Image = (Bitmap)Image.FromFile(FlagPath);
                PaintFlag.Width = bm1.Width;
            } catch { }
        }

        private void SaveMap_Click(object sender, EventArgs e)
        {
            Image imageToConvert = null;
            if (!Directory.Exists(Application.StartupPath + @"\map_data_created"))
                Directory.CreateDirectory("map_data_created");

            imageToConvert = bm;
            saveFileDialogMap.InitialDirectory = Application.StartupPath + @"\map_data_created\";
            saveFileDialogMap.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialogMap.FileName = MapName + "_map.png";
            if (saveFileDialogMap.ShowDialog() == DialogResult.OK)
            {
                imageToConvert.Save(saveFileDialogMap.FileName);
                imageToConvert.Dispose();
            }

            imageToConvert = bm1;
            saveFileDialogFlag.InitialDirectory = Application.StartupPath + @"\map_data_created\";
            saveFileDialogFlag.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialogFlag.FileName = MapName + "_flag.png";
            if (saveFileDialogFlag.ShowDialog() == DialogResult.OK)
            {
                imageToConvert.Save(saveFileDialogFlag.FileName);
                imageToConvert.Dispose();
            }

            saveFileDialogText.InitialDirectory = Application.StartupPath + @"\map_data_created\";
            saveFileDialogText.Filter = "dat files (*.dat)|*.dat|All file (*.*)|*.*";
            saveFileDialogText.FileName = MapName;
            if (saveFileDialogText.ShowDialog() == DialogResult.OK)
            {
                string text;
                StreamWriter writer = new StreamWriter(saveFileDialogText.OpenFile());
                text = MapName + "|" + @"\map_data_created\" + saveFileDialogMap.FileName + "|" + @"\map_data_created\" + saveFileDialogFlag.FileName + "|" + maxID + "|" + CoinChar + "|";
                for (int i = 0; i < maxID; i++)
                    text += NameState[i] + "-";
                text = text.Substring(0, text.Length - 1);
                text += "|";

                for (int i = 0; i < maxID; i++)
                    text += Population[i] + "-";
                text = text.Substring(0, text.Length - 1);
                text += "|";

                for (int i = 0; i < maxID; i++)
                    text += CapitalCity[i] + "-";
                text = text.Substring(0, text.Length - 1);
                text += "|";

                for (int i = 0; i < maxID; i++)
                    text += Mining[i] + "-";
                text = text.Substring(0, text.Length - 1);
                text += "|";

                for (int i = 0; i < maxID; i++)
                    text += Farming[i] + "-";
                text = text.Substring(0, text.Length - 1);
                text += "|";

                for (int i = 0; i < maxID; i++)
                    text += SPoint[i] + "-";
                text = text.Substring(0, text.Length - 1);
                text += "/";

                writer.Write(text);

                writer.Dispose();
                writer.Close();

            }
        }

        private void BtnEraser_Click(object sender, EventArgs e)
        {
            ToolUse = 3;
        }

        private void BtnChangeColor_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            p.Color = cd.Color;
            ColorMap.BackColor = cd.Color;
        }

        private void PaintFlag_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            if (ToolUse == 2 && setpoint == false)
            {
                new FillColorClass().FloodFill(ref bm1, ColorMap.BackColor, new Point(e.X, e.Y));
                PaintFlag.Image = bm1;
            }
        }

        private void PaintFlag_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint && setpoint == false && !Border)
            {
                Bitmap bm1 = (Bitmap)PaintFlag.Image;
                if (ToolUse == 1)
                {
                    px = e.Location;
                    kp1.DrawLine(p, px, py);
                    py = px;
                }

                if (ToolUse == 3)
                {
                    px = e.Location;
                    kp1.DrawLine(Eraser, px, py);
                    py = px;
                }
                PaintFlag.Image = bm1;
                kp1 = Graphics.FromImage(bm1);
                PaintFlag.Refresh();
            }
        }

        private void PaintFlag_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                SizeXBox.Enabled = true;
                SizeYBox.Enabled = true;
            } else
            {
                SizeXBox.Enabled = false;
                SizeYBox.Enabled = false;
            }
        }


    }
}
