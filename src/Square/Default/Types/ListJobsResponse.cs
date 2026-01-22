using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a [ListJobs](api-endpoint:Team-ListJobs) response. Either `jobs` or `errors`
/// is present in the response. If additional results are available, the `cursor` field is also present.
/// </summary>
[Serializable]
public record ListJobsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The retrieved jobs. A single paged response contains up to 100 jobs.
    /// </summary>
    [JsonPropertyName("jobs")]
    public IEnumerable<Job>? Jobs { get; set; }

    /// <summary>
    /// An opaque cursor used to retrieve the next page of results. This field is present only
    /// if the request succeeded and additional results are available. For more information, see
    /// [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// The errors that occurred during the request.
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
