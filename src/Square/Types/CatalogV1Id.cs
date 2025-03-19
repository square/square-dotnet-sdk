using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A Square API V1 identifier of an item, including the object ID and its associated location ID.
/// </summary>
public record CatalogV1Id
{
    /// <summary>
    /// The ID for an object used in the Square API V1, if the object ID differs from the Square API V2 object ID.
    /// </summary>
    [JsonPropertyName("catalog_v1_id")]
    public string? CatalogV1Id_ { get; set; }

    /// <summary>
    /// The ID of the `Location` this Connect V1 ID is associated with.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

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
