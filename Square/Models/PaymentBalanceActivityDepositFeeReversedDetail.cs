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

namespace Square.Models
{
    /// <summary>
    /// PaymentBalanceActivityDepositFeeReversedDetail.
    /// </summary>
    public class PaymentBalanceActivityDepositFeeReversedDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityDepositFeeReversedDetail"/> class.
        /// </summary>
        /// <param name="payoutId">payout_id.</param>
        public PaymentBalanceActivityDepositFeeReversedDetail(
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

        internal PaymentBalanceActivityDepositFeeReversedDetail(
            Dictionary<string, bool> shouldSerialize,
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
            return $"PaymentBalanceActivityDepositFeeReversedDetail : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PaymentBalanceActivityDepositFeeReversedDetail other &&
                (this.PayoutId == null && other.PayoutId == null ||
                 this.PayoutId?.Equals(other.PayoutId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 237579341;
            hashCode = HashCode.Combine(hashCode, this.PayoutId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PayoutId = {this.PayoutId ?? "null"}");
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPayoutId()
            {
                this.shouldSerialize["payout_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityDepositFeeReversedDetail. </returns>
            public PaymentBalanceActivityDepositFeeReversedDetail Build()
            {
                return new PaymentBalanceActivityDepositFeeReversedDetail(
                    shouldSerialize,
                    this.payoutId);
            }
        }
    }
}