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
    /// CheckoutOptions.
    /// </summary>
    public class CheckoutOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutOptions"/> class.
        /// </summary>
        /// <param name="allowTipping">allow_tipping.</param>
        /// <param name="customFields">custom_fields.</param>
        /// <param name="subscriptionPlanId">subscription_plan_id.</param>
        /// <param name="redirectUrl">redirect_url.</param>
        /// <param name="merchantSupportEmail">merchant_support_email.</param>
        /// <param name="askForShippingAddress">ask_for_shipping_address.</param>
        /// <param name="acceptedPaymentMethods">accepted_payment_methods.</param>
        public CheckoutOptions(
            bool? allowTipping = null,
            IList<Models.CustomField> customFields = null,
            string subscriptionPlanId = null,
            string redirectUrl = null,
            string merchantSupportEmail = null,
            bool? askForShippingAddress = null,
            Models.AcceptedPaymentMethods acceptedPaymentMethods = null)
        {
            this.AllowTipping = allowTipping;
            this.CustomFields = customFields;
            this.SubscriptionPlanId = subscriptionPlanId;
            this.RedirectUrl = redirectUrl;
            this.MerchantSupportEmail = merchantSupportEmail;
            this.AskForShippingAddress = askForShippingAddress;
            this.AcceptedPaymentMethods = acceptedPaymentMethods;
        }

        /// <summary>
        /// Indicates whether the payment allows tipping.
        /// </summary>
        [JsonProperty("allow_tipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowTipping { get; }

        /// <summary>
        /// The custom fields requesting information from the buyer.
        /// </summary>
        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomField> CustomFields { get; }

        /// <summary>
        /// The ID of the subscription plan for the buyer to pay and subscribe.
        /// For more information, see [Subscription Plan Checkout](https://developer.squareup.com/docs/checkout-api/subscription-plan-checkout).
        /// </summary>
        [JsonProperty("subscription_plan_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionPlanId { get; }

        /// <summary>
        /// The confirmation page URL to redirect the buyer to after Square processes the payment.
        /// </summary>
        [JsonProperty("redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUrl { get; }

        /// <summary>
        /// The email address that buyers can use to contact the seller.
        /// </summary>
        [JsonProperty("merchant_support_email", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantSupportEmail { get; }

        /// <summary>
        /// Indicates whether to include the address fields in the payment form.
        /// </summary>
        [JsonProperty("ask_for_shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AskForShippingAddress { get; }

        /// <summary>
        /// Gets or sets AcceptedPaymentMethods.
        /// </summary>
        [JsonProperty("accepted_payment_methods", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AcceptedPaymentMethods AcceptedPaymentMethods { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckoutOptions : ({string.Join(", ", toStringOutput)})";
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

            return obj is CheckoutOptions other &&
                ((this.AllowTipping == null && other.AllowTipping == null) || (this.AllowTipping?.Equals(other.AllowTipping) == true)) &&
                ((this.CustomFields == null && other.CustomFields == null) || (this.CustomFields?.Equals(other.CustomFields) == true)) &&
                ((this.SubscriptionPlanId == null && other.SubscriptionPlanId == null) || (this.SubscriptionPlanId?.Equals(other.SubscriptionPlanId) == true)) &&
                ((this.RedirectUrl == null && other.RedirectUrl == null) || (this.RedirectUrl?.Equals(other.RedirectUrl) == true)) &&
                ((this.MerchantSupportEmail == null && other.MerchantSupportEmail == null) || (this.MerchantSupportEmail?.Equals(other.MerchantSupportEmail) == true)) &&
                ((this.AskForShippingAddress == null && other.AskForShippingAddress == null) || (this.AskForShippingAddress?.Equals(other.AskForShippingAddress) == true)) &&
                ((this.AcceptedPaymentMethods == null && other.AcceptedPaymentMethods == null) || (this.AcceptedPaymentMethods?.Equals(other.AcceptedPaymentMethods) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -962206928;
            hashCode = HashCode.Combine(this.AllowTipping, this.CustomFields, this.SubscriptionPlanId, this.RedirectUrl, this.MerchantSupportEmail, this.AskForShippingAddress, this.AcceptedPaymentMethods);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AllowTipping = {(this.AllowTipping == null ? "null" : this.AllowTipping.ToString())}");
            toStringOutput.Add($"this.CustomFields = {(this.CustomFields == null ? "null" : $"[{string.Join(", ", this.CustomFields)} ]")}");
            toStringOutput.Add($"this.SubscriptionPlanId = {(this.SubscriptionPlanId == null ? "null" : this.SubscriptionPlanId == string.Empty ? "" : this.SubscriptionPlanId)}");
            toStringOutput.Add($"this.RedirectUrl = {(this.RedirectUrl == null ? "null" : this.RedirectUrl == string.Empty ? "" : this.RedirectUrl)}");
            toStringOutput.Add($"this.MerchantSupportEmail = {(this.MerchantSupportEmail == null ? "null" : this.MerchantSupportEmail == string.Empty ? "" : this.MerchantSupportEmail)}");
            toStringOutput.Add($"this.AskForShippingAddress = {(this.AskForShippingAddress == null ? "null" : this.AskForShippingAddress.ToString())}");
            toStringOutput.Add($"this.AcceptedPaymentMethods = {(this.AcceptedPaymentMethods == null ? "null" : this.AcceptedPaymentMethods.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AllowTipping(this.AllowTipping)
                .CustomFields(this.CustomFields)
                .SubscriptionPlanId(this.SubscriptionPlanId)
                .RedirectUrl(this.RedirectUrl)
                .MerchantSupportEmail(this.MerchantSupportEmail)
                .AskForShippingAddress(this.AskForShippingAddress)
                .AcceptedPaymentMethods(this.AcceptedPaymentMethods);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? allowTipping;
            private IList<Models.CustomField> customFields;
            private string subscriptionPlanId;
            private string redirectUrl;
            private string merchantSupportEmail;
            private bool? askForShippingAddress;
            private Models.AcceptedPaymentMethods acceptedPaymentMethods;

             /// <summary>
             /// AllowTipping.
             /// </summary>
             /// <param name="allowTipping"> allowTipping. </param>
             /// <returns> Builder. </returns>
            public Builder AllowTipping(bool? allowTipping)
            {
                this.allowTipping = allowTipping;
                return this;
            }

             /// <summary>
             /// CustomFields.
             /// </summary>
             /// <param name="customFields"> customFields. </param>
             /// <returns> Builder. </returns>
            public Builder CustomFields(IList<Models.CustomField> customFields)
            {
                this.customFields = customFields;
                return this;
            }

             /// <summary>
             /// SubscriptionPlanId.
             /// </summary>
             /// <param name="subscriptionPlanId"> subscriptionPlanId. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionPlanId(string subscriptionPlanId)
            {
                this.subscriptionPlanId = subscriptionPlanId;
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
             /// AcceptedPaymentMethods.
             /// </summary>
             /// <param name="acceptedPaymentMethods"> acceptedPaymentMethods. </param>
             /// <returns> Builder. </returns>
            public Builder AcceptedPaymentMethods(Models.AcceptedPaymentMethods acceptedPaymentMethods)
            {
                this.acceptedPaymentMethods = acceptedPaymentMethods;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutOptions. </returns>
            public CheckoutOptions Build()
            {
                return new CheckoutOptions(
                    this.allowTipping,
                    this.customFields,
                    this.subscriptionPlanId,
                    this.redirectUrl,
                    this.merchantSupportEmail,
                    this.askForShippingAddress,
                    this.acceptedPaymentMethods);
            }
        }
    }
}