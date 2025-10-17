using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<RefundStatus>))]
[Serializable]
public readonly record struct RefundStatus : IStringEnum
{
    public static readonly RefundStatus Pending = new(Values.Pending);

    public static readonly RefundStatus Approved = new(Values.Approved);

    public static readonly RefundStatus Rejected = new(Values.Rejected);

    public static readonly RefundStatus Failed = new(Values.Failed);

    public RefundStatus(string value)
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
    public static RefundStatus FromCustom(string value)
    {
        return new RefundStatus(value);
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

    public static bool operator ==(RefundStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RefundStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RefundStatus value) => value.Value;

    public static explicit operator RefundStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Approved = "APPROVED";

        public const string Rejected = "REJECTED";

        public const string Failed = "FAILED";
    }
}
