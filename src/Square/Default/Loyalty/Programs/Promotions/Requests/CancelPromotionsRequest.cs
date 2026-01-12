using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Loyalty.Programs.Promotions;

[Serializable]
public record CancelPromotionsRequest
{
    /// <summary>
    /// The ID of the base [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonIgnore]
    public required string ProgramId { get; set; }

    /// <summary>
    /// The ID of the [loyalty promotion](entity:LoyaltyPromotion) to cancel. You can cancel a
    /// promotion that has an `ACTIVE` or `SCHEDULED` status.
    /// </summary>
    [JsonIgnore]
    public required string PromotionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
