using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Vendors;

[Serializable]
public record BatchGetVendorsRequest
{
    /// <summary>
    /// IDs of the [Vendor](entity:Vendor) objects to retrieve.
    /// </summary>
    [JsonPropertyName("vendor_ids")]
    public IEnumerable<string>? VendorIds { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
