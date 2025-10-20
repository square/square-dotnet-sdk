using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record CatalogInfoResponseLimits : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The maximum number of objects that may appear within a single batch in a
    /// `/v2/catalog/batch-upsert` request.
    /// </summary>
    [JsonPropertyName("batch_upsert_max_objects_per_batch")]
    public int? BatchUpsertMaxObjectsPerBatch { get; set; }

    /// <summary>
    /// The maximum number of objects that may appear across all batches in a
    /// `/v2/catalog/batch-upsert` request.
    /// </summary>
    [JsonPropertyName("batch_upsert_max_total_objects")]
    public int? BatchUpsertMaxTotalObjects { get; set; }

    /// <summary>
    /// The maximum number of object IDs that may appear in a `/v2/catalog/batch-retrieve`
    /// request.
    /// </summary>
    [JsonPropertyName("batch_retrieve_max_object_ids")]
    public int? BatchRetrieveMaxObjectIds { get; set; }

    /// <summary>
    /// The maximum number of results that may be returned in a page of a
    /// `/v2/catalog/search` response.
    /// </summary>
    [JsonPropertyName("search_max_page_limit")]
    public int? SearchMaxPageLimit { get; set; }

    /// <summary>
    /// The maximum number of object IDs that may be included in a single
    /// `/v2/catalog/batch-delete` request.
    /// </summary>
    [JsonPropertyName("batch_delete_max_object_ids")]
    public int? BatchDeleteMaxObjectIds { get; set; }

    /// <summary>
    /// The maximum number of item IDs that may be included in a single
    /// `/v2/catalog/update-item-taxes` request.
    /// </summary>
    [JsonPropertyName("update_item_taxes_max_item_ids")]
    public int? UpdateItemTaxesMaxItemIds { get; set; }

    /// <summary>
    /// The maximum number of tax IDs to be enabled that may be included in a single
    /// `/v2/catalog/update-item-taxes` request.
    /// </summary>
    [JsonPropertyName("update_item_taxes_max_taxes_to_enable")]
    public int? UpdateItemTaxesMaxTaxesToEnable { get; set; }

    /// <summary>
    /// The maximum number of tax IDs to be disabled that may be included in a single
    /// `/v2/catalog/update-item-taxes` request.
    /// </summary>
    [JsonPropertyName("update_item_taxes_max_taxes_to_disable")]
    public int? UpdateItemTaxesMaxTaxesToDisable { get; set; }

    /// <summary>
    /// The maximum number of item IDs that may be included in a single
    /// `/v2/catalog/update-item-modifier-lists` request.
    /// </summary>
    [JsonPropertyName("update_item_modifier_lists_max_item_ids")]
    public int? UpdateItemModifierListsMaxItemIds { get; set; }

    /// <summary>
    /// The maximum number of modifier list IDs to be enabled that may be included in
    /// a single `/v2/catalog/update-item-modifier-lists` request.
    /// </summary>
    [JsonPropertyName("update_item_modifier_lists_max_modifier_lists_to_enable")]
    public int? UpdateItemModifierListsMaxModifierListsToEnable { get; set; }

    /// <summary>
    /// The maximum number of modifier list IDs to be disabled that may be included in
    /// a single `/v2/catalog/update-item-modifier-lists` request.
    /// </summary>
    [JsonPropertyName("update_item_modifier_lists_max_modifier_lists_to_disable")]
    public int? UpdateItemModifierListsMaxModifierListsToDisable { get; set; }

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
