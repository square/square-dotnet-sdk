using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The parameters of a `Timecard` search query, which includes filter and sort options.
/// </summary>
public record TimecardQuery
{
    /// <summary>
    /// Query filter options.
    /// </summary>
    [JsonPropertyName("filter")]
    public TimecardFilter? Filter { get; set; }

    /// <summary>
    /// Sort order details.
    /// </summary>
    [JsonPropertyName("sort")]
    public TimecardSort? Sort { get; set; }

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
