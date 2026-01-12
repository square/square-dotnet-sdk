using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Vendors;

[Serializable]
public record BatchUpdateVendorsRequest
{
    /// <summary>
    /// A set of [UpdateVendorRequest](entity:UpdateVendorRequest) objects encapsulating to-be-updated [Vendor](entity:Vendor)
    /// objects. The set is represented by  a collection of `Vendor`-ID/`UpdateVendorRequest`-object pairs.
    /// </summary>
    [JsonPropertyName("vendors")]
    public Dictionary<string, UpdateVendorRequest> Vendors { get; set; } =
        new Dictionary<string, UpdateVendorRequest>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
