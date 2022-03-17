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
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;



namespace CodeColorisers
{


	/// <summary>
	/// Code coloriser for the best language, VB.NET !!!
	/// </summary>
	/// <remarks>
	/// uses simple regex.
	///  TODO: colors for comments, strings and keywords are hard coded. It might be nice to put that into a config file
	///  TODO: this needs to be updated to include LINQ.
	/// </remarks>
	internal class VBCodeColoriser : IColorTokenProvider
	{




		private string keywords = "(?:\\u0023)Region|(?:\\u0023)End\\s+Region|" + "(?:\\u0023)If|(?:\\u0023)Else|(?:\\u0023)ElseIf|(?:\\u0023)End|(?:\\u0023)Const|" + "Custom\\s+Event|" + "Option\\s+Strict\\s+Off|Option\\s+Explicit\\s+Off|Option\\s+Strict|Option\\s+Explicit|Option\\s+Compare\\s+Binary|Option\\s+Compare\\s+Text|" + "AddHandler|AddressOf|Alias|And|" + "AndAlso|As|Boolean|ByRef|" + "Byte|ByVal|Call|Case|" + "Catch|CBool|CByte|CChar|" + "CDate|CDbl|CDec|Char|" + "CInt|Class|CLng|CObj|" + "Const|Continue|CSByte|CShort|" + "CSng|CStr|CType|CUInt|" + "CULng|CUShort|Date|Decimal|" + "Declare|Default|Delegate|Dim|" + "DirectCast|Do|Double|Each|" + "Else|ElseIf|End|EndIf|" + "Enum|Erase|Error|Event|" + "Exit|False|Finally|For|" + "Friend|From|Function|Get|GetType|" + "Global|GoSub|GoTo|Handles|" + "If|Implements|Imports|In|" + "Inherits|Integer|Interface|Is|" + "IsNot|Let|Lib|Like|" + "Long|Loop|Me|Mod|" + "Module|MustInherit|MustOverride|MyBase|" + "MyClass|Namespace|Narrowing|New|" + "Next|Not|Nothing|NotInheritable|" + "NotOverridable|Object|Of|On|" + "Operator|Option|Optional|Or|" + "OrElse|Overloads|Overridable|Overrides|" + "ParamArray|Partial|Private|Property|" + "Protected|Public|RaiseEvent|ReadOnly|" + "ReDim|REM|RemoveHandler|Resume|" + "Return|SByte|Select|Set|" + "Shadows|Shared|Short|Single|" + "Static|Step|Stop|String|" + "Structure|Sub|SyncLock|Then|" + "Throw|To|True|Try|" + "TryCast|TypeOf|UInteger|ULong|" + "UShort|Using|Variant|Wend|" + "When|Where|While|Widening|With|" + "WithEvents|WriteOnly|Xor";





		public IList<ColorToken> GetColorTokens(string sourceCode, int offset = 0)
		{

			List<ColorToken> tokens = new List<ColorToken>();

			// early exit 
			if (sourceCode == null || sourceCode.Length == 0)
				return tokens;


			Int32 endPos = offset + sourceCode.Length;
			Regex keywordRegEx = new Regex("(?<=\\s|{|}|\\(|\\)|,|\\=|^)(" + keywords + ")\\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
			Regex quoteRegEx = new Regex("(\".*?\")", RegexOptions.CultureInvariant);



			if ((sourceCode.IndexOf("\"") > -1)) {
				string[] subStrings = quoteRegEx.Split(sourceCode);


				foreach (string subString in subStrings) {
					if (subString.StartsWith("\"")) {
						tokens.Add(new ColorToken(offset, subString.Length, Color.DarkRed, Color.Empty));


					} else {
						foreach (Match mtch in keywordRegEx.Matches(subString)) {
							tokens.Add(new ColorToken(offset + mtch.Index, mtch.Length, Color.Blue, Color.Empty));
						}

						Int32 idx = subString.IndexOf('\'');

						if (idx > -1) {
							tokens.Add(new ColorToken(offset + idx, endPos - offset - idx, Color.DarkGreen, Color.Empty));

							return tokens;
							// early exit
						}

					}

					offset += subString.Length;

				}


			} else {
				foreach (Match mtch in keywordRegEx.Matches(sourceCode)) {
					tokens.Add(new ColorToken(offset + mtch.Index, mtch.Length, Color.Blue, Color.Empty));
				}

				Int32 idx = sourceCode.IndexOf('\'');

				if (idx > -1) {
					tokens.Add(new ColorToken(offset + idx, endPos - offset - idx, Color.DarkGreen, Color.Empty));
				}
			}

			return tokens;

		}



	}




}
