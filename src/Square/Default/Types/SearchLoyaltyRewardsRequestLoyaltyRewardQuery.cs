using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The set of search requirements.
/// </summary>
[Serializable]
public record SearchLoyaltyRewardsRequestLoyaltyRewardQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the [loyalty account](entity:LoyaltyAccount) to which the loyalty reward belongs.
    /// </summary>
    [JsonPropertyName("loyalty_account_id")]
    public required string LoyaltyAccountId { get; set; }

    /// <summary>
    /// The status of the loyalty reward.
    /// See [LoyaltyRewardStatus](#type-loyaltyrewardstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public LoyaltyRewardStatus? Status { get; set; }

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
