using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;//necessary

namespace System.Windows
{
    public class ResourceKeyProvider : UIElement// DependencyObject
    {
        public static string GetTextKey(DependencyObject obj)
        {
            return (string)obj.GetValue(TextKeyProperty);
        }

        public static void SetTextKey(DependencyObject obj, string value)
        {
            obj.SetValue(TextKeyProperty, value);
        }

        public static readonly DependencyProperty TextKeyProperty =
            DependencyProperty.RegisterAttached("TextKey", typeof(string), typeof(ResourceKeyProvider), new PropertyMetadata(string.Empty, OnTextKeyChanged));

        public static string GetToolTipKey(DependencyObject obj)
        {
            return (string)obj.GetValue(ToolTipKeyProperty);
        }
        public static void SetToolTipKey(DependencyObject obj, string value)
        {
            obj.SetValue(ToolTipKeyProperty, value);
        }

        public static readonly DependencyProperty ToolTipKeyProperty =
            DependencyProperty.RegisterAttached("ToolTipKey", typeof(string), typeof(ResourceKeyProvider), new PropertyMetadata(string.Empty, OnToolTipKeyChanged));

        private static void OnTextKeyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            //var element = obj as UIElement;
            //if (element != null)
            //{
            //    element.RenderTransformOrigin = new Point(0.5, 0.5);
            //    element.RenderTransform = new RotateTransform((double)e.NewValue);
            //}
        }
        private static void OnToolTipKeyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            //var element = obj as UIElement;
            //if (element != null)
            //{
            //    element.RenderTransformOrigin = new Point(0.5, 0.5);
            //    element.RenderTransform = new RotateTransform((double)e.NewValue);
            //}
        }

    }
}