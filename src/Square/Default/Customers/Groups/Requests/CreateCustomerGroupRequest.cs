using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Customers;

[Serializable]
public record CreateCustomerGroupRequest
{
    /// <summary>
    /// The idempotency key for the request. For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The customer group to create.
    /// </summary>
    [JsonPropertyName("group")]
    public required CustomerGroup Group { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
