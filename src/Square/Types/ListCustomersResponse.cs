using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the `ListCustomers` endpoint.
///
/// Either `errors` or `customers` is present in a given response (never both).
/// </summary>
public record ListCustomersResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The customer profiles associated with the Square account or an empty object (`{}`) if none are found.
    /// Only customer profiles with public information (`given_name`, `family_name`, `company_name`, `email_address`, or
    /// `phone_number`) are included in the response.
    /// </summary>
    [JsonPropertyName("customers")]
    public IEnumerable<Customer>? Customers { get; set; }

    /// <summary>
    /// A pagination cursor to retrieve the next set of results for the
    /// original query. A cursor is only present if the request succeeded and additional results
    /// are available.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The total count of customers associated with the Square account. Only customer profiles with public information
    /// (`given_name`, `family_name`, `company_name`, `email_address`, or `phone_number`) are counted. This field is present
    /// only if `count` is set to `true` in the request.
    /// </summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }

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
