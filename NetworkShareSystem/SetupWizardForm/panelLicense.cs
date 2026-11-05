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
    public partial class panelLicense : Form
    {
        public panelLicense()
        {
            InitializeComponent();
        }

        private void chkAcceptLicense_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = chkAcceptLicense.Checked;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form toWelcome=new panelWelcome();
            toWelcome.Show();
            toWelcome.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form toConfig = new panelConfig();
            toConfig.Show();
            toConfig.Focus();
            string logPath = $@"E:\install_log.txt";

            System.IO.File.AppendAllText(logPath, "lic end.\n");

        }
        private void panelLicense_Load(object sender, EventArgs e)
        {
        string logPath = $@"E:\install_log.txt";
            System.IO.File.AppendAllText(logPath, "lic load.\n");

        }
    }
}
