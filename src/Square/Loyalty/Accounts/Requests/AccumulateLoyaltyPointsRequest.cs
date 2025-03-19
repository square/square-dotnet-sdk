using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Accounts;

public record AccumulateLoyaltyPointsRequest
{
    /// <summary>
    /// The ID of the target [loyalty account](entity:LoyaltyAccount).
    /// </summary>
    [JsonIgnore]
    public required string AccountId { get; set; }

    /// <summary>
    /// The points to add to the account.
    /// If you are using the Orders API to manage orders, specify the order ID.
    /// Otherwise, specify the points to add.
    /// </summary>
    [JsonPropertyName("accumulate_points")]
    public required LoyaltyEventAccumulatePoints AccumulatePoints { get; set; }

    /// <summary>
    /// A unique string that identifies the `AccumulateLoyaltyPoints` request.
    /// Keys can be any valid string but must be unique for every request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The [location](entity:Location) where the purchase was made.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
