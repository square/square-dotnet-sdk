using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CalculateLoyaltyPoints](api-endpoint:Loyalty-CalculateLoyaltyPoints) response.
/// </summary>
public record CalculateLoyaltyPointsResponse
{
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
