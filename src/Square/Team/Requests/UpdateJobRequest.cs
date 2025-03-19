using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Team;

public record UpdateJobRequest
{
    /// <summary>
    /// The ID of the job to update.
    /// </summary>
    [JsonIgnore]
    public required string JobId { get; set; }

    /// <summary>
    /// The job with the updated fields, either `title`, `is_tip_eligible`, or both. Only changed fields need
    /// to be included in the request. Optionally include `version` to enable optimistic concurrency control.
    /// </summary>
    [JsonPropertyName("job")]
    public required Job Job { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
