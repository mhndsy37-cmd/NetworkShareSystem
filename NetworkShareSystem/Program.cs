using NetworkShareSystem.SetupWizardForm;
using System;
using System.IO;
using System.Windows.Forms;

namespace NetworkMonitorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             
            string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkMonitorApp", "settings.json");

            if (File.Exists(configPath))
            {
                
                Application.Run(new MainForm());
            }
            else
            {
                 
                Application.Run(new panelWelcome());
            }
        }
    }
}
