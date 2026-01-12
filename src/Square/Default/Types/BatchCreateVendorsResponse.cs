using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an output from a call to [BulkCreateVendors](api-endpoint:Vendors-BulkCreateVendors).
/// </summary>
[Serializable]
public record BatchCreateVendorsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A set of [CreateVendorResponse](entity:CreateVendorResponse) objects encapsulating successfully created [Vendor](entity:Vendor)
    /// objects or error responses for failed attempts. The set is represented by
    /// a collection of idempotency-key/`Vendor`-object or idempotency-key/error-object pairs. The idempotency keys correspond to those specified
    /// in the input.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, CreateVendorResponse>? Responses { get; set; }

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
