using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [BulkUpsertCustomerCustomAttributes](api-endpoint:CustomerCustomAttributes-BulkUpsertCustomerCustomAttributes) response,
/// which contains a map of responses that each corresponds to an individual upsert request.
/// </summary>
public record BatchUpsertCustomerCustomAttributesResponse
{
    /// <summary>
    /// A map of responses that correspond to individual upsert requests. Each response has the
    /// same ID as the corresponding request and contains either a `customer_id` and `custom_attribute` or an `errors` field.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        BatchUpsertCustomerCustomAttributesResponseCustomerCustomAttributeUpsertResponse
    >? Values { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
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
