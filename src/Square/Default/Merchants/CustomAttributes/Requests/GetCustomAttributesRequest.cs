using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Merchants;

[Serializable]
public record GetCustomAttributesRequest
{
    /// <summary>
    /// The ID of the target [merchant](entity:Merchant).
    /// </summary>
    [JsonIgnore]
    public required string MerchantId { get; set; }

    /// <summary>
    /// The key of the custom attribute to retrieve. This key must match the `key` of a custom
    /// attribute definition in the Square seller account. If the requesting application is not the
    /// definition owner, you must use the qualified key.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <summary>
    /// Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of
    /// the custom attribute. Set this parameter to `true` to get the name and description of the custom
    /// attribute, information about the data type, or other definition details. The default value is `false`.
    /// </summary>
    [JsonIgnore]
    public bool? WithDefinition { get; set; }

    /// <summary>
    /// The current version of the custom attribute, which is used for strongly consistent reads to
    /// guarantee that you receive the most up-to-date data. When included in the request, Square
    /// returns the specified version or a higher version if one exists. If the specified version is
    /// higher than the current version, Square returns a `BAD_REQUEST` error.
    /// </summary>
    [JsonIgnore]
    public int? Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
