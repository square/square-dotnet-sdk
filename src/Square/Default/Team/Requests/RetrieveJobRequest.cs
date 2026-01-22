using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record RetrieveJobRequest
{
    /// <summary>
    /// The ID of the job to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string JobId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
