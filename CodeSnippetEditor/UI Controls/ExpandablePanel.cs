//-----------------------------------------------------------------
// Copyright (c) Bill McCarthy.  
// This code and information are provided "as is"  without warranty
// of any kind either expressed or implied. Use at your own risk.
//-----------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;


// ERROR: Not supported in C#: OptionDeclaration

[DesignerCategory("")]
public class ExpandablePanel : Panel, INotifyPropertyChanged
{
    string _collapseI = "Qk1AAgAAAAAAADYAAAAoAAAADQAAAA0AAAABABgAAAAAAAoCAAASCwAAEgsAAAAAAAAAAAAA/wD/4NXItZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp74NXI/wD/AODVyLWae/Dr5P7+/f7+/f7+/f7+/f7+/f7+/f7+/fDr5LWae+DVyAC1mnvw6+T+/v3+/v3+/v3+/v3+/v3+/v3+/v3+/v3+/v3w6+S1mnsAtZp7/v79/v79mVtFmVtF/v79/v79/v79mVtFmVtF/v79/v79tZp7ALWae/7+/f7+/f7+/ZlbRZlbRf7+/ZlbRZlbRf7+/f7+/f7+/bWaewC1mnv+/v3+/v3+/v3+/v2ZW0WZW0WZW0X+/v3+/v3+/v3+/v21mnsAtZp7/v79/v79/v79/v79/v79mVtF/v79/v79/v79/v79/v79tZp7ALWae/7+/f7+/ZlbRZlbRf7+/f7+/f7+/ZlbRZlbRf7+/f7+/bWaewC1mnv+/v3+/v3+/v2ZW0WZW0X+/v2ZW0WZW0X+/v3+/v3+/v21mnsAtZp7/v79/v79/v79/v79mVtFmVtFmVtF/v79/v79/v799/TwtZp7ALWae/Dr5P7+/f7+/f7+/f7+/ZlbRf7+/f7+/f7+/f7+/fDr5LWaewDg1ci1mnvw6+T+/v3+/v3+/v3+/v3+/v3+/v3+/v3w6+S1mnvl3NEA/wD/4NXItZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp74NXI/wD/AAAA";
    string _expandI = "Qk1AAgAAAAAAADYAAAAoAAAADQAAAA0AAAABABgAAAAAAAoCAAASCwAAEgsAAAAAAAAAAAAA/wD/4NXItZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp74NXI/wD/AODVyLWae/Dr5P7+/f7+/f7+/f7+/f7+/f7+/f7+/fDr5LWae+DVyAC1mnvw6+T+/v3+/v3+/v3+/v2ZW0X+/v3+/v3+/v3+/v3w6+S1mnsAtZp7/v79/v79/v79/v79mVtFmVtFmVtF/v79/v79/v79/v79tZp7ALWae/7+/f7+/f7+/ZlbRZlbRf7+/ZlbRZlbRf7+/f7+/f7+/bWaewC1mnv+/v3+/v2ZW0WZW0X+/v3+/v3+/v2ZW0WZW0X+/v3+/v21mnsAtZp7/v79/v79/v79/v79/v79mVtF/v79/v79/v79/v79/v79tZp7ALWae/7+/f7+/f7+/f7+/ZlbRZlbRZlbRf7+/f7+/f7+/f7+/bWaewC1mnv+/v3+/v3+/v2ZW0WZW0X+/v2ZW0WZW0X+/v3+/v3+/v21mnsAtZp7/v79/v79mVtFmVtF/v79/v79/v79mVtFmVtF/v799/TwtZp7ALWae/Dr5P7+/f7+/f7+/f7+/f7+/f7+/f7+/f7+/f7+/fDr5LWaewDg1ci1mnvw6+T+/v3+/v3+/v3+/v3+/v3+/v3+/v3w6+S1mnvl3NEA/wD/4NXItZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp7tZp74NXI/wD/AAAA";
    Image _collapseImage = null;
    Image _expandImage = null;
    int _height = 0;

    public ExpandablePanel() : base()
    {
        Title = new GradientLabel();
        var coll = Convert.FromBase64String(_collapseI);
        _collapseImage = new Bitmap(new System.IO.MemoryStream(coll));
        var expl = Convert.FromBase64String(_expandI);
        _expandImage = new Bitmap(new System.IO.MemoryStream(expl));
        InitializeTitle();
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        _height = this.Height;
    }

    private GradientLabel withEventsField__title;
    private GradientLabel Title
    {
        get { return withEventsField__title; }
        set
        {
            if (withEventsField__title != null)
            {
                withEventsField__title.Click -= Title_Click;
            }
            withEventsField__title = value;
            if (withEventsField__title != null)
            {
                withEventsField__title.Click += Title_Click;
            }
        }
    }

