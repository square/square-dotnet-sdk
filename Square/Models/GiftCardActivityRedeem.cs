namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// GiftCardActivityRedeem.
    /// </summary>
    public class GiftCardActivityRedeem
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityRedeem"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="status">status.</param>
        public GiftCardActivityRedeem(
            Models.Money amountMoney,
            string paymentId = null,
            string referenceId = null,
            string status = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false }
            };

            this.AmountMoney = amountMoney;
            this.PaymentId = paymentId;
            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            this.Status = status;
        }
        internal GiftCardActivityRedeem(Dictionary<string, bool> shouldSerialize,
            Models.Money amountMoney,
            string paymentId = null,
            string referenceId = null,
            string status = null)
        {
            this.shouldSerialize = shouldSerialize;
            AmountMoney = amountMoney;
            PaymentId = paymentId;
            ReferenceId = referenceId;
            Status = status;
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
        /// The ID of the payment that represents the gift card redemption. Square populates this field
        /// if the payment was processed by Square.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// A client-specified ID that associates the gift card activity with an entity in another system.
        /// Applications that use a custom payment processing system can use this field to track information
        /// related to an order or payment.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Indicates the status of a [gift card]($m/GiftCard) redemption. This status is relevant only for
        /// redemptions made from Square products (such as Square Point of Sale) because Square products use a
        /// two-state process. Gift cards redeemed using the Gift Card Activities API always have a `COMPLETED` status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityRedeem : ({string.Join(", ", toStringOutput)})";
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
            return obj is GiftCardActivityRedeem other &&                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1898558398;
            hashCode = HashCode.Combine(this.AmountMoney, this.PaymentId, this.ReferenceId, this.Status);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
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
                .ReferenceId(this.ReferenceId)
                .Status(this.Status);
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
            private string paymentId;
            private string referenceId;
            private string status;

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
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
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
            /// <returns> GiftCardActivityRedeem. </returns>
            public GiftCardActivityRedeem Build()
            {
                return new GiftCardActivityRedeem(shouldSerialize,
                    this.amountMoney,
                    this.paymentId,
                    this.referenceId,
                    this.status);
            }
        }
    }
}