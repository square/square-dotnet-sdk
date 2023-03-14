namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// V1SettlementEntry.
    /// </summary>
    public class V1SettlementEntry
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1SettlementEntry"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="type">type.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="feeMoney">fee_money.</param>
        public V1SettlementEntry(
            string paymentId = null,
            string type = null,
            Models.V1Money amountMoney = null,
            Models.V1Money feeMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false }
            };

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            this.Type = type;
            this.AmountMoney = amountMoney;
            this.FeeMoney = feeMoney;
        }
        internal V1SettlementEntry(Dictionary<string, bool> shouldSerialize,
            string paymentId = null,
            string type = null,
            Models.V1Money amountMoney = null,
            Models.V1Money feeMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Gets or sets AmountMoney.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AmountMoney { get; }

        /// <summary>
        /// Gets or sets FeeMoney.
        /// </summary>
        [JsonProperty("fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money FeeMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1SettlementEntry : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
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

            return obj is V1SettlementEntry other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.FeeMoney == null && other.FeeMoney == null) || (this.FeeMoney?.Equals(other.FeeMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2064570648;
            hashCode = HashCode.Combine(this.PaymentId, this.Type, this.AmountMoney, this.FeeMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.FeeMoney = {(this.FeeMoney == null ? "null" : this.FeeMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(this.PaymentId)
                .Type(this.Type)
                .AmountMoney(this.AmountMoney)
                .FeeMoney(this.FeeMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
            };

            private string paymentId;
            private string type;
            private Models.V1Money amountMoney;
            private Models.V1Money feeMoney;

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                shouldSerialize["payment_id"] = true;
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.V1Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// FeeMoney.
             /// </summary>
             /// <param name="feeMoney"> feeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder FeeMoney(Models.V1Money feeMoney)
            {
                this.feeMoney = feeMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1SettlementEntry. </returns>
            public V1SettlementEntry Build()
            {
                return new V1SettlementEntry(shouldSerialize,
                    this.paymentId,
                    this.type,
                    this.amountMoney,
                    this.feeMoney);
            }
        }
    }
}