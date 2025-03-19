using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter events by the order associated with the event.
/// </summary>
public record LoyaltyEventOrderFilter
{
    /// <summary>
    /// The ID of the [order](entity:Order) associated with the event.
    /// </summary>
    [JsonPropertyName("order_id")]
    public required string OrderId { get; set; }

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
