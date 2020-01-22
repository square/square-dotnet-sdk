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
    public class V1SettlementEntry 
    {
        public V1SettlementEntry(string paymentId = null,
            string type = null,
            Models.V1Money amountMoney = null,
            Models.V1Money feeMoney = null)
        {
            PaymentId = paymentId;
            Type = type;
            AmountMoney = amountMoney;
            FeeMoney = feeMoney;
        }

        /// <summary>
        /// The settlement's unique identifier.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Getter for amount_money
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.V1Money AmountMoney { get; }

        /// <summary>
        /// Getter for fee_money
        /// </summary>
        [JsonProperty("fee_money")]
        public Models.V1Money FeeMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(PaymentId)
                .Type(Type)
                .AmountMoney(AmountMoney)
                .FeeMoney(FeeMoney);
            return builder;
        }

        public class Builder
        {
            private string paymentId;
            private string type;
            private Models.V1Money amountMoney;
            private Models.V1Money feeMoney;

            public Builder() { }
            public Builder PaymentId(string value)
            {
                paymentId = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder AmountMoney(Models.V1Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder FeeMoney(Models.V1Money value)
            {
                feeMoney = value;
                return this;
            }

            public V1SettlementEntry Build()
            {
                return new V1SettlementEntry(paymentId,
                    type,
                    amountMoney,
                    feeMoney);
            }
        }
    }
}