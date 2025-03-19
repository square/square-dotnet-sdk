using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor.BreakTypes;

public record UpdateBreakTypeRequest
{
    /// <summary>
    /// The UUID for the `BreakType` being updated.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The updated `BreakType`.
    /// </summary>
    [JsonPropertyName("break_type")]
    public required BreakType BreakType { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
