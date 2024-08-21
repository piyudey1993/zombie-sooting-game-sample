namespace Zombie_Shooter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ammo_txt = new Label();
            score_txt = new Label();
            heath_txt = new Label();
            health_bar = new ProgressBar();
            player = new PictureBox();
            Game_timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // ammo_txt
            // 
            ammo_txt.AutoSize = true;
            ammo_txt.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ammo_txt.ForeColor = SystemColors.ButtonFace;
            ammo_txt.Location = new Point(9, 8);
            ammo_txt.Name = "ammo_txt";
            ammo_txt.Size = new Size(85, 25);
            ammo_txt.TabIndex = 0;
            ammo_txt.Text = "AMMO: ";
            // 
            // score_txt
            // 
            score_txt.AutoSize = true;
            score_txt.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            score_txt.ForeColor = SystemColors.ButtonFace;
            score_txt.Location = new Point(307, 8);
            score_txt.Name = "score_txt";
            score_txt.Size = new Size(51, 25);
            score_txt.TabIndex = 1;
            score_txt.Text = "kills:";
            // 
            // heath_txt
            // 
            heath_txt.AutoSize = true;
            heath_txt.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            heath_txt.ForeColor = SystemColors.ButtonFace;
            heath_txt.Location = new Point(629, 8);
            heath_txt.Name = "heath_txt";
            heath_txt.Size = new Size(71, 25);
            heath_txt.TabIndex = 2;
            heath_txt.Text = "health:";
            // 
            // health_bar
            // 
            health_bar.Location = new Point(728, 8);
            health_bar.Name = "health_bar";
            health_bar.Size = new Size(125, 23);
            health_bar.TabIndex = 3;
            health_bar.UseWaitCursor = true;
            health_bar.Value = 100;
            // 
            // player
            // 
            player.Image = Properties.Resources.up;
            player.Location = new Point(380, 334);
            player.Name = "player";
            player.Size = new Size(71, 100);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 4;
            player.TabStop = false;
            // 
            // Game_timer
            // 
            Game_timer.Enabled = true;
            Game_timer.Tick += MainTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(924, 661);
            Controls.Add(player);
            Controls.Add(health_bar);
            Controls.Add(heath_txt);
            Controls.Add(score_txt);
            Controls.Add(ammo_txt);
            Name = "Form1";
            Text = "Form1";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ammo_txt;
        private Label score_txt;
        private Label heath_txt;
        private ProgressBar health_bar;
        private PictureBox player;
        private System.Windows.Forms.Timer Game_timer;
    }
}
