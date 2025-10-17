using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a payout fee that can incur as part of a payout.
/// </summary>
[Serializable]
public record PayoutFee : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The money amount of the payout fee.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The timestamp of when the fee takes effect, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("effective_at")]
    public string? EffectiveAt { get; set; }

    /// <summary>
    /// The type of fee assessed as part of the payout.
    /// See [PayoutFeeType](#type-payoutfeetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public PayoutFeeType? Type { get; set; }

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
