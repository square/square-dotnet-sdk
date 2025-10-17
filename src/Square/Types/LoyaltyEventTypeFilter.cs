using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter events by event type.
/// </summary>
[Serializable]
public record LoyaltyEventTypeFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The loyalty event types used to filter the result.
    /// If multiple values are specified, the endpoint uses a
    /// logical OR to combine them.
    /// See [LoyaltyEventType](#type-loyaltyeventtype) for possible values
    /// </summary>
    [JsonPropertyName("types")]
    public IEnumerable<LoyaltyEventType> Types { get; set; } = new List<LoyaltyEventType>();

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
