using System;
using System.Diagnostics;
using System.IO;

namespace NetworkMonitorApp
{
    public static class SystemHelper
    {
        public static string SetStartup(bool enable)
        {
            string taskName = "NetworkShareMonitorApp";
            string exePath = Process.GetCurrentProcess().MainModule.FileName;

            
            string tempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "NetworkShareMonitorApp");
            string ps1Path = Path.Combine(tempFolder, "SetupTask.ps1");

            if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);

            if (enable)
            {
                
                string safeExePath = exePath.Replace("'", "''");

                
                string script = $@"
$ErrorActionPreference = 'Stop'
try {{
    $action = New-ScheduledTaskAction -Execute '{safeExePath}'
    $trigger = New-ScheduledTaskTrigger -AtLogOn
    $principal = New-ScheduledTaskPrincipal -UserId (whoami) -LogonType Interactive -RunLevel Highest
    Register-ScheduledTask -TaskName '{taskName}' -Action $action -Trigger $trigger -Principal $principal -Force | Out-Null
    
    $task = Get-ScheduledTask -TaskName '{taskName}' -ErrorAction SilentlyContinue
    if ($task) {{ Write-Output 'TASK_CREATED_SUCCESSFULLY' }} else {{ Write-Output 'TASK_NOT_FOUND' }}
}} catch {{
    Write-Output ('ERROR: ' + $_.Exception.Message)
}}
";
                
                File.WriteAllText(ps1Path, script, new System.Text.UTF8Encoding(true));

                
                string args = $"-NoProfile -ExecutionPolicy Bypass -File \"{ps1Path}\"";
                return RunProcess("powershell.exe", args);
            }
            else
            {
                string script = $@"
$ErrorActionPreference = 'SilentlyContinue'
Unregister-ScheduledTask -TaskName '{taskName}' -Confirm:$false
Write-Output 'TASK_DELETED'
";
                File.WriteAllText(ps1Path, script, new System.Text.UTF8Encoding(true));
                string args = $"-NoProfile -ExecutionPolicy Bypass -File \"{ps1Path}\"";
                return RunProcess("powershell.exe", args);
            }
        }

        public static string ApplySMBGuestMode()
        {
            string script = "Set-SmbClientConfiguration -EnableInsecureGuestLogons $true -Force; Set-SmbClientConfiguration -RequireSecuritySignature $false -Force";
            return RunProcess("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"");
        }

        public static string SetupNetworkShare(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                string folderName = Path.GetFileName(folderPath.TrimEnd('\\'));
                if (string.IsNullOrWhiteSpace(folderName)) folderName = "Drive_" + folderPath.Replace(":", "").Replace("\\", "");
                string shareName = folderName;

                string safePath = folderPath.Replace("'", "''");
                string safeShareName = shareName.Replace("'", "''");

                string script = $@"
                    $path = '{safePath}'
                    $shareName = '{safeShareName}'

                    $existingShare = Get-SmbShare -Name $shareName -ErrorAction SilentlyContinue
                    if ($existingShare) {{
                        if ($existingShare.Path -ne $path) {{
                            Remove-SmbShare -Name $shareName -Force -ErrorAction Stop | Out-Null
                            New-SmbShare -Name $shareName -Path $path -FullAccess 'Everyone' -ErrorAction Stop | Out-Null
                        }} else {{
                            Grant-SmbShareAccess -Name $shareName -AccountName 'Everyone' -AccessRight Full -Force -ErrorAction Stop | Out-Null
                        }}
                    }} else {{
                        New-SmbShare -Name $shareName -Path $path -FullAccess 'Everyone' -ErrorAction Stop | Out-Null
                    }}

                    icacls $path /grant 'Everyone:(OI)(CI)F' | Out-Null
                ";

                return RunProcess("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"", 30000);
            }
            catch (Exception ex)
            {
                return "EXCEPTION: " + ex.Message;
            }
        }

        private static string RunProcess(string fileName, string arguments, int timeoutMs = 15000)
        {
            try
            {
                var psi = new ProcessStartInfo(fileName, arguments)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var p = Process.Start(psi))
                {
                    if (p == null) return "FAILED TO START";

                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();

                    if (!p.WaitForExit(timeoutMs))
                    {
                        try { p.Kill(); } catch { }
                        return "TIMEOUT";
                    }

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        return "ERROR: " + error.Trim();
                    }

                    return string.IsNullOrWhiteSpace(output) ? "SUCCESS" : output.Trim();
                }
            }
            catch (Exception ex)
            {
                return "EXCEPTION: " + ex.Message;
            }
        }
    }
}
