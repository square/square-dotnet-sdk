using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Vendors;

public record BatchCreateVendorsRequest
{
    /// <summary>
    /// Specifies a set of new [Vendor](entity:Vendor) objects as represented by a collection of idempotency-key/`Vendor`-object pairs.
    /// </summary>
    [JsonPropertyName("vendors")]
    public Dictionary<string, Vendor> Vendors { get; set; } = new Dictionary<string, Vendor>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
