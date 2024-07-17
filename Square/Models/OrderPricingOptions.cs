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
    /// OrderPricingOptions.
    /// </summary>
    public class OrderPricingOptions
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderPricingOptions"/> class.
        /// </summary>
        /// <param name="autoApplyDiscounts">auto_apply_discounts.</param>
        /// <param name="autoApplyTaxes">auto_apply_taxes.</param>
        public OrderPricingOptions(
            bool? autoApplyDiscounts = null,
            bool? autoApplyTaxes = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "auto_apply_discounts", false },
                { "auto_apply_taxes", false }
            };

            if (autoApplyDiscounts != null)
            {
                shouldSerialize["auto_apply_discounts"] = true;
                this.AutoApplyDiscounts = autoApplyDiscounts;
            }

            if (autoApplyTaxes != null)
            {
                shouldSerialize["auto_apply_taxes"] = true;
                this.AutoApplyTaxes = autoApplyTaxes;
            }

        }
        internal OrderPricingOptions(Dictionary<string, bool> shouldSerialize,
            bool? autoApplyDiscounts = null,
            bool? autoApplyTaxes = null)
        {
            this.shouldSerialize = shouldSerialize;
            AutoApplyDiscounts = autoApplyDiscounts;
            AutoApplyTaxes = autoApplyTaxes;
        }

        /// <summary>
        /// The option to determine whether pricing rule-based
        /// discounts are automatically applied to an order.
        /// </summary>
        [JsonProperty("auto_apply_discounts")]
        public bool? AutoApplyDiscounts { get; }

        /// <summary>
        /// The option to determine whether rule-based taxes are automatically
        /// applied to an order when the criteria of the corresponding rules are met.
        /// </summary>
        [JsonProperty("auto_apply_taxes")]
        public bool? AutoApplyTaxes { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderPricingOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAutoApplyDiscounts()
        {
            return this.shouldSerialize["auto_apply_discounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAutoApplyTaxes()
        {
            return this.shouldSerialize["auto_apply_taxes"];
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
            return obj is OrderPricingOptions other &&                ((this.AutoApplyDiscounts == null && other.AutoApplyDiscounts == null) || (this.AutoApplyDiscounts?.Equals(other.AutoApplyDiscounts) == true)) &&
                ((this.AutoApplyTaxes == null && other.AutoApplyTaxes == null) || (this.AutoApplyTaxes?.Equals(other.AutoApplyTaxes) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1105954045;
            hashCode = HashCode.Combine(this.AutoApplyDiscounts, this.AutoApplyTaxes);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AutoApplyDiscounts = {(this.AutoApplyDiscounts == null ? "null" : this.AutoApplyDiscounts.ToString())}");
            toStringOutput.Add($"this.AutoApplyTaxes = {(this.AutoApplyTaxes == null ? "null" : this.AutoApplyTaxes.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AutoApplyDiscounts(this.AutoApplyDiscounts)
                .AutoApplyTaxes(this.AutoApplyTaxes);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "auto_apply_discounts", false },
                { "auto_apply_taxes", false },
            };

            private bool? autoApplyDiscounts;
            private bool? autoApplyTaxes;

             /// <summary>
             /// AutoApplyDiscounts.
             /// </summary>
             /// <param name="autoApplyDiscounts"> autoApplyDiscounts. </param>
             /// <returns> Builder. </returns>
            public Builder AutoApplyDiscounts(bool? autoApplyDiscounts)
            {
                shouldSerialize["auto_apply_discounts"] = true;
                this.autoApplyDiscounts = autoApplyDiscounts;
                return this;
            }

             /// <summary>
             /// AutoApplyTaxes.
             /// </summary>
             /// <param name="autoApplyTaxes"> autoApplyTaxes. </param>
             /// <returns> Builder. </returns>
            public Builder AutoApplyTaxes(bool? autoApplyTaxes)
            {
                shouldSerialize["auto_apply_taxes"] = true;
                this.autoApplyTaxes = autoApplyTaxes;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAutoApplyDiscounts()
            {
                this.shouldSerialize["auto_apply_discounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAutoApplyTaxes()
            {
                this.shouldSerialize["auto_apply_taxes"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderPricingOptions. </returns>
            public OrderPricingOptions Build()
            {
                return new OrderPricingOptions(shouldSerialize,
                    this.autoApplyDiscounts,
                    this.autoApplyTaxes);
            }
        }
    }
}