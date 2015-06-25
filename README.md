# Portable launcher for Kodi
## Introduction
I was recently doing some research on using Kodi as a completely portable media centre,
and I found this thread on the Kodi forum (which helped me out a lot): [[Windows] Relative paths in portable mode](http://forum.kodi.tv/showthread.php?tid=94181).  
There was one problem: everything had to be done through a batch file,
which may ward off less-experienced users,
and I couldn't find a GUI program that does the same as the batch file.  
So I decided to make a program myself, which does (almost) the same as the batch file in the aforementioned forum thread, and more.

This program launches [Kodi/XBMC](http://kodi.tv) (hereafter referred to as just Kodi) in portable mode,
and mounts the user's media folder to a virtual hard drive, among other things.  
This is especially handy if Kodi is located on an external hard drive,
and you want to be able to run it from all computers: previously you would've had to use a batch file,
which most users aren't comfortable with. Now you can just launch 'Portable launcher for Kodi',
and Kodi will be started in portable mode.

## Requirements
- At least Windows Vista; Windows 7 or higher recommended
- .NET Framework 4.5.1 (installed by default on most modern Windows installations)

## Installation
Nothing to install, just a single `.exe` file.
Download from [/releases](https://github.com/nidunc/Portable-launcher-for-Kodi/releases).  
On first launch, the program will ask you for a few things, which it needs to be able to work.
You can change these settings after the first launch through the program's settings
(the gear icon in the top-right - appears after you've finished with the initial setup).

## Features
- [x] Launch Kodi in portable mode (with `Kodi.exe -p`)
- [x] Mount user's media folder (using the C# equivalent of `subst.exe`)
- [ ] TODO: move Kodi's installation folder to another place (an external hard drive, for example)
if it's installed on the C:\ drive (such as `C:\Program Files (x86)\Kodi` or `C:\Program Files\Kodi`),  
and uninstall Kodi from the computer afterwards (if it was installed to Program Files).
- [ ] TODO: move Kodi's application data to the "portable_data" folder in Kodi's installation folder
- [ ] TODO: use a different way of storing settings that is portable
- [ ] TODO: install/update Kodi automatically

## License
This program is licensed under the GPLv3 (GNU General Public License version 3).  
The license is in the "LICENSE" file in the root of this repository.

## Third-party libraries
- [Mahapps.Metro](http://mahapps.com) ([GitHub](https://github.com/MahApps/MahApps.Metro/))
by Paul Jenkins, Jake Ginnivan, Brendan Forster (@shiftkey), Alex Mitchell (@Amrykid), Dennis Daume (@flagbug),
Jan Karger (@punker76)
for the user interface,
licensed under the Ms-Pl (Microsoft Public License)
  - Contains the [Modern UI Icon Pack](http://modernuiicons.com/)
  ([GitHub](https://github.com/Templarian/WindowsIcons)) by Austin Andrews of [Templarian.com](http://templarian.com/)
- [Windows API Code Pack 1.1](https://github.com/aybe/Windows-API-Code-Pack-1.1) by 'Aybe' for the folder browser.
Unknown license.
- [Fody](https://github.com/Fody/Fody) and [Costura](https://github.com/Fody/Costura) by Simon Cropp and Cameron MacFarland,
for merging the program and all references (dependencies) into one `.exe` file.