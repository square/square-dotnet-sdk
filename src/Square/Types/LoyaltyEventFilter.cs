using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The filtering criteria. If the request specifies multiple filters,
/// the endpoint uses a logical AND to evaluate them.
/// </summary>
public record LoyaltyEventFilter
{
    /// <summary>
    /// Filter events by loyalty account.
    /// </summary>
    [JsonPropertyName("loyalty_account_filter")]
    public LoyaltyEventLoyaltyAccountFilter? LoyaltyAccountFilter { get; set; }

    /// <summary>
    /// Filter events by event type.
    /// </summary>
    [JsonPropertyName("type_filter")]
    public LoyaltyEventTypeFilter? TypeFilter { get; set; }

    /// <summary>
    /// Filter events by date time range.
    /// For each range, the start time is inclusive and the end time
    /// is exclusive.
    /// </summary>
    [JsonPropertyName("date_time_filter")]
    public LoyaltyEventDateTimeFilter? DateTimeFilter { get; set; }

    /// <summary>
    /// Filter events by location.
    /// </summary>
    [JsonPropertyName("location_filter")]
    public LoyaltyEventLocationFilter? LocationFilter { get; set; }

    /// <summary>
    /// Filter events by the order associated with the event.
    /// </summary>
    [JsonPropertyName("order_filter")]
    public LoyaltyEventOrderFilter? OrderFilter { get; set; }

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
