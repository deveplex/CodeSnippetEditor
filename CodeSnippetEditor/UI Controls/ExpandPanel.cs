using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    class ExpandPanel : Panel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ExpandPanel() : base()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            BackColor = Drawing.Color.Black;
            Height = 1;
        }

        [Browsable(false)]
        public Orientation Orientation { get; set; }
    }
}
