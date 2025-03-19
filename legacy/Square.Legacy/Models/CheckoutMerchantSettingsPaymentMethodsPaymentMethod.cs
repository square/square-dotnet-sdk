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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CheckoutMerchantSettingsPaymentMethodsPaymentMethod.
    /// </summary>
    public class CheckoutMerchantSettingsPaymentMethodsPaymentMethod
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutMerchantSettingsPaymentMethodsPaymentMethod"/> class.
        /// </summary>
        /// <param name="enabled">enabled.</param>
        public CheckoutMerchantSettingsPaymentMethodsPaymentMethod(bool? enabled = null)
        {
            shouldSerialize = new Dictionary<string, bool> { { "enabled", false } };

            if (enabled != null)
            {
                shouldSerialize["enabled"] = true;
                this.Enabled = enabled;
            }
        }

        internal CheckoutMerchantSettingsPaymentMethodsPaymentMethod(
            Dictionary<string, bool> shouldSerialize,
            bool? enabled = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Enabled = enabled;
        }

        /// <summary>
        /// Indicates whether the payment method is enabled for the account.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CheckoutMerchantSettingsPaymentMethodsPaymentMethod : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnabled()
        {
            return this.shouldSerialize["enabled"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CheckoutMerchantSettingsPaymentMethodsPaymentMethod other
                && (
                    this.Enabled == null && other.Enabled == null
                    || this.Enabled?.Equals(other.Enabled) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1582271258;
            hashCode = HashCode.Combine(hashCode, this.Enabled);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Enabled(this.Enabled);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "enabled", false },
            };

            private bool? enabled;

            /// <summary>
            /// Enabled.
            /// </summary>
            /// <param name="enabled"> enabled. </param>
            /// <returns> Builder. </returns>
            public Builder Enabled(bool? enabled)
            {
                shouldSerialize["enabled"] = true;
                this.enabled = enabled;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEnabled()
            {
                this.shouldSerialize["enabled"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutMerchantSettingsPaymentMethodsPaymentMethod. </returns>
            public CheckoutMerchantSettingsPaymentMethodsPaymentMethod Build()
            {
                return new CheckoutMerchantSettingsPaymentMethodsPaymentMethod(
                    shouldSerialize,
                    this.enabled
                );
            }
        }
    }
}