    private bool _Collapsed = false;


    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(typeof(Color), "Silver")]
    public Color TitleBackColor1
    {
        get { return Title.BackColor; }
        set
        {
            if (value != Title.BackColor)
            {
                Title.BackColor = value;
                Title.Invalidate();
            }
        }
    }


    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DefaultValue(typeof(Color), "White")]
    public Color TitleBackColor2
    {
        get { return Title.BackColor2; }
        set
        {
            if (value != Title.BackColor2)
            {
                Title.BackColor2 = value;
                Title.Invalidate();
            }
        }
    }


    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Color TitleForeColor
    {
        get { return Title.ForeColor; }
        set
        {
            if (value != Title.ForeColor)
            {
                Title.ForeColor = value;
                Title.Invalidate();
            }
        }
    }


    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Int32 TitleHeight
    {
        get { return Title.Height; }
        set
        {
            if (value != Title.Height)
            {
                Title.Height = value;
                Title.Invalidate();
            }
        }
    }

    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public Font TitleFont
    {
        get { return Title.Font; }
        set
        {
            Title.Font = value;
            Title.Invalidate();
        }
    }


    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public LinearGradientMode GradientMode
    {
        get { return Title.GradientMode; }
        set
        {
            if (value != Title.GradientMode)
            {
                Title.GradientMode = value;
                Title.Invalidate();
            }
        }
    }

    [Category("Appearance")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool Collapsed
    {
        get { return _Collapsed; }
        set
        {
            if (value != _Collapsed)
            {
                ToggleCollapsed();
                OnPropertyChanged("Collapsed");
            }
        }
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public override string Text
    {
        get { return Title.Text; }
        set
        {
            if (value != Title.Text)
            {
                Title.Text = value;
                Title.Invalidate();
                OnPropertyChanged("Text");
            }
        }
    }


    public override System.Drawing.Font Font
    {
        get { return base.Font; }
        set
        {
            if (!object.ReferenceEquals(value, base.Font))
            {
                base.Font = value;
                Title.Font = value;
                Title.Invalidate();
            }
        }
    }



    private void InitializeTitle()
    {
        var _with1 = this.Title;
        _with1.AutoEllipsis = true;
        _with1.AutoSize = false;
        _with1.Dock = DockStyle.Top;
        _with1.Image = _collapseImage;
        _with1.ImageAlign = ContentAlignment.MiddleRight;
        _with1.TextAlign = ContentAlignment.MiddleLeft;
        _with1.Visible = true;
        this.Controls.Add(Title);
    }




    private void Title_Click(object sender, System.EventArgs e)
    {
        Collapsed = !Collapsed;
    }
    //readonly Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag static_ToggleCollapsed__topPadding_Init = new Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag();


    Int32 static_ToggleCollapsed__topPadding;

    private void ToggleCollapsed()
    {
        //lock (static_ToggleCollapsed__topPadding_Init)
        //{
        //    try
        //    {
        //        if (InitStaticVariableHelper(static_ToggleCollapsed__topPadding_Init))
        //        {
        //            static_ToggleCollapsed__topPadding = 2;
        //        }
        //    }
        //    finally
        //    {
        //        static_ToggleCollapsed__topPadding_Init.State = 1;
        //    }
        //}
        if (_Collapsed)
        {
            this.Padding = new Padding(this.Padding.Left, 0, this.Padding.Right, this.Padding.Bottom);
            this.AutoSize = false;
            this.Height = _height;
            _Collapsed = false;
            Title.Image = _collapseImage;
        }
        else
        {
            static_ToggleCollapsed__topPadding = this.Padding.Top;
            this.Padding = new Padding(this.Padding.Left, 0, this.Padding.Right, this.Padding.Bottom);
            this.AutoSize = false;
            this.Height = Title.Height + 2;
            _Collapsed = true;
            Title.Image = _expandImage;
        }
    }

    protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
    {
        base.OnControlAdded(e);
        Title.SendToBack();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    //static bool InitStaticVariableHelper(Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag flag)
    //{
    //	if (flag.State == 0) {
    //		flag.State = 2;
    //		return true;
    //	} else if (flag.State == 2) {
    //		throw new Microsoft.VisualBasic.CompilerServices.IncompleteInitialization();
    //	} else {
    //		return false;
    //	}
    //}


    private class GradientLabel : Label
    {

        public GradientLabel() : base()
        {
        }

        private Color _BackColor2;
        [Category("Appearance")]
        public Color BackColor2
        {
            get { return _BackColor2; }
            set
            {
                _BackColor2 = value;
                this.Invalidate();
            }
        }




        private LinearGradientMode _GradientMode;
        [Category("Appearance")]
        [DefaultValue(typeof(LinearGradientMode), "0")]
        public LinearGradientMode GradientMode
        {
            get { return _GradientMode; }
            set
            {
                _GradientMode = value;
                this.Invalidate();
            }
        }



        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (LinearGradientBrush br = new LinearGradientBrush(rect, this.BackColor, this.BackColor2, this.GradientMode))
            {
                e.Graphics.FillRectangle(br, rect);
            }
        }



    }
}
