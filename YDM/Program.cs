using System;
using System.Windows.Forms;

namespace YDM
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
            try
            {
                Application.Run(new MainForm());
            }
            catch
            {
                // need a button to clear the code
                Properties.Settings.Default.Reset();
                Application.Run(new MainForm());
            }
        }
    }
}
