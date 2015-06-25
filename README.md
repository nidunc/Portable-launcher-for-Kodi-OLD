# Portable launcher for Kodi
## Introduction
This program launches [Kodi/XBMC](http://kodi.tv) (hereafter referred to as just Kodi) in portable mode,
and mounts the user's media folder to a virtual hard drive, among other things.  
This is especially handy if Kodi is located on an external hard drive,
and you want to be able to run it from all computers: previously you would've had to use a batch file,
which most users aren't comfortable with. Now you can just launch 'Portable launcher for Kodi',
and Kodi will be started in portable mode.

## Features
- [x] Launch Kodi in portable mode (with `Kodi.exe -p`)
- [x] Mount user's media folder (using the C# equivalent of `subst.exe`)
- [ ] TODO: move Kodi's installation folder to another place (an external hard drive, for example)
if it's installed on the C:\ drive (such as `C:\Program Files (x86)\Kodi` or `C:\Program Files\Kodi`),  
and uninstall Kodi from the computer afterwards (if it was installed to Program Files).
- [ ] TODO: move Kodi's application data to the "portable_data" folder in Kodi's installation folder
- [ ] TODO: use a different way of storing settings that is portable
- [ ] TODO: install/update Kodi automatically

## Installation
Nothing to install, just a single `.exe` file.
Download from [/releases](https://github.com/nidunc/Portable-launcher-for-Kodi/releases).  
On first launch, the program will ask you for a few things, which it needs to be able to work.
You can change these settings after the first launch through the program's settings
(the gear icon in the top-right - appears after you've finished with the initial setup).

## Requirements
- At least Windows Vista; Windows 7 or higher recommended
- .NET Framework 4.5.1 (installed by default on most modern Windows installations)

## License
This program is licensed under the GPLv3 (GNU General Public License version 3).  
The license is in the "LICENSE" file in the root of this repository.

## Third-party libraries
- [Mahapps.Metro](http://mahapps.com) ([GitHub](https://github.com/MahApps/MahApps.Metro/)) for the user interface,
licensed under the Ms-Pl (Microsoft Public License)
  - Contains the [Modern UI Icon Pack](http://modernuiicons.com/)
  ([GitHub](https://github.com/Templarian/WindowsIcons)) by Austin Andrews of [Templarian.com](http://templarian.com/)
- [Windows API Code Pack 1.1](https://github.com/aybe/Windows-API-Code-Pack-1.1) by 'Aybe' for the folder browser.
Unknown license.
