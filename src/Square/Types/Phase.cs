using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a phase, which can override subscription phases as defined by plan_id
/// </summary>
[Serializable]
public record Phase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// id of subscription phase
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// index of phase in total subscription plan
    /// </summary>
    [JsonPropertyName("ordinal")]
    public long? Ordinal { get; set; }

    /// <summary>
    /// id of order to be used in billing
    /// </summary>
    [JsonPropertyName("order_template_id")]
    public string? OrderTemplateId { get; set; }

    /// <summary>
    /// the uid from the plan's phase in catalog
    /// </summary>
    [JsonPropertyName("plan_phase_uid")]
    public string? PlanPhaseUid { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
