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
            statusStrip1 = new StatusStrip();
            StatusLabelHP = new ToolStripStatusLabel();
            StatusLabelStepCount = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabelHP, StatusLabelStepCount });
            statusStrip1.Location = new Point(0, 372);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(445, 26);
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
            StatusLabelStepCount.Name = "StatusLabelStepCount";
            StatusLabelStepCount.Size = new Size(60, 20);
            StatusLabelStepCount.Text = "Steps: 0";
            // 
            // LevelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 398);
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

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabelHP;
        private ToolStripStatusLabel StatusLabelStepCount;
    }
}