using System;
using System.Windows.Forms;
using WindowsFormsApp5.Forms;

namespace WindowsFormsApp5
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PlayerInfo());
        }
    }
}
