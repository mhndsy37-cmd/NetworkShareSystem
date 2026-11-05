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

            // بررسی اینکه آیا برنامه قبلا نصب شده است یا خیر
            string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkMonitorApp", "settings.json");

            if (File.Exists(configPath))
            {
                // اگر نصب شده بود، برنامه مانیتور را اجرا کن
                Application.Run(new MainForm());
            }
            else
            {
                // اگر نصب نشده بود، ویزارد نصب را باز کن
                Application.Run(new panelWelcome());
            }
        }
    }
}