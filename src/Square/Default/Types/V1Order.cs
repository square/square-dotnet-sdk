using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// V1Order
/// </summary>
[Serializable]
public record V1Order : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The order's unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The email address of the order's buyer.
    /// </summary>
    [JsonPropertyName("buyer_email")]
    public string? BuyerEmail { get; set; }

    /// <summary>
    /// The name of the order's buyer.
    /// </summary>
    [JsonPropertyName("recipient_name")]
    public string? RecipientName { get; set; }

    /// <summary>
    /// The phone number to use for the order's delivery.
    /// </summary>
    [JsonPropertyName("recipient_phone_number")]
    public string? RecipientPhoneNumber { get; set; }

    /// <summary>
    /// Whether the tax is an ADDITIVE tax or an INCLUSIVE tax.
    /// See [V1OrderState](#type-v1orderstate) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public V1OrderState? State { get; set; }

    /// <summary>
    /// The address to ship the order to.
    /// </summary>
    [JsonPropertyName("shipping_address")]
    public Address? ShippingAddress { get; set; }

    /// <summary>
    /// The amount of all items purchased in the order, before taxes and shipping.
    /// </summary>
    [JsonPropertyName("subtotal_money")]
    public V1Money? SubtotalMoney { get; set; }

    /// <summary>
    /// The shipping cost for the order.
    /// </summary>
    [JsonPropertyName("total_shipping_money")]
    public V1Money? TotalShippingMoney { get; set; }

    /// <summary>
    /// The total of all taxes applied to the order.
    /// </summary>
    [JsonPropertyName("total_tax_money")]
    public V1Money? TotalTaxMoney { get; set; }

    /// <summary>
    /// The total cost of the order.
    /// </summary>
    [JsonPropertyName("total_price_money")]
    public V1Money? TotalPriceMoney { get; set; }

    /// <summary>
    /// The total of all discounts applied to the order.
    /// </summary>
    [JsonPropertyName("total_discount_money")]
    public V1Money? TotalDiscountMoney { get; set; }

    /// <summary>
    /// The time when the order was created, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The time when the order was last modified, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The time when the order expires if no action is taken, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    /// <summary>
    /// The unique identifier of the payment associated with the order.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// A note provided by the buyer when the order was created, if any.
    /// </summary>
    [JsonPropertyName("buyer_note")]
    public string? BuyerNote { get; set; }

    /// <summary>
    /// A note provided by the merchant when the order's state was set to COMPLETED, if any
    /// </summary>
    [JsonPropertyName("completed_note")]
    public string? CompletedNote { get; set; }

    /// <summary>
    /// A note provided by the merchant when the order's state was set to REFUNDED, if any.
    /// </summary>
    [JsonPropertyName("refunded_note")]
    public string? RefundedNote { get; set; }

    /// <summary>
    /// A note provided by the merchant when the order's state was set to CANCELED, if any.
    /// </summary>
    [JsonPropertyName("canceled_note")]
    public string? CanceledNote { get; set; }

    /// <summary>
    /// The tender used to pay for the order.
    /// </summary>
    [JsonPropertyName("tender")]
    public V1Tender? Tender { get; set; }

    /// <summary>
    /// The history of actions associated with the order.
    /// </summary>
    [JsonPropertyName("order_history")]
    public IEnumerable<V1OrderHistoryEntry>? OrderHistory { get; set; }

    /// <summary>
    /// The promo code provided by the buyer, if any.
    /// </summary>
    [JsonPropertyName("promo_code")]
    public string? PromoCode { get; set; }

    /// <summary>
    /// For Bitcoin transactions, the address that the buyer sent Bitcoin to.
    /// </summary>
    [JsonPropertyName("btc_receive_address")]
    public string? BtcReceiveAddress { get; set; }

    /// <summary>
    /// For Bitcoin transactions, the price of the buyer's order in satoshi (100 million satoshi equals 1 BTC).
    /// </summary>
    [JsonPropertyName("btc_price_satoshi")]
    public double? BtcPriceSatoshi { get; set; }

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
