using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

[Serializable]
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
