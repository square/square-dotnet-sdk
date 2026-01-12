using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an output from a call to [BulkUpdateVendors](api-endpoint:Vendors-BulkUpdateVendors).
/// </summary>
[Serializable]
public record BatchUpdateVendorsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Errors encountered when the request fails.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A set of [UpdateVendorResponse](entity:UpdateVendorResponse) objects encapsulating successfully created [Vendor](entity:Vendor)
    /// objects or error responses for failed attempts. The set is represented by a collection of `Vendor`-ID/`UpdateVendorResponse`-object or
    /// `Vendor`-ID/error-object pairs.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, UpdateVendorResponse>? Responses { get; set; }

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
