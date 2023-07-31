using System;
using System.Windows.Markup;

namespace Ametrin.Utils.WPF;

public sealed class EnumBindingSourceExtension : MarkupExtension {
    public Type EnumType { get; }

    public EnumBindingSourceExtension(Type enumType) {
        EnumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
        if(!EnumType.IsEnum) throw new ArgumentException("Type must be for an Enum.");

        return Enum.GetValues(EnumType);
    }
}