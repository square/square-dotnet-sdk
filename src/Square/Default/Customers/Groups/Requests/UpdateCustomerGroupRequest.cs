using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Customers.Groups;

[Serializable]
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
