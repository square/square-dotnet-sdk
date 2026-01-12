using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an [UpdateScheduledShift](api-endpoint:Labor-UpdateScheduledShift) response.
/// Either `scheduled_shift` or `errors` is present in the response.
/// </summary>
[Serializable]
public record UpdateScheduledShiftResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The updated scheduled shift. To make the changes public, call
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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
