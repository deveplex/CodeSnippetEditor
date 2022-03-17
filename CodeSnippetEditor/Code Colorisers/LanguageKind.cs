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
	/// public enum for known languages.
	/// Used primarily with the code colorisers.
	/// </summary>
	/// <remarks>
	/// Potentially subject to change in the future !  
	/// But does provide a more efficient way of filtering than using strings.
	/// </remarks>
	public enum CodeLanguage
	{
		VB,
		CSharp,
		JSharp,
		XML,
		Unknown
	}


}

