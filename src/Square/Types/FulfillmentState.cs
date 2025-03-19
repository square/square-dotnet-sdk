using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<FulfillmentState>))]
public readonly record struct FulfillmentState : IStringEnum
{
    public static readonly FulfillmentState Proposed = new(Values.Proposed);

    public static readonly FulfillmentState Reserved = new(Values.Reserved);

    public static readonly FulfillmentState Prepared = new(Values.Prepared);

    public static readonly FulfillmentState Completed = new(Values.Completed);

    public static readonly FulfillmentState Canceled = new(Values.Canceled);

    public static readonly FulfillmentState Failed = new(Values.Failed);

    public FulfillmentState(string value)
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
    public static FulfillmentState FromCustom(string value)
    {
        return new FulfillmentState(value);
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

    public static bool operator ==(FulfillmentState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FulfillmentState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FulfillmentState value) => value.Value;

    public static explicit operator FulfillmentState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Proposed = "PROPOSED";

        public const string Reserved = "RESERVED";

        public const string Prepared = "PREPARED";

        public const string Completed = "COMPLETED";

        public const string Canceled = "CANCELED";

        public const string Failed = "FAILED";
    }
}
