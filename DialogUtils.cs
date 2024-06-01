using Ametrin.Utils.WPF.FileDialogs;
using System;

namespace Ametrin.Utils.WPF;
public static class DialogUtils {
    
    [Obsolete]
    public static OpenFileDialog GetFileDialog(string title = "Select File", string filterDescription = "All files", string extension = "*", string path = "", bool multiSelect = false) {
        return new OpenFileDialog {
            Title = title,
            InitialDirectory = path,
            Multiselect = multiSelect,
            CheckPathExists = true,
            RestoreDirectory = false,
        }.AddExtensionFilter(filterDescription, extension);
    }

    [Obsolete]
    public static SaveFileDialog SaveFileDialog(string title = "Save File", string filterDescription = "All Files", string extension = "*", string path = "") {
        return new SaveFileDialog {
            Title = title,
            InitialDirectory = path,
            DefaultExtension = extension,
            RestoreDirectory = false,
        }.AddExtensionFilter(filterDescription, extension);
    }

}