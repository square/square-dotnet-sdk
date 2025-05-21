using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [BulkPublishScheduledShifts](api-endpoint:Labor-BulkPublishScheduledShifts) response.
/// Either `scheduled_shifts` or `errors` is present in the response.
/// </summary>
public record BulkPublishScheduledShiftsResponse
{
    /// <summary>
    /// A map of key-value pairs that represent responses for individual publish requests.
    /// The order of responses might differ from the order in which the requests were provided.
    ///
    /// - Each key is the scheduled shift ID that was specified for a publish request.
    /// - Each value is the corresponding response. If the request succeeds, the value is the
    /// published scheduled shift. If the request fails, the value is an `errors` array containing
    /// any errors that occurred while processing the request.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, PublishScheduledShiftResponse>? Responses { get; set; }

    /// <summary>
    /// Any top-level errors that prevented the bulk operation from succeeding.
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
