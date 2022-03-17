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
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet;




namespace SnippetRepresentation
{

	/// <summary>
	/// represents the CodeSnippets\CodeSnippet\Header element
	/// </summary>
	/// <remarks>Specifies general information about the IntelliSense Code Snippet.</remarks>

	public class Header : IDataErrorInfo
	{



		private string _title;
		private string _author;
		private string _description;
		private string _helpUrl;
		private string _shortcut;
		private Keywords _keywords;

		private SnippetTypes _snippettypes;



		public Header() : this(null)
		{
		}


		public Header(XElement el)
		{
			if (el == null) {
				_keywords = new Keywords();
				_snippettypes = new SnippetTypes();
			} else {
				var _with1 = el;
				_title = _with1.Value;
				_author = _with1.Value;
				_description = _with1.Value;
				_helpUrl = _with1.Value;
				_shortcut = _with1.Value;
				_keywords = new Keywords(_with1.FirstOrDefault);
				_snippettypes = new SnippetTypes(_with1.FirstOrDefault);
			}
		}



		/// <remarks>required</remarks>
		public string Title {
			get { return _title; }
			set { _title = value; }
		}



		/// <remarks>optional</remarks>
		public string Author {
			get { return _author; }
			set { _author = value; }
		}



		/// <remarks>optional</remarks>
		public string Description {
			get { return _description; }
			set { _description = value; }
		}



		/// <remarks>optional</remarks>
		public string HelpUrl {
			get { return _helpUrl; }
			set { _helpUrl = value; }
		}



		/// <remarks>optional</remarks>
		public string Shortcut {
			get { return _shortcut; }
			set { _shortcut = value; }
		}



		/// <remarks>optional, currently not used</remarks>
		public Keywords Keywords {
			get { return _keywords; }
		}



		/// <remarks>optional</remarks>
		public SnippetTypes SnippetTypes {
			get { return _snippettypes; }
		}






		public override bool Equals(object obj)
		{

			Header hdr = obj as Header;
			if (hdr == null)
				return false;

			return (_title == hdr._title) && (_author == hdr._author) && (_description == hdr._description) && (_helpUrl == hdr._helpUrl) && (_shortcut == hdr._shortcut) && (_keywords.Equals(hdr._keywords)) && (_snippettypes.Equals(hdr._snippettypes));

		}


		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public string Error {
			get { return _title == null ? "Title required" : null; }
		}

		public string this[string columnName] {
			get {
				switch (columnName) {
					case "Title":
						return _title == null ? "Title required" : null;
					default:
						return null;
				}
			}
		}
	}

}
