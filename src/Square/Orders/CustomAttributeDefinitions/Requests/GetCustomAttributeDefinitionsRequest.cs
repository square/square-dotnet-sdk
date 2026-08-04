using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Orders.CustomAttributeDefinitions;

[Serializable]
public record GetCustomAttributeDefinitionsRequest
{
    /// <summary>
    /// The key of the custom attribute definition to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <summary>
    /// To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control, include this optional field and specify the current version of the custom attribute.
    /// </summary>
    [JsonIgnore]
    public int? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
