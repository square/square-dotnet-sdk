using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a collection of catalog objects for the purpose of applying a
/// `PricingRule`. Including a catalog object will include all of its subtypes.
/// For example, including a category in a product set will include all of its
/// items and associated item variations in the product set. Including an item in
/// a product set will also include its item variations.
/// </summary>
[Serializable]
public record CatalogProductSet : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// User-defined name for the product set. For example, "Clearance Items"
    /// or "Winter Sale Items".
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Unique IDs for any `CatalogObject` included in this product set. Any
    /// number of these catalog objects can be in an order for a pricing rule to apply.
    ///
    /// This can be used with `product_ids_all` in a parent `CatalogProductSet` to
    /// match groups of products for a bulk discount, such as a discount for an
    /// entree and side combo.
    ///
    /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
    ///
    /// Max: 500 catalog object IDs.
    /// </summary>
    [JsonPropertyName("product_ids_any")]
    public IEnumerable<string>? ProductIdsAny { get; set; }

    /// <summary>
    /// Unique IDs for any `CatalogObject` included in this product set.
    /// All objects in this set must be included in an order for a pricing rule to apply.
    ///
    /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
    ///
    /// Max: 500 catalog object IDs.
    /// </summary>
    [JsonPropertyName("product_ids_all")]
    public IEnumerable<string>? ProductIdsAll { get; set; }

    /// <summary>
    /// If set, there must be exactly this many items from `products_any` or `products_all`
    /// in the cart for the discount to apply.
    ///
    /// Cannot be combined with either `quantity_min` or `quantity_max`.
    /// </summary>
    [JsonPropertyName("quantity_exact")]
    public long? QuantityExact { get; set; }

    /// <summary>
    /// If set, there must be at least this many items from `products_any` or `products_all`
    /// in a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if
    /// `quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.
    /// </summary>
    [JsonPropertyName("quantity_min")]
    public long? QuantityMin { get; set; }

    /// <summary>
    /// If set, the pricing rule will apply to a maximum of this many items from
    /// `products_any` or `products_all`.
    /// </summary>
    [JsonPropertyName("quantity_max")]
    public long? QuantityMax { get; set; }

    /// <summary>
    /// If set to `true`, the product set will include every item in the catalog.
    /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
    /// </summary>
    [JsonPropertyName("all_products")]
    public bool? AllProducts { get; set; }

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
