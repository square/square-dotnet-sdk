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
    /// PaymentBalanceActivityDepositFeeDetail.
    /// </summary>
    public class PaymentBalanceActivityDepositFeeDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityDepositFeeDetail"/> class.
        /// </summary>
        /// <param name="payoutId">payout_id.</param>
        public PaymentBalanceActivityDepositFeeDetail(
            string payoutId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payout_id", false }
            };

            if (payoutId != null)
            {
                shouldSerialize["payout_id"] = true;
                this.PayoutId = payoutId;
            }

        }
        internal PaymentBalanceActivityDepositFeeDetail(Dictionary<string, bool> shouldSerialize,
            string payoutId = null)
        {
            this.shouldSerialize = shouldSerialize;
            PayoutId = payoutId;
        }

        /// <summary>
        /// The ID of the payout that triggered this deposit fee activity.
        /// </summary>
        [JsonProperty("payout_id")]
        public string PayoutId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentBalanceActivityDepositFeeDetail : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaymentBalanceActivityDepositFeeDetail other &&
                ((this.PayoutId == null && other.PayoutId == null) || (this.PayoutId?.Equals(other.PayoutId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1761126555;
            hashCode = HashCode.Combine(this.PayoutId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PayoutId = {(this.PayoutId == null ? "null" : this.PayoutId == string.Empty ? "" : this.PayoutId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
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
                { "payout_id", false },
            };

            private string payoutId;

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
            public void UnsetPayoutId()
            {
                this.shouldSerialize["payout_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityDepositFeeDetail. </returns>
            public PaymentBalanceActivityDepositFeeDetail Build()
            {
                return new PaymentBalanceActivityDepositFeeDetail(shouldSerialize,
                    this.payoutId);
            }
        }
    }
}