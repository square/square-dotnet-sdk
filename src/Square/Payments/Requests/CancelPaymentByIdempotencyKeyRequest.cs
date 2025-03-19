using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Payments;

public record CancelPaymentByIdempotencyKeyRequest
{
    /// <summary>
    /// The `idempotency_key` identifying the payment to be canceled.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
