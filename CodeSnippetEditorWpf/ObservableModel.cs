using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeSnippetEditor
{
    public class ObservableModel<T> : DynamicObject, INotifyPropertyChanged
        where T : class, new()
    {
        private T _observableObject = default(T);

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableModel()
        {
            _observableObject = new T();
        }

        public ObservableModel(T model)
        {
            _observableObject = model;
        }

        public T ObservableObject
        {
            get
            {
                return _observableObject;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;
            PropertyInfo[] pis = _observableObject.GetType().GetProperties();
            var pi = pis.FirstOrDefault(p => p.Name == name);
            if (pi == null)
                throw new Exception();
            result = pi.GetValue(_observableObject, null);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var name = binder.Name;
            PropertyInfo[] pis = _observableObject.GetType().GetProperties();
            var pi = pis.FirstOrDefault(p => p.Name == name);
            if (pi == null)
                throw new Exception();
            pi.SetValue(_observableObject, value, null);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            return true;
        }
    }
}
