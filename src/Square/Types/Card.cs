using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the payment details of a card to be used for payments. These
/// details are determined by the payment token generated by Web Payments SDK.
/// </summary>
public record Card
{
    /// <summary>
    /// Unique ID for this card. Generated by Square.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The card's brand.
    /// See [CardBrand](#type-cardbrand) for possible values
    /// </summary>
    [JsonPropertyName("card_brand")]
    public CardBrand? CardBrand { get; set; }

    /// <summary>
    /// The last 4 digits of the card number.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("last_4")]
    public string? Last4 { get; set; }

    /// <summary>
    /// The expiration month of the associated card as an integer between 1 and 12.
    /// </summary>
    [JsonPropertyName("exp_month")]
    public long? ExpMonth { get; set; }

    /// <summary>
    /// The four-digit year of the card's expiration date.
    /// </summary>
    [JsonPropertyName("exp_year")]
    public long? ExpYear { get; set; }

    /// <summary>
    /// The name of the cardholder.
    /// </summary>
    [JsonPropertyName("cardholder_name")]
    public string? CardholderName { get; set; }

    /// <summary>
    /// The billing address for this card. `US` postal codes can be provided as a 5-digit zip code
    /// or 9-digit ZIP+4 (example: `12345-6789`). For a full list of field meanings by country, see
    /// [Working with Addresses](https://developer.squareup.com/docs/build-basics/common-data-types/working-with-addresses).
    /// </summary>
    [JsonPropertyName("billing_address")]
    public Address? BillingAddress { get; set; }

    /// <summary>
    /// Intended as a Square-assigned identifier, based
    /// on the card number, to identify the card across multiple locations within a
    /// single application.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("fingerprint")]
    public string? Fingerprint { get; set; }

    /// <summary>
    /// **Required** The ID of a [customer](entity:Customer) to be associated with the card.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The ID of the merchant associated with the card.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// An optional user-defined reference ID that associates this card with
    /// another entity in an external system. For example, a customer ID from an
    /// external customer management system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Indicates whether or not a card can be used for payments.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The type of the card.
    /// The Card object includes this field only in response to Payments API calls.
    /// See [CardType](#type-cardtype) for possible values
    /// </summary>
    [JsonPropertyName("card_type")]
    public CardType? CardType { get; set; }

    /// <summary>
    /// Indicates whether the card is prepaid or not.
    /// See [CardPrepaidType](#type-cardprepaidtype) for possible values
    /// </summary>
    [JsonPropertyName("prepaid_type")]
    public CardPrepaidType? PrepaidType { get; set; }

    /// <summary>
    /// The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API
    /// returns this field.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("bin")]
    public string? Bin { get; set; }

    /// <summary>
    /// Current version number of the card. Increments with each card update. Requests to update an
    /// existing Card object will be rejected unless the version in the request matches the current
    /// version for the Card.
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; set; }

    /// <summary>
    /// The card's co-brand if available. For example, an Afterpay virtual card would have a
    /// co-brand of AFTERPAY.
    /// See [CardCoBrand](#type-cardcobrand) for possible values
    /// </summary>
    [JsonPropertyName("card_co_brand")]
    public CardCoBrand? CardCoBrand { get; set; }

    /// <summary>
    /// An alert from the issuing bank about the card status. Alerts can indicate whether
    /// future charges to the card are likely to fail. For more information, see
    /// [Manage Card on File Declines](https://developer.squareup.com/docs/cards-api/manage-card-on-file-declines).
    ///
    /// This field is present only if there's an active issuer alert.
    /// See [IssuerAlert](#type-issueralert) for possible values
    /// </summary>
    [JsonPropertyName("issuer_alert")]
    public string? IssuerAlert { get; set; }

    /// <summary>
    /// The timestamp of when the current issuer alert was received and processed, in
    /// RFC 3339 format.
    ///
    /// This field is present only if there's an active issuer alert.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("issuer_alert_at")]
    public string? IssuerAlertAt { get; set; }

    /// <summary>
    /// Indicates whether the card is linked to a Health Savings Account (HSA) or Flexible
    /// Spending Account (FSA), based on the card BIN.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("hsa_fsa")]
    public bool? HsaFsa { get; set; }

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
