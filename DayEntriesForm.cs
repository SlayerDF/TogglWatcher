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
        List<TogglTimeEntry> _entries;

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
