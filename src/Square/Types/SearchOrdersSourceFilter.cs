using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A filter based on order `source` information.
/// </summary>
public record SearchOrdersSourceFilter
{
    /// <summary>
    /// Filters by the [Source](entity:OrderSource) `name`. The filter returns any orders
    /// with a `source.name` that matches any of the listed source names.
    ///
    /// Max: 10 source names.
    /// </summary>
    [JsonPropertyName("source_names")]
    public IEnumerable<string>? SourceNames { get; set; }

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
