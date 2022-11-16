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
    /// GiftCardActivityUnlinkedActivityRefund.
    /// </summary>
    public class GiftCardActivityUnlinkedActivityRefund
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityUnlinkedActivityRefund"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="paymentId">payment_id.</param>
        public GiftCardActivityUnlinkedActivityRefund(
            Models.Money amountMoney,
            string referenceId = null,
            string paymentId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false }
            };

            this.AmountMoney = amountMoney;
            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            this.PaymentId = paymentId;
        }
        internal GiftCardActivityUnlinkedActivityRefund(Dictionary<string, bool> shouldSerialize,
            Models.Money amountMoney,
            string referenceId = null,
            string paymentId = null)
        {
            this.shouldSerialize = shouldSerialize;
            AmountMoney = amountMoney;
            ReferenceId = referenceId;
            PaymentId = paymentId;
        }

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

        /// <summary>
        /// A client-specified ID that associates the gift card activity with an entity in another system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The ID of the refunded payment. This field is not used starting in Square version 2022-06-16.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityUnlinkedActivityRefund : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
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

            return obj is GiftCardActivityUnlinkedActivityRefund other &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1819618874;
            hashCode = HashCode.Combine(this.AmountMoney, this.ReferenceId, this.PaymentId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AmountMoney)
                .ReferenceId(this.ReferenceId)
                .PaymentId(this.PaymentId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
            };

            private Models.Money amountMoney;
            private string referenceId;
            private string paymentId;

            public Builder(
                Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityUnlinkedActivityRefund. </returns>
            public GiftCardActivityUnlinkedActivityRefund Build()
            {
                return new GiftCardActivityUnlinkedActivityRefund(shouldSerialize,
                    this.amountMoney,
                    this.referenceId,
                    this.paymentId);
            }
        }
    }
}