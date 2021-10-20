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
    /// V1CreateRefundRequest.
    /// </summary>
    public class V1CreateRefundRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1CreateRefundRequest"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="type">type.</param>
        /// <param name="reason">reason.</param>
        /// <param name="refundedMoney">refunded_money.</param>
        /// <param name="requestIdempotenceKey">request_idempotence_key.</param>
        public V1CreateRefundRequest(
            string paymentId,
            string type,
            string reason,
            Models.V1Money refundedMoney = null,
            string requestIdempotenceKey = null)
        {
            this.PaymentId = paymentId;
            this.Type = type;
            this.Reason = reason;
            this.RefundedMoney = refundedMoney;
            this.RequestIdempotenceKey = requestIdempotenceKey;
        }

        /// <summary>
        /// The ID of the payment to refund. If you are creating a `PARTIAL`
        /// refund for a split tender payment, instead provide the id of the
        /// particular tender you want to refund.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        /// Gets or sets RefundedMoney.
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// An optional key to ensure idempotence if you issue the same PARTIAL refund request more than once.
        /// </summary>
        [JsonProperty("request_idempotence_key", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestIdempotenceKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1CreateRefundRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1CreateRefundRequest other &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.RefundedMoney == null && other.RefundedMoney == null) || (this.RefundedMoney?.Equals(other.RefundedMoney) == true)) &&
                ((this.RequestIdempotenceKey == null && other.RequestIdempotenceKey == null) || (this.RequestIdempotenceKey?.Equals(other.RequestIdempotenceKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1278947048;
            hashCode = HashCode.Combine(this.PaymentId, this.Type, this.Reason, this.RefundedMoney, this.RequestIdempotenceKey);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason == string.Empty ? "" : this.Reason)}");
            toStringOutput.Add($"this.RefundedMoney = {(this.RefundedMoney == null ? "null" : this.RefundedMoney.ToString())}");
            toStringOutput.Add($"this.RequestIdempotenceKey = {(this.RequestIdempotenceKey == null ? "null" : this.RequestIdempotenceKey == string.Empty ? "" : this.RequestIdempotenceKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PaymentId,
                this.Type,
                this.Reason)
                .RefundedMoney(this.RefundedMoney)
                .RequestIdempotenceKey(this.RequestIdempotenceKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string paymentId;
            private string type;
            private string reason;
            private Models.V1Money refundedMoney;
            private string requestIdempotenceKey;

            public Builder(
                string paymentId,
                string type,
                string reason)
            {
                this.paymentId = paymentId;
                this.type = type;
                this.reason = reason;
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
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

             /// <summary>
             /// RefundedMoney.
             /// </summary>
             /// <param name="refundedMoney"> refundedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedMoney(Models.V1Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

             /// <summary>
             /// RequestIdempotenceKey.
             /// </summary>
             /// <param name="requestIdempotenceKey"> requestIdempotenceKey. </param>
             /// <returns> Builder. </returns>
            public Builder RequestIdempotenceKey(string requestIdempotenceKey)
            {
                this.requestIdempotenceKey = requestIdempotenceKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1CreateRefundRequest. </returns>
            public V1CreateRefundRequest Build()
            {
                return new V1CreateRefundRequest(
                    this.paymentId,
                    this.type,
                    this.reason,
                    this.refundedMoney,
                    this.requestIdempotenceKey);
            }
        }
    }
}