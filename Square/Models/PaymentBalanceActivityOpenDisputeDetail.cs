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
    /// PaymentBalanceActivityOpenDisputeDetail.
    /// </summary>
    public class PaymentBalanceActivityOpenDisputeDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityOpenDisputeDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="disputeId">dispute_id.</param>
        public PaymentBalanceActivityOpenDisputeDetail(
            string paymentId = null,
            string disputeId = null)
        {
            this.PaymentId = paymentId;
            this.DisputeId = disputeId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// The ID of the dispute associated with this activity.
        /// </summary>
        [JsonProperty("dispute_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DisputeId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityOpenDisputeDetail : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaymentBalanceActivityOpenDisputeDetail other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.DisputeId == null && other.DisputeId == null) || (this.DisputeId?.Equals(other.DisputeId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1315062164;
            hashCode = HashCode.Combine(this.PaymentId, this.DisputeId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.DisputeId = {(this.DisputeId == null ? "null" : this.DisputeId == string.Empty ? "" : this.DisputeId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(this.PaymentId)
                .DisputeId(this.DisputeId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string paymentId;
            private string disputeId;

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
             /// DisputeId.
             /// </summary>
             /// <param name="disputeId"> disputeId. </param>
             /// <returns> Builder. </returns>
            public Builder DisputeId(string disputeId)
            {
                this.disputeId = disputeId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityOpenDisputeDetail. </returns>
            public PaymentBalanceActivityOpenDisputeDetail Build()
            {
                return new PaymentBalanceActivityOpenDisputeDetail(
                    this.paymentId,
                    this.disputeId);
            }
        }
    }
}