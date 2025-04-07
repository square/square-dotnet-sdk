using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A line item modifier being returned.
/// </summary>
public record OrderReturnLineItemModifier
{
    /// <summary>
    /// A unique ID that identifies the return modifier only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The modifier `uid` from the order's line item that contains the
    /// original sale of this line item modifier.
    /// </summary>
    [JsonPropertyName("source_modifier_uid")]
    public string? SourceModifierUid { get; set; }

    /// <summary>
    /// The catalog object ID referencing [CatalogModifier](entity:CatalogModifier).
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this line item modifier references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The name of the item modifier.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The base price for the modifier.
    ///
    /// `base_price_money` is required for ad hoc modifiers.
    /// If both `catalog_object_id` and `base_price_money` are set, `base_price_money` overrides the predefined [CatalogModifier](entity:CatalogModifier) price.
    /// </summary>
    [JsonPropertyName("base_price_money")]
    public Money? BasePriceMoney { get; set; }

    /// <summary>
    /// The total price of the item modifier for its line item.
    /// This is the modifier's `base_price_money` multiplied by the line item's quantity.
    /// </summary>
    [JsonPropertyName("total_price_money")]
    public Money? TotalPriceMoney { get; set; }

    /// <summary>
    /// The quantity of the line item modifier. The modifier quantity can be 0 or more.
    /// For example, suppose a restaurant offers a cheeseburger on the menu. When a buyer orders
    /// this item, the restaurant records the purchase by creating an `Order` object with a line item
    /// for a burger. The line item includes a line item modifier: the name is cheese and the quantity
    /// is 1. The buyer has the option to order extra cheese (or no cheese). If the buyer chooses
    /// the extra cheese option, the modifier quantity increases to 2. If the buyer does not want
    /// any cheese, the modifier quantity is set to 0.
    /// </summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
