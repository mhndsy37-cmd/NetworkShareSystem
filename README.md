# Network Share Monitor (NetworkShareSystem)
<h2 align="center">
  
v1.0.0-beta.release
</h2>

<div align="center">

[![My Skills](https://skillicons.dev/icons?i=cs,windows,powershell,visualstudio&theme=dark)](https://skillicons.dev)

</div>

## Project Vision
This software is built with the vision of achieving a level of stability, deep system integration, and automation that meets strict enterprise standards. The architecture is designed with the long-term goal of reaching a level of reliability where the core functionalities could be integrated directly into the Windows operating system.

## Overview
**Network Share Monitor** is a Windows desktop utility designed to automate local network sharing, dynamically update folder icons based on network status, and provide instant control over network adapters via the system tray. It handles complex PowerShell network configurations and SMB permissions through an intuitive graphical interface.

## Key Features

*   **Setup Wizard:** A multi-step installation interface handling license agreements, folder configuration, and initial security setups.
*   **Automated SMB & NTFS Configuration:** Automatically configures SMB shares and applies NTFS permissions (`icacls`) to ensure the shared folder is accessible to network devices while maintaining the chosen security level.
*   **Dynamic System Tray Control:** Runs silently in the background. The right-click context menu detects the current network state, allowing users to disconnect active adapters or enable disabled ones.
*   **Real-Time Folder Icon Updating:** Monitors network connectivity. When the status changes, the application updates the `desktop.ini` and forces Windows Explorer to refresh the icon immediately.
*   **Task Scheduler Integration:** Registers the application in the Windows Task Scheduler to launch silently with the highest privileges upon user login, bypassing UAC prompts.
*   **Elevation on Demand:** Requests Administrator privileges during installation to apply system-level modifications correctly.

## Technology Stack
*   **Language:** C# (.NET Framework 4.7.2)
*   **UI Framework:** Windows Forms (WinForms)
*   **System Integration:** Win32 APIs (`SHChangeNotify`), PowerShell, Windows Task Scheduler, SMB Protocols.
*   **External Dependencies:** Newtonsoft.Json, FolderIconUpdater.exe (for immediate icon cache flushing).

## System Requirements
*   **OS:** Windows 10 or Windows 11.
*   **Framework:** .NET Framework 4.7.2 or higher.
*   **Privileges:** Administrator rights are required for installation and network adapter management.

## Security Considerations
The application provides two modes for network sharing:
1.  **Secure Mode:** Requires standard Windows authentication (Username & Password).
2.  **Guest Mode:** Configures SMB to allow insecure guest logons. The application warns the user that this mode reduces network security and should only be used in trusted environments.

## Installation
1. Run the executable file.
2. Complete the setup wizard (Accept the license, select the target folder, and configure the security mode).
3. Click Install. Accept the Windows UAC (User Account Control) prompt.
4. Restart the computer when prompted by the installer.
5. After restarting, the application will run in the System Tray.

## License
This software is provided "AS IS", without warranty of any kind. The developer is not liable for any network disruptions or security vulnerabilities arising from the use of this application.
