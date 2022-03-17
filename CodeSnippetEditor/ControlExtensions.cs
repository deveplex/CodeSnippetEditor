using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    public static class ControlExtensions
    {
        public static List<Control> GetAllChildren(this Control control)
        {
            var childrens = new List<Control>();
            foreach (Control ctrl in control.Controls)
            {
                childrens.Add(ctrl);
                var c = ctrl.GetAllChildren();
                childrens.AddRange(c);
            }
            return childrens;
        }
        public static List<ToolStripItem> GetAllChildren(this ToolStrip control)
        {
            var childrens = new List<ToolStripItem>();
            foreach (ToolStripItem ctrl in control.Items)
            {
                childrens.Add(ctrl);
                var c = ctrl.GetAllChildren();
                childrens.AddRange(c);
            }
            return childrens;
        }
        public static List<ToolStripItem> GetAllChildren(this ToolStripItem control)
        {
            var childrens = new List<ToolStripItem>();
            if (control is ToolStripDropDownItem)
            {
                foreach (ToolStripItem ctrl in ((ToolStripDropDownItem)control).DropDownItems)
                {
                    childrens.Add(ctrl);
                    var c = ctrl.GetAllChildren();
                    childrens.AddRange(c);
                }
            }
            return childrens;
        }

        public static void RaiseEvent(this Control control, EventHandler handler, EventArgs e)
        {
            RaiseEvent(control, handler, () => e);
        }

        public static void RaiseEvent(this Control control, EventHandler handler, Func<EventArgs> func)
        {
            if (handler != null)
                handler(control, func());
            return;
        }

        public static void RaiseEvent<TEventArgs>(this Control control, EventHandler<TEventArgs> handler, TEventArgs e) where TEventArgs : EventArgs
        {
            RaiseEvent(control, handler, () => e);
        }

        public static void RaiseEvent<TEventArgs>(this Control control, EventHandler<TEventArgs> handler, Func<TEventArgs> func) where TEventArgs : EventArgs
        {
            if (handler != null)
                handler(control, func());
            return;
        }
    }
}
