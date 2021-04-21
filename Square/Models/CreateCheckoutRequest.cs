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
    /// CreateCheckoutRequest.
    /// </summary>
    public class CreateCheckoutRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCheckoutRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="order">order.</param>
        /// <param name="askForShippingAddress">ask_for_shipping_address.</param>
        /// <param name="merchantSupportEmail">merchant_support_email.</param>
        /// <param name="prePopulateBuyerEmail">pre_populate_buyer_email.</param>
        /// <param name="prePopulateShippingAddress">pre_populate_shipping_address.</param>
        /// <param name="redirectUrl">redirect_url.</param>
        /// <param name="additionalRecipients">additional_recipients.</param>
        /// <param name="note">note.</param>
        public CreateCheckoutRequest(
            string idempotencyKey,
            Models.CreateOrderRequest order,
            bool? askForShippingAddress = null,
            string merchantSupportEmail = null,
            string prePopulateBuyerEmail = null,
            Models.Address prePopulateShippingAddress = null,
            string redirectUrl = null,
            IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients = null,
            string note = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Order = order;
            this.AskForShippingAddress = askForShippingAddress;
            this.MerchantSupportEmail = merchantSupportEmail;
            this.PrePopulateBuyerEmail = prePopulateBuyerEmail;
            this.PrePopulateShippingAddress = prePopulateShippingAddress;
            this.RedirectUrl = redirectUrl;
            this.AdditionalRecipients = additionalRecipients;
            this.Note = note;
        }

        /// <summary>
        /// A unique string that identifies this checkout among others you have created. It can be
        /// any valid string but must be unique for every order sent to Square Checkout for a given location ID.
        /// The idempotency key is used to avoid processing the same order more than once. If you are
        /// unsure whether a particular checkout was created successfully, you can attempt it again with
        /// the same idempotency key and all the same other parameters without worrying about creating duplicates.
        /// You should use a random number/string generator native to the language
        /// you are working in to generate strings for your idempotency keys.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Gets or sets Order.
        /// </summary>
        [JsonProperty("order")]
        public Models.CreateOrderRequest Order { get; }

        /// <summary>
        /// If `true`, Square Checkout collects shipping information on your behalf and stores
        /// that information with the transaction information in the Square Seller Dashboard.
        /// Default: `false`.
        /// </summary>
        [JsonProperty("ask_for_shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AskForShippingAddress { get; }

        /// <summary>
        /// The email address to display on the Square Checkout confirmation page
        /// and confirmation email that the buyer can use to contact the seller.
        /// If this value is not set, the confirmation page and email display the
        /// primary email address associated with the seller's Square account.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("merchant_support_email", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantSupportEmail { get; }

        /// <summary>
        /// If provided, the buyer's email is prepopulated on the checkout page
        /// as an editable text field.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("pre_populate_buyer_email", NullValueHandling = NullValueHandling.Ignore)]
        public string PrePopulateBuyerEmail { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("pre_populate_shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address PrePopulateShippingAddress { get; }

        /// <summary>
        /// The URL to redirect to after the checkout is completed with `checkoutId`,
        /// Square's `orderId`, `transactionId`, and `referenceId` appended as URL
        /// parameters. For example, if the provided redirect URL is
        /// `http://www.example.com/order-complete`, a successful transaction redirects
        /// the customer to:
        /// <pre><code>http://www.example.com/order-complete?checkoutId=xxxxxx&amp;orderId=xxxxxx&amp;referenceId=xxxxxx&amp;transactionId=xxxxxx</code></pre>
        /// If you do not provide a redirect URL, Square Checkout displays an order
        /// confirmation page on your behalf; however, it is strongly recommended that
        /// you provide a redirect URL so you can verify the transaction results and
        /// finalize the order through your existing/normal confirmation workflow.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUrl { get; }

        /// <summary>
        /// The basic primitive of a multi-party transaction. The value is optional.
        /// The transaction facilitated by you can be split from here.
        /// If you provide this value, the `amount_money` value in your `additional_recipients` field
        /// cannot be more than 90% of the `total_money` calculated by Square for your order.
        /// The `location_id` must be a valid seller location where the checkout is occurring.
        /// This field requires `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission.
        /// This field is currently not supported in the Square Sandbox.
        /// </summary>
        [JsonProperty("additional_recipients", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.ChargeRequestAdditionalRecipient> AdditionalRecipients { get; }

        /// <summary>
        /// An optional note to associate with the `checkout` object.
        /// This value cannot exceed 60 characters.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCheckoutRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCheckoutRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.AskForShippingAddress == null && other.AskForShippingAddress == null) || (this.AskForShippingAddress?.Equals(other.AskForShippingAddress) == true)) &&
                ((this.MerchantSupportEmail == null && other.MerchantSupportEmail == null) || (this.MerchantSupportEmail?.Equals(other.MerchantSupportEmail) == true)) &&
                ((this.PrePopulateBuyerEmail == null && other.PrePopulateBuyerEmail == null) || (this.PrePopulateBuyerEmail?.Equals(other.PrePopulateBuyerEmail) == true)) &&
                ((this.PrePopulateShippingAddress == null && other.PrePopulateShippingAddress == null) || (this.PrePopulateShippingAddress?.Equals(other.PrePopulateShippingAddress) == true)) &&
                ((this.RedirectUrl == null && other.RedirectUrl == null) || (this.RedirectUrl?.Equals(other.RedirectUrl) == true)) &&
                ((this.AdditionalRecipients == null && other.AdditionalRecipients == null) || (this.AdditionalRecipients?.Equals(other.AdditionalRecipients) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1270416416;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.Order != null)
            {
               hashCode += this.Order.GetHashCode();
            }

            if (this.AskForShippingAddress != null)
            {
               hashCode += this.AskForShippingAddress.GetHashCode();
            }

            if (this.MerchantSupportEmail != null)
            {
               hashCode += this.MerchantSupportEmail.GetHashCode();
            }

            if (this.PrePopulateBuyerEmail != null)
            {
               hashCode += this.PrePopulateBuyerEmail.GetHashCode();
            }

            if (this.PrePopulateShippingAddress != null)
            {
               hashCode += this.PrePopulateShippingAddress.GetHashCode();
            }

            if (this.RedirectUrl != null)
            {
               hashCode += this.RedirectUrl.GetHashCode();
            }

            if (this.AdditionalRecipients != null)
            {
               hashCode += this.AdditionalRecipients.GetHashCode();
            }

            if (this.Note != null)
            {
               hashCode += this.Note.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.AskForShippingAddress = {(this.AskForShippingAddress == null ? "null" : this.AskForShippingAddress.ToString())}");
            toStringOutput.Add($"this.MerchantSupportEmail = {(this.MerchantSupportEmail == null ? "null" : this.MerchantSupportEmail == string.Empty ? "" : this.MerchantSupportEmail)}");
            toStringOutput.Add($"this.PrePopulateBuyerEmail = {(this.PrePopulateBuyerEmail == null ? "null" : this.PrePopulateBuyerEmail == string.Empty ? "" : this.PrePopulateBuyerEmail)}");
            toStringOutput.Add($"this.PrePopulateShippingAddress = {(this.PrePopulateShippingAddress == null ? "null" : this.PrePopulateShippingAddress.ToString())}");
            toStringOutput.Add($"this.RedirectUrl = {(this.RedirectUrl == null ? "null" : this.RedirectUrl == string.Empty ? "" : this.RedirectUrl)}");
            toStringOutput.Add($"this.AdditionalRecipients = {(this.AdditionalRecipients == null ? "null" : $"[{string.Join(", ", this.AdditionalRecipients)} ]")}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.Order)
                .AskForShippingAddress(this.AskForShippingAddress)
                .MerchantSupportEmail(this.MerchantSupportEmail)
                .PrePopulateBuyerEmail(this.PrePopulateBuyerEmail)
                .PrePopulateShippingAddress(this.PrePopulateShippingAddress)
                .RedirectUrl(this.RedirectUrl)
                .AdditionalRecipients(this.AdditionalRecipients)
                .Note(this.Note);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.CreateOrderRequest order;
            private bool? askForShippingAddress;
            private string merchantSupportEmail;
            private string prePopulateBuyerEmail;
            private Models.Address prePopulateShippingAddress;
            private string redirectUrl;
            private IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients;
            private string note;

            public Builder(
                string idempotencyKey,
                Models.CreateOrderRequest order)
            {
                this.idempotencyKey = idempotencyKey;
                this.order = order;
            }

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
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(Models.CreateOrderRequest order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// AskForShippingAddress.
             /// </summary>
             /// <param name="askForShippingAddress"> askForShippingAddress. </param>
             /// <returns> Builder. </returns>
            public Builder AskForShippingAddress(bool? askForShippingAddress)
            {
                this.askForShippingAddress = askForShippingAddress;
                return this;
            }

             /// <summary>
             /// MerchantSupportEmail.
             /// </summary>
             /// <param name="merchantSupportEmail"> merchantSupportEmail. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantSupportEmail(string merchantSupportEmail)
            {
                this.merchantSupportEmail = merchantSupportEmail;
                return this;
            }

             /// <summary>
             /// PrePopulateBuyerEmail.
             /// </summary>
             /// <param name="prePopulateBuyerEmail"> prePopulateBuyerEmail. </param>
             /// <returns> Builder. </returns>
            public Builder PrePopulateBuyerEmail(string prePopulateBuyerEmail)
            {
                this.prePopulateBuyerEmail = prePopulateBuyerEmail;
                return this;
            }

             /// <summary>
             /// PrePopulateShippingAddress.
             /// </summary>
             /// <param name="prePopulateShippingAddress"> prePopulateShippingAddress. </param>
             /// <returns> Builder. </returns>
            public Builder PrePopulateShippingAddress(Models.Address prePopulateShippingAddress)
            {
                this.prePopulateShippingAddress = prePopulateShippingAddress;
                return this;
            }

             /// <summary>
             /// RedirectUrl.
             /// </summary>
             /// <param name="redirectUrl"> redirectUrl. </param>
             /// <returns> Builder. </returns>
            public Builder RedirectUrl(string redirectUrl)
            {
                this.redirectUrl = redirectUrl;
                return this;
            }

             /// <summary>
             /// AdditionalRecipients.
             /// </summary>
             /// <param name="additionalRecipients"> additionalRecipients. </param>
             /// <returns> Builder. </returns>
            public Builder AdditionalRecipients(IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients)
            {
                this.additionalRecipients = additionalRecipients;
                return this;
            }

             /// <summary>
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateCheckoutRequest. </returns>
            public CreateCheckoutRequest Build()
            {
                return new CreateCheckoutRequest(
                    this.idempotencyKey,
                    this.order,
                    this.askForShippingAddress,
                    this.merchantSupportEmail,
                    this.prePopulateBuyerEmail,
                    this.prePopulateShippingAddress,
                    this.redirectUrl,
                    this.additionalRecipients,
                    this.note);
            }
        }
    }
}