using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Loyalty.Programs;

[Serializable]
public record CalculateLoyaltyPointsRequest
{
    /// <summary>
    /// The ID of the [loyalty program](entity:LoyaltyProgram), which defines the rules for accruing points.
    /// </summary>
    [JsonIgnore]
    public required string ProgramId { get; set; }

    /// <summary>
    /// The [order](entity:Order) ID for which to calculate the points.
    /// Specify this field if your application uses the Orders API to process orders.
    /// Otherwise, specify the `transaction_amount_money`.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The purchase amount for which to calculate the points.
    /// Specify this field if your application does not use the Orders API to process orders.
    /// Otherwise, specify the `order_id`.
    /// </summary>
    [JsonPropertyName("transaction_amount_money")]
    public Money? TransactionAmountMoney { get; set; }

    /// <summary>
    /// The ID of the target [loyalty account](entity:LoyaltyAccount). Optionally specify this field
    /// if your application uses the Orders API to process orders.
    ///
    /// If specified, the `promotion_points` field in the response shows the number of points the buyer would
    /// earn from the purchase. In this case, Square uses the account ID to determine whether the promotion's
    /// `trigger_limit` (the maximum number of times that a buyer can trigger the promotion) has been reached.
    /// If not specified, the `promotion_points` field shows the number of points the purchase qualifies
    /// for regardless of the trigger limit.
    /// </summary>
    [JsonPropertyName("loyalty_account_id")]
    public string? LoyaltyAccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
