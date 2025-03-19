using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CreateJob](api-endpoint:Team-CreateJob) response. Either `job` or `errors`
/// is present in the response.
/// </summary>
public record CreateJobResponse
{
    /// <summary>
    /// The new job.
    /// </summary>
    [JsonPropertyName("job")]
    public Job? Job { get; set; }

    /// <summary>
    /// The errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
