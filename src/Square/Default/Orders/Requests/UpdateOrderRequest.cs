using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record UpdateOrderRequest
{
    /// <summary>
    /// The ID of the order to update.
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <summary>
    /// The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects)
    /// containing only the fields to update and the version to which the update is
    /// being applied.
    /// </summary>
    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    /// <summary>
    /// The [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete)
    /// fields to clear. For example, `line_items[uid].note`.
    /// For more information, see [Deleting fields](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#deleting-fields).
    /// </summary>
    [JsonPropertyName("fields_to_clear")]
    public IEnumerable<string>? FieldsToClear { get; set; }

    /// <summary>
    /// A value you specify that uniquely identifies this update request.
    ///
    /// If you are unsure whether a particular update was applied to an order successfully,
    /// you can reattempt it with the same idempotency key without
    /// worrying about creating duplicate updates to the order.
    /// The latest order version is returned.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
