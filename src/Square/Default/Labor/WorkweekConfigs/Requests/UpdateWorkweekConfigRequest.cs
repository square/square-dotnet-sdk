using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor.WorkweekConfigs;

[Serializable]
public record UpdateWorkweekConfigRequest
{
    /// <summary>
    /// The UUID for the `WorkweekConfig` object being updated.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The updated `WorkweekConfig` object.
    /// </summary>
    [JsonPropertyName("workweek_config")]
    public required WorkweekConfig WorkweekConfig { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
