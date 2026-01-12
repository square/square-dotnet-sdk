using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Invoices;

[Serializable]
public record CreateInvoiceRequest
{
    /// <summary>
    /// The invoice to create.
    /// </summary>
    [JsonPropertyName("invoice")]
    public required Invoice Invoice { get; set; }

    /// <summary>
    /// A unique string that identifies the `CreateInvoice` request. If you do not
    /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
    /// treats each request as independent.
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
