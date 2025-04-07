using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [ListJobs](api-endpoint:Team-ListJobs) response. Either `jobs` or `errors`
/// is present in the response. If additional results are available, the `cursor` field is also present.
/// </summary>
public record ListJobsResponse
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
