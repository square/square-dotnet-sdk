using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about a `LOAD` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityLoad
{
    /// <summary>
    /// The amount added to the gift card. This value is a positive integer.
    ///
    /// Applications that use a custom order processing system must specify this amount in the
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) that contains the `GIFT_CARD` line item.
    ///
    /// Applications that use the Square Orders API to process orders must specify the order ID in the
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The UID of the `GIFT_CARD` line item in the order that represents the additional funds for the gift card.
    ///
    /// Applications that use the Square Orders API to process orders must specify the line item UID
    /// in the [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
    /// </summary>
    [JsonPropertyName("line_item_uid")]
    public string? LineItemUid { get; set; }

    /// <summary>
    /// A client-specified ID that associates the gift card activity with an entity in another system.
    ///
    /// Applications that use a custom order processing system can use this field to track information related to
    /// an order or payment.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The payment instrument IDs used to process the order for the additional funds, such as a credit card ID
    /// or bank account ID.
    ///
    /// Applications that use a custom order processing system must specify payment instrument IDs in
    /// the [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
    /// Square uses this information to perform compliance checks.
    ///
    /// For applications that use the Square Orders API to process payments, Square has the necessary
    /// instrument IDs to perform compliance checks.
    ///
    /// Each buyer payment instrument ID can contain a maximum of 255 characters.
    /// </summary>
    [JsonPropertyName("buyer_payment_instrument_ids")]
    public IEnumerable<string>? BuyerPaymentInstrumentIds { get; set; }

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
