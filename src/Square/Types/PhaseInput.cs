using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the arguments used to construct a new phase.
/// </summary>
public record PhaseInput
{
    /// <summary>
    /// index of phase in total subscription plan
    /// </summary>
    [JsonPropertyName("ordinal")]
    public required long Ordinal { get; set; }

    /// <summary>
    /// id of order to be used in billing
    /// </summary>
    [JsonPropertyName("order_template_id")]
    public string? OrderTemplateId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
