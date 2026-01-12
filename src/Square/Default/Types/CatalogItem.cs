using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A [CatalogObject](entity:CatalogObject) instance of the `ITEM` type, also referred to as an item, in the catalog.
/// </summary>
[Serializable]
public record CatalogItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
    ///
    /// Deprecated at 2022-07-20, this field is planned to retire in 6 months. You should migrate to use `description_html` to set the description
    /// of the [CatalogItem](entity:CatalogItem) instance.  The `description` and `description_html` field values are kept in sync. If you try to
    /// set the both fields, the `description_html` text value overwrites the `description` value. Updates in one field are also reflected in the other,
    /// except for when you use an early version before Square API 2022-07-20 and `description_html` is set to blank, setting the `description` value to null
    /// does not nullify `description_html`.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The text of the item's display label in the Square Point of Sale app. Only up to the first five characters of the string are used.
    /// This attribute is searchable, and its value length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("abbreviation")]
    public string? Abbreviation { get; set; }

    /// <summary>
    /// The color of the item's display label in the Square Point of Sale app. This must be a valid hex color code.
    /// </summary>
    [JsonPropertyName("label_color")]
    public string? LabelColor { get; set; }

    /// <summary>
    /// Indicates whether the item is taxable (`true`) or non-taxable (`false`). Default is `true`.
    /// </summary>
    [JsonPropertyName("is_taxable")]
    public bool? IsTaxable { get; set; }

    /// <summary>
    /// The ID of the item's category, if any. Deprecated since 2023-12-13. Use `CatalogItem.categories`, instead.
    /// </summary>
    [JsonPropertyName("category_id")]
    public string? CategoryId { get; set; }

    /// <summary>
    /// A set of IDs indicating the taxes enabled for
    /// this item. When updating an item, any taxes listed here will be added to the item.
    /// Taxes may also be added to or deleted from an item using `UpdateItemTaxes`.
    /// </summary>
    [JsonPropertyName("tax_ids")]
    public IEnumerable<string>? TaxIds { get; set; }

    /// <summary>
    /// A set of `CatalogItemModifierListInfo` objects
    /// representing the modifier lists that apply to this item, along with the overrides and min
    /// and max limits that are specific to this item. Modifier lists
    /// may also be added to or deleted from an item using `UpdateItemModifierLists`.
    /// </summary>
    [JsonPropertyName("modifier_list_info")]
    public IEnumerable<CatalogItemModifierListInfo>? ModifierListInfo { get; set; }

    /// <summary>
    /// A list of [CatalogItemVariation](entity:CatalogItemVariation) objects for this item. An item must have
    /// at least one variation.
    /// </summary>
    [JsonPropertyName("variations")]
    public IEnumerable<CatalogObject>? Variations { get; set; }

    /// <summary>
    /// The product type of the item. Once set, the `product_type` value cannot be modified.
    ///
    /// Items of the `LEGACY_SQUARE_ONLINE_SERVICE` and `LEGACY_SQUARE_ONLINE_MEMBERSHIP` product types can be updated
    /// but cannot be created using the API.
    /// See [CatalogItemProductType](#type-catalogitemproducttype) for possible values
    /// </summary>
    [JsonPropertyName("product_type")]
    public CatalogItemProductType? ProductType { get; set; }

    /// <summary>
    /// If `false`, the Square Point of Sale app will present the `CatalogItem`'s
    /// details screen immediately, allowing the merchant to choose `CatalogModifier`s
    /// before adding the item to the cart.  This is the default behavior.
    ///
    /// If `true`, the Square Point of Sale app will immediately add the item to the cart with the pre-selected
    /// modifiers, and merchants can edit modifiers by drilling down onto the item's details.
    ///
    /// Third-party clients are encouraged to implement similar behaviors.
    /// </summary>
    [JsonPropertyName("skip_modifier_screen")]
    public bool? SkipModifierScreen { get; set; }

    /// <summary>
    /// List of item options IDs for this item. Used to manage and group item
    /// variations in a specified order.
    ///
    /// Maximum: 6 item options.
    /// </summary>
    [JsonPropertyName("item_options")]
    public IEnumerable<CatalogItemOptionForItem>? ItemOptions { get; set; }

    /// <summary>
    /// Deprecated. A URI pointing to a published e-commerce product page for the Item.
    /// </summary>
    [JsonPropertyName("ecom_uri")]
    public string? EcomUri { get; set; }

    /// <summary>
    /// Deprecated. A comma-separated list of encoded URIs pointing to a set of published e-commerce images for the Item.
    /// </summary>
    [JsonPropertyName("ecom_image_uris")]
    public IEnumerable<string>? EcomImageUris { get; set; }

    /// <summary>
    /// The IDs of images associated with this `CatalogItem` instance.
    /// These images will be shown to customers in Square Online Store.
    /// The first image will show up as the icon for this item in POS.
    /// </summary>
    [JsonPropertyName("image_ids")]
    public IEnumerable<string>? ImageIds { get; set; }

    /// <summary>
    /// A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.
    /// Its value must not be empty.
    ///
    /// It is currently supported for sellers of the Japanese locale only.
    /// </summary>
    [JsonPropertyName("sort_name")]
    public string? SortName { get; set; }

    /// <summary>
    /// The list of categories.
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<CatalogObjectCategory>? Categories { get; set; }

    /// <summary>
    /// The item's description as expressed in valid HTML elements. The length of this field value, including those of HTML tags,
    /// is of Unicode points. With application query filters, the text values of the HTML elements and attributes are searchable. Invalid or
    /// unsupported HTML elements or attributes are ignored.
    ///
    /// Supported HTML elements include:
    /// - `a`: Link. Supports linking to website URLs, email address, and telephone numbers.
    /// - `b`, `strong`:  Bold text
    /// - `br`: Line break
    /// - `code`: Computer code
    /// - `div`: Section
    /// - `h1-h6`: Headings
    /// - `i`, `em`: Italics
    /// - `li`: List element
    /// - `ol`: Numbered list
    /// - `p`: Paragraph
    /// - `ul`: Bullet list
    /// - `u`: Underline
    ///
    ///
    /// Supported HTML attributes include:
    /// - `align`: Alignment of the text content
    /// - `href`: Link destination
    /// - `rel`: Relationship between link's target and source
    /// - `target`: Place to open the linked document
    /// </summary>
    [JsonPropertyName("description_html")]
    public string? DescriptionHtml { get; set; }

    /// <summary>
    /// A server-generated plaintext version of the `description_html` field, without formatting tags.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("description_plaintext")]
    public string? DescriptionPlaintext { get; set; }

    /// <summary>
    /// A list of IDs representing channels, such as a Square Online site, where the item can be made visible or available.
    /// This field is read only and cannot be edited.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; set; }

    /// <summary>
    /// Indicates whether this item is archived (`true`) or not (`false`).
    /// </summary>
    [JsonPropertyName("is_archived")]
    public bool? IsArchived { get; set; }

    /// <summary>
    /// The SEO data for a seller's Square Online store.
    /// </summary>
    [JsonPropertyName("ecom_seo_data")]
    public CatalogEcomSeoData? EcomSeoData { get; set; }

    /// <summary>
    /// The food and beverage-specific details for the `FOOD_AND_BEV` item.
    /// </summary>
    [JsonPropertyName("food_and_beverage_details")]
    public CatalogItemFoodAndBeverageDetails? FoodAndBeverageDetails { get; set; }

    /// <summary>
    /// The item's reporting category.
    /// </summary>
    [JsonPropertyName("reporting_category")]
    public CatalogObjectCategory? ReportingCategory { get; set; }

    /// <summary>
    /// Indicates whether this item is alcoholic (`true`) or not (`false`).
    /// </summary>
    [JsonPropertyName("is_alcoholic")]
    public bool? IsAlcoholic { get; set; }

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
