using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers;

public record BulkRetrieveCustomersRequest
{
    /// <summary>
    /// The IDs of the [customer profiles](entity:Customer) to retrieve.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string> CustomerIds { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
