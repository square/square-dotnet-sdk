using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BatchGetInventoryCountsRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The filter to return results by `CatalogObject` ID.
    /// The filter is applicable only when set.  The default is null.
    /// </summary>
    [JsonPropertyName("catalog_object_ids")]
    public IEnumerable<string>? CatalogObjectIds { get; set; }

    /// <summary>
    /// The filter to return results by `Location` ID.
    /// This filter is applicable only when set. The default is null.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// The filter to return results with their `calculated_at` value
    /// after the given time as specified in an RFC 3339 timestamp.
    /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
    /// </summary>
    [JsonPropertyName("updated_after")]
    public string? UpdatedAfter { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for the original query.
    ///
    /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The filter to return results by `InventoryState`. The filter is only applicable when set.
    /// Ignored are untracked states of `NONE`, `SOLD`, and `UNLINKED_RETURN`.
    /// The default is null.
    /// </summary>
    [JsonPropertyName("states")]
    public IEnumerable<InventoryState>? States { get; set; }

    /// <summary>
    /// The number of [records](entity:InventoryCount) to return.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

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
