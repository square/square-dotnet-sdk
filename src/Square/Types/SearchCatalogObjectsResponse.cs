using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record SearchCatalogObjectsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If unset, this is the final response.
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The CatalogObjects returned.
    /// </summary>
    [JsonPropertyName("objects")]
    public IEnumerable<CatalogObject>? Objects { get; set; }

    /// <summary>
    /// A list of CatalogObjects referenced by the objects in the `objects` field.
    /// </summary>
    [JsonPropertyName("related_objects")]
    public IEnumerable<CatalogObject>? RelatedObjects { get; set; }

    /// <summary>
    /// When the associated product catalog was last updated. Will
    /// match the value for `end_time` or `cursor` if either field is included in the `SearchCatalog` request.
    /// </summary>
    [JsonPropertyName("latest_time")]
    public string? LatestTime { get; set; }

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
