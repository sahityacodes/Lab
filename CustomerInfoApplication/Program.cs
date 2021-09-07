using System;
using System.Windows.Forms;

namespace CustomerInfoApplication
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
            Application.SetCompatibleTextRenderingDefault(true);
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception)
            {
                MessageBox.Show("Error in the application.");
            }
        }
    }
}
