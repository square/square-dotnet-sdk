using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the `ListCustomers` endpoint.
///
/// Either `errors` or `customers` is present in a given response (never both).
/// </summary>
[Serializable]
public record ListCustomersResponse : IJsonOnDeserialized
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
