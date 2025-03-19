using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Vendors;

public record UpdateVendorsRequest
{
    /// <summary>
    /// ID of the [Vendor](entity:Vendor) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string VendorId { get; set; }

    [JsonIgnore]
    public required UpdateVendorRequest Body { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
