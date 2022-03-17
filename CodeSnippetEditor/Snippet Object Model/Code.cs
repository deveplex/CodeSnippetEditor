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
using System.Linq;
using System.Xml;
using System.Xml.Linq;
//using <xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">;
using System.ComponentModel;



namespace SnippetRepresentation
{

	/// <summary>
	/// This class represents the CodeSnippets\CodeSnippet\Snippet\Code element
	/// </summary>
	/// <remarks></remarks>
	public class Code : IDataErrorInfo
	{



		private string _codeData = "";
		private string _language = "VB";
		private string _delimiter = "$";

		private string _kind = "";

		public Code() : this(null)
		{
		}

		public Code(XElement el)
		{
			if (el != null) {
				Data = el.Value;
				Language = el;
				Kind = el;
				_delimiter = el ?? "$";
			}
		}


		/// <summary>
		/// the snippet's code 
		/// </summary>
		/// <remarks>required</remarks>
		public string Data {
			get { return _codeData; }
			set { _codeData = value; }
		}


		/// <summary>
		/// code language: should be one of the following : 'VB', 'CSharp', 'XML' or 'JSharp'
		/// </summary>
		/// <remarks>required</remarks>
		public string Language {
			get { return _language; }
			set {
				if (value == null)
					value = "VB";
				_language = value;
			}
		}


		/// <summary>
		/// delimiter used for literals and objects within the code
		/// </summary>
		/// <remarks>optional. defaults to $</remarks>
		public string Delimiter {
			get { return _delimiter; }
			set {
				if (value == null)
					value = "$";
				_delimiter = value;
			}
		}


		/// <summary>
		///  scope of the snippet: type declaration, method declaration, method body, page (for asp.net) or comment.
		/// </summary>
		/// <remarks>optional</remarks>
		public string Kind {
			get { return _kind; }
			set {
				if (value == null)
					value = "";
				_kind = value;
			}
		}



		#region "equality methods"


		public override bool Equals(object obj)
		{

			Code rep = obj as Code;
			if (rep == null)
				return false;

			return string.Equals(_language, rep._language, StringComparison.OrdinalIgnoreCase) && _delimiter == rep._delimiter && _kind == rep._kind && _codeData == rep._codeData;

		}


		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion


		#region "IDataErrorInfo"

		public string Error {
			get {
				if (Language == null) {
					return "you need to specify a language";
				} else {
					return null;
				}
			}
		}

		public string this[string columnName] {
			get {
				switch (columnName) {
					case "Language":
						if (Language == null)
							return "you need to specify a language";
						break;
					default:
						return null;
				}
				return null;
			}
		}

		#endregion

	}

}

