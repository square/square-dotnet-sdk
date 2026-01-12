using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Specifies a decimal number range.
/// </summary>
[Serializable]
public record FloatNumberRange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A decimal value indicating where the range starts.
    /// </summary>
    [JsonPropertyName("start_at")]
    public string? StartAt { get; set; }

    /// <summary>
    /// A decimal value indicating where the range ends.
    /// </summary>
    [JsonPropertyName("end_at")]
    public string? EndAt { get; set; }

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
