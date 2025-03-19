using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an action performed on a [gift card](entity:GiftCard) that affects its state or balance.
/// A gift card activity contains information about a specific activity type. For example, a `REDEEM` activity
/// includes a `redeem_activity_details` field that contains information about the redemption.
/// </summary>
public record GiftCardActivity
{
    /// <summary>
    /// The Square-assigned ID of the gift card activity.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of gift card activity.
    /// See [Type](#type-type) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required GiftCardActivityType Type { get; set; }

    /// <summary>
    /// The ID of the [business location](entity:Location) where the activity occurred.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The timestamp when the gift card activity was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The gift card ID. When creating a gift card activity, `gift_card_id` is not required if
    /// `gift_card_gan` is specified.
    /// </summary>
    [JsonPropertyName("gift_card_id")]
    public string? GiftCardId { get; set; }

    /// <summary>
    /// The gift card account number (GAN). When creating a gift card activity, `gift_card_gan`
    /// is not required if `gift_card_id` is specified.
    /// </summary>
    [JsonPropertyName("gift_card_gan")]
    public string? GiftCardGan { get; set; }

    /// <summary>
    /// The final balance on the gift card after the action is completed.
    /// </summary>
    [JsonPropertyName("gift_card_balance_money")]
    public Money? GiftCardBalanceMoney { get; set; }

    /// <summary>
    /// Additional details about a `LOAD` activity, which is used to reload money onto a gift card.
    /// </summary>
    [JsonPropertyName("load_activity_details")]
    public GiftCardActivityLoad? LoadActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `ACTIVATE` activity, which is used to activate a gift card with
    /// an initial balance.
    /// </summary>
    [JsonPropertyName("activate_activity_details")]
    public GiftCardActivityActivate? ActivateActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `REDEEM` activity, which is used to redeem a gift card for a purchase.
    ///
    /// For applications that process payments using the Square Payments API, Square creates a `REDEEM` activity that
    /// updates the gift card balance after the corresponding [CreatePayment](api-endpoint:Payments-CreatePayment)
    /// request is completed. Applications that use a custom payment processing system must call
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) to create the `REDEEM` activity.
    /// </summary>
    [JsonPropertyName("redeem_activity_details")]
    public GiftCardActivityRedeem? RedeemActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `CLEAR_BALANCE` activity, which is used to set the balance of a gift card to zero.
    /// </summary>
    [JsonPropertyName("clear_balance_activity_details")]
    public GiftCardActivityClearBalance? ClearBalanceActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `DEACTIVATE` activity, which is used to deactivate a gift card.
    /// </summary>
    [JsonPropertyName("deactivate_activity_details")]
    public GiftCardActivityDeactivate? DeactivateActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `ADJUST_INCREMENT` activity, which is used to add money to a gift card
    /// outside of a typical `ACTIVATE`, `LOAD`, or `REFUND` activity flow.
    /// </summary>
    [JsonPropertyName("adjust_increment_activity_details")]
    public GiftCardActivityAdjustIncrement? AdjustIncrementActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `ADJUST_DECREMENT` activity, which is used to deduct money from a gift
    /// card outside of a typical `REDEEM` activity flow.
    /// </summary>
    [JsonPropertyName("adjust_decrement_activity_details")]
    public GiftCardActivityAdjustDecrement? AdjustDecrementActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `REFUND` activity, which is used to add money to a gift card when
    /// refunding a payment.
    ///
    /// For applications that refund payments to a gift card using the Square Refunds API, Square automatically
    /// creates a `REFUND` activity that updates the gift card balance after a [RefundPayment](api-endpoint:Refunds-RefundPayment)
    /// request is completed. Applications that use a custom processing system must call
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) to create the `REFUND` activity.
    /// </summary>
    [JsonPropertyName("refund_activity_details")]
    public GiftCardActivityRefund? RefundActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `UNLINKED_ACTIVITY_REFUND` activity. This activity is used to add money
    /// to a gift card when refunding a payment that was processed using a custom payment processing system
    /// and not linked to the gift card.
    /// </summary>
    [JsonPropertyName("unlinked_activity_refund_activity_details")]
    public GiftCardActivityUnlinkedActivityRefund? UnlinkedActivityRefundActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `IMPORT` activity, which Square uses to import a third-party
    /// gift card with a balance.
    /// </summary>
    [JsonPropertyName("import_activity_details")]
    public GiftCardActivityImport? ImportActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `BLOCK` activity, which Square uses to temporarily block a gift card.
    /// </summary>
    [JsonPropertyName("block_activity_details")]
    public GiftCardActivityBlock? BlockActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `UNBLOCK` activity, which Square uses to unblock a gift card.
    /// </summary>
    [JsonPropertyName("unblock_activity_details")]
    public GiftCardActivityUnblock? UnblockActivityDetails { get; set; }

    /// <summary>
    /// Additional details about an `IMPORT_REVERSAL` activity, which Square uses to reverse the
    /// import of a third-party gift card.
    /// </summary>
    [JsonPropertyName("import_reversal_activity_details")]
    public GiftCardActivityImportReversal? ImportReversalActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `TRANSFER_BALANCE_TO` activity, which Square uses to add money to
    /// a gift card as the result of a transfer from another gift card.
    /// </summary>
    [JsonPropertyName("transfer_balance_to_activity_details")]
    public GiftCardActivityTransferBalanceTo? TransferBalanceToActivityDetails { get; set; }

    /// <summary>
    /// Additional details about a `TRANSFER_BALANCE_FROM` activity, which Square uses to deduct money from
    /// a gift as the result of a transfer to another gift card.
    /// </summary>
    [JsonPropertyName("transfer_balance_from_activity_details")]
    public GiftCardActivityTransferBalanceFrom? TransferBalanceFromActivityDetails { get; set; }

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
