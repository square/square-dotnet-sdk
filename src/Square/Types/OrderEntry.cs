using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A lightweight description of an [order](entity:Order) that is returned when
/// `returned_entries` is `true` on a [SearchOrdersRequest](api-endpoint:Orders-SearchOrders).
/// </summary>
public record OrderEntry
{
    /// <summary>
    /// The ID of the order.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The version number, which is incremented each time an update is committed to the order.
    /// Orders that were not created through the API do not include a version number and
    /// therefore cannot be updated.
    ///
    /// [Read more about working with versions.](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders)
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The location ID the order belongs to.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

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
