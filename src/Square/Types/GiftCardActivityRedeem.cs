using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about a `REDEEM` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityRedeem
{
    /// <summary>
    /// The amount deducted from the gift card for the redemption. This value is a positive integer.
    ///
    /// Applications that use a custom payment processing system must specify this amount in the
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The ID of the payment that represents the gift card redemption. Square populates this field
    /// if the payment was processed by Square.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// A client-specified ID that associates the gift card activity with an entity in another system.
    ///
    /// Applications that use a custom payment processing system can use this field to track information
    /// related to an order or payment.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The status of the gift card redemption. Gift cards redeemed from Square Point of Sale or the
    /// Square Seller Dashboard use a two-state process: `PENDING`
    /// to `COMPLETED` or `PENDING` to  `CANCELED`. Gift cards redeemed using the Gift Card Activities API
    /// always have a `COMPLETED` status.
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public GiftCardActivityRedeemStatus? Status { get; set; }

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
