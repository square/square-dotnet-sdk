using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BulkUpdateCustomersRequest
{
    /// <summary>
    /// A map of 1 to 100 individual update requests, represented by `customer ID: { customer data }`
    /// key-value pairs.
    ///
    /// Each key is the ID of the [customer profile](entity:Customer) to update. To update a customer profile
    /// that was created by merging existing profiles, provide the ID of the newly created profile.
    ///
    /// Each value contains the updated customer data. Only new or changed fields are required. To add or
    /// update a field, specify the new value. To remove a field, specify `null`.
    /// </summary>
    [JsonPropertyName("customers")]
    public Dictionary<string, BulkUpdateCustomerData> Customers { get; set; } =
        new Dictionary<string, BulkUpdateCustomerData>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
