using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The parameters of a `Timecard` search query, which includes filter and sort options.
/// </summary>
[Serializable]
public record TimecardQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Query filter options.
    /// </summary>
    [JsonPropertyName("filter")]
    public TimecardFilter? Filter { get; set; }

    /// <summary>
    /// Sort order details.
    /// </summary>
    [JsonPropertyName("sort")]
    public TimecardSort? Sort { get; set; }

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
