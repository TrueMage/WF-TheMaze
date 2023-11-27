namespace Maze
{
    partial class LevelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelForm));
            statusStrip1 = new StatusStrip();
            StatusLabelHP = new ToolStripStatusLabel();
            StatusLabelStepCount = new ToolStripStatusLabel();
            StatusLabelEnergy = new ToolStripStatusLabel();
            WeaponIcon = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            MusicSettingMenuItem = new ToolStripMenuItem();
            SoundSettingMenuItem = new ToolStripMenuItem();
            StripStatusRestart = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabelHP, StatusLabelStepCount, StatusLabelEnergy, WeaponIcon, toolStripDropDownButton1, StripStatusRestart });
            statusStrip1.Location = new Point(0, 372);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(633, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelHP
            // 
            StatusLabelHP.Image = Properties.Resources.heart;
            StatusLabelHP.Name = "StatusLabelHP";
            StatusLabelHP.Size = new Size(76, 20);
            StatusLabelHP.Text = "100 HP";
            // 
            // StatusLabelStepCount
            // 
            StatusLabelStepCount.Image = Properties.Resources.steps;
            StatusLabelStepCount.Name = "StatusLabelStepCount";
            StatusLabelStepCount.Size = new Size(37, 20);
            StatusLabelStepCount.Text = "0";
            // 
            // StatusLabelEnergy
            // 
            StatusLabelEnergy.Image = Properties.Resources.energy;
            StatusLabelEnergy.Name = "StatusLabelEnergy";
            StatusLabelEnergy.Size = new Size(53, 20);
            StatusLabelEnergy.Text = "500";
            // 
            // WeaponIcon
            // 
            WeaponIcon.Image = Properties.Resources.pistol;
            WeaponIcon.Name = "WeaponIcon";
            WeaponIcon.Size = new Size(73, 20);
            WeaponIcon.Text = "ENTER";
            WeaponIcon.ToolTipText = "ENTER";
            WeaponIcon.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.AccessibleRole = AccessibleRole.None;
            toolStripDropDownButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { MusicSettingMenuItem, SoundSettingMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(98, 24);
            toolStripDropDownButton1.Text = "Настройки";
            // 
            // MusicSettingMenuItem
            // 
            MusicSettingMenuItem.Checked = true;
            MusicSettingMenuItem.CheckState = CheckState.Checked;
            MusicSettingMenuItem.Name = "MusicSettingMenuItem";
            MusicSettingMenuItem.Size = new Size(145, 26);
            MusicSettingMenuItem.Text = "Музыка";
            MusicSettingMenuItem.Click += MusicSettingMenuItem_Click;
            // 
            // SoundSettingMenuItem
            // 
            SoundSettingMenuItem.Checked = true;
            SoundSettingMenuItem.CheckState = CheckState.Checked;
            SoundSettingMenuItem.Name = "SoundSettingMenuItem";
            SoundSettingMenuItem.Size = new Size(145, 26);
            SoundSettingMenuItem.Text = "Звук";
            SoundSettingMenuItem.Click += SoundSettingMenuItem_Click;
            // 
            // StripStatusRestart
            // 
            StripStatusRestart.Name = "StripStatusRestart";
            StripStatusRestart.Size = new Size(112, 20);
            StripStatusRestart.Text = "Перезапустить";
            StripStatusRestart.Click += StripStatusRestart_Click;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // LevelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 398);
            Controls.Add(statusStrip1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LevelForm";
            Text = "Form1";
            Load += LevelForm_Load;
            KeyDown += KeyDownHandler;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripStatusLabel StatusLabelHP;
        private ToolStripStatusLabel StatusLabelStepCount;
        private System.Windows.Forms.Timer timer1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem MusicSettingMenuItem;
        private ToolStripMenuItem SoundSettingMenuItem;
        private ToolStripStatusLabel StatusLabelEnergy;
        public ToolStripStatusLabel WeaponIcon;
        public ToolStripStatusLabel StripStatusRestart;
        private StatusStrip statusStrip1;
    }
}