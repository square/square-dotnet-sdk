using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Stores details about a cash refund. Contains only non-confidential information.
/// </summary>
[Serializable]
public record DestinationDetailsCashRefundDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
