using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    //[ProvideProperty("ResourceKey", typeof(ToolStripItem))]
    [ProvideProperty("ResourceKey", typeof(Component))]
    public class ResourceKeyProvider : Component, IExtenderProvider//, INotifyPropertyChanged
    {
        private IDictionary<Component, string> _ResourceKeys = null;

       // public event PropertyChangedEventHandler PropertyChanged;

        public ResourceKeyProvider()
        {
            _ResourceKeys = new Dictionary<Component, string>();
        }

        public ResourceKeyProvider(IContainer container)
        {
            container.Add(this);
            _ResourceKeys = new Dictionary<Component, string>();
        }

        [DefaultValue(null), Description("Resources Key")]
        public string GetResourceKey(Component control)
        {
            if (_ResourceKeys.ContainsKey(control))
                return _ResourceKeys[control]?? string.Empty;
            else
                return string.Empty;
        }

        public void SetResourceKey(Component control, string value)
        {
            if (value == null)
                value = string.Empty;

            if (value.Length <= 0)
                _ResourceKeys.Remove(control);
            else
                _ResourceKeys.Add(control, value);

            //OnPropertyChanged("ResourceKey");
        }

        public bool CanExtend(object extendee)
        {
            if (extendee is Component && !(extendee is ResourceKeyProvider))
                return true;
            else
                return false;
        }

        //protected void OnPropertyChanged(string name)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(name));
        //    }
        //}
    }
}

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute
    {

    }
}