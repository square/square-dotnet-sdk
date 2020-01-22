using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Refund 
    {
        public V1Refund(string type = null,
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
            Type = type;
            Reason = reason;
            RefundedMoney = refundedMoney;
            RefundedProcessingFeeMoney = refundedProcessingFeeMoney;
            RefundedTaxMoney = refundedTaxMoney;
            RefundedAdditiveTaxMoney = refundedAdditiveTaxMoney;
            RefundedAdditiveTax = refundedAdditiveTax;
            RefundedInclusiveTaxMoney = refundedInclusiveTaxMoney;
            RefundedInclusiveTax = refundedInclusiveTax;
            RefundedTipMoney = refundedTipMoney;
            RefundedDiscountMoney = refundedDiscountMoney;
            RefundedSurchargeMoney = refundedSurchargeMoney;
            RefundedSurcharges = refundedSurcharges;
            CreatedAt = createdAt;
            ProcessedAt = processedAt;
            PaymentId = paymentId;
            MerchantId = merchantId;
            IsExchange = isExchange;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The merchant-specified reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        /// Getter for refunded_money
        /// </summary>
        [JsonProperty("refunded_money")]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Getter for refunded_processing_fee_money
        /// </summary>
        [JsonProperty("refunded_processing_fee_money")]
        public Models.V1Money RefundedProcessingFeeMoney { get; }

        /// <summary>
        /// Getter for refunded_tax_money
        /// </summary>
        [JsonProperty("refunded_tax_money")]
        public Models.V1Money RefundedTaxMoney { get; }

        /// <summary>
        /// Getter for refunded_additive_tax_money
        /// </summary>
        [JsonProperty("refunded_additive_tax_money")]
        public Models.V1Money RefundedAdditiveTaxMoney { get; }

        /// <summary>
        /// All of the additive taxes associated with the refund.
        /// </summary>
        [JsonProperty("refunded_additive_tax")]
        public IList<Models.V1PaymentTax> RefundedAdditiveTax { get; }

        /// <summary>
        /// Getter for refunded_inclusive_tax_money
        /// </summary>
        [JsonProperty("refunded_inclusive_tax_money")]
        public Models.V1Money RefundedInclusiveTaxMoney { get; }

        /// <summary>
        /// All of the inclusive taxes associated with the refund.
        /// </summary>
        [JsonProperty("refunded_inclusive_tax")]
        public IList<Models.V1PaymentTax> RefundedInclusiveTax { get; }

        /// <summary>
        /// Getter for refunded_tip_money
        /// </summary>
        [JsonProperty("refunded_tip_money")]
        public Models.V1Money RefundedTipMoney { get; }

        /// <summary>
        /// Getter for refunded_discount_money
        /// </summary>
        [JsonProperty("refunded_discount_money")]
        public Models.V1Money RefundedDiscountMoney { get; }

        /// <summary>
        /// Getter for refunded_surcharge_money
        /// </summary>
        [JsonProperty("refunded_surcharge_money")]
        public Models.V1Money RefundedSurchargeMoney { get; }

        /// <summary>
        /// A list of all surcharges associated with the refund.
        /// </summary>
        [JsonProperty("refunded_surcharges")]
        public IList<Models.V1PaymentSurcharge> RefundedSurcharges { get; }

        /// <summary>
        /// The time when the merchant initiated the refund for Square to process, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when Square processed the refund on behalf of the merchant, in ISO 8601 format.
        /// </summary>
        [JsonProperty("processed_at")]
        public string ProcessedAt { get; }

        /// <summary>
        /// A Square-issued ID associated with the refund. For single-tender refunds, payment_id is the ID of the original payment ID. For split-tender refunds, payment_id is the ID of the original tender. For exchange-based refunds (is_exchange == true), payment_id is the ID of the original payment ID even if the payment includes other tenders.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// Getter for merchant_id
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// Indicates whether or not the refund is associated with an exchange. If is_exchange is true, the refund reflects the value of goods returned in the exchange not the total money refunded.
        /// </summary>
        [JsonProperty("is_exchange")]
        public bool? IsExchange { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(Type)
                .Reason(Reason)
                .RefundedMoney(RefundedMoney)
                .RefundedProcessingFeeMoney(RefundedProcessingFeeMoney)
                .RefundedTaxMoney(RefundedTaxMoney)
                .RefundedAdditiveTaxMoney(RefundedAdditiveTaxMoney)
                .RefundedAdditiveTax(RefundedAdditiveTax)
                .RefundedInclusiveTaxMoney(RefundedInclusiveTaxMoney)
                .RefundedInclusiveTax(RefundedInclusiveTax)
                .RefundedTipMoney(RefundedTipMoney)
                .RefundedDiscountMoney(RefundedDiscountMoney)
                .RefundedSurchargeMoney(RefundedSurchargeMoney)
                .RefundedSurcharges(RefundedSurcharges)
                .CreatedAt(CreatedAt)
                .ProcessedAt(ProcessedAt)
                .PaymentId(PaymentId)
                .MerchantId(MerchantId)
                .IsExchange(IsExchange);
            return builder;
        }

        public class Builder
        {
            private string type;
            private string reason;
            private Models.V1Money refundedMoney;
            private Models.V1Money refundedProcessingFeeMoney;
            private Models.V1Money refundedTaxMoney;
            private Models.V1Money refundedAdditiveTaxMoney;
            private IList<Models.V1PaymentTax> refundedAdditiveTax = new List<Models.V1PaymentTax>();
            private Models.V1Money refundedInclusiveTaxMoney;
            private IList<Models.V1PaymentTax> refundedInclusiveTax = new List<Models.V1PaymentTax>();
            private Models.V1Money refundedTipMoney;
            private Models.V1Money refundedDiscountMoney;
            private Models.V1Money refundedSurchargeMoney;
            private IList<Models.V1PaymentSurcharge> refundedSurcharges = new List<Models.V1PaymentSurcharge>();
            private string createdAt;
            private string processedAt;
            private string paymentId;
            private string merchantId;
            private bool? isExchange;

            public Builder() { }
            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Reason(string value)
            {
                reason = value;
                return this;
            }

            public Builder RefundedMoney(Models.V1Money value)
            {
                refundedMoney = value;
                return this;
            }

            public Builder RefundedProcessingFeeMoney(Models.V1Money value)
            {
                refundedProcessingFeeMoney = value;
                return this;
            }

            public Builder RefundedTaxMoney(Models.V1Money value)
            {
                refundedTaxMoney = value;
                return this;
            }

            public Builder RefundedAdditiveTaxMoney(Models.V1Money value)
            {
                refundedAdditiveTaxMoney = value;
                return this;
            }

            public Builder RefundedAdditiveTax(IList<Models.V1PaymentTax> value)
            {
                refundedAdditiveTax = value;
                return this;
            }

            public Builder RefundedInclusiveTaxMoney(Models.V1Money value)
            {
                refundedInclusiveTaxMoney = value;
                return this;
            }

            public Builder RefundedInclusiveTax(IList<Models.V1PaymentTax> value)
            {
                refundedInclusiveTax = value;
                return this;
            }

            public Builder RefundedTipMoney(Models.V1Money value)
            {
                refundedTipMoney = value;
                return this;
            }

            public Builder RefundedDiscountMoney(Models.V1Money value)
            {
                refundedDiscountMoney = value;
                return this;
            }

            public Builder RefundedSurchargeMoney(Models.V1Money value)
            {
                refundedSurchargeMoney = value;
                return this;
            }

            public Builder RefundedSurcharges(IList<Models.V1PaymentSurcharge> value)
            {
                refundedSurcharges = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder ProcessedAt(string value)
            {
                processedAt = value;
                return this;
            }

            public Builder PaymentId(string value)
            {
                paymentId = value;
                return this;
            }

            public Builder MerchantId(string value)
            {
                merchantId = value;
                return this;
            }

            public Builder IsExchange(bool? value)
            {
                isExchange = value;
                return this;
            }

            public V1Refund Build()
            {
                return new V1Refund(type,
                    reason,
                    refundedMoney,
                    refundedProcessingFeeMoney,
                    refundedTaxMoney,
                    refundedAdditiveTaxMoney,
                    refundedAdditiveTax,
                    refundedInclusiveTaxMoney,
                    refundedInclusiveTax,
                    refundedTipMoney,
                    refundedDiscountMoney,
                    refundedSurchargeMoney,
                    refundedSurcharges,
                    createdAt,
                    processedAt,
                    paymentId,
                    merchantId,
                    isExchange);
            }
        }
    }
}