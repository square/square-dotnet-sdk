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
    /// AcceptedPaymentMethods.
    /// </summary>
    public class AcceptedPaymentMethods
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptedPaymentMethods"/> class.
        /// </summary>
        /// <param name="applePay">apple_pay.</param>
        /// <param name="googlePay">google_pay.</param>
        /// <param name="cashAppPay">cash_app_pay.</param>
        /// <param name="afterpayClearpay">afterpay_clearpay.</param>
        public AcceptedPaymentMethods(
            bool? applePay = null,
            bool? googlePay = null,
            bool? cashAppPay = null,
            bool? afterpayClearpay = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "apple_pay", false },
                { "google_pay", false },
                { "cash_app_pay", false },
                { "afterpay_clearpay", false }
            };

            if (applePay != null)
            {
                shouldSerialize["apple_pay"] = true;
                this.ApplePay = applePay;
            }

            if (googlePay != null)
            {
                shouldSerialize["google_pay"] = true;
                this.GooglePay = googlePay;
            }

            if (cashAppPay != null)
            {
                shouldSerialize["cash_app_pay"] = true;
                this.CashAppPay = cashAppPay;
            }

            if (afterpayClearpay != null)
            {
                shouldSerialize["afterpay_clearpay"] = true;
                this.AfterpayClearpay = afterpayClearpay;
            }

        }
        internal AcceptedPaymentMethods(Dictionary<string, bool> shouldSerialize,
            bool? applePay = null,
            bool? googlePay = null,
            bool? cashAppPay = null,
            bool? afterpayClearpay = null)
        {
            this.shouldSerialize = shouldSerialize;
            ApplePay = applePay;
            GooglePay = googlePay;
            CashAppPay = cashAppPay;
            AfterpayClearpay = afterpayClearpay;
        }

        /// <summary>
        /// Whether Apple Pay is accepted at checkout.
        /// </summary>
        [JsonProperty("apple_pay")]
        public bool? ApplePay { get; }

        /// <summary>
        /// Whether Google Pay is accepted at checkout.
        /// </summary>
        [JsonProperty("google_pay")]
        public bool? GooglePay { get; }

        /// <summary>
        /// Whether Cash App Pay is accepted at checkout.
        /// </summary>
        [JsonProperty("cash_app_pay")]
        public bool? CashAppPay { get; }

        /// <summary>
        /// Whether Afterpay/Clearpay is accepted at checkout.
        /// </summary>
        [JsonProperty("afterpay_clearpay")]
        public bool? AfterpayClearpay { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AcceptedPaymentMethods : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplePay()
        {
            return this.shouldSerialize["apple_pay"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeGooglePay()
        {
            return this.shouldSerialize["google_pay"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCashAppPay()
        {
            return this.shouldSerialize["cash_app_pay"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAfterpayClearpay()
        {
            return this.shouldSerialize["afterpay_clearpay"];
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

            return obj is AcceptedPaymentMethods other &&
                ((this.ApplePay == null && other.ApplePay == null) || (this.ApplePay?.Equals(other.ApplePay) == true)) &&
                ((this.GooglePay == null && other.GooglePay == null) || (this.GooglePay?.Equals(other.GooglePay) == true)) &&
                ((this.CashAppPay == null && other.CashAppPay == null) || (this.CashAppPay?.Equals(other.CashAppPay) == true)) &&
                ((this.AfterpayClearpay == null && other.AfterpayClearpay == null) || (this.AfterpayClearpay?.Equals(other.AfterpayClearpay) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1012972110;
            hashCode = HashCode.Combine(this.ApplePay, this.GooglePay, this.CashAppPay, this.AfterpayClearpay);

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
            toStringOutput.Add($"this.CashAppPay = {(this.CashAppPay == null ? "null" : this.CashAppPay.ToString())}");
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
                .CashAppPay(this.CashAppPay)
                .AfterpayClearpay(this.AfterpayClearpay);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "apple_pay", false },
                { "google_pay", false },
                { "cash_app_pay", false },
                { "afterpay_clearpay", false },
            };

            private bool? applePay;
            private bool? googlePay;
            private bool? cashAppPay;
            private bool? afterpayClearpay;

             /// <summary>
             /// ApplePay.
             /// </summary>
             /// <param name="applePay"> applePay. </param>
             /// <returns> Builder. </returns>
            public Builder ApplePay(bool? applePay)
            {
                shouldSerialize["apple_pay"] = true;
                this.applePay = applePay;
                return this;
            }

             /// <summary>
             /// GooglePay.
             /// </summary>
             /// <param name="googlePay"> googlePay. </param>
             /// <returns> Builder. </returns>
            public Builder GooglePay(bool? googlePay)
            {
                shouldSerialize["google_pay"] = true;
                this.googlePay = googlePay;
                return this;
            }

             /// <summary>
             /// CashAppPay.
             /// </summary>
             /// <param name="cashAppPay"> cashAppPay. </param>
             /// <returns> Builder. </returns>
            public Builder CashAppPay(bool? cashAppPay)
            {
                shouldSerialize["cash_app_pay"] = true;
                this.cashAppPay = cashAppPay;
                return this;
            }

             /// <summary>
             /// AfterpayClearpay.
             /// </summary>
             /// <param name="afterpayClearpay"> afterpayClearpay. </param>
             /// <returns> Builder. </returns>
            public Builder AfterpayClearpay(bool? afterpayClearpay)
            {
                shouldSerialize["afterpay_clearpay"] = true;
                this.afterpayClearpay = afterpayClearpay;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplePay()
            {
                this.shouldSerialize["apple_pay"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetGooglePay()
            {
                this.shouldSerialize["google_pay"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCashAppPay()
            {
                this.shouldSerialize["cash_app_pay"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAfterpayClearpay()
            {
                this.shouldSerialize["afterpay_clearpay"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AcceptedPaymentMethods. </returns>
            public AcceptedPaymentMethods Build()
            {
                return new AcceptedPaymentMethods(shouldSerialize,
                    this.applePay,
                    this.googlePay,
                    this.cashAppPay,
                    this.afterpayClearpay);
            }
        }
    }
}