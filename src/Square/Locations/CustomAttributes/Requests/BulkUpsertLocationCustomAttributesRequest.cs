using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Locations.CustomAttributes;

public record BulkUpsertLocationCustomAttributesRequest
{
    /// <summary>
    /// A map containing 1 to 25 individual upsert requests. For each request, provide an
    /// arbitrary ID that is unique for this `BulkUpsertLocationCustomAttributes` request and the
    /// information needed to create or update a custom attribute.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
    > Values { get; set; } =
        new Dictionary<
            string,
            BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
        >();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
