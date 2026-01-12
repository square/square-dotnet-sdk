using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Customers;

[Serializable]
public record GetCustomersRequest
{
    /// <summary>
    /// The ID of the customer to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
