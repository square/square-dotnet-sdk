using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the Square processing fee.
/// </summary>
[Serializable]
public record ProcessingFee : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The timestamp of when the fee takes effect, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("effective_at")]
    public string? EffectiveAt { get; set; }

    /// <summary>
    /// The type of fee assessed or adjusted. The fee type can be `INITIAL` or `ADJUSTMENT`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The fee amount, which might be negative, that is assessed or adjusted by Square.
    ///
    /// Positive values represent funds being assessed, while negative values represent
    /// funds being returned.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

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
