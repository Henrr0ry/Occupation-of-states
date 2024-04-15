
namespace Occupation_of_states
{
    partial class MainMenu
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.bntMultiplayerOff = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.PlayPanel = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnSingleplayer = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMultiplayerOn = new System.Windows.Forms.Button();
            this.BtnCreatorMap = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.PlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bntMultiplayerOff
            // 
            this.bntMultiplayerOff.BackColor = System.Drawing.SystemColors.Control;
            this.bntMultiplayerOff.BackgroundImage = global::Occupation_of_states.Properties.Resources.BtnLong1;
            this.bntMultiplayerOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bntMultiplayerOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntMultiplayerOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bntMultiplayerOff.Location = new System.Drawing.Point(14, 63);
            this.bntMultiplayerOff.Name = "bntMultiplayerOff";
            this.bntMultiplayerOff.Size = new System.Drawing.Size(380, 50);
            this.bntMultiplayerOff.TabIndex = 1;
            this.bntMultiplayerOff.Text = "offline Multiplayer";
            this.bntMultiplayerOff.UseVisualStyleBackColor = false;
            this.bntMultiplayerOff.Click += new System.EventHandler(this.btnMultiplayerOff_Click);
            this.bntMultiplayerOff.MouseEnter += new System.EventHandler(this.bntMultiplayerOff_MouseEnter);
            this.bntMultiplayerOff.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MainPanel.Controls.Add(this.PlayPanel);
            this.MainPanel.Controls.Add(this.BtnCreatorMap);
            this.MainPanel.Controls.Add(this.btnPlay);
            this.MainPanel.Controls.Add(this.pictureBox1);
            this.MainPanel.Controls.Add(this.BtnExit);
            this.MainPanel.Controls.Add(this.btnSettings);
            this.MainPanel.Location = new System.Drawing.Point(117, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(827, 714);
            this.MainPanel.TabIndex = 1;
            this.MainPanel.Visible = false;
            // 
            // PlayPanel
            // 
            this.PlayPanel.Controls.Add(this.pictureBox4);
            this.PlayPanel.Controls.Add(this.pictureBox2);
            this.PlayPanel.Controls.Add(this.pictureBox3);
            this.PlayPanel.Controls.Add(this.btnSingleplayer);
            this.PlayPanel.Controls.Add(this.btnBack);
            this.PlayPanel.Controls.Add(this.bntMultiplayerOff);
            this.PlayPanel.Controls.Add(this.btnMultiplayerOn);
            this.PlayPanel.Location = new System.Drawing.Point(200, 419);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(415, 236);
            this.PlayPanel.TabIndex = 5;
            this.PlayPanel.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Occupation_of_states.Properties.Resources.PvPOn;
            this.pictureBox4.Location = new System.Drawing.Point(34, 124);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(80, 40);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Occupation_of_states.Properties.Resources.PvB;
            this.pictureBox2.Location = new System.Drawing.Point(34, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 40);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Occupation_of_states.Properties.Resources.PvPOff;
            this.pictureBox3.Location = new System.Drawing.Point(34, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 40);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // btnSingleplayer
            // 
            this.btnSingleplayer.BackColor = System.Drawing.SystemColors.Control;
            this.btnSingleplayer.BackgroundImage = global::Occupation_of_states.Properties.Resources.BtnLong1;
            this.btnSingleplayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSingleplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingleplayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSingleplayer.Location = new System.Drawing.Point(14, 7);
            this.btnSingleplayer.Name = "btnSingleplayer";
            this.btnSingleplayer.Size = new System.Drawing.Size(380, 50);
            this.btnSingleplayer.TabIndex = 0;
            this.btnSingleplayer.Text = "Singleplayer";
            this.btnSingleplayer.UseVisualStyleBackColor = false;
            this.btnSingleplayer.Click += new System.EventHandler(this.btnSingleplayer_Click);
            this.btnSingleplayer.MouseEnter += new System.EventHandler(this.btnSingleplayer_MouseEnter);
            this.btnSingleplayer.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::Occupation_of_states.Properties.Resources.BtnMenu1;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Location = new System.Drawing.Point(116, 175);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 50);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseEnter += new System.EventHandler(this.btnBack_MouseEnter);
            this.btnBack.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // btnMultiplayerOn
            // 
            this.btnMultiplayerOn.BackColor = System.Drawing.SystemColors.Control;
            this.btnMultiplayerOn.BackgroundImage = global::Occupation_of_states.Properties.Resources.BtnLong1;
            this.btnMultiplayerOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMultiplayerOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiplayerOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMultiplayerOn.Location = new System.Drawing.Point(14, 119);
            this.btnMultiplayerOn.Name = "btnMultiplayerOn";
            this.btnMultiplayerOn.Size = new System.Drawing.Size(380, 50);
            this.btnMultiplayerOn.TabIndex = 2;
            this.btnMultiplayerOn.Text = "online Multiplayer";
            this.btnMultiplayerOn.UseVisualStyleBackColor = true;
            this.btnMultiplayerOn.Click += new System.EventHandler(this.btnMultiplayerOn_Click);
            this.btnMultiplayerOn.MouseEnter += new System.EventHandler(this.btnMultiplayerOn_MouseEnter);
            this.btnMultiplayerOn.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // BtnCreatorMap
            // 
            this.BtnCreatorMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCreatorMap.BackgroundImage")));
            this.BtnCreatorMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnCreatorMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreatorMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnCreatorMap.Location = new System.Drawing.Point(316, 482);
            this.BtnCreatorMap.Name = "BtnCreatorMap";
            this.BtnCreatorMap.Size = new System.Drawing.Size(180, 50);
            this.BtnCreatorMap.TabIndex = 6;
            this.BtnCreatorMap.Text = "Creator Map";
            this.BtnCreatorMap.UseVisualStyleBackColor = true;
            this.BtnCreatorMap.Click += new System.EventHandler(this.BtnCreatorMap_Click);
            this.BtnCreatorMap.MouseEnter += new System.EventHandler(this.btnBack_MouseEnter);
            this.BtnCreatorMap.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::Occupation_of_states.Properties.Resources.BtnMenu1;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPlay.Location = new System.Drawing.Point(316, 426);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(180, 50);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Occupation_of_states.Properties.Resources.BigLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 400);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnExit.BackgroundImage")));
            this.BtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnExit.Location = new System.Drawing.Point(316, 594);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(180, 50);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.BtnExit.MouseEnter += new System.EventHandler(this.BtnExit_MouseEnter);
            this.BtnExit.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSettings.Location = new System.Drawing.Point(316, 538);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(180, 50);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnSettings.MouseEnter += new System.EventHandler(this.btnSettings_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.bntAnimate_MouseLeave);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.ForeColor = System.Drawing.Color.Black;
            this.VersionLabel.Location = new System.Drawing.Point(981, 768);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(109, 13);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "Game Version 0.0.0.0";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1102, 790);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Occupation of states";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Shown += new System.EventHandler(this.MainMenu_Load);
            this.SizeChanged += new System.EventHandler(this.MainMenu_SizeChanged);
            this.MainPanel.ResumeLayout(false);
            this.PlayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntMultiplayerOff;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button btnMultiplayerOn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel PlayPanel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnSingleplayer;
        private System.Windows.Forms.Button BtnCreatorMap;
    }
}

