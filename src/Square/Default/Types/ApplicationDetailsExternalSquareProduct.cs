using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<ApplicationDetailsExternalSquareProduct>))]
[Serializable]
public readonly record struct ApplicationDetailsExternalSquareProduct : IStringEnum
{
    public static readonly ApplicationDetailsExternalSquareProduct Appointments = new(
        Values.Appointments
    );

    public static readonly ApplicationDetailsExternalSquareProduct EcommerceApi = new(
        Values.EcommerceApi
    );

    public static readonly ApplicationDetailsExternalSquareProduct Invoices = new(Values.Invoices);

    public static readonly ApplicationDetailsExternalSquareProduct OnlineStore = new(
        Values.OnlineStore
    );

    public static readonly ApplicationDetailsExternalSquareProduct Other = new(Values.Other);

    public static readonly ApplicationDetailsExternalSquareProduct Restaurants = new(
        Values.Restaurants
    );

    public static readonly ApplicationDetailsExternalSquareProduct Retail = new(Values.Retail);

    public static readonly ApplicationDetailsExternalSquareProduct SquarePos = new(
        Values.SquarePos
    );

    public static readonly ApplicationDetailsExternalSquareProduct TerminalApi = new(
        Values.TerminalApi
    );

    public static readonly ApplicationDetailsExternalSquareProduct VirtualTerminal = new(
        Values.VirtualTerminal
    );

    public ApplicationDetailsExternalSquareProduct(string value)
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
    public static ApplicationDetailsExternalSquareProduct FromCustom(string value)
    {
        return new ApplicationDetailsExternalSquareProduct(value);
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

    public static bool operator ==(ApplicationDetailsExternalSquareProduct value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ApplicationDetailsExternalSquareProduct value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ApplicationDetailsExternalSquareProduct value) =>
        value.Value;

    public static explicit operator ApplicationDetailsExternalSquareProduct(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Appointments = "APPOINTMENTS";

        public const string EcommerceApi = "ECOMMERCE_API";

        public const string Invoices = "INVOICES";

        public const string OnlineStore = "ONLINE_STORE";

        public const string Other = "OTHER";

        public const string Restaurants = "RESTAURANTS";

        public const string Retail = "RETAIL";

        public const string SquarePos = "SQUARE_POS";

        public const string TerminalApi = "TERMINAL_API";

        public const string VirtualTerminal = "VIRTUAL_TERMINAL";
    }
}
