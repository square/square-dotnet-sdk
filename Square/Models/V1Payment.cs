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
    public class V1Payment 
    {
        public V1Payment(string id = null,
            string merchantId = null,
            string createdAt = null,
            string creatorId = null,
            Models.Device device = null,
            string paymentUrl = null,
            string receiptUrl = null,
            Models.V1Money inclusiveTaxMoney = null,
            Models.V1Money additiveTaxMoney = null,
            Models.V1Money taxMoney = null,
            Models.V1Money tipMoney = null,
            Models.V1Money discountMoney = null,
            Models.V1Money totalCollectedMoney = null,
            Models.V1Money processingFeeMoney = null,
            Models.V1Money netTotalMoney = null,
            Models.V1Money refundedMoney = null,
            Models.V1Money swedishRoundingMoney = null,
            Models.V1Money grossSalesMoney = null,
            Models.V1Money netSalesMoney = null,
            IList<Models.V1PaymentTax> inclusiveTax = null,
            IList<Models.V1PaymentTax> additiveTax = null,
            IList<Models.V1Tender> tender = null,
            IList<Models.V1Refund> refunds = null,
            IList<Models.V1PaymentItemization> itemizations = null,
            Models.V1Money surchargeMoney = null,
            IList<Models.V1PaymentSurcharge> surcharges = null,
            bool? isPartial = null)
        {
            Id = id;
            MerchantId = merchantId;
            CreatedAt = createdAt;
            CreatorId = creatorId;
            Device = device;
            PaymentUrl = paymentUrl;
            ReceiptUrl = receiptUrl;
            InclusiveTaxMoney = inclusiveTaxMoney;
            AdditiveTaxMoney = additiveTaxMoney;
            TaxMoney = taxMoney;
            TipMoney = tipMoney;
            DiscountMoney = discountMoney;
            TotalCollectedMoney = totalCollectedMoney;
            ProcessingFeeMoney = processingFeeMoney;
            NetTotalMoney = netTotalMoney;
            RefundedMoney = refundedMoney;
            SwedishRoundingMoney = swedishRoundingMoney;
            GrossSalesMoney = grossSalesMoney;
            NetSalesMoney = netSalesMoney;
            InclusiveTax = inclusiveTax;
            AdditiveTax = additiveTax;
            Tender = tender;
            Refunds = refunds;
            Itemizations = itemizations;
            SurchargeMoney = surchargeMoney;
            Surcharges = surcharges;
            IsPartial = isPartial;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The payment's unique identifier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The unique identifier of the merchant that took the payment.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// The time when the payment was created, in ISO 8601 format. Reflects the time of the first payment if the object represents an incomplete partial payment, and the time of the last or complete payment otherwise.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The unique identifier of the Square account that took the payment.
        /// </summary>
        [JsonProperty("creator_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorId { get; }

        /// <summary>
        /// Getter for device
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Device Device { get; }

        /// <summary>
        /// The URL of the payment's detail page in the merchant dashboard. The merchant must be signed in to the merchant dashboard to view this page.
        /// </summary>
        [JsonProperty("payment_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentUrl { get; }

        /// <summary>
        /// The URL of the receipt for the payment. Note that for split tender
        /// payments, this URL corresponds to the receipt for the first tender
        /// listed in the payment's tender field. Each Tender object has its own
        /// receipt_url field you can use to get the other receipts associated with
        /// a split tender payment.
        /// </summary>
        [JsonProperty("receipt_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiptUrl { get; }

        /// <summary>
        /// Getter for inclusive_tax_money
        /// </summary>
        [JsonProperty("inclusive_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money InclusiveTaxMoney { get; }

        /// <summary>
        /// Getter for additive_tax_money
        /// </summary>
        [JsonProperty("additive_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AdditiveTaxMoney { get; }

        /// <summary>
        /// Getter for tax_money
        /// </summary>
        [JsonProperty("tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TaxMoney { get; }

        /// <summary>
        /// Getter for tip_money
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TipMoney { get; }

        /// <summary>
        /// Getter for discount_money
        /// </summary>
        [JsonProperty("discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money DiscountMoney { get; }

        /// <summary>
        /// Getter for total_collected_money
        /// </summary>
        [JsonProperty("total_collected_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalCollectedMoney { get; }

        /// <summary>
        /// Getter for processing_fee_money
        /// </summary>
        [JsonProperty("processing_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money ProcessingFeeMoney { get; }

        /// <summary>
        /// Getter for net_total_money
        /// </summary>
        [JsonProperty("net_total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money NetTotalMoney { get; }

        /// <summary>
        /// Getter for refunded_money
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Getter for swedish_rounding_money
        /// </summary>
        [JsonProperty("swedish_rounding_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SwedishRoundingMoney { get; }

        /// <summary>
        /// Getter for gross_sales_money
        /// </summary>
        [JsonProperty("gross_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money GrossSalesMoney { get; }

        /// <summary>
        /// Getter for net_sales_money
        /// </summary>
        [JsonProperty("net_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money NetSalesMoney { get; }

        /// <summary>
        /// All of the inclusive taxes associated with the payment.
        /// </summary>
        [JsonProperty("inclusive_tax", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentTax> InclusiveTax { get; }

        /// <summary>
        /// All of the additive taxes associated with the payment.
        /// </summary>
        [JsonProperty("additive_tax", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentTax> AdditiveTax { get; }

        /// <summary>
        /// All of the tenders associated with the payment.
        /// </summary>
        [JsonProperty("tender", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Tender> Tender { get; }

        /// <summary>
        /// All of the refunds applied to the payment. Note that the value of all refunds on a payment can exceed the value of all tenders if a merchant chooses to refund money to a tender after previously accepting returned goods as part of an exchange.
        /// </summary>
        [JsonProperty("refunds", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Refund> Refunds { get; }

        /// <summary>
        /// The items purchased in the payment.
        /// </summary>
        [JsonProperty("itemizations", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentItemization> Itemizations { get; }

        /// <summary>
        /// Getter for surcharge_money
        /// </summary>
        [JsonProperty("surcharge_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SurchargeMoney { get; }

        /// <summary>
        /// A list of all surcharges associated with the payment.
        /// </summary>
        [JsonProperty("surcharges", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentSurcharge> Surcharges { get; }

        /// <summary>
        /// Indicates whether or not the payment is only partially paid for.
        /// If true, this payment will have the tenders collected so far, but the
        /// itemizations will be empty until the payment is completed.
        /// </summary>
        [JsonProperty("is_partial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPartial { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .MerchantId(MerchantId)
                .CreatedAt(CreatedAt)
                .CreatorId(CreatorId)
                .Device(Device)
                .PaymentUrl(PaymentUrl)
                .ReceiptUrl(ReceiptUrl)
                .InclusiveTaxMoney(InclusiveTaxMoney)
                .AdditiveTaxMoney(AdditiveTaxMoney)
                .TaxMoney(TaxMoney)
                .TipMoney(TipMoney)
                .DiscountMoney(DiscountMoney)
                .TotalCollectedMoney(TotalCollectedMoney)
                .ProcessingFeeMoney(ProcessingFeeMoney)
                .NetTotalMoney(NetTotalMoney)
                .RefundedMoney(RefundedMoney)
                .SwedishRoundingMoney(SwedishRoundingMoney)
                .GrossSalesMoney(GrossSalesMoney)
                .NetSalesMoney(NetSalesMoney)
                .InclusiveTax(InclusiveTax)
                .AdditiveTax(AdditiveTax)
                .Tender(Tender)
                .Refunds(Refunds)
                .Itemizations(Itemizations)
                .SurchargeMoney(SurchargeMoney)
                .Surcharges(Surcharges)
                .IsPartial(IsPartial);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string merchantId;
            private string createdAt;
            private string creatorId;
            private Models.Device device;
            private string paymentUrl;
            private string receiptUrl;
            private Models.V1Money inclusiveTaxMoney;
            private Models.V1Money additiveTaxMoney;
            private Models.V1Money taxMoney;
            private Models.V1Money tipMoney;
            private Models.V1Money discountMoney;
            private Models.V1Money totalCollectedMoney;
            private Models.V1Money processingFeeMoney;
            private Models.V1Money netTotalMoney;
            private Models.V1Money refundedMoney;
            private Models.V1Money swedishRoundingMoney;
            private Models.V1Money grossSalesMoney;
            private Models.V1Money netSalesMoney;
            private IList<Models.V1PaymentTax> inclusiveTax;
            private IList<Models.V1PaymentTax> additiveTax;
            private IList<Models.V1Tender> tender;
            private IList<Models.V1Refund> refunds;
            private IList<Models.V1PaymentItemization> itemizations;
            private Models.V1Money surchargeMoney;
            private IList<Models.V1PaymentSurcharge> surcharges;
            private bool? isPartial;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder CreatorId(string creatorId)
            {
                this.creatorId = creatorId;
                return this;
            }

            public Builder Device(Models.Device device)
            {
                this.device = device;
                return this;
            }

            public Builder PaymentUrl(string paymentUrl)
            {
                this.paymentUrl = paymentUrl;
                return this;
            }

            public Builder ReceiptUrl(string receiptUrl)
            {
                this.receiptUrl = receiptUrl;
                return this;
            }

            public Builder InclusiveTaxMoney(Models.V1Money inclusiveTaxMoney)
            {
                this.inclusiveTaxMoney = inclusiveTaxMoney;
                return this;
            }

            public Builder AdditiveTaxMoney(Models.V1Money additiveTaxMoney)
            {
                this.additiveTaxMoney = additiveTaxMoney;
                return this;
            }

            public Builder TaxMoney(Models.V1Money taxMoney)
            {
                this.taxMoney = taxMoney;
                return this;
            }

            public Builder TipMoney(Models.V1Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

            public Builder DiscountMoney(Models.V1Money discountMoney)
            {
                this.discountMoney = discountMoney;
                return this;
            }

            public Builder TotalCollectedMoney(Models.V1Money totalCollectedMoney)
            {
                this.totalCollectedMoney = totalCollectedMoney;
                return this;
            }

            public Builder ProcessingFeeMoney(Models.V1Money processingFeeMoney)
            {
                this.processingFeeMoney = processingFeeMoney;
                return this;
            }

            public Builder NetTotalMoney(Models.V1Money netTotalMoney)
            {
                this.netTotalMoney = netTotalMoney;
                return this;
            }

            public Builder RefundedMoney(Models.V1Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

            public Builder SwedishRoundingMoney(Models.V1Money swedishRoundingMoney)
            {
                this.swedishRoundingMoney = swedishRoundingMoney;
                return this;
            }

            public Builder GrossSalesMoney(Models.V1Money grossSalesMoney)
            {
                this.grossSalesMoney = grossSalesMoney;
                return this;
            }

            public Builder NetSalesMoney(Models.V1Money netSalesMoney)
            {
                this.netSalesMoney = netSalesMoney;
                return this;
            }

            public Builder InclusiveTax(IList<Models.V1PaymentTax> inclusiveTax)
            {
                this.inclusiveTax = inclusiveTax;
                return this;
            }

            public Builder AdditiveTax(IList<Models.V1PaymentTax> additiveTax)
            {
                this.additiveTax = additiveTax;
                return this;
            }

            public Builder Tender(IList<Models.V1Tender> tender)
            {
                this.tender = tender;
                return this;
            }

            public Builder Refunds(IList<Models.V1Refund> refunds)
            {
                this.refunds = refunds;
                return this;
            }

            public Builder Itemizations(IList<Models.V1PaymentItemization> itemizations)
            {
                this.itemizations = itemizations;
                return this;
            }

            public Builder SurchargeMoney(Models.V1Money surchargeMoney)
            {
                this.surchargeMoney = surchargeMoney;
                return this;
            }

            public Builder Surcharges(IList<Models.V1PaymentSurcharge> surcharges)
            {
                this.surcharges = surcharges;
                return this;
            }

            public Builder IsPartial(bool? isPartial)
            {
                this.isPartial = isPartial;
                return this;
            }

            public V1Payment Build()
            {
                return new V1Payment(id,
                    merchantId,
                    createdAt,
                    creatorId,
                    device,
                    paymentUrl,
                    receiptUrl,
                    inclusiveTaxMoney,
                    additiveTaxMoney,
                    taxMoney,
                    tipMoney,
                    discountMoney,
                    totalCollectedMoney,
                    processingFeeMoney,
                    netTotalMoney,
                    refundedMoney,
                    swedishRoundingMoney,
                    grossSalesMoney,
                    netSalesMoney,
                    inclusiveTax,
                    additiveTax,
                    tender,
                    refunds,
                    itemizations,
                    surchargeMoney,
                    surcharges,
                    isPartial);
            }
        }
    }
}