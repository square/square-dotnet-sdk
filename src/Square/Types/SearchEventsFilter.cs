using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Criteria to filter events by.
/// </summary>
public record SearchEventsFilter
{
    /// <summary>
    /// Filter events by event types.
    /// </summary>
    [JsonPropertyName("event_types")]
    public IEnumerable<string>? EventTypes { get; set; }

    /// <summary>
    /// Filter events by merchant.
    /// </summary>
    [JsonPropertyName("merchant_ids")]
    public IEnumerable<string>? MerchantIds { get; set; }

    /// <summary>
    /// Filter events by location.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// Filter events by when they were created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public TimeRange? CreatedAt { get; set; }

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
