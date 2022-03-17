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
	/// Interface that all code colorisers need to implement.
	/// Provides the basis of providing code colorign information to the application via the
	/// IColorTokenProvider.GetColorTokens method
	/// </summary>
	/// <remarks></remarks>
	public interface IColorTokenProvider
	{

		IList<ColorToken> GetColorTokens(string sourceCode, Int32 offset = 0);

	}



}
