namespace Square.Models
{
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

    /// <summary>
    /// CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay.
    /// </summary>
    public class CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay"/> class.
        /// </summary>
        /// <param name="orderEligibilityRange">order_eligibility_range.</param>
        /// <param name="itemEligibilityRange">item_eligibility_range.</param>
        /// <param name="enabled">enabled.</param>
        public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay(
            Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange orderEligibilityRange = null,
            Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange itemEligibilityRange = null,
            bool? enabled = null)
        {
            this.OrderEligibilityRange = orderEligibilityRange;
            this.ItemEligibilityRange = itemEligibilityRange;
            this.Enabled = enabled;
        }

        /// <summary>
        /// A range of purchase price that qualifies.
        /// </summary>
        [JsonProperty("order_eligibility_range", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange OrderEligibilityRange { get; }

        /// <summary>
        /// A range of purchase price that qualifies.
        /// </summary>
        [JsonProperty("item_eligibility_range", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange ItemEligibilityRange { get; }

        /// <summary>
        /// Indicates whether the payment method is enabled for the account.
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay : ({string.Join(", ", toStringOutput)})";
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
            return obj is CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay other &&                ((this.OrderEligibilityRange == null && other.OrderEligibilityRange == null) || (this.OrderEligibilityRange?.Equals(other.OrderEligibilityRange) == true)) &&
                ((this.ItemEligibilityRange == null && other.ItemEligibilityRange == null) || (this.ItemEligibilityRange?.Equals(other.ItemEligibilityRange) == true)) &&
                ((this.Enabled == null && other.Enabled == null) || (this.Enabled?.Equals(other.Enabled) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 136387679;
            hashCode = HashCode.Combine(this.OrderEligibilityRange, this.ItemEligibilityRange, this.Enabled);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderEligibilityRange = {(this.OrderEligibilityRange == null ? "null" : this.OrderEligibilityRange.ToString())}");
            toStringOutput.Add($"this.ItemEligibilityRange = {(this.ItemEligibilityRange == null ? "null" : this.ItemEligibilityRange.ToString())}");
            toStringOutput.Add($"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderEligibilityRange(this.OrderEligibilityRange)
                .ItemEligibilityRange(this.ItemEligibilityRange)
                .Enabled(this.Enabled);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange orderEligibilityRange;
            private Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange itemEligibilityRange;
            private bool? enabled;

             /// <summary>
             /// OrderEligibilityRange.
             /// </summary>
             /// <param name="orderEligibilityRange"> orderEligibilityRange. </param>
             /// <returns> Builder. </returns>
            public Builder OrderEligibilityRange(Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange orderEligibilityRange)
            {
                this.orderEligibilityRange = orderEligibilityRange;
                return this;
            }

             /// <summary>
             /// ItemEligibilityRange.
             /// </summary>
             /// <param name="itemEligibilityRange"> itemEligibilityRange. </param>
             /// <returns> Builder. </returns>
            public Builder ItemEligibilityRange(Models.CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange itemEligibilityRange)
            {
                this.itemEligibilityRange = itemEligibilityRange;
                return this;
            }

             /// <summary>
             /// Enabled.
             /// </summary>
             /// <param name="enabled"> enabled. </param>
             /// <returns> Builder. </returns>
            public Builder Enabled(bool? enabled)
            {
                this.enabled = enabled;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay. </returns>
            public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay Build()
            {
                return new CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay(
                    this.orderEligibilityRange,
                    this.itemEligibilityRange,
                    this.enabled);
            }
        }
    }
}