using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Merchants;

[Serializable]
public record GetMerchantsRequest
{
    /// <summary>
    /// The ID of the merchant to retrieve. If the string "me" is supplied as the ID,
    /// then retrieve the merchant that is currently accessible to this call.
    /// </summary>
    [JsonIgnore]
    public required string MerchantId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
