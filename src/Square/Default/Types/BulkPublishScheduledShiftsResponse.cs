using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a [BulkPublishScheduledShifts](api-endpoint:Labor-BulkPublishScheduledShifts) response.
/// Either `scheduled_shifts` or `errors` is present in the response.
/// </summary>
[Serializable]
public record BulkPublishScheduledShiftsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
