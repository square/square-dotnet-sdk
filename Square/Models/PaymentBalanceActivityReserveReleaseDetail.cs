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
    /// PaymentBalanceActivityReserveReleaseDetail.
    /// </summary>
    public class PaymentBalanceActivityReserveReleaseDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityReserveReleaseDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        public PaymentBalanceActivityReserveReleaseDetail(
            string paymentId = null)
        {
            this.PaymentId = paymentId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityReserveReleaseDetail : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaymentBalanceActivityReserveReleaseDetail other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2142085744;
            hashCode = HashCode.Combine(this.PaymentId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(this.PaymentId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string paymentId;

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
            /// <returns> PaymentBalanceActivityReserveReleaseDetail. </returns>
            public PaymentBalanceActivityReserveReleaseDetail Build()
            {
                return new PaymentBalanceActivityReserveReleaseDetail(
                    this.paymentId);
            }
        }
    }
}