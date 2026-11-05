using System.Drawing;
using System.Windows.Forms;

namespace NetworkMonitorApp
{
    public class BaseForm : Form
    {
        public void BaseFormconf(
            
            ) 
        {
            this.Font = AppTheme.NormalFont;
            this.BackColor = AppTheme.BackgroundColor;
            this.ForeColor = AppTheme.TextColor;
            this.StartPosition = AppTheme.StartPosition;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = AppTheme.WizardSize;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}