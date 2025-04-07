using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the item variations containing the specified item option value IDs.
/// </summary>
public record CatalogQueryItemVariationsForItemOptionValues
{
    /// <summary>
    /// A set of `CatalogItemOptionValue` IDs to be used to find associated
    /// `CatalogItemVariation`s. All ItemVariations that contain all of the given
    /// Item Option Values (in any order) will be returned.
    /// </summary>
    [JsonPropertyName("item_option_value_ids")]
    public IEnumerable<string>? ItemOptionValueIds { get; set; }

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
