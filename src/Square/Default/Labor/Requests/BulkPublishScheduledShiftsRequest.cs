using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BulkPublishScheduledShiftsRequest
{
    /// <summary>
    /// A map of 1 to 100 key-value pairs that represent individual publish requests.
    ///
    /// - Each key is the ID of a scheduled shift you want to publish.
    /// - Each value is a `BulkPublishScheduledShiftsData` object that contains the
    /// `version` field or is an empty object.
    /// </summary>
    [JsonPropertyName("scheduled_shifts")]
    public Dictionary<string, BulkPublishScheduledShiftsData> ScheduledShifts { get; set; } =
        new Dictionary<string, BulkPublishScheduledShiftsData>();

    /// <summary>
    /// Indicates whether Square should send email notifications to team members and
    /// which team members should receive the notifications. This setting applies to all shifts
    /// specified in the bulk operation. The default value is `AFFECTED`.
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
