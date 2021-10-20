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
    /// GiftCardActivityRefund.
    /// </summary>
    public class GiftCardActivityRefund
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityRefund"/> class.
        /// </summary>
        /// <param name="redeemActivityId">redeem_activity_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="paymentId">payment_id.</param>
        public GiftCardActivityRefund(
            string redeemActivityId,
            Models.Money amountMoney = null,
            string referenceId = null,
            string paymentId = null)
        {
            this.RedeemActivityId = redeemActivityId;
            this.AmountMoney = amountMoney;
            this.ReferenceId = referenceId;
            this.PaymentId = paymentId;
        }

        /// <summary>
        /// The ID for the Redeem activity that needs to be refunded. Hence, the activity it
        /// refers to has to be of the REDEEM type.
        /// </summary>
        [JsonProperty("redeem_activity_id")]
        public string RedeemActivityId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// A client-specified ID to associate an entity, in another system, with this gift card
        /// activity. This can be used to track the order or payment related information when the Square Orders
        /// API is not being used.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// When the Square Payments API is used, Refund is not called on the Gift Cards API.
        /// However, when Square reads a Refund activity from the Gift Cards API, the developer needs to know the
        /// ID of the payment (made using this gift card) that is being refunded.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityRefund : ({string.Join(", ", toStringOutput)})";
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

            return obj is GiftCardActivityRefund other &&
                ((this.RedeemActivityId == null && other.RedeemActivityId == null) || (this.RedeemActivityId?.Equals(other.RedeemActivityId) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 53973684;
            hashCode = HashCode.Combine(this.RedeemActivityId, this.AmountMoney, this.ReferenceId, this.PaymentId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RedeemActivityId = {(this.RedeemActivityId == null ? "null" : this.RedeemActivityId == string.Empty ? "" : this.RedeemActivityId)}");
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
                this.RedeemActivityId)
                .AmountMoney(this.AmountMoney)
                .ReferenceId(this.ReferenceId)
                .PaymentId(this.PaymentId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string redeemActivityId;
            private Models.Money amountMoney;
            private string referenceId;
            private string paymentId;

            public Builder(
                string redeemActivityId)
            {
                this.redeemActivityId = redeemActivityId;
            }

             /// <summary>
             /// RedeemActivityId.
             /// </summary>
             /// <param name="redeemActivityId"> redeemActivityId. </param>
             /// <returns> Builder. </returns>
            public Builder RedeemActivityId(string redeemActivityId)
            {
                this.redeemActivityId = redeemActivityId;
                return this;
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
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityRefund. </returns>
            public GiftCardActivityRefund Build()
            {
                return new GiftCardActivityRefund(
                    this.redeemActivityId,
                    this.amountMoney,
                    this.referenceId,
                    this.paymentId);
            }
        }
    }
}