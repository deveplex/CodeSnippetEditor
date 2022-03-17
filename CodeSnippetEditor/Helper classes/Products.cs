using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
//-----------------------------------------------------------------
// Copyright (c) Bill McCarthy.  
// This code and information are provided "as is"  without warranty
// of any kind either expressed or implied. Use at your own risk.
//-----------------------------------------------------------------


 // ERROR: Not supported in C#: OptionDeclaration
using Microsoft.Win32;
using System.Text;
using VB = Microsoft.VisualBasic;
using static System.Environment;

namespace Utility
{

	// used by My.Settings.Products.
	//****************************************
	//<ArrayOfProduct xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	//    xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	//   <Product>
	//      <Name>Visual Studio 2005</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VisualStudio\8.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Basic 2005 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VBExpress\8.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual C# 2005 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VCSExpress\8.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Web Developer 2005 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VWDExpress\8.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Studio 2008</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VisualStudio\9.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Basic 2008 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VBExpress\9.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual C# 2008 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VCSExpress\9.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Web Developer 2008 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VWDExpress\9.0</RegistryPath>
	//   </Product >
	//   <Product>
	//      <Name>Visual Studio 2010</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VisualStudio\10.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Basic 2010 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VBExpress\10.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual C# 2010 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VCSExpress\10.0</RegistryPath>
	//   </Product>
	//   <Product>
	//      <Name>Visual Web Developer 2010 Express Edition</Name>
	//      <RegistryPath>SOFTWARE\Microsoft\VWDExpress\10.0</RegistryPath>
	//   </Product >
	//</ArrayOfProduct>
	//*********************************


	public class ProductCollection : List<Product>
	{

		public Product Find(string name)
		{
			foreach (Product prod in this) {
				if (prod.Name == name)
					return prod;
			}
			return null;
		}

	}




	public class Product
	{


		internal string CodeExpansionsPath = "Languages\\CodeExpansions";
		private string _Name;
		private string _RegistryPath;
		private Language.LanguageCollection _Languages;

		private Int32 _LCID;
		public string Name {
			get { return _Name; }
			set { _Name = value; }
		}



		public string RegistryPath {
			get { return _RegistryPath; }
			set { _RegistryPath = value; }
		}

		public string HKLMRegistryPath {
			get {
				if (IntPtr.Size == 8) {
					// 64 bit product change path to Wow6432Node
					// Thanks to Ken Tucker for providng this 64 bit fix.
					return RegistryPath.Replace("SOFTWARE\\", "SOFTWARE\\Wow6432Node\\");
				} else {
					return RegistryPath;
				}
			}
		}



		[System.Xml.Serialization.XmlIgnore()]
		public Language.LanguageCollection Languages {
			get {
				if (_Languages == null) {
					_Languages = new Language.LanguageCollection(this);

				}
				return _Languages;
			}
		}


		public bool IsInstalled {
			get {
				string path = this.RegistryPath;
				if (path == null)
					return false;
				using (RegistryKey hkey = Registry.CurrentUser.OpenSubKey(this.RegistryPath + "\\General")) {
					return (hkey != null);
				}
			}
		}


		public Int32 LCID {
			get {
				if (_LCID == 0) {
					using (RegistryKey hkey = Registry.CurrentUser.OpenSubKey(this.RegistryPath + "\\General")) {
						_LCID = Convert.ToInt32(hkey.GetValue("UILanguage", -1));
					}
					//it's the system lanugage
					if (_LCID < 0) {
						_LCID = System.Globalization.CultureInfo.CurrentUICulture.LCID;
					}
				}
				return _LCID;
			}
		}



		//Friend Sub InitializeUserRegistry()
		//   ' loop through the keys in HKLM\Software\Microsoft\VisualStudio\9.0\Languages\CodeExpansions
		//   ' then find the package and find the package satelliteDll, then get the resource string
		//   ' using that string then create the sub key in HKCU\\Software\Microsoft\VisualStudio\9.0\Languages\CodeExpansions
		//   ' then set the path and copy the Paths sub nodes over (optional)

		//   If Not IsInstalled Then Return

		//   Dim snippetLangID As String
		//   Dim langName As String


