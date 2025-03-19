using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Vendors;

public record CreateVendorRequest
{
    /// <summary>
    /// A client-supplied, universally unique identifier (UUID) to make this [CreateVendor](api-endpoint:Vendors-CreateVendor) call idempotent.
    ///
    /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) in the
    /// [API Development 101](https://developer.squareup.com/docs/buildbasics) section for more
    /// information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The requested [Vendor](entity:Vendor) to be created.
    /// </summary>
    [JsonPropertyName("vendor")]
    public Vendor? Vendor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
