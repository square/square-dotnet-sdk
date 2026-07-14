using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about the vendor of an item variation.
/// </summary>
[Serializable]
public record CatalogItemVariationVendorInformation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the [Vendor](entity:Vendor) linked to a default cost of this product.
    /// When the product is added to a purchase order, the default cost is pre-filled.
    /// This field is not validated. Clients should gracefully handle cases where the vendor_id
    /// does not match any existing vendor.
    /// </summary>
    [JsonPropertyName("vendor_id")]
    public string? VendorId { get; set; }

    /// <summary>
    /// Unique identifier of this product in the specified vendor's' inventory system.
    /// When the product is added to a purchase order, the vendor code is pre-filled based
    /// on the selected vendor.
    /// </summary>
    [JsonPropertyName("vendor_code")]
    public string? VendorCode { get; set; }

    /// <summary>
    /// The unit cost of the linked product, when purchased from the linked vendor.
    /// </summary>
    [JsonPropertyName("unit_cost_money")]
    public Money? UnitCostMoney { get; set; }

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
