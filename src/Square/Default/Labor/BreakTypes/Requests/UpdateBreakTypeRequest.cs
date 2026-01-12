using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor.BreakTypes;

[Serializable]
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
