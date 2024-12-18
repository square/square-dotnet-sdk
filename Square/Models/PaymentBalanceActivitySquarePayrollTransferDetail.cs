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
    /// PaymentBalanceActivitySquarePayrollTransferDetail.
    /// </summary>
    public class PaymentBalanceActivitySquarePayrollTransferDetail
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBalanceActivitySquarePayrollTransferDetail"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        public PaymentBalanceActivitySquarePayrollTransferDetail(
            string paymentId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false }
            };

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }
        }

        internal PaymentBalanceActivitySquarePayrollTransferDetail(
            Dictionary<string, bool> shouldSerialize,
            string paymentId = null)
        {
            this.shouldSerialize = shouldSerialize;
            PaymentId = paymentId;
        }

        /// <summary>
        /// The ID of the payment associated with this activity.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PaymentBalanceActivitySquarePayrollTransferDetail : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PaymentBalanceActivitySquarePayrollTransferDetail other &&
                (this.PaymentId == null && other.PaymentId == null ||
                 this.PaymentId?.Equals(other.PaymentId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -403392114;
            hashCode = HashCode.Combine(hashCode, this.PaymentId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {this.PaymentId ?? "null"}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
            };

            private string paymentId;

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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentBalanceActivitySquarePayrollTransferDetail. </returns>
            public PaymentBalanceActivitySquarePayrollTransferDetail Build()
            {
                return new PaymentBalanceActivitySquarePayrollTransferDetail(
                    shouldSerialize,
                    this.paymentId);
            }
        }
    }
}