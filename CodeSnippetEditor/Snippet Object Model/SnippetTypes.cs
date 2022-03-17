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
	/// This class represents the CodeSnippets\CodeSnippet\Header\SnippetTypes element
	/// </summary>
	/// <remarks> 
	///  "Expansion", "SurroundsWith" or "Refactoring"
	/// </remarks>
	public class SnippetTypes
	{


		private List<string> SnippetTypes;
		public SnippetTypes() : this(null)
		{
		}

		public SnippetTypes(XElement el)
		{
			if (el == null) {
				SnippetTypes = new List<string>();
			} else {
				SnippetTypes = (from item in elitem.Value).ToList;
			}
		}




		public List<string> List {
			get { return SnippetTypes; }
		}




		#region "equality methods"


		public override bool Equals(object obj)
		{

			SnippetTypes stypes = obj as SnippetTypes;
			if (stypes == null)
				return false;

			if ((this.List.Count != stypes.List.Count))
				return false;
			for (Int32 i = 0; i <= this.List.Count - 1; i++) {
				if (!(this.List.Item(i) == stypes.List.Item(i))) {
					return false;
				}
			}

			return true;

		}


		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion

	}


}

