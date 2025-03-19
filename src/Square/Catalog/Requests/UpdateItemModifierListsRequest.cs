using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Catalog;

public record UpdateItemModifierListsRequest
{
    /// <summary>
    /// The IDs of the catalog items associated with the CatalogModifierList objects being updated.
    /// </summary>
    [JsonPropertyName("item_ids")]
    public IEnumerable<string> ItemIds { get; set; } = new List<string>();

    /// <summary>
    /// The IDs of the CatalogModifierList objects to enable for the CatalogItem.
    /// At least one of `modifier_lists_to_enable` or `modifier_lists_to_disable` must be specified.
    /// </summary>
    [JsonPropertyName("modifier_lists_to_enable")]
    public IEnumerable<string>? ModifierListsToEnable { get; set; }

    /// <summary>
    /// The IDs of the CatalogModifierList objects to disable for the CatalogItem.
    /// At least one of `modifier_lists_to_enable` or `modifier_lists_to_disable` must be specified.
    /// </summary>
    [JsonPropertyName("modifier_lists_to_disable")]
    public IEnumerable<string>? ModifierListsToDisable { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
