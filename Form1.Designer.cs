namespace SpaceInvaders
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Heart2 = new System.Windows.Forms.PictureBox();
            this.Heart1 = new System.Windows.Forms.PictureBox();
            this.Heart3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ProjectileTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1;
            this.GameTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Heart2
            // 
            this.Heart2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Heart2.BackgroundImage")));
            this.Heart2.Location = new System.Drawing.Point(64, 4);
            this.Heart2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Heart2.Name = "Heart2";
            this.Heart2.Size = new System.Drawing.Size(47, 43);
            this.Heart2.TabIndex = 1;
            this.Heart2.TabStop = false;
            // 
            // Heart1
            // 
            this.Heart1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Heart1.BackgroundImage")));
            this.Heart1.Location = new System.Drawing.Point(9, 4);
            this.Heart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Heart1.Name = "Heart1";
            this.Heart1.Size = new System.Drawing.Size(47, 43);
            this.Heart1.TabIndex = 3;
            this.Heart1.TabStop = false;
            // 
            // Heart3
            // 
            this.Heart3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Heart3.BackgroundImage")));
            this.Heart3.Location = new System.Drawing.Point(119, 4);
            this.Heart3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Heart3.Name = "Heart3";
            this.Heart3.Size = new System.Drawing.Size(47, 43);
            this.Heart3.TabIndex = 4;
            this.Heart3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // ProjectileTimer
            // 
            this.ProjectileTimer.Tick += new System.EventHandler(this.ProjectileTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 690);
            this.Controls.Add(this.Heart3);
            this.Controls.Add(this.Heart1);
            this.Controls.Add(this.Heart2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox Heart3;
        private System.Windows.Forms.PictureBox Heart2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox Heart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer ProjectileTimer;
    }
}

