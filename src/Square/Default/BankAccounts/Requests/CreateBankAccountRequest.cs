using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CreateBankAccountRequest
{
    /// <summary>
    /// Unique ID. For more information, see the
    /// [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The ID of the source that represents the bank account information to be stored. This field
    /// accepts the payment token created by WebSDK
    /// </summary>
    [JsonPropertyName("source_id")]
    public required string SourceId { get; set; }

    /// <summary>
    /// The ID of the customer associated with the bank account to be stored.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
