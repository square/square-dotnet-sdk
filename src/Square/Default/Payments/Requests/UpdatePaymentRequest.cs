using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Payments;

[Serializable]
public record UpdatePaymentRequest
{
    /// <summary>
    /// The ID of the payment to update.
    /// </summary>
    [JsonIgnore]
    public required string PaymentId { get; set; }

    /// <summary>
    /// The updated `Payment` object.
    /// </summary>
    [JsonPropertyName("payment")]
    public Payment? Payment { get; set; }

    /// <summary>
    /// A unique string that identifies this `UpdatePayment` request. Keys can be any valid string
    /// but must be unique for every `UpdatePayment` request.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
