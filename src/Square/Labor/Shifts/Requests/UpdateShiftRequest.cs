using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor.Shifts;

public record UpdateShiftRequest
{
    /// <summary>
    /// The ID of the object being updated.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The updated `Shift` object.
    /// </summary>
    [JsonPropertyName("shift")]
    public required Shift Shift { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
