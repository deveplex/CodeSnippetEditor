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
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using VB = Microsoft.VisualBasic;
//using http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet;



namespace SnippetRepresentation
{



	/// <summary>
	/// represents the CodeSnippets\CodeSnippet\Snippet\Declarations\Literal element 
	///            and CodeSnippets\CodeSnippet\Snippet\Declarations\Objectl element
	/// </summary>
	/// <remarks></remarks>
	public class Replacement //: IDataErrorInfo
	{



		private string _id;
		private string _type;
		private string _tooltip;
		private string _default;
		private ReplacementKind _declarationkind;
		private bool _editable;

		private string _Function;

		public const string LiteralTag = "Literal";

		public const string ObjectTag = "Object";


		/// <summary>
		/// represents the id element of the Literal
		/// </summary>
		/// <remarks>required</remarks>
		public string Id { get; set; }


		/// <summary>
		/// represents the type element of the Literal
		/// </summary>
		/// <remarks>required if replacement kind is Object</remarks>
		public string Type { get; set; }


        /// <summary>
        /// represents the tooltip element of the literal
        /// </summary>
        /// <remarks>optional</remarks>
        public string Tooltip { get; set; }


        /// <summary>
        /// represents the default value of the literal
        /// </summary>
        /// <remarks>optional</remarks>
        public string Default { get; set; }



        /// <summary>
        /// Specifies if the replacment is a literal or object
        /// </summary>
        /// <remarks>used so as we can represent literals and objects using the same class
        /// </remarks>
        public ReplacementKind ReplacementKind { get; set; }




        /// <summary>
        /// Specifies whether or not you can edit the literal after the code snippet is inserted. The default value of this attribute is true.
        /// </summary>
        /// <remarks>optional</remarks>
        public bool Editable { get; set; }


        /// <summary>
        /// Specifies a function to execute when the literal or object receives focus in Visual Studio.
        /// </summary>
        /// <remarks>optional</remarks>
        public string Function { get; set; }
    }

}

