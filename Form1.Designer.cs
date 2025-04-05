namespace Dinoo
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
            dino = new PictureBox();
            obstacleBox = new PictureBox();
            slowLootBox = new PictureBox();
            ammoLootBox = new PictureBox();
            bulletBox = new PictureBox();
            lblAmmo = new Label();
            lblScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dino).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacleBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slowLootBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ammoLootBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bulletBox).BeginInit();
            SuspendLayout();
            // 
            // dino
            // 
            dino.BackColor = Color.Green;
            dino.Location = new Point(50, 250);
            dino.Name = "dino";
            dino.Size = new Size(50, 50);
            dino.TabIndex = 0;
            dino.TabStop = false;
            // 
            // obstacleBox
            // 
            obstacleBox.BackColor = Color.Red;
            obstacleBox.Location = new Point(500, 250);
            obstacleBox.Name = "obstacleBox";
            obstacleBox.Size = new Size(50, 50);
            obstacleBox.TabIndex = 1;
            obstacleBox.TabStop = false;
            // 
            // slowLootBox
            // 
            slowLootBox.BackColor = Color.Blue;
            slowLootBox.Location = new Point(500, 182);
            slowLootBox.Name = "slowLootBox";
            slowLootBox.Size = new Size(30, 30);
            slowLootBox.TabIndex = 2;
            slowLootBox.TabStop = false;
            // 
            // ammoLootBox
            // 
            ammoLootBox.BackColor = Color.FromArgb(255, 128, 0);
            ammoLootBox.Location = new Point(565, 182);
            ammoLootBox.Name = "ammoLootBox";
            ammoLootBox.Size = new Size(30, 30);
            ammoLootBox.TabIndex = 3;
            ammoLootBox.TabStop = false;
            // 
            // bulletBox
            // 
            bulletBox.BackColor = Color.Yellow;
            bulletBox.Location = new Point(106, 269);
            bulletBox.Name = "bulletBox";
            bulletBox.Size = new Size(20, 5);
            bulletBox.TabIndex = 4;
            bulletBox.TabStop = false;
            bulletBox.Visible = false;
            // 
            // lblAmmo
            // 
            lblAmmo.AutoSize = true;
            lblAmmo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmmo.Location = new Point(28, 30);
            lblAmmo.Name = "lblAmmo";
            lblAmmo.Size = new Size(57, 15);
            lblAmmo.TabIndex = 5;
            lblAmmo.Text = "Ammo: 0";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(106, 30);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(52, 15);
            lblScore.TabIndex = 6;
            lblScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblScore);
            Controls.Add(lblAmmo);
            Controls.Add(bulletBox);
            Controls.Add(ammoLootBox);
            Controls.Add(slowLootBox);
            Controls.Add(obstacleBox);
            Controls.Add(dino);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dino).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacleBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)slowLootBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ammoLootBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)bulletBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox dino;
        private PictureBox obstacleBox;
        private PictureBox slowLootBox;
        private PictureBox ammoLootBox;
        private PictureBox bulletBox;
        private Label lblAmmo;
        private Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}
