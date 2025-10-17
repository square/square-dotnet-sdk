using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A collection of various money amounts.
/// </summary>
[Serializable]
public record OrderMoneyAmounts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The total money.
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// The money associated with taxes.
    /// </summary>
    [JsonPropertyName("tax_money")]
    public Money? TaxMoney { get; set; }

    /// <summary>
    /// The money associated with discounts.
    /// </summary>
    [JsonPropertyName("discount_money")]
    public Money? DiscountMoney { get; set; }

    /// <summary>
    /// The money associated with tips.
    /// </summary>
    [JsonPropertyName("tip_money")]
    public Money? TipMoney { get; set; }

    /// <summary>
    /// The money associated with service charges.
    /// </summary>
    [JsonPropertyName("service_charge_money")]
    public Money? ServiceChargeMoney { get; set; }

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
