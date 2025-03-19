using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a payout fee that can incur as part of a payout.
/// </summary>
public record PayoutFee
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
