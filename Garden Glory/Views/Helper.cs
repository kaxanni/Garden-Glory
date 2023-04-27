using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Garden_Glory.Views
{
    class Helper
    {
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static void clearAll(DependencyObject depObj)
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(depObj))
            {
                tb.Text = string.Empty;
            }

            foreach (ComboBox tb in FindVisualChildren<ComboBox>(depObj))
            {
                tb.Text = string.Empty;
            }
        }
    }
}
