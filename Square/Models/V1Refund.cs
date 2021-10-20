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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// V1Refund.
    /// </summary>
    public class V1Refund
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Refund"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="reason">reason.</param>
        /// <param name="refundedMoney">refunded_money.</param>
        /// <param name="refundedProcessingFeeMoney">refunded_processing_fee_money.</param>
        /// <param name="refundedTaxMoney">refunded_tax_money.</param>
        /// <param name="refundedAdditiveTaxMoney">refunded_additive_tax_money.</param>
        /// <param name="refundedAdditiveTax">refunded_additive_tax.</param>
        /// <param name="refundedInclusiveTaxMoney">refunded_inclusive_tax_money.</param>
        /// <param name="refundedInclusiveTax">refunded_inclusive_tax.</param>
        /// <param name="refundedTipMoney">refunded_tip_money.</param>
        /// <param name="refundedDiscountMoney">refunded_discount_money.</param>
        /// <param name="refundedSurchargeMoney">refunded_surcharge_money.</param>
        /// <param name="refundedSurcharges">refunded_surcharges.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="processedAt">processed_at.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="isExchange">is_exchange.</param>
        public V1Refund(
            string type = null,
            string reason = null,
            Models.V1Money refundedMoney = null,
            Models.V1Money refundedProcessingFeeMoney = null,
            Models.V1Money refundedTaxMoney = null,
            Models.V1Money refundedAdditiveTaxMoney = null,
            IList<Models.V1PaymentTax> refundedAdditiveTax = null,
            Models.V1Money refundedInclusiveTaxMoney = null,
            IList<Models.V1PaymentTax> refundedInclusiveTax = null,
            Models.V1Money refundedTipMoney = null,
            Models.V1Money refundedDiscountMoney = null,
            Models.V1Money refundedSurchargeMoney = null,
            IList<Models.V1PaymentSurcharge> refundedSurcharges = null,
            string createdAt = null,
            string processedAt = null,
            string paymentId = null,
            string merchantId = null,
            bool? isExchange = null)
        {
            this.Type = type;
            this.Reason = reason;
            this.RefundedMoney = refundedMoney;
            this.RefundedProcessingFeeMoney = refundedProcessingFeeMoney;
            this.RefundedTaxMoney = refundedTaxMoney;
            this.RefundedAdditiveTaxMoney = refundedAdditiveTaxMoney;
            this.RefundedAdditiveTax = refundedAdditiveTax;
            this.RefundedInclusiveTaxMoney = refundedInclusiveTaxMoney;
            this.RefundedInclusiveTax = refundedInclusiveTax;
            this.RefundedTipMoney = refundedTipMoney;
            this.RefundedDiscountMoney = refundedDiscountMoney;
            this.RefundedSurchargeMoney = refundedSurchargeMoney;
            this.RefundedSurcharges = refundedSurcharges;
            this.CreatedAt = createdAt;
            this.ProcessedAt = processedAt;
            this.PaymentId = paymentId;
            this.MerchantId = merchantId;
            this.IsExchange = isExchange;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The merchant-specified reason for the refund.
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; }

        /// <summary>
        /// Gets or sets RefundedMoney.
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Gets or sets RefundedProcessingFeeMoney.
        /// </summary>
        [JsonProperty("refunded_processing_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedProcessingFeeMoney { get; }

        /// <summary>
        /// Gets or sets RefundedTaxMoney.
        /// </summary>
        [JsonProperty("refunded_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedTaxMoney { get; }

        /// <summary>
        /// Gets or sets RefundedAdditiveTaxMoney.
        /// </summary>
        [JsonProperty("refunded_additive_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedAdditiveTaxMoney { get; }

        /// <summary>
        /// All of the additive taxes associated with the refund.
        /// </summary>
        [JsonProperty("refunded_additive_tax", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentTax> RefundedAdditiveTax { get; }

        /// <summary>
        /// Gets or sets RefundedInclusiveTaxMoney.
        /// </summary>
        [JsonProperty("refunded_inclusive_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedInclusiveTaxMoney { get; }

        /// <summary>
        /// All of the inclusive taxes associated with the refund.
        /// </summary>
        [JsonProperty("refunded_inclusive_tax", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentTax> RefundedInclusiveTax { get; }

        /// <summary>
        /// Gets or sets RefundedTipMoney.
        /// </summary>
        [JsonProperty("refunded_tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedTipMoney { get; }

        /// <summary>
        /// Gets or sets RefundedDiscountMoney.
        /// </summary>
        [JsonProperty("refunded_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedDiscountMoney { get; }

        /// <summary>
        /// Gets or sets RefundedSurchargeMoney.
        /// </summary>
        [JsonProperty("refunded_surcharge_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedSurchargeMoney { get; }

        /// <summary>
        /// A list of all surcharges associated with the refund.
        /// </summary>
        [JsonProperty("refunded_surcharges", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentSurcharge> RefundedSurcharges { get; }

        /// <summary>
        /// The time when the merchant initiated the refund for Square to process, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when Square processed the refund on behalf of the merchant, in ISO 8601 format.
        /// </summary>
        [JsonProperty("processed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ProcessedAt { get; }

        /// <summary>
        /// A Square-issued ID associated with the refund. For single-tender refunds, payment_id is the ID of the original payment ID. For split-tender refunds, payment_id is the ID of the original tender. For exchange-based refunds (is_exchange == true), payment_id is the ID of the original payment ID even if the payment includes other tenders.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// Gets or sets MerchantId.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// Indicates whether or not the refund is associated with an exchange. If is_exchange is true, the refund reflects the value of goods returned in the exchange not the total money refunded.
        /// </summary>
        [JsonProperty("is_exchange", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsExchange { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Refund : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1Refund other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.RefundedMoney == null && other.RefundedMoney == null) || (this.RefundedMoney?.Equals(other.RefundedMoney) == true)) &&
                ((this.RefundedProcessingFeeMoney == null && other.RefundedProcessingFeeMoney == null) || (this.RefundedProcessingFeeMoney?.Equals(other.RefundedProcessingFeeMoney) == true)) &&
                ((this.RefundedTaxMoney == null && other.RefundedTaxMoney == null) || (this.RefundedTaxMoney?.Equals(other.RefundedTaxMoney) == true)) &&
                ((this.RefundedAdditiveTaxMoney == null && other.RefundedAdditiveTaxMoney == null) || (this.RefundedAdditiveTaxMoney?.Equals(other.RefundedAdditiveTaxMoney) == true)) &&
                ((this.RefundedAdditiveTax == null && other.RefundedAdditiveTax == null) || (this.RefundedAdditiveTax?.Equals(other.RefundedAdditiveTax) == true)) &&
                ((this.RefundedInclusiveTaxMoney == null && other.RefundedInclusiveTaxMoney == null) || (this.RefundedInclusiveTaxMoney?.Equals(other.RefundedInclusiveTaxMoney) == true)) &&
                ((this.RefundedInclusiveTax == null && other.RefundedInclusiveTax == null) || (this.RefundedInclusiveTax?.Equals(other.RefundedInclusiveTax) == true)) &&
                ((this.RefundedTipMoney == null && other.RefundedTipMoney == null) || (this.RefundedTipMoney?.Equals(other.RefundedTipMoney) == true)) &&
                ((this.RefundedDiscountMoney == null && other.RefundedDiscountMoney == null) || (this.RefundedDiscountMoney?.Equals(other.RefundedDiscountMoney) == true)) &&
                ((this.RefundedSurchargeMoney == null && other.RefundedSurchargeMoney == null) || (this.RefundedSurchargeMoney?.Equals(other.RefundedSurchargeMoney) == true)) &&
                ((this.RefundedSurcharges == null && other.RefundedSurcharges == null) || (this.RefundedSurcharges?.Equals(other.RefundedSurcharges) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.ProcessedAt == null && other.ProcessedAt == null) || (this.ProcessedAt?.Equals(other.ProcessedAt) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.IsExchange == null && other.IsExchange == null) || (this.IsExchange?.Equals(other.IsExchange) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 699909783;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Type, this.Reason, this.RefundedMoney, this.RefundedProcessingFeeMoney, this.RefundedTaxMoney, this.RefundedAdditiveTaxMoney, this.RefundedAdditiveTax);

            hashCode = HashCode.Combine(hashCode, this.RefundedInclusiveTaxMoney, this.RefundedInclusiveTax, this.RefundedTipMoney, this.RefundedDiscountMoney, this.RefundedSurchargeMoney, this.RefundedSurcharges, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.ProcessedAt, this.PaymentId, this.MerchantId, this.IsExchange);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason == string.Empty ? "" : this.Reason)}");
            toStringOutput.Add($"this.RefundedMoney = {(this.RefundedMoney == null ? "null" : this.RefundedMoney.ToString())}");
            toStringOutput.Add($"this.RefundedProcessingFeeMoney = {(this.RefundedProcessingFeeMoney == null ? "null" : this.RefundedProcessingFeeMoney.ToString())}");
            toStringOutput.Add($"this.RefundedTaxMoney = {(this.RefundedTaxMoney == null ? "null" : this.RefundedTaxMoney.ToString())}");
            toStringOutput.Add($"this.RefundedAdditiveTaxMoney = {(this.RefundedAdditiveTaxMoney == null ? "null" : this.RefundedAdditiveTaxMoney.ToString())}");
            toStringOutput.Add($"this.RefundedAdditiveTax = {(this.RefundedAdditiveTax == null ? "null" : $"[{string.Join(", ", this.RefundedAdditiveTax)} ]")}");
            toStringOutput.Add($"this.RefundedInclusiveTaxMoney = {(this.RefundedInclusiveTaxMoney == null ? "null" : this.RefundedInclusiveTaxMoney.ToString())}");
            toStringOutput.Add($"this.RefundedInclusiveTax = {(this.RefundedInclusiveTax == null ? "null" : $"[{string.Join(", ", this.RefundedInclusiveTax)} ]")}");
            toStringOutput.Add($"this.RefundedTipMoney = {(this.RefundedTipMoney == null ? "null" : this.RefundedTipMoney.ToString())}");
            toStringOutput.Add($"this.RefundedDiscountMoney = {(this.RefundedDiscountMoney == null ? "null" : this.RefundedDiscountMoney.ToString())}");
            toStringOutput.Add($"this.RefundedSurchargeMoney = {(this.RefundedSurchargeMoney == null ? "null" : this.RefundedSurchargeMoney.ToString())}");
            toStringOutput.Add($"this.RefundedSurcharges = {(this.RefundedSurcharges == null ? "null" : $"[{string.Join(", ", this.RefundedSurcharges)} ]")}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.ProcessedAt = {(this.ProcessedAt == null ? "null" : this.ProcessedAt == string.Empty ? "" : this.ProcessedAt)}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.IsExchange = {(this.IsExchange == null ? "null" : this.IsExchange.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(this.Type)
                .Reason(this.Reason)
                .RefundedMoney(this.RefundedMoney)
                .RefundedProcessingFeeMoney(this.RefundedProcessingFeeMoney)
                .RefundedTaxMoney(this.RefundedTaxMoney)
                .RefundedAdditiveTaxMoney(this.RefundedAdditiveTaxMoney)
                .RefundedAdditiveTax(this.RefundedAdditiveTax)
                .RefundedInclusiveTaxMoney(this.RefundedInclusiveTaxMoney)
                .RefundedInclusiveTax(this.RefundedInclusiveTax)
                .RefundedTipMoney(this.RefundedTipMoney)
                .RefundedDiscountMoney(this.RefundedDiscountMoney)
                .RefundedSurchargeMoney(this.RefundedSurchargeMoney)
                .RefundedSurcharges(this.RefundedSurcharges)
                .CreatedAt(this.CreatedAt)
                .ProcessedAt(this.ProcessedAt)
                .PaymentId(this.PaymentId)
                .MerchantId(this.MerchantId)
                .IsExchange(this.IsExchange);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string type;
            private string reason;
            private Models.V1Money refundedMoney;
            private Models.V1Money refundedProcessingFeeMoney;
            private Models.V1Money refundedTaxMoney;
            private Models.V1Money refundedAdditiveTaxMoney;
            private IList<Models.V1PaymentTax> refundedAdditiveTax;
            private Models.V1Money refundedInclusiveTaxMoney;
            private IList<Models.V1PaymentTax> refundedInclusiveTax;
            private Models.V1Money refundedTipMoney;
            private Models.V1Money refundedDiscountMoney;
            private Models.V1Money refundedSurchargeMoney;
            private IList<Models.V1PaymentSurcharge> refundedSurcharges;
            private string createdAt;
            private string processedAt;
            private string paymentId;
            private string merchantId;
            private bool? isExchange;

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
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

             /// <summary>
             /// RefundedMoney.
             /// </summary>
             /// <param name="refundedMoney"> refundedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedMoney(Models.V1Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

             /// <summary>
             /// RefundedProcessingFeeMoney.
             /// </summary>
             /// <param name="refundedProcessingFeeMoney"> refundedProcessingFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedProcessingFeeMoney(Models.V1Money refundedProcessingFeeMoney)
            {
                this.refundedProcessingFeeMoney = refundedProcessingFeeMoney;
                return this;
            }

             /// <summary>
             /// RefundedTaxMoney.
             /// </summary>
             /// <param name="refundedTaxMoney"> refundedTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedTaxMoney(Models.V1Money refundedTaxMoney)
            {
                this.refundedTaxMoney = refundedTaxMoney;
                return this;
            }

             /// <summary>
             /// RefundedAdditiveTaxMoney.
             /// </summary>
             /// <param name="refundedAdditiveTaxMoney"> refundedAdditiveTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedAdditiveTaxMoney(Models.V1Money refundedAdditiveTaxMoney)
            {
                this.refundedAdditiveTaxMoney = refundedAdditiveTaxMoney;
                return this;
            }

             /// <summary>
             /// RefundedAdditiveTax.
             /// </summary>
             /// <param name="refundedAdditiveTax"> refundedAdditiveTax. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedAdditiveTax(IList<Models.V1PaymentTax> refundedAdditiveTax)
            {
                this.refundedAdditiveTax = refundedAdditiveTax;
                return this;
            }

             /// <summary>
             /// RefundedInclusiveTaxMoney.
             /// </summary>
             /// <param name="refundedInclusiveTaxMoney"> refundedInclusiveTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedInclusiveTaxMoney(Models.V1Money refundedInclusiveTaxMoney)
            {
                this.refundedInclusiveTaxMoney = refundedInclusiveTaxMoney;
                return this;
            }

             /// <summary>
             /// RefundedInclusiveTax.
             /// </summary>
             /// <param name="refundedInclusiveTax"> refundedInclusiveTax. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedInclusiveTax(IList<Models.V1PaymentTax> refundedInclusiveTax)
            {
                this.refundedInclusiveTax = refundedInclusiveTax;
                return this;
            }

             /// <summary>
             /// RefundedTipMoney.
             /// </summary>
             /// <param name="refundedTipMoney"> refundedTipMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedTipMoney(Models.V1Money refundedTipMoney)
            {
                this.refundedTipMoney = refundedTipMoney;
                return this;
            }

             /// <summary>
             /// RefundedDiscountMoney.
             /// </summary>
             /// <param name="refundedDiscountMoney"> refundedDiscountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedDiscountMoney(Models.V1Money refundedDiscountMoney)
            {
                this.refundedDiscountMoney = refundedDiscountMoney;
                return this;
            }

             /// <summary>
             /// RefundedSurchargeMoney.
             /// </summary>
             /// <param name="refundedSurchargeMoney"> refundedSurchargeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedSurchargeMoney(Models.V1Money refundedSurchargeMoney)
            {
                this.refundedSurchargeMoney = refundedSurchargeMoney;
                return this;
            }

             /// <summary>
             /// RefundedSurcharges.
             /// </summary>
             /// <param name="refundedSurcharges"> refundedSurcharges. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedSurcharges(IList<Models.V1PaymentSurcharge> refundedSurcharges)
            {
                this.refundedSurcharges = refundedSurcharges;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// ProcessedAt.
             /// </summary>
             /// <param name="processedAt"> processedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ProcessedAt(string processedAt)
            {
                this.processedAt = processedAt;
                return this;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

             /// <summary>
             /// IsExchange.
             /// </summary>
             /// <param name="isExchange"> isExchange. </param>
             /// <returns> Builder. </returns>
            public Builder IsExchange(bool? isExchange)
            {
                this.isExchange = isExchange;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Refund. </returns>
            public V1Refund Build()
            {
                return new V1Refund(
                    this.type,
                    this.reason,
                    this.refundedMoney,
                    this.refundedProcessingFeeMoney,
                    this.refundedTaxMoney,
                    this.refundedAdditiveTaxMoney,
                    this.refundedAdditiveTax,
                    this.refundedInclusiveTaxMoney,
                    this.refundedInclusiveTax,
                    this.refundedTipMoney,
                    this.refundedDiscountMoney,
                    this.refundedSurchargeMoney,
                    this.refundedSurcharges,
                    this.createdAt,
                    this.processedAt,
                    this.paymentId,
                    this.merchantId,
                    this.isExchange);
            }
        }
    }
}