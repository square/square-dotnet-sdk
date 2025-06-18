using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about fulfillment updates.
/// </summary>
public record OrderFulfillmentUpdatedUpdate
{
    /// <summary>
    /// A unique ID that identifies the fulfillment only within this order.
    /// </summary>
    [JsonPropertyName("fulfillment_uid")]
    public string? FulfillmentUid { get; set; }

    /// <summary>
    /// The state of the fulfillment before the change.
    /// The state is not populated if the fulfillment is created with this new `Order` version.
    /// </summary>
    [JsonPropertyName("old_state")]
    public FulfillmentState? OldState { get; set; }

    /// <summary>
    /// The state of the fulfillment after the change. The state might be equal to `old_state` if a non-state
    /// field was changed on the fulfillment (such as the tracking number).
    /// </summary>
    [JsonPropertyName("new_state")]
    public FulfillmentState? NewState { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
