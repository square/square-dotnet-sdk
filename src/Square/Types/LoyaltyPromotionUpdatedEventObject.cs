using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the loyalty promotion associated with a `loyalty.promotion.updated` event.
/// </summary>
public record LoyaltyPromotionUpdatedEventObject
{
    /// <summary>
    /// The loyalty promotion that was updated.
    /// </summary>
    [JsonPropertyName("loyalty_promotion")]
    public LoyaltyPromotion? LoyaltyPromotion { get; set; }

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