		//   Using rootKey As RegistryKey = Registry.LocalMachine.OpenSubKey(Me.HKLMRegistryPath, False), _
		//       languageKey As RegistryKey = rootKey.OpenSubKey(Me.CodeExpansionsPath, False), _
		//       hkcuKey As RegistryKey = Registry.CurrentUser.CreateSubKey(Me.RegistryPath & "\" & Me.CodeExpansionsPath)

		//      If rootKey Is Nothing Or languageKey Is Nothing Or hkcuKey Is Nothing Then
		//         Return
		//      End If

		//      For Each subkeyName As String In languageKey.GetSubKeyNames

		//         Dim subkey As RegistryKey = languageKey.OpenSubKey(subkeyName, False)

		//         If subkey Is Nothing Then Continue For

		//         Dim snippetLangID_Object As Object = subkey.GetValue("")

		//         If snippetLangID_Object Is Nothing Then Continue For

		//         snippetLangID = snippetLangID_Object.ToString()

		//         langName = subkey.GetValue("DisplayName").ToString()

		//         ' XML language has resid as #200 so need ot strip of leading "#"
		//         If langName.StartsWith("#") Then langName = langName.Substring(1)

		//         ' if the langName is numeric then need to get the langName from the package resource string table
		//         If VB.IsNumeric(langName) Then
		//            Dim resID As UInt32 = CUInt(langName)
		//            Dim package As String = subkey.GetValue("Package").ToString()
		//            Using packageKey As RegistryKey = rootKey.OpenSubKey("Packages\" & package & "\SatelliteDll", False)
		//               Dim path As String = packageKey.GetValue("Path", "").ToString()
		//               path = IO.Path.Combine(path, Me.LCID.ToString())
		//               path = IO.Path.Combine(path, packageKey.GetValue("DllName", "").ToString())
		//               langName = NativeMethods.GetResourceString(path, resID)
		//               If langName = Nothing Then langName = subkeyName
		//            End Using
		//         End If


		//         'concat path

		//         Dim sb As New Text.StringBuilder
		//         Using regKey As RegistryKey = languageKey.OpenSubKey(subkeyName & "\Paths", False)

		//            For Each subName As String In regKey.GetValueNames
		//               Dim temp As String = regKey.GetValue(subName, "").ToString().Trim()
		//               If temp.Length > 0 Then
		//                  sb.Append(temp)
		//                  If Not temp.EndsWith(";") Then sb.Append(";")
		//               End If
		//            Next
		//         End Using


		//         ' now create the HKCU keys.

		//         Using userKey As RegistryKey = hkcuKey.CreateSubKey(langName)
		//            userKey.SetValue("", snippetLangID, RegistryValueKind.String)
		//            userKey.SetValue("Path", sb.ToString(), RegistryValueKind.String)
		//         End Using

		//      Next

		//   End Using
		//End Sub




	}



	public class Language
	{


		public class LanguageCollection : System.Collections.ObjectModel.Collection<Language>
		{


			private Product _product;
			public LanguageCollection(Product parent, bool loadFromRegistry = true)
			{
				_product = parent;
				if (loadFromRegistry)
					LoadLanguagesFromRegistry();
			}

			protected override void InsertItem(int index, Language item)
			{
				item._Product = _product;
				base.InsertItem(index, item);
			}

			private void LoadLanguagesFromRegistry()
			{
				using (RegistryKey languageKey = Registry.LocalMachine.OpenSubKey(_product.HKLMRegistryPath + "\\" + _product.CodeExpansionsPath + "\\", false)) {
					if (languageKey != null) {
						foreach (var key_loopVariable in languageKey.GetSubKeyNames()) {
							var key = key_loopVariable;
							if (key != null)
								this.Add(new Language(key));
						}
					}
				}
			}

		}



		public static readonly Language UnCatalogued = new Language("UnCatalogued");
		private string _Name;
		private string _LocalisedName;

		private Product _Product;

		public Language()
		{
			//
		}


		public Language(string name)
		{
			this._Name = name;
			if (name == "UnCatalogued")
				_LocalisedName = "UnCatalogued";
		}


		public string Name {
			get { return this._Name; }
			set { this._Name = value; }
		}


