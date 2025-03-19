using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Terminal.Refunds;

public record CreateTerminalRefundRequest
{
    /// <summary>
    /// A unique string that identifies this `CreateRefund` request. Keys can be any valid string but
    /// must be unique for every `CreateRefund` request.
    ///
    /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The refund to create.
    /// </summary>
    [JsonPropertyName("refund")]
    public TerminalRefund? Refund { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
