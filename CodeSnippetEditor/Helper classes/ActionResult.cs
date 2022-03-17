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



/// <summary>
/// Provides the result value of an actions such as save or export.
/// </summary>
/// <remarks>Used by SaveAs and ExportToVSI etc.</remarks>
 // ERROR: Not supported in C#: OptionDeclaration
internal enum ActionResult
{
	Success = 0,
	Fail = 1,
	Cancelled = 2
}
