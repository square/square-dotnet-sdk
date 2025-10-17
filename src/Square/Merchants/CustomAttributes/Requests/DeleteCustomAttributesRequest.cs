using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Merchants.CustomAttributes;

[Serializable]
public record DeleteCustomAttributesRequest
{
    /// <summary>
    /// The ID of the target [merchant](entity:Merchant).
    /// </summary>
    [JsonIgnore]
    public required string MerchantId { get; set; }

    /// <summary>
    /// The key of the custom attribute to delete. This key must match the `key` of a custom
    /// attribute definition in the Square seller account. If the requesting application is not the
    /// definition owner, you must use the qualified key.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
