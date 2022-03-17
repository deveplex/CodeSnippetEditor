using CodeSnippetEditor.UI_Controls;
using SnippetRepresentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeSnippetEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeFormControl();
            this.Load += MainForm_Load;
            this.Layout += MainForm_Layout;

            this.MainSplitContainer.SplitterMoved += MainSplitContainer_SplitterMoved;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //var Collapse = File.OpenRead(Path.Combine("Resources", "Collapse_large.bmp"));
            //byte[] dfd = new byte[Collapse.Length];
            //Collapse.Read(dfd, 0, dfd.Length);
            //var d = Convert.ToBase64String(dfd);

            //var Expand = File.OpenRead(Path.Combine("Resources", "Expand_large.bmp"));
            //byte[] dfd1 = new byte[Expand.Length];
            //Expand.Read(dfd1, 0, dfd1.Length);
            //var f = Convert.ToBase64String(dfd1);
        }

        private void MainForm_Layout(object sender, LayoutEventArgs e)
        {
            ApplyResources();
        }

        private void InitializeFormControl()
        {
            BindingSource replacementSource = new BindingSource();
            replacementSource.DataSource = new List<Replacement> { };
            dataGrid_ReplacementView.DataSource = replacementSource;

            BindingSource referenceSource = new BindingSource();
            referenceSource.DataSource = new List<Reference> { };
            dataGrid_ReferenceView.DataSource = referenceSource;

            BindingSource importSource = new BindingSource();
            importSource.DataSource = new List<Import> { };
            dataGrid_ImportView.DataSource = importSource;
        }

        private void ApplyResources()
        {
            var key = this.TextResourceKeyProvider.GetResourceKey(this);
            if (!string.IsNullOrEmpty(key))
                this.Text = Resources.GetString(key);

            var childrens = this.GetAllChildren();
            foreach (Control ctrl in childrens)
            {
                if (ctrl is TextBox || ctrl is ComboBox )
                    continue;
                if (ctrl is DataGrid || ctrl is DataGridView)
                {
                    ctrl.Refresh();
                    continue;
                }
                if (ctrl is ToolStrip)
                {
                   var items = ((ToolStrip)ctrl).GetAllChildren();
                    foreach (ToolStripItem item in items)
                    {
                        key = this.TextResourceKeyProvider.GetResourceKey(item);
                        if (!string.IsNullOrEmpty(key))
                            item.Text = Resources.GetString(key);
                    }
                    continue;
                }
                key = this.TextResourceKeyProvider.GetResourceKey(ctrl);
                if (!string.IsNullOrEmpty(key))
                    ctrl.Text = Resources.GetString(key);
            }
        }

        
        private void MainSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (this.MainSplitContainer.SplitterDistance > 350)
                this.MainSplitContainer.SplitterDistance = 350;
        }
    }
}
