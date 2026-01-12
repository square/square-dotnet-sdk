using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A filter to select customers based on exact or fuzzy matching of
/// customer attributes against a specified query. Depending on the customer attributes,
/// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
/// </summary>
[Serializable]
public record CustomerTextFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
