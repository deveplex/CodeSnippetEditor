using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeSnippetEditor
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private ObservableCollection<Hashtable> LocalizationViewModel { get; set; }

        private ObservableCollection<CultureInfo> CultureInfoViewModel { get; set; }

        public ConfigWindow()
        {
            InitializeComponent();
            InitializeVariation();

            this.Loaded += ConfigWindow_Loaded;
        }
         public void InitializeVariation()
        {
            LocalizationViewModel = new ObservableCollection<Hashtable>();

            CultureInfoViewModel = new ObservableCollection<CultureInfo>();
        }

        private void ConfigWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyLocalization();
            this.DataContext = LocalizationViewModel;

            var culs = new List<string> { "en-GB", "zh-CHS", "zh-CHT" };
            foreach (var s in culs)
            {
                CultureInfo cultureInfo = new CultureInfo(s);
                CultureInfoViewModel.Add(cultureInfo);
            }
            this.ctrlLanguageComboBox.ItemsSource = CultureInfoViewModel;
            //foreach(Window w in Application.Current.Windows)
            //{
            //    w.;
            //}
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
    }
}