		[System.Xml.Serialization.XmlIgnore()]
		public string LocalisedName {
			get {
				if (this._LocalisedName == null) {
					if (this.Product.IsInstalled) {
						this._LocalisedName = GetLocalisedName();
					}
				}
				if (this._LocalisedName == null) {
					this._LocalisedName = this.Name;
				}
				return this._LocalisedName;
			}
		}


		public bool IsInstalled {
			get {
				using (RegistryKey languageKey = Registry.LocalMachine.OpenSubKey(this.Product.HKLMRegistryPath + "\\" + this.Product.CodeExpansionsPath + "\\" + this.Name, false)) {
					return Convert.ToString(languageKey.GetValue("DisplayName", "")) != null;
				}
			}
		}


		public Product Product {
			get { return this._Product; }
		}


		public string[] GetExpandedPaths()
		{
			string paths = this.SnippetsPath;
			paths = ReplaceVars(paths);
			return paths.Split(';');
		}


		[System.Xml.Serialization.XmlIgnore()]
		public string SnippetsPath {
			get {
				using (RegistryKey regKey = GetRegLanguagePathKey()) {
					if (regKey == null)
						return "";
					return regKey.GetValue("Path", "").ToString();
				}
			}
			set {
				using (RegistryKey regKey = GetRegLanguagePathKey()) {
					if (regKey == null)
						return;
					regKey.SetValue("Path", value);
				}
			}
		}


		#region "private helper methods"

		private string ReplaceVars(string strIn)
		{
			string strOut = null;
			if (strIn == null)
				return "";
			strOut = strIn.Replace("%MyDocs%", GetMyDocs());
			strOut = strOut.Replace("%InstallRoot%\\", GetInstallRoot());
			strOut = strOut.Replace("%LCID%", this.Product.LCID.ToString());
			return strOut;
		}



		string static_GetInstallRoot_m_InstallRoot;
		private string GetInstallRoot()
		{
			if (static_GetInstallRoot_m_InstallRoot == null) {
				using (RegistryKey hkey = Registry.LocalMachine.OpenSubKey(this.Product.HKLMRegistryPath + "\\Setup\\VS")) {
					static_GetInstallRoot_m_InstallRoot = hkey.GetValue("ProductDir", System.IO.Path.Combine(GetFolderPath(SpecialFolder.ProgramFiles), "Microsoft Visual Studio 9")).ToString();
				}
			}
			if (!static_GetInstallRoot_m_InstallRoot.EndsWith("\\"))
				static_GetInstallRoot_m_InstallRoot += "\\";
			return static_GetInstallRoot_m_InstallRoot;
		}


		private string GetMyDocs()
		{
			if (this.Product == null)
				return GetFolderPath(SpecialFolder.MyDocuments);
			string docsPath = null;
			using (RegistryKey hkey = Registry.CurrentUser.OpenSubKey(this.Product.RegistryPath)) {
				docsPath = hkey.GetValue("VisualStudioLocation", "").ToString();
			}
			if (docsPath == null)
				docsPath = GetFolderPath(SpecialFolder.MyDocuments);
			return docsPath;
		}



        private string GetLocalisedName()
        {

            using (RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(this.Product.HKLMRegistryPath + "\\" + Product.CodeExpansionsPath + "\\" + this.Name, false))
            {

                if (rootKey == null)
                    return this.Name;

                string resIDString = rootKey.GetValue("DisplayName", "").ToString();

                // special handling for XML language as it has resid as #200 so need to strip of leading "#"
                if (resIDString.StartsWith("#"))
                    resIDString = resIDString.Substring(1);

                // if the resID is numeric then need to get the LocalisedName from the package resource string table
                UInt32 id;
                if (UInt32.TryParse(resIDString, out id))
                {
                    string package = rootKey.GetValue("Package").ToString();
                    using (RegistryKey packageKey = Registry.LocalMachine.OpenSubKey(this.Product.HKLMRegistryPath + "\\Packages\\" + package + "\\SatelliteDll", false))
                    {
                        string path = packageKey.GetValue("Path").ToString();
                        if (path == null)
                            return resIDString;
                        path = System.IO.Path.Combine(path, this.Product.LCID.ToString());
                        path = System.IO.Path.Combine(path, packageKey.GetValue("DllName").ToString());
                        resIDString = NativeMethods.GetResourceString(path, id);
                    }
                }

                return resIDString;
            }
        }



