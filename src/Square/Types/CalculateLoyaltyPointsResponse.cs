using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CalculateLoyaltyPoints](api-endpoint:Loyalty-CalculateLoyaltyPoints) response.
/// </summary>
[Serializable]
public record CalculateLoyaltyPointsResponse : IJsonOnDeserialized
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
    /// The number of points that the buyer can earn from the base loyalty program.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// The number of points that the buyer can earn from a loyalty promotion. To be eligible
    /// to earn promotion points, the purchase must first qualify for program points. When `order_id`
    /// is not provided in the request, this value is always 0.
    /// </summary>
    [JsonPropertyName("promotion_points")]
    public int? PromotionPoints { get; set; }

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
