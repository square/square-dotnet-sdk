using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Customers;

[Serializable]
public record DeleteCustomersRequest
{
    /// <summary>
    /// The ID of the customer to delete.
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The current version of the customer profile.
    ///
    /// As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile).
    /// </summary>
    [JsonIgnore]
    public long? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
