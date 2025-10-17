using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about an `UNBLOCK` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
[Serializable]
public record GiftCardActivityUnblock : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reason the gift card was unblocked.
    /// See [Reason](#type-reason) for possible values
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = "CHARGEBACK_UNBLOCK";

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
