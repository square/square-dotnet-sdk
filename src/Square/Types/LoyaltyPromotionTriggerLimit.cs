using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the number of times a buyer can earn points during a [loyalty promotion](entity:LoyaltyPromotion).
/// If this field is not set, buyers can trigger the promotion an unlimited number of times to earn points during
/// the time that the promotion is available.
///
/// A purchase that is disqualified from earning points because of this limit might qualify for another active promotion.
/// </summary>
public record LoyaltyPromotionTriggerLimit
{
    /// <summary>
    /// The maximum number of times a buyer can trigger the promotion during the specified `interval`.
    /// </summary>
    [JsonPropertyName("times")]
    public required int Times { get; set; }

    /// <summary>
    /// The time period the limit applies to.
    /// See [LoyaltyPromotionTriggerLimitInterval](#type-loyaltypromotiontriggerlimitinterval) for possible values
    /// </summary>
    [JsonPropertyName("interval")]
    public LoyaltyPromotionTriggerLimitInterval? Interval { get; set; }

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
