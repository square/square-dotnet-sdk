using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the details of a tender with `type` `BUY_NOW_PAY_LATER`.
/// </summary>
[Serializable]
public record TenderBuyNowPayLaterDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Buy Now Pay Later brand.
    /// See [Brand](#type-brand) for possible values
    /// </summary>
    [JsonPropertyName("buy_now_pay_later_brand")]
    public TenderBuyNowPayLaterDetailsBrand? BuyNowPayLaterBrand { get; set; }

    /// <summary>
    /// The buy now pay later payment's current state (such as `AUTHORIZED` or
    /// `CAPTURED`). See [TenderBuyNowPayLaterDetailsStatus](entity:TenderBuyNowPayLaterDetailsStatus)
    /// for possible values.
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TenderBuyNowPayLaterDetailsStatus? Status { get; set; }

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
