using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TogglWatcher.TogglApi.Models;

namespace TogglWatcher
{
    class TrayMenu : IDisposable
    {
        private readonly ContextMenuStrip _contextMenu;
        private readonly NotifyIcon _icon;

        private readonly ObservableCollection<TogglWatcher> _watchers = new ObservableCollection<TogglWatcher>();

        public TrayMenu()
        {
            _contextMenu = InitializeContextMenu();

            _icon = new NotifyIcon()
            {
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                ContextMenuStrip = _contextMenu,
                Visible = true
            };

            LoadWatchers();
        }

        public void Dispose()
        {
            _icon.Visible = false;
            _icon.Dispose();
            _contextMenu.Dispose();

            foreach (var watcher in _watchers)
            {
                watcher.Dispose();
            }
        }

        ContextMenuStrip InitializeContextMenu()
        {
            var contextMenu = new ContextMenuStrip();

            contextMenu.Items.Add("New Watcher", null, InitializeWatcher);
            contextMenu.Items.Add(InitializeWatchersMenu());
            contextMenu.Items.Add("Exit", null, (object sender, EventArgs e) => Application.Exit());

            return contextMenu;
        }

        void InitializeWatcher(object sender, EventArgs e)
        {
            var watcher = WatcherForm.GetWatcher();

            if (watcher != null) _watchers.Add(watcher);

            SaveWatchers();
        }

        ToolStripMenuItem InitializeWatchersMenu()
        {
            var menu = new ToolStripMenuItem("Watchers")
            {
                Enabled = false
            };

            _watchers.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            {
                menu.Enabled = _watchers.Count > 0;
                menu.DropDownItems.Clear();

                foreach (var watcher in _watchers)
                {
                    menu.DropDownItems.Add(InitializeWatcherMenu(watcher));
                }

                if (e.OldItems != null) {
                    foreach (TogglWatcher watcher in e.OldItems)
                    {
                        watcher.Dispose();
                    }
                }

                if (e.NewItems != null) {
                    foreach (TogglWatcher watcher in e.NewItems)
                    {
                        watcher.StatusChanged += (TogglTimeEntry entry, bool notification) =>
                        {
                            if (notification) ShowNotification(watcher, entry);

                            UpdateHoverText();
                        };

                        watcher.Refresh();
                    }
                }

                UpdateHoverText();
            };

            return menu;
        }

        ToolStripMenuItem InitializeWatcherMenu(TogglWatcher watcher)
        {
            var menu = new ToolStripMenuItem(watcher.Name);
            menu.DropDownItems.AddRange(new ToolStripMenuItem[] {
                new ToolStripMenuItem("View", null, async (object sender, EventArgs e) => {
                    new DayEntriesForm(await watcher.GetTodayEntries()).Show();
                }),
                new ToolStripMenuItem("Refresh", null, (object sender, EventArgs e) => watcher.Refresh()),
                new ToolStripMenuItem("Edit", null, (object sender, EventArgs e) => {
                    WatcherForm.GetWatcher(watcher);

                    SaveWatchers();
                }),
                new ToolStripMenuItem("Remove", null, (object sender, EventArgs e) => {
                    var result = MessageBox.Show($"Remove watcher '{watcher.Name}'?", "Remove watcher", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)  {
                        _watchers.Remove(watcher);

                        SaveWatchers();
                    }
                })
            });

            return menu;
        }

        void ShowNotification(TogglWatcher watcher, TogglTimeEntry entry)
        {
            if (entry == null)
            {
                _icon.ShowBalloonTip(2000, watcher.Name, "Timer stopped", ToolTipIcon.Info);
            } 
            
            else
            {
                var text = $"Timer started: {Helpers.TruncateString(entry.Description, 30)} ({Helpers.StringifySecondsDuration(entry.Duration)})";

                _icon.ShowBalloonTip(2000, watcher.Name, text, ToolTipIcon.Info);
            }
        }

        void UpdateHoverText()
        {
            var text = "TogglWatcher";

            foreach (var watcher in _watchers)
            {
                var entry = watcher.LastEntry;

                text += $"\n  {watcher.Name}: ";
                if (entry == null) text += "no entry";
                else text += $"{Helpers.TruncateString(entry.Description, 20)} ({Helpers.StringifySecondsDuration(entry.Duration)})";
            }

            _icon.Text = Helpers.TruncateString(text, 63);
        }

        void SaveWatchers()
        {
            FileStream fs = new FileStream("watchers.bin", FileMode.Create);
            BinaryFormatter fm = new BinaryFormatter();

            foreach (var watcher in _watchers)
            {
                fm.Serialize(fs, watcher);
            }

            fs.Close();
        }

        void LoadWatchers()
        {
            if (!File.Exists("watchers.bin")) return;

            FileStream fs = new FileStream("watchers.bin", FileMode.Open);
            BinaryFormatter fm = new BinaryFormatter();

            while (fs.Position != fs.Length)
            {
                var watcher = (TogglWatcher)fm.Deserialize(fs);
                _watchers.Add(watcher);
            }

            fs.Close();
        }
    }
}
