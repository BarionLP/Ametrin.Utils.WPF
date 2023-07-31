using System.Windows.Media;
using System.Windows;

namespace Ametrin.Utils.WPF;

public static class DependencyObjectExtensions {
    public static DependencyObject? FindParent(this DependencyObject child) {
        return VisualTreeHelper.GetParent(child);
    }

    public static T? FindParent<T>(this DependencyObject child) where T : DependencyObject {
        var parent = VisualTreeHelper.GetParent(child);

        if(parent is null) return null;

        if(parent is T) return parent as T;

        return FindParent<T>(parent);
    }

    public static T? FindChild<T>(this DependencyObject parent) where T : DependencyObject {
        for(var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++) {
            var child = VisualTreeHelper.GetChild(parent, i);
            if(child is T t) {
                return t;
            }
        }

        for(var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++) {
            var child = VisualTreeHelper.GetChild(parent, i);
            var childOfChild = child.FindChild<T>();
            if(childOfChild is not null) {
                return childOfChild;
            }
        }

        return null;
    }
}
