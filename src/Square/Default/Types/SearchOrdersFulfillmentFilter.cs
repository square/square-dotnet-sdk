using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Filter based on [order fulfillment](entity:Fulfillment) information.
/// </summary>
[Serializable]
public record SearchOrdersFulfillmentFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of [fulfillment types](entity:FulfillmentType) to filter
    /// for. The list returns orders if any of its fulfillments match any of the fulfillment types
    /// listed in this field.
    /// See [FulfillmentType](#type-fulfillmenttype) for possible values
    /// </summary>
    [JsonPropertyName("fulfillment_types")]
    public IEnumerable<FulfillmentType>? FulfillmentTypes { get; set; }

    /// <summary>
    /// A list of [fulfillment states](entity:FulfillmentState) to filter
    /// for. The list returns orders if any of its fulfillments match any of the
    /// fulfillment states listed in this field.
    /// See [FulfillmentState](#type-fulfillmentstate) for possible values
    /// </summary>
    [JsonPropertyName("fulfillment_states")]
    public IEnumerable<FulfillmentState>? FulfillmentStates { get; set; }

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
