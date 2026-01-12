using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<V1TenderEntryMethod>))]
[Serializable]
public readonly record struct V1TenderEntryMethod : IStringEnum
{
    public static readonly V1TenderEntryMethod Manual = new(Values.Manual);

    public static readonly V1TenderEntryMethod Scanned = new(Values.Scanned);

    public static readonly V1TenderEntryMethod SquareCash = new(Values.SquareCash);

    public static readonly V1TenderEntryMethod SquareWallet = new(Values.SquareWallet);

    public static readonly V1TenderEntryMethod Swiped = new(Values.Swiped);

    public static readonly V1TenderEntryMethod WebForm = new(Values.WebForm);

    public static readonly V1TenderEntryMethod Other = new(Values.Other);

    public V1TenderEntryMethod(string value)
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
    public static V1TenderEntryMethod FromCustom(string value)
    {
        return new V1TenderEntryMethod(value);
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

    public static bool operator ==(V1TenderEntryMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(V1TenderEntryMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(V1TenderEntryMethod value) => value.Value;

    public static explicit operator V1TenderEntryMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Manual = "MANUAL";

        public const string Scanned = "SCANNED";

        public const string SquareCash = "SQUARE_CASH";

        public const string SquareWallet = "SQUARE_WALLET";

        public const string Swiped = "SWIPED";

        public const string WebForm = "WEB_FORM";

        public const string Other = "OTHER";
    }
}
