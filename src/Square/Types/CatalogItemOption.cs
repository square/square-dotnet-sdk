using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A group of variations for a `CatalogItem`.
/// </summary>
public record CatalogItemOption
{
    /// <summary>
    /// The item option's display name for the seller. Must be unique across
    /// all item options. This is a searchable attribute for use in applicable query filters.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The item option's display name for the customer. This is a searchable attribute for use in applicable query filters.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The item option's human-readable description. Displayed in the Square
    /// Point of Sale app for the seller and in the Online Store or on receipts for
    /// the buyer. This is a searchable attribute for use in applicable query filters.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// If true, display colors for entries in `values` when present.
    /// </summary>
    [JsonPropertyName("show_colors")]
    public bool? ShowColors { get; set; }

    /// <summary>
    /// A list of CatalogObjects containing the
    /// `CatalogItemOptionValue`s for this item.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<CatalogObject>? Values { get; set; }

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
