using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the naming used for loyalty points.
/// </summary>
[Serializable]
public record LoyaltyProgramTerminology : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A singular unit for a point (for example, 1 point is called 1 star).
    /// </summary>
    [JsonPropertyName("one")]
    public required string One { get; set; }

    /// <summary>
    /// A plural unit for point (for example, 10 points is called 10 stars).
    /// </summary>
    [JsonPropertyName("other")]
    public required string Other { get; set; }

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
