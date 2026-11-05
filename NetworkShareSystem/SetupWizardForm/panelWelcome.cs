using NetworkMonitorApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkShareSystem.SetupWizardForm
{
    public partial class panelWelcome : BaseForm
    {
        public panelWelcome()
        {
            InitializeComponent();

            panelConfig.settings = AppSettings.Load();
            string flagPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "network_monitor_elevated.flag");
            bool isElevatedInstall = System.IO.File.Exists(flagPath);
            if (isElevatedInstall)
            {
                System.IO.File.Delete(flagPath); 
                this.Hide();
                Form sendConfig = new panelInstall();
                sendConfig.Show();
                sendConfig.Focus();
            }
        }

        private void panelWelcome_Load(object sender, EventArgs e)
        {

        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form toLicense=new panelLicense();

            toLicense.Show();
            toLicense.Focus();
            string logPath = $@"E:\install_log.txt";

            System.IO.File.AppendAllText(logPath, "wellcome end.\n");

        }
        private void panelWelcome_Load_1(object sender, EventArgs e)
        {
        string logPath = $@"E:\install_log.txt";
            System.IO.File.AppendAllText(logPath, "wellcome load.\n");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
