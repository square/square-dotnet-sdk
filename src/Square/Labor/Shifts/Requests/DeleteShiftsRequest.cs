using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.Shifts;

public record DeleteShiftsRequest
{
    /// <summary>
    /// The UUID for the `Shift` being deleted.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
