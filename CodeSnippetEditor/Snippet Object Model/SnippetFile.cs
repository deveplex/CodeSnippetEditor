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
using SnippetEditor.SnippetRepresentation;

using http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet;


/// <summary>
/// Stotres file information, the CodeSnippet contents and provides support methods such as FromFile and ToFile
/// </summary>
/// <remarks></remarks>
internal class SnippetFile
{

	private CodeSnippet _codeSnippet;

	private string _filename = "";

	/// <summary>
	/// the filename (with complete path) of the opened snippet
	/// </summary>
	public string Filename {
		get { return _filename; }
		set { _filename = value; }
	}


	/// <summary>
	/// the CodeSnippet contained in this SnippetFile
	/// </summary>
	public CodeSnippet CodeSnippet {
		get { return _codeSnippet; }
		set { _codeSnippet = value; }
	}



	/// <summary>
	/// Saves a snippet to a file
	/// </summary>
	/// <param name="filename">The file to save the snippet to</param>
	/// <returns>True is success</returns>
	public bool ToFile(string filename)
	{



		XCData xcdCode = new XCData(_codeSnippet.Snippet.Code.Data);

		XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null), "", new XElement("CodeSnippets", new XElement("CodeSnippet", new XAttribute("Format", _codeSnippet.Format), new XElement("Header", new XElement("Title", _codeSnippet.Header.Title), new XElement("Author", _codeSnippet.Header.Author), new XElement("Description", _codeSnippet.Header.Description), new XElement("HelpUrl", _codeSnippet.Header.HelpUrl), new XElement("SnippetTypes", from item in _codeSnippet.Header.SnippetTypes.Listnew XElement("SnippetType", item)), new XElement("Keywords", from item in _codeSnippet.Header.Keywords.Listnew XElement("Keyword", item)), new XElement("Shortcut", _codeSnippet.Header.Shortcut)), new XElement("Snippet", new XElement("References", from item in _codeSnippet.Snippet.References.Listnew XElement("Reference", new XElement("Assembly", item.Assembly), new XElement("Url", item.Url))), new XElement("Imports", from item in _codeSnippet.Snippet.Imports.Listnew XElement("Import", new XElement("Namespace", item.Namespace))), new XElement("Declarations", from item in _codeSnippet.Snippet.Declarations.Replacementswhere item.ReplacementKind == ReplacementKind.Literalnew XElement("Literal", new XAttribute("Editable", item.Editable), new XElement("ID", item.Id), new XElement("Type", item.Type), new XElement("ToolTip", item.Tooltip), new XElement("Default", item.Default), new XElement("Function", item.Function)), from item in _codeSnippet.Snippet.Declarations.Replacementswhere item.ReplacementKind == ReplacementKind.Objectnew XElement("Object", new XAttribute("Editable", item.Editable), new XElement("ID", item.Id), new XElement("Type", item.Type), new XElement("ToolTip", item.Tooltip), new XElement("Default", item.Default), new XElement("Function", item.Function))), new XElement("Code", new XAttribute("Language", _codeSnippet.Snippet.Code.Language), new XAttribute("Kind", _codeSnippet.Snippet.Code.Kind), new XAttribute("Delimiter", _codeSnippet.Snippet.Code.Delimiter), xcdCode)))));


		doc.Save(filename);
		_filename = filename;

		return true;
	}


	/// <summary>
	/// loads a snippet from a file
	/// </summary>
	/// <param name="filename">file to load the snippet from</param>
	public void LoadFile(string filename)
	{
		CodeSnippet cs = FileToCodeSnippet(filename);
		if (cs != null) {
			_codeSnippet = cs;
			_filename = filename;
		}
	}


	/// <summary>
	/// load a file and returns a codesnippet
	/// </summary>
	private CodeSnippet FileToCodeSnippet(string filename)
	{
		CodeSnippet cs = null;
		try {
			var doc = XDocument.Load(filename);
			var el = doc.FirstOrDefault;
			if (el == null)
				return null;
			cs = new CodeSnippet(el);
		} catch (Exception ex) {
			//TODO: should remove MsgBox on errors or have a UI switch.
			Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, My.Resources.Error_Loading_Xml_File);
		}
		return cs;
	}


	/// <summary>
	/// determines if the snippet has changed since the last save
	/// </summary>
	public bool SnippetHasChanged()
	{

		if ((_codeSnippet == null)) {
			return false;
		}

		CodeSnippet cs = default(CodeSnippet);

		if (string.IsNullOrEmpty(_filename)) {
			cs = new CodeSnippet();
			return !cs.Equals(_codeSnippet);

		//The snippet has been saved before
		} else {
			cs = FileToCodeSnippet(_filename);
			if (cs != null) {
				return !cs.Equals(_codeSnippet);
			} else {
				return true;
			}
		}
	}


	/// <summary>
	/// creates a new CodeSnippet
	/// </summary>
	public void CreateNewSnippet()
	{
		_codeSnippet = new CodeSnippet();
		_filename = "";
	}

}
