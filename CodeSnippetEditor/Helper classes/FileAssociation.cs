using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//-----------------------------------------------------------------
// Copyright (c) Bill McCarthy.  
// This code and information are provided "as is"  without warranty
// of any kind either expressed or implied. Use at your own risk.
//-----------------------------------------------------------------


 // ERROR: Not supported in C#: OptionDeclaration
using Microsoft.Win32;





/// <summary>
/// class to enable or remove file associations
/// </summary>
/// <remarks>
///  See GetWritableClassesRoot remarks for details about dealing with UAC and x86 virtualization on x86)
///  </remarks>
internal sealed class FileAssociation
{

	private const string _AssociationName = "VB Snippet Editor";
	private const string _previous = "previous";

	private const string _Description = "Visual Studio Snippet";

	private FileAssociation()
	{
		// shared class
	}


	public static bool IsAssociated(string extension)
	{

		using (RegistryKey regkey = Registry.ClassesRoot.OpenSubKey(extension)) {
			if ((regkey != null) && (regkey.GetValue("", "").ToString() == _AssociationName)) {
				return true;
			} else {
				return false;
			}
		}

	}




	public static bool Associate(string extension, bool @remove)
	{
		if (extension == null)
			return false;

		RegistryKey regkey = null;
		string oldValue = null;

		try {

			if (@remove) {
				if (IsAssociated(extension)) {
					regkey = GetWritableClassesRoot().OpenSubKey(extension, true);
					oldValue = regkey.GetValue(_previous, "").ToString;
					regkey.SetValue("", oldValue, RegistryValueKind.String);
					regkey.DeleteValue(_previous, false);
				}

			//adding the key
			} else {

				regkey = GetWritableClassesRoot().CreateSubKey(extension);
				//gives us write permissions
				oldValue = regkey.GetValue("", "").ToString;
				if (oldValue != _AssociationName) {
					regkey.SetValue(_previous, oldValue, RegistryValueKind.String);
					regkey.SetValue("", _AssociationName, RegistryValueKind.String);
				}
				EnsureAppKey();
			}

		} catch (Exception ex) {
			if (Threading.Interlocked.Exchange(_UserMode, 2) == 1) {
				// try calling the method again using HKCU.  See GetWritableClassesRoot remarks for details.
				Associate(extension, @remove);
			} else {
				throw;
			}
		} finally {
			if (regkey != null)
				regkey.Close();
		}

	}




	private static void EnsureAppKey()
	{
		string appPath = System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName;
		if (appPath.EndsWith(".vshost.exe"))
			appPath = appPath.Substring(0, appPath.Length - 11) + ".exe";

		// key doesn't exist so let's create it
		using (RegistryKey regkey = GetWritableClassesRoot().CreateSubKey(_AssociationName)) {

			regkey.SetValue("", _Description);
			RegSetSubKeyValue(regkey, "DefaultIcon", "", "\"" + appPath + "\",0", RegistryValueKind.String);
			RegSetSubKeyValue(regkey, "Shell", "", "open", RegistryValueKind.String);
			RegSetSubKeyValue(regkey, "Shell\\open", "", "&Open", RegistryValueKind.String);
			RegSetSubKeyValue(regkey, "Shell\\open\\command", "", "\"" + appPath + "\" \"%1\"", RegistryValueKind.String);

		}
	}


	// helper function to set sub-key values

	private static void RegSetSubKeyValue(RegistryKey root, string subkey, string name, object value, RegistryValueKind kind)
	{
		using (RegistryKey regkey = root.CreateSubKey(subkey)) {
			regkey.SetValue(name, value, kind);
		}

	}


		// flag to determine to use HKLM (1) or HCKU (2). See GetWritableClassesRoot remarks for details.
	private static Int32 _UserMode;

	/// <summary>
	/// Gets the writable part of ClassesRoot.
	/// </summary>
	/// <returns>registryKey. Ensure you close it.</returns>
	/// <remarks>
	/// If the user can't write to HKLM, then HKCU is used. 
	/// The result of the test is stored in the _UserMode field, HKLM (1) or HCKU (2)
	/// An oddity exists when running with UAC on and as x86 on x64 (WOW64), where the HKLM open with write permissions but fails when attempted to be used.
	/// To deal with this the _UserMode flag is checked in write methods, and if it is 1 (HKLM), it is changed to 2 (HKCU) and the method is retried.
	/// </remarks>
	private static RegistryKey GetWritableClassesRoot()
	{
		RegistryKey regkey = null;
		switch (_UserMode) {
			case 0:
				// need to check if HKLM can be used
				try {
					regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes", true);
					Threading.Interlocked.Exchange(_UserMode, 1);
				} catch (Exception ex) {
					regkey = Registry.CurrentUser.OpenSubKey("Software\\Classes", true);
					Threading.Interlocked.Exchange(_UserMode, 2);
				}
				break;
			case 1:
				// can use HKLM
				regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes", true);
				break;
			case 2:
				// has to use HKCU
				regkey = Registry.CurrentUser.OpenSubKey("Software\\Classes", true);
				break;
		}
		return regkey;
	}




}






