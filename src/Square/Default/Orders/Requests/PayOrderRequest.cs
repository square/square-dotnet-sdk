using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Orders;

[Serializable]
public record PayOrderRequest
{
    /// <summary>
    /// The ID of the order being paid.
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <summary>
    /// A value you specify that uniquely identifies this request among requests you have sent. If
    /// you are unsure whether a particular payment request was completed successfully, you can reattempt
    /// it with the same idempotency key without worrying about duplicate payments.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The version of the order being paid. If not supplied, the latest version will be paid.
    /// </summary>
    [JsonPropertyName("order_version")]
    public int? OrderVersion { get; set; }

    /// <summary>
    /// The IDs of the [payments](entity:Payment) to collect.
    /// The payment total must match the order total.
    /// </summary>
    [JsonPropertyName("payment_ids")]
    public IEnumerable<string>? PaymentIds { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
