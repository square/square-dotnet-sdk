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
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityRefundDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="refundId">refund_id.</param>
        public PaymentBalanceActivityRefundDetail(
            string paymentId = null,
            string refundId = null)
        {
            this.PaymentId = paymentId;
            this.RefundId = refundId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// The ID of the refund associated with this activity.
        /// </summary>
        [JsonProperty("refund_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityRefundDetail : ({string.Join(", ", toStringOutput)})";
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
            private string paymentId;
            private string refundId;

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
             /// RefundId.
             /// </summary>
             /// <param name="refundId"> refundId. </param>
             /// <returns> Builder. </returns>
            public Builder RefundId(string refundId)
            {
                this.refundId = refundId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityRefundDetail. </returns>
            public PaymentBalanceActivityRefundDetail Build()
            {
                return new PaymentBalanceActivityRefundDetail(
                    this.paymentId,
                    this.refundId);
            }
        }
    }
}