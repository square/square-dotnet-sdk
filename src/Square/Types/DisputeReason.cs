using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DisputeReason>))]
public readonly record struct DisputeReason : IStringEnum
{
    public static readonly DisputeReason AmountDiffers = new(Values.AmountDiffers);

    public static readonly DisputeReason Cancelled = new(Values.Cancelled);

    public static readonly DisputeReason Duplicate = new(Values.Duplicate);

    public static readonly DisputeReason NoKnowledge = new(Values.NoKnowledge);

    public static readonly DisputeReason NotAsDescribed = new(Values.NotAsDescribed);

    public static readonly DisputeReason NotReceived = new(Values.NotReceived);

    public static readonly DisputeReason PaidByOtherMeans = new(Values.PaidByOtherMeans);

    public static readonly DisputeReason CustomerRequestsCredit = new(
        Values.CustomerRequestsCredit
    );

    public static readonly DisputeReason EmvLiabilityShift = new(Values.EmvLiabilityShift);

    public DisputeReason(string value)
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
    public static DisputeReason FromCustom(string value)
    {
        return new DisputeReason(value);
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

    public static bool operator ==(DisputeReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DisputeReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DisputeReason value) => value.Value;

    public static explicit operator DisputeReason(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string AmountDiffers = "AMOUNT_DIFFERS";

        public const string Cancelled = "CANCELLED";

        public const string Duplicate = "DUPLICATE";

        public const string NoKnowledge = "NO_KNOWLEDGE";

        public const string NotAsDescribed = "NOT_AS_DESCRIBED";

        public const string NotReceived = "NOT_RECEIVED";

        public const string PaidByOtherMeans = "PAID_BY_OTHER_MEANS";

        public const string CustomerRequestsCredit = "CUSTOMER_REQUESTS_CREDIT";

        public const string EmvLiabilityShift = "EMV_LIABILITY_SHIFT";
    }
}
