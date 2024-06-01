namespace Ametrin.Utils.WPF.FileDialogs;

public sealed record FileFilter(NonEmptyString Description, NonEmptyString Pattern) {
    public static FileFilter AllFiles { get; } = new("All Files", "*.*");
    public override string ToString() => $"{Description} ({Pattern})|{Pattern}";

    public static FileFilter Create(NonEmptyString description, NonEmptyString pattern) => new(description, pattern);
    public static FileFilter CreateFromExtension(NonEmptyString description, NonEmptyString extension) => Create(description, extension.StartsWith('.') ? $"*{extension}" : $"*.{extension}");
}
