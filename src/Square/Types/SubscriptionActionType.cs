using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionActionType>))]
[Serializable]
public readonly record struct SubscriptionActionType : IStringEnum
{
    public static readonly SubscriptionActionType Cancel = new(Values.Cancel);

    public static readonly SubscriptionActionType Pause = new(Values.Pause);

    public static readonly SubscriptionActionType Resume = new(Values.Resume);

    public static readonly SubscriptionActionType SwapPlan = new(Values.SwapPlan);

    public static readonly SubscriptionActionType ChangeBillingAnchorDate = new(
        Values.ChangeBillingAnchorDate
    );

    public static readonly SubscriptionActionType Complete = new(Values.Complete);

    public SubscriptionActionType(string value)
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
    public static SubscriptionActionType FromCustom(string value)
    {
        return new SubscriptionActionType(value);
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

    public static bool operator ==(SubscriptionActionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionActionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionActionType value) => value.Value;

    public static explicit operator SubscriptionActionType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Cancel = "CANCEL";

        public const string Pause = "PAUSE";

        public const string Resume = "RESUME";

        public const string SwapPlan = "SWAP_PLAN";

        public const string ChangeBillingAnchorDate = "CHANGE_BILLING_ANCHOR_DATE";

        public const string Complete = "COMPLETE";
    }
}
