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
//using http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet;



namespace SnippetRepresentation
{
	/// <summary>
	/// This class represents the CodeSnippet\Snippet\References element
	/// </summary>
	/// <remarks>references are optional</remarks>
	public class References
	{


		private List<Reference> _References;
		public References() : this(null)
		{
		}

		public References(XElement el)
		{
			if (el == null) {
				_References = new List<Reference>();
			} else {
				_References = (from item in elnew Reference(item)).ToList;
			}
		}


		public List<Reference> List {
			get { return _References; }
		}



		#region "equality methods"


		public override bool Equals(object obj)
		{

			References @ref = obj as References;
			if (@ref == null)
				return false;

			if ((this.List.Count != @ref.List.Count))
				return false;
			for (Int32 i = 0; i <= this.List.Count - 1; i++) {
				if ((!this.List.Item(i).Equals(@ref.List.Item(i)))) {
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

