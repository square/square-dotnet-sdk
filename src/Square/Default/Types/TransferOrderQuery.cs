using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Query parameters for searching transfer orders
/// </summary>
[Serializable]
public record TransferOrderQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Filter criteria
    /// </summary>
    [JsonPropertyName("filter")]
    public TransferOrderFilter? Filter { get; set; }

    /// <summary>
    /// Sort configuration
    /// </summary>
    [JsonPropertyName("sort")]
    public TransferOrderSort? Sort { get; set; }

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
