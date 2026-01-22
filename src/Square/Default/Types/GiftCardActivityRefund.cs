using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents details about a `REFUND` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
[Serializable]
public record GiftCardActivityRefund : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the refunded `REDEEM` gift card activity. Square populates this field if the
    /// `payment_id` in the corresponding [RefundPayment](api-endpoint:Refunds-RefundPayment) request
    /// represents a gift card redemption.
    ///
    /// For applications that use a custom payment processing system, this field is required when creating
    /// a `REFUND` activity. The provided `REDEEM` activity ID must be linked to the same gift card.
    /// </summary>
    [JsonPropertyName("redeem_activity_id")]
    public string? RedeemActivityId { get; set; }

    /// <summary>
    /// The amount added to the gift card for the refund. This value is a positive integer.
    ///
    /// This field is required when creating a `REFUND` activity. The amount can represent a full or partial refund.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// A client-specified ID that associates the gift card activity with an entity in another system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The ID of the refunded payment. Square populates this field if the refund is for a
    /// payment processed by Square. This field matches the `payment_id` in the corresponding
    /// [RefundPayment](api-endpoint:Refunds-RefundPayment) request.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

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
