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
    public class V1PaymentDiscount 
    {
        public V1PaymentDiscount(string name = null,
            Models.V1Money appliedMoney = null,
            string discountId = null)
        {
            Name = name;
            AppliedMoney = appliedMoney;
            DiscountId = discountId;
        }

        /// <summary>
        /// The discount's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Getter for applied_money
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The ID of the applied discount, if available. Discounts applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("discount_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .AppliedMoney(AppliedMoney)
                .DiscountId(DiscountId);
            return builder;
        }

        public class Builder
        {
            private string name;
            private Models.V1Money appliedMoney;
            private string discountId;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder AppliedMoney(Models.V1Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            public Builder DiscountId(string discountId)
            {
                this.discountId = discountId;
                return this;
            }

            public V1PaymentDiscount Build()
            {
                return new V1PaymentDiscount(name,
                    appliedMoney,
                    discountId);
            }
        }
    }
}