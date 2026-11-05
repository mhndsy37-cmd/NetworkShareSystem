using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkShareSystem.SetupWizardForm
{
    public partial class panelFinish : Form
    {
        public panelFinish()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult EEE = MessageBox.Show(
                "Note: It is recommended to restart Windows to apply the network core settings.\nAre you doing this now?",
                "Finish note",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if (EEE==DialogResult.Yes)
            {
                Process.Start("shutdown", "/r /t 0");
            }
            else
            {
                Process.Start(Application.ExecutablePath);
            }
        }
    }
}
