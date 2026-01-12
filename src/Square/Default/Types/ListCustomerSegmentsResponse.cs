using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body for requests to the `ListCustomerSegments` endpoint.
///
/// Either `errors` or `segments` is present in a given response (never both).
/// </summary>
[Serializable]
public record ListCustomerSegmentsResponse : IJsonOnDeserialized
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
    /// The list of customer segments belonging to the associated Square account.
    /// </summary>
    [JsonPropertyName("segments")]
    public IEnumerable<CustomerSegment>? Segments { get; set; }

    /// <summary>
    /// A pagination cursor to be used in subsequent calls to `ListCustomerSegments`
    /// to retrieve the next set of query results. The cursor is only present if the request succeeded and
    /// additional results are available.
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
