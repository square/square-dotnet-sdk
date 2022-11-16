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
    /// PaymentBalanceActivityRefundDetail.
    /// </summary>
    public class PaymentBalanceActivityRefundDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityRefundDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="refundId">refund_id.</param>
        public PaymentBalanceActivityRefundDetail(
            string paymentId = null,
            string refundId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "refund_id", false }
            };

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (refundId != null)
            {
                shouldSerialize["refund_id"] = true;
                this.RefundId = refundId;
            }

        }
        internal PaymentBalanceActivityRefundDetail(Dictionary<string, bool> shouldSerialize,
            string paymentId = null,
            string refundId = null)
        {
            this.shouldSerialize = shouldSerialize;
            PaymentId = paymentId;
            RefundId = refundId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The ID of the refund associated with this activity.
        /// </summary>
        [JsonProperty("refund_id")]
        public string RefundId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityRefundDetail : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRefundId()
        {
            return this.shouldSerialize["refund_id"];
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

            return obj is PaymentBalanceActivityRefundDetail other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.RefundId == null && other.RefundId == null) || (this.RefundId?.Equals(other.RefundId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -405424502;
            hashCode = HashCode.Combine(this.PaymentId, this.RefundId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.RefundId = {(this.RefundId == null ? "null" : this.RefundId == string.Empty ? "" : this.RefundId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(this.PaymentId)
                .RefundId(this.RefundId);
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
                { "refund_id", false },
            };

            private string paymentId;
            private string refundId;

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
             /// RefundId.
             /// </summary>
             /// <param name="refundId"> refundId. </param>
             /// <returns> Builder. </returns>
            public Builder RefundId(string refundId)
            {
                shouldSerialize["refund_id"] = true;
                this.refundId = refundId;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRefundId()
            {
                this.shouldSerialize["refund_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityRefundDetail. </returns>
            public PaymentBalanceActivityRefundDetail Build()
            {
                return new PaymentBalanceActivityRefundDetail(shouldSerialize,
                    this.paymentId,
                    this.refundId);
            }
        }
    }
}