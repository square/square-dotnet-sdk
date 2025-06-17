using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record LaborScheduledShiftUpdatedEventData
{
    /// <summary>
    /// The type of object affected by the event. For this event, the value is `scheduled_shift`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The ID of the affected `ScheduledShift`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An object containing the affected `ScheduledShift`.
    /// </summary>
    [JsonPropertyName("object")]
    public LaborScheduledShiftUpdatedEventObject? Object { get; set; }

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
