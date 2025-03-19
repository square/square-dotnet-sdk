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
    /// CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange.
    /// </summary>
    public class CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange"/> class.
        /// </summary>
        /// <param name="min">min.</param>
        /// <param name="max">max.</param>
        public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange(
            Models.Money min,
            Models.Money max
        )
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("min")]
        public Models.Money Min { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("max")]
        public Models.Money Max { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj
                    is CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange other
                && (this.Min == null && other.Min == null || this.Min?.Equals(other.Min) == true)
                && (this.Max == null && other.Max == null || this.Max?.Equals(other.Max) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1658199586;
            hashCode = HashCode.Combine(hashCode, this.Min, this.Max);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Min = {(this.Min == null ? "null" : this.Min.ToString())}");
            toStringOutput.Add($"this.Max = {(this.Max == null ? "null" : this.Max.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Min, this.Max);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money min;
            private Models.Money max;

            /// <summary>
            /// Initialize Builder for CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange.
            /// </summary>
            /// <param name="min"> min. </param>
            /// <param name="max"> max. </param>
            public Builder(Models.Money min, Models.Money max)
            {
                this.min = min;
                this.max = max;
            }

            /// <summary>
            /// Min.
            /// </summary>
            /// <param name="min"> min. </param>
            /// <returns> Builder. </returns>
            public Builder Min(Models.Money min)
            {
                this.min = min;
                return this;
            }

            /// <summary>
            /// Max.
            /// </summary>
            /// <param name="max"> max. </param>
            /// <returns> Builder. </returns>
            public Builder Max(Models.Money max)
            {
                this.max = max;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange. </returns>
            public CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange Build()
            {
                return new CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange(
                    this.min,
                    this.max
                );
            }
        }
    }
}
