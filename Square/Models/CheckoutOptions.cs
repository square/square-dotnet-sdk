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
        private readonly Dictionary<string, bool> shouldSerialize;
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
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="shippingFee">shipping_fee.</param>
        /// <param name="enableCoupon">enable_coupon.</param>
        /// <param name="enableLoyalty">enable_loyalty.</param>
        public CheckoutOptions(
            bool? allowTipping = null,
            IList<Models.CustomField> customFields = null,
            string subscriptionPlanId = null,
            string redirectUrl = null,
            string merchantSupportEmail = null,
            bool? askForShippingAddress = null,
            Models.AcceptedPaymentMethods acceptedPaymentMethods = null,
            Models.Money appFeeMoney = null,
            Models.ShippingFee shippingFee = null,
            bool? enableCoupon = null,
            bool? enableLoyalty = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "allow_tipping", false },
                { "custom_fields", false },
                { "subscription_plan_id", false },
                { "redirect_url", false },
                { "merchant_support_email", false },
                { "ask_for_shipping_address", false },
                { "enable_coupon", false },
                { "enable_loyalty", false }
            };

            if (allowTipping != null)
            {
                shouldSerialize["allow_tipping"] = true;
                this.AllowTipping = allowTipping;
            }

            if (customFields != null)
            {
                shouldSerialize["custom_fields"] = true;
                this.CustomFields = customFields;
            }

            if (subscriptionPlanId != null)
            {
                shouldSerialize["subscription_plan_id"] = true;
                this.SubscriptionPlanId = subscriptionPlanId;
            }

            if (redirectUrl != null)
            {
                shouldSerialize["redirect_url"] = true;
                this.RedirectUrl = redirectUrl;
            }

            if (merchantSupportEmail != null)
            {
                shouldSerialize["merchant_support_email"] = true;
                this.MerchantSupportEmail = merchantSupportEmail;
            }

            if (askForShippingAddress != null)
            {
                shouldSerialize["ask_for_shipping_address"] = true;
                this.AskForShippingAddress = askForShippingAddress;
            }

            this.AcceptedPaymentMethods = acceptedPaymentMethods;
            this.AppFeeMoney = appFeeMoney;
            this.ShippingFee = shippingFee;
            if (enableCoupon != null)
            {
                shouldSerialize["enable_coupon"] = true;
                this.EnableCoupon = enableCoupon;
            }

            if (enableLoyalty != null)
            {
                shouldSerialize["enable_loyalty"] = true;
                this.EnableLoyalty = enableLoyalty;
            }

        }
        internal CheckoutOptions(Dictionary<string, bool> shouldSerialize,
            bool? allowTipping = null,
            IList<Models.CustomField> customFields = null,
            string subscriptionPlanId = null,
            string redirectUrl = null,
            string merchantSupportEmail = null,
            bool? askForShippingAddress = null,
            Models.AcceptedPaymentMethods acceptedPaymentMethods = null,
            Models.Money appFeeMoney = null,
            Models.ShippingFee shippingFee = null,
            bool? enableCoupon = null,
            bool? enableLoyalty = null)
        {
            this.shouldSerialize = shouldSerialize;
            AllowTipping = allowTipping;
            CustomFields = customFields;
            SubscriptionPlanId = subscriptionPlanId;
            RedirectUrl = redirectUrl;
            MerchantSupportEmail = merchantSupportEmail;
            AskForShippingAddress = askForShippingAddress;
            AcceptedPaymentMethods = acceptedPaymentMethods;
            AppFeeMoney = appFeeMoney;
            ShippingFee = shippingFee;
            EnableCoupon = enableCoupon;
            EnableLoyalty = enableLoyalty;
        }

        /// <summary>
        /// Indicates whether the payment allows tipping.
        /// </summary>
        [JsonProperty("allow_tipping")]
        public bool? AllowTipping { get; }

        /// <summary>
        /// The custom fields requesting information from the buyer.
        /// </summary>
        [JsonProperty("custom_fields")]
        public IList<Models.CustomField> CustomFields { get; }

        /// <summary>
        /// The ID of the subscription plan for the buyer to pay and subscribe.
        /// For more information, see [Subscription Plan Checkout](https://developer.squareup.com/docs/checkout-api/subscription-plan-checkout).
        /// </summary>
        [JsonProperty("subscription_plan_id")]
        public string SubscriptionPlanId { get; }

        /// <summary>
        /// The confirmation page URL to redirect the buyer to after Square processes the payment.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; }

        /// <summary>
        /// The email address that buyers can use to contact the seller.
        /// </summary>
        [JsonProperty("merchant_support_email")]
        public string MerchantSupportEmail { get; }

        /// <summary>
        /// Indicates whether to include the address fields in the payment form.
        /// </summary>
        [JsonProperty("ask_for_shipping_address")]
        public bool? AskForShippingAddress { get; }

        /// <summary>
        /// Gets or sets AcceptedPaymentMethods.
        /// </summary>
        [JsonProperty("accepted_payment_methods", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AcceptedPaymentMethods AcceptedPaymentMethods { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// Gets or sets ShippingFee.
        /// </summary>
        [JsonProperty("shipping_fee", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShippingFee ShippingFee { get; }

        /// <summary>
        /// Indicates whether to include the `Add coupon` section for the buyer to provide a Square marketing coupon in the payment form.
        /// </summary>
        [JsonProperty("enable_coupon")]
        public bool? EnableCoupon { get; }

        /// <summary>
        /// Indicates whether to include the `REWARDS` section for the buyer to opt in to loyalty, redeem rewards in the payment form, or both.
        /// </summary>
        [JsonProperty("enable_loyalty")]
        public bool? EnableLoyalty { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckoutOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAllowTipping()
        {
            return this.shouldSerialize["allow_tipping"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomFields()
        {
            return this.shouldSerialize["custom_fields"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubscriptionPlanId()
        {
            return this.shouldSerialize["subscription_plan_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRedirectUrl()
        {
            return this.shouldSerialize["redirect_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantSupportEmail()
        {
            return this.shouldSerialize["merchant_support_email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAskForShippingAddress()
        {
            return this.shouldSerialize["ask_for_shipping_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnableCoupon()
        {
            return this.shouldSerialize["enable_coupon"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnableLoyalty()
        {
            return this.shouldSerialize["enable_loyalty"];
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
            return obj is CheckoutOptions other &&                ((this.AllowTipping == null && other.AllowTipping == null) || (this.AllowTipping?.Equals(other.AllowTipping) == true)) &&
                ((this.CustomFields == null && other.CustomFields == null) || (this.CustomFields?.Equals(other.CustomFields) == true)) &&
                ((this.SubscriptionPlanId == null && other.SubscriptionPlanId == null) || (this.SubscriptionPlanId?.Equals(other.SubscriptionPlanId) == true)) &&
                ((this.RedirectUrl == null && other.RedirectUrl == null) || (this.RedirectUrl?.Equals(other.RedirectUrl) == true)) &&
                ((this.MerchantSupportEmail == null && other.MerchantSupportEmail == null) || (this.MerchantSupportEmail?.Equals(other.MerchantSupportEmail) == true)) &&
                ((this.AskForShippingAddress == null && other.AskForShippingAddress == null) || (this.AskForShippingAddress?.Equals(other.AskForShippingAddress) == true)) &&
                ((this.AcceptedPaymentMethods == null && other.AcceptedPaymentMethods == null) || (this.AcceptedPaymentMethods?.Equals(other.AcceptedPaymentMethods) == true)) &&
                ((this.AppFeeMoney == null && other.AppFeeMoney == null) || (this.AppFeeMoney?.Equals(other.AppFeeMoney) == true)) &&
                ((this.ShippingFee == null && other.ShippingFee == null) || (this.ShippingFee?.Equals(other.ShippingFee) == true)) &&
                ((this.EnableCoupon == null && other.EnableCoupon == null) || (this.EnableCoupon?.Equals(other.EnableCoupon) == true)) &&
                ((this.EnableLoyalty == null && other.EnableLoyalty == null) || (this.EnableLoyalty?.Equals(other.EnableLoyalty) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 570031906;
            hashCode = HashCode.Combine(this.AllowTipping, this.CustomFields, this.SubscriptionPlanId, this.RedirectUrl, this.MerchantSupportEmail, this.AskForShippingAddress, this.AcceptedPaymentMethods);

            hashCode = HashCode.Combine(hashCode, this.AppFeeMoney, this.ShippingFee, this.EnableCoupon, this.EnableLoyalty);

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
            toStringOutput.Add($"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}");
            toStringOutput.Add($"this.ShippingFee = {(this.ShippingFee == null ? "null" : this.ShippingFee.ToString())}");
            toStringOutput.Add($"this.EnableCoupon = {(this.EnableCoupon == null ? "null" : this.EnableCoupon.ToString())}");
            toStringOutput.Add($"this.EnableLoyalty = {(this.EnableLoyalty == null ? "null" : this.EnableLoyalty.ToString())}");
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
                .AcceptedPaymentMethods(this.AcceptedPaymentMethods)
                .AppFeeMoney(this.AppFeeMoney)
                .ShippingFee(this.ShippingFee)
                .EnableCoupon(this.EnableCoupon)
                .EnableLoyalty(this.EnableLoyalty);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "allow_tipping", false },
                { "custom_fields", false },
                { "subscription_plan_id", false },
                { "redirect_url", false },
                { "merchant_support_email", false },
                { "ask_for_shipping_address", false },
                { "enable_coupon", false },
                { "enable_loyalty", false },
            };

            private bool? allowTipping;
            private IList<Models.CustomField> customFields;
            private string subscriptionPlanId;
            private string redirectUrl;
            private string merchantSupportEmail;
            private bool? askForShippingAddress;
            private Models.AcceptedPaymentMethods acceptedPaymentMethods;
            private Models.Money appFeeMoney;
            private Models.ShippingFee shippingFee;
            private bool? enableCoupon;
            private bool? enableLoyalty;

             /// <summary>
             /// AllowTipping.
             /// </summary>
             /// <param name="allowTipping"> allowTipping. </param>
             /// <returns> Builder. </returns>
            public Builder AllowTipping(bool? allowTipping)
            {
                shouldSerialize["allow_tipping"] = true;
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
                shouldSerialize["custom_fields"] = true;
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
                shouldSerialize["subscription_plan_id"] = true;
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
                shouldSerialize["redirect_url"] = true;
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
                shouldSerialize["merchant_support_email"] = true;
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
                shouldSerialize["ask_for_shipping_address"] = true;
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
             /// AppFeeMoney.
             /// </summary>
             /// <param name="appFeeMoney"> appFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppFeeMoney(Models.Money appFeeMoney)
            {
                this.appFeeMoney = appFeeMoney;
                return this;
            }

             /// <summary>
             /// ShippingFee.
             /// </summary>
             /// <param name="shippingFee"> shippingFee. </param>
             /// <returns> Builder. </returns>
            public Builder ShippingFee(Models.ShippingFee shippingFee)
            {
                this.shippingFee = shippingFee;
                return this;
            }

             /// <summary>
             /// EnableCoupon.
             /// </summary>
             /// <param name="enableCoupon"> enableCoupon. </param>
             /// <returns> Builder. </returns>
            public Builder EnableCoupon(bool? enableCoupon)
            {
                shouldSerialize["enable_coupon"] = true;
                this.enableCoupon = enableCoupon;
                return this;
            }

             /// <summary>
             /// EnableLoyalty.
             /// </summary>
             /// <param name="enableLoyalty"> enableLoyalty. </param>
             /// <returns> Builder. </returns>
            public Builder EnableLoyalty(bool? enableLoyalty)
            {
                shouldSerialize["enable_loyalty"] = true;
                this.enableLoyalty = enableLoyalty;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAllowTipping()
            {
                this.shouldSerialize["allow_tipping"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomFields()
            {
                this.shouldSerialize["custom_fields"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSubscriptionPlanId()
            {
                this.shouldSerialize["subscription_plan_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRedirectUrl()
            {
                this.shouldSerialize["redirect_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMerchantSupportEmail()
            {
                this.shouldSerialize["merchant_support_email"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAskForShippingAddress()
            {
                this.shouldSerialize["ask_for_shipping_address"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEnableCoupon()
            {
                this.shouldSerialize["enable_coupon"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEnableLoyalty()
            {
                this.shouldSerialize["enable_loyalty"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutOptions. </returns>
            public CheckoutOptions Build()
            {
                return new CheckoutOptions(shouldSerialize,
                    this.allowTipping,
                    this.customFields,
                    this.subscriptionPlanId,
                    this.redirectUrl,
                    this.merchantSupportEmail,
                    this.askForShippingAddress,
                    this.acceptedPaymentMethods,
                    this.appFeeMoney,
                    this.shippingFee,
                    this.enableCoupon,
                    this.enableLoyalty);
            }
        }
    }
}