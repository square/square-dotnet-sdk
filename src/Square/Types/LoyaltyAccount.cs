using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a loyalty account in a [loyalty program](entity:LoyaltyProgram). For more information, see
/// [Create and Retrieve Loyalty Accounts](https://developer.squareup.com/docs/loyalty-api/loyalty-accounts).
/// </summary>
public record LoyaltyAccount
{
    /// <summary>
    /// The Square-assigned ID of the loyalty account.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The Square-assigned ID of the [loyalty program](entity:LoyaltyProgram) to which the account belongs.
    /// </summary>
    [JsonPropertyName("program_id")]
    public required string ProgramId { get; set; }

    /// <summary>
    /// The available point balance in the loyalty account. If points are scheduled to expire, they are listed in the `expiring_point_deadlines` field.
    ///
    /// Your application should be able to handle loyalty accounts that have a negative point balance (`balance` is less than 0). This might occur if a seller makes a manual adjustment or as a result of a refund or exchange.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("balance")]
    public int? Balance { get; set; }

    /// <summary>
    /// The total points accrued during the lifetime of the account.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("lifetime_points")]
    public int? LifetimePoints { get; set; }

    /// <summary>
    /// The Square-assigned ID of the [customer](entity:Customer) that is associated with the account.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The timestamp when the buyer joined the loyalty program, in RFC 3339 format. This field is used to display the **Enrolled On** or **Member Since** date in first-party Square products.
    ///
    /// If this field is not set in a `CreateLoyaltyAccount` request, Square populates it after the buyer's first action on their account
    /// (when `AccumulateLoyaltyPoints` or `CreateLoyaltyReward` is called). In first-party flows, Square populates the field when the buyer agrees to the terms of service in Square Point of Sale.
    ///
    /// This field is typically specified in a `CreateLoyaltyAccount` request when creating a loyalty account for a buyer who already interacted with their account.
    /// For example, you would set this field when migrating accounts from an external system. The timestamp in the request can represent a current or previous date and time, but it cannot be set for the future.
    /// </summary>
    [JsonPropertyName("enrolled_at")]
    public string? EnrolledAt { get; set; }

    /// <summary>
    /// The timestamp when the loyalty account was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the loyalty account was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The mapping that associates the loyalty account with a buyer. Currently,
    /// a loyalty account can only be mapped to a buyer by phone number.
    ///
    /// To create a loyalty account, you must specify the `mapping` field, with the buyer's phone number
    /// in the `phone_number` field.
    /// </summary>
    [JsonPropertyName("mapping")]
    public LoyaltyAccountMapping? Mapping { get; set; }

    /// <summary>
    /// The schedule for when points expire in the loyalty account balance. This field is present only if the account has points that are scheduled to expire.
    ///
    /// The total number of points in this field equals the number of points in the `balance` field.
    /// </summary>
    [JsonPropertyName("expiring_point_deadlines")]
    public IEnumerable<LoyaltyAccountExpiringPointDeadline>? ExpiringPointDeadlines { get; set; }

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
