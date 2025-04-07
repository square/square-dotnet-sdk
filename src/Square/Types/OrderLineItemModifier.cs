using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A [CatalogModifier](entity:CatalogModifier).
/// </summary>
public record OrderLineItemModifier
{
    /// <summary>
    /// A unique ID that identifies the modifier only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The catalog object ID referencing [CatalogModifier](entity:CatalogModifier).
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this modifier references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The name of the item modifier.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
    /// The base price for the modifier.
    ///
    /// `base_price_money` is required for ad hoc modifiers.
    /// If both `catalog_object_id` and `base_price_money` are set, `base_price_money` will
    /// override the predefined [CatalogModifier](entity:CatalogModifier) price.
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
    /// Application-defined data attached to this order. Metadata fields are intended
    /// to store descriptive references or associations with an entity in another system or store brief
    /// information about the object. Square does not process this field; it only stores and returns it
    /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
    /// identifiable information or card details).
    ///
    /// Keys written by applications must be 60 characters or less and must be in the character set
    /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
    /// with a namespace, separated from the key with a ':' character.
    ///
    /// Values have a maximum length of 255 characters.
    ///
    /// An application can have up to 10 entries per metadata field.
    ///
    /// Entries written by applications are private and can only be read or modified by the same
    /// application.
    ///
    /// For more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

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
