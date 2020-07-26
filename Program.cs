using System;
using System.Windows.Forms;

namespace TogglWatcher
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrayApplicationContext());
        }

        public class TrayApplicationContext : ApplicationContext
        {
            private readonly TrayMenu _trayMenu = new TrayMenu();

            public TrayApplicationContext()
            {
                Application.ApplicationExit += new EventHandler(OnApplicationExit);
            }

            private void OnApplicationExit(object sender, EventArgs e)
            {
                _trayMenu.Dispose();
            }
        }
    }
}
