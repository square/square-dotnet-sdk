using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Customers;

[Serializable]
public record AddGroupsRequest
{
    /// <summary>
    /// The ID of the customer to add to a group.
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The ID of the customer group to add the customer to.
    /// </summary>
    [JsonIgnore]
    public required string GroupId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
