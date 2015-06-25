# Portable launcher for Kodi
## Introduction
I was recently doing some research on using [Kodi/XBMC](http://kodi.tv) (hereafter referred to as just Kodi)
as a completely portable media centre, and I found this thread on the Kodi forum (which helped me out a lot):
[[Windows] Relative paths in portable mode](http://forum.kodi.tv/showthread.php?tid=94181).  
There was one problem: everything had to be done through a batch file,
which may ward off less-experienced users,
and I couldn't find a GUI program that does the same as the batch file.  
So I decided to make a program myself, which does (almost) the same as the batch file in the aforementioned forum thread, and more.

----------

If you're wondering why you need this program or a batch file in the first place to make Kodi portable,
let me explain it to you.  
Out-of-the-box Kodi is already able to be used as a fully-fledged portable media center (provided DirectX
and the Visual C++ Redistributables are installed on every one of them, of course),
but with one flaw: the media sources are static, which can cause problems if you use the same Kodi installation
on multiple computers, because an external hard drive almost never has the same drive letter.  

On one computer your media folder could be located at `D:\Media`.
On another computer this might be `E:\Media`. Or `F:\Media`. And every time this path has to be updated in
Kodi's settings, and every time all media has to be re-added.
Nobody wants to have to do that the whole time, right? Which is where this program comes in.

Before your media folder would be located here:  
Computer 1: `D:\Media`
Computer 2: `E:\Media`
Computer 3: `F:\Media`

After this program does its work, it's still located in those folders, but also in `X:\` (or whichever letter
you choose) on every computer.  
So, essentially, what this program does is mount your media folder as a virtual hard drive, and then launch
Kodi in portable mode, in which you can then (for example) specify `X:\Music`, `X:\TV-series` and `X:\Films`
as your media sources, without ever having to change that again.

## Requirements
- At least Windows Vista; Windows 7 or higher recommended
- Microsoft .NET Framework 4.5.1 (installed by default on most modern Windows installations)
- Kodi (or XBMC)

## Installation
Nothing to install, just a single `.exe` file.
Download from [/releases](https://github.com/nidunc/Portable-launcher-for-Kodi/releases).  
On first launch, the program will ask you for a few things, which it needs to be able to work.
You can change these settings after the first launch through the program's settings
(the gear icon in the top-right - appears after you've finished the initial setup).

## Features
- [x] Launch Kodi in portable mode (with `Kodi.exe -p`)
- [x] Mount user's media folder (using the C# equivalent of `subst.exe`)
- [ ] TO-DO: move Kodi's installation folder to another place (an external hard drive, for example)
if it's installed on the C:\ drive (such as `C:\Program Files (x86)\Kodi` or `C:\Program Files\Kodi`),  
and uninstall Kodi from the computer afterwards (if it was installed to Program Files).
- [ ] TO-DO: move Kodi's application data to the "portable_data" folder in Kodi's installation folder
- [ ] TO-DO: use a different way of storing settings that is portable
- [ ] TO-DO: install/update Kodi automatically

## Kodi forums page
[[Windows] Portable launcher for Kodi](http://forum.kodi.tv/showthread.php?tid=226857)

## Third-party libraries/tools used
- [MahApps.Metro](http://mahapps.com) ([GitHub](https://github.com/MahApps/MahApps.Metro/))
by Paul Jenkins, Jake Ginnivan, Brendan Forster (shiftkey), Alex Mitchell (Amrykid), Dennis Daume (flagbug),
Jan Karger (punker76) for the user interface, licensed under the
[Ms-PL (Microsoft Public License)](https://msdn.microsoft.com/en-us/library/ff649456.aspx)
- The MahApps.Metro.Resources package, which includes the [Modern UI Icon Pack](http://modernuiicons.com/)
  ([GitHub](https://github.com/Templarian/WindowsIcons)) (licensed under Creative Commons 3.0)
 by Austin Andrews of [Templarian.com](http://templarian.com/)
- [Windows API Code Pack 1.1](https://github.com/aybe/Windows-API-Code-Pack-1.1) by 'Aybe' for the folder browser.
Unknown license.
- [Fody](https://github.com/Fody/Fody) and [Costura](https://github.com/Fody/Costura)
by Simon Cropp and Cameron MacFarland, for merging the program and all references (dependencies)
into one `.exe` file, so the end-user doesn't have to download a ton of `.dll` files.
Licensed under the [MIT License](http://opensource.org/licenses/MIT).

## License
> ```
> Copyright © 2015 nidunc  
>
> "Portable launcher for Kodi" is free software: you can redistribute it and/or modify
> it under the terms of the GNU General Public License as published by
> the Free Software Foundation, either version 3 of the License, or
> (at your option) any later version.
> 
> "Portable launcher for Kodi" is distributed in the hope that it will be useful,
> but WITHOUT ANY WARRANTY; without even the implied warranty of
> MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
> GNU General Public License for more details.
> 
> You should have received a copy of the GNU General Public License
> along with "Portable launcher for Kodi".  If not, see <http://www.gnu.org/licenses/>.
> ```

Kodi™ and XBMC™ are registered trademarks of the XBMC Foundation.  
I am not affiliated with the Foundation in any way, nor do I claim to be.