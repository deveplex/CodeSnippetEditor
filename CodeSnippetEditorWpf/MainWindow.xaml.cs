using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeSnippetEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Hashtable> LocalizationViewModel { get; set; }

        private dynamic PropertieViewModel { get; set; }
        private dynamic CodeViewModel { get; set; }
        private ObservableCollection<Replacement> ReplacementViewModel { get; set; }
        private ObservableCollection<Import> ImportViewModel { get; set; }
        private ObservableCollection<Reference> ReferenceViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeVariation();
            this.DataContext = this;// LocalizationViewModel;

            this.Loaded += MainWindow_Loaded;

            this.ctrlConfigMenuItem.Click += CtrlConfigMenuItem_Click;

            this.ctrlCodeSnippetEditorView.SizeChanged += ScrollViewer_SizeChanged;
            this.ctrlReplacementDataGrid.LoadingRow += DataGrid_LoadingRow;
            this.ctrlReplacementDataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            this.ctrlReferenceDataGrid.LoadingRow += DataGrid_LoadingRow;
            this.ctrlReferenceDataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            this.ctrlImportDataGrid.LoadingRow += DataGrid_LoadingRow;
            this.ctrlImportDataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;

            this.ctrlCodeLanguageComboBox.SelectionChanged += CtrlCodeLanguageComboBox_SelectionChanged;

        }

        private void CtrlCodeLanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ggg = PropertieViewModel.ObservableObject;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(int))
            {
                e.Column.MinWidth = 30;
            }
            if (e.PropertyType == typeof(string))
            {
                e.Column.MinWidth = 100;
            }
            if (e.PropertyType.BaseType == typeof(bool))
            {
                e.Column.MinWidth = 60;
            }
            if (e.PropertyType.BaseType == typeof(Enum))
            {
                e.Column.MinWidth = 80;
            }
        }

        private void InitializeVariation()
        {
            LocalizationViewModel = new ObservableCollection<Hashtable>();

            ReplacementViewModel = new ObservableCollection<Replacement>();
            ImportViewModel = new ObservableCollection<Import>();
            ReferenceViewModel = new ObservableCollection<Reference>();
        }

        private void InitializeControl()
        {
            var ToolBars = this.FindVisualChild<ToolBar>();
            foreach (var toolBar in ToolBars)
            {
                var grids = toolBar.FindVisualChild<Grid>();
                var grid = grids.FirstOrDefault(m => m.TemplatedParent == toolBar);
                if (grid != null)
                {
                    grid.Margin = new Thickness(0, 1, 0, 1);
                }
                //var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
                //if (overflowGrid != null)
                //{
                //    overflowGrid.Visibility = Visibility.Hidden;
                //}
                var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as Border;
                if (mainPanelBorder != null)
                {
                    mainPanelBorder.Margin = new Thickness(0);
                    mainPanelBorder.CornerRadius = new CornerRadius(0);
                }
            }

        }

        private void CtrlConfigMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window c = new ConfigWindow();
            c.ShowDialog();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var view = ((ScrollViewer)sender);
            var hPadding = view.Padding.Left + view.Padding.Right;
            var scrollBars = ((ScrollViewer)sender).FindVisualChild<ScrollBar>();
            var vBar = scrollBars.FirstOrDefault(m => double.IsNaN(m.Height) && m.TemplatedParent == sender);
            var w = 0d;
            if (vBar.Visibility == Visibility.Visible)
                w = vBar.Width;
            //ctrlReplacementDataGrid.Width = e.NewSize.Width - 20 - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
            //ctrlReferenceDataGrid.Width = e.NewSize.Width - 20 - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
            //ctrlImportDataGrid.Width = e.NewSize.Width - 20 - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
            ctrlPropertiesExpander.Width = e.NewSize.Width - hPadding - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
            ctrlCodeEditorExpander.Width = e.NewSize.Width - hPadding - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
            ctrlReferenceExpander.Width = e.NewSize.Width - hPadding - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
            ctrlImportExpander.Width = e.NewSize.Width - hPadding - w - 2;// ((FrameworkElement)ctrl_ReplacementDataGrid.Parent).ActualWidth;
        }

        private void ApplyLocalization()
        {
            LocalizationViewModel = new ObservableCollection<Hashtable>();

            Hashtable localizationResources = new Hashtable();
            LocalizationViewModel.Add(localizationResources);

            var key = ResourceKeyProvider.GetTextKey(this);
            if (!string.IsNullOrEmpty(key))
                if (!localizationResources.ContainsKey(key))
                    localizationResources.Add(key, Properties.Resources.GetString(key));
            key = ResourceKeyProvider.GetToolTipKey(this);
            if (!string.IsNullOrEmpty(key))
                if (!localizationResources.ContainsKey(key))
                    localizationResources.Add(key, Properties.Resources.GetString(key));

            var ctrlList = this.ctrlWindowBorder.FindLogicalChild<Control>();
            foreach (var ctrl in ctrlList)
            {
                key = ResourceKeyProvider.GetTextKey(ctrl);
                if (!string.IsNullOrEmpty(key))
                    if (!localizationResources.ContainsKey(key))
                        localizationResources.Add(key, Properties.Resources.GetString(key));
                key = ResourceKeyProvider.GetToolTipKey(ctrl);
                if (!string.IsNullOrEmpty(key))
                    if (!localizationResources.ContainsKey(key))
                        localizationResources.Add(key, Properties.Resources.GetString(key));
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControl();
            ApplyLocalization();
            this.DataContext = LocalizationViewModel;


            var propertie = new Propertie();
            propertie.Language = "Visual C#";
            propertie.Kind = "Unspecified";
            PropertieViewModel = new ObservableModel<Propertie>(propertie);
            ctrlTitleTextBox.DataContext = ctrlDescriptionTextBox.DataContext = ctrlAuthorTextBox.DataContext =
            ctrlShortoutTextBox.DataContext = ctrlHelpUrlTextBox.DataContext = ctrlCodeLanguageComboBox.DataContext = ctrlCodeKindComboBox.DataContext = PropertieViewModel;

            CodeViewModel = new ObservableModel<Code>();
            ctrlCodeRichTextBox.DataContext = CodeViewModel;

            ReplacementViewModel = new ObservableCollection<Replacement>
            {
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
                //new Replacement {  },
            };
            ctrlReplacementDataGrid.ItemsSource = ReplacementViewModel;

            ReferenceViewModel = new ObservableCollection<Reference>
            {
                //new Reference { Assembly="fdfdfdfdf", Url="http://schemas.openxmlformats.org/markup-compatibility/2006" },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
                //new Reference {  },
            };
            ctrlReferenceDataGrid.ItemsSource = ReferenceViewModel;

            ImportViewModel = new ObservableCollection<Import>
            {
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
                //new Import {  },
            };
            ctrlImportDataGrid.ItemsSource = ImportViewModel;

            SplitButton.Click += (obj, args) => { SplitButtonMenu.PlacementTarget = (Button)obj; SplitButtonMenu.Placement = PlacementMode.Bottom; SplitButtonMenu.IsOpen = true; };
        }
    }
}

namespace System.Windows
{
    public static class DependencyObjectEx
    {
        public static IList<T> FindLogicalChild<T>(this FrameworkElement obj) where T : FrameworkElement
        {
            List<T> TList = new List<T> { };
            var children = LogicalTreeHelper.GetChildren(obj);
            if (children == null)
                return TList;
            foreach (var child in children)
            {
                if (child is T)
                {
                    TList.Add((T)child);
                }
                if (child is FrameworkElement)
                {
                    IList<T> childOfChildren = ((FrameworkElement)child).FindLogicalChild<T>();
                    if (childOfChildren != null)
                    {
                        TList.AddRange(childOfChildren);
                    }
                }
            }
            return TList;
        }

        public static IList<T> FindLogicalParent<T>(this DependencyObject obj) where T : DependencyObject
        {
            List<T> TList = new List<T> { };
            DependencyObject parent = LogicalTreeHelper.GetParent(obj);
            if (parent == null)
                return TList;
            if (parent is T)
            {
                TList.Add((T)parent);
            }
            IList<T> parentOfParent = parent.FindLogicalParent<T>();
            if (parentOfParent != null)
            {
                TList.AddRange(parentOfParent);
            }
            return TList;
        }

        public static IList<T> FindVisualChild<T>(this DependencyObject obj) where T : DependencyObject
        {
            List<T> TList = new List<T> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child == null)
                    continue;
                if (child is T)
                {
                    TList.Add((T)child);
                }
                IList<T> childOfChildren = child.FindVisualChild<T>();
                if (childOfChildren != null)
                {
                    TList.AddRange(childOfChildren);
                }
            }
            return TList;
        }

        public static IList<T> FindVisualParent<T>(this DependencyObject obj) where T : DependencyObject
        {
            List<T> TList = new List<T> { };
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            if (parent == null)
                return TList;
            if (parent is T)
            {
                TList.Add((T)parent);
            }
            IList<T> parentOfParent = parent.FindVisualParent<T>();
            if (parentOfParent != null)
            {
                TList.AddRange(parentOfParent);
            }
            return TList;
        }
    }
}