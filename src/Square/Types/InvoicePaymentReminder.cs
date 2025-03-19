using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a payment request reminder (automatic notification) that Square sends
/// to the customer. You configure a reminder relative to the payment request
/// `due_date`.
/// </summary>
public record InvoicePaymentReminder
{
    /// <summary>
    /// A Square-assigned ID that uniquely identifies the reminder within the
    /// `InvoicePaymentRequest`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The number of days before (a negative number) or after (a positive number)
    /// the payment request `due_date` when the reminder is sent. For example, -3 indicates that
    /// the reminder should be sent 3 days before the payment request `due_date`.
    /// </summary>
    [JsonPropertyName("relative_scheduled_days")]
    public int? RelativeScheduledDays { get; set; }

    /// <summary>
    /// The reminder message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The status of the reminder.
    /// See [InvoicePaymentReminderStatus](#type-invoicepaymentreminderstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public InvoicePaymentReminderStatus? Status { get; set; }

    /// <summary>
    /// If sent, the timestamp when the reminder was sent, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("sent_at")]
    public string? SentAt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
