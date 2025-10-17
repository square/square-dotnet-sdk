using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.Groups;

[Serializable]
public record RemoveGroupsRequest
{
    /// <summary>
    /// The ID of the customer to remove from the group.
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The ID of the customer group to remove the customer from.
    /// </summary>
    [JsonIgnore]
    public required string GroupId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
