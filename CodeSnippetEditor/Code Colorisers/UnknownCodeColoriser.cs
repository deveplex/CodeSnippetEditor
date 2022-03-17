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
	/// Defualt code coloriser for unknown languages
	/// </summary>
	/// <remarks>
	/// known languages can derive from this although it is preferable they implement IColorTokenProvider directly.
	/// </remarks>
	internal class UnknownCodeColoriser : IColorTokenProvider
	{


		public virtual IList<ColorToken> GetColorTokens(string sourceCode, int offset = 0)
		{
			// return an empty list to make it easy for callee enumeration code 
			return new List<ColorToken>();
		}
	}



}
