using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor;

[Serializable]
public record DeleteTimecardRequest
{
    /// <summary>
    /// The UUID for the `Timecard` being deleted.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
