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