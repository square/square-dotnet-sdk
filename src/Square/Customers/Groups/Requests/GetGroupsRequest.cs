using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.Groups;

[Serializable]
public record GetGroupsRequest
{
    /// <summary>
    /// The ID of the customer group to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string GroupId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
