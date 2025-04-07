using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter events by event type.
/// </summary>
public record LoyaltyEventTypeFilter
{
    /// <summary>
    /// The loyalty event types used to filter the result.
    /// If multiple values are specified, the endpoint uses a
    /// logical OR to combine them.
    /// See [LoyaltyEventType](#type-loyaltyeventtype) for possible values
    /// </summary>
    [JsonPropertyName("types")]
    public IEnumerable<LoyaltyEventType> Types { get; set; } = new List<LoyaltyEventType>();

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