		private RegistryKey GetRegLanguagePathKey()
		{
			if (this.Product == null)
				return null;

			string CodeExpansionsRegKeyPath = this.Product.RegistryPath + "\\" + this.Product.CodeExpansionsPath;

			RegistryKey regKey = Registry.CurrentUser.OpenSubKey(CodeExpansionsRegKeyPath + "\\" + this.LocalisedName, true);

			if (regKey == null || regKey.ValueCount == 0) {
				if (this.IsInstalled)
					this.InitializeUserRegistry();
			}

			if (regKey == null) {
				regKey = Registry.CurrentUser.OpenSubKey(CodeExpansionsRegKeyPath + "\\" + this.LocalisedName, true);
			}

			return regKey;

		}


		internal void InitializeUserRegistry()
		{
			// find the package and find the package satelliteDll, then get the resource string
			// using that string then create the sub key in HKCU\\Software\Microsoft\VisualStudio\9.0\Languages\CodeExpansions
			// then set the path and copy the Paths sub nodes over (optional)

			if ((!IsInstalled) | (this.Product == null))
				return;

			string snippetLangID = null;
			string langName = null;


			using (RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(this.Product.HKLMRegistryPath, false)) {
				using (RegistryKey languageKey = rootKey.OpenSubKey(this.Product.CodeExpansionsPath, false)) {
					using (RegistryKey hkcuKey = Registry.CurrentUser.CreateSubKey(this.Product.RegistryPath + "\\" + this.Product.CodeExpansionsPath)) {

						if (rootKey == null | languageKey == null | hkcuKey == null) {
							return;
						}



						RegistryKey subkey = languageKey.OpenSubKey(this.Name, false);

						if (subkey == null)
							return;

						object snippetLangID_Object = subkey.GetValue("");

						if (snippetLangID_Object == null)
							return;

						snippetLangID = snippetLangID_Object.ToString();

						langName = subkey.GetValue("DisplayName").ToString();

						// XML language has resid as #200 so need ot strip of leading "#"
						if (langName.StartsWith("#"))
							langName = langName.Substring(1);

                        // if the langName is numeric then need to get the langName from the package resource string table
                        UInt32 resID;
                        if (UInt32.TryParse(langName, out resID))
                             {
							string package = subkey.GetValue("Package").ToString();
							using (RegistryKey packageKey = rootKey.OpenSubKey("Packages\\" + package + "\\SatelliteDll", false)) {
								string path = packageKey.GetValue("Path", "").ToString();
								path = System.IO.Path.Combine(path, this.Product.LCID.ToString());
								path = System.IO.Path.Combine(path, packageKey.GetValue("DllName", "").ToString());
								langName = NativeMethods.GetResourceString(path, resID);
								if (langName == null)
									langName = this.Name;
							}
						}


						//concat path

						StringBuilder sb = new StringBuilder();
						using (RegistryKey regKey = languageKey.OpenSubKey(this.Name + "\\Paths", false)) {

							foreach (string subName in regKey.GetValueNames()) {
								string temp = regKey.GetValue(subName, "").ToString().Trim();
								if (temp.Length > 0) {
									sb.Append(temp);
									if (!temp.EndsWith(";"))
										sb.Append(";");
								}
							}
						}


						// now create the HKCU keys.

						using (RegistryKey userKey = hkcuKey.CreateSubKey(langName)) {
							userKey.SetValue("", snippetLangID, RegistryValueKind.String);
							userKey.SetValue("Path", sb.ToString(), RegistryValueKind.String);
						}


					}
				}
			}
		}




		#endregion


	}




	internal partial class NativeMethods
	{

		private NativeMethods()
		{
		}
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		private static extern Int32 LoadString(IntPtr hInstance, UInt32 uID, StringBuilder lpBuffer, Int32 nBufferMax);
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FreeLibrary(IntPtr hModule);

        static internal string GetResourceString(string path, UInt32 resourceID)
		{
			IntPtr hModule = default(IntPtr);
			StringBuilder sb = new StringBuilder(256);
			string retVal = null;
			try {
				hModule = LoadLibrary(path);
				LoadString(hModule, resourceID, sb, 255);
				retVal = sb.ToString();
			} finally {
				FreeLibrary(hModule);
			}
			return retVal;
		}

	}




}
