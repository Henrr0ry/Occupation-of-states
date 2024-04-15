
namespace Occupation_of_states
{
    partial class CommandPrompt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandPrompt));
            this.CMDbox = new System.Windows.Forms.RichTextBox();
            this.CMDtext = new System.Windows.Forms.TextBox();
            this.MinigameTimer = new System.Windows.Forms.Timer(this.components);
            this.ExplosionTimer = new System.Windows.Forms.Timer(this.components);
            this.LogUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CMDbox
            // 
            this.CMDbox.BackColor = System.Drawing.Color.Black;
            this.CMDbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CMDbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CMDbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDbox.ForeColor = System.Drawing.Color.Lime;
            this.CMDbox.Location = new System.Drawing.Point(0, 0);
            this.CMDbox.Name = "CMDbox";
            this.CMDbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.CMDbox.Size = new System.Drawing.Size(959, 444);
            this.CMDbox.TabIndex = 0;
            this.CMDbox.TabStop = false;
            this.CMDbox.Text = "";
            this.CMDbox.Enter += new System.EventHandler(this.CMDbox_Enter);
            // 
            // CMDtext
            // 
            this.CMDtext.BackColor = System.Drawing.Color.Black;
            this.CMDtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CMDtext.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CMDtext.ForeColor = System.Drawing.Color.DarkGreen;
            this.CMDtext.Location = new System.Drawing.Point(0, 450);
            this.CMDtext.Name = "CMDtext";
            this.CMDtext.Size = new System.Drawing.Size(959, 16);
            this.CMDtext.TabIndex = 1;
            this.CMDtext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMDtext_KeyDown);
            this.CMDtext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CMDtext_KeyUp);
            // 
            // MinigameTimer
            // 
            this.MinigameTimer.Interval = 1000;
            this.MinigameTimer.Tick += new System.EventHandler(this.MinigameTimer_Tick);
            // 
            // ExplosionTimer
            // 
            this.ExplosionTimer.Tick += new System.EventHandler(this.ExplosionTimer_Tick);
            // 
            // LogUpdateTimer
            // 
            this.LogUpdateTimer.Tick += new System.EventHandler(this.LogUpdateTimer_Tick);
            // 
            // CommandPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(960, 467);
            this.Controls.Add(this.CMDtext);
            this.Controls.Add(this.CMDbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandPrompt";
            this.Text = "CMD Occupaion of states";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CommandPrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox CMDbox;
        private System.Windows.Forms.TextBox CMDtext;
        private System.Windows.Forms.Timer MinigameTimer;
        private System.Windows.Forms.Timer ExplosionTimer;
        private System.Windows.Forms.Timer LogUpdateTimer;
    }
}