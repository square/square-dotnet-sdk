using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalActionQueryFilter
{
    /// <summary>
    /// `TerminalAction`s associated with a specific device. If no device is specified then all
    /// `TerminalAction`s for the merchant will be displayed.
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Time range for the beginning of the reporting period. Inclusive.
    /// Default value: The current time minus one day.
    /// Note that `TerminalAction`s are available for 30 days after creation.
    /// </summary>
    [JsonPropertyName("created_at")]
    public TimeRange? CreatedAt { get; set; }

    /// <summary>
    /// Filter results with the desired status of the `TerminalAction`
    /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED`
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Filter results with the requested ActionType.
    /// See [TerminalActionActionType](#type-terminalactionactiontype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public TerminalActionActionType? Type { get; set; }

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
