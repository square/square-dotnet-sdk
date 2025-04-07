using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A batch of catalog objects.
/// </summary>
public record CatalogObjectBatch
{
    /// <summary>
    /// A list of CatalogObjects belonging to this batch.
    /// </summary>
    [JsonPropertyName("objects")]
    public IEnumerable<CatalogObject> Objects { get; set; } = new List<CatalogObject>();

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
