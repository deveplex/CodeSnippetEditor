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
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using VB = Microsoft.VisualBasic;

/// <summary>
/// 
/// </summary>
/// <remarks></remarks>
[System.ComponentModel.DesignerCategory("")]
internal class CodeEditor : RichTextBox
{
/*

    #region "public Properties"


    private int _TabSize = 4;

    [DefaultValue(4)]
    public int TabSize
    {
        get { return _TabSize; }
        set
        {
            _TabSize = value;
            this.SetDefaultTabStop(value);
        }
    }



    public override string Text
    {
        // If Me.IsHandleCreated Then
        //Return Me.GetText
        // Else
        // End If
        get { return base.Text; }
        set
        {
            base.Text = value;
            ClearUndo();
            if (this.Created)
                this.ColorAll();
        }
    }


    public string TextWithoutCR
    {
        get { return base.Text; }
    }




    private CodeColorisers.CodeLanguage _CodeLanguage;
    [DefaultValue(typeof(CodeColorisers.CodeLanguage), "CSharp")]
    public CodeColorisers.CodeLanguage CodeLanguage
    {
        get { return _CodeLanguage; }
        set
        {
            if (value != _CodeLanguage)
            {
                _CodeLanguage = value;
                this.ColorAll();
            }
        }
    }


    //Public Property SubString(ByVal start As int, ByVal [end] As int) As String
    //   Get
    //      Return Me.ITextDocument.Range(start, [end]).Text
    //   End Get
    //   Set(ByVal value As String)
    //      Me.ITextDocument.Range(start, [end]).Text = value
    //   End Set
    //End Property


    public ITextRange GetRange(int start, int end)
    {
        return this.ITextDocument.Range(start, end);
    }

    #endregion


    #region "Highlighting methods"

    public void HighightRange(int start, int end, Color color)
    {
        ITextRange rng = this.ITextDocument.Range(start, end);
        rng.Font.BackColor = ColorToRGB(color);
    }


    public void ClearAllHighLighting()
    {
        ITextRange rng = this.ITextDocument.Range(0, this.Text.Length);
        rng.Font.BackColor = ColorToRGB(this.BackColor);
    }

    #endregion


    #region "Replace overloads"


    public int ReplaceAll(string valueToFind, string newValue)
    {
        return ReplaceAndHighlightAll(valueToFind, newValue, this.BackColor);
    }


    public int ReplaceAndHighlightAll(string valueToFind, string newValue)
    {
        return ReplaceAndHighlightAll(valueToFind, newValue, Color.Yellow);
    }

    public int ReplaceAndHighlightAll(string valueToFind, string newValue, Color bgcolor)
    {
        if (valueToFind == null)
            return 0;
        if (newValue == null)
            newValue = "";

        int cnt = default(int);
        int clr = ColorToRGB(bgcolor);
        ITextRange rng = this.ITextDocument.Range(0, 1);
        int idx = 0;
        int length = valueToFind.Length;
        int newLength = newValue.Length;
        do
        {
            idx = base.Text.IndexOf(valueToFind, idx);

            if (idx >= 0)
            {
                rng.SetRange(idx, idx + length);
                rng.Text = newValue;
                rng.Font.BackColor = clr;
                idx += newLength;
            }
            else
            {
                break; // TODO: might not be correct. Was : Exit Do
            }
            if (idx > base.Text.Length)
                break; // TODO: might not be correct. Was : Exit Do
        } while (true);
        return cnt;
    }


    public int ReplaceWords(string oldWord, string newWord)
    {

        if (oldWord == null)
            return 0;
        if (newWord == null)
            newWord = "";

        int idx = 0;
        int count = 0;
        while (idx >= 0)
        {
            idx = this.Find(oldWord, idx, RichTextBoxFinds.MatchCase | RichTextBoxFinds.NoHighlight | RichTextBoxFinds.WholeWord);
            if (idx < 0)
                break; // TODO: might not be correct. Was : Exit Do
            this.GetRange(idx, idx + oldWord.Length).Text = newWord;
            idx += oldWord.Length + 1;
            count += 1;
        }

        return count;

    }


    public bool IsWord(string value, int position)
    {
        if (value == null || position < 1)
            return false;
        int rtn = this.Find(value, position - 1, position + value.Length, RichTextBoxFinds.MatchCase | RichTextBoxFinds.NoHighlight | RichTextBoxFinds.WholeWord);
        return rtn >= 0;
    }


    #endregion


    #region "coloring"

    public event EventHandler ColoringCompleted;

    protected void OnColoringCompleted(EventArgs ev)
    {
        if (ColoringCompleted != null)
        {
            ColoringCompleted(this, ev);
        }
    }

    public void ColorAll()
    {
        if (!this.Created)
            return;

        bool isReadOnly = false;
        if (this.ReadOnly)
        {
            isReadOnly = true;
            this.ReadOnly = false;
        }


        this.ITextDocument.Freeze();

        int idx = 0;
        foreach (string line in this.Lines)
        {
            ColorLine(idx, line);
            idx += line.Length + 1;
        }
        this.ITextDocument.Unfreeze();


        if (isReadOnly)
            this.ReadOnly = true;
        OnColoringCompleted(EventArgs.Empty);
    }





    private void ColorCurrentLine(int offset = 0)
    {
        System.Runtime.InteropServices.HandleRef href = new System.Runtime.InteropServices.HandleRef(this, this.Handle);

        int lineNumber = default(int);
        int startIndex = default(int);

        // get the current line index
        lineNumber = NativeMethods.GetCurrentLineNumber(href) + offset;
        startIndex = NativeMethods.GetLineCharIndex(href, lineNumber);
        string txt = NativeMethods.GetLine(href, lineNumber);

        if (txt.Length > 0)
        {
            ColorLine(startIndex, NativeMethods.GetCurrentLine(href));
        }

        OnColoringCompleted(EventArgs.Empty);

    }




    public void ColorLine(int offset, string sourceLine)
    {
        int endPos = offset + sourceLine.Length;
        ITextRange rg = this.ITextDocument.Range(offset, endPos);

        if (rg.Font.CanChange)
        {
            rg.Font.ForeColor = 0x0;
            rg.Font.BackColor = ColorToRGB(this.BackColor);
        }

        foreach (CodeColorisers.ColorToken token in CodeColorisers.Coloriser.GetColoriser(this.CodeLanguage).GetColorTokens(sourceLine, offset))
        {
            rg.SetRange(token.Start, token.Start + token.Length);
            if (!token.ForeColor.IsEmpty && rg.Font.CanChange)
                rg.Font.ForeColor = ColorToRGB(token.ForeColor);
            if (!token.BackColor.IsEmpty && rg.Font.CanChange)
                rg.Font.BackColor = ColorToRGB(token.BackColor);
        }

    }



    public static int ColorToRGB(Color color)
    {
        return (Convert.ToInt32(color.B) << 16) | (Convert.ToInt32(color.G) << 8) | (color.R);
    }


    #endregion


    #region "Private Properties:: ITextDocument"


    private ITextDocument m_Itextdocument;

    private ITextDocument ITextDocument
    {

        get
        {
            if (m_Itextdocument == null)
            {
                m_Itextdocument = NativeMethods.GetOLEInterface(this);
            }
            return m_Itextdocument;
        }

        set
        {
            if (value == null)
            {
                if ((m_Itextdocument != null))
                {
                    Marshal.ReleaseComObject(m_Itextdocument);
                }
            }
            m_Itextdocument = value;
        }
    }



    #endregion


    #region "overrides"


    protected override void Dispose(bool disposing)
    {
        this.ITextDocument = null;
        base.Dispose(disposing);
    }


    protected override void CreateHandle()
    {
        this.ITextDocument = null;
        base.CreateHandle();
    }




    protected override void DestroyHandle()
    {
        this.ITextDocument = null;
        base.DestroyHandle();
    }



    protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.Handled)
            return;

        if (e.Modifiers == Keys.Control)
        {
            switch (e.KeyCode)
            {
                case Keys.X:
                    ColorAll();
                    break;
                case Keys.Enter:
                case Keys.LineFeed:
                    ColorCurrentLine(-1);
                    ColorCurrentLine();
                    break;
            }
            return;
        }


        switch (e.KeyCode)
        {

            case Keys.Delete:
            case Keys.Back:
            case Keys.Tab:
            case Keys.Space:
                ColorCurrentLine();

                break;
            case Keys.Return:
                ColorCurrentLine(-1);
                ColorCurrentLine();

                break;
            case Keys.D0: // TODO: to Keys.Divide
            case Keys.OemSemicolon: // TODO: to Keys.OemBackslash
                ColorCurrentLine();

                break;
        }

    }


    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
    {
        switch (keyData)
        {
            case (Keys.V | Keys.Control):
                //paste
                // ERROR: Not supported in C#: ClassReferenceExpression
                this.Paste();
                return true;
            case (Keys.Z | Keys.Control):
                // undo
                // ERROR: Not supported in C#: ClassReferenceExpression
                this.Undo();
                return true;
            case (Keys.Y | Keys.Control):
                // redo
                // ERROR: Not supported in C#: ClassReferenceExpression
                this.Redo();
                return true;
            case (Keys.L | Keys.Control):
            case (Keys.R | Keys.Control):
            case (Keys.E | Keys.Control):
                //alignment
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }


    public new void Paste()
    {
        base.Paste(DataFormats.GetFormat(DataFormats.Text));
        this.ColorAll();
    }

    #endregion


    #region "undo and redo tracking"
    // unfortuantely we need to track this manually as the formatting interferes with the RTF undo/redo tracking
    // note: we cannot use the TOM.ITextDocument.BeginEditcollection and EndEditCollection as these are not supported with the .NET RTF control


    private Stack<TextChangeInfo> m_Undo = new Stack<TextChangeInfo>();
    private Stack<TextChangeInfo> m_Redo = new Stack<TextChangeInfo>();
    //= ""
    private string m_LastText;
    //= False
    private bool m_Undoing;
    private NativeMethods.CharRange m_CurrentRange;

    private NativeMethods.CharRange m_PreviousRange;
    private struct TextChangeInfo
    {
        public string Text;

        public NativeMethods.CharRange Range;
        public TextChangeInfo(string newText, NativeMethods.CharRange newRange)
        {
            this.Range = newRange;
            this.Text = newText;
        }

    }


    public new void Undo()
    {
        if (m_Undo.Count == 0)
            return;
        m_Undoing = true;
        TextChangeInfo oldInfo = new TextChangeInfo(this.Text, this.m_CurrentRange);
        TextChangeInfo changeinfo = m_Undo.Pop();
        var _with1 = changeinfo;
        base.Text = _with1.Text;
        m_LastText = _with1.Text;
        SetSelection(_with1.Range);
        if (this.Created)
            this.ColorAll();
        m_Redo.Push(oldInfo);
        m_Undoing = false;
    }


    public new void Redo()
    {
        if (m_Redo.Count == 0)
            return;
        m_Undoing = true;
        TextChangeInfo changeinfo = m_Redo.Pop();
        var _with2 = changeinfo;
        base.Text = _with2.Text;
        if (this.Created)
            this.ColorAll();
        SetSelection(_with2.Range);
        m_Undo.Push(changeinfo);
        m_Undoing = false;
    }


    public new void ClearUndo()
    {
        this.m_Undo.Clear();
        this.m_Redo.Clear();
        this.m_CurrentRange = null;
        this.m_PreviousRange = null;
        m_LastText = this.Text;
    }


    protected override void OnTextChanged(System.EventArgs e)
    {
        string newText = this.Text;
        if (!m_Undoing)
        {
            if (!string.Equals(newText, m_LastText, StringComparison.Ordinal))
            {
                m_Undo.Push(new TextChangeInfo(m_LastText, this.m_PreviousRange));
                m_LastText = newText;
            }
        }
        base.OnTextChanged(e);
    }


    protected override void OnSelectionChanged(System.EventArgs e)
    {
        base.OnSelectionChanged(e);
        NativeMethods.CharRange range = GetSelection();
        this.m_PreviousRange = this.m_CurrentRange;
        this.m_CurrentRange = range;
    }

    #endregion


    #region "win API"


    private void SetDefaultTabStop(int tabSize)
    {
        NativeMethods.SetDefaultTabStop(tabSize, this);
    }

    private string GetText()
    {
        return NativeMethods.GetText(this);
    }

    private NativeMethods.CharRange GetSelection()
    {
        return NativeMethods.GetSelection(this);
    }

    private void SetSelection(NativeMethods.CharRange range)
    {
        NativeMethods.SetSelection(range, this);
    }

    private class NativeMethods
    {

        private NativeMethods()
        {
            // class is Shared
        }

        static internal void SetDefaultTabStop(int tabSize, CodeEditor editor)
        {
            SendMessageW(new HandleRef(editor, editor.Handle), 0xcb, new IntPtr(1), ref tabSize * 4);
        }

        static internal string GetText(CodeEditor editor)
        {
            HandleRef href = new HandleRef(editor, editor.Handle);
            int length = SendMessageW(href, WM_GETTEXTLENGTH, IntPtr.Zero, ref 0).ToInt32 + 2;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(length + 2);
            SendMessageW(href, WM_GETTEXT, new IntPtr(length), ref sb);
            return sb.ToString();
        }

        static internal NativeMethods.CharRange GetSelection(CodeEditor editor)
        {
            CharRange range = default(CharRange);
            SendMessageW(new HandleRef(editor, editor.Handle), EM_EXGETSEL, IntPtr.Zero, ref range);
            return range;
        }

        static internal void SetSelection(NativeMethods.CharRange range, CodeEditor editor)
        {
            SendMessageW(new HandleRef(editor, editor.Handle), EM_EXSETSEL, IntPtr.Zero, ref range);
        }

        static internal ITextDocument GetOLEInterface(CodeEditor editor)
        {
            ITextDocument iDoc = null;
            SendMessageW(new HandleRef(editor, editor.Handle), EM_GETOLEINTERFACE, IntPtr.Zero, ref iDoc);
            return iDoc;
        }


        //Friend Shared Function GetCurrentLine(ByVal editor As CodeEditor) As String
        //   Return GetCurrentLine(New HandleRef(editor, editor.Handle))
        //End Function

        static internal string GetCurrentLine(HandleRef href)
        {
            return GetLine(href, GetCurrentLineNumber(href));
        }

        //Friend Shared Function GetLine(ByVal editor As CodeEditor, ByVal lineNumber As int) As String
        //   Return GetLine(New HandleRef(editor, editor.Handle), lineNumber)
        //End Function

        static internal string GetLine(HandleRef href, int lineNumber)
        {
            int lineLength = GetLineLength(href, lineNumber);

            if (lineLength <= 0)
                return "";

            StringBuilder sb = new StringBuilder(lineLength + 2);
            sb.Append(VB.ChrW(lineLength));
            int rtn = SendMessageW(href, EM_GETLINE, new IntPtr(lineNumber), ref sb).ToInt32;

            return sb.ToString(0, rtn);

        }



        //Friend Shared Function GetLineLength(ByVal editor As CodeEditor, ByVal lineNumber As int) As int
        //   Return GetLineLength(New HandleRef(editor, editor.Handle), lineNumber)
        //End Function

        private static int GetLineLength(HandleRef href, int lineNumber)
        {
            return SendMessageW(href, EM_LINELENGTH, new IntPtr(GetLineCharIndex(href, lineNumber)), ref 0).ToInt32;
        }


        //Friend Shared Function GetCurrentLineNumber(ByVal editor As CodeEditor) As int
        //   Return GetCurrentLineNumber(New HandleRef(editor, editor.Handle))
        //End Function

        static internal int GetCurrentLineNumber(HandleRef href)
        {
            return SendMessageW(href, EM_LINEFROMCHAR, new IntPtr(-1), ref 0).ToInt32;
        }


        //Friend Shared Function GetLineCharIndex(ByVal editor As CodeEditor, ByVal lineNumber As int) As int
        //   Return GetLineCharIndex(New HandleRef(editor, editor.Handle), lineNumber)
        //End Function

        static internal int GetLineCharIndex(HandleRef href, int lineNumber)
        {
            return SendMessageW(href, EM_LINEINDEX, new IntPtr(lineNumber), ref 0).ToInt32;
        }
        [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]


        //Friend Shared Function SetAdvanacedTypography(ByVal href As HandleRef) As int
        //   Return SendMessageW(href, EM_SETTYPOGRAPHYOPTIONS, New IntPtr(TO_ADVANCEDTYPOGRAPHY), TO_ADVANCEDTYPOGRAPHY).ToInt32
        //End Function


        private static extern IntPtr SendMessageW(HandleRef hWnd, int msg, IntPtr wParam, ref ITextDocument lparam);
        [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SendMessageW(HandleRef hWnd, int msg, IntPtr wParam, StringBuilder lparam);
        [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SendMessageW(HandleRef hWnd, int msg, IntPtr wParam, ref int lparam);
        [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SendMessageW(HandleRef hWnd, int msg, IntPtr wParam, ref CharRange lparam);


        private const int WM_USER = 0x400;
        private const int EM_EXGETSEL = (WM_USER + 52);
        private const int EM_EXSETSEL = (WM_USER + 55);
        private const int EM_GETOLEINTERFACE = (WM_USER + 60);
        private const int EM_GETLINE = 0xc4;
        private const int EM_LINEFROMCHAR = 0xc9;
        private const int EM_LINELENGTH = 0xc1;
        private const int EM_LINEINDEX = 0xbb;
        private const int EM_SETTABSTOPS = 0xcb;
        private const int WM_GETTEXT = 0xd;
        private const int WM_GETTEXTLENGTH = 0xe;
        private const int TO_ADVANCEDTYPOGRAPHY = 1;
        private const int EM_SETTYPOGRAPHYOPTIONS = (WM_USER + 202);



        internal struct CharRange
        {
            public int Min;
            public int Max;
        }


    }


    #endregion

    */
}

