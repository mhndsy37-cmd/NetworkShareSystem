using NetworkMonitorApp;

namespace NetworkShareSystem.SetupWizardForm
{
    partial class panelConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDeFolderPath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDeIco = new System.Windows.Forms.Label();
            this.btnBrowseIconDisconnected = new System.Windows.Forms.Button();
            this.txtIconDisconnected = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseIconConnected = new System.Windows.Forms.Button();
            this.txtIconConnected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNetworkSharingMode = new System.Windows.Forms.Label();
            this.rbGm = new System.Windows.Forms.RadioButton();
            this.rbSm = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, -4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(666, 86);
            this.label2.TabIndex = 16;
            this.label2.Text = "Config Setup Wizard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(584, 459);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 30);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(694, 459);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(104, 30);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDeFolderPath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(176, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 83);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shared Folder Path";
            // 
            // lblDeFolderPath
            // 
            this.lblDeFolderPath.AutoSize = true;
            this.lblDeFolderPath.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeFolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDeFolderPath.Location = new System.Drawing.Point(15, 57);
            this.lblDeFolderPath.Name = "lblDeFolderPath";
            this.lblDeFolderPath.Size = new System.Drawing.Size(0, 17);
            this.lblDeFolderPath.TabIndex = 14;
            this.lblDeFolderPath.Click += new System.EventHandler(this.lblDeFolderPath_Click);
            this.lblDeFolderPath.Enter += new System.EventHandler(this.lblDeHover);
            this.lblDeFolderPath.Leave += new System.EventHandler(this.lblDeLeave);
            this.lblDeFolderPath.MouseEnter += new System.EventHandler(this.lblDeHover);
            this.lblDeFolderPath.MouseLeave += new System.EventHandler(this.lblDeLeave);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(504, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(104, 30);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(156, 24);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(342, 29);
            this.txtPath.TabIndex = 1;
            this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shared Folder Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDeIco);
            this.groupBox2.Controls.Add(this.btnBrowseIconDisconnected);
            this.groupBox2.Controls.Add(this.txtIconDisconnected);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnBrowseIconConnected);
            this.groupBox2.Controls.Add(this.txtIconConnected);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(176, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 114);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status Icons";
            // 
            // lblDeIco
            // 
            this.lblDeIco.AutoSize = true;
            this.lblDeIco.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeIco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDeIco.Location = new System.Drawing.Point(15, 89);
            this.lblDeIco.Name = "lblDeIco";
            this.lblDeIco.Size = new System.Drawing.Size(318, 17);
            this.lblDeIco.TabIndex = 20;
            this.lblDeIco.Text = "Default: Similar to Windows\' own network status icon.";
            this.lblDeIco.Click += new System.EventHandler(this.label5_Click_1);
            this.lblDeIco.Enter += new System.EventHandler(this.lblDeHover);
            this.lblDeIco.Leave += new System.EventHandler(this.lblDeLeave);
            this.lblDeIco.MouseEnter += new System.EventHandler(this.lblDeHover);
            this.lblDeIco.MouseLeave += new System.EventHandler(this.lblDeLeave);
            // 
            // btnBrowseIconDisconnected
            // 
            this.btnBrowseIconDisconnected.Location = new System.Drawing.Point(504, 57);
            this.btnBrowseIconDisconnected.Name = "btnBrowseIconDisconnected";
            this.btnBrowseIconDisconnected.Size = new System.Drawing.Size(104, 30);
            this.btnBrowseIconDisconnected.TabIndex = 19;
            this.btnBrowseIconDisconnected.Text = "Browse...";
            this.btnBrowseIconDisconnected.UseVisualStyleBackColor = true;
            this.btnBrowseIconDisconnected.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // txtIconDisconnected
            // 
            this.txtIconDisconnected.Location = new System.Drawing.Point(184, 58);
            this.txtIconDisconnected.Name = "txtIconDisconnected";
            this.txtIconDisconnected.Size = new System.Drawing.Size(314, 29);
            this.txtIconDisconnected.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Network Disconnect ico:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseIconConnected
            // 
            this.btnBrowseIconConnected.Location = new System.Drawing.Point(504, 22);
            this.btnBrowseIconConnected.Name = "btnBrowseIconConnected";
            this.btnBrowseIconConnected.Size = new System.Drawing.Size(104, 30);
            this.btnBrowseIconConnected.TabIndex = 16;
            this.btnBrowseIconConnected.Text = "Browse...";
            this.btnBrowseIconConnected.UseVisualStyleBackColor = true;
            this.btnBrowseIconConnected.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // txtIconConnected
            // 
            this.txtIconConnected.Location = new System.Drawing.Point(184, 23);
            this.txtIconConnected.Name = "txtIconConnected";
            this.txtIconConnected.Size = new System.Drawing.Size(314, 29);
            this.txtIconConnected.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Network Connect ico:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNetworkSharingMode);
            this.groupBox3.Controls.Add(this.rbGm);
            this.groupBox3.Controls.Add(this.rbSm);
            this.groupBox3.Location = new System.Drawing.Point(176, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(623, 165);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Network Sharing Mode";
            // 
            // lblNetworkSharingMode
            // 
            this.lblNetworkSharingMode.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkSharingMode.Location = new System.Drawing.Point(16, 85);
            this.lblNetworkSharingMode.Name = "lblNetworkSharingMode";
            this.lblNetworkSharingMode.Size = new System.Drawing.Size(606, 77);
            this.lblNetworkSharingMode.TabIndex = 2;
            this.lblNetworkSharingMode.Text = "⚠ Info: In this scenario, for others to access your network, they must enter the " +
    "username and password of the user account that is sharing the folder into the ne" +
    "twork login fields.";
            this.lblNetworkSharingMode.Click += new System.EventHandler(this.label5_Click);
            // 
            // rbGm
            // 
            this.rbGm.AutoSize = true;
            this.rbGm.Location = new System.Drawing.Point(20, 55);
            this.rbGm.Name = "rbGm";
            this.rbGm.Size = new System.Drawing.Size(292, 25);
            this.rbGm.TabIndex = 1;
            this.rbGm.TabStop = true;
            this.rbGm.Text = "Guest Mode (No Password - Insecure)";
            this.rbGm.UseVisualStyleBackColor = true;
            this.rbGm.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // rbSm
            // 
            this.rbSm.AutoSize = true;
            this.rbSm.Location = new System.Drawing.Point(20, 29);
            this.rbSm.Name = "rbSm";
            this.rbSm.Size = new System.Drawing.Size(346, 25);
            this.rbSm.TabIndex = 0;
            this.rbSm.TabStop = true;
            this.rbSm.Text = "Secure Mode (Requires Username & Password)";
            this.rbSm.UseVisualStyleBackColor = true;
            this.rbSm.CheckedChanged += new System.EventHandler(this.rbMode_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NetworkShareSystem.Properties.Resources.Network_Share_Hub_Illustration;
            this.pictureBox1.Location = new System.Drawing.Point(-10, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 510);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panelConfig
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNext);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "panelConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.panelConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseIconDisconnected;
        private System.Windows.Forms.TextBox txtIconDisconnected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseIconConnected;
        private System.Windows.Forms.TextBox txtIconConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNetworkSharingMode;
        private System.Windows.Forms.RadioButton rbGm;
        private System.Windows.Forms.RadioButton rbSm;
        private System.Windows.Forms.Label lblDeFolderPath;
        private System.Windows.Forms.Label lblDeIco;
    }
}