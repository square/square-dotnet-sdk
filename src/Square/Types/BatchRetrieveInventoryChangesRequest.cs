using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record BatchRetrieveInventoryChangesRequest
{
    /// <summary>
    /// The filter to return results by `CatalogObject` ID.
    /// The filter is only applicable when set. The default value is null.
    /// </summary>
    [JsonPropertyName("catalog_object_ids")]
    public IEnumerable<string>? CatalogObjectIds { get; set; }

    /// <summary>
    /// The filter to return results by `Location` ID.
    /// The filter is only applicable when set. The default value is null.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// The filter to return results by `InventoryChangeType` values other than `TRANSFER`.
    /// The default value is `[PHYSICAL_COUNT, ADJUSTMENT]`.
    /// </summary>
    [JsonPropertyName("types")]
    public IEnumerable<InventoryChangeType>? Types { get; set; }

    /// <summary>
    /// The filter to return `ADJUSTMENT` query results by
    /// `InventoryState`. This filter is only applied when set.
    /// The default value is null.
    /// </summary>
    [JsonPropertyName("states")]
    public IEnumerable<InventoryState>? States { get; set; }

    /// <summary>
    /// The filter to return results with their `calculated_at` value
    /// after the given time as specified in an RFC 3339 timestamp.
    /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
    /// </summary>
    [JsonPropertyName("updated_after")]
    public string? UpdatedAfter { get; set; }

    /// <summary>
    /// The filter to return results with their `created_at` or `calculated_at` value
    /// strictly before the given time as specified in an RFC 3339 timestamp.
    /// The default value is the UNIX epoch of (`1970-01-01T00:00:00Z`).
    /// </summary>
    [JsonPropertyName("updated_before")]
    public string? UpdatedBefore { get; set; }

    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for the original query.
    ///
    /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The number of [records](entity:InventoryChange) to return.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

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
