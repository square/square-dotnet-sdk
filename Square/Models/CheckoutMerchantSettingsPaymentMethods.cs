using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CheckoutMerchantSettingsPaymentMethods.
    /// </summary>
    public class CheckoutMerchantSettingsPaymentMethods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutMerchantSettingsPaymentMethods"/> class.
        /// </summary>
        /// <param name="applePay">apple_pay.</param>
        /// <param name="googlePay">google_pay.</param>
        /// <param name="cashApp">cash_app.</param>
        /// <param name="afterpayClearpay">afterpay_clearpay.</param>
        public CheckoutMerchantSettingsPaymentMethods(
            Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod applePay = null,
            Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod googlePay = null,
            Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod cashApp = null,
            Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay afterpayClearpay = null)
        {
            this.ApplePay = applePay;
            this.GooglePay = googlePay;
            this.CashApp = cashApp;
            this.AfterpayClearpay = afterpayClearpay;
        }

        /// <summary>
        /// The settings allowed for a payment method.
        /// </summary>
        [JsonProperty("apple_pay", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod ApplePay { get; }

        /// <summary>
        /// The settings allowed for a payment method.
        /// </summary>
        [JsonProperty("google_pay", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod GooglePay { get; }

        /// <summary>
        /// The settings allowed for a payment method.
        /// </summary>
        [JsonProperty("cash_app", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod CashApp { get; }

        /// <summary>
        /// The settings allowed for AfterpayClearpay.
        /// </summary>
        [JsonProperty("afterpay_clearpay", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay AfterpayClearpay { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckoutMerchantSettingsPaymentMethods : ({string.Join(", ", toStringOutput)})";
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
            return obj is CheckoutMerchantSettingsPaymentMethods other &&                ((this.ApplePay == null && other.ApplePay == null) || (this.ApplePay?.Equals(other.ApplePay) == true)) &&
                ((this.GooglePay == null && other.GooglePay == null) || (this.GooglePay?.Equals(other.GooglePay) == true)) &&
                ((this.CashApp == null && other.CashApp == null) || (this.CashApp?.Equals(other.CashApp) == true)) &&
                ((this.AfterpayClearpay == null && other.AfterpayClearpay == null) || (this.AfterpayClearpay?.Equals(other.AfterpayClearpay) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 761016599;
            hashCode = HashCode.Combine(this.ApplePay, this.GooglePay, this.CashApp, this.AfterpayClearpay);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ApplePay = {(this.ApplePay == null ? "null" : this.ApplePay.ToString())}");
            toStringOutput.Add($"this.GooglePay = {(this.GooglePay == null ? "null" : this.GooglePay.ToString())}");
            toStringOutput.Add($"this.CashApp = {(this.CashApp == null ? "null" : this.CashApp.ToString())}");
            toStringOutput.Add($"this.AfterpayClearpay = {(this.AfterpayClearpay == null ? "null" : this.AfterpayClearpay.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ApplePay(this.ApplePay)
                .GooglePay(this.GooglePay)
                .CashApp(this.CashApp)
                .AfterpayClearpay(this.AfterpayClearpay);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod applePay;
            private Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod googlePay;
            private Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod cashApp;
            private Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay afterpayClearpay;

             /// <summary>
             /// ApplePay.
             /// </summary>
             /// <param name="applePay"> applePay. </param>
             /// <returns> Builder. </returns>
            public Builder ApplePay(Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod applePay)
            {
                this.applePay = applePay;
                return this;
            }

             /// <summary>
             /// GooglePay.
             /// </summary>
             /// <param name="googlePay"> googlePay. </param>
             /// <returns> Builder. </returns>
            public Builder GooglePay(Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod googlePay)
            {
                this.googlePay = googlePay;
                return this;
            }

             /// <summary>
             /// CashApp.
             /// </summary>
             /// <param name="cashApp"> cashApp. </param>
             /// <returns> Builder. </returns>
            public Builder CashApp(Models.CheckoutMerchantSettingsPaymentMethodsPaymentMethod cashApp)
            {
                this.cashApp = cashApp;
                return this;
            }

             /// <summary>
             /// AfterpayClearpay.
             /// </summary>
             /// <param name="afterpayClearpay"> afterpayClearpay. </param>
             /// <returns> Builder. </returns>
            public Builder AfterpayClearpay(Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay afterpayClearpay)
            {
                this.afterpayClearpay = afterpayClearpay;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutMerchantSettingsPaymentMethods. </returns>
            public CheckoutMerchantSettingsPaymentMethods Build()
            {
                return new CheckoutMerchantSettingsPaymentMethods(
                    this.applePay,
                    this.googlePay,
                    this.cashApp,
                    this.afterpayClearpay);
            }
        }
    }
}