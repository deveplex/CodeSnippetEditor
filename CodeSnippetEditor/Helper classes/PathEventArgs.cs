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
/// Extends EventArgs to include a Path property.
/// </summary>
/// <remarks>Used to indicate the path selected in the snippet explorer and allow main form to handle those events</remarks>
 // ERROR: Not supported in C#: OptionDeclaration
internal class PathEventArgs : EventArgs
{

	public PathEventArgs(string path)
	{
		this.m_Path = path;
	}


	private string m_Path;
	public string Path {
		get { return m_Path; }
	}

}
