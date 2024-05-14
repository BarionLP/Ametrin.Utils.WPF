using Ametrin.Utils;
using System.Windows.Media;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ametrin.Utils.WPF;

public static class DependencyObjectExtensions {
    public static DependencyObject? GetParent(this DependencyObject child) => VisualTreeHelper.GetParent(child);
    public static T? FindParentOrSelf<T>(this DependencyObject obj) where T : DependencyObject => obj is T typed ? typed : obj.FindParent<T>();
    public static T? FindParent<T>(this DependencyObject obj) where T : DependencyObject {
        return VisualTreeHelper.GetParent(obj) switch {
            null => null,
            T typed => typed,
            var parent => parent.FindParent<T>(),
        };
    }


    public static DependencyObject? GetChild(this DependencyObject child, int index) => VisualTreeHelper.GetChild(child, index);
    public static T? FindChildOrSelf<T>(this DependencyObject obj) where T : DependencyObject => obj is T typed ? typed : obj.FindChild<T>();
    public static T? FindChild<T>(this DependencyObject obj) where T : DependencyObject {
        var children = obj.EnumerateChildren();
        return children.OfType<T>().FirstOrDefault() ?? children.Select(FindChild<T>).FirstOrDefault(c => c is not null);
    }
    public static IEnumerable<DependencyObject> EnumerateChildren(this DependencyObject obj) {
        foreach(var index in ..VisualTreeHelper.GetChildrenCount(obj)) {
            if(obj.GetChild(index) is DependencyObject child) {
                yield return child;
            }
        }
    }

    [Obsolete] // use find parent or self
    public static T FindAncestorOrSelf<T>(this DependencyObject obj) where T : DependencyObject {
        while(obj is not null) {
            if(obj is T objTyped)
                return objTyped;
            obj = VisualTreeHelper.GetParent(obj);
        }
        return null!;
    }
}