/*
#region "COM Interfaces for RichEdit control's TextObjectModel "

[ComImport(), TypeLibType(192), Guid("8CC497C0-A1DF-11CE-8098-00AA0047BE5D"), DefaultMember("Name")]
public interface ITextDocument
{
    // Methods
    //<DispId(0)> _
    //ReadOnly Property Name() As <MarshalAs(UnmanagedType.BStr)> String
    //<DispId(1)> _
    //ReadOnly Property Selection() As <MarshalAs(UnmanagedType.Interface)> ITextSelection
    //<DispId(2)> _
    //ReadOnly Property StoryCount() As Integer
    //<DispId(3)> _
    //ReadOnly Property StoryRanges() As <MarshalAs(UnmanagedType.Interface)> Object
    [DispId(4)]
    int Saved { get; set; }
    [DispId(5)]

    float DefaultTabStop { get; set; }
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(6)]
    void New();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(7)]
    void Open([In(), MarshalAs(UnmanagedType.Struct)]
ref object pVar, [In()]
int Flags, [In()]
int CodePage);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(8)]
    void Save([In(), MarshalAs(UnmanagedType.Struct)]
ref object pVar, [In()]
int Flags, [In()]
int CodePage);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(9)]
    int Freeze();

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(10)]
    int Unfreeze();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
    void BeginEditCollection();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(12)]
    void EndEditCollection();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(13)]
    int Undo([In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(14)]
    int Redo([In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(15)]
    [return: MarshalAs(UnmanagedType.Interface)]
    ITextRange Range([In()]
int cp1, [In()]
int cp2);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(16)]
    [return: MarshalAs(UnmanagedType.Interface)]
    ITextRange RangeFromPoint([In()]
int x, [In()]
int y);
    // Properties


}

[ComImport(), TypeLibType(192), Guid("8CC497C2-A1DF-11CE-8098-00AA0047BE5D"), DefaultMember("Text")]
public interface ITextRange
{

    [DispId(0)]
    String Text { get; set; }


    [DispId(513)]
    int Char { get; set; }
    [DispId(514)]
    ITextRange Duplicate { get; }
    [DispId(515)]
    ITextRange FormattedText { get; set; }
    [DispId(516)]
    int Start { get; set; }
    [DispId(517)]
    int End { get; set; }
    [DispId(518)]
    ITextFont Font { get; set; }
    [DispId(519)]
    ITextPara Para { get; set; }
    [DispId(520)]
    int StoryLength { get; }
    [DispId(521)]

    int StoryType { get; }

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(528)]
    void Collapse([In()]
int bStart);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(529)]
    int Expand([In()]
int Unit);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(530)]
    int GetIndex([In()]
int Unit);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(531)]
    void SetIndex([In()]
int Unit, [In()]
int Index, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(532)]
    void SetRange([In()]
int cpActive, [In()]
int cpOther);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(533)]
    int InRange([In(), MarshalAs(UnmanagedType.Interface)]
ITextRange pRange);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(534)]
    int InStory([In(), MarshalAs(UnmanagedType.Interface)]
ITextRange pRange);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(535)]
    int IsEqual([In(), MarshalAs(UnmanagedType.Interface)]
ITextRange pRange);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(536)]
    void Select();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(537)]
    int StartOf([In()]
int Unit, [In()]
int Extend);


    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(544)]
    int EndOf([In()]
int Unit, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(545)]
    int Move([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(546)]
    int MoveStart([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(547)]
    int MoveEnd([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(548)]
    int MoveWhile([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(549)]
    int MoveStartWhile([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(550)]
    int MoveEndWhile([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(551)]
    int MoveUntil([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(552)]
    int MoveStartUntil([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(553)]
    int MoveEndUntil([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);


    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(560)]
    int FindText([In(), MarshalAs(UnmanagedType.BStr)]
string bstr, [In()]
int cch, [In()]
int Flags);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(561)]
    int FindTextStart([In(), MarshalAs(UnmanagedType.BStr)]
string bstr, [In()]
int cch, [In()]
int Flags);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(562)]
    int FindTextEnd([In(), MarshalAs(UnmanagedType.BStr)]
string bstr, [In()]
int cch, [In()]
int Flags);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(563)]
    int Delete([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(564)]
    void Cut([Out(), MarshalAs(UnmanagedType.Struct)]ref object pVar);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(565)]
    void Copy([Out(), MarshalAs(UnmanagedType.Struct)]
ref object pVar);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(566)]
    void Paste([In(), MarshalAs(UnmanagedType.Struct)]
ref object pVar, [In()]
int Format);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(567)]
    int CanPaste([In(), MarshalAs(UnmanagedType.Struct)]
ref object pVar, [In()]
int Format);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(568)]
    int CanEdit();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(569)]
    void ChangeCase([In()]

int Type);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(576)]
    void GetPoint([In()]
int Type, [Out()]
ref int px, [Out()]
ref int py);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(577)]
    void SetPoint([In()]
int x, [In()]
int y, [In()]
int Type, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(578)]
    void ScrollIntoView([In()]
int Value);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(579)]
    [return: MarshalAs(UnmanagedType.IUnknown)]
    object GetEmbeddedObject();

}

[ComImport(), Guid("8CC497C1-A1DF-11CE-8098-00AA0047BE5D"), TypeLibType(192), DefaultMember("Text")]
public interface ITextSelection
{
    [DispId(0)]
    string Text { get; set; }

    [DispId(257)]
    int Flags { get; set; }
    [DispId(258)]
    int Type { get; }
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(259)]
    int MoveLeft([In()]
int Unit, [In()]
int Count, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(260)]
    int MoveRight([In()]
int Unit, [In()]
int Count, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(261)]
    int MoveUp([In()]
int Unit, [In()]
int Count, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(262)]
    int MoveDown([In()]
int Unit, [In()]
int Count, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(263)]
    int HomeKey([In()]
int Unit, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(264)]
    int EndKey([In()]
int Unit, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(265)]
    void TypeText([In(), MarshalAs(UnmanagedType.BStr)]

string bstr);

    [DispId(513)]
    int Char { get; set; }
    //<DispId(514)> _
    //ReadOnly Property Duplicate() As <MarshalAs(UnmanagedType.Interface)> ITextRange
    //<DispId(515)> _
    //Property FormattedText() As <MarshalAs(UnmanagedType.Interface)> ITextRange
    [DispId(516)]
    int Start { get; set; }
    [DispId(517)]
    int End { get; set; }
    //<DispId(518)> _
    //Property Font() As <MarshalAs(UnmanagedType.Interface)> ITextFont
    //<DispId(519)> _
    //Property Para() As <MarshalAs(UnmanagedType.Interface)> ITextPara
    [DispId(520)]
    int StoryLength { get; }
    [DispId(521)]

    int StoryType { get; }


    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(528)]
    void Collapse([In()]
int bStart);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(529)]
    int Expand([In()]
int Unit);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(530)]
    int GetIndex([In()]
int Unit);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(531)]
    void SetIndex([In()]
int Unit, [In()]
int Index, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(532)]
    void SetRange([In()]
int cpActive, [In()]
int cpOther);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(533)]
    int InRange([In(), MarshalAs(UnmanagedType.Interface)]
ITextRange pRange);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(534)]
    int InStory([In(), MarshalAs(UnmanagedType.Interface)]
ITextRange pRange);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(535)]
    int IsEqual([In(), MarshalAs(UnmanagedType.Interface)]
ITextRange pRange);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(536)]
    void Select();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(537)]
    int StartOf([In()]
int Unit, [In()]
int Extend);


    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(544)]
    int EndOf([In()]
int Unit, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(545)]
    int Move([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(546)]
    int MoveStart([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(547)]
    int MoveEnd([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(548)]
    int MoveWhile([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(549)]
    int MoveStartWhile([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(550)]
    int MoveEndWhile([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(551)]
    int MoveUntil([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(552)]
    int MoveStartUntil([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(553)]
    int MoveEndUntil([In(), MarshalAs(UnmanagedType.Struct)]
ref object Cset, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(560)]
    int FindText([In(), MarshalAs(UnmanagedType.BStr)]
string bstr, [In()]
int cch, [In()]
int Flags);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(561)]
    int FindTextStart([In(), MarshalAs(UnmanagedType.BStr)]
string bstr, [In()]
int cch, [In()]
int Flags);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(562)]
    int FindTextEnd([In(), MarshalAs(UnmanagedType.BStr)]
string bstr, [In()]
int cch, [In()]
int Flags);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(563)]
    int Delete([In()]
int Unit, [In()]
int Count);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(564)]
    void Cut([Out(), MarshalAs(UnmanagedType.Struct)]
ref object pVar);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(565)]
    void Copy([Out(), MarshalAs(UnmanagedType.Struct)]
ref object pVar);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(566)]
    void Paste([In(), MarshalAs(UnmanagedType.Struct)]
ref object pVar, [In()]
int Format);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(567)]
    int CanPaste([In(), MarshalAs(UnmanagedType.Struct)]
ref object pVar, [In()]
int Format);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(568)]
    int CanEdit();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(569)]
    void ChangeCase([In()]

int Type);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(576)]
    void GetPoint([In()]
int Type, [Out()]
ref int px, [Out()]
ref int py);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(577)]
    void SetPoint([In()]
int x, [In()]
int y, [In()]
int Type, [In()]
int Extend);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(578)]
    void ScrollIntoView([In()]
int Value);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(579)]
    [return: MarshalAs(UnmanagedType.IUnknown)]
    object GetEmbeddedObject();



}

//<ComImport(), Guid("8CC497C5-A1DF-11CE-8098-00AA0047BE5D"), DefaultMember("Item"), TypeLibType(CType(192, Short))> _
//Public Interface ITextStoryRanges
//	'Implements IEnumerable

//' Methods
//	<MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), TypeLibFunc(CType(1, Short)), DispId(-4)> _
//	Function GetEnumerator() As <MarshalAs(UnmanagedType.CustomMarshaler, MarshalType:="", MarshalTypeRef:=GetType(Runtime.InteropServices.custommarshallers.EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> Collections.IEnumerator
//	<MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(0)> _
//	Function Item(<[In]()> ByVal Index As Integer) As <MarshalAs(UnmanagedType.Interface)> ITextRange

//	' Properties
//<DispId(2)> _
//ReadOnly Property Count() As Integer
//End Interface

[ComImport(), Guid("8CC497C3-A1DF-11CE-8098-00AA0047BE5D"), DefaultMember("Duplicate"), TypeLibType(192)]
public interface ITextFont
{
    //<DispId(0)> _
    //Property Duplicate() As <MarshalAs(UnmanagedType.Interface)> ITextFont
    // Methods
    //[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(769)]
    bool CanChange { get; set; }
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(770)]
    int IsEqual([In(), MarshalAs(UnmanagedType.Interface)]
ITextFont pFont);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(771)]
    void Reset([In()]

int Value);
    // Properties
    [DispId(772)]
    int Style { get; set; }
    [DispId(773)]
    int AllCaps { get; set; }
    [DispId(774)]
    int Animation { get; set; }
    [DispId(775)]
    int BackColor { get; set; }
    [DispId(776)]
    int Bold { get; set; }
    [DispId(777)]

    int Emboss { get; set; }
    [DispId(784)]
    int ForeColor { get; set; }
    [DispId(785)]
    int Hidden { get; set; }
    [DispId(786)]
    int Engrave { get; set; }
    [DispId(787)]
    int Italic { get; set; }
    [DispId(788)]
    float Kerning { get; set; }
    [DispId(789)]
    int LanguageID { get; set; }
    [DispId(790)]
    string Name { get; set; }
    [DispId(791)]
    int Outline { get; set; }
    [DispId(792)]
    float Position { get; set; }
    [DispId(793)]

    int Protected { get; set; }
    [DispId(800)]
    int Shadow { get; set; }
    [DispId(801)]
    float Size { get; set; }
    [DispId(802)]
    int SmallCaps { get; set; }
    [DispId(803)]
    float Spacing { get; set; }
    [DispId(804)]
    int StrikeThrough { get; set; }
    [DispId(805)]
    int Subscript { get; set; }
    [DispId(806)]
    int Superscript { get; set; }
    [DispId(807)]
    int Underline { get; set; }
    [DispId(808)]
    int Weight { get; set; }
}

[ComImport(), Guid("8CC497C4-A1DF-11CE-8098-00AA0047BE5D"), TypeLibType(192), DefaultMember("Duplicate")]
public interface ITextPara
{

    //<DispId(0)> _
    //Property Duplicate() As <MarshalAs(UnmanagedType.Interface)> ITextPara

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1025)]
    int CanChange();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1026)]
    int IsEqual([In(), MarshalAs(UnmanagedType.Interface)]
ITextPara pPara);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1027)]
    void Reset([In()]
int Value);
    [DispId(1028)]
    int Style { get; set; }
    [DispId(1029)]
    int Alignment { get; set; }
    [DispId(1031)]
    float FirstLineIndent { get; }
    [DispId(1030)]
    int Hyphenation { get; set; }
    [DispId(1032)]
    int KeepTogether { get; set; }
    [DispId(1033)]

    int KeepWithNext { get; set; }
    [DispId(1040)]
    float LeftIndent { get; }
    [DispId(1041)]
    float LineSpacing { get; }
    [DispId(1042)]
    int LineSpacingRule { get; }
    [DispId(1043)]
    int ListAlignment { get; set; }
    [DispId(1044)]
    int ListLevelIndex { get; set; }
    [DispId(1045)]
    int ListStart { get; set; }
    [DispId(1046)]
    float ListTab { get; set; }
    [DispId(1047)]
    int ListType { get; set; }
    [DispId(1048)]
    int NoLineNumber { get; set; }
    [DispId(1049)]

    int PageBreakBefore { get; set; }
    [DispId(1056)]

    float RightIndent { get; set; }
    [DispId(1059)]
    float SpaceAfter { get; set; }
    [DispId(1060)]
    float SpaceBefore { get; set; }
    [DispId(1061)]
    int WidowControl { get; set; }
    [DispId(1062)]

    int TabCount { get; }
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1057)]
    void SetIndents([In()]
float StartIndent, [In()]
float LeftIndent, [In()]
float RightIndent);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1058)]
    void SetLineSpacing([In()]
int LineSpacingRule, [In()]

float LineSpacing);



    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1063)]
    void AddTab([In()]
float tbPos, [In()]
int tbAlign, [In()]
int tbLeader);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1064)]
    void ClearAllTabs();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1065)]
    void DeleteTab([In()]

float tbPos);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1072)]
    void GetTab(int iTab, ref float ptbPos, ref int ptbAlign, ref int ptbLeader);
}


#endregion
*/


























