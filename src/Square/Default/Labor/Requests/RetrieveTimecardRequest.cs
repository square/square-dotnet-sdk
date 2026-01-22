using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record RetrieveTimecardRequest
{
    /// <summary>
    /// The UUID for the `Timecard` being retrieved.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
