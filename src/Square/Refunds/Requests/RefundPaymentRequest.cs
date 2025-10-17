using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Refunds;

[Serializable]
public record RefundPaymentRequest
{
    /// <summary>
    /// A unique string that identifies this `RefundPayment` request. The key can be any valid string
    /// but must be unique for every `RefundPayment` request.
    ///
    /// Keys are limited to a max of 45 characters - however, the number of allowed characters might be
    /// less than 45, if multi-byte characters are used.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The amount of money to refund.
    ///
    /// This amount cannot be more than the `total_money` value of the payment minus the total
    /// amount of all previously completed refunds for this payment.
    ///
    /// This amount must be specified in the smallest denomination of the applicable currency
    /// (for example, US dollar amounts are specified in cents). For more information, see
    /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    ///
    /// The currency code must match the currency associated with the business
    /// that is charging the card.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The amount of money the developer contributes to help cover the refunded amount.
    /// This amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents).
    ///
    /// The value cannot be more than the `amount_money`.
    ///
    /// You can specify this parameter in a refund request only if the same parameter was also included
    /// when taking the payment. This is part of the application fee scenario the API supports. For more
    /// information, see [Take Payments and Collect Fees](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees).
    ///
    /// To set this field, `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required.
    /// For more information, see [Permissions](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees#permissions).
    /// </summary>
    [JsonPropertyName("app_fee_money")]
    public Money? AppFeeMoney { get; set; }

    /// <summary>
    /// The unique ID of the payment being refunded.
    /// Required when unlinked=false, otherwise must not be set.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// The ID indicating where funds will be refunded to. Required for unlinked refunds. For more
    /// information, see [Process an Unlinked Refund](https://developer.squareup.com/docs/refunds-api/unlinked-refunds).
    ///
    /// For refunds linked to Square payments, `destination_id` is usually omitted; in this case, funds
    /// will be returned to the original payment source. The field may be specified in order to request
    /// a cross-method refund to a gift card. For more information,
    /// see [Cross-method refunds to gift cards](https://developer.squareup.com/docs/payments-api/refund-payments#cross-method-refunds-to-gift-cards).
    /// </summary>
    [JsonPropertyName("destination_id")]
    public string? DestinationId { get; set; }

    /// <summary>
    /// Indicates that the refund is not linked to a Square payment.
    /// If set to true, `destination_id` and `location_id` must be supplied while `payment_id` must not
    /// be provided.
    /// </summary>
    [JsonPropertyName("unlinked")]
    public bool? Unlinked { get; set; }

    /// <summary>
    /// The location ID associated with the unlinked refund.
    /// Required for requests specifying `unlinked=true`.
    /// Otherwise, if included when `unlinked=false`, will throw an error.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The [Customer](entity:Customer) ID of the customer associated with the refund.
    /// This is required if the `destination_id` refers to a card on file created using the Cards
    /// API. Only allowed when `unlinked=true`.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// A description of the reason for the refund.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Used for optimistic concurrency. This opaque token identifies the current `Payment`
    /// version that the caller expects. If the server has a different version of the Payment,
    /// the update fails and a response with a VERSION_MISMATCH error is returned.
    /// If the versions match, or the field is not provided, the refund proceeds as normal.
    /// </summary>
    [JsonPropertyName("payment_version_token")]
    public string? PaymentVersionToken { get; set; }

    /// <summary>
    /// An optional [TeamMember](entity:TeamMember) ID to associate with this refund.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// Additional details required when recording an unlinked cash refund (`destination_id` is CASH).
    /// </summary>
    [JsonPropertyName("cash_details")]
    public DestinationDetailsCashRefundDetails? CashDetails { get; set; }

    /// <summary>
    /// Additional details required when recording an unlinked external refund
    /// (`destination_id` is EXTERNAL).
    /// </summary>
    [JsonPropertyName("external_details")]
    public DestinationDetailsExternalRefundDetails? ExternalDetails { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
