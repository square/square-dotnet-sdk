using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains query criteria for the search.
/// </summary>
public record SearchEventsQuery
{
    /// <summary>
    /// Criteria to filter events by.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchEventsFilter? Filter { get; set; }

    /// <summary>
    /// Criteria to sort events by.
    /// </summary>
    [JsonPropertyName("sort")]
    public SearchEventsSort? Sort { get; set; }

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
