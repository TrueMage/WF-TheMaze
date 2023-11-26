namespace Maze
{
    partial class VictoryForm
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
            med1 = new PictureBox();
            med0 = new PictureBox();
            med2 = new PictureBox();
            label1 = new Label();
            buttonExit = new Button();
            buttonRestart = new Button();
            ((System.ComponentModel.ISupportInitialize)med1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)med0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)med2).BeginInit();
            SuspendLayout();
            // 
            // med1
            // 
            med1.BackgroundImage = Properties.Resources.big_medal;
            med1.BackgroundImageLayout = ImageLayout.Center;
            med1.InitialImage = Properties.Resources.big_medal;
            med1.Location = new Point(140, 100);
            med1.Name = "med1";
            med1.Size = new Size(75, 75);
            med1.TabIndex = 0;
            med1.TabStop = false;
            med1.Visible = false;
            // 
            // med0
            // 
            med0.BackgroundImage = Properties.Resources.big_medal;
            med0.InitialImage = Properties.Resources.big_medal;
            med0.Location = new Point(227, 100);
            med0.Name = "med0";
            med0.Size = new Size(75, 75);
            med0.TabIndex = 1;
            med0.TabStop = false;
            med0.Visible = false;
            // 
            // med2
            // 
            med2.BackgroundImage = Properties.Resources.big_medal;
            med2.BackgroundImageLayout = ImageLayout.Center;
            med2.InitialImage = Properties.Resources.big_medal;
            med2.Location = new Point(314, 100);
            med2.Name = "med2";
            med2.Size = new Size(75, 75);
            med2.TabIndex = 2;
            med2.TabStop = false;
            med2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(186, 47);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(151, 28);
            label1.TabIndex = 3;
            label1.Text = "Вы победили!";
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(12, 100);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(122, 74);
            buttonExit.TabIndex = 4;
            buttonExit.Text = "Выйти";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonRestart
            // 
            buttonRestart.Location = new Point(401, 100);
            buttonRestart.Name = "buttonRestart";
            buttonRestart.Size = new Size(122, 74);
            buttonRestart.TabIndex = 5;
            buttonRestart.Text = "Новая игра";
            buttonRestart.UseVisualStyleBackColor = true;
            buttonRestart.Click += buttonRestart_Click;
            // 
            // VictoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 186);
            Controls.Add(buttonRestart);
            Controls.Add(buttonExit);
            Controls.Add(label1);
            Controls.Add(med2);
            Controls.Add(med0);
            Controls.Add(med1);
            MaximizeBox = false;
            Name = "VictoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Победа";
            TopMost = true;
            Load += VictoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)med1).EndInit();
            ((System.ComponentModel.ISupportInitialize)med0).EndInit();
            ((System.ComponentModel.ISupportInitialize)med2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox med1;
        private PictureBox med0;
        private PictureBox med2;
        private Label label1;
        private Button buttonExit;
        private Button buttonRestart;
    }
}