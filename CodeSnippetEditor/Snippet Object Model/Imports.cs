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
	/// represents the CodeSnippet\Snippet\Imports element
	/// </summary>
	/// <remarks></remarks>
	public class Imports
	{


		private List<Import> _Imports;

		public Imports() : this(null)
		{
		}

		public Imports(XElement el)
		{
			if (el == null) {
				_Imports = new List<Import>();
			} else {
				_Imports = (from item in elnew Import(item)).ToList;
			}
		}



		public List<Import> List {
			get { return _Imports; }
		}


		#region "equality methods"


		public override bool Equals(object obj)
		{

			Imports imprt = obj as Imports;
			if (imprt == null)
				return false;

			if ((this.List.Count != imprt.List.Count))
				return false;
			for (Int32 i = 0; i <= this.List.Count - 1; i++) {
				if ((!this.List.Item(i).Equals(imprt.List.Item(i)))) {
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

