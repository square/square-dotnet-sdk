using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about a `TRANSFER_BALANCE_TO` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityTransferBalanceTo
{
    /// <summary>
    /// The ID of the gift card from which the specified amount was transferred.
    /// </summary>
    [JsonPropertyName("transfer_from_gift_card_id")]
    public required string TransferFromGiftCardId { get; set; }

    /// <summary>
    /// The amount added to the gift card balance for the transfer. This value is a positive integer.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

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
