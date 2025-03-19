using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about an `UNLINKED_ACTIVITY_REFUND` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityUnlinkedActivityRefund
{
    /// <summary>
    /// The amount added to the gift card for the refund. This value is a positive integer.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// A client-specified ID that associates the gift card activity with an entity in another system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The ID of the refunded payment. This field is not used starting in Square version 2022-06-16.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
