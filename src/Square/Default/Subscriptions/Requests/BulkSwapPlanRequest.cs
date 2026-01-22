using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BulkSwapPlanRequest
{
    /// <summary>
    /// The ID of the new subscription plan variation.
    ///
    /// This field is required.
    /// </summary>
    [JsonPropertyName("new_plan_variation_id")]
    public required string NewPlanVariationId { get; set; }

    /// <summary>
    /// The ID of the plan variation whose subscriptions should be swapped. Active subscriptions
    /// using this plan variation will be subscribed to the new plan variation on their next billing
    /// day.
    /// </summary>
    [JsonPropertyName("old_plan_variation_id")]
    public required string OldPlanVariationId { get; set; }

    /// <summary>
    /// The ID of the location to associate with the swapped subscriptions.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
