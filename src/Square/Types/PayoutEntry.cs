using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// One or more PayoutEntries that make up a Payout. Each one has a date, amount, and type of activity.
/// The total amount of the payout will equal the sum of the payout entries for a batch payout
/// </summary>
public record PayoutEntry
{
    /// <summary>
    /// A unique ID for the payout entry.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the payout entries’ associated payout.
    /// </summary>
    [JsonPropertyName("payout_id")]
    public required string PayoutId { get; set; }

    /// <summary>
    /// The timestamp of when the payout entry affected the balance, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("effective_at")]
    public string? EffectiveAt { get; set; }

    /// <summary>
    /// The type of activity associated with this payout entry.
    /// See [ActivityType](#type-activitytype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public ActivityType? Type { get; set; }

    /// <summary>
    /// The amount of money involved in this payout entry.
    /// </summary>
    [JsonPropertyName("gross_amount_money")]
    public Money? GrossAmountMoney { get; set; }

    /// <summary>
    /// The amount of Square fees associated with this payout entry.
    /// </summary>
    [JsonPropertyName("fee_amount_money")]
    public Money? FeeAmountMoney { get; set; }

    /// <summary>
    /// The net proceeds from this transaction after any fees.
    /// </summary>
    [JsonPropertyName("net_amount_money")]
    public Money? NetAmountMoney { get; set; }

    /// <summary>
    /// Details of any developer app fee revenue generated on a payment.
    /// </summary>
    [JsonPropertyName("type_app_fee_revenue_details")]
    public PaymentBalanceActivityAppFeeRevenueDetail? TypeAppFeeRevenueDetails { get; set; }

    /// <summary>
    /// Details of a refund for an app fee on a payment.
    /// </summary>
    [JsonPropertyName("type_app_fee_refund_details")]
    public PaymentBalanceActivityAppFeeRefundDetail? TypeAppFeeRefundDetails { get; set; }

    /// <summary>
    /// Details of any automatic transfer from the payment processing balance to the Square Savings account. These are, generally, proportional to the merchant's sales.
    /// </summary>
    [JsonPropertyName("type_automatic_savings_details")]
    public PaymentBalanceActivityAutomaticSavingsDetail? TypeAutomaticSavingsDetails { get; set; }

    /// <summary>
    /// Details of any automatic transfer from the Square Savings account back to the processing balance. These are, generally, proportional to the merchant's refunds.
    /// </summary>
    [JsonPropertyName("type_automatic_savings_reversed_details")]
    public PaymentBalanceActivityAutomaticSavingsReversedDetail? TypeAutomaticSavingsReversedDetails { get; set; }

    /// <summary>
    /// Details of credit card payment captures.
    /// </summary>
    [JsonPropertyName("type_charge_details")]
    public PaymentBalanceActivityChargeDetail? TypeChargeDetails { get; set; }

    /// <summary>
    /// Details of any fees involved with deposits such as for instant deposits.
    /// </summary>
    [JsonPropertyName("type_deposit_fee_details")]
    public PaymentBalanceActivityDepositFeeDetail? TypeDepositFeeDetails { get; set; }

    /// <summary>
    /// Details of any reversal or refund of fees involved with deposits such as for instant deposits.
    /// </summary>
    [JsonPropertyName("type_deposit_fee_reversed_details")]
    public PaymentBalanceActivityDepositFeeReversedDetail? TypeDepositFeeReversedDetails { get; set; }

    /// <summary>
    /// Details of any balance change due to a dispute event.
    /// </summary>
    [JsonPropertyName("type_dispute_details")]
    public PaymentBalanceActivityDisputeDetail? TypeDisputeDetails { get; set; }

    /// <summary>
    /// Details of adjustments due to the Square processing fee.
    /// </summary>
    [JsonPropertyName("type_fee_details")]
    public PaymentBalanceActivityFeeDetail? TypeFeeDetails { get; set; }

    /// <summary>
    /// Square offers Free Payments Processing for a variety of business scenarios including seller referral or when Square wants to apologize for a bug, customer service, repricing complication, and so on. This entry represents details of any credit to the merchant for the purposes of Free Processing.
    /// </summary>
    [JsonPropertyName("type_free_processing_details")]
    public PaymentBalanceActivityFreeProcessingDetail? TypeFreeProcessingDetails { get; set; }

    /// <summary>
    /// Details of any adjustment made by Square related to the holding or releasing of a payment.
    /// </summary>
    [JsonPropertyName("type_hold_adjustment_details")]
    public PaymentBalanceActivityHoldAdjustmentDetail? TypeHoldAdjustmentDetails { get; set; }

    /// <summary>
    /// Details of any open disputes.
    /// </summary>
    [JsonPropertyName("type_open_dispute_details")]
    public PaymentBalanceActivityOpenDisputeDetail? TypeOpenDisputeDetails { get; set; }

    /// <summary>
    /// Details of any other type that does not belong in the rest of the types.
    /// </summary>
    [JsonPropertyName("type_other_details")]
    public PaymentBalanceActivityOtherDetail? TypeOtherDetails { get; set; }

    /// <summary>
    /// Details of any other type of adjustments that don't fall under existing types.
    /// </summary>
    [JsonPropertyName("type_other_adjustment_details")]
    public PaymentBalanceActivityOtherAdjustmentDetail? TypeOtherAdjustmentDetails { get; set; }

    /// <summary>
    /// Details of a refund for an existing card payment.
    /// </summary>
    [JsonPropertyName("type_refund_details")]
    public PaymentBalanceActivityRefundDetail? TypeRefundDetails { get; set; }

    /// <summary>
    /// Details of fees released for adjustments.
    /// </summary>
    [JsonPropertyName("type_release_adjustment_details")]
    public PaymentBalanceActivityReleaseAdjustmentDetail? TypeReleaseAdjustmentDetails { get; set; }

    /// <summary>
    /// Details of fees paid for funding risk reserve.
    /// </summary>
    [JsonPropertyName("type_reserve_hold_details")]
    public PaymentBalanceActivityReserveHoldDetail? TypeReserveHoldDetails { get; set; }

    /// <summary>
    /// Details of fees released from risk reserve.
    /// </summary>
    [JsonPropertyName("type_reserve_release_details")]
    public PaymentBalanceActivityReserveReleaseDetail? TypeReserveReleaseDetails { get; set; }

    /// <summary>
    /// Details of capital merchant cash advance (MCA) assessments. These are, generally, proportional to the merchant's sales but may be issued for other reasons related to the MCA.
    /// </summary>
    [JsonPropertyName("type_square_capital_payment_details")]
    public PaymentBalanceActivitySquareCapitalPaymentDetail? TypeSquareCapitalPaymentDetails { get; set; }

    /// <summary>
    /// Details of capital merchant cash advance (MCA) assessment refunds. These are, generally, proportional to the merchant's refunds but may be issued for other reasons related to the MCA.
    /// </summary>
    [JsonPropertyName("type_square_capital_reversed_payment_details")]
    public PaymentBalanceActivitySquareCapitalReversedPaymentDetail? TypeSquareCapitalReversedPaymentDetails { get; set; }

    /// <summary>
    /// Details of tax paid on fee amounts.
    /// </summary>
    [JsonPropertyName("type_tax_on_fee_details")]
    public PaymentBalanceActivityTaxOnFeeDetail? TypeTaxOnFeeDetails { get; set; }

    /// <summary>
    /// Details of fees collected by a 3rd party platform.
    /// </summary>
    [JsonPropertyName("type_third_party_fee_details")]
    public PaymentBalanceActivityThirdPartyFeeDetail? TypeThirdPartyFeeDetails { get; set; }

    /// <summary>
    /// Details of refunded fees from a 3rd party platform.
    /// </summary>
    [JsonPropertyName("type_third_party_fee_refund_details")]
    public PaymentBalanceActivityThirdPartyFeeRefundDetail? TypeThirdPartyFeeRefundDetails { get; set; }

    /// <summary>
    /// Details of a payroll payment that was transferred to a team member’s bank account.
    /// </summary>
    [JsonPropertyName("type_square_payroll_transfer_details")]
    public PaymentBalanceActivitySquarePayrollTransferDetail? TypeSquarePayrollTransferDetails { get; set; }

    /// <summary>
    /// Details of a payroll payment to a team member’s bank account that was deposited back to the seller’s account by Square.
    /// </summary>
    [JsonPropertyName("type_square_payroll_transfer_reversed_details")]
    public PaymentBalanceActivitySquarePayrollTransferReversedDetail? TypeSquarePayrollTransferReversedDetails { get; set; }

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
