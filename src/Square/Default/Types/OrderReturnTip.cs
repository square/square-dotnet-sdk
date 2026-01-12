using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A tip being returned.
/// </summary>
[Serializable]
public record OrderReturnTip : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID that identifies the tip only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The amount of tip being returned
    /// --
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// The tender `uid` from the order that contains the original application of this tip.
    /// </summary>
    [JsonPropertyName("source_tender_uid")]
    public string? SourceTenderUid { get; set; }

    /// <summary>
    /// The tender `id` from the order that contains the original application of this tip.
    /// </summary>
    [JsonPropertyName("source_tender_id")]
    public string? SourceTenderId { get; set; }

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
