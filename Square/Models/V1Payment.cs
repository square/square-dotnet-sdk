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
    /// V1Payment.
    /// </summary>
    public class V1Payment
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Payment"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="creatorId">creator_id.</param>
        /// <param name="device">device.</param>
        /// <param name="paymentUrl">payment_url.</param>
        /// <param name="receiptUrl">receipt_url.</param>
        /// <param name="inclusiveTaxMoney">inclusive_tax_money.</param>
        /// <param name="additiveTaxMoney">additive_tax_money.</param>
        /// <param name="taxMoney">tax_money.</param>
        /// <param name="tipMoney">tip_money.</param>
        /// <param name="discountMoney">discount_money.</param>
        /// <param name="totalCollectedMoney">total_collected_money.</param>
        /// <param name="processingFeeMoney">processing_fee_money.</param>
        /// <param name="netTotalMoney">net_total_money.</param>
        /// <param name="refundedMoney">refunded_money.</param>
        /// <param name="swedishRoundingMoney">swedish_rounding_money.</param>
        /// <param name="grossSalesMoney">gross_sales_money.</param>
        /// <param name="netSalesMoney">net_sales_money.</param>
        /// <param name="inclusiveTax">inclusive_tax.</param>
        /// <param name="additiveTax">additive_tax.</param>
        /// <param name="tender">tender.</param>
        /// <param name="refunds">refunds.</param>
        /// <param name="itemizations">itemizations.</param>
        /// <param name="surchargeMoney">surcharge_money.</param>
        /// <param name="surcharges">surcharges.</param>
        /// <param name="isPartial">is_partial.</param>
        public V1Payment(
            string id = null,
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "merchant_id", false },
                { "creator_id", false },
                { "payment_url", false },
                { "receipt_url", false },
                { "inclusive_tax", false },
                { "additive_tax", false },
                { "tender", false },
                { "refunds", false },
                { "itemizations", false },
                { "surcharges", false },
                { "is_partial", false }
            };

            this.Id = id;
            if (merchantId != null)
            {
                shouldSerialize["merchant_id"] = true;
                this.MerchantId = merchantId;
            }

            this.CreatedAt = createdAt;
            if (creatorId != null)
            {
                shouldSerialize["creator_id"] = true;
                this.CreatorId = creatorId;
            }

            this.Device = device;
            if (paymentUrl != null)
            {
                shouldSerialize["payment_url"] = true;
                this.PaymentUrl = paymentUrl;
            }

            if (receiptUrl != null)
            {
                shouldSerialize["receipt_url"] = true;
                this.ReceiptUrl = receiptUrl;
            }

            this.InclusiveTaxMoney = inclusiveTaxMoney;
            this.AdditiveTaxMoney = additiveTaxMoney;
            this.TaxMoney = taxMoney;
            this.TipMoney = tipMoney;
            this.DiscountMoney = discountMoney;
            this.TotalCollectedMoney = totalCollectedMoney;
            this.ProcessingFeeMoney = processingFeeMoney;
            this.NetTotalMoney = netTotalMoney;
            this.RefundedMoney = refundedMoney;
            this.SwedishRoundingMoney = swedishRoundingMoney;
            this.GrossSalesMoney = grossSalesMoney;
            this.NetSalesMoney = netSalesMoney;
            if (inclusiveTax != null)
            {
                shouldSerialize["inclusive_tax"] = true;
                this.InclusiveTax = inclusiveTax;
            }

            if (additiveTax != null)
            {
                shouldSerialize["additive_tax"] = true;
                this.AdditiveTax = additiveTax;
            }

            if (tender != null)
            {
                shouldSerialize["tender"] = true;
                this.Tender = tender;
            }

            if (refunds != null)
            {
                shouldSerialize["refunds"] = true;
                this.Refunds = refunds;
            }

            if (itemizations != null)
            {
                shouldSerialize["itemizations"] = true;
                this.Itemizations = itemizations;
            }

            this.SurchargeMoney = surchargeMoney;
            if (surcharges != null)
            {
                shouldSerialize["surcharges"] = true;
                this.Surcharges = surcharges;
            }

            if (isPartial != null)
            {
                shouldSerialize["is_partial"] = true;
                this.IsPartial = isPartial;
            }

        }
        internal V1Payment(Dictionary<string, bool> shouldSerialize,
            string id = null,
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
            this.shouldSerialize = shouldSerialize;
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

        /// <summary>
        /// Gets http context.
        /// </summary>
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
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The time when the payment was created, in ISO 8601 format. Reflects the time of the first payment if the object represents an incomplete partial payment, and the time of the last or complete payment otherwise.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The unique identifier of the Square account that took the payment.
        /// </summary>
        [JsonProperty("creator_id")]
        public string CreatorId { get; }

        /// <summary>
        /// Gets or sets Device.
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Device Device { get; }

        /// <summary>
        /// The URL of the payment's detail page in the merchant dashboard. The merchant must be signed in to the merchant dashboard to view this page.
        /// </summary>
        [JsonProperty("payment_url")]
        public string PaymentUrl { get; }

        /// <summary>
        /// The URL of the receipt for the payment. Note that for split tender
        /// payments, this URL corresponds to the receipt for the first tender
        /// listed in the payment's tender field. Each Tender object has its own
        /// receipt_url field you can use to get the other receipts associated with
        /// a split tender payment.
        /// </summary>
        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; }

        /// <summary>
        /// Gets or sets InclusiveTaxMoney.
        /// </summary>
        [JsonProperty("inclusive_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money InclusiveTaxMoney { get; }

        /// <summary>
        /// Gets or sets AdditiveTaxMoney.
        /// </summary>
        [JsonProperty("additive_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AdditiveTaxMoney { get; }

        /// <summary>
        /// Gets or sets TaxMoney.
        /// </summary>
        [JsonProperty("tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TaxMoney { get; }

        /// <summary>
        /// Gets or sets TipMoney.
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TipMoney { get; }

        /// <summary>
        /// Gets or sets DiscountMoney.
        /// </summary>
        [JsonProperty("discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money DiscountMoney { get; }

        /// <summary>
        /// Gets or sets TotalCollectedMoney.
        /// </summary>
        [JsonProperty("total_collected_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalCollectedMoney { get; }

        /// <summary>
        /// Gets or sets ProcessingFeeMoney.
        /// </summary>
        [JsonProperty("processing_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money ProcessingFeeMoney { get; }

        /// <summary>
        /// Gets or sets NetTotalMoney.
        /// </summary>
        [JsonProperty("net_total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money NetTotalMoney { get; }

        /// <summary>
        /// Gets or sets RefundedMoney.
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// Gets or sets SwedishRoundingMoney.
        /// </summary>
        [JsonProperty("swedish_rounding_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SwedishRoundingMoney { get; }

        /// <summary>
        /// Gets or sets GrossSalesMoney.
        /// </summary>
        [JsonProperty("gross_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money GrossSalesMoney { get; }

        /// <summary>
        /// Gets or sets NetSalesMoney.
        /// </summary>
        [JsonProperty("net_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money NetSalesMoney { get; }

        /// <summary>
        /// All of the inclusive taxes associated with the payment.
        /// </summary>
        [JsonProperty("inclusive_tax")]
        public IList<Models.V1PaymentTax> InclusiveTax { get; }

        /// <summary>
        /// All of the additive taxes associated with the payment.
        /// </summary>
        [JsonProperty("additive_tax")]
        public IList<Models.V1PaymentTax> AdditiveTax { get; }

        /// <summary>
        /// All of the tenders associated with the payment.
        /// </summary>
        [JsonProperty("tender")]
        public IList<Models.V1Tender> Tender { get; }

        /// <summary>
        /// All of the refunds applied to the payment. Note that the value of all refunds on a payment can exceed the value of all tenders if a merchant chooses to refund money to a tender after previously accepting returned goods as part of an exchange.
        /// </summary>
        [JsonProperty("refunds")]
        public IList<Models.V1Refund> Refunds { get; }

        /// <summary>
        /// The items purchased in the payment.
        /// </summary>
        [JsonProperty("itemizations")]
        public IList<Models.V1PaymentItemization> Itemizations { get; }

        /// <summary>
        /// Gets or sets SurchargeMoney.
        /// </summary>
        [JsonProperty("surcharge_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SurchargeMoney { get; }

        /// <summary>
        /// A list of all surcharges associated with the payment.
        /// </summary>
        [JsonProperty("surcharges")]
        public IList<Models.V1PaymentSurcharge> Surcharges { get; }

        /// <summary>
        /// Indicates whether or not the payment is only partially paid for.
        /// If true, this payment will have the tenders collected so far, but the
        /// itemizations will be empty until the payment is completed.
        /// </summary>
        [JsonProperty("is_partial")]
        public bool? IsPartial { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Payment : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantId()
        {
            return this.shouldSerialize["merchant_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatorId()
        {
            return this.shouldSerialize["creator_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentUrl()
        {
            return this.shouldSerialize["payment_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceiptUrl()
        {
            return this.shouldSerialize["receipt_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInclusiveTax()
        {
            return this.shouldSerialize["inclusive_tax"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAdditiveTax()
        {
            return this.shouldSerialize["additive_tax"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTender()
        {
            return this.shouldSerialize["tender"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRefunds()
        {
            return this.shouldSerialize["refunds"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemizations()
        {
            return this.shouldSerialize["itemizations"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSurcharges()
        {
            return this.shouldSerialize["surcharges"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsPartial()
        {
            return this.shouldSerialize["is_partial"];
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

            return obj is V1Payment other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.CreatorId == null && other.CreatorId == null) || (this.CreatorId?.Equals(other.CreatorId) == true)) &&
                ((this.Device == null && other.Device == null) || (this.Device?.Equals(other.Device) == true)) &&
                ((this.PaymentUrl == null && other.PaymentUrl == null) || (this.PaymentUrl?.Equals(other.PaymentUrl) == true)) &&
                ((this.ReceiptUrl == null && other.ReceiptUrl == null) || (this.ReceiptUrl?.Equals(other.ReceiptUrl) == true)) &&
                ((this.InclusiveTaxMoney == null && other.InclusiveTaxMoney == null) || (this.InclusiveTaxMoney?.Equals(other.InclusiveTaxMoney) == true)) &&
                ((this.AdditiveTaxMoney == null && other.AdditiveTaxMoney == null) || (this.AdditiveTaxMoney?.Equals(other.AdditiveTaxMoney) == true)) &&
                ((this.TaxMoney == null && other.TaxMoney == null) || (this.TaxMoney?.Equals(other.TaxMoney) == true)) &&
                ((this.TipMoney == null && other.TipMoney == null) || (this.TipMoney?.Equals(other.TipMoney) == true)) &&
                ((this.DiscountMoney == null && other.DiscountMoney == null) || (this.DiscountMoney?.Equals(other.DiscountMoney) == true)) &&
                ((this.TotalCollectedMoney == null && other.TotalCollectedMoney == null) || (this.TotalCollectedMoney?.Equals(other.TotalCollectedMoney) == true)) &&
                ((this.ProcessingFeeMoney == null && other.ProcessingFeeMoney == null) || (this.ProcessingFeeMoney?.Equals(other.ProcessingFeeMoney) == true)) &&
                ((this.NetTotalMoney == null && other.NetTotalMoney == null) || (this.NetTotalMoney?.Equals(other.NetTotalMoney) == true)) &&
                ((this.RefundedMoney == null && other.RefundedMoney == null) || (this.RefundedMoney?.Equals(other.RefundedMoney) == true)) &&
                ((this.SwedishRoundingMoney == null && other.SwedishRoundingMoney == null) || (this.SwedishRoundingMoney?.Equals(other.SwedishRoundingMoney) == true)) &&
                ((this.GrossSalesMoney == null && other.GrossSalesMoney == null) || (this.GrossSalesMoney?.Equals(other.GrossSalesMoney) == true)) &&
                ((this.NetSalesMoney == null && other.NetSalesMoney == null) || (this.NetSalesMoney?.Equals(other.NetSalesMoney) == true)) &&
                ((this.InclusiveTax == null && other.InclusiveTax == null) || (this.InclusiveTax?.Equals(other.InclusiveTax) == true)) &&
                ((this.AdditiveTax == null && other.AdditiveTax == null) || (this.AdditiveTax?.Equals(other.AdditiveTax) == true)) &&
                ((this.Tender == null && other.Tender == null) || (this.Tender?.Equals(other.Tender) == true)) &&
                ((this.Refunds == null && other.Refunds == null) || (this.Refunds?.Equals(other.Refunds) == true)) &&
                ((this.Itemizations == null && other.Itemizations == null) || (this.Itemizations?.Equals(other.Itemizations) == true)) &&
                ((this.SurchargeMoney == null && other.SurchargeMoney == null) || (this.SurchargeMoney?.Equals(other.SurchargeMoney) == true)) &&
                ((this.Surcharges == null && other.Surcharges == null) || (this.Surcharges?.Equals(other.Surcharges) == true)) &&
                ((this.IsPartial == null && other.IsPartial == null) || (this.IsPartial?.Equals(other.IsPartial) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -215174345;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Id, this.MerchantId, this.CreatedAt, this.CreatorId, this.Device, this.PaymentUrl, this.ReceiptUrl);

            hashCode = HashCode.Combine(hashCode, this.InclusiveTaxMoney, this.AdditiveTaxMoney, this.TaxMoney, this.TipMoney, this.DiscountMoney, this.TotalCollectedMoney, this.ProcessingFeeMoney);

            hashCode = HashCode.Combine(hashCode, this.NetTotalMoney, this.RefundedMoney, this.SwedishRoundingMoney, this.GrossSalesMoney, this.NetSalesMoney, this.InclusiveTax, this.AdditiveTax);

            hashCode = HashCode.Combine(hashCode, this.Tender, this.Refunds, this.Itemizations, this.SurchargeMoney, this.Surcharges, this.IsPartial);

            return hashCode;
        }
        internal V1Payment ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.CreatorId = {(this.CreatorId == null ? "null" : this.CreatorId == string.Empty ? "" : this.CreatorId)}");
            toStringOutput.Add($"this.Device = {(this.Device == null ? "null" : this.Device.ToString())}");
            toStringOutput.Add($"this.PaymentUrl = {(this.PaymentUrl == null ? "null" : this.PaymentUrl == string.Empty ? "" : this.PaymentUrl)}");
            toStringOutput.Add($"this.ReceiptUrl = {(this.ReceiptUrl == null ? "null" : this.ReceiptUrl == string.Empty ? "" : this.ReceiptUrl)}");
            toStringOutput.Add($"this.InclusiveTaxMoney = {(this.InclusiveTaxMoney == null ? "null" : this.InclusiveTaxMoney.ToString())}");
            toStringOutput.Add($"this.AdditiveTaxMoney = {(this.AdditiveTaxMoney == null ? "null" : this.AdditiveTaxMoney.ToString())}");
            toStringOutput.Add($"this.TaxMoney = {(this.TaxMoney == null ? "null" : this.TaxMoney.ToString())}");
            toStringOutput.Add($"this.TipMoney = {(this.TipMoney == null ? "null" : this.TipMoney.ToString())}");
            toStringOutput.Add($"this.DiscountMoney = {(this.DiscountMoney == null ? "null" : this.DiscountMoney.ToString())}");
            toStringOutput.Add($"this.TotalCollectedMoney = {(this.TotalCollectedMoney == null ? "null" : this.TotalCollectedMoney.ToString())}");
            toStringOutput.Add($"this.ProcessingFeeMoney = {(this.ProcessingFeeMoney == null ? "null" : this.ProcessingFeeMoney.ToString())}");
            toStringOutput.Add($"this.NetTotalMoney = {(this.NetTotalMoney == null ? "null" : this.NetTotalMoney.ToString())}");
            toStringOutput.Add($"this.RefundedMoney = {(this.RefundedMoney == null ? "null" : this.RefundedMoney.ToString())}");
            toStringOutput.Add($"this.SwedishRoundingMoney = {(this.SwedishRoundingMoney == null ? "null" : this.SwedishRoundingMoney.ToString())}");
            toStringOutput.Add($"this.GrossSalesMoney = {(this.GrossSalesMoney == null ? "null" : this.GrossSalesMoney.ToString())}");
            toStringOutput.Add($"this.NetSalesMoney = {(this.NetSalesMoney == null ? "null" : this.NetSalesMoney.ToString())}");
            toStringOutput.Add($"this.InclusiveTax = {(this.InclusiveTax == null ? "null" : $"[{string.Join(", ", this.InclusiveTax)} ]")}");
            toStringOutput.Add($"this.AdditiveTax = {(this.AdditiveTax == null ? "null" : $"[{string.Join(", ", this.AdditiveTax)} ]")}");
            toStringOutput.Add($"this.Tender = {(this.Tender == null ? "null" : $"[{string.Join(", ", this.Tender)} ]")}");
            toStringOutput.Add($"this.Refunds = {(this.Refunds == null ? "null" : $"[{string.Join(", ", this.Refunds)} ]")}");
            toStringOutput.Add($"this.Itemizations = {(this.Itemizations == null ? "null" : $"[{string.Join(", ", this.Itemizations)} ]")}");
            toStringOutput.Add($"this.SurchargeMoney = {(this.SurchargeMoney == null ? "null" : this.SurchargeMoney.ToString())}");
            toStringOutput.Add($"this.Surcharges = {(this.Surcharges == null ? "null" : $"[{string.Join(", ", this.Surcharges)} ]")}");
            toStringOutput.Add($"this.IsPartial = {(this.IsPartial == null ? "null" : this.IsPartial.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .MerchantId(this.MerchantId)
                .CreatedAt(this.CreatedAt)
                .CreatorId(this.CreatorId)
                .Device(this.Device)
                .PaymentUrl(this.PaymentUrl)
                .ReceiptUrl(this.ReceiptUrl)
                .InclusiveTaxMoney(this.InclusiveTaxMoney)
                .AdditiveTaxMoney(this.AdditiveTaxMoney)
                .TaxMoney(this.TaxMoney)
                .TipMoney(this.TipMoney)
                .DiscountMoney(this.DiscountMoney)
                .TotalCollectedMoney(this.TotalCollectedMoney)
                .ProcessingFeeMoney(this.ProcessingFeeMoney)
                .NetTotalMoney(this.NetTotalMoney)
                .RefundedMoney(this.RefundedMoney)
                .SwedishRoundingMoney(this.SwedishRoundingMoney)
                .GrossSalesMoney(this.GrossSalesMoney)
                .NetSalesMoney(this.NetSalesMoney)
                .InclusiveTax(this.InclusiveTax)
                .AdditiveTax(this.AdditiveTax)
                .Tender(this.Tender)
                .Refunds(this.Refunds)
                .Itemizations(this.Itemizations)
                .SurchargeMoney(this.SurchargeMoney)
                .Surcharges(this.Surcharges)
                .IsPartial(this.IsPartial);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "merchant_id", false },
                { "creator_id", false },
                { "payment_url", false },
                { "receipt_url", false },
                { "inclusive_tax", false },
                { "additive_tax", false },
                { "tender", false },
                { "refunds", false },
                { "itemizations", false },
                { "surcharges", false },
                { "is_partial", false },
            };

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
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                shouldSerialize["merchant_id"] = true;
                this.merchantId = merchantId;
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
             /// CreatorId.
             /// </summary>
             /// <param name="creatorId"> creatorId. </param>
             /// <returns> Builder. </returns>
            public Builder CreatorId(string creatorId)
            {
                shouldSerialize["creator_id"] = true;
                this.creatorId = creatorId;
                return this;
            }

             /// <summary>
             /// Device.
             /// </summary>
             /// <param name="device"> device. </param>
             /// <returns> Builder. </returns>
            public Builder Device(Models.Device device)
            {
                this.device = device;
                return this;
            }

             /// <summary>
             /// PaymentUrl.
             /// </summary>
             /// <param name="paymentUrl"> paymentUrl. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentUrl(string paymentUrl)
            {
                shouldSerialize["payment_url"] = true;
                this.paymentUrl = paymentUrl;
                return this;
            }

             /// <summary>
             /// ReceiptUrl.
             /// </summary>
             /// <param name="receiptUrl"> receiptUrl. </param>
             /// <returns> Builder. </returns>
            public Builder ReceiptUrl(string receiptUrl)
            {
                shouldSerialize["receipt_url"] = true;
                this.receiptUrl = receiptUrl;
                return this;
            }

             /// <summary>
             /// InclusiveTaxMoney.
             /// </summary>
             /// <param name="inclusiveTaxMoney"> inclusiveTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder InclusiveTaxMoney(Models.V1Money inclusiveTaxMoney)
            {
                this.inclusiveTaxMoney = inclusiveTaxMoney;
                return this;
            }

             /// <summary>
             /// AdditiveTaxMoney.
             /// </summary>
             /// <param name="additiveTaxMoney"> additiveTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AdditiveTaxMoney(Models.V1Money additiveTaxMoney)
            {
                this.additiveTaxMoney = additiveTaxMoney;
                return this;
            }

             /// <summary>
             /// TaxMoney.
             /// </summary>
             /// <param name="taxMoney"> taxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TaxMoney(Models.V1Money taxMoney)
            {
                this.taxMoney = taxMoney;
                return this;
            }

             /// <summary>
             /// TipMoney.
             /// </summary>
             /// <param name="tipMoney"> tipMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TipMoney(Models.V1Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

             /// <summary>
             /// DiscountMoney.
             /// </summary>
             /// <param name="discountMoney"> discountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountMoney(Models.V1Money discountMoney)
            {
                this.discountMoney = discountMoney;
                return this;
            }

             /// <summary>
             /// TotalCollectedMoney.
             /// </summary>
             /// <param name="totalCollectedMoney"> totalCollectedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalCollectedMoney(Models.V1Money totalCollectedMoney)
            {
                this.totalCollectedMoney = totalCollectedMoney;
                return this;
            }

             /// <summary>
             /// ProcessingFeeMoney.
             /// </summary>
             /// <param name="processingFeeMoney"> processingFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ProcessingFeeMoney(Models.V1Money processingFeeMoney)
            {
                this.processingFeeMoney = processingFeeMoney;
                return this;
            }

             /// <summary>
             /// NetTotalMoney.
             /// </summary>
             /// <param name="netTotalMoney"> netTotalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder NetTotalMoney(Models.V1Money netTotalMoney)
            {
                this.netTotalMoney = netTotalMoney;
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
             /// SwedishRoundingMoney.
             /// </summary>
             /// <param name="swedishRoundingMoney"> swedishRoundingMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SwedishRoundingMoney(Models.V1Money swedishRoundingMoney)
            {
                this.swedishRoundingMoney = swedishRoundingMoney;
                return this;
            }

             /// <summary>
             /// GrossSalesMoney.
             /// </summary>
             /// <param name="grossSalesMoney"> grossSalesMoney. </param>
             /// <returns> Builder. </returns>
            public Builder GrossSalesMoney(Models.V1Money grossSalesMoney)
            {
                this.grossSalesMoney = grossSalesMoney;
                return this;
            }

             /// <summary>
             /// NetSalesMoney.
             /// </summary>
             /// <param name="netSalesMoney"> netSalesMoney. </param>
             /// <returns> Builder. </returns>
            public Builder NetSalesMoney(Models.V1Money netSalesMoney)
            {
                this.netSalesMoney = netSalesMoney;
                return this;
            }

             /// <summary>
             /// InclusiveTax.
             /// </summary>
             /// <param name="inclusiveTax"> inclusiveTax. </param>
             /// <returns> Builder. </returns>
            public Builder InclusiveTax(IList<Models.V1PaymentTax> inclusiveTax)
            {
                shouldSerialize["inclusive_tax"] = true;
                this.inclusiveTax = inclusiveTax;
                return this;
            }

             /// <summary>
             /// AdditiveTax.
             /// </summary>
             /// <param name="additiveTax"> additiveTax. </param>
             /// <returns> Builder. </returns>
            public Builder AdditiveTax(IList<Models.V1PaymentTax> additiveTax)
            {
                shouldSerialize["additive_tax"] = true;
                this.additiveTax = additiveTax;
                return this;
            }

             /// <summary>
             /// Tender.
             /// </summary>
             /// <param name="tender"> tender. </param>
             /// <returns> Builder. </returns>
            public Builder Tender(IList<Models.V1Tender> tender)
            {
                shouldSerialize["tender"] = true;
                this.tender = tender;
                return this;
            }

             /// <summary>
             /// Refunds.
             /// </summary>
             /// <param name="refunds"> refunds. </param>
             /// <returns> Builder. </returns>
            public Builder Refunds(IList<Models.V1Refund> refunds)
            {
                shouldSerialize["refunds"] = true;
                this.refunds = refunds;
                return this;
            }

             /// <summary>
             /// Itemizations.
             /// </summary>
             /// <param name="itemizations"> itemizations. </param>
             /// <returns> Builder. </returns>
            public Builder Itemizations(IList<Models.V1PaymentItemization> itemizations)
            {
                shouldSerialize["itemizations"] = true;
                this.itemizations = itemizations;
                return this;
            }

             /// <summary>
             /// SurchargeMoney.
             /// </summary>
             /// <param name="surchargeMoney"> surchargeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SurchargeMoney(Models.V1Money surchargeMoney)
            {
                this.surchargeMoney = surchargeMoney;
                return this;
            }

             /// <summary>
             /// Surcharges.
             /// </summary>
             /// <param name="surcharges"> surcharges. </param>
             /// <returns> Builder. </returns>
            public Builder Surcharges(IList<Models.V1PaymentSurcharge> surcharges)
            {
                shouldSerialize["surcharges"] = true;
                this.surcharges = surcharges;
                return this;
            }

             /// <summary>
             /// IsPartial.
             /// </summary>
             /// <param name="isPartial"> isPartial. </param>
             /// <returns> Builder. </returns>
            public Builder IsPartial(bool? isPartial)
            {
                shouldSerialize["is_partial"] = true;
                this.isPartial = isPartial;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMerchantId()
            {
                this.shouldSerialize["merchant_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCreatorId()
            {
                this.shouldSerialize["creator_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentUrl()
            {
                this.shouldSerialize["payment_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReceiptUrl()
            {
                this.shouldSerialize["receipt_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetInclusiveTax()
            {
                this.shouldSerialize["inclusive_tax"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAdditiveTax()
            {
                this.shouldSerialize["additive_tax"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTender()
            {
                this.shouldSerialize["tender"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRefunds()
            {
                this.shouldSerialize["refunds"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemizations()
            {
                this.shouldSerialize["itemizations"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSurcharges()
            {
                this.shouldSerialize["surcharges"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsPartial()
            {
                this.shouldSerialize["is_partial"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Payment. </returns>
            public V1Payment Build()
            {
                return new V1Payment(shouldSerialize,
                    this.id,
                    this.merchantId,
                    this.createdAt,
                    this.creatorId,
                    this.device,
                    this.paymentUrl,
                    this.receiptUrl,
                    this.inclusiveTaxMoney,
                    this.additiveTaxMoney,
                    this.taxMoney,
                    this.tipMoney,
                    this.discountMoney,
                    this.totalCollectedMoney,
                    this.processingFeeMoney,
                    this.netTotalMoney,
                    this.refundedMoney,
                    this.swedishRoundingMoney,
                    this.grossSalesMoney,
                    this.netSalesMoney,
                    this.inclusiveTax,
                    this.additiveTax,
                    this.tender,
                    this.refunds,
                    this.itemizations,
                    this.surchargeMoney,
                    this.surcharges,
                    this.isPartial);
            }
        }
    }
}