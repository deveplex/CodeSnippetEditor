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
using System.Xml.Linq;
using SnippetEditor.SnippetRepresentation;

using http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet;
using http://schemas.microsoft.com/developer/vscontent/2005;


//
/// <summary>
///  class to write snippet(s) to a VSI file.
/// </summary>
/// <remarks>requires reference to Microsoft.VisualStudio.Zip</remarks>
internal sealed class VsiWriter
{


	private static readonly string CrLf = Environment.NewLine;
	private VsiWriter()
	{
		// only shared methods
	}


	public static bool SaveAsVsi(string vsiPath, string snippetPath)
	{

		string tempPath = My.Computer.FileSystem.SpecialDirectories.Temp + "\\VbsnippetEditor";

		string snippetFileName = IO.Path.GetFileName(snippetPath);
		string filename = IO.Path.GetFileNameWithoutExtension(snippetPath);
		string newSnippetPath = IO.Path.Combine(tempPath, snippetFileName);
		string vscontentPath = IO.Path.Combine(tempPath, filename + ".vscontent");


		My.Computer.FileSystem.CreateDirectory(tempPath);

		My.Computer.FileSystem.CopyFile(snippetPath, newSnippetPath, true);
		WriteVSContentFile(vscontentPath, newSnippetPath);

		Microsoft.VisualStudio.Zip.ZipFileCompressor myzip = new Microsoft.VisualStudio.Zip.ZipFileCompressor(vsiPath, tempPath, new string[] {
			filename + ".vscontent",
			filename + ".snippet"
		}, true, false);

		My.Computer.FileSystem.DeleteDirectory(tempPath, FileIO.DeleteDirectoryOption.DeleteAllContents);
		return true;

	}



	private static bool WriteVSContentFile(string path, string snippetPath)
	{
		return WriteVSContentFile(path, new string[] { snippetPath });
	}


	private static bool WriteVSContentFile(string path, string[] snippetPaths)
	{
		string sOut = SnippetsToVSContent(snippetPaths);
		IO.File.WriteAllText(path, sOut);
		return true;
	}


	private static string SnippetsToVSContent(string[] snippetPaths)
	{
		return new XElement("VSContent", from path in snippetPathsXDocument.Load(path)new XElement("Content", new XElement("FileName", IO.Path.GetFileName(path)), new XElement("DisplayName", doc.Value), new XElement("FileContentType", "Code Snippet"), new XElement("ContentVersion", "1.0"), new XElement("Attributes", new XElement("Attribute", new XAttribute("name", "lang"), new XAttribute("value", doc.ToLowerInvariant))))).ToString(SaveOptions.None);

	}




}
