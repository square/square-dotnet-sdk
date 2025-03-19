using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Stores details about a cash refund. Contains only non-confidential information.
/// </summary>
public record DestinationDetailsCashRefundDetails
{
    /// <summary>
    /// The amount and currency of the money supplied by the seller.
    /// </summary>
    [JsonPropertyName("seller_supplied_money")]
    public required Money SellerSuppliedMoney { get; set; }

    /// <summary>
    /// The amount of change due back to the seller.
    /// This read-only field is calculated
    /// from the `amount_money` and `seller_supplied_money` fields.
    /// </summary>
    [JsonPropertyName("change_back_money")]
    public Money? ChangeBackMoney { get; set; }

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
