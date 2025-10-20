using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<LocationCapability>))]
[Serializable]
public readonly record struct LocationCapability : IStringEnum
{
    public static readonly LocationCapability CreditCardProcessing = new(
        Values.CreditCardProcessing
    );

    public static readonly LocationCapability AutomaticTransfers = new(Values.AutomaticTransfers);

    public static readonly LocationCapability UnlinkedRefunds = new(Values.UnlinkedRefunds);

    public LocationCapability(string value)
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
    public static LocationCapability FromCustom(string value)
    {
        return new LocationCapability(value);
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

    public static bool operator ==(LocationCapability value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LocationCapability value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LocationCapability value) => value.Value;

    public static explicit operator LocationCapability(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CreditCardProcessing = "CREDIT_CARD_PROCESSING";

        public const string AutomaticTransfers = "AUTOMATIC_TRANSFERS";

        public const string UnlinkedRefunds = "UNLINKED_REFUNDS";
    }
}
