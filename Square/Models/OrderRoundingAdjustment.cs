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
    public class OrderRoundingAdjustment 
    {
        public OrderRoundingAdjustment(string uid = null,
            string name = null,
            Models.Money amountMoney = null)
        {
            Uid = uid;
            Name = name;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// Unique ID that identifies the rounding adjustment only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The name of the rounding adjustment from the original sale Order.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .Name(Name)
                .AmountMoney(AmountMoney);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string name;
            private Models.Money amountMoney;

            public Builder() { }
            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public OrderRoundingAdjustment Build()
            {
                return new OrderRoundingAdjustment(uid,
                    name,
                    amountMoney);
            }
        }
    }
}