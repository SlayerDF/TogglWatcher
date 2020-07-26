namespace TogglWatcher
{
    partial class WatcherForm
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.numericUpDown_seconds = new System.Windows.Forms.NumericUpDown();
            this.textBox_apiToken = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_notification = new System.Windows.Forms.Label();
            this.label_seconds = new System.Windows.Forms.Label();
            this.label_apiToken = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.checkBox_notification = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_seconds)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_name.Location = new System.Drawing.Point(131, 39);
            this.textBox_name.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(200, 23);
            this.textBox_name.TabIndex = 1;
            // 
            // numericUpDown_seconds
            // 
            this.numericUpDown_seconds.Dock = System.Windows.Forms.DockStyle.Left;
            this.numericUpDown_seconds.Location = new System.Drawing.Point(131, 68);
            this.numericUpDown_seconds.Name = "numericUpDown_seconds";
            this.numericUpDown_seconds.Size = new System.Drawing.Size(42, 23);
            this.numericUpDown_seconds.TabIndex = 2;
            this.numericUpDown_seconds.Minimum = 10;
            this.numericUpDown_seconds.Maximum = 600;
            this.numericUpDown_seconds.Increment = 5;
            this.numericUpDown_seconds.Value = 60;
            // 
            // textBox_apiToken
            // 
            this.textBox_apiToken.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox_apiToken.Location = new System.Drawing.Point(131, 10);
            this.textBox_apiToken.MinimumSize = new System.Drawing.Size(200, 4);
            this.textBox_apiToken.Name = "textBox_apiToken";
            this.textBox_apiToken.Size = new System.Drawing.Size(200, 23);
            this.textBox_apiToken.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label_notification, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_seconds, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_apiToken, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_seconds, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_apiToken, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_submit, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_error, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_notification, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(7);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 213);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label_notification
            // 
            this.label_notification.AutoSize = true;
            this.label_notification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_notification.Location = new System.Drawing.Point(10, 94);
            this.label_notification.Name = "label_notification";
            this.label_notification.Size = new System.Drawing.Size(115, 20);
            this.label_notification.TabIndex = 2;
            this.label_notification.Text = "Notification enabled";
            this.label_notification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_seconds
            // 
            this.label_seconds.AutoSize = true;
            this.label_seconds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seconds.Location = new System.Drawing.Point(10, 65);
            this.label_seconds.Name = "label_seconds";
            this.label_seconds.Size = new System.Drawing.Size(115, 29);
            this.label_seconds.TabIndex = 2;
            this.label_seconds.Text = "Refresh seconds";
            this.label_seconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_apiToken
            // 
            this.label_apiToken.AutoSize = true;
            this.label_apiToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_apiToken.Location = new System.Drawing.Point(10, 7);
            this.label_apiToken.Name = "label_apiToken";
            this.label_apiToken.Size = new System.Drawing.Size(115, 29);
            this.label_apiToken.TabIndex = 2;
            this.label_apiToken.Text = "API Token";
            this.label_apiToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_name.Location = new System.Drawing.Point(10, 36);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(115, 29);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "Watcher name";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_submit
            // 
            this.button_submit.AutoSize = true;
            this.button_submit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_submit.Location = new System.Drawing.Point(10, 117);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(115, 25);
            this.button_submit.TabIndex = 3;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_error, 2);
            this.label_error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(7, 145);
            this.label_error.Margin = new System.Windows.Forms.Padding(0);
            this.label_error.Name = "label_error";
            this.label_error.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label_error.Size = new System.Drawing.Size(327, 20);
            this.label_error.TabIndex = 4;
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_error.Visible = false;
            // 
            // checkBox_notification
            // 
            this.checkBox_notification.AutoSize = true;
            this.checkBox_notification.Checked = true;
            this.checkBox_notification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_notification.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_notification.Location = new System.Drawing.Point(131, 97);
            this.checkBox_notification.Name = "checkBox_notification";
            this.checkBox_notification.Size = new System.Drawing.Size(15, 14);
            this.checkBox_notification.TabIndex = 5;
            this.checkBox_notification.UseVisualStyleBackColor = true;
            // 
            // WatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(314, 213);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WatcherForm";
            this.Text = "Create Watcher";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_seconds)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.NumericUpDown numericUpDown_seconds;
        private System.Windows.Forms.TextBox textBox_apiToken;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_apiToken;
        private System.Windows.Forms.Label label_seconds;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label_notification;
        private System.Windows.Forms.CheckBox checkBox_notification;
    }
}