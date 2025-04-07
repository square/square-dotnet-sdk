using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The set of search requirements.
/// </summary>
public record SearchLoyaltyRewardsRequestLoyaltyRewardQuery
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
