using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace NetworkMonitorApp
{
    public static class NetworkLogic
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, string dwItem1, IntPtr dwItem2);

        public static bool IsNetworkUp()
        {
            string logPath = $@"E:\install_log.txt";
            System.IO.File.AppendAllText(logPath, "net logi bool 1.\n");
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var a in adapters)
            {
                if (a.OperationalStatus == OperationalStatus.Up && a.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    var props = a.GetIPProperties();
                    foreach (var ip in props.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            string ipStr = ip.Address.ToString();
                            if (!ipStr.StartsWith("169.254.") && ipStr != "127.0.0.1")
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public static void UpdateFolderIcon(string folderPath, string iconPath)
        {
            try
            {
                // اطمینان از اینکه مسیر آیکون مطلق (Absolute) است
                string absoluteIconPath = System.IO.Path.GetFullPath(iconPath);

                if (!System.IO.File.Exists(absoluteIconPath)) return; // اگر فایل آیکون نبود، کاری نکن

                string iniPath = System.IO.Path.Combine(folderPath, "desktop.ini");

                // 1. نوشتن محتوای استاندارد فایل desktop.ini
                string iniContent = "[.ShellClassInfo]\r\nIconResource=" + absoluteIconPath + ",0\r\n";

                // اگر فایل وجود دارد، ویژگی‌هایش را موقتاً عادی کن تا بتوانی روی آن بنویسی
                if (System.IO.File.Exists(iniPath))
                    System.IO.File.SetAttributes(iniPath, System.IO.FileAttributes.Normal);

                // نوشتن فایل با فرمت ANSI
                System.IO.File.WriteAllText(iniPath, iniContent, System.Text.Encoding.Default);

                // 2. اعمال ویژگی‌های مخفی و سیستمی به فایل ini
                System.IO.File.SetAttributes(iniPath, System.IO.FileAttributes.Hidden | System.IO.FileAttributes.System);

                // 3. اعمال ویژگی سیستمی به خود پوشه (بسیار مهم برای خواندن desktop.ini)
                var dirInfo = new System.IO.DirectoryInfo(folderPath);
                if ((dirInfo.Attributes & System.IO.FileAttributes.System) == 0)
                {
                    dirInfo.Attributes |= System.IO.FileAttributes.System;
                }

                // 4. رفرش کردن ویندوز اکسپلورر
                SHChangeNotify(0x08000000, 0x00001005, folderPath, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Icon update error: " + ex.Message);
            }
        }
    }
}