using NetworkMonitorApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkShareSystem.SetupWizardForm
{
    public partial class panelConfig : Form
    {
        public panelConfig()
        {
            InitializeComponent();
            settings = AppSettings.Load();

        }
        public static AppSettings settings;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the folder you want to share on the network:";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Icon Files (*.ico)|*.ico";
                ofd.Title = "Select an Icon";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (((Button)sender).Name == "btnBrowseIconConnected")
                    {
                        txtIconConnected.Text = ofd.FileName;
                    }
                    else if (((Button)sender).Name == "btnBrowseIconDisconnected")
                    {
                        txtIconDisconnected.Text = ofd.FileName;
                    }
                }
            }

        }
        private void rbMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGm.Checked)
            {
                lblNetworkSharingMode.Text = "⚠ WARNING: Guest mode disables SMB encryption and allows access without a password. This reduces network security!";
                lblNetworkSharingMode.ForeColor = AppTheme.DangerColor;
                lblNetworkSharingMode.Visible = true;
            }
            else
            {
                lblNetworkSharingMode.Text = "⚠ Info: In this scenario, for others to access your network, they must enter the username and password of the user account that is sharing the folder into the network login fields.";
                lblNetworkSharingMode.ForeColor = AppTheme.InfoColor;

            }
        }
        private void panelConfig_Load(object sender, EventArgs e)
        {
            string logPath = $@"E:\install_log.txt";
            System.IO.File.AppendAllText(logPath, "cof load 1.\n");

            rbSm.Checked = true;
            txtPath.Text = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\NetworkShareSystam";
            lblDeFolderPath.Text = $@"Default: {Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\NetworkShareSystam";
            System.IO.File.AppendAllText(logPath, "cof load 2.\n");

        }

        private void txtPath_Leave(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                txtPath.Text = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\NetworkShareSystam";
            }
        }

        private void lblDeFolderPath_Click(object sender, EventArgs e)
        {
            txtPath.Text = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\NetworkShareSystam";
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            txtIconConnected.Text = "";
            txtIconDisconnected.Text = "";

        }
        private void lblDeHover(object sender, EventArgs e)
        {
            if (((Label)sender).Name == "lblDeFolderPath")
            {
                lblDeFolderPath.ForeColor = Color.Blue;
            }
            if (((Label)sender).Name == "lblDeIco")
            {
                lblDeIco.ForeColor = Color.Blue;
            }
        }
        private void lblDeLeave(object sender, EventArgs e)
        {
            if (((Label)sender).Name == "lblDeFolderPath")
            {
                lblDeFolderPath.ForeColor = Color.FromArgb(128, 128, 255);
            }
            if (((Label)sender).Name == "lblDeIco")
            {
                lblDeIco.ForeColor = Color.FromArgb(128, 128, 255);
            }
        }
        private void SaveSettingsFromUI()
        {
            string selectedPath = txtPath.Text.Trim();
            string appFolderName = "NetworkShareSystem";

            // ۲. بررسی اینکه آیا مسیر از قبل به نام پوشه ما ختم می‌شود یا خیر
            // اگر مسیر پیش‌فرض خودمان باشد (که قبلا تنظیم کردیم)، دوباره آن را تکرار نمی‌کنیم
            if (!selectedPath.EndsWith(appFolderName, StringComparison.OrdinalIgnoreCase))
            {
                // اگر کاربر مسیر دیگری (مثل D:\Downloads) را انتخاب کرده بود، پوشه ما را داخل آن می‌سازیم
                settings.FolderPath = System.IO.Path.Combine(selectedPath, appFolderName);
            }
            else
            {
                settings.FolderPath = selectedPath;
            }

            // ۳. بقیه تنظیمات (بدون تغییر)
            settings.IconConnected = txtIconConnected.Text;
            settings.IconDisconnected = txtIconDisconnected.Text;
            settings.AllowInsecureSMB = rbGm.Checked;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string logPath = $@"E:\install_log.txt";
            System.IO.File.AppendAllText(logPath, "cof end 1.\n");
            if (string.IsNullOrWhiteSpace(settings.FolderPath))
            {
                MessageBox.Show("Please select a valid folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!System.IO.Directory.Exists(settings.FolderPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(settings.FolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not create the folder. Please check permissions.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                }
            SaveSettingsFromUI();
            settings.Save();
            if (IsRunningAsAdmin())
            {
                this.Hide();
                Form toInstall = new panelInstall();
                toInstall.Show();
                toInstall.Focus();
            }
            else
            {
                RelaunchAsAdmin();
            }
            System.IO.File.AppendAllText(logPath, "cof end 2.\n");
            return;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form toLicense = new panelLicense();
            toLicense.Show();
            toLicense.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private bool IsRunningAsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                string logPath = $@"E:\install_log.txt";
                System.IO.File.AppendAllText(logPath, "cof run ad 1.\n");
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void RelaunchAsAdmin()
        {
            try
            {
                string flagPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "network_monitor_elevated.flag");
                System.IO.File.WriteAllText(flagPath, "1");

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory, // 🔥 بسیار مهم: تنظیم پوشه کاری
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };
                Process.Start(psi);
                Environment.Exit(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Admin privileges are required to install.", "Cancelled");
            }
        }

    }

}


        
    

