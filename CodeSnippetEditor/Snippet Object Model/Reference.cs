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
	/// represents the CodeSnippet\References\Reference element
	/// </summary>
	/// <remarks>Although the Assembly property is required, 
	///  don't enforce this as Reference items with an empty Assembly element are stripped out when saved.
	/// </remarks>
	public class Reference
	{
		public string Assembly { get; set; }
		public string Url {get;set;}
	}

}

