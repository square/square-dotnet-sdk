using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains query criteria for the search.
/// </summary>
public record SearchOrdersQuery
{
    /// <summary>
    /// Criteria to filter results by.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchOrdersFilter? Filter { get; set; }

    /// <summary>
    /// Criteria to sort results by.
    /// </summary>
    [JsonPropertyName("sort")]
    public SearchOrdersSort? Sort { get; set; }

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
