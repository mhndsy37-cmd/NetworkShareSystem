using System.Drawing;
using System.Windows.Forms;

namespace NetworkMonitorApp
    {
        public static class AppTheme
        {
            public static Size WizardSize = new Size(850, 550);
            public static Size MainFormSize = new Size(300, 200);
            public static FormStartPosition StartPosition = FormStartPosition.CenterScreen;
            public static Color BackgroundColor = Color.WhiteSmoke;
            public static Color PrimaryColor = Color.FromArgb(0, 120, 215); // آبی ویندوز
            public static Color TextColor = Color.FromArgb(51, 51, 51); // خاکستری تیره
            public static Color DangerColor = Color.FromArgb(209, 52, 56); // قرمز برای هشدارها
            public static Font TitleFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            public static Font SubtitleFont = new Font("Segoe UI", 12F, FontStyle.Regular);
            public static Font NormalFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            public static Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            public static Color InfoColor = Color.Teal;
            public static Color WarningColor = Color.Orange;
           
    }
    }

