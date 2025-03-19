using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalRefundQueryFilter
{
    /// <summary>
    /// `TerminalRefund` objects associated with a specific device. If no device is specified, then all
    /// `TerminalRefund` objects for the signed-in account are displayed.
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// The timestamp for the beginning of the reporting period, in RFC 3339 format. Inclusive.
    /// Default value: The current time minus one day.
    /// Note that `TerminalRefund`s are available for 30 days after creation.
    /// </summary>
    [JsonPropertyName("created_at")]
    public TimeRange? CreatedAt { get; set; }

    /// <summary>
    /// Filtered results with the desired status of the `TerminalRefund`.
    /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, or `COMPLETED`.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
