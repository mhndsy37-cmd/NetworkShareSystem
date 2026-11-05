using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NetworkMonitorApp
{
    public partial class MainForm : Form
    {
        private AppSettings _settings;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private Timer networkTimer;
        private bool _lastStatus = false;

        private string updaterToolPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FolderIconUpdater.exe");

        // متغیرهای نگهداری مسیر قطعی آیکون‌ها
        private string _iconConnectedPath;
        private string _iconDisconnectedPath;

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, string dwItem1, IntPtr dwItem2);

        public MainForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;

            _settings = AppSettings.Load();

            _iconConnectedPath = EnsureIconExists(_settings.IconConnected, NetworkShareSystem.Properties.Resources.Connected, "DefaultConnected.ico");
            _iconDisconnectedPath = EnsureIconExists(_settings.IconDisconnected, NetworkShareSystem.Properties.Resources.Disconnected, "DefaultDisconnected.ico");
            trayMenu = new ContextMenuStrip();
            trayMenu.Opening += TrayMenu_Opening;

            trayIcon = new NotifyIcon()
            {
                Visible = true,
                ContextMenuStrip = trayMenu,
                Text = "Network Monitor",
                Icon = SystemIcons.Application
            };

            trayIcon.DoubleClick += (s, e) => OpenSharedFolder();

            networkTimer = new Timer();
            networkTimer.Interval = 1000;
            networkTimer.Tick += NetworkTimer_Tick;
            networkTimer.Start();

            // اجرای اولیه
            NetworkTimer_Tick(null, null);
        }

        // این متد بررسی می‌کند اگر آیکون نبود، آن را از منابع برنامه روی هارد ذخیره کند
        private string EnsureIconExists(string currentPath, byte[] defaultResource, string defaultFileName)
        {
            if (!string.IsNullOrWhiteSpace(currentPath) && File.Exists(currentPath))
                return currentPath;

            try
            {
                string iconsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkMonitorApp", "Icons");
                if (!Directory.Exists(iconsDir)) Directory.CreateDirectory(iconsDir);

                string fallbackPath = Path.Combine(iconsDir, defaultFileName);
                if (!File.Exists(fallbackPath))
                {
                    File.WriteAllBytes(fallbackPath, defaultResource);
                }
                return fallbackPath;
            }
            catch
            {
                return null; // اگر حتی این هم نشد، null برمی‌گرداند
            }
        }

        private void NetworkTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                bool isUp = NetworkLogic.IsNetworkUp();

                if (isUp != _lastStatus)
                {
                    string iconPath = isUp ? _iconConnectedPath : _iconDisconnectedPath;

                    // ۱. تغییر آیکون سینی
                    if (!string.IsNullOrWhiteSpace(iconPath) && File.Exists(iconPath))
                    {
                        trayIcon.Icon = new Icon(iconPath);
                    }
                    else
                    {
                        trayIcon.Icon = SystemIcons.Application; // آیکون جایگزین
                    }
                    trayIcon.Text = isUp ? "Network: Connected" : "Network: Disconnected";

                    // ۲. تغییر آیکون پوشه
                    if (!string.IsNullOrWhiteSpace(iconPath) && File.Exists(iconPath))
                    {
                        UpdateSharedFolderIcon(iconPath);
                    }

                    // 🔥 مهم: این خط حتماً باید اجرا شود تا حلقه بی‌نهایت قطع شود
                    _lastStatus = isUp;
                }
            }
            catch { /* جلوگیری از کرش */ }
        }

        private void UpdateSharedFolderIcon(string iconPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_settings.FolderPath) || !Directory.Exists(_settings.FolderPath)) return;

                string iniPath = Path.Combine(_settings.FolderPath, "desktop.ini");
                string iniContent = "[.ShellClassInfo]\r\nIconResource=" + iconPath + ",0\r\n";

                if (File.Exists(iniPath)) File.SetAttributes(iniPath, FileAttributes.Normal);
                File.WriteAllText(iniPath, iniContent, System.Text.Encoding.Default);
                File.SetAttributes(iniPath, FileAttributes.Hidden | FileAttributes.System);

                var dirInfo = new DirectoryInfo(_settings.FolderPath);
                if ((dirInfo.Attributes & FileAttributes.System) == 0)
                    dirInfo.Attributes |= FileAttributes.System;

                // اجرای ابزار اختصاصی
                if (File.Exists(updaterToolPath))
                {
                    Process.Start(new ProcessStartInfo(updaterToolPath, $"/f \"{_settings.FolderPath}\"")
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    });
                }
                else
                {
                    // روش جایگزین اگر ابزار نبود
                    SHChangeNotify(0x08000000, 0x00001005, _settings.FolderPath, IntPtr.Zero);
                    Process.Start(new ProcessStartInfo("ie4uinit.exe", "-show") { WindowStyle = ProcessWindowStyle.Hidden, CreateNoWindow = true });
                }
            }
            catch { /* نادیده گرفتن خطاها */ }
        }

        private void TrayMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            trayMenu.Items.Clear();

            var statusItem = new ToolStripMenuItem($"Status: {(_lastStatus ? "Connected" : "Disconnected")}");
            statusItem.Enabled = false;
            trayMenu.Items.Add(statusItem);
            trayMenu.Items.Add(new ToolStripSeparator());

            if (_lastStatus)
            {
                var activeAdapters = GetAdapters("Up");
                foreach (var adapter in activeAdapters)
                {
                    var item = new ToolStripMenuItem($"Disconnect {adapter}");
                    item.Click += (s, ev) => ManageAdapter(adapter, false);
                    trayMenu.Items.Add(item);
                }
            }
            else
            {
                var disabledAdapters = GetAdapters("Disabled");
                var lanAdapter = disabledAdapters.FirstOrDefault(a => a.Contains("Ethernet") || a.Contains("LAN"));
                var wifiAdapter = disabledAdapters.FirstOrDefault(a => a.Contains("Wi-Fi") || a.Contains("WLAN"));

                if (lanAdapter != null)
                {
                    var item = new ToolStripMenuItem($"Connect LAN ({lanAdapter})");
                    item.Click += (s, ev) => ManageAdapter(lanAdapter, true);
                    trayMenu.Items.Add(item);
                }

                if (wifiAdapter != null)
                {
                    var item = new ToolStripMenuItem($"Turn on Wi-Fi ({wifiAdapter})");
                    item.Click += (s, ev) => ManageAdapter(wifiAdapter, true);
                    trayMenu.Items.Add(item);
                }
            }

            trayMenu.Items.Add(new ToolStripSeparator());

            var openItem = new ToolStripMenuItem("Open Shared Folder");
            openItem.Click += (s, ev) => OpenSharedFolder();
            trayMenu.Items.Add(openItem);

            var exitItem = new ToolStripMenuItem("Exit Monitor");
            exitItem.Click += (s, ev) => { trayIcon.Visible = false; Application.Exit(); };
            trayMenu.Items.Add(exitItem);
        }

        private string[] GetAdapters(string status)
        {
            try
            {
                string script = $"Get-NetAdapter -Physical | Where-Object {{ $_.Status -eq '{status}' }} | Select-Object -ExpandProperty Name";
                var psi = new ProcessStartInfo("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (var p = Process.Start(psi))
                {
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    return output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(a => a.Trim()).ToArray();
                }
            }
            catch { return new string[0]; }
        }

        private void ManageAdapter(string adapterName, bool enable)
        {
            try
            {
                string cmd = enable ? "Enable-NetAdapter" : "Disable-NetAdapter";
                string script = $"{cmd} -Name '{adapterName}' -Confirm:$false";

                Process.Start(new ProcessStartInfo("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error managing adapter: " + ex.Message, "Error");
            }
        }

        private void OpenSharedFolder()
        {
            if (!string.IsNullOrWhiteSpace(_settings.FolderPath) && Directory.Exists(_settings.FolderPath))
                Process.Start("explorer.exe", _settings.FolderPath);
            else
                MessageBox.Show("Shared folder not found!\nPath: " + _settings.FolderPath, "Error");
        }
    }
}