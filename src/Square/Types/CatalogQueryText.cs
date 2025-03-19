using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the search result whose searchable attribute values contain all of the specified keywords or tokens, independent of the token order or case.
/// </summary>
public record CatalogQueryText
{
    /// <summary>
    /// A list of 1, 2, or 3 search keywords. Keywords with fewer than 3 alphanumeric characters are ignored.
    /// </summary>
    [JsonPropertyName("keywords")]
    public IEnumerable<string> Keywords { get; set; } = new List<string>();

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
