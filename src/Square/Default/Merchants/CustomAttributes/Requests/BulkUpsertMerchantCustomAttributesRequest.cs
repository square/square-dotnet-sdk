using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Merchants.CustomAttributes;

[Serializable]
public record BulkUpsertMerchantCustomAttributesRequest
{
    /// <summary>
    /// A map containing 1 to 25 individual upsert requests. For each request, provide an
    /// arbitrary ID that is unique for this `BulkUpsertMerchantCustomAttributes` request and the
    /// information needed to create or update a custom attribute.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
    > Values { get; set; } =
        new Dictionary<
            string,
            BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
        >();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
