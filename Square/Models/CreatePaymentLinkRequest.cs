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
    /// CreatePaymentLinkRequest.
    /// </summary>
    public class CreatePaymentLinkRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePaymentLinkRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="description">description.</param>
        /// <param name="quickPay">quick_pay.</param>
        /// <param name="order">order.</param>
        /// <param name="checkoutOptions">checkout_options.</param>
        /// <param name="prePopulatedData">pre_populated_data.</param>
        /// <param name="paymentNote">payment_note.</param>
        public CreatePaymentLinkRequest(
            string idempotencyKey = null,
            string description = null,
            Models.QuickPay quickPay = null,
            Models.Order order = null,
            Models.CheckoutOptions checkoutOptions = null,
            Models.PrePopulatedData prePopulatedData = null,
            string paymentNote = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Description = description;
            this.QuickPay = quickPay;
            this.Order = order;
            this.CheckoutOptions = checkoutOptions;
            this.PrePopulatedData = prePopulatedData;
            this.PaymentNote = paymentNote;
        }

        /// <summary>
        /// A unique string that identifies this `CreatePaymentLinkRequest` request.
        /// If you do not provide a unique string (or provide an empty string as the value),
        /// the endpoint treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A description of the payment link. You provide this optional description that is useful in your
        /// application context. It is not used anywhere.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// Describes an ad hoc item and price to generate a quick pay checkout link.
        /// For more information,
        /// see [Quick Pay Checkout](https://developer.squareup.com/docs/checkout-api/quick-pay-checkout).
        /// </summary>
        [JsonProperty("quick_pay", NullValueHandling = NullValueHandling.Ignore)]
        public Models.QuickPay QuickPay { get; }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. `Order` objects also
        /// include information about any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Order Order { get; }

        /// <summary>
        /// Gets or sets CheckoutOptions.
        /// </summary>
        [JsonProperty("checkout_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutOptions CheckoutOptions { get; }

        /// <summary>
        /// Describes buyer data to prepopulate in the payment form.
        /// For more information,
        /// see [Optional Checkout Configurations](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations).
        /// </summary>
        [JsonProperty("pre_populated_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PrePopulatedData PrePopulatedData { get; }

        /// <summary>
        /// A note for the payment. After processing the payment, Square adds this note to the resulting `Payment`.
        /// </summary>
        [JsonProperty("payment_note", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentNote { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreatePaymentLinkRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreatePaymentLinkRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.QuickPay == null && other.QuickPay == null) || (this.QuickPay?.Equals(other.QuickPay) == true)) &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.CheckoutOptions == null && other.CheckoutOptions == null) || (this.CheckoutOptions?.Equals(other.CheckoutOptions) == true)) &&
                ((this.PrePopulatedData == null && other.PrePopulatedData == null) || (this.PrePopulatedData?.Equals(other.PrePopulatedData) == true)) &&
                ((this.PaymentNote == null && other.PaymentNote == null) || (this.PaymentNote?.Equals(other.PaymentNote) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1695889538;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Description, this.QuickPay, this.Order, this.CheckoutOptions, this.PrePopulatedData, this.PaymentNote);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.QuickPay = {(this.QuickPay == null ? "null" : this.QuickPay.ToString())}");
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.CheckoutOptions = {(this.CheckoutOptions == null ? "null" : this.CheckoutOptions.ToString())}");
            toStringOutput.Add($"this.PrePopulatedData = {(this.PrePopulatedData == null ? "null" : this.PrePopulatedData.ToString())}");
            toStringOutput.Add($"this.PaymentNote = {(this.PaymentNote == null ? "null" : this.PaymentNote == string.Empty ? "" : this.PaymentNote)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(this.IdempotencyKey)
                .Description(this.Description)
                .QuickPay(this.QuickPay)
                .Order(this.Order)
                .CheckoutOptions(this.CheckoutOptions)
                .PrePopulatedData(this.PrePopulatedData)
                .PaymentNote(this.PaymentNote);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string description;
            private Models.QuickPay quickPay;
            private Models.Order order;
            private Models.CheckoutOptions checkoutOptions;
            private Models.PrePopulatedData prePopulatedData;
            private string paymentNote;

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

             /// <summary>
             /// QuickPay.
             /// </summary>
             /// <param name="quickPay"> quickPay. </param>
             /// <returns> Builder. </returns>
            public Builder QuickPay(Models.QuickPay quickPay)
            {
                this.quickPay = quickPay;
                return this;
            }

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(Models.Order order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// CheckoutOptions.
             /// </summary>
             /// <param name="checkoutOptions"> checkoutOptions. </param>
             /// <returns> Builder. </returns>
            public Builder CheckoutOptions(Models.CheckoutOptions checkoutOptions)
            {
                this.checkoutOptions = checkoutOptions;
                return this;
            }

             /// <summary>
             /// PrePopulatedData.
             /// </summary>
             /// <param name="prePopulatedData"> prePopulatedData. </param>
             /// <returns> Builder. </returns>
            public Builder PrePopulatedData(Models.PrePopulatedData prePopulatedData)
            {
                this.prePopulatedData = prePopulatedData;
                return this;
            }

             /// <summary>
             /// PaymentNote.
             /// </summary>
             /// <param name="paymentNote"> paymentNote. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentNote(string paymentNote)
            {
                this.paymentNote = paymentNote;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreatePaymentLinkRequest. </returns>
            public CreatePaymentLinkRequest Build()
            {
                return new CreatePaymentLinkRequest(
                    this.idempotencyKey,
                    this.description,
                    this.quickPay,
                    this.order,
                    this.checkoutOptions,
                    this.prePopulatedData,
                    this.paymentNote);
            }
        }
    }
}