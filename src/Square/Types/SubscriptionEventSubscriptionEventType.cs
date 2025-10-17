using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionEventSubscriptionEventType>))]
[Serializable]
public readonly record struct SubscriptionEventSubscriptionEventType : IStringEnum
{
    public static readonly SubscriptionEventSubscriptionEventType StartSubscription = new(
        Values.StartSubscription
    );

    public static readonly SubscriptionEventSubscriptionEventType PlanChange = new(
        Values.PlanChange
    );

    public static readonly SubscriptionEventSubscriptionEventType StopSubscription = new(
        Values.StopSubscription
    );

    public static readonly SubscriptionEventSubscriptionEventType DeactivateSubscription = new(
        Values.DeactivateSubscription
    );

    public static readonly SubscriptionEventSubscriptionEventType ResumeSubscription = new(
        Values.ResumeSubscription
    );

    public static readonly SubscriptionEventSubscriptionEventType PauseSubscription = new(
        Values.PauseSubscription
    );

    public static readonly SubscriptionEventSubscriptionEventType BillingAnchorDateChanged = new(
        Values.BillingAnchorDateChanged
    );

    public SubscriptionEventSubscriptionEventType(string value)
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
    public static SubscriptionEventSubscriptionEventType FromCustom(string value)
    {
        return new SubscriptionEventSubscriptionEventType(value);
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

    public static bool operator ==(SubscriptionEventSubscriptionEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubscriptionEventSubscriptionEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubscriptionEventSubscriptionEventType value) =>
        value.Value;

    public static explicit operator SubscriptionEventSubscriptionEventType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string StartSubscription = "START_SUBSCRIPTION";

        public const string PlanChange = "PLAN_CHANGE";

        public const string StopSubscription = "STOP_SUBSCRIPTION";

        public const string DeactivateSubscription = "DEACTIVATE_SUBSCRIPTION";

        public const string ResumeSubscription = "RESUME_SUBSCRIPTION";

        public const string PauseSubscription = "PAUSE_SUBSCRIPTION";

        public const string BillingAnchorDateChanged = "BILLING_ANCHOR_DATE_CHANGED";
    }
}
