using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the items containing the specified item option IDs.
/// </summary>
public record CatalogQueryItemsForItemOptions
{
    /// <summary>
    /// A set of `CatalogItemOption` IDs to be used to find associated
    /// `CatalogItem`s. All Items that contain all of the given Item Options (in any order)
    /// will be returned.
    /// </summary>
    [JsonPropertyName("item_option_ids")]
    public IEnumerable<string>? ItemOptionIds { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
