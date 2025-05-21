using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents filter and sort criteria for the `query` field in a
/// [SearchScheduledShifts](api-endpoint:Labor-SearchScheduledShifts) request.
/// </summary>
public record ScheduledShiftQuery
{
    /// <summary>
    /// Filtering options for the query.
    /// </summary>
    [JsonPropertyName("filter")]
    public ScheduledShiftFilter? Filter { get; set; }

    /// <summary>
    /// Sorting options for the query.
    /// </summary>
    [JsonPropertyName("sort")]
    public ScheduledShiftSort? Sort { get; set; }

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
