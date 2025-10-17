using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the details of a tender with `type` `CASH`.
/// </summary>
[Serializable]
public record TenderCashDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
