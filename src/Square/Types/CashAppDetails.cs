using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about `WALLET` type payments with the `brand` of `CASH_APP`.
/// </summary>
public record CashAppDetails
{
    /// <summary>
    /// The name of the Cash App account holder.
    /// </summary>
    [JsonPropertyName("buyer_full_name")]
    public string? BuyerFullName { get; set; }

    /// <summary>
    /// The country of the Cash App account holder, in ISO 3166-1-alpha-2 format.
    ///
    /// For possible values, see [Country](entity:Country).
    /// </summary>
    [JsonPropertyName("buyer_country_code")]
    public string? BuyerCountryCode { get; set; }

    /// <summary>
    /// $Cashtag of the Cash App account holder.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("buyer_cashtag")]
    public string? BuyerCashtag { get; set; }

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
