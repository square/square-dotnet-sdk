using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filtering criteria to use for a `SearchOrders` request. Multiple filters
/// are ANDed together.
/// </summary>
[Serializable]
public record SearchOrdersFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Filter by [OrderState](entity:OrderState).
    /// </summary>
    [JsonPropertyName("state_filter")]
    public SearchOrdersStateFilter? StateFilter { get; set; }

    /// <summary>
    /// Filter for results within a time range.
    ///
    /// __Important:__ If you filter for orders by time range, you must set `SearchOrdersSort`
    /// to sort by the same field.
    /// [Learn more about filtering orders by time range.](https://developer.squareup.com/docs/orders-api/manage-orders/search-orders#important-note-about-filtering-orders-by-time-range)
    /// </summary>
    [JsonPropertyName("date_time_filter")]
    public SearchOrdersDateTimeFilter? DateTimeFilter { get; set; }

    /// <summary>
    /// Filter by the fulfillment type or state.
    /// </summary>
    [JsonPropertyName("fulfillment_filter")]
    public SearchOrdersFulfillmentFilter? FulfillmentFilter { get; set; }

    /// <summary>
    /// Filter by the source of the order.
    /// </summary>
    [JsonPropertyName("source_filter")]
    public SearchOrdersSourceFilter? SourceFilter { get; set; }

    /// <summary>
    /// Filter by customers associated with the order.
    /// </summary>
    [JsonPropertyName("customer_filter")]
    public SearchOrdersCustomerFilter? CustomerFilter { get; set; }

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
