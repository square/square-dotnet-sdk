namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// PayoutEntry.
    /// </summary>
    public class PayoutEntry
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PayoutEntry"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="payoutId">payout_id.</param>
        /// <param name="effectiveAt">effective_at.</param>
        /// <param name="type">type.</param>
        /// <param name="grossAmountMoney">gross_amount_money.</param>
        /// <param name="feeAmountMoney">fee_amount_money.</param>
        /// <param name="netAmountMoney">net_amount_money.</param>
        /// <param name="typeAppFeeRevenueDetails">type_app_fee_revenue_details.</param>
        /// <param name="typeAppFeeRefundDetails">type_app_fee_refund_details.</param>
        /// <param name="typeAutomaticSavingsDetails">type_automatic_savings_details.</param>
        /// <param name="typeAutomaticSavingsReversedDetails">type_automatic_savings_reversed_details.</param>
        /// <param name="typeChargeDetails">type_charge_details.</param>
        /// <param name="typeDepositFeeDetails">type_deposit_fee_details.</param>
        /// <param name="typeDisputeDetails">type_dispute_details.</param>
        /// <param name="typeFeeDetails">type_fee_details.</param>
        /// <param name="typeFreeProcessingDetails">type_free_processing_details.</param>
        /// <param name="typeHoldAdjustmentDetails">type_hold_adjustment_details.</param>
        /// <param name="typeOpenDisputeDetails">type_open_dispute_details.</param>
        /// <param name="typeOtherDetails">type_other_details.</param>
        /// <param name="typeOtherAdjustmentDetails">type_other_adjustment_details.</param>
        /// <param name="typeRefundDetails">type_refund_details.</param>
        /// <param name="typeReleaseAdjustmentDetails">type_release_adjustment_details.</param>
        /// <param name="typeReserveHoldDetails">type_reserve_hold_details.</param>
        /// <param name="typeReserveReleaseDetails">type_reserve_release_details.</param>
        /// <param name="typeSquareCapitalPaymentDetails">type_square_capital_payment_details.</param>
        /// <param name="typeSquareCapitalReversedPaymentDetails">type_square_capital_reversed_payment_details.</param>
        /// <param name="typeTaxOnFeeDetails">type_tax_on_fee_details.</param>
        /// <param name="typeThirdPartyFeeDetails">type_third_party_fee_details.</param>
        /// <param name="typeThirdPartyFeeRefundDetails">type_third_party_fee_refund_details.</param>
        public PayoutEntry(
            string id,
            string payoutId,
            string effectiveAt = null,
            string type = null,
            Models.Money grossAmountMoney = null,
            Models.Money feeAmountMoney = null,
            Models.Money netAmountMoney = null,
            Models.PaymentBalanceActivityAppFeeRevenueDetail typeAppFeeRevenueDetails = null,
            Models.PaymentBalanceActivityAppFeeRefundDetail typeAppFeeRefundDetails = null,
            Models.PaymentBalanceActivityAutomaticSavingsDetail typeAutomaticSavingsDetails = null,
            Models.PaymentBalanceActivityAutomaticSavingsReversedDetail typeAutomaticSavingsReversedDetails = null,
            Models.PaymentBalanceActivityChargeDetail typeChargeDetails = null,
            Models.PaymentBalanceActivityDepositFeeDetail typeDepositFeeDetails = null,
            Models.PaymentBalanceActivityDisputeDetail typeDisputeDetails = null,
            Models.PaymentBalanceActivityFeeDetail typeFeeDetails = null,
            Models.PaymentBalanceActivityFreeProcessingDetail typeFreeProcessingDetails = null,
            Models.PaymentBalanceActivityHoldAdjustmentDetail typeHoldAdjustmentDetails = null,
            Models.PaymentBalanceActivityOpenDisputeDetail typeOpenDisputeDetails = null,
            Models.PaymentBalanceActivityOtherDetail typeOtherDetails = null,
            Models.PaymentBalanceActivityOtherAdjustmentDetail typeOtherAdjustmentDetails = null,
            Models.PaymentBalanceActivityRefundDetail typeRefundDetails = null,
            Models.PaymentBalanceActivityReleaseAdjustmentDetail typeReleaseAdjustmentDetails = null,
            Models.PaymentBalanceActivityReserveHoldDetail typeReserveHoldDetails = null,
            Models.PaymentBalanceActivityReserveReleaseDetail typeReserveReleaseDetails = null,
            Models.PaymentBalanceActivitySquareCapitalPaymentDetail typeSquareCapitalPaymentDetails = null,
            Models.PaymentBalanceActivitySquareCapitalReversedPaymentDetail typeSquareCapitalReversedPaymentDetails = null,
            Models.PaymentBalanceActivityTaxOnFeeDetail typeTaxOnFeeDetails = null,
            Models.PaymentBalanceActivityThirdPartyFeeDetail typeThirdPartyFeeDetails = null,
            Models.PaymentBalanceActivityThirdPartyFeeRefundDetail typeThirdPartyFeeRefundDetails = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_at", false }
            };

            this.Id = id;
            this.PayoutId = payoutId;
            if (effectiveAt != null)
            {
                shouldSerialize["effective_at"] = true;
                this.EffectiveAt = effectiveAt;
            }

            this.Type = type;
            this.GrossAmountMoney = grossAmountMoney;
            this.FeeAmountMoney = feeAmountMoney;
            this.NetAmountMoney = netAmountMoney;
            this.TypeAppFeeRevenueDetails = typeAppFeeRevenueDetails;
            this.TypeAppFeeRefundDetails = typeAppFeeRefundDetails;
            this.TypeAutomaticSavingsDetails = typeAutomaticSavingsDetails;
            this.TypeAutomaticSavingsReversedDetails = typeAutomaticSavingsReversedDetails;
            this.TypeChargeDetails = typeChargeDetails;
            this.TypeDepositFeeDetails = typeDepositFeeDetails;
            this.TypeDisputeDetails = typeDisputeDetails;
            this.TypeFeeDetails = typeFeeDetails;
            this.TypeFreeProcessingDetails = typeFreeProcessingDetails;
            this.TypeHoldAdjustmentDetails = typeHoldAdjustmentDetails;
            this.TypeOpenDisputeDetails = typeOpenDisputeDetails;
            this.TypeOtherDetails = typeOtherDetails;
            this.TypeOtherAdjustmentDetails = typeOtherAdjustmentDetails;
            this.TypeRefundDetails = typeRefundDetails;
            this.TypeReleaseAdjustmentDetails = typeReleaseAdjustmentDetails;
            this.TypeReserveHoldDetails = typeReserveHoldDetails;
            this.TypeReserveReleaseDetails = typeReserveReleaseDetails;
            this.TypeSquareCapitalPaymentDetails = typeSquareCapitalPaymentDetails;
            this.TypeSquareCapitalReversedPaymentDetails = typeSquareCapitalReversedPaymentDetails;
            this.TypeTaxOnFeeDetails = typeTaxOnFeeDetails;
            this.TypeThirdPartyFeeDetails = typeThirdPartyFeeDetails;
            this.TypeThirdPartyFeeRefundDetails = typeThirdPartyFeeRefundDetails;
        }
        internal PayoutEntry(Dictionary<string, bool> shouldSerialize,
            string id,
            string payoutId,
            string effectiveAt = null,
            string type = null,
            Models.Money grossAmountMoney = null,
            Models.Money feeAmountMoney = null,
            Models.Money netAmountMoney = null,
            Models.PaymentBalanceActivityAppFeeRevenueDetail typeAppFeeRevenueDetails = null,
            Models.PaymentBalanceActivityAppFeeRefundDetail typeAppFeeRefundDetails = null,
            Models.PaymentBalanceActivityAutomaticSavingsDetail typeAutomaticSavingsDetails = null,
            Models.PaymentBalanceActivityAutomaticSavingsReversedDetail typeAutomaticSavingsReversedDetails = null,
            Models.PaymentBalanceActivityChargeDetail typeChargeDetails = null,
            Models.PaymentBalanceActivityDepositFeeDetail typeDepositFeeDetails = null,
            Models.PaymentBalanceActivityDisputeDetail typeDisputeDetails = null,
            Models.PaymentBalanceActivityFeeDetail typeFeeDetails = null,
            Models.PaymentBalanceActivityFreeProcessingDetail typeFreeProcessingDetails = null,
            Models.PaymentBalanceActivityHoldAdjustmentDetail typeHoldAdjustmentDetails = null,
            Models.PaymentBalanceActivityOpenDisputeDetail typeOpenDisputeDetails = null,
            Models.PaymentBalanceActivityOtherDetail typeOtherDetails = null,
            Models.PaymentBalanceActivityOtherAdjustmentDetail typeOtherAdjustmentDetails = null,
            Models.PaymentBalanceActivityRefundDetail typeRefundDetails = null,
            Models.PaymentBalanceActivityReleaseAdjustmentDetail typeReleaseAdjustmentDetails = null,
            Models.PaymentBalanceActivityReserveHoldDetail typeReserveHoldDetails = null,
            Models.PaymentBalanceActivityReserveReleaseDetail typeReserveReleaseDetails = null,
            Models.PaymentBalanceActivitySquareCapitalPaymentDetail typeSquareCapitalPaymentDetails = null,
            Models.PaymentBalanceActivitySquareCapitalReversedPaymentDetail typeSquareCapitalReversedPaymentDetails = null,
            Models.PaymentBalanceActivityTaxOnFeeDetail typeTaxOnFeeDetails = null,
            Models.PaymentBalanceActivityThirdPartyFeeDetail typeThirdPartyFeeDetails = null,
            Models.PaymentBalanceActivityThirdPartyFeeRefundDetail typeThirdPartyFeeRefundDetails = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            PayoutId = payoutId;
            EffectiveAt = effectiveAt;
            Type = type;
            GrossAmountMoney = grossAmountMoney;
            FeeAmountMoney = feeAmountMoney;
            NetAmountMoney = netAmountMoney;
            TypeAppFeeRevenueDetails = typeAppFeeRevenueDetails;
            TypeAppFeeRefundDetails = typeAppFeeRefundDetails;
            TypeAutomaticSavingsDetails = typeAutomaticSavingsDetails;
            TypeAutomaticSavingsReversedDetails = typeAutomaticSavingsReversedDetails;
            TypeChargeDetails = typeChargeDetails;
            TypeDepositFeeDetails = typeDepositFeeDetails;
            TypeDisputeDetails = typeDisputeDetails;
            TypeFeeDetails = typeFeeDetails;
            TypeFreeProcessingDetails = typeFreeProcessingDetails;
            TypeHoldAdjustmentDetails = typeHoldAdjustmentDetails;
            TypeOpenDisputeDetails = typeOpenDisputeDetails;
            TypeOtherDetails = typeOtherDetails;
            TypeOtherAdjustmentDetails = typeOtherAdjustmentDetails;
            TypeRefundDetails = typeRefundDetails;
            TypeReleaseAdjustmentDetails = typeReleaseAdjustmentDetails;
            TypeReserveHoldDetails = typeReserveHoldDetails;
            TypeReserveReleaseDetails = typeReserveReleaseDetails;
            TypeSquareCapitalPaymentDetails = typeSquareCapitalPaymentDetails;
            TypeSquareCapitalReversedPaymentDetails = typeSquareCapitalReversedPaymentDetails;
            TypeTaxOnFeeDetails = typeTaxOnFeeDetails;
            TypeThirdPartyFeeDetails = typeThirdPartyFeeDetails;
            TypeThirdPartyFeeRefundDetails = typeThirdPartyFeeRefundDetails;
        }

        /// <summary>
        /// A unique ID for the payout entry.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the payout entries’ associated payout.
        /// </summary>
        [JsonProperty("payout_id")]
        public string PayoutId { get; }

        /// <summary>
        /// The timestamp of when the payout entry affected the balance, in RFC 3339 format.
        /// </summary>
        [JsonProperty("effective_at")]
        public string EffectiveAt { get; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("gross_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money GrossAmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("fee_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money FeeAmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("net_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money NetAmountMoney { get; }

        /// <summary>
        /// Gets or sets TypeAppFeeRevenueDetails.
        /// </summary>
        [JsonProperty("type_app_fee_revenue_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityAppFeeRevenueDetail TypeAppFeeRevenueDetails { get; }

        /// <summary>
        /// Gets or sets TypeAppFeeRefundDetails.
        /// </summary>
        [JsonProperty("type_app_fee_refund_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityAppFeeRefundDetail TypeAppFeeRefundDetails { get; }

        /// <summary>
        /// Gets or sets TypeAutomaticSavingsDetails.
        /// </summary>
        [JsonProperty("type_automatic_savings_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityAutomaticSavingsDetail TypeAutomaticSavingsDetails { get; }

        /// <summary>
        /// Gets or sets TypeAutomaticSavingsReversedDetails.
        /// </summary>
        [JsonProperty("type_automatic_savings_reversed_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityAutomaticSavingsReversedDetail TypeAutomaticSavingsReversedDetails { get; }

        /// <summary>
        /// Gets or sets TypeChargeDetails.
        /// </summary>
        [JsonProperty("type_charge_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityChargeDetail TypeChargeDetails { get; }

        /// <summary>
        /// Gets or sets TypeDepositFeeDetails.
        /// </summary>
        [JsonProperty("type_deposit_fee_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityDepositFeeDetail TypeDepositFeeDetails { get; }

        /// <summary>
        /// Gets or sets TypeDisputeDetails.
        /// </summary>
        [JsonProperty("type_dispute_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityDisputeDetail TypeDisputeDetails { get; }

        /// <summary>
        /// Gets or sets TypeFeeDetails.
        /// </summary>
        [JsonProperty("type_fee_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityFeeDetail TypeFeeDetails { get; }

        /// <summary>
        /// Gets or sets TypeFreeProcessingDetails.
        /// </summary>
        [JsonProperty("type_free_processing_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityFreeProcessingDetail TypeFreeProcessingDetails { get; }

        /// <summary>
        /// Gets or sets TypeHoldAdjustmentDetails.
        /// </summary>
        [JsonProperty("type_hold_adjustment_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityHoldAdjustmentDetail TypeHoldAdjustmentDetails { get; }

        /// <summary>
        /// Gets or sets TypeOpenDisputeDetails.
        /// </summary>
        [JsonProperty("type_open_dispute_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityOpenDisputeDetail TypeOpenDisputeDetails { get; }

        /// <summary>
        /// Gets or sets TypeOtherDetails.
        /// </summary>
        [JsonProperty("type_other_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityOtherDetail TypeOtherDetails { get; }

        /// <summary>
        /// Gets or sets TypeOtherAdjustmentDetails.
        /// </summary>
        [JsonProperty("type_other_adjustment_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityOtherAdjustmentDetail TypeOtherAdjustmentDetails { get; }

        /// <summary>
        /// Gets or sets TypeRefundDetails.
        /// </summary>
        [JsonProperty("type_refund_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityRefundDetail TypeRefundDetails { get; }

        /// <summary>
        /// Gets or sets TypeReleaseAdjustmentDetails.
        /// </summary>
        [JsonProperty("type_release_adjustment_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityReleaseAdjustmentDetail TypeReleaseAdjustmentDetails { get; }

        /// <summary>
        /// Gets or sets TypeReserveHoldDetails.
        /// </summary>
        [JsonProperty("type_reserve_hold_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityReserveHoldDetail TypeReserveHoldDetails { get; }

        /// <summary>
        /// Gets or sets TypeReserveReleaseDetails.
        /// </summary>
        [JsonProperty("type_reserve_release_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityReserveReleaseDetail TypeReserveReleaseDetails { get; }

        /// <summary>
        /// Gets or sets TypeSquareCapitalPaymentDetails.
        /// </summary>
        [JsonProperty("type_square_capital_payment_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivitySquareCapitalPaymentDetail TypeSquareCapitalPaymentDetails { get; }

        /// <summary>
        /// Gets or sets TypeSquareCapitalReversedPaymentDetails.
        /// </summary>
        [JsonProperty("type_square_capital_reversed_payment_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivitySquareCapitalReversedPaymentDetail TypeSquareCapitalReversedPaymentDetails { get; }

        /// <summary>
        /// Gets or sets TypeTaxOnFeeDetails.
        /// </summary>
        [JsonProperty("type_tax_on_fee_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityTaxOnFeeDetail TypeTaxOnFeeDetails { get; }

        /// <summary>
        /// Gets or sets TypeThirdPartyFeeDetails.
        /// </summary>
        [JsonProperty("type_third_party_fee_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityThirdPartyFeeDetail TypeThirdPartyFeeDetails { get; }

        /// <summary>
        /// Gets or sets TypeThirdPartyFeeRefundDetails.
        /// </summary>
        [JsonProperty("type_third_party_fee_refund_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentBalanceActivityThirdPartyFeeRefundDetail TypeThirdPartyFeeRefundDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PayoutEntry : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEffectiveAt()
        {
            return this.shouldSerialize["effective_at"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is PayoutEntry other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.PayoutId == null && other.PayoutId == null) || (this.PayoutId?.Equals(other.PayoutId) == true)) &&
                ((this.EffectiveAt == null && other.EffectiveAt == null) || (this.EffectiveAt?.Equals(other.EffectiveAt) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.GrossAmountMoney == null && other.GrossAmountMoney == null) || (this.GrossAmountMoney?.Equals(other.GrossAmountMoney) == true)) &&
                ((this.FeeAmountMoney == null && other.FeeAmountMoney == null) || (this.FeeAmountMoney?.Equals(other.FeeAmountMoney) == true)) &&
                ((this.NetAmountMoney == null && other.NetAmountMoney == null) || (this.NetAmountMoney?.Equals(other.NetAmountMoney) == true)) &&
                ((this.TypeAppFeeRevenueDetails == null && other.TypeAppFeeRevenueDetails == null) || (this.TypeAppFeeRevenueDetails?.Equals(other.TypeAppFeeRevenueDetails) == true)) &&
                ((this.TypeAppFeeRefundDetails == null && other.TypeAppFeeRefundDetails == null) || (this.TypeAppFeeRefundDetails?.Equals(other.TypeAppFeeRefundDetails) == true)) &&
                ((this.TypeAutomaticSavingsDetails == null && other.TypeAutomaticSavingsDetails == null) || (this.TypeAutomaticSavingsDetails?.Equals(other.TypeAutomaticSavingsDetails) == true)) &&
                ((this.TypeAutomaticSavingsReversedDetails == null && other.TypeAutomaticSavingsReversedDetails == null) || (this.TypeAutomaticSavingsReversedDetails?.Equals(other.TypeAutomaticSavingsReversedDetails) == true)) &&
                ((this.TypeChargeDetails == null && other.TypeChargeDetails == null) || (this.TypeChargeDetails?.Equals(other.TypeChargeDetails) == true)) &&
                ((this.TypeDepositFeeDetails == null && other.TypeDepositFeeDetails == null) || (this.TypeDepositFeeDetails?.Equals(other.TypeDepositFeeDetails) == true)) &&
                ((this.TypeDisputeDetails == null && other.TypeDisputeDetails == null) || (this.TypeDisputeDetails?.Equals(other.TypeDisputeDetails) == true)) &&
                ((this.TypeFeeDetails == null && other.TypeFeeDetails == null) || (this.TypeFeeDetails?.Equals(other.TypeFeeDetails) == true)) &&
                ((this.TypeFreeProcessingDetails == null && other.TypeFreeProcessingDetails == null) || (this.TypeFreeProcessingDetails?.Equals(other.TypeFreeProcessingDetails) == true)) &&
                ((this.TypeHoldAdjustmentDetails == null && other.TypeHoldAdjustmentDetails == null) || (this.TypeHoldAdjustmentDetails?.Equals(other.TypeHoldAdjustmentDetails) == true)) &&
                ((this.TypeOpenDisputeDetails == null && other.TypeOpenDisputeDetails == null) || (this.TypeOpenDisputeDetails?.Equals(other.TypeOpenDisputeDetails) == true)) &&
                ((this.TypeOtherDetails == null && other.TypeOtherDetails == null) || (this.TypeOtherDetails?.Equals(other.TypeOtherDetails) == true)) &&
                ((this.TypeOtherAdjustmentDetails == null && other.TypeOtherAdjustmentDetails == null) || (this.TypeOtherAdjustmentDetails?.Equals(other.TypeOtherAdjustmentDetails) == true)) &&
                ((this.TypeRefundDetails == null && other.TypeRefundDetails == null) || (this.TypeRefundDetails?.Equals(other.TypeRefundDetails) == true)) &&
                ((this.TypeReleaseAdjustmentDetails == null && other.TypeReleaseAdjustmentDetails == null) || (this.TypeReleaseAdjustmentDetails?.Equals(other.TypeReleaseAdjustmentDetails) == true)) &&
                ((this.TypeReserveHoldDetails == null && other.TypeReserveHoldDetails == null) || (this.TypeReserveHoldDetails?.Equals(other.TypeReserveHoldDetails) == true)) &&
                ((this.TypeReserveReleaseDetails == null && other.TypeReserveReleaseDetails == null) || (this.TypeReserveReleaseDetails?.Equals(other.TypeReserveReleaseDetails) == true)) &&
                ((this.TypeSquareCapitalPaymentDetails == null && other.TypeSquareCapitalPaymentDetails == null) || (this.TypeSquareCapitalPaymentDetails?.Equals(other.TypeSquareCapitalPaymentDetails) == true)) &&
                ((this.TypeSquareCapitalReversedPaymentDetails == null && other.TypeSquareCapitalReversedPaymentDetails == null) || (this.TypeSquareCapitalReversedPaymentDetails?.Equals(other.TypeSquareCapitalReversedPaymentDetails) == true)) &&
                ((this.TypeTaxOnFeeDetails == null && other.TypeTaxOnFeeDetails == null) || (this.TypeTaxOnFeeDetails?.Equals(other.TypeTaxOnFeeDetails) == true)) &&
                ((this.TypeThirdPartyFeeDetails == null && other.TypeThirdPartyFeeDetails == null) || (this.TypeThirdPartyFeeDetails?.Equals(other.TypeThirdPartyFeeDetails) == true)) &&
                ((this.TypeThirdPartyFeeRefundDetails == null && other.TypeThirdPartyFeeRefundDetails == null) || (this.TypeThirdPartyFeeRefundDetails?.Equals(other.TypeThirdPartyFeeRefundDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2018225012;
            hashCode = HashCode.Combine(this.Id, this.PayoutId, this.EffectiveAt, this.Type, this.GrossAmountMoney, this.FeeAmountMoney, this.NetAmountMoney);

            hashCode = HashCode.Combine(hashCode, this.TypeAppFeeRevenueDetails, this.TypeAppFeeRefundDetails, this.TypeAutomaticSavingsDetails, this.TypeAutomaticSavingsReversedDetails, this.TypeChargeDetails, this.TypeDepositFeeDetails, this.TypeDisputeDetails);

            hashCode = HashCode.Combine(hashCode, this.TypeFeeDetails, this.TypeFreeProcessingDetails, this.TypeHoldAdjustmentDetails, this.TypeOpenDisputeDetails, this.TypeOtherDetails, this.TypeOtherAdjustmentDetails, this.TypeRefundDetails);

            hashCode = HashCode.Combine(hashCode, this.TypeReleaseAdjustmentDetails, this.TypeReserveHoldDetails, this.TypeReserveReleaseDetails, this.TypeSquareCapitalPaymentDetails, this.TypeSquareCapitalReversedPaymentDetails, this.TypeTaxOnFeeDetails, this.TypeThirdPartyFeeDetails);

            hashCode = HashCode.Combine(hashCode, this.TypeThirdPartyFeeRefundDetails);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.PayoutId = {(this.PayoutId == null ? "null" : this.PayoutId == string.Empty ? "" : this.PayoutId)}");
            toStringOutput.Add($"this.EffectiveAt = {(this.EffectiveAt == null ? "null" : this.EffectiveAt == string.Empty ? "" : this.EffectiveAt)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.GrossAmountMoney = {(this.GrossAmountMoney == null ? "null" : this.GrossAmountMoney.ToString())}");
            toStringOutput.Add($"this.FeeAmountMoney = {(this.FeeAmountMoney == null ? "null" : this.FeeAmountMoney.ToString())}");
            toStringOutput.Add($"this.NetAmountMoney = {(this.NetAmountMoney == null ? "null" : this.NetAmountMoney.ToString())}");
            toStringOutput.Add($"this.TypeAppFeeRevenueDetails = {(this.TypeAppFeeRevenueDetails == null ? "null" : this.TypeAppFeeRevenueDetails.ToString())}");
            toStringOutput.Add($"this.TypeAppFeeRefundDetails = {(this.TypeAppFeeRefundDetails == null ? "null" : this.TypeAppFeeRefundDetails.ToString())}");
            toStringOutput.Add($"this.TypeAutomaticSavingsDetails = {(this.TypeAutomaticSavingsDetails == null ? "null" : this.TypeAutomaticSavingsDetails.ToString())}");
            toStringOutput.Add($"this.TypeAutomaticSavingsReversedDetails = {(this.TypeAutomaticSavingsReversedDetails == null ? "null" : this.TypeAutomaticSavingsReversedDetails.ToString())}");
            toStringOutput.Add($"this.TypeChargeDetails = {(this.TypeChargeDetails == null ? "null" : this.TypeChargeDetails.ToString())}");
            toStringOutput.Add($"this.TypeDepositFeeDetails = {(this.TypeDepositFeeDetails == null ? "null" : this.TypeDepositFeeDetails.ToString())}");
            toStringOutput.Add($"this.TypeDisputeDetails = {(this.TypeDisputeDetails == null ? "null" : this.TypeDisputeDetails.ToString())}");
            toStringOutput.Add($"this.TypeFeeDetails = {(this.TypeFeeDetails == null ? "null" : this.TypeFeeDetails.ToString())}");
            toStringOutput.Add($"this.TypeFreeProcessingDetails = {(this.TypeFreeProcessingDetails == null ? "null" : this.TypeFreeProcessingDetails.ToString())}");
            toStringOutput.Add($"this.TypeHoldAdjustmentDetails = {(this.TypeHoldAdjustmentDetails == null ? "null" : this.TypeHoldAdjustmentDetails.ToString())}");
            toStringOutput.Add($"this.TypeOpenDisputeDetails = {(this.TypeOpenDisputeDetails == null ? "null" : this.TypeOpenDisputeDetails.ToString())}");
            toStringOutput.Add($"this.TypeOtherDetails = {(this.TypeOtherDetails == null ? "null" : this.TypeOtherDetails.ToString())}");
            toStringOutput.Add($"this.TypeOtherAdjustmentDetails = {(this.TypeOtherAdjustmentDetails == null ? "null" : this.TypeOtherAdjustmentDetails.ToString())}");
            toStringOutput.Add($"this.TypeRefundDetails = {(this.TypeRefundDetails == null ? "null" : this.TypeRefundDetails.ToString())}");
            toStringOutput.Add($"this.TypeReleaseAdjustmentDetails = {(this.TypeReleaseAdjustmentDetails == null ? "null" : this.TypeReleaseAdjustmentDetails.ToString())}");
            toStringOutput.Add($"this.TypeReserveHoldDetails = {(this.TypeReserveHoldDetails == null ? "null" : this.TypeReserveHoldDetails.ToString())}");
            toStringOutput.Add($"this.TypeReserveReleaseDetails = {(this.TypeReserveReleaseDetails == null ? "null" : this.TypeReserveReleaseDetails.ToString())}");
            toStringOutput.Add($"this.TypeSquareCapitalPaymentDetails = {(this.TypeSquareCapitalPaymentDetails == null ? "null" : this.TypeSquareCapitalPaymentDetails.ToString())}");
            toStringOutput.Add($"this.TypeSquareCapitalReversedPaymentDetails = {(this.TypeSquareCapitalReversedPaymentDetails == null ? "null" : this.TypeSquareCapitalReversedPaymentDetails.ToString())}");
            toStringOutput.Add($"this.TypeTaxOnFeeDetails = {(this.TypeTaxOnFeeDetails == null ? "null" : this.TypeTaxOnFeeDetails.ToString())}");
            toStringOutput.Add($"this.TypeThirdPartyFeeDetails = {(this.TypeThirdPartyFeeDetails == null ? "null" : this.TypeThirdPartyFeeDetails.ToString())}");
            toStringOutput.Add($"this.TypeThirdPartyFeeRefundDetails = {(this.TypeThirdPartyFeeRefundDetails == null ? "null" : this.TypeThirdPartyFeeRefundDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.PayoutId)
                .EffectiveAt(this.EffectiveAt)
                .Type(this.Type)
                .GrossAmountMoney(this.GrossAmountMoney)
                .FeeAmountMoney(this.FeeAmountMoney)
                .NetAmountMoney(this.NetAmountMoney)
                .TypeAppFeeRevenueDetails(this.TypeAppFeeRevenueDetails)
                .TypeAppFeeRefundDetails(this.TypeAppFeeRefundDetails)
                .TypeAutomaticSavingsDetails(this.TypeAutomaticSavingsDetails)
                .TypeAutomaticSavingsReversedDetails(this.TypeAutomaticSavingsReversedDetails)
                .TypeChargeDetails(this.TypeChargeDetails)
                .TypeDepositFeeDetails(this.TypeDepositFeeDetails)
                .TypeDisputeDetails(this.TypeDisputeDetails)
                .TypeFeeDetails(this.TypeFeeDetails)
                .TypeFreeProcessingDetails(this.TypeFreeProcessingDetails)
                .TypeHoldAdjustmentDetails(this.TypeHoldAdjustmentDetails)
                .TypeOpenDisputeDetails(this.TypeOpenDisputeDetails)
                .TypeOtherDetails(this.TypeOtherDetails)
                .TypeOtherAdjustmentDetails(this.TypeOtherAdjustmentDetails)
                .TypeRefundDetails(this.TypeRefundDetails)
                .TypeReleaseAdjustmentDetails(this.TypeReleaseAdjustmentDetails)
                .TypeReserveHoldDetails(this.TypeReserveHoldDetails)
                .TypeReserveReleaseDetails(this.TypeReserveReleaseDetails)
                .TypeSquareCapitalPaymentDetails(this.TypeSquareCapitalPaymentDetails)
                .TypeSquareCapitalReversedPaymentDetails(this.TypeSquareCapitalReversedPaymentDetails)
                .TypeTaxOnFeeDetails(this.TypeTaxOnFeeDetails)
                .TypeThirdPartyFeeDetails(this.TypeThirdPartyFeeDetails)
                .TypeThirdPartyFeeRefundDetails(this.TypeThirdPartyFeeRefundDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_at", false },
            };

            private string id;
            private string payoutId;
            private string effectiveAt;
            private string type;
            private Models.Money grossAmountMoney;
            private Models.Money feeAmountMoney;
            private Models.Money netAmountMoney;
            private Models.PaymentBalanceActivityAppFeeRevenueDetail typeAppFeeRevenueDetails;
            private Models.PaymentBalanceActivityAppFeeRefundDetail typeAppFeeRefundDetails;
            private Models.PaymentBalanceActivityAutomaticSavingsDetail typeAutomaticSavingsDetails;
            private Models.PaymentBalanceActivityAutomaticSavingsReversedDetail typeAutomaticSavingsReversedDetails;
            private Models.PaymentBalanceActivityChargeDetail typeChargeDetails;
            private Models.PaymentBalanceActivityDepositFeeDetail typeDepositFeeDetails;
            private Models.PaymentBalanceActivityDisputeDetail typeDisputeDetails;
            private Models.PaymentBalanceActivityFeeDetail typeFeeDetails;
            private Models.PaymentBalanceActivityFreeProcessingDetail typeFreeProcessingDetails;
            private Models.PaymentBalanceActivityHoldAdjustmentDetail typeHoldAdjustmentDetails;
            private Models.PaymentBalanceActivityOpenDisputeDetail typeOpenDisputeDetails;
            private Models.PaymentBalanceActivityOtherDetail typeOtherDetails;
            private Models.PaymentBalanceActivityOtherAdjustmentDetail typeOtherAdjustmentDetails;
            private Models.PaymentBalanceActivityRefundDetail typeRefundDetails;
            private Models.PaymentBalanceActivityReleaseAdjustmentDetail typeReleaseAdjustmentDetails;
            private Models.PaymentBalanceActivityReserveHoldDetail typeReserveHoldDetails;
            private Models.PaymentBalanceActivityReserveReleaseDetail typeReserveReleaseDetails;
            private Models.PaymentBalanceActivitySquareCapitalPaymentDetail typeSquareCapitalPaymentDetails;
            private Models.PaymentBalanceActivitySquareCapitalReversedPaymentDetail typeSquareCapitalReversedPaymentDetails;
            private Models.PaymentBalanceActivityTaxOnFeeDetail typeTaxOnFeeDetails;
            private Models.PaymentBalanceActivityThirdPartyFeeDetail typeThirdPartyFeeDetails;
            private Models.PaymentBalanceActivityThirdPartyFeeRefundDetail typeThirdPartyFeeRefundDetails;

            public Builder(
                string id,
                string payoutId)
            {
                this.id = id;
                this.payoutId = payoutId;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// PayoutId.
             /// </summary>
             /// <param name="payoutId"> payoutId. </param>
             /// <returns> Builder. </returns>
            public Builder PayoutId(string payoutId)
            {
                this.payoutId = payoutId;
                return this;
            }

             /// <summary>
             /// EffectiveAt.
             /// </summary>
             /// <param name="effectiveAt"> effectiveAt. </param>
             /// <returns> Builder. </returns>
            public Builder EffectiveAt(string effectiveAt)
            {
                shouldSerialize["effective_at"] = true;
                this.effectiveAt = effectiveAt;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// GrossAmountMoney.
             /// </summary>
             /// <param name="grossAmountMoney"> grossAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder GrossAmountMoney(Models.Money grossAmountMoney)
            {
                this.grossAmountMoney = grossAmountMoney;
                return this;
            }

             /// <summary>
             /// FeeAmountMoney.
             /// </summary>
             /// <param name="feeAmountMoney"> feeAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder FeeAmountMoney(Models.Money feeAmountMoney)
            {
                this.feeAmountMoney = feeAmountMoney;
                return this;
            }

             /// <summary>
             /// NetAmountMoney.
             /// </summary>
             /// <param name="netAmountMoney"> netAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder NetAmountMoney(Models.Money netAmountMoney)
            {
                this.netAmountMoney = netAmountMoney;
                return this;
            }

             /// <summary>
             /// TypeAppFeeRevenueDetails.
             /// </summary>
             /// <param name="typeAppFeeRevenueDetails"> typeAppFeeRevenueDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeAppFeeRevenueDetails(Models.PaymentBalanceActivityAppFeeRevenueDetail typeAppFeeRevenueDetails)
            {
                this.typeAppFeeRevenueDetails = typeAppFeeRevenueDetails;
                return this;
            }

             /// <summary>
             /// TypeAppFeeRefundDetails.
             /// </summary>
             /// <param name="typeAppFeeRefundDetails"> typeAppFeeRefundDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeAppFeeRefundDetails(Models.PaymentBalanceActivityAppFeeRefundDetail typeAppFeeRefundDetails)
            {
                this.typeAppFeeRefundDetails = typeAppFeeRefundDetails;
                return this;
            }

             /// <summary>
             /// TypeAutomaticSavingsDetails.
             /// </summary>
             /// <param name="typeAutomaticSavingsDetails"> typeAutomaticSavingsDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeAutomaticSavingsDetails(Models.PaymentBalanceActivityAutomaticSavingsDetail typeAutomaticSavingsDetails)
            {
                this.typeAutomaticSavingsDetails = typeAutomaticSavingsDetails;
                return this;
            }

             /// <summary>
             /// TypeAutomaticSavingsReversedDetails.
             /// </summary>
             /// <param name="typeAutomaticSavingsReversedDetails"> typeAutomaticSavingsReversedDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeAutomaticSavingsReversedDetails(Models.PaymentBalanceActivityAutomaticSavingsReversedDetail typeAutomaticSavingsReversedDetails)
            {
                this.typeAutomaticSavingsReversedDetails = typeAutomaticSavingsReversedDetails;
                return this;
            }

             /// <summary>
             /// TypeChargeDetails.
             /// </summary>
             /// <param name="typeChargeDetails"> typeChargeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeChargeDetails(Models.PaymentBalanceActivityChargeDetail typeChargeDetails)
            {
                this.typeChargeDetails = typeChargeDetails;
                return this;
            }

             /// <summary>
             /// TypeDepositFeeDetails.
             /// </summary>
             /// <param name="typeDepositFeeDetails"> typeDepositFeeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeDepositFeeDetails(Models.PaymentBalanceActivityDepositFeeDetail typeDepositFeeDetails)
            {
                this.typeDepositFeeDetails = typeDepositFeeDetails;
                return this;
            }

             /// <summary>
             /// TypeDisputeDetails.
             /// </summary>
             /// <param name="typeDisputeDetails"> typeDisputeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeDisputeDetails(Models.PaymentBalanceActivityDisputeDetail typeDisputeDetails)
            {
                this.typeDisputeDetails = typeDisputeDetails;
                return this;
            }

             /// <summary>
             /// TypeFeeDetails.
             /// </summary>
             /// <param name="typeFeeDetails"> typeFeeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeFeeDetails(Models.PaymentBalanceActivityFeeDetail typeFeeDetails)
            {
                this.typeFeeDetails = typeFeeDetails;
                return this;
            }

             /// <summary>
             /// TypeFreeProcessingDetails.
             /// </summary>
             /// <param name="typeFreeProcessingDetails"> typeFreeProcessingDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeFreeProcessingDetails(Models.PaymentBalanceActivityFreeProcessingDetail typeFreeProcessingDetails)
            {
                this.typeFreeProcessingDetails = typeFreeProcessingDetails;
                return this;
            }

             /// <summary>
             /// TypeHoldAdjustmentDetails.
             /// </summary>
             /// <param name="typeHoldAdjustmentDetails"> typeHoldAdjustmentDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeHoldAdjustmentDetails(Models.PaymentBalanceActivityHoldAdjustmentDetail typeHoldAdjustmentDetails)
            {
                this.typeHoldAdjustmentDetails = typeHoldAdjustmentDetails;
                return this;
            }

             /// <summary>
             /// TypeOpenDisputeDetails.
             /// </summary>
             /// <param name="typeOpenDisputeDetails"> typeOpenDisputeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeOpenDisputeDetails(Models.PaymentBalanceActivityOpenDisputeDetail typeOpenDisputeDetails)
            {
                this.typeOpenDisputeDetails = typeOpenDisputeDetails;
                return this;
            }

             /// <summary>
             /// TypeOtherDetails.
             /// </summary>
             /// <param name="typeOtherDetails"> typeOtherDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeOtherDetails(Models.PaymentBalanceActivityOtherDetail typeOtherDetails)
            {
                this.typeOtherDetails = typeOtherDetails;
                return this;
            }

             /// <summary>
             /// TypeOtherAdjustmentDetails.
             /// </summary>
             /// <param name="typeOtherAdjustmentDetails"> typeOtherAdjustmentDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeOtherAdjustmentDetails(Models.PaymentBalanceActivityOtherAdjustmentDetail typeOtherAdjustmentDetails)
            {
                this.typeOtherAdjustmentDetails = typeOtherAdjustmentDetails;
                return this;
            }

             /// <summary>
             /// TypeRefundDetails.
             /// </summary>
             /// <param name="typeRefundDetails"> typeRefundDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeRefundDetails(Models.PaymentBalanceActivityRefundDetail typeRefundDetails)
            {
                this.typeRefundDetails = typeRefundDetails;
                return this;
            }

             /// <summary>
             /// TypeReleaseAdjustmentDetails.
             /// </summary>
             /// <param name="typeReleaseAdjustmentDetails"> typeReleaseAdjustmentDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeReleaseAdjustmentDetails(Models.PaymentBalanceActivityReleaseAdjustmentDetail typeReleaseAdjustmentDetails)
            {
                this.typeReleaseAdjustmentDetails = typeReleaseAdjustmentDetails;
                return this;
            }

             /// <summary>
             /// TypeReserveHoldDetails.
             /// </summary>
             /// <param name="typeReserveHoldDetails"> typeReserveHoldDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeReserveHoldDetails(Models.PaymentBalanceActivityReserveHoldDetail typeReserveHoldDetails)
            {
                this.typeReserveHoldDetails = typeReserveHoldDetails;
                return this;
            }

             /// <summary>
             /// TypeReserveReleaseDetails.
             /// </summary>
             /// <param name="typeReserveReleaseDetails"> typeReserveReleaseDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeReserveReleaseDetails(Models.PaymentBalanceActivityReserveReleaseDetail typeReserveReleaseDetails)
            {
                this.typeReserveReleaseDetails = typeReserveReleaseDetails;
                return this;
            }

             /// <summary>
             /// TypeSquareCapitalPaymentDetails.
             /// </summary>
             /// <param name="typeSquareCapitalPaymentDetails"> typeSquareCapitalPaymentDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeSquareCapitalPaymentDetails(Models.PaymentBalanceActivitySquareCapitalPaymentDetail typeSquareCapitalPaymentDetails)
            {
                this.typeSquareCapitalPaymentDetails = typeSquareCapitalPaymentDetails;
                return this;
            }

             /// <summary>
             /// TypeSquareCapitalReversedPaymentDetails.
             /// </summary>
             /// <param name="typeSquareCapitalReversedPaymentDetails"> typeSquareCapitalReversedPaymentDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeSquareCapitalReversedPaymentDetails(Models.PaymentBalanceActivitySquareCapitalReversedPaymentDetail typeSquareCapitalReversedPaymentDetails)
            {
                this.typeSquareCapitalReversedPaymentDetails = typeSquareCapitalReversedPaymentDetails;
                return this;
            }

             /// <summary>
             /// TypeTaxOnFeeDetails.
             /// </summary>
             /// <param name="typeTaxOnFeeDetails"> typeTaxOnFeeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeTaxOnFeeDetails(Models.PaymentBalanceActivityTaxOnFeeDetail typeTaxOnFeeDetails)
            {
                this.typeTaxOnFeeDetails = typeTaxOnFeeDetails;
                return this;
            }

             /// <summary>
             /// TypeThirdPartyFeeDetails.
             /// </summary>
             /// <param name="typeThirdPartyFeeDetails"> typeThirdPartyFeeDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeThirdPartyFeeDetails(Models.PaymentBalanceActivityThirdPartyFeeDetail typeThirdPartyFeeDetails)
            {
                this.typeThirdPartyFeeDetails = typeThirdPartyFeeDetails;
                return this;
            }

             /// <summary>
             /// TypeThirdPartyFeeRefundDetails.
             /// </summary>
             /// <param name="typeThirdPartyFeeRefundDetails"> typeThirdPartyFeeRefundDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TypeThirdPartyFeeRefundDetails(Models.PaymentBalanceActivityThirdPartyFeeRefundDetail typeThirdPartyFeeRefundDetails)
            {
                this.typeThirdPartyFeeRefundDetails = typeThirdPartyFeeRefundDetails;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEffectiveAt()
            {
                this.shouldSerialize["effective_at"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PayoutEntry. </returns>
            public PayoutEntry Build()
            {
                return new PayoutEntry(shouldSerialize,
                    this.id,
                    this.payoutId,
                    this.effectiveAt,
                    this.type,
                    this.grossAmountMoney,
                    this.feeAmountMoney,
                    this.netAmountMoney,
                    this.typeAppFeeRevenueDetails,
                    this.typeAppFeeRefundDetails,
                    this.typeAutomaticSavingsDetails,
                    this.typeAutomaticSavingsReversedDetails,
                    this.typeChargeDetails,
                    this.typeDepositFeeDetails,
                    this.typeDisputeDetails,
                    this.typeFeeDetails,
                    this.typeFreeProcessingDetails,
                    this.typeHoldAdjustmentDetails,
                    this.typeOpenDisputeDetails,
                    this.typeOtherDetails,
                    this.typeOtherAdjustmentDetails,
                    this.typeRefundDetails,
                    this.typeReleaseAdjustmentDetails,
                    this.typeReserveHoldDetails,
                    this.typeReserveReleaseDetails,
                    this.typeSquareCapitalPaymentDetails,
                    this.typeSquareCapitalReversedPaymentDetails,
                    this.typeTaxOnFeeDetails,
                    this.typeThirdPartyFeeDetails,
                    this.typeThirdPartyFeeRefundDetails);
            }
        }
    }
}