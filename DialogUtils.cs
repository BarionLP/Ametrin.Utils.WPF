using Microsoft.Win32;

namespace Ametrin.Utils.WPF; 
public static class DialogUtils {
    public static OpenFileDialog GetFileDialog(string title = "Select File", string filterDescription = "All files", string extension = "*", string path = "", bool multiSelect = false) {
        return new OpenFileDialog {
            Title = title,
            InitialDirectory = path,
            DefaultExt = extension,
            Filter = $"{filterDescription} (*.{extension})|*.{extension}",
            Multiselect = multiSelect,
            CheckPathExists = true,
            RestoreDirectory = false,
        };
    }
}
