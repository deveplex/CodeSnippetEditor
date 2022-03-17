namespace CodeSnippetEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView_SnippetExplorer = new System.Windows.Forms.TreeView();
            this.toolStrip_SnippetExplorer = new System.Windows.Forms.ToolStrip();
            this.toolStrip_FilterTextBox = new System.Windows.Forms.ToolStripSpringTextBox();
            this.toolStrip_ApplyFilterButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.combo_VS = new System.Windows.Forms.ComboBox();
            this.expandable_ImportPanel = new ExpandablePanel();
            this.dataGrid_ImportView = new System.Windows.Forms.DataGridView();
            this.expandable_ReferencePanel = new ExpandablePanel();
            this.dataGrid_ReferenceView = new System.Windows.Forms.DataGridView();
            this.expandablePanel2 = new ExpandablePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid_ReplacementView = new System.Windows.Forms.DataGridView();
            this.toolStrip_CodeEditor = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.codeEditor1 = new CodeEditor();
            this.expandablePanel1 = new ExpandablePanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ccccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.abToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextResourceKeyProvider = new System.Windows.Forms.ResourceKeyProvider(this.components);
            this.ToolTipResourceKeyProvider = new System.Windows.Forms.ResourceKeyProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.toolStrip_SnippetExplorer.SuspendLayout();
            this.expandable_ImportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ImportView)).BeginInit();
            this.expandable_ReferencePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ReferenceView)).BeginInit();
            this.expandablePanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ReplacementView)).BeginInit();
            this.toolStrip_CodeEditor.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.treeView_SnippetExplorer);
            this.MainSplitContainer.Panel1.Controls.Add(this.toolStrip_SnippetExplorer);
            this.MainSplitContainer.Panel1.Controls.Add(this.combo_VS);
            this.ToolTipResourceKeyProvider.SetResourceKey(this.MainSplitContainer.Panel1, "");
            this.TextResourceKeyProvider.SetResourceKey(this.MainSplitContainer.Panel1, "");
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.AutoScroll = true;
            this.MainSplitContainer.Panel2.Controls.Add(this.expandable_ImportPanel);
            this.MainSplitContainer.Panel2.Controls.Add(this.expandable_ReferencePanel);
            this.MainSplitContainer.Panel2.Controls.Add(this.expandablePanel2);
            this.MainSplitContainer.Panel2.Controls.Add(this.expandablePanel1);
            this.MainSplitContainer.Panel2.Controls.Add(this.toolStrip1);
            this.ToolTipResourceKeyProvider.SetResourceKey(this.MainSplitContainer.Panel2, "");
            this.TextResourceKeyProvider.SetResourceKey(this.MainSplitContainer.Panel2, "");
            this.TextResourceKeyProvider.SetResourceKey(this.MainSplitContainer, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.MainSplitContainer, "");
            this.MainSplitContainer.Size = new System.Drawing.Size(1154, 823);
            this.MainSplitContainer.SplitterDistance = 293;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // treeView_SnippetExplorer
            // 
            this.treeView_SnippetExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_SnippetExplorer.Location = new System.Drawing.Point(0, 45);
            this.treeView_SnippetExplorer.Name = "treeView_SnippetExplorer";
            this.TextResourceKeyProvider.SetResourceKey(this.treeView_SnippetExplorer, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.treeView_SnippetExplorer, "");
            this.treeView_SnippetExplorer.Size = new System.Drawing.Size(293, 778);
            this.treeView_SnippetExplorer.TabIndex = 3;
            // 
            // toolStrip_SnippetExplorer
            // 
            this.toolStrip_SnippetExplorer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_SnippetExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_FilterTextBox,
            this.toolStrip_ApplyFilterButton});
            this.toolStrip_SnippetExplorer.Location = new System.Drawing.Point(0, 20);
            this.toolStrip_SnippetExplorer.Name = "toolStrip_SnippetExplorer";
            this.toolStrip_SnippetExplorer.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.TextResourceKeyProvider.SetResourceKey(this.toolStrip_SnippetExplorer, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStrip_SnippetExplorer, "");
            this.toolStrip_SnippetExplorer.Size = new System.Drawing.Size(293, 25);
            this.toolStrip_SnippetExplorer.TabIndex = 2;
            this.toolStrip_SnippetExplorer.Text = "toolStrip_SnippetExplorer";
            // 
            // toolStrip_FilterTextBox
            // 
            this.toolStrip_FilterTextBox.Name = "toolStrip_FilterTextBox";
            this.TextResourceKeyProvider.SetResourceKey(this.toolStrip_FilterTextBox, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStrip_FilterTextBox, "");
            this.toolStrip_FilterTextBox.Size = new System.Drawing.Size(229, 25);
            // 
            // toolStrip_ApplyFilterButton
            // 
            this.toolStrip_ApplyFilterButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_ApplyFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStrip_ApplyFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_ApplyFilterButton.Image")));
            this.toolStrip_ApplyFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_ApplyFilterButton.Name = "toolStrip_ApplyFilterButton";
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStrip_ApplyFilterButton, "");
            this.TextResourceKeyProvider.SetResourceKey(this.toolStrip_ApplyFilterButton, "");
            this.toolStrip_ApplyFilterButton.Size = new System.Drawing.Size(29, 22);
            this.toolStrip_ApplyFilterButton.Text = "toolStripDropDownButton1";
            // 
            // combo_VS
            // 
            this.combo_VS.Dock = System.Windows.Forms.DockStyle.Top;
            this.combo_VS.FormattingEnabled = true;
            this.combo_VS.Location = new System.Drawing.Point(0, 0);
            this.combo_VS.Name = "combo_VS";
            this.ToolTipResourceKeyProvider.SetResourceKey(this.combo_VS, "");
            this.TextResourceKeyProvider.SetResourceKey(this.combo_VS, "");
            this.combo_VS.Size = new System.Drawing.Size(293, 20);
            this.combo_VS.TabIndex = 1;
            // 
            // expandable_ImportPanel
            // 
            this.expandable_ImportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandable_ImportPanel.Collapsed = false;
            this.expandable_ImportPanel.Controls.Add(this.dataGrid_ImportView);
            this.expandable_ImportPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandable_ImportPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.expandable_ImportPanel.Location = new System.Drawing.Point(0, 719);
            this.expandable_ImportPanel.Name = "expandable_ImportPanel";
            this.TextResourceKeyProvider.SetResourceKey(this.expandable_ImportPanel, "Application.SnippetEditor.Category.Item4");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.expandable_ImportPanel, "");
            this.expandable_ImportPanel.Size = new System.Drawing.Size(857, 68);
            this.expandable_ImportPanel.TabIndex = 5;
            this.expandable_ImportPanel.Text = "expandablePanel1";
            this.expandable_ImportPanel.TitleBackColor1 = System.Drawing.Color.Gray;
            this.expandable_ImportPanel.TitleBackColor2 = System.Drawing.Color.Empty;
            this.expandable_ImportPanel.TitleFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandable_ImportPanel.TitleForeColor = System.Drawing.SystemColors.HighlightText;
            this.expandable_ImportPanel.TitleHeight = 23;
            // 
            // dataGrid_ImportView
            // 
            this.dataGrid_ImportView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_ImportView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid_ImportView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_ImportView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ImportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_ImportView.Location = new System.Drawing.Point(0, 23);
            this.dataGrid_ImportView.Name = "dataGrid_ImportView";
            this.TextResourceKeyProvider.SetResourceKey(this.dataGrid_ImportView, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.dataGrid_ImportView, "");
            this.dataGrid_ImportView.RowHeadersVisible = false;
            this.dataGrid_ImportView.RowTemplate.Height = 23;
            this.dataGrid_ImportView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_ImportView.Size = new System.Drawing.Size(855, 43);
            this.dataGrid_ImportView.TabIndex = 1;
            // 
            // expandable_ReferencePanel
            // 
            this.expandable_ReferencePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandable_ReferencePanel.Collapsed = false;
            this.expandable_ReferencePanel.Controls.Add(this.dataGrid_ReferenceView);
            this.expandable_ReferencePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandable_ReferencePanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.expandable_ReferencePanel.Location = new System.Drawing.Point(0, 651);
            this.expandable_ReferencePanel.Name = "expandable_ReferencePanel";
            this.TextResourceKeyProvider.SetResourceKey(this.expandable_ReferencePanel, "Application.SnippetEditor.Category.Item3");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.expandable_ReferencePanel, "");
            this.expandable_ReferencePanel.Size = new System.Drawing.Size(857, 68);
            this.expandable_ReferencePanel.TabIndex = 4;
            this.expandable_ReferencePanel.Text = "expandablePanel1";
            this.expandable_ReferencePanel.TitleBackColor1 = System.Drawing.Color.Gray;
            this.expandable_ReferencePanel.TitleBackColor2 = System.Drawing.Color.Empty;
            this.expandable_ReferencePanel.TitleFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandable_ReferencePanel.TitleForeColor = System.Drawing.SystemColors.HighlightText;
            this.expandable_ReferencePanel.TitleHeight = 23;
            // 
            // dataGrid_ReferenceView
            // 
            this.dataGrid_ReferenceView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_ReferenceView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid_ReferenceView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_ReferenceView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ReferenceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_ReferenceView.Location = new System.Drawing.Point(0, 23);
            this.dataGrid_ReferenceView.Name = "dataGrid_ReferenceView";
            this.TextResourceKeyProvider.SetResourceKey(this.dataGrid_ReferenceView, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.dataGrid_ReferenceView, "");
            this.dataGrid_ReferenceView.RowHeadersVisible = false;
            this.dataGrid_ReferenceView.RowTemplate.Height = 23;
            this.dataGrid_ReferenceView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_ReferenceView.Size = new System.Drawing.Size(855, 43);
            this.dataGrid_ReferenceView.TabIndex = 1;
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandablePanel2.Collapsed = false;
            this.expandablePanel2.Controls.Add(this.panel1);
            this.expandablePanel2.Controls.Add(this.codeEditor1);
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.expandablePanel2.Location = new System.Drawing.Point(0, 223);
            this.expandablePanel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.expandablePanel2.Name = "expandablePanel2";
            this.TextResourceKeyProvider.SetResourceKey(this.expandablePanel2, "Application.SnippetEditor.Category.Item2");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.expandablePanel2, "");
            this.expandablePanel2.Size = new System.Drawing.Size(857, 428);
            this.expandablePanel2.TabIndex = 3;
            this.expandablePanel2.Text = "expandablePanel1";
            this.expandablePanel2.TitleBackColor1 = System.Drawing.Color.Gray;
            this.expandablePanel2.TitleBackColor2 = System.Drawing.Color.Empty;
            this.expandablePanel2.TitleFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanel2.TitleForeColor = System.Drawing.SystemColors.HighlightText;
            this.expandablePanel2.TitleHeight = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGrid_ReplacementView);
            this.panel1.Controls.Add(this.toolStrip_CodeEditor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 251);
            this.panel1.Name = "panel1";
            this.ToolTipResourceKeyProvider.SetResourceKey(this.panel1, "");
            this.TextResourceKeyProvider.SetResourceKey(this.panel1, "");
            this.panel1.Size = new System.Drawing.Size(855, 175);
            this.panel1.TabIndex = 2;
            // 
            // dataGrid_ReplacementView
            // 
            this.dataGrid_ReplacementView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_ReplacementView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid_ReplacementView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_ReplacementView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ReplacementView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_ReplacementView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGrid_ReplacementView.Location = new System.Drawing.Point(0, 25);
            this.dataGrid_ReplacementView.Name = "dataGrid_ReplacementView";
            this.dataGrid_ReplacementView.ReadOnly = true;
            this.TextResourceKeyProvider.SetResourceKey(this.dataGrid_ReplacementView, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.dataGrid_ReplacementView, "");
            this.dataGrid_ReplacementView.RowHeadersVisible = false;
            this.dataGrid_ReplacementView.RowTemplate.Height = 23;
            this.dataGrid_ReplacementView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_ReplacementView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid_ReplacementView.Size = new System.Drawing.Size(855, 150);
            this.dataGrid_ReplacementView.TabIndex = 1;
            // 
            // toolStrip_CodeEditor
            // 
            this.toolStrip_CodeEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip_CodeEditor.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_CodeEditor.Name = "toolStrip_CodeEditor";
            this.TextResourceKeyProvider.SetResourceKey(this.toolStrip_CodeEditor, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStrip_CodeEditor, "");
            this.toolStrip_CodeEditor.Size = new System.Drawing.Size(855, 25);
            this.toolStrip_CodeEditor.TabIndex = 0;
            this.toolStrip_CodeEditor.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.TextResourceKeyProvider.SetResourceKey(this.toolStripButton1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStripButton1, "");
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.TextResourceKeyProvider.SetResourceKey(this.toolStripButton2, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStripButton2, "");
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // codeEditor1
            // 
            this.codeEditor1.AcceptsTab = true;
            this.codeEditor1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeEditor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.codeEditor1.Location = new System.Drawing.Point(0, 23);
            this.codeEditor1.Name = "codeEditor1";
            this.TextResourceKeyProvider.SetResourceKey(this.codeEditor1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.codeEditor1, "");
            this.codeEditor1.Size = new System.Drawing.Size(855, 228);
            this.codeEditor1.TabIndex = 0;
            this.codeEditor1.Text = "";
            this.codeEditor1.WordWrap = false;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandablePanel1.Collapsed = false;
            this.expandablePanel1.Controls.Add(this.tableLayoutPanel1);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 25);
            this.expandablePanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.expandablePanel1.Name = "expandablePanel1";
            this.TextResourceKeyProvider.SetResourceKey(this.expandablePanel1, "Application.SnippetEditor.Category.Item1");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.expandablePanel1, "");
            this.expandablePanel1.Size = new System.Drawing.Size(857, 198);
            this.expandablePanel1.TabIndex = 2;
            this.expandablePanel1.Text = "expandablePanel1";
            this.expandablePanel1.TitleBackColor1 = System.Drawing.Color.Gray;
            this.expandablePanel1.TitleBackColor2 = System.Drawing.Color.Empty;
            this.expandablePanel1.TitleFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanel1.TitleForeColor = System.Drawing.SystemColors.HighlightText;
            this.expandablePanel1.TitleHeight = 23;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.TextResourceKeyProvider.SetResourceKey(this.tableLayoutPanel1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.tableLayoutPanel1, "");
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 144);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label1.Name = "label1";
            this.TextResourceKeyProvider.SetResourceKey(this.label1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label1, "");
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox5, 3);
            this.textBox5.Location = new System.Drawing.Point(57, 117);
            this.textBox5.Name = "textBox5";
            this.TextResourceKeyProvider.SetResourceKey(this.textBox5, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.textBox5, "");
            this.textBox5.Size = new System.Drawing.Size(772, 21);
            this.textBox5.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 3);
            this.textBox1.Location = new System.Drawing.Point(57, 3);
            this.textBox1.Name = "textBox1";
            this.TextResourceKeyProvider.SetResourceKey(this.textBox1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.textBox1, "");
            this.textBox1.Size = new System.Drawing.Size(772, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label7.Name = "label7";
            this.TextResourceKeyProvider.SetResourceKey(this.label7, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label7, "");
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "label7";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label2.Name = "label2";
            this.TextResourceKeyProvider.SetResourceKey(this.label2, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label2, "");
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(380, 88);
            this.comboBox2.Name = "comboBox2";
            this.TextResourceKeyProvider.SetResourceKey(this.comboBox2, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.comboBox2, "");
            this.comboBox2.Size = new System.Drawing.Size(231, 20);
            this.comboBox2.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox2, 3);
            this.textBox2.Location = new System.Drawing.Point(57, 31);
            this.textBox2.Name = "textBox2";
            this.TextResourceKeyProvider.SetResourceKey(this.textBox2, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.textBox2, "");
            this.textBox2.Size = new System.Drawing.Size(772, 21);
            this.textBox2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(35, 0, 10, 0);
            this.label6.Name = "label6";
            this.TextResourceKeyProvider.SetResourceKey(this.label6, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label6, "");
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label3.Name = "label3";
            this.TextResourceKeyProvider.SetResourceKey(this.label3, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label3, "");
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(57, 88);
            this.comboBox1.Name = "comboBox1";
            this.TextResourceKeyProvider.SetResourceKey(this.comboBox1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.comboBox1, "");
            this.comboBox1.Size = new System.Drawing.Size(231, 20);
            this.comboBox1.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.Location = new System.Drawing.Point(57, 59);
            this.textBox3.Name = "textBox3";
            this.TextResourceKeyProvider.SetResourceKey(this.textBox3, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.textBox3, "");
            this.textBox3.Size = new System.Drawing.Size(231, 21);
            this.textBox3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label5.Name = "label5";
            this.TextResourceKeyProvider.SetResourceKey(this.label5, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label5, "");
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(35, 0, 10, 0);
            this.label4.Name = "label4";
            this.TextResourceKeyProvider.SetResourceKey(this.label4, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.label4, "");
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.Location = new System.Drawing.Point(380, 59);
            this.textBox4.Name = "textBox4";
            this.TextResourceKeyProvider.SetResourceKey(this.textBox4, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.textBox4, "");
            this.textBox4.Size = new System.Drawing.Size(231, 21);
            this.textBox4.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.TextResourceKeyProvider.SetResourceKey(this.toolStrip1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStrip1, "");
            this.toolStrip1.Size = new System.Drawing.Size(857, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip_SnippetEditor";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ccccToolStripMenuItem,
            this.toolStripMenuItem1,
            this.abToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStripDropDownButton1, "");
            this.TextResourceKeyProvider.SetResourceKey(this.toolStripDropDownButton1, "Application.Menu.Tools");
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(179, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // ccccToolStripMenuItem
            // 
            this.ccccToolStripMenuItem.Name = "ccccToolStripMenuItem";
            this.ToolTipResourceKeyProvider.SetResourceKey(this.ccccToolStripMenuItem, "");
            this.TextResourceKeyProvider.SetResourceKey(this.ccccToolStripMenuItem, "Application.Menu.Config");
            this.ccccToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ccccToolStripMenuItem.Text = "Mune";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.TextResourceKeyProvider.SetResourceKey(this.toolStripMenuItem1, "");
            this.ToolTipResourceKeyProvider.SetResourceKey(this.toolStripMenuItem1, "");
            this.toolStripMenuItem1.Size = new System.Drawing.Size(106, 6);
            // 
            // abToolStripMenuItem
            // 
            this.abToolStripMenuItem.Name = "abToolStripMenuItem";
            this.ToolTipResourceKeyProvider.SetResourceKey(this.abToolStripMenuItem, "");
            this.TextResourceKeyProvider.SetResourceKey(this.abToolStripMenuItem, "Application.Menu.Exit");
            this.abToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abToolStripMenuItem.Text = "Mune";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 823);
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "MainForm";
            this.TextResourceKeyProvider.SetResourceKey(this, "ApplicationName");
            this.ToolTipResourceKeyProvider.SetResourceKey(this, "");
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.PerformLayout();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.toolStrip_SnippetExplorer.ResumeLayout(false);
            this.toolStrip_SnippetExplorer.PerformLayout();
            this.expandable_ImportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ImportView)).EndInit();
            this.expandable_ReferencePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ReferenceView)).EndInit();
            this.expandablePanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ReplacementView)).EndInit();
            this.toolStrip_CodeEditor.ResumeLayout(false);
            this.toolStrip_CodeEditor.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ResourceKeyProvider TextResourceKeyProvider;
        private ExpandablePanel expandablePanel1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private ExpandablePanel expandablePanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid_ReplacementView;
        private System.Windows.Forms.ToolStrip toolStrip_CodeEditor;
        private CodeEditor codeEditor1;
        private ExpandablePanel expandable_ReferencePanel;
        private System.Windows.Forms.DataGridView dataGrid_ReferenceView;
        private ExpandablePanel expandable_ImportPanel;
        private System.Windows.Forms.DataGridView dataGrid_ImportView;
        private System.Windows.Forms.ComboBox combo_VS;
        private System.Windows.Forms.ToolStrip toolStrip_SnippetExplorer;
        private System.Windows.Forms.ToolStripSpringTextBox toolStrip_FilterTextBox;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_ApplyFilterButton;
        private System.Windows.Forms.TreeView treeView_SnippetExplorer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ccccToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abToolStripMenuItem;
        private System.Windows.Forms.ResourceKeyProvider ToolTipResourceKeyProvider;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

