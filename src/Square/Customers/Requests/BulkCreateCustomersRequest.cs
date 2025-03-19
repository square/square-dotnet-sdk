using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Customers;

public record BulkCreateCustomersRequest
{
    /// <summary>
    /// A map of 1 to 100 individual create requests, represented by `idempotency key: { customer data }`
    /// key-value pairs.
    ///
    /// Each key is an [idempotency key](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency)
    /// that uniquely identifies the create request. Each value contains the customer data used to create the
    /// customer profile.
    /// </summary>
    [JsonPropertyName("customers")]
    public Dictionary<string, BulkCreateCustomerData> Customers { get; set; } =
        new Dictionary<string, BulkCreateCustomerData>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
