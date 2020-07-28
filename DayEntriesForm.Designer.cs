namespace TogglWatcher
{
    partial class DayEntriesForm
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
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.panel_main = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox_main.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_main.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Padding = new System.Windows.Forms.Padding(10);
            this.pictureBox_main.Size = new System.Drawing.Size(865, 522);
            this.pictureBox_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_main.TabIndex = 0;
            this.pictureBox_main.TabStop = false;
            // 
            // panel_main
            // 
            this.panel_main.AutoScroll = true;
            this.panel_main.BackColor = System.Drawing.SystemColors.Window;
            this.panel_main.Controls.Add(this.pictureBox_main);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(684, 561);
            this.panel_main.TabIndex = 1;
            // 
            // DayEntriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.panel_main);
            this.Name = "DayEntriesForm";
            this.Text = "Today\'s entries";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.Panel panel_main;
    }
}