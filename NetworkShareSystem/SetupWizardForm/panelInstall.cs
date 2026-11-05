using NetworkMonitorApp;
using NetworkShareSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkShareSystem.SetupWizardForm
{
    public partial class panelInstall : Form
    {
        public panelInstall()
        {
            settings = panelConfig.settings;
            InitializeComponent();
        }
        AppSettings settings;
        private void panelInstall_Load(object sender, EventArgs e)
        {
            
        }

        private async void StartInstallation()
        {
            if (this.IsDisposed) return;

            try
            {
                btnNext.Enabled = false;
                lblInstallStatus.Text = "Applying SMB Settings...";
                progressBarInstall.Value = 25;

                await Task.Delay(800); 
                if (this.IsDisposed) return;

                if (settings.AllowInsecureSMB)
                {
                    string smbResult = SystemHelper.ApplySMBGuestMode();
                    if (smbResult.StartsWith("ERROR") || smbResult.StartsWith("EXCEPTION"))
                    {
                        this.Invoke(new Action(() => MessageBox.Show("SMB Warning:\n" + smbResult, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                    }
                }

         
                string shareResult = SystemHelper.SetupNetworkShare(settings.FolderPath);
                if (shareResult.StartsWith("ERROR") || shareResult.StartsWith("EXCEPTION"))
                {
                    this.Invoke(new Action(() => MessageBox.Show("Share Warning:\n" + shareResult, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                }

              
                string taskResult = SystemHelper.SetStartup(true);
                if (!taskResult.Contains("TASK_CREATED_SUCCESSFULLY"))
                {
                    this.Invoke(new Action(() => MessageBox.Show("Task Scheduler Warning:\n" + taskResult, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                }

              
                lblInstallStatus.Text = "Saving configuration...";
                progressBarInstall.Value = 75;

                await Task.Delay(500);
                if (this.IsDisposed) return;

                settings.Save();

                lblInstallStatus.Text = "Installation Complete!";
                progressBarInstall.Value = 100;

                await Task.Delay(1000);
                if (this.IsDisposed) return;

                Form toFinish = new panelFinish();
                this.Hide();
                toFinish.Show();
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                    MessageBox.Show("Installation Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void progressBarInstall_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void panelInstall_Load_1(object sender, EventArgs e)
        {
           
        }

        private void panelInstall_Shown(object sender, EventArgs e)
        {
            StartInstallation();
        }
    }
}
