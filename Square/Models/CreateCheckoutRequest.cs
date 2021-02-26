
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateCheckoutRequest 
    {
        public CreateCheckoutRequest(string idempotencyKey,
            Models.CreateOrderRequest order,
            bool? askForShippingAddress = null,
            string merchantSupportEmail = null,
            string prePopulateBuyerEmail = null,
            Models.Address prePopulateShippingAddress = null,
            string redirectUrl = null,
            IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients = null,
            string note = null)
        {
            IdempotencyKey = idempotencyKey;
            Order = order;
            AskForShippingAddress = askForShippingAddress;
            MerchantSupportEmail = merchantSupportEmail;
            PrePopulateBuyerEmail = prePopulateBuyerEmail;
            PrePopulateShippingAddress = prePopulateShippingAddress;
            RedirectUrl = redirectUrl;
            AdditionalRecipients = additionalRecipients;
            Note = note;
        }

        /// <summary>
        /// A unique string that identifies this checkout among others
        /// you've created. It can be any valid string but must be unique for every
        /// order sent to Square Checkout for a given location ID.
        /// The idempotency key is used to avoid processing the same order more than
        /// once. If you're unsure whether a particular checkout was created
        /// successfully, you can reattempt it with the same idempotency key and all the
        /// same other parameters without worrying about creating duplicates.
        /// We recommend using a random number/string generator native to the language
        /// you are working in to generate strings for your idempotency keys.
        /// See the [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency) guide for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Getter for order
        /// </summary>
        [JsonProperty("order")]
        public Models.CreateOrderRequest Order { get; }

        /// <summary>
        /// If `true`, Square Checkout will collect shipping information on your
        /// behalf and store that information with the transaction information in your
        /// Square Dashboard.
        /// Default: `false`.
        /// </summary>
        [JsonProperty("ask_for_shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AskForShippingAddress { get; }

        /// <summary>
        /// The email address to display on the Square Checkout confirmation page
        /// and confirmation email that the buyer can use to contact the merchant.
        /// If this value is not set, the confirmation page and email will display the
        /// primary email address associated with the merchant's Square account.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("merchant_support_email", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantSupportEmail { get; }

        /// <summary>
        /// If provided, the buyer's email is pre-populated on the checkout page
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
        /// The URL to redirect to after checkout is completed with `checkoutId`,
        /// Square's `orderId`, `transactionId`, and `referenceId` appended as URL
        /// parameters. For example, if the provided redirect_url is
        /// `http://www.example.com/order-complete`, a successful transaction redirects
        /// the customer to:
        /// <pre><code>http://www.example.com/order-complete?checkoutId=xxxxxx&amp;orderId=xxxxxx&amp;referenceId=xxxxxx&amp;transactionId=xxxxxx</code></pre>
        /// If you do not provide a redirect URL, Square Checkout will display an order
        /// confirmation page on your behalf; however Square strongly recommends that
        /// you provide a redirect URL so you can verify the transaction results and
        /// finalize the order through your existing/normal confirmation workflow.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUrl { get; }

        /// <summary>
        /// The basic primitive of multi-party transaction. The value is optional.
        /// The transaction facilitated by you can be split from here.
        /// If you provide this value, the `amount_money` value in your additional_recipients
        /// must not be more than 90% of the `total_money` calculated by Square for your order.
        /// The `location_id` must be the valid location of the app owner merchant.
        /// This field requires `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission.
        /// This field is currently not supported in sandbox.
        /// </summary>
        [JsonProperty("additional_recipients", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.ChargeRequestAdditionalRecipient> AdditionalRecipients { get; }

        /// <summary>
        /// An optional note to associate with the checkout object.
        /// This value cannot exceed 60 characters.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCheckoutRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"Order = {(Order == null ? "null" : Order.ToString())}");
            toStringOutput.Add($"AskForShippingAddress = {(AskForShippingAddress == null ? "null" : AskForShippingAddress.ToString())}");
            toStringOutput.Add($"MerchantSupportEmail = {(MerchantSupportEmail == null ? "null" : MerchantSupportEmail == string.Empty ? "" : MerchantSupportEmail)}");
            toStringOutput.Add($"PrePopulateBuyerEmail = {(PrePopulateBuyerEmail == null ? "null" : PrePopulateBuyerEmail == string.Empty ? "" : PrePopulateBuyerEmail)}");
            toStringOutput.Add($"PrePopulateShippingAddress = {(PrePopulateShippingAddress == null ? "null" : PrePopulateShippingAddress.ToString())}");
            toStringOutput.Add($"RedirectUrl = {(RedirectUrl == null ? "null" : RedirectUrl == string.Empty ? "" : RedirectUrl)}");
            toStringOutput.Add($"AdditionalRecipients = {(AdditionalRecipients == null ? "null" : $"[{ string.Join(", ", AdditionalRecipients)} ]")}");
            toStringOutput.Add($"Note = {(Note == null ? "null" : Note == string.Empty ? "" : Note)}");
        }

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
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((Order == null && other.Order == null) || (Order?.Equals(other.Order) == true)) &&
                ((AskForShippingAddress == null && other.AskForShippingAddress == null) || (AskForShippingAddress?.Equals(other.AskForShippingAddress) == true)) &&
                ((MerchantSupportEmail == null && other.MerchantSupportEmail == null) || (MerchantSupportEmail?.Equals(other.MerchantSupportEmail) == true)) &&
                ((PrePopulateBuyerEmail == null && other.PrePopulateBuyerEmail == null) || (PrePopulateBuyerEmail?.Equals(other.PrePopulateBuyerEmail) == true)) &&
                ((PrePopulateShippingAddress == null && other.PrePopulateShippingAddress == null) || (PrePopulateShippingAddress?.Equals(other.PrePopulateShippingAddress) == true)) &&
                ((RedirectUrl == null && other.RedirectUrl == null) || (RedirectUrl?.Equals(other.RedirectUrl) == true)) &&
                ((AdditionalRecipients == null && other.AdditionalRecipients == null) || (AdditionalRecipients?.Equals(other.AdditionalRecipients) == true)) &&
                ((Note == null && other.Note == null) || (Note?.Equals(other.Note) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1270416416;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (Order != null)
            {
               hashCode += Order.GetHashCode();
            }

            if (AskForShippingAddress != null)
            {
               hashCode += AskForShippingAddress.GetHashCode();
            }

            if (MerchantSupportEmail != null)
            {
               hashCode += MerchantSupportEmail.GetHashCode();
            }

            if (PrePopulateBuyerEmail != null)
            {
               hashCode += PrePopulateBuyerEmail.GetHashCode();
            }

            if (PrePopulateShippingAddress != null)
            {
               hashCode += PrePopulateShippingAddress.GetHashCode();
            }

            if (RedirectUrl != null)
            {
               hashCode += RedirectUrl.GetHashCode();
            }

            if (AdditionalRecipients != null)
            {
               hashCode += AdditionalRecipients.GetHashCode();
            }

            if (Note != null)
            {
               hashCode += Note.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                Order)
                .AskForShippingAddress(AskForShippingAddress)
                .MerchantSupportEmail(MerchantSupportEmail)
                .PrePopulateBuyerEmail(PrePopulateBuyerEmail)
                .PrePopulateShippingAddress(PrePopulateShippingAddress)
                .RedirectUrl(RedirectUrl)
                .AdditionalRecipients(AdditionalRecipients)
                .Note(Note);
            return builder;
        }

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

            public Builder(string idempotencyKey,
                Models.CreateOrderRequest order)
            {
                this.idempotencyKey = idempotencyKey;
                this.order = order;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder Order(Models.CreateOrderRequest order)
            {
                this.order = order;
                return this;
            }

            public Builder AskForShippingAddress(bool? askForShippingAddress)
            {
                this.askForShippingAddress = askForShippingAddress;
                return this;
            }

            public Builder MerchantSupportEmail(string merchantSupportEmail)
            {
                this.merchantSupportEmail = merchantSupportEmail;
                return this;
            }

            public Builder PrePopulateBuyerEmail(string prePopulateBuyerEmail)
            {
                this.prePopulateBuyerEmail = prePopulateBuyerEmail;
                return this;
            }

            public Builder PrePopulateShippingAddress(Models.Address prePopulateShippingAddress)
            {
                this.prePopulateShippingAddress = prePopulateShippingAddress;
                return this;
            }

            public Builder RedirectUrl(string redirectUrl)
            {
                this.redirectUrl = redirectUrl;
                return this;
            }

            public Builder AdditionalRecipients(IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients)
            {
                this.additionalRecipients = additionalRecipients;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public CreateCheckoutRequest Build()
            {
                return new CreateCheckoutRequest(idempotencyKey,
                    order,
                    askForShippingAddress,
                    merchantSupportEmail,
                    prePopulateBuyerEmail,
                    prePopulateShippingAddress,
                    redirectUrl,
                    additionalRecipients,
                    note);
            }
        }
    }
}