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
	/// This class represents the CodeSnippet\Snippet element
	/// </summary>
	/// <remarks></remarks>
	public class Snippet
	{

		private References _references;
		private Imports _imports;
		private Declarations _declarations;

		private Code _code;

		public Snippet() : this(null)
		{
		}

		public Snippet(XElement el)
		{
			if (el == null) {
				_references = new References();
				_imports = new Imports();
				_declarations = new Declarations();
				_code = new Code();
			} else {
				_references = new References(el.FirstOrDefault);
				_imports = new Imports(el.FirstOrDefault);
				_declarations = new Declarations(el.FirstOrDefault);
				_code = new Code(el.FirstOrDefault);
			}
		}



		/// <remarks>optional</remarks>
		public References References {
			get { return _references; }
		}



		/// <remarks>optional</remarks>
		public Imports Imports {
			get { return _imports; }
		}



		/// <remarks>optional</remarks>
		public Declarations Declarations {
			get { return _declarations; }
		}



		/// <remarks></remarks>
		public Code Code {
			get { return _code; }
		}




		#region "equality methods"

		public override bool Equals(object obj)
		{
			Snippet snip = obj as Snippet;
			if (snip == null)
				return false;

			return _references.Equals(snip._references) && _imports.Equals(snip._imports) && _declarations.Equals(snip._declarations) && _code.Equals(snip._code);

		}


		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion

	}

}

