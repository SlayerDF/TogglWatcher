using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TogglWatcher
{
    public partial class WatcherForm : Form
    {
        private TogglWatcher _watcher;

        private WatcherForm(TogglWatcher watcher = null)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            if (watcher != null)
            {
                _watcher = watcher;
                textBox_apiToken.Text = new string('*', 32);
                textBox_name.Text = watcher.Name;
                numericUpDown_seconds.Value = watcher.CheckIntervalSeconds;
                checkBox_notification.Checked = watcher.NotificationEnabled;
                button_submit.Text = "Update";

                textBox_apiToken.Enabled = false;

                button_submit.Click += UpdateWatcher;
            }
            else
            {
                button_submit.Text = "Create";
                button_submit.Click += CreateWatcher;
            }
        }

        public static TogglWatcher GetWatcher(TogglWatcher watcher = null)
        {
            var form = new WatcherForm(watcher);
            form.ShowDialog();

            return form._watcher;
        }

        private void CreateWatcher(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            var apiToken = textBox_apiToken.Text;
            var name = textBox_name.Text;
            var checkIntervalSeconds = (int)numericUpDown_seconds.Value;
            var notificationEnabled = checkBox_notification.Checked;

            _watcher = new TogglWatcher(apiToken, name, checkIntervalSeconds, notificationEnabled);

            Close();
        }

        private void UpdateWatcher(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            var name = textBox_name.Text;
            var checkIntervalSeconds = (int)numericUpDown_seconds.Value;
            var notificationEnabled = checkBox_notification.Checked;

            _watcher.Name = name;
            _watcher.CheckIntervalSeconds = checkIntervalSeconds;
            _watcher.NotificationEnabled = notificationEnabled;

            Close();
        }

        private bool ValidateFields()
        {
            if (textBox_apiToken.Text.Length == 0)
            {
                ShowError("API token is not defined");
                return false;
            }

            if (textBox_name.Text.Length == 0)
            {
                ShowError("The Watcher's name is not defined");
                return false;
            }

            if (numericUpDown_seconds.Value < 10 || numericUpDown_seconds.Value > 600)
            {
                ShowError("Refresh seconds must be in range from 10 to 600 seconds");
                return false;
            }

            return true;
        }

        private void ShowError(string errorText)
        {
            label_error.Text = errorText;
            label_error.Visible = true;
        }
    }
}
