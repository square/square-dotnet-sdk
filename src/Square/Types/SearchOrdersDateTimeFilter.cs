using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter for `Order` objects based on whether their `CREATED_AT`,
/// `CLOSED_AT`, or `UPDATED_AT` timestamps fall within a specified time range.
/// You can specify the time range and which timestamp to filter for. You can filter
/// for only one time range at a time.
///
/// For each time range, the start time and end time are inclusive. If the end time
/// is absent, it defaults to the time of the first request for the cursor.
///
/// __Important:__ If you use the `DateTimeFilter` in a `SearchOrders` query,
/// you must set the `sort_field` in [OrdersSort](entity:SearchOrdersSort)
/// to the same field you filter for. For example, if you set the `CLOSED_AT` field
/// in `DateTimeFilter`, you must set the `sort_field` in `SearchOrdersSort` to
/// `CLOSED_AT`. Otherwise, `SearchOrders` throws an error.
/// [Learn more about filtering orders by time range.](https://developer.squareup.com/docs/orders-api/manage-orders/search-orders#important-note-about-filtering-orders-by-time-range)
/// </summary>
public record SearchOrdersDateTimeFilter
{
    /// <summary>
    /// The time range for filtering on the `created_at` timestamp. If you use this
    /// value, you must set the `sort_field` in the `OrdersSearchSort` object to
    /// `CREATED_AT`.
    /// </summary>
    [JsonPropertyName("created_at")]
    public TimeRange? CreatedAt { get; set; }

    /// <summary>
    /// The time range for filtering on the `updated_at` timestamp. If you use this
    /// value, you must set the `sort_field` in the `OrdersSearchSort` object to
    /// `UPDATED_AT`.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public TimeRange? UpdatedAt { get; set; }

    /// <summary>
    /// The time range for filtering on the `closed_at` timestamp. If you use this
    /// value, you must set the `sort_field` in the `OrdersSearchSort` object to
    /// `CLOSED_AT`.
    /// </summary>
    [JsonPropertyName("closed_at")]
    public TimeRange? ClosedAt { get; set; }

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
