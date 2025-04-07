using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A tender represents a discrete monetary exchange. Square represents this
/// exchange as a money object with a specific currency and amount, where the
/// amount is given in the smallest denomination of the given currency.
///
/// Square POS can accept more than one form of tender for a single payment (such
/// as by splitting a bill between a credit card and a gift card). The `tender`
/// field of the Payment object lists all forms of tender used for the payment.
///
/// Split tender payments behave slightly differently from single tender payments:
///
/// The receipt_url for a split tender corresponds only to the first tender listed
/// in the tender field. To get the receipt URLs for the remaining tenders, use
/// the receipt_url fields of the corresponding Tender objects.
///
/// *A note on gift cards**: when a customer purchases a Square gift card from a
/// merchant, the merchant receives the full amount of the gift card in the
/// associated payment.
///
/// When that gift card is used as a tender, the balance of the gift card is
/// reduced and the merchant receives no funds. A `Tender` object with a type of
/// `SQUARE_GIFT_CARD` indicates a gift card was used for some or all of the
/// associated payment.
/// </summary>
public record V1Tender
{
    /// <summary>
    /// The tender's unique ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of tender.
    /// See [V1TenderType](#type-v1tendertype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public V1TenderType? Type { get; set; }

    /// <summary>
    /// A human-readable description of the tender.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The ID of the employee that processed the tender.
    /// </summary>
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// The URL of the receipt for the tender.
    /// </summary>
    [JsonPropertyName("receipt_url")]
    public string? ReceiptUrl { get; set; }

    /// <summary>
    /// The brand of credit card provided.
    /// See [V1TenderCardBrand](#type-v1tendercardbrand) for possible values
    /// </summary>
    [JsonPropertyName("card_brand")]
    public V1TenderCardBrand? CardBrand { get; set; }

    /// <summary>
    /// The last four digits of the provided credit card's account number.
    /// </summary>
    [JsonPropertyName("pan_suffix")]
    public string? PanSuffix { get; set; }

    /// <summary>
    /// The tender's unique ID.
    /// See [V1TenderEntryMethod](#type-v1tenderentrymethod) for possible values
    /// </summary>
    [JsonPropertyName("entry_method")]
    public V1TenderEntryMethod? EntryMethod { get; set; }

    /// <summary>
    /// Notes entered by the merchant about the tender at the time of payment, if any. Typically only present for tender with the type: OTHER.
    /// </summary>
    [JsonPropertyName("payment_note")]
    public string? PaymentNote { get; set; }

    /// <summary>
    /// The total amount of money provided in this form of tender.
    /// </summary>
    [JsonPropertyName("total_money")]
    public V1Money? TotalMoney { get; set; }

    /// <summary>
    /// The amount of total_money applied to the payment.
    /// </summary>
    [JsonPropertyName("tendered_money")]
    public V1Money? TenderedMoney { get; set; }

    /// <summary>
    /// The time when the tender was created, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("tendered_at")]
    public string? TenderedAt { get; set; }

    /// <summary>
    /// The time when the tender was settled, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("settled_at")]
    public string? SettledAt { get; set; }

    /// <summary>
    /// The amount of total_money returned to the buyer as change.
    /// </summary>
    [JsonPropertyName("change_back_money")]
    public V1Money? ChangeBackMoney { get; set; }

    /// <summary>
    /// The total of all refunds applied to this tender. This amount is always negative or zero.
    /// </summary>
    [JsonPropertyName("refunded_money")]
    public V1Money? RefundedMoney { get; set; }

    /// <summary>
    /// Indicates whether or not the tender is associated with an exchange. If is_exchange is true, the tender represents the value of goods returned in an exchange not the actual money paid. The exchange value reduces the tender amounts needed to pay for items purchased in the exchange.
    /// </summary>
    [JsonPropertyName("is_exchange")]
    public bool? IsExchange { get; set; }

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
