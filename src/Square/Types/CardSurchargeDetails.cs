using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details related to an attempt to apply a card surcharge to this payment.  When surcharge
/// eligibility is not known in advance, such as when the card type (debit or credit) is required
/// to make the eligibility determination, proposed_card_surcharge_money and
/// proposed_additional_amount_money will match the values in the request, while card_surcharge_money
/// and additional_amount_money are present only when the payment has a surcharge applied.
/// </summary>
[Serializable]
public record CardSurchargeDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A specific surcharge levied by the merchant, if a card payment is used, instead of cash or
    /// some other payment type. Should only include the base surcharge amount. Any additional fees related
    /// to the surcharge (e.g. taxes on the surcharge) should only be included in the additional_amount_money.
    /// This amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents). For more information, see
    /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    /// The currency code must match the currency associated with the business that is accepting the
    /// payment.
    /// </summary>
    [JsonPropertyName("card_surcharge_money")]
    public Money? CardSurchargeMoney { get; set; }

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
