using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<FulfillmentFulfillmentLineItemApplication>))]
public readonly record struct FulfillmentFulfillmentLineItemApplication : IStringEnum
{
    public static readonly FulfillmentFulfillmentLineItemApplication All = new(Values.All);

    public static readonly FulfillmentFulfillmentLineItemApplication EntryList = new(
        Values.EntryList
    );

    public FulfillmentFulfillmentLineItemApplication(string value)
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
    public static FulfillmentFulfillmentLineItemApplication FromCustom(string value)
    {
        return new FulfillmentFulfillmentLineItemApplication(value);
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

    public static bool operator ==(
        FulfillmentFulfillmentLineItemApplication value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FulfillmentFulfillmentLineItemApplication value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FulfillmentFulfillmentLineItemApplication value) =>
        value.Value;

    public static explicit operator FulfillmentFulfillmentLineItemApplication(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string All = "ALL";

        public const string EntryList = "ENTRY_LIST";
    }
}
