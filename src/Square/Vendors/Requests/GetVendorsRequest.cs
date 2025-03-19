using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Vendors;

public record GetVendorsRequest
{
    /// <summary>
    /// ID of the [Vendor](entity:Vendor) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string VendorId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
