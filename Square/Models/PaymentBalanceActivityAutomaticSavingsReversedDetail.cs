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
    /// PaymentBalanceActivityAutomaticSavingsReversedDetail.
    /// </summary>
    public class PaymentBalanceActivityAutomaticSavingsReversedDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityAutomaticSavingsReversedDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="payoutId">payout_id.</param>
        public PaymentBalanceActivityAutomaticSavingsReversedDetail(
            string paymentId = null,
            string payoutId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "payout_id", false }
            };

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (payoutId != null)
            {
                shouldSerialize["payout_id"] = true;
                this.PayoutId = payoutId;
            }

        }
        internal PaymentBalanceActivityAutomaticSavingsReversedDetail(Dictionary<string, bool> shouldSerialize,
            string paymentId = null,
            string payoutId = null)
        {
            this.shouldSerialize = shouldSerialize;
            PaymentId = paymentId;
            PayoutId = payoutId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The ID of the payout associated with this activity.
        /// </summary>
        [JsonProperty("payout_id")]
        public string PayoutId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityAutomaticSavingsReversedDetail : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializePayoutId()
        {
            return this.shouldSerialize["payout_id"];
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

            return obj is PaymentBalanceActivityAutomaticSavingsReversedDetail other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.PayoutId == null && other.PayoutId == null) || (this.PayoutId?.Equals(other.PayoutId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 65991116;
            hashCode = HashCode.Combine(this.PaymentId, this.PayoutId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.PayoutId = {(this.PayoutId == null ? "null" : this.PayoutId == string.Empty ? "" : this.PayoutId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(this.PaymentId)
                .PayoutId(this.PayoutId);
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
                { "payout_id", false },
            };

            private string paymentId;
            private string payoutId;

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
             /// PayoutId.
             /// </summary>
             /// <param name="payoutId"> payoutId. </param>
             /// <returns> Builder. </returns>
            public Builder PayoutId(string payoutId)
            {
                shouldSerialize["payout_id"] = true;
                this.payoutId = payoutId;
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
            public void UnsetPayoutId()
            {
                this.shouldSerialize["payout_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityAutomaticSavingsReversedDetail. </returns>
            public PaymentBalanceActivityAutomaticSavingsReversedDetail Build()
            {
                return new PaymentBalanceActivityAutomaticSavingsReversedDetail(shouldSerialize,
                    this.paymentId,
                    this.payoutId);
            }
        }
    }
}