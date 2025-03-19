using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the items containing the specified modifier list IDs.
/// </summary>
public record CatalogQueryItemsForModifierList
{
    /// <summary>
    /// A set of `CatalogModifierList` IDs to be used to find associated `CatalogItem`s.
    /// </summary>
    [JsonPropertyName("modifier_list_ids")]
    public IEnumerable<string> ModifierListIds { get; set; } = new List<string>();

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
