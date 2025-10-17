using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the arguments used to construct a new phase.
/// </summary>
[Serializable]
public record PhaseInput : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
