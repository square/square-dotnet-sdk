using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Subscriptions;

public record PauseSubscriptionRequest
{
    /// <summary>
    /// The ID of the subscription to pause.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date when the scheduled `PAUSE` action takes place on the subscription.
    ///
    /// When this date is unspecified or falls within the current billing cycle, the subscription is paused
    /// on the starting date of the next billing cycle.
    /// </summary>
    [JsonPropertyName("pause_effective_date")]
    public string? PauseEffectiveDate { get; set; }

    /// <summary>
    /// The number of billing cycles the subscription will be paused before it is reactivated.
    ///
    /// When this is set, a `RESUME` action is also scheduled to take place on the subscription at
    /// the end of the specified pause cycle duration. In this case, neither `resume_effective_date`
    /// nor `resume_change_timing` may be specified.
    /// </summary>
    [JsonPropertyName("pause_cycle_duration")]
    public long? PauseCycleDuration { get; set; }

    /// <summary>
    /// The date when the subscription is reactivated by a scheduled `RESUME` action.
    /// This date must be at least one billing cycle ahead of `pause_effective_date`.
    /// </summary>
    [JsonPropertyName("resume_effective_date")]
    public string? ResumeEffectiveDate { get; set; }

    /// <summary>
    /// The timing whether the subscription is reactivated immediately or at the end of the billing cycle, relative to
    /// `resume_effective_date`.
    /// See [ChangeTiming](#type-changetiming) for possible values
    /// </summary>
    [JsonPropertyName("resume_change_timing")]
    public ChangeTiming? ResumeChangeTiming { get; set; }

    /// <summary>
    /// The user-provided reason to pause the subscription.
    /// </summary>
    [JsonPropertyName("pause_reason")]
    public string? PauseReason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
