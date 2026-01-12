using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Orders.CustomAttributeDefinitions;

[Serializable]
public record DeleteCustomAttributeDefinitionsRequest
{
    /// <summary>
    /// The key of the custom attribute definition to delete.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
