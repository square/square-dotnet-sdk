using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about a `TRANSFER_BALANCE_FROM` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityTransferBalanceFrom
{
    /// <summary>
    /// The ID of the gift card to which the specified amount was transferred.
    /// </summary>
    [JsonPropertyName("transfer_to_gift_card_id")]
    public required string TransferToGiftCardId { get; set; }

    /// <summary>
    /// The amount deducted from the gift card for the transfer. This value is a positive integer.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

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
