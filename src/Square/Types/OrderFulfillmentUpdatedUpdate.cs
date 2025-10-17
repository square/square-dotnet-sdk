using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about fulfillment updates.
/// </summary>
[Serializable]
public record OrderFulfillmentUpdatedUpdate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
