namespace Dark_Echo
{
    partial class Game
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer02 = new System.Windows.Forms.Timer(this.components);
            this.Stage01 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 150;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer02
            // 
            this.timer02.Enabled = true;
            this.timer02.Interval = 200;
            this.timer02.Tick += new System.EventHandler(this.steptimer_Tick);
            // 
            // Stage01
            // 
            this.Stage01.Font = new System.Drawing.Font("BernhardFashion BT", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stage01.ForeColor = System.Drawing.Color.GhostWhite;
            this.Stage01.Location = new System.Drawing.Point(213, 369);
            this.Stage01.Name = "Stage01";
            this.Stage01.Size = new System.Drawing.Size(556, 214);
            this.Stage01.TabIndex = 2;
            this.Stage01.Text = "S T A G E  0 1";
            this.Stage01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clear
            // 
            this.Clear.Enabled = false;
            this.Clear.Font = new System.Drawing.Font("BernhardFashion BT", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.Color.GhostWhite;
            this.Clear.Location = new System.Drawing.Point(221, 377);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(556, 214);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "C L E A R";
            this.Clear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Clear.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Stage01);
            this.DoubleBuffered = true;
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Game_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer02;
        private System.Windows.Forms.Label Stage01;
        private System.Windows.Forms.Label Clear;
    }
}