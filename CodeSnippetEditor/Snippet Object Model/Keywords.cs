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
	/// represents the CodeSnippets\CodeSnippet\Header\Keywords element
	/// </summary>
	/// <remarks>Groups individual Keyword elements. The code snippet keywords are used by Visual Studio
	///  and represent a standard way for online content providers to add custom keywords.</remarks>
	public class Keywords
	{



		private List<string> _Keywords;
		public Keywords() : this(null)
		{
		}

		public Keywords(XElement el)
		{
			if (el == null) {
				_Keywords = new List<string>();
			} else {
				_Keywords = (from item in elitem.Value).ToList;
			}
		}


		public List<string> List {
			get { return _Keywords; }
		}


		#region "equality methods"


		public override bool Equals(object obj)
		{

			Keywords keys = obj as Keywords;
			if (keys == null)
				return false;

			if ((this.List.Count != keys.List.Count))
				return false;
			for (Int32 i = 0; i <= this.List.Count - 1; i++) {
				if (!(this.List.Item(i) == keys.List.Item(i))) {
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

