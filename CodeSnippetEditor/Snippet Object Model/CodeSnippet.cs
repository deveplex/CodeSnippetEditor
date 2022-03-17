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
using http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet;




namespace SnippetRepresentation
{
	/// <summary>
	/// represents the CodeSnippets\CodeSnippet element. 
	/// </summary>
	/// <remarks>Each .snippet file can contain multiple CodeSnippet's. 
	///</remarks>
	public class CodeSnippet
	{



		private string _format;
		private Header _header;

		private Snippet _snippet;

		public CodeSnippet(XElement el)
		{
			if (el == null) {
				_format = "1.0.0";
				_header = new Header();
				_snippet = new Snippet();
			} else {
				_format = el;
				_header = new Header(el.FirstOrDefault);
				_snippet = new Snippet(el.FirstOrDefault);
			}
		}

		public CodeSnippet() : this(null)
		{
		}


		/// <summary>
		/// format attribute of the CodeSnippet
		/// </summary>
		/// <value></value>
		/// <remarks>required. 
		/// Specifies the schema version of the code snippet. 
		/// The Format attribute must be a string in the syntax of x.x.x, where 
		/// each "x" represents a numerical value of the version number. Visual Studio 
		/// will ignore code snippets with Format attributes that it does not understand.
		/// </remarks>
		public string Format {
			get { return _format; }
			set { _format = value; }
		}


		/// <summary>
		/// the Header element of the CodeSnippet
		/// </summary>
		/// <value></value>
		/// <remarks>required. 
		/// Specifies general information about the IntelliSense Code Snippet.
		/// </remarks>
		public Header Header {
			get { return _header; }
		}


		/// <summary>
		/// the Snippet element of the CodeSnippet
		/// </summary>
		/// <value></value>
		/// <remarks>required. 
		/// Specifies the references, imports, declarations, and code for the code snippet.
		/// </remarks>
		public Snippet Snippet {
			get { return _snippet; }
		}



		#region "equality methods"

		public override bool Equals(object obj)
		{

			CodeSnippet cs = obj as CodeSnippet;
			if (cs == null)
				return false;

			return _format == cs._format && _header.Equals(cs._header) && _snippet.Equals(cs._snippet);

		}


		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion

	}
}


