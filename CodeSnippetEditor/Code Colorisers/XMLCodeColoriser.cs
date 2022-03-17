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
namespace CodeColorisers
{

	/// <summary>
	/// Default code coloriser for XML
	/// </summary>
	/// <remarks></remarks>
	internal class XmlCodeColoriser : IColorTokenProvider
	{


		public IList<ColorToken> GetColorTokens(string sourceCode, int offset = 0)
		{
			// TODO: provide coloring for XML
			// return an empty list to make it easy for callee enumeration code 
			return new List<ColorToken>();
		}

	}



}



