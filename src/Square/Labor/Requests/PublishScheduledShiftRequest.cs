using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor;

[Serializable]
public record PublishScheduledShiftRequest
{
    /// <summary>
    /// The ID of the scheduled shift to publish.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// A unique identifier for the `PublishScheduledShift` request, used to ensure the
    /// [idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency)
    /// of the operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The current version of the scheduled shift, used to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control. If the provided version doesn't match the server version, the request fails.
    /// If omitted, Square executes a blind write, potentially overwriting data from another publish request.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Indicates whether Square should send an email notification to team members and
    /// which team members should receive the notification. The default value is `AFFECTED`.
    /// See [ScheduledShiftNotificationAudience](#type-scheduledshiftnotificationaudience) for possible values
    /// </summary>
    [JsonPropertyName("scheduled_shift_notification_audience")]
    public ScheduledShiftNotificationAudience? ScheduledShiftNotificationAudience { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
