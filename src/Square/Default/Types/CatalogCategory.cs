using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A category to which a `CatalogItem` instance belongs.
/// </summary>
[Serializable]
public record CatalogCategory : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The IDs of images associated with this `CatalogCategory` instance.
    /// Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
    /// </summary>
    [JsonPropertyName("image_ids")]
    public IEnumerable<string>? ImageIds { get; set; }

    /// <summary>
    /// The type of the category.
    /// See [CatalogCategoryType](#type-catalogcategorytype) for possible values
    /// </summary>
    [JsonPropertyName("category_type")]
    public CatalogCategoryType? CategoryType { get; set; }

    /// <summary>
    /// The ID of the parent category of this category instance.
    /// </summary>
    [JsonPropertyName("parent_category")]
    public CatalogObjectCategory? ParentCategory { get; set; }

    /// <summary>
    /// Indicates whether a category is a top level category, which does not have any parent_category.
    /// </summary>
    [JsonPropertyName("is_top_level")]
    public bool? IsTopLevel { get; set; }

    /// <summary>
    /// A list of IDs representing channels, such as a Square Online site, where the category can be made visible.
    /// </summary>
    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; set; }

    /// <summary>
    /// The IDs of the `CatalogAvailabilityPeriod` objects associated with the category.
    /// </summary>
    [JsonPropertyName("availability_period_ids")]
    public IEnumerable<string>? AvailabilityPeriodIds { get; set; }

    /// <summary>
    /// Indicates whether the category is visible (`true`) or hidden (`false`) on all of the seller's Square Online sites.
    /// </summary>
    [JsonPropertyName("online_visibility")]
    public bool? OnlineVisibility { get; set; }

    /// <summary>
    /// The top-level category in a category hierarchy.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("root_category")]
    public string? RootCategory { get; set; }

    /// <summary>
    /// The SEO data for a seller's Square Online store.
    /// </summary>
    [JsonPropertyName("ecom_seo_data")]
    public CatalogEcomSeoData? EcomSeoData { get; set; }

    /// <summary>
    /// The path from the category to its root category. The first node of the path is the parent of the category
    /// and the last is the root category. The path is empty if the category is a root category.
    /// </summary>
    [JsonPropertyName("path_to_root")]
    public IEnumerable<CategoryPathToRootNode>? PathToRoot { get; set; }

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
