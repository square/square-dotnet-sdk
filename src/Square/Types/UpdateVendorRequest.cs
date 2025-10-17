using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an input to a call to [UpdateVendor](api-endpoint:Vendors-UpdateVendor).
/// </summary>
[Serializable]
public record UpdateVendorRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
