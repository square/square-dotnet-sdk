using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Subscriptions;

[Serializable]
public record SwapPlanRequest
{
    /// <summary>
    /// The ID of the subscription to swap the subscription plan for.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The ID of the new subscription plan variation.
    ///
    /// This field is required.
    /// </summary>
    [JsonPropertyName("new_plan_variation_id")]
    public string? NewPlanVariationId { get; set; }

    /// <summary>
    /// A list of PhaseInputs, to pass phase-specific information used in the swap.
    /// </summary>
    [JsonPropertyName("phases")]
    public IEnumerable<PhaseInput>? Phases { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
