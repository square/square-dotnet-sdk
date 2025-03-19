using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Customers.Groups;

public record UpdateCustomerGroupRequest
{
    /// <summary>
    /// The ID of the customer group to update.
    /// </summary>
    [JsonIgnore]
    public required string GroupId { get; set; }

    /// <summary>
    /// The `CustomerGroup` object including all the updates you want to make.
    /// </summary>
    [JsonPropertyName("group")]
    public required CustomerGroup Group { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
