using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A filter to select customers based on exact or fuzzy matching of
/// customer attributes against a specified query. Depending on the customer attributes,
/// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
/// </summary>
public record CustomerTextFilter
{
    /// <summary>
    /// Use the exact filter to select customers whose attributes match exactly the specified query.
    /// </summary>
    [JsonPropertyName("exact")]
    public string? Exact { get; set; }

    /// <summary>
    /// Use the fuzzy filter to select customers whose attributes match the specified query
    /// in a fuzzy manner. When the fuzzy option is used, search queries are tokenized, and then
    /// each query token must be matched somewhere in the searched attribute. For single token queries,
    /// this is effectively the same behavior as a partial match operation.
    /// </summary>
    [JsonPropertyName("fuzzy")]
    public string? Fuzzy { get; set; }

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
