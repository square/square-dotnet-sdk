using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Provides metadata when the event `type` is `ACCUMULATE_POINTS`.
/// </summary>
[Serializable]
public record LoyaltyEventAccumulatePoints : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("loyalty_program_id")]
    public string? LoyaltyProgramId { get; set; }

    /// <summary>
    /// The number of points accumulated by the event.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// The ID of the [order](entity:Order) for which the buyer accumulated the points.
    /// This field is returned only if the Orders API is used to process orders.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

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
