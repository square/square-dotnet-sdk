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
        public OrderPricingOptions(bool? autoApplyDiscounts = null)
        {
            AutoApplyDiscounts = autoApplyDiscounts;
        }

        /// <summary>
        /// The option to determine whether or not pricing rule-based discounts are automatically applied to an order.
        /// </summary>
        [JsonProperty("auto_apply_discounts")]
        public bool? AutoApplyDiscounts { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AutoApplyDiscounts(AutoApplyDiscounts);
            return builder;
        }

        public class Builder
        {
            private bool? autoApplyDiscounts;

            public Builder() { }
            public Builder AutoApplyDiscounts(bool? value)
            {
                autoApplyDiscounts = value;
                return this;
            }

            public OrderPricingOptions Build()
            {
                return new OrderPricingOptions(autoApplyDiscounts);
            }
        }
    }
}