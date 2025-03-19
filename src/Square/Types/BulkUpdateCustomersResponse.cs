using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields included in the response body from the
/// [BulkUpdateCustomers](api-endpoint:Customers-BulkUpdateCustomers) endpoint.
/// </summary>
public record BulkUpdateCustomersResponse
{
    /// <summary>
    /// A map of responses that correspond to individual update requests, represented by
    /// key-value pairs.
    ///
    /// Each key is the customer ID that was specified for an update request and each value
    /// is the corresponding response.
    /// If the request succeeds, the value is the updated customer profile.
    /// If the request fails, the value contains any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, UpdateCustomerResponse>? Responses { get; set; }

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
