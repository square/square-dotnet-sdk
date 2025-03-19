using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Stores details about a cash payment. Contains only non-confidential information. For more information, see
/// [Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments).
/// </summary>
public record CashPaymentDetails
{
    /// <summary>
    /// The amount and currency of the money supplied by the buyer.
    /// </summary>
    [JsonPropertyName("buyer_supplied_money")]
    public required Money BuyerSuppliedMoney { get; set; }

    /// <summary>
    /// The amount of change due back to the buyer.
    /// This read-only field is calculated
    /// from the `amount_money` and `buyer_supplied_money` fields.
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
