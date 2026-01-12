using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields included in the response body from the
/// [BulkRetrieveCustomers](api-endpoint:Customers-BulkRetrieveCustomers) endpoint.
/// </summary>
[Serializable]
public record BulkRetrieveCustomersResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A map of responses that correspond to individual retrieve requests, represented by
    /// key-value pairs.
    ///
    /// Each key is the customer ID that was specified for a retrieve request and each value
    /// is the corresponding response.
    /// If the request succeeds, the value is the requested customer profile.
    /// If the request fails, the value contains any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, GetCustomerResponse>? Responses { get; set; }

    /// <summary>
    /// Any top-level errors that prevented the bulk operation from running.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
