using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the details of a tender with `type` `CASH`.
/// </summary>
public record TenderCashDetails
{
    /// <summary>
    /// The total amount of cash provided by the buyer, before change is given.
    /// </summary>
    [JsonPropertyName("buyer_tendered_money")]
    public Money? BuyerTenderedMoney { get; set; }

    /// <summary>
    /// The amount of change returned to the buyer.
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
