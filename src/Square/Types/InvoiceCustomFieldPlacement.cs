using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InvoiceCustomFieldPlacement>))]
[Serializable]
public readonly record struct InvoiceCustomFieldPlacement : IStringEnum
{
    public static readonly InvoiceCustomFieldPlacement AboveLineItems = new(Values.AboveLineItems);

    public static readonly InvoiceCustomFieldPlacement BelowLineItems = new(Values.BelowLineItems);

    public InvoiceCustomFieldPlacement(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static InvoiceCustomFieldPlacement FromCustom(string value)
    {
        return new InvoiceCustomFieldPlacement(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(InvoiceCustomFieldPlacement value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InvoiceCustomFieldPlacement value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InvoiceCustomFieldPlacement value) => value.Value;

    public static explicit operator InvoiceCustomFieldPlacement(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AboveLineItems = "ABOVE_LINE_ITEMS";

        public const string BelowLineItems = "BELOW_LINE_ITEMS";
    }
}
