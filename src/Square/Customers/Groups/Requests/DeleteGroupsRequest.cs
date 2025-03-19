using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.Groups;

public record DeleteGroupsRequest
{
    /// <summary>
    /// The ID of the customer group to delete.
    /// </summary>
    [JsonIgnore]
    public required string GroupId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
