using System.Windows;

namespace Ametrin.Utils.WPF;

public static class MessageBoxHelper {
    public static MessageBoxResult ShowError(string error, string caption = "Error") 
        => MessageBox.Show(error, caption, MessageBoxButton.OK, MessageBoxImage.Error);
    
    public static MessageBoxResult ShowSuccess(string error, string caption = "Success", Window? owner = null) 
        => owner is null 
            ? MessageBox.Show(error, caption, MessageBoxButton.OK, MessageBoxImage.Information) 
            : MessageBox.Show(owner, error, caption, MessageBoxButton.OK, MessageBoxImage.Information);
}
