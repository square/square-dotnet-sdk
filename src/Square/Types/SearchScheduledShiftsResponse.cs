using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [SearchScheduledShifts](api-endpoint:Labor-SearchScheduledShifts) response.
/// Either `scheduled_shifts` or `errors` is present in the response.
/// </summary>
public record SearchScheduledShiftsResponse
{
    /// <summary>
    /// A paginated list of scheduled shifts that match the query conditions.
    /// </summary>
    [JsonPropertyName("scheduled_shifts")]
    public IEnumerable<ScheduledShift>? ScheduledShifts { get; set; }

    /// <summary>
    /// The pagination cursor used to retrieve the next page of results. This field is present
    /// only if additional results are available.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
