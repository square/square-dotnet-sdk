using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListCustomerGroups](api-endpoint:CustomerGroups-ListCustomerGroups) endpoint.
///
/// Either `errors` or `groups` is present in a given response (never both).
/// </summary>
[Serializable]
public record ListCustomerGroupsResponse : IJsonOnDeserialized
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
    /// A list of customer groups belonging to the current seller.
    /// </summary>
    [JsonPropertyName("groups")]
    public IEnumerable<CustomerGroup>? Groups { get; set; }

    /// <summary>
    /// A pagination cursor to retrieve the next set of results for your
    /// original query to the endpoint. This value is present only if the request
    /// succeeded and additional results are available.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
