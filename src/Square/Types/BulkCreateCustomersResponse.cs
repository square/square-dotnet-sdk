using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields included in the response body from the
/// [BulkCreateCustomers](api-endpoint:Customers-BulkCreateCustomers) endpoint.
/// </summary>
public record BulkCreateCustomersResponse
{
    /// <summary>
    /// A map of responses that correspond to individual create requests, represented by
    /// key-value pairs.
    ///
    /// Each key is the idempotency key that was provided for a create request and each value
    /// is the corresponding response.
    /// If the request succeeds, the value is the new customer profile.
    /// If the request fails, the value contains any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, CreateCustomerResponse>? Responses { get; set; }

    /// <summary>
    /// Any top-level errors that prevented the bulk operation from running.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
