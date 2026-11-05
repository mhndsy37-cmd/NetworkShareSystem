using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;

namespace NetworkMonitorApp
{
    public class AppSettings
    {
        public string FolderPath { get; set; } = @"C:\NetworkShareSystem";
        public string IconConnected { get; set; } = @"C:\Icons\Connected.ico";
        public string IconDisconnected { get; set; } = @"C:\Icons\Disconnected.ico";
        public bool StartWithWindows { get; set; } = false;
        public bool AllowInsecureSMB { get; set; } = false;

        private static string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkMonitorApp", "settings.json");

        public static AppSettings Load()
        {
         
            try
            {
                if (File.Exists(ConfigPath))
                {
                    string json = File.ReadAllText(ConfigPath);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var settings = JsonConvert.DeserializeObject<AppSettings>(json);
                        if (settings != null) return settings;
                    }
                }
            }
            catch (Exception)
            {
           }
            
            return new AppSettings();
             
        }

        public void Save()
        {
            string dir = Path.GetDirectoryName(ConfigPath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
