using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CreateScheduledShift](api-endpoint:Labor-CreateScheduledShift) response.
/// Either `scheduled_shift` or `errors` is present in the response.
/// </summary>
public record CreateScheduledShiftResponse
{
    /// <summary>
    /// The new scheduled shift. To make the shift public, call
    /// [PublishScheduledShift](api-endpoint:Labor-PublishScheduledShift) or
    /// [BulkPublishScheduledShifts](api-endpoint:Labor-BulkPublishScheduledShifts).
    /// </summary>
    [JsonPropertyName("scheduled_shift")]
    public ScheduledShift? ScheduledShift { get; set; }

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
