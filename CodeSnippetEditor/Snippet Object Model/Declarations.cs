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
	/// This class represents the CodeSnippet\Snippet\Declarations element
	/// </summary>
	/// <remarks>contains Object and Literal elements. Rather than have two lists,
	///  an abstracted type in this object model, "Replacement", is used to represent both Object and Literal elements. 
	/// </remarks>
	public class Declarations
	{




		private List<Replacement> _Replacements;
		public Declarations() : this(null)
		{
		}


		public Declarations(XElement el)
		{
			if (el == null) {
				_Replacements = new List<Replacement>();
			} else {
				_Replacements = (from item in el.Elementsnew Replacement(item)).ToList;
			}

		}




		public List<Replacement> Replacements {
			get { return _Replacements; }
		}


		#region "equality methods"

		public override bool Equals(object obj)
		{

			Declarations decs = obj as Declarations;
			if (decs == null)
				return false;

			if ((this._Replacements.Count != decs._Replacements.Count))
				return false;
			for (Int32 i = 0; i <= this._Replacements.Count - 1; i++) {
				if ((!this._Replacements.Item(i).Equals(decs._Replacements.Item(i)))) {
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

