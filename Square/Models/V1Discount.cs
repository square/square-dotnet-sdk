using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Discount 
    {
        public V1Discount(string id = null,
            string name = null,
            string rate = null,
            Models.V1Money amountMoney = null,
            string discountType = null,
            bool? pinRequired = null,
            string color = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            Rate = rate;
            AmountMoney = amountMoney;
            DiscountType = discountType;
            PinRequired = pinRequired;
            Color = color;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The discount's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The discount's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The rate of the discount, as a string representation of a decimal number. A value of 0.07 corresponds to a rate of 7%. This rate is 0 if discount_type is VARIABLE_PERCENTAGE.
        /// </summary>
        [JsonProperty("rate")]
        public string Rate { get; }

        /// <summary>
        /// Getter for amount_money
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.V1Money AmountMoney { get; }

        /// <summary>
        /// Getter for discount_type
        /// </summary>
        [JsonProperty("discount_type")]
        public string DiscountType { get; }

        /// <summary>
        /// Indicates whether a mobile staff member needs to enter their PIN to apply the discount to a payment.
        /// </summary>
        [JsonProperty("pin_required")]
        public bool? PinRequired { get; }

        /// <summary>
        /// Getter for color
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id")]
        public string V2Id { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .Rate(Rate)
                .AmountMoney(AmountMoney)
                .DiscountType(DiscountType)
                .PinRequired(PinRequired)
                .Color(Color)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string rate;
            private Models.V1Money amountMoney;
            private string discountType;
            private bool? pinRequired;
            private string color;
            private string v2Id;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Rate(string value)
            {
                rate = value;
                return this;
            }

            public Builder AmountMoney(Models.V1Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder DiscountType(string value)
            {
                discountType = value;
                return this;
            }

            public Builder PinRequired(bool? value)
            {
                pinRequired = value;
                return this;
            }

            public Builder Color(string value)
            {
                color = value;
                return this;
            }

            public Builder V2Id(string value)
            {
                v2Id = value;
                return this;
            }

            public V1Discount Build()
            {
                return new V1Discount(id,
                    name,
                    rate,
                    amountMoney,
                    discountType,
                    pinRequired,
                    color,
                    v2Id);
            }
        }
    }
}