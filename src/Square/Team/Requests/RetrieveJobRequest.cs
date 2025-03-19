using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Team;

public record RetrieveJobRequest
{
    /// <summary>
    /// The ID of the job to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string JobId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
