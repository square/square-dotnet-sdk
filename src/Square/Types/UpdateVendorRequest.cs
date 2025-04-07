using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an input to a call to [UpdateVendor](api-endpoint:Vendors-UpdateVendor).
/// </summary>
public record UpdateVendorRequest
{
    /// <summary>
    /// A client-supplied, universally unique identifier (UUID) for the
    /// request.
    ///
    /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) in the
    /// [API Development 101](https://developer.squareup.com/docs/buildbasics) section for more
    /// information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The specified [Vendor](entity:Vendor) to be updated.
    /// </summary>
    [JsonPropertyName("vendor")]
    public required Vendor Vendor { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
