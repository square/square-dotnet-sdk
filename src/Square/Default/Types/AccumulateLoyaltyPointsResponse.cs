using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an [AccumulateLoyaltyPoints](api-endpoint:Loyalty-AccumulateLoyaltyPoints) response.
/// </summary>
[Serializable]
public record AccumulateLoyaltyPointsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The resulting loyalty event. Starting in Square version 2022-08-17, this field is no longer returned.
    /// </summary>
    [JsonPropertyName("event")]
    public LoyaltyEvent? Event { get; set; }

    /// <summary>
    /// The resulting loyalty events. If the purchase qualifies for points, the `ACCUMULATE_POINTS` event
    /// is always included. When using the Orders API, the `ACCUMULATE_PROMOTION_POINTS` event is included
    /// if the purchase also qualifies for a loyalty promotion.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<LoyaltyEvent>? Events { get; set; }

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
