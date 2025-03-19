using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Provides metadata when the event `type` is `ACCUMULATE_POINTS`.
/// </summary>
public record LoyaltyEventAccumulatePoints
{
    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public string? LoyaltyProgramId { get; set; }

    /// <summary>
    /// The number of points accumulated by the event.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) for which the buyer accumulated the points.
    /// This field is returned only if the Orders API is used to process orders.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
