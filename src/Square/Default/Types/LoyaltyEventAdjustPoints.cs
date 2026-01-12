using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Provides metadata when the event `type` is `ADJUST_POINTS`.
/// </summary>
[Serializable]
public record LoyaltyEventAdjustPoints : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square-assigned ID of the [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public string? LoyaltyProgramId { get; set; }

    /// <summary>
    /// The number of points added or removed.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The reason for the adjustment of points.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

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
