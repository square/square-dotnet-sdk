using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Loyalty.Programs.Promotions;

[Serializable]
public record GetPromotionsRequest
{
    /// <summary>
    /// The ID of the base [loyalty program](entity:LoyaltyProgram). To get the program ID,
    /// call [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) using the `main` keyword.
    /// </summary>
    [JsonIgnore]
    public required string ProgramId { get; set; }

    /// <summary>
    /// The ID of the [loyalty promotion](entity:LoyaltyPromotion) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string PromotionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
