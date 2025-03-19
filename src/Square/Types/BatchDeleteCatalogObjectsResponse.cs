using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record BatchDeleteCatalogObjectsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The IDs of all CatalogObjects deleted by this request.
    /// </summary>
    [JsonPropertyName("deleted_object_ids")]
    public IEnumerable<string>? DeletedObjectIds { get; set; }

    /// <summary>
    /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates) of this deletion in RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
    /// </summary>
    [JsonPropertyName("deleted_at")]
    public string? DeletedAt { get; set; }

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
