using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The filtering criteria. If the request specifies multiple filters,
/// the endpoint uses a logical AND to evaluate them.
/// </summary>
[Serializable]
public record LoyaltyEventFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
