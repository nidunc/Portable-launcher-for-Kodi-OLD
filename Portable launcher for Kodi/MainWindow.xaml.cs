// Portable launcher for Kodi - launches Kodi/XBMC in portable mode and mounts user's media folder as a virtual hard drive, among other things
// Copyright © 2015 nidunc
// 
// This file is part of "Portable launcher for Kodi"
// 
// "Portable launcher for Kodi" is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// "Portable launcher for Kodi" is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with "Portable launcher for Kodi".  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using KodiPortableLauncher.Properties;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace KodiPortableLauncher
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			// Checks if this is a new version, in which case the program transfers (upgrades) the old settings
			if (Settings.Default.upgradeRequired)
			{
				Settings.Default.Upgrade();
				Settings.Default.upgradeRequired = false;
				Settings.Default.Save();
			}

			if (Settings.Default.firstRun)
			{
				NavigationTabControl.SelectedItem = FirstRun;
				FirstRunTabControl.SelectedItem = FirstRunStep1;
				BtnHelp.Visibility = Visibility.Hidden;
				BtnSettings.Visibility = Visibility.Hidden;
			}

			var driveLetters = new ArrayList(26); // Allocate space for alphabet
			for (var i = 65; i < 91; i++) // increment from ASCII values for A-Z
			{
				driveLetters.Add(Convert.ToChar(i)); // Add uppercase letters to possible drive letters
			}

			foreach (var drive in Directory.GetLogicalDrives())
			{
				driveLetters.Remove(drive[0]); // remove used drive letters from possible drive letters
			}

			foreach (char drive in driveLetters)
			{
				cbDriveLetter1.Items.Add(drive + ":"); // add unused drive letters to the combobox
			}
		}

		public string Mc
		{
			get { return Settings.Default.KodiOrXbmc; }
			set { Settings.Default.KodiOrXbmc = value; }
		}

		public void ExeLocationBrowser()
		{
			// Create new OpenFileDialog instance under name fileDialog
			var fileDialog = new OpenFileDialog
			{
				Title = "Select the main " + Mc + " executable file (" + Mc + ".exe)",
				Filter = Mc + ".exe|" + Mc + ".exe|Executable Files|*.exe",
				InitialDirectory =
					Environment.GetFolderPath(Environment.Is64BitOperatingSystem
						? Environment.SpecialFolder.ProgramFilesX86
						: Environment.SpecialFolder.ProgramFiles) + @"\" + Mc,
				Multiselect = false
			};

			var result = fileDialog.ShowDialog(); // Open fileDialog

			// Check if user clicked OK. If OK was clicked, the selected file will be entered into the text field
			if (result == true)
				TxtKodiXbmcExeLocation1.Text = fileDialog.FileName;
		}

		public void MediaFolderBrowser()
		{
			var folderDialog = new CommonOpenFileDialog
			{
				Title = "Select the folder which contains your media",
				IsFolderPicker = true,
				Multiselect = false,
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
			};

			if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
				TxtMediaFolderLocation1.Text = folderDialog.FileName;
		}

		// The "BtnGoToFirstRunStep2" button moves the focus to the second step in the "FirstRunTabControl" tabcontrol
		private void BtnGoToFirstRunStep2_Click(object sender, RoutedEventArgs e)
			=> FirstRunTabControl.SelectedItem = FirstRunStep2;

		// If the selected index changes (Kodi or XBMC)
		private void CbKodiOrXbmc1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (CbKodiOrXbmc1.SelectedIndex)
			{
				case 0:
					Mc = "Kodi";
					break;
				case 1:
					Mc = "XBMC";
					break;
			}

			TbSelectKodiXbmcExeLocation1.Text = "Where is your " + Mc + " executable located?";
		}

		private async void BtnBrowseKodiXbmcExe1_Click(object sender, RoutedEventArgs e)
		{
			if (CbKodiOrXbmc1.SelectedItem != null)
			{
				ExeLocationBrowser();
			}
			else
			{
				var mySettings = new MetroDialogSettings
				{
					ColorScheme = MetroDialogColorScheme.Accented
				};

				await this.ShowMessageAsync("Warning", "Please select Kodi or XBMC in the combobox",
					MessageDialogStyle.Affirmative, mySettings);
			}
		}

		private async void BtnGoToFirstRunStep2Part2_Click(object sender, RoutedEventArgs e)
		{
			var mySettings = new MetroDialogSettings
			{
				ColorScheme = MetroDialogColorScheme.Accented
			};

			if (string.IsNullOrWhiteSpace(TxtKodiXbmcExeLocation1.Text))
			{
				if (string.IsNullOrWhiteSpace(Mc))
				{
					await this.ShowMessageAsync("Warning", "Please\n" +
					                                       "1) select Kodi or XBMC in the combobox and\n" +
					                                       "2) select the executable\n" +
					                                       "before continuing",
						MessageDialogStyle.Affirmative, mySettings);
				}
				else
				{
					await this.ShowMessageAsync("Warning", "Please select the " + Mc + " executable before continuing",
						MessageDialogStyle.Affirmative, mySettings);
				}
			}
			else
			{
				FirstRunStep2TabControl.SelectedItem = FirstRunStep2Part2;
			}
		}

		// "BtnBrowseMediaFolder1" opens the folder browser to allow the user to select their media folder on click
		private void BtnBrowseMediaFolder1_Click(object sender, RoutedEventArgs e) => MediaFolderBrowser();

		private void BtnGoToFirstRunStep2Part3_Click(object sender, RoutedEventArgs e)
		{
		}

		private void BtnAbout_Click(object sender, RoutedEventArgs e)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

			if (!AboutFlyout.IsOpen)
			{
				aboutDesc.Text = fvi.Comments;
				aboutVersion.Text = fvi.ProductVersion;
				devCopyright.Text = fvi.LegalCopyright;
			}

			// If the "About" flyout is open, it will be closed, and vice versa
			AboutFlyout.IsOpen = !AboutFlyout.IsOpen;
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			if (sender.GetType() != typeof (Hyperlink))
				return;
			var link = ((Hyperlink) sender).NavigateUri.ToString();
			Process.Start(link);
		}

		private static class Subst
		{
			public static void MapDrive(char letter, string path)
			{
				if (!DefineDosDevice(0, DevName(letter), path))
					throw new Win32Exception();
			}

			public static void UnmapDrive(char letter)
			{
				if (!DefineDosDevice(2, DevName(letter), null))
					throw new Win32Exception();
			}

			public static string GetDriveMapping(char letter)
			{
				var sb = new StringBuilder(259);
				if (QueryDosDevice(DevName(letter), sb, sb.Capacity) == 0)
				{
					// Return empty string if the drive is not mapped
					var err = Marshal.GetLastWin32Error();
					if (err == 2) return "";
					throw new Win32Exception();
				}
				return sb.ToString().Substring(4);
			}

			private static string DevName(char letter)
			{
				return new string(char.ToUpper(letter), 1) + ":";
			}

			[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern bool DefineDosDevice(int flags, string devname, string path);

			[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern int QueryDosDevice(string devname, StringBuilder buffer, int bufSize);
		}
	}
}