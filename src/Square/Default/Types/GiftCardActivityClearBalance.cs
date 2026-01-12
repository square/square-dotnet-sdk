using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents details about a `CLEAR_BALANCE` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
[Serializable]
public record GiftCardActivityClearBalance : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reason the gift card balance was cleared.
    /// See [Reason](#type-reason) for possible values
    /// </summary>
    [JsonPropertyName("reason")]
    public required GiftCardActivityClearBalanceReason Reason { get; set; }

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
