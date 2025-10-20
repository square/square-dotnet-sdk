using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a Square loyalty program. Loyalty programs define how buyers can earn points and redeem points for rewards.
/// Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard.
/// For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
/// </summary>
[Serializable]
public record LoyaltyProgram : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square-assigned ID of the loyalty program. Updates to
    /// the loyalty program do not modify the identifier.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Whether the program is currently active.
    /// See [LoyaltyProgramStatus](#type-loyaltyprogramstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public LoyaltyProgramStatus? Status { get; set; }

    /// <summary>
    /// The list of rewards for buyers, sorted by ascending points.
    /// </summary>
    [JsonPropertyName("reward_tiers")]
    public IEnumerable<LoyaltyProgramRewardTier>? RewardTiers { get; set; }

    /// <summary>
    /// If present, details for how points expire.
    /// </summary>
    [JsonPropertyName("expiration_policy")]
    public LoyaltyProgramExpirationPolicy? ExpirationPolicy { get; set; }

    /// <summary>
    /// A cosmetic name for the “points” currency.
    /// </summary>
    [JsonPropertyName("terminology")]
    public LoyaltyProgramTerminology? Terminology { get; set; }

    /// <summary>
    /// The [locations](entity:Location) at which the program is active.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// The timestamp when the program was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the reward was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Defines how buyers can earn loyalty points from the base loyalty program.
    /// To check for associated [loyalty promotions](entity:LoyaltyPromotion) that enable
    /// buyers to earn extra points, call [ListLoyaltyPromotions](api-endpoint:Loyalty-ListLoyaltyPromotions).
    /// </summary>
    [JsonPropertyName("accrual_rules")]
    public IEnumerable<LoyaltyProgramAccrualRule>? AccrualRules { get; set; }

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
