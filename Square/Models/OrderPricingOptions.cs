
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
    public class OrderPricingOptions 
    {
        public OrderPricingOptions(bool? autoApplyDiscounts = null,
            bool? autoApplyTaxes = null)
        {
            AutoApplyDiscounts = autoApplyDiscounts;
            AutoApplyTaxes = autoApplyTaxes;
        }

        /// <summary>
        /// The option to determine whether pricing rule-based
        /// discounts are automatically applied to an order.
        /// </summary>
        [JsonProperty("auto_apply_discounts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoApplyDiscounts { get; }

        /// <summary>
        /// The option to determine whether rule-based taxes are automatically
        /// applied to an order when the criteria of the corresponding rules are met.
        /// </summary>
        [JsonProperty("auto_apply_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoApplyTaxes { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderPricingOptions : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AutoApplyDiscounts = {(AutoApplyDiscounts == null ? "null" : AutoApplyDiscounts.ToString())}");
            toStringOutput.Add($"AutoApplyTaxes = {(AutoApplyTaxes == null ? "null" : AutoApplyTaxes.ToString())}");
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

            return obj is OrderPricingOptions other &&
                ((AutoApplyDiscounts == null && other.AutoApplyDiscounts == null) || (AutoApplyDiscounts?.Equals(other.AutoApplyDiscounts) == true)) &&
                ((AutoApplyTaxes == null && other.AutoApplyTaxes == null) || (AutoApplyTaxes?.Equals(other.AutoApplyTaxes) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1105954045;

            if (AutoApplyDiscounts != null)
            {
               hashCode += AutoApplyDiscounts.GetHashCode();
            }

            if (AutoApplyTaxes != null)
            {
               hashCode += AutoApplyTaxes.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AutoApplyDiscounts(AutoApplyDiscounts)
                .AutoApplyTaxes(AutoApplyTaxes);
            return builder;
        }

        public class Builder
        {
            private bool? autoApplyDiscounts;
            private bool? autoApplyTaxes;



            public Builder AutoApplyDiscounts(bool? autoApplyDiscounts)
            {
                this.autoApplyDiscounts = autoApplyDiscounts;
                return this;
            }

            public Builder AutoApplyTaxes(bool? autoApplyTaxes)
            {
                this.autoApplyTaxes = autoApplyTaxes;
                return this;
            }

            public OrderPricingOptions Build()
            {
                return new OrderPricingOptions(autoApplyDiscounts,
                    autoApplyTaxes);
            }
        }
    }
}