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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// GiftCardActivityRefund.
    /// </summary>
    public class GiftCardActivityRefund
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityRefund"/> class.
        /// </summary>
        /// <param name="redeemActivityId">redeem_activity_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="paymentId">payment_id.</param>
        public GiftCardActivityRefund(
            string redeemActivityId = null,
            Models.Money amountMoney = null,
            string referenceId = null,
            string paymentId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "redeem_activity_id", false },
                { "reference_id", false },
            };

            if (redeemActivityId != null)
            {
                shouldSerialize["redeem_activity_id"] = true;
                this.RedeemActivityId = redeemActivityId;
            }
            this.AmountMoney = amountMoney;

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }
            this.PaymentId = paymentId;
        }

        internal GiftCardActivityRefund(
            Dictionary<string, bool> shouldSerialize,
            string redeemActivityId = null,
            Models.Money amountMoney = null,
            string referenceId = null,
            string paymentId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            RedeemActivityId = redeemActivityId;
            AmountMoney = amountMoney;
            ReferenceId = referenceId;
            PaymentId = paymentId;
        }

        /// <summary>
        /// The ID of the refunded `REDEEM` gift card activity. Square populates this field if the
        /// `payment_id` in the corresponding [RefundPayment](api-endpoint:Refunds-RefundPayment) request
        /// represents a gift card redemption.
        /// For applications that use a custom payment processing system, this field is required when creating
        /// a `REFUND` activity. The provided `REDEEM` activity ID must be linked to the same gift card.
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
        /// A client-specified ID that associates the gift card activity with an entity in another system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The ID of the refunded payment. Square populates this field if the refund is for a
        /// payment processed by Square.Legacy. This field matches the `payment_id` in the corresponding
        /// [RefundPayment](api-endpoint:Refunds-RefundPayment) request.
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRedeemActivityId()
        {
            return this.shouldSerialize["redeem_activity_id"];
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is GiftCardActivityRefund other
                && (
                    this.RedeemActivityId == null && other.RedeemActivityId == null
                    || this.RedeemActivityId?.Equals(other.RedeemActivityId) == true
                )
                && (
                    this.AmountMoney == null && other.AmountMoney == null
                    || this.AmountMoney?.Equals(other.AmountMoney) == true
                )
                && (
                    this.ReferenceId == null && other.ReferenceId == null
                    || this.ReferenceId?.Equals(other.ReferenceId) == true
                )
                && (
                    this.PaymentId == null && other.PaymentId == null
                    || this.PaymentId?.Equals(other.PaymentId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 53973684;
            hashCode = HashCode.Combine(
                hashCode,
                this.RedeemActivityId,
                this.AmountMoney,
                this.ReferenceId,
                this.PaymentId
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RedeemActivityId = {this.RedeemActivityId ?? "null"}");
            toStringOutput.Add(
                $"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}"
            );
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add($"this.PaymentId = {this.PaymentId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .RedeemActivityId(this.RedeemActivityId)
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "redeem_activity_id", false },
                { "reference_id", false },
            };

            private string redeemActivityId;
            private Models.Money amountMoney;
            private string referenceId;
            private string paymentId;

            /// <summary>
            /// RedeemActivityId.
            /// </summary>
            /// <param name="redeemActivityId"> redeemActivityId. </param>
            /// <returns> Builder. </returns>
            public Builder RedeemActivityId(string redeemActivityId)
            {
                shouldSerialize["redeem_activity_id"] = true;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetRedeemActivityId()
            {
                this.shouldSerialize["redeem_activity_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityRefund. </returns>
            public GiftCardActivityRefund Build()
            {
                return new GiftCardActivityRefund(
                    shouldSerialize,
                    this.redeemActivityId,
                    this.amountMoney,
                    this.referenceId,
                    this.paymentId
                );
            }
        }
    }
}
