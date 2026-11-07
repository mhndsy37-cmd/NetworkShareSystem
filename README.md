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

##  Future Roadmap & Advanced Features

The project is designed with a modular architecture, allowing for continuous expansion. Below is the complete technical roadmap for upcoming features, categorized by their functional domain.

###  1. Comprehensive Settings Dashboard (GUI)
- [ ] **File & Permission Manager:** A visual TreeView (like Windows Explorer) to manage files directly from the app. Includes creating new folders, moving directories, and modifying NTFS permissions for specific sub-folders.
- [ ] **Dynamic Network User Manager:** Create and manage "Fake Network Users" (e.g., a dedicated `NetworkUser` with a specific password). This allows secure network access without exposing the main Windows administrator account.
- [ ] **Random Password Generator:** A built-in tool to generate strong, random passwords for the network user to maximize security.
- [ ] **Dynamic Share Name:** Allow the user to rename the network share directly from the settings without re-installing.

###  2. Advanced Routing, VPN & Connectivity
- [ ] **IP & DNS Manager:** Quick configuration of Static/Dynamic IPs, Custom DNS servers, and a built-in "Flush DNS" utility.
- [ ] **VPN & Tunneling Hub:** A built-in interface to manage Windows native VPNs (L2TP, SSTP) as well as modern tunnel cores (e.g., Xray, Sing-box).
- [ ] **Subscription Link Parser:** Allow users to paste a subscription link (Base64), automatically parse the server configs, and generate the required JSON files to establish the tunnel.
- [ ] **Split Tunneling:** Define routing rules so local LAN traffic (e.g., accessing the shared folder) stays direct, while internet traffic is routed through the VPN/Tunnel.

###  3. Advanced Network Security & Emergency Controls
- [ ] **Emergency Kill Switch (Panic Button):** A system tray option to instantly disconnect all physical network adapters, revoke SMB sharing, and strictly quarantine the shared folder (NTFS lockdown) in case of a suspected breach.
- [ ] **Mini-IDS (Host-based Intrusion Detection):** A background monitor that detects suspicious network behavior (e.g., port scanning, brute-force attempts) and automatically creates Windows Firewall rules to block the offending IPs.
- [ ] **SMB Security Profiles:** Allow users to toggle between "Maximum Security" (enforces SMB Signing and Encryption) and "Maximum Performance" (disables SMB Signing/Encryption) based on their current needs.
- [ ] **Randomized Identity (Privacy):** Implement automated random MAC address generation (for supported Wi-Fi adapters) and random IP allocation to prevent local network tracking.

###  4. Data Safety & Storage Management
- [ ] **Network Configuration Rollback:** Automatically generate a configuration snapshot (`netsh dump`) before applying major network changes. Users can revert to a safe state with a single click if the network breaks.
- [ ] **Git-like File Versioning:** Utilize `FileSystemWatcher` to monitor the shared folder. Automatically maintain a hidden history of modified and deleted files, allowing users to restore previous versions directly from the UI.
- [ ] **Atomic File Transfers (Integrity Protection):** Monitor `Get-SmbOpenFile` to detect interrupted file transfers (e.g., due to Wi-Fi drops). Move incomplete/corrupted files to a quarantine folder to prevent data loss.
- [ ] **Storage Reservation:** Allow users to reserve a specific amount of disk space (via placeholder files or NTFS Quotas) exclusively for network transfers.
- [ ] **Real-Time Transfer Logs:** Display live upload/download speeds and log all file transfers (who accessed, what file, and transfer speed) for auditing purposes.

###  5. Traffic Shaping & Application Control
- [ ] **App Network Controller:** A user-friendly GUI to manage Windows Firewall rules per application:
  - Block an application entirely.
  - Restrict it to LAN only.
  - Schedule internet access (e.g., block gaming apps from 10 PM to 6 AM).
- [ ] **Speed Throttling (QoS):** Implement Windows QoS policies (`New-NetQosPolicy`) to limit the upload/download speed of specific applications or network adapters.
- [ ] **Data Quotas:** Set data usage limits for specific applications (e.g., 5 GB/month). The app will monitor usage and automatically block the app when the limit is reached.
- [ ] **Traffic Prioritization:** Assign network priority levels to specific devices or users on the network (requires compatible router API integration).

### 6. Network Diagnostics & Optimization
- [ ] **Connection Tester:** Built-in tools to ping local gateways and global servers (e.g., 8.8.8.8) to test internet and local connectivity.
- [ ] **Network Speed Test:** A built-in module to test actual internet download/upload speeds and adapter health (Packet Loss & Latency).
- [ ] **Network Optimizer:** A one-click TCP optimizer to adjust Windows network parameters (MTU, TCP Window Size) for maximum speed.
- [ ] **Adapter Configuration:** Advanced settings to change specific hardware parameters of the network card (Speed & Duplex, Energy Efficient Ethernet, etc.).

## License
This software is provided "AS IS", without warranty of any kind. The developer is not liable for any network disruptions or security vulnerabilities arising from the use of this application.
