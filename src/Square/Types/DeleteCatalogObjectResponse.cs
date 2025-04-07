using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeleteCatalogObjectResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The IDs of all catalog objects deleted by this request.
    /// Multiple IDs may be returned when associated objects are also deleted, for example
    /// a catalog item variation will be deleted (and its ID included in this field)
    /// when its parent catalog item is deleted.
    /// </summary>
    [JsonPropertyName("deleted_object_ids")]
    public IEnumerable<string>? DeletedObjectIds { get; set; }

    /// <summary>
    /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// of this deletion in RFC 3339 format, e.g., `2016-09-04T23:59:33.123Z`.
    /// </summary>
    [JsonPropertyName("deleted_at")]
    public string? DeletedAt { get; set; }

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
