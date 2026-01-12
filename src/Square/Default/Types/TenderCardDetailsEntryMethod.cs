using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<TenderCardDetailsEntryMethod>))]
[Serializable]
public readonly record struct TenderCardDetailsEntryMethod : IStringEnum
{
    public static readonly TenderCardDetailsEntryMethod Swiped = new(Values.Swiped);

    public static readonly TenderCardDetailsEntryMethod Keyed = new(Values.Keyed);

    public static readonly TenderCardDetailsEntryMethod Emv = new(Values.Emv);

    public static readonly TenderCardDetailsEntryMethod OnFile = new(Values.OnFile);

    public static readonly TenderCardDetailsEntryMethod Contactless = new(Values.Contactless);

    public TenderCardDetailsEntryMethod(string value)
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
    public static TenderCardDetailsEntryMethod FromCustom(string value)
    {
        return new TenderCardDetailsEntryMethod(value);
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

    public static bool operator ==(TenderCardDetailsEntryMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenderCardDetailsEntryMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenderCardDetailsEntryMethod value) => value.Value;

    public static explicit operator TenderCardDetailsEntryMethod(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Swiped = "SWIPED";

        public const string Keyed = "KEYED";

        public const string Emv = "EMV";

        public const string OnFile = "ON_FILE";

        public const string Contactless = "CONTACTLESS";
    }
}
