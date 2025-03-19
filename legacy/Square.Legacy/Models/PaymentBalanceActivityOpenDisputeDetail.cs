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
    /// PaymentBalanceActivityOpenDisputeDetail.
    /// </summary>
    public class PaymentBalanceActivityOpenDisputeDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivityOpenDisputeDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="disputeId">dispute_id.</param>
        public PaymentBalanceActivityOpenDisputeDetail(
            string paymentId = null,
            string disputeId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "dispute_id", false },
            };

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (disputeId != null)
            {
                shouldSerialize["dispute_id"] = true;
                this.DisputeId = disputeId;
            }
        }

        internal PaymentBalanceActivityOpenDisputeDetail(
            Dictionary<string, bool> shouldSerialize,
            string paymentId = null,
            string disputeId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            PaymentId = paymentId;
            DisputeId = disputeId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The ID of the dispute associated with this activity.
        /// </summary>
        [JsonProperty("dispute_id")]
        public string DisputeId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PaymentBalanceActivityOpenDisputeDetail : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeDisputeId()
        {
            return this.shouldSerialize["dispute_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is PaymentBalanceActivityOpenDisputeDetail other
                && (
                    this.PaymentId == null && other.PaymentId == null
                    || this.PaymentId?.Equals(other.PaymentId) == true
                )
                && (
                    this.DisputeId == null && other.DisputeId == null
                    || this.DisputeId?.Equals(other.DisputeId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1315062164;
            hashCode = HashCode.Combine(hashCode, this.PaymentId, this.DisputeId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {this.PaymentId ?? "null"}");
            toStringOutput.Add($"this.DisputeId = {this.DisputeId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().PaymentId(this.PaymentId).DisputeId(this.DisputeId);
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
                { "dispute_id", false },
            };

            private string paymentId;
            private string disputeId;

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
            /// DisputeId.
            /// </summary>
            /// <param name="disputeId"> disputeId. </param>
            /// <returns> Builder. </returns>
            public Builder DisputeId(string disputeId)
            {
                shouldSerialize["dispute_id"] = true;
                this.disputeId = disputeId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDisputeId()
            {
                this.shouldSerialize["dispute_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivityOpenDisputeDetail. </returns>
            public PaymentBalanceActivityOpenDisputeDetail Build()
            {
                return new PaymentBalanceActivityOpenDisputeDetail(
                    shouldSerialize,
                    this.paymentId,
                    this.disputeId
                );
            }
        }
    }
}
