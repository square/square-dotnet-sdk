using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents additional data for rules with the `VISIT` accrual type.
/// </summary>
[Serializable]
public record LoyaltyProgramAccrualRuleVisitData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
