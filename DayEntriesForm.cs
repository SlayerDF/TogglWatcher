using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TogglWatcher.TogglApi.Models;

namespace TogglWatcher
{
    public partial class DayEntriesForm : Form
    {
        public DayEntriesForm(List<TogglTimeEntry> entries)
        {
            InitializeComponent();

            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            //_entries = new List<TogglTimeEntry>(entries);

            //Resize += DayEntriesForm_Resize;

            //DayEntriesForm_Resize(null, null);

            //if (_entries.Count > 0) Text += $". Total: {Helpers.StringifySecondsDuration(_entries.Sum(entry => entry.Duration))}";

            dateTimePicker_from.Value = DateTime.Today;
            dateTimePicker_to.Value = DateTime.Today.AddDays(1).AddMilliseconds(-1);

            BuildEntries(entries, dateTimePicker_from.Value, dateTimePicker_to.Value);
        }

        private void BuildEntries(List<TogglTimeEntry> entries, DateTime from, DateTime to)
        {
            var panel = tableLayoutPanel_entries;

            panel.Controls.Clear();
            panel.RowCount = entries.Count;

            for (var i = 0; i < entries.Count; i++)
            {
                panel.RowStyles.Add(new RowStyle());

                var entry = entries[i];

                if (entry.Stop != default) BuildActiveEntry(entry);
                else panel.Controls.Add(BuildEntry(entry, from, to), 0, i);

                if (i != entries.Count - 1)
                {
                    var nextEntry = entries[i + 1];

                    BuildIdle(entry, nextEntry);
                }
            }
        }

        private void BuildActiveEntry(TogglTimeEntry entry)
        {
        }

        private TableLayoutPanel BuildEntry(TogglTimeEntry entry, DateTime from, DateTime to)
        {
            var timeLabel = new Label()
            {
                AutoEllipsis = true,
                Dock = DockStyle.Top,
                Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.White,
                Margin = new Padding(10),
                Text = BuildEntryTimeText(entry, from, to),
            };

            var descLabel = new Label()
            {
                AutoEllipsis = true,
                Dock = DockStyle.Top,
                Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White,
                Margin = new Padding(10),
                Text = entry.Description,
            };

            var panel = new TableLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.FromArgb(128, 128, 255),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble,
                ColumnCount = 1,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 10),
                RowCount = 2,
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panel.RowStyles.Add(new RowStyle());
            panel.RowStyles.Add(new RowStyle());
            panel.Controls.Add(timeLabel, 0, 0);
            panel.Controls.Add(descLabel, 0, 1);

            return panel;
        }

        private void BuildIdle(TogglTimeEntry currentEntry, TogglTimeEntry nextEntry)
        {

        }

        private string BuildEntryTimeText(TogglTimeEntry entry, DateTime from, DateTime to)
        {
            var dateFormat = entry.Start.Date != entry.End.Date ? "dd.MM.yyyy HH:mm:ss" : "HH:mm:ss";

            MessageBox.Show($"{entry.End} {entry.End.ToString(dateFormat)}");

            var result = $"From {entry.Start.ToString(dateFormat)} to {entry.End.ToString(dateFormat)}";

            if (from.Date != to.Date && entry.Start.Date == entry.End.Date) result += $" ({entry.Start.Date:dd.MM.yyyy})";

            return result;
        }

        //private void DayEntriesForm_Resize(object sender, EventArgs e)
        //{
        //    pictureBox_main.Image = CreateChart();
        //}

        //private void CreateChart2()
        //{
        //    tableLayoutPanel_entries.Controls.Clear();

        //    tableLayoutPanel_entries.RowCount = _entries.Count;

        //    for (int i = 0; i < _entries.Count; i++)
        //    {
        //        tableLayoutPanel_entries.SetRow(BuildChartRow(_entries[i]), i);
        //    }
        //}

        //private Control BuildChartRow(TogglTimeEntry entry)
        //{
        //    return new Panel();
        //}

        //private Bitmap CreateChart()
        //{
        //    if (pictureBox_main.Width == 0 || pictureBox_main.Height == 0 || _entries.Count == 0) return null;

        //    FontFamily fontFamily = new FontFamily("Arial");

        //    var totalPadding = pictureBox_main.Margin + pictureBox_main.Padding;

        //    var width = ClientSize.Width - SystemInformation.VerticalScrollBarWidth - totalPadding.Left - totalPadding.Right;
        //    var height = ClientSize.Height + totalPadding.Top + totalPadding.Bottom;

        //    var totalElements = _entries.Count * 2 - 1;
        //    var elementIndent = 10;
        //    var elementHeight = Math.Min(100, Math.Max(75, (height + elementIndent * (1 - totalElements)) / totalElements));

        //    var actualHeight = elementHeight * totalElements + elementIndent * (totalElements - 1);

        //    Bitmap img = new Bitmap(width, actualHeight);
        //    Graphics g = Graphics.FromImage(img);

        //    // Draw

        //    int yGlobal = 0;

        //    void drawIndent()
        //    {
        //        yGlobal += elementIndent + elementHeight;
        //    }

        //    void drawText(string text, float fontSize, Brush brush, float x, float y)
        //    {
        //        fontSize = Math.Max(fontSize, 2);

        //        text = Helpers.TruncateString(text, (int)(width - x) / (int)(fontSize * 0.7));

        //        x -= fontSize / 1.5f;
        //        y -= fontSize / 2f;

        //        g.DrawString(text, new Font(fontFamily, fontSize), brush, x, y);
        //    }

        //    void drawEntry(TogglTimeEntry entry)
        //    {
        //        var brush = entry.Stop == default ? Brushes.Red : Brushes.RoyalBlue;
        //        var leftIndent = 15;

        //        g.FillRectangle(brush, 0, yGlobal, width, elementHeight);

        //        var text = entry.Stop != default
        //            ? $"{entry.Start:HH:mm} - {entry.Stop:HH:mm}"
        //            : $"Active for {Helpers.StringifySecondsDuration(entry.Duration)}";

        //        drawText(text, elementHeight / 5, Brushes.White, leftIndent, yGlobal + elementIndent * 2);

        //        drawText(entry.Description, elementHeight / 6, Brushes.White, leftIndent + 5, yGlobal + elementHeight / 1.5f);

        //        drawIndent();
        //    }

        //    void drawIdle(TogglTimeEntry cur, TogglTimeEntry next)
        //    {
        //        var leftIndent = 15;

        //        g.FillRectangle(Brushes.SlateGray, 0, yGlobal, width, elementHeight);

        //        var text = $"Idle for {Helpers.StringifySecondsDuration((long)(next.Start - cur.End).TotalSeconds)}";

        //        drawText(text, elementHeight / 5, Brushes.White, leftIndent, yGlobal + elementHeight / 2f);

        //        drawIndent();
        //    }

        //    for (var i = 0; i < _entries.Count; i++)
        //    {
        //        drawEntry(_entries[i]);

        //        if (i == _entries.Count - 1) break;

        //        drawIdle(_entries[i], _entries[i + 1]);
        //    }

        //    return img;
        //}

        private void checkBox_to_enabled_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_to.Visible = checkBox_to_enabled.Checked;
        }
    }
}
