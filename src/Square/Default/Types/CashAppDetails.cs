using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Additional details about `WALLET` type payments with the `brand` of `CASH_APP`.
/// </summary>
[Serializable]
public record CashAppDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
