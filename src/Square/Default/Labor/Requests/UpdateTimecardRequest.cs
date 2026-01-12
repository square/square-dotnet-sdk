using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

[Serializable]
public record UpdateTimecardRequest
{
    /// <summary>
    /// The ID of the object being updated.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The updated `Timecard` object.
    /// </summary>
    [JsonPropertyName("timecard")]
    public required Timecard Timecard { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
