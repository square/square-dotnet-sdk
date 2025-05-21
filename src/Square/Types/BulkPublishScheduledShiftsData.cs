using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents options for an individual publish request in a
/// [BulkPublishScheduledShifts](api-endpoint:Labor-BulkPublishScheduledShifts)
/// operation, provided as the value in a key-value pair.
/// </summary>
public record BulkPublishScheduledShiftsData
{
    /// <summary>
    /// The current version of the scheduled shift, used to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control. If the provided version doesn't match the server version, the request fails.
    /// If omitted, Square executes a blind write, potentially overwriting data from another publish request.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

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
