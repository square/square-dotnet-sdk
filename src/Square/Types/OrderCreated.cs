using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record OrderCreated
{
    /// <summary>
    /// The order's unique ID.
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
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The ID of the seller location that this order is associated with.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The state of the order.
    /// See [OrderState](#type-orderstate) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public OrderState? State { get; set; }

    /// <summary>
    /// The timestamp for when the order was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

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
