using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DestinationType>))]
public readonly record struct DestinationType : IStringEnum
{
    public static readonly DestinationType BankAccount = new(Values.BankAccount);

    public static readonly DestinationType Card = new(Values.Card);

    public static readonly DestinationType SquareBalance = new(Values.SquareBalance);

    public static readonly DestinationType SquareStoredBalance = new(Values.SquareStoredBalance);

    public DestinationType(string value)
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
    public static DestinationType FromCustom(string value)
    {
        return new DestinationType(value);
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

    public static bool operator ==(DestinationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DestinationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DestinationType value) => value.Value;

    public static explicit operator DestinationType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string BankAccount = "BANK_ACCOUNT";

        public const string Card = "CARD";

        public const string SquareBalance = "SQUARE_BALANCE";

        public const string SquareStoredBalance = "SQUARE_STORED_BALANCE";
    }
}
