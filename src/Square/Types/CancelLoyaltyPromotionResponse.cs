using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CancelLoyaltyPromotion](api-endpoint:Loyalty-CancelLoyaltyPromotion) response.
/// Either `loyalty_promotion` or `errors` is present in the response.
/// </summary>
public record CancelLoyaltyPromotionResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The canceled loyalty promotion.
    /// </summary>
    [JsonPropertyName("loyalty_promotion")]
    public LoyaltyPromotion? LoyaltyPromotion { get; set; }

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
