using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Terminal.Checkouts;

public record CreateTerminalCheckoutRequest
{
    /// <summary>
    /// A unique string that identifies this `CreateCheckout` request. Keys can be any valid string but
    /// must be unique for every `CreateCheckout` request.
    ///
    /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The checkout to create.
    /// </summary>
    [JsonPropertyName("checkout")]
    public required TerminalCheckout Checkout { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
