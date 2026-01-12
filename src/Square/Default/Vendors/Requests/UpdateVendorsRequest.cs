using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Vendors;

[Serializable]
public record UpdateVendorsRequest
{
    /// <summary>
    /// ID of the [Vendor](entity:Vendor) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string VendorId { get; set; }

    [JsonIgnore]
    public required UpdateVendorRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
