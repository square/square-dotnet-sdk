using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Customers.Groups;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
