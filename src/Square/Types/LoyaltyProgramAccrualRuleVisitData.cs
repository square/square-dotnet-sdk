using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents additional data for rules with the `VISIT` accrual type.
/// </summary>
public record LoyaltyProgramAccrualRuleVisitData
{
    /// <summary>
    /// The minimum purchase required during the visit to quality for points.
    /// </summary>
    [JsonPropertyName("minimum_amount_money")]
    public Money? MinimumAmountMoney { get; set; }

    /// <summary>
    /// Indicates how taxes should be treated when calculating the purchase amount to determine whether the visit qualifies for points.
    /// This setting applies only if `minimum_amount_money` is specified.
    /// See [LoyaltyProgramAccrualRuleTaxMode](#type-loyaltyprogramaccrualruletaxmode) for possible values
    /// </summary>
    [JsonPropertyName("tax_mode")]
    public required LoyaltyProgramAccrualRuleTaxMode TaxMode { get; set; }

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
