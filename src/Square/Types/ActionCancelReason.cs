using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ActionCancelReason>))]
[Serializable]
public readonly record struct ActionCancelReason : IStringEnum
{
    public static readonly ActionCancelReason BuyerCanceled = new(Values.BuyerCanceled);

    public static readonly ActionCancelReason SellerCanceled = new(Values.SellerCanceled);

    public static readonly ActionCancelReason TimedOut = new(Values.TimedOut);

    public ActionCancelReason(string value)
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
    public static ActionCancelReason FromCustom(string value)
    {
        return new ActionCancelReason(value);
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

    public static bool operator ==(ActionCancelReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionCancelReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionCancelReason value) => value.Value;

    public static explicit operator ActionCancelReason(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BuyerCanceled = "BUYER_CANCELED";

        public const string SellerCanceled = "SELLER_CANCELED";

        public const string TimedOut = "TIMED_OUT";
    }
}
