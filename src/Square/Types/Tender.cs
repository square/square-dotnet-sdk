using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a tender (i.e., a method of payment) used in a Square transaction.
/// </summary>
public record Tender
{
    /// <summary>
    /// The tender's unique ID. It is the associated payment ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the transaction's associated location.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the tender's associated transaction.
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// The timestamp for when the tender was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// An optional note associated with the tender at the time of payment.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The total amount of the tender, including `tip_money`. If the tender has a `payment_id`,
    /// the `total_money` of the corresponding [Payment](entity:Payment) will be equal to the
    /// `amount_money` of the tender.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The tip's amount of the tender.
    /// </summary>
    [JsonPropertyName("tip_money")]
    public Money? TipMoney { get; set; }

    /// <summary>
    /// The amount of any Square processing fees applied to the tender.
    ///
    /// This field is not immediately populated when a new transaction is created.
    /// It is usually available after about ten seconds.
    /// </summary>
    [JsonPropertyName("processing_fee_money")]
    public Money? ProcessingFeeMoney { get; set; }

    /// <summary>
    /// If the tender is associated with a customer or represents a customer's card on file,
    /// this is the ID of the associated customer.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The type of tender, such as `CARD` or `CASH`.
    /// See [TenderType](#type-tendertype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required TenderType Type { get; set; }

    /// <summary>
    /// The details of the card tender.
    ///
    /// This value is present only if the value of `type` is `CARD`.
    /// </summary>
    [JsonPropertyName("card_details")]
    public TenderCardDetails? CardDetails { get; set; }

    /// <summary>
    /// The details of the cash tender.
    ///
    /// This value is present only if the value of `type` is `CASH`.
    /// </summary>
    [JsonPropertyName("cash_details")]
    public TenderCashDetails? CashDetails { get; set; }

    /// <summary>
    /// The details of the bank account tender.
    ///
    /// This value is present only if the value of `type` is `BANK_ACCOUNT`.
    /// </summary>
    [JsonPropertyName("bank_account_details")]
    public TenderBankAccountDetails? BankAccountDetails { get; set; }

    /// <summary>
    /// The details of a Buy Now Pay Later tender.
    ///
    /// This value is present only if the value of `type` is `BUY_NOW_PAY_LATER`.
    /// </summary>
    [JsonPropertyName("buy_now_pay_later_details")]
    public TenderBuyNowPayLaterDetails? BuyNowPayLaterDetails { get; set; }

    /// <summary>
    /// The details of a Square Account tender.
    ///
    /// This value is present only if the value of `type` is `SQUARE_ACCOUNT`.
    /// </summary>
    [JsonPropertyName("square_account_details")]
    public TenderSquareAccountDetails? SquareAccountDetails { get; set; }

    /// <summary>
    /// Additional recipients (other than the merchant) receiving a portion of this tender.
    /// For example, fees assessed on the purchase by a third party integration.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public IEnumerable<AdditionalRecipient>? AdditionalRecipients { get; set; }

    /// <summary>
    /// The ID of the [Payment](entity:Payment) that corresponds to this tender.
    /// This value is only present for payments created with the v2 Payments API.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
