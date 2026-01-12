using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Subscriptions;

[Serializable]
public record ResumeSubscriptionRequest
{
    /// <summary>
    /// The ID of the subscription to resume.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The `YYYY-MM-DD`-formatted date when the subscription reactivated.
    /// </summary>
    [JsonPropertyName("resume_effective_date")]
    public string? ResumeEffectiveDate { get; set; }

    /// <summary>
    /// The timing to resume a subscription, relative to the specified
    /// `resume_effective_date` attribute value.
    /// See [ChangeTiming](#type-changetiming) for possible values
    /// </summary>
    [JsonPropertyName("resume_change_timing")]
    public ChangeTiming? ResumeChangeTiming { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
