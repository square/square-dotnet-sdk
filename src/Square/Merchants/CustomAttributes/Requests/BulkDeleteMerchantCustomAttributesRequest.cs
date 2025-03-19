using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributes;

public record BulkDeleteMerchantCustomAttributesRequest
{
    /// <summary>
    /// The data used to update the `CustomAttribute` objects.
    /// The keys must be unique and are used to map to the corresponding response.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
    > Values { get; set; } =
        new Dictionary<
            string,
            BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
        >();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
