using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Stores details about an external payment. Contains only non-confidential information.
/// For more information, see
/// [Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments).
/// </summary>
[Serializable]
public record ExternalPaymentDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of external payment the seller received. It can be one of the following:
    /// - CHECK - Paid using a physical check.
    /// - BANK_TRANSFER - Paid using external bank transfer.
    /// - OTHER\_GIFT\_CARD - Paid using a non-Square gift card.
    /// - CRYPTO - Paid using a crypto currency.
    /// - SQUARE_CASH - Paid using Square Cash App.
    /// - SOCIAL - Paid using peer-to-peer payment applications.
    /// - EXTERNAL - A third-party application gathered this payment outside of Square.
    /// - EMONEY - Paid using an E-money provider.
    /// - CARD - A credit or debit card that Square does not support.
    /// - STORED_BALANCE - Use for house accounts, store credit, and so forth.
    /// - FOOD_VOUCHER - Restaurant voucher provided by employers to employees to pay for meals
    /// - OTHER - A type not listed here.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// A description of the external payment source. For example,
    /// "Food Delivery Service".
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <summary>
    /// An ID to associate the payment to its originating source.
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

    /// <summary>
    /// The fees paid to the source. The `amount_money` minus this field is
    /// the net amount seller receives.
    /// </summary>
    [JsonPropertyName("source_fee_money")]
    public Money? SourceFeeMoney { get; set; }

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
