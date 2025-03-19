using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Invoices;

public record PublishInvoiceRequest
{
    /// <summary>
    /// The ID of the invoice to publish.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    /// <summary>
    /// The version of the [invoice](entity:Invoice) to publish.
    /// This must match the current version of the invoice; otherwise, the request is rejected.
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// A unique string that identifies the `PublishInvoice` request. If you do not
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
