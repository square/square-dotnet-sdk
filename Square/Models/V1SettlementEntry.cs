
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
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Getter for amount_money
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AmountMoney { get; }

        /// <summary>
        /// Getter for fee_money
        /// </summary>
        [JsonProperty("fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money FeeMoney { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1SettlementEntry : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"PaymentId = {(PaymentId == null ? "null" : PaymentId == string.Empty ? "" : PaymentId)}");
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type.ToString())}");
            toStringOutput.Add($"AmountMoney = {(AmountMoney == null ? "null" : AmountMoney.ToString())}");
            toStringOutput.Add($"FeeMoney = {(FeeMoney == null ? "null" : FeeMoney.ToString())}");
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

            return obj is V1SettlementEntry other &&
                ((PaymentId == null && other.PaymentId == null) || (PaymentId?.Equals(other.PaymentId) == true)) &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((AmountMoney == null && other.AmountMoney == null) || (AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((FeeMoney == null && other.FeeMoney == null) || (FeeMoney?.Equals(other.FeeMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2064570648;

            if (PaymentId != null)
            {
               hashCode += PaymentId.GetHashCode();
            }

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (AmountMoney != null)
            {
               hashCode += AmountMoney.GetHashCode();
            }

            if (FeeMoney != null)
            {
               hashCode += FeeMoney.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder AmountMoney(Models.V1Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder FeeMoney(Models.V1Money feeMoney)
            {
                this.feeMoney = feeMoney;
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