using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.Shifts;

[Serializable]
public record GetShiftsRequest
{
    /// <summary>
    /// The UUID for the `Shift` being retrieved.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
