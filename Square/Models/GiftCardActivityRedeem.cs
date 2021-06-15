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
    /// GiftCardActivityRedeem.
    /// </summary>
    public class GiftCardActivityRedeem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityRedeem"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="referenceId">reference_id.</param>
        public GiftCardActivityRedeem(
            Models.Money amountMoney,
            string paymentId = null,
            string referenceId = null)
        {
            this.AmountMoney = amountMoney;
            this.PaymentId = paymentId;
            this.ReferenceId = referenceId;
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
        /// When the Square Payments API is used, Redeem is not called on the Gift Cards API.
        /// However, when Square reads a Redeem activity from the Gift Cards API, developers need to know the
        /// associated `payment_id`.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// A client-specified ID to associate an entity, in another system, with this gift card
        /// activity. This can be used to track the order or payment related information when the Square Orders
        /// API is not being used.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityRedeem : ({string.Join(", ", toStringOutput)})";
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

            return obj is GiftCardActivityRedeem other &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -960472333;

            if (this.AmountMoney != null)
            {
               hashCode += this.AmountMoney.GetHashCode();
            }

            if (this.PaymentId != null)
            {
               hashCode += this.PaymentId.GetHashCode();
            }

            if (this.ReferenceId != null)
            {
               hashCode += this.ReferenceId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AmountMoney)
                .PaymentId(this.PaymentId)
                .ReferenceId(this.ReferenceId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money amountMoney;
            private string paymentId;
            private string referenceId;

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
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityRedeem. </returns>
            public GiftCardActivityRedeem Build()
            {
                return new GiftCardActivityRedeem(
                    this.amountMoney,
                    this.paymentId,
                    this.referenceId);
            }
        }
    }
}