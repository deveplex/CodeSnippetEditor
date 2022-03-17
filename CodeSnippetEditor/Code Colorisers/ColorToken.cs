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
using System.Drawing;




namespace CodeColorisers
{

	/// <summary>
	/// Structure that contains color formatting information for use by code colorisers
	/// Required by the IColorTokenProvider interface's GetColortokens method. 
	/// </summary>
	/// <remarks></remarks>

	public struct ColorToken
	{

		public Int32 Start;
		public Int32 Length;
		public Color ForeColor;

		public Color BackColor;
		public ColorToken(Int32 start, Int32 length, Color foreColor, Color backColor)
		{
			this.Start = start;
			this.Length = length;
			this.ForeColor = foreColor;
			this.BackColor = backColor;
		}

		public override bool Equals(object obj)
		{
			return this.Equals((ColorToken)obj);
		}

		public bool Equals(ColorToken token)
		{
			return (this.Start == token.Start) && (this.Length == token.Length) && (this.ForeColor == token.ForeColor) && (this.BackColor == token.BackColor);
		}

		public static bool operator !=(ColorToken left, ColorToken right)
		{
			return !left.Equals(right);
		}

		public static bool operator ==(ColorToken left, ColorToken right)
		{
			return left.Equals(right);
		}

		public override int GetHashCode()
		{
			return this.Start ^ this.Length ^ this.ForeColor.GetHashCode() ^ this.BackColor.GetHashCode();
		}

	}


}



