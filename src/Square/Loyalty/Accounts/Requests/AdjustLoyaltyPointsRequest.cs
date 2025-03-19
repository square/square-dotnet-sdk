using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Accounts;

public record AdjustLoyaltyPointsRequest
{
    /// <summary>
    /// The ID of the target [loyalty account](entity:LoyaltyAccount).
    /// </summary>
    [JsonIgnore]
    public required string AccountId { get; set; }

    /// <summary>
    /// A unique string that identifies this `AdjustLoyaltyPoints` request.
    /// Keys can be any valid string, but must be unique for every request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The points to add or subtract and the reason for the adjustment. To add points, specify a positive integer.
    /// To subtract points, specify a negative integer.
    /// </summary>
    [JsonPropertyName("adjust_points")]
    public required LoyaltyEventAdjustPoints AdjustPoints { get; set; }

    /// <summary>
    /// Indicates whether to allow a negative adjustment to result in a negative balance. If `true`, a negative
    /// balance is allowed when subtracting points. If `false`, Square returns a `BAD_REQUEST` error when subtracting
    /// the specified number of points would result in a negative balance. The default value is `false`.
    /// </summary>
    [JsonPropertyName("allow_negative_balance")]
    public bool? AllowNegativeBalance { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
