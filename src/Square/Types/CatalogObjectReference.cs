using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A reference to a Catalog object at a specific version. In general this is
/// used as an entry point into a graph of catalog objects, where the objects exist
/// at a specific version.
/// </summary>
public record CatalogObjectReference
{
    /// <summary>
    /// The ID of the referenced object.
    /// </summary>
    [JsonPropertyName("object_id")]
    public string? ObjectId { get; set; }

    /// <summary>
    /// The version of the object.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

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
