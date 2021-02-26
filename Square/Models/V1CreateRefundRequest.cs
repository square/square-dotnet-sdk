
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1CreateRefundRequest 
    {
        public V1CreateRefundRequest(string paymentId,
            string type,
            string reason,
            Models.V1Money refundedMoney = null,
            string requestIdempotenceKey = null)
        {
            PaymentId = paymentId;
            Type = type;
            Reason = reason;
            RefundedMoney = refundedMoney;
            RequestIdempotenceKey = requestIdempotenceKey;
        }

        /// <summary>
        /// The ID of the payment to refund. If you are creating a `PARTIAL`
        /// refund for a split tender payment, instead provide the id of the
        /// particular tender you want to refund.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        /// Getter for refunded_money
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// An optional key to ensure idempotence if you issue the same PARTIAL refund request more than once.
        /// </summary>
        [JsonProperty("request_idempotence_key", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestIdempotenceKey { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1CreateRefundRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"PaymentId = {(PaymentId == null ? "null" : PaymentId == string.Empty ? "" : PaymentId)}");
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type.ToString())}");
            toStringOutput.Add($"Reason = {(Reason == null ? "null" : Reason == string.Empty ? "" : Reason)}");
            toStringOutput.Add($"RefundedMoney = {(RefundedMoney == null ? "null" : RefundedMoney.ToString())}");
            toStringOutput.Add($"RequestIdempotenceKey = {(RequestIdempotenceKey == null ? "null" : RequestIdempotenceKey == string.Empty ? "" : RequestIdempotenceKey)}");
        }

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
                ((PaymentId == null && other.PaymentId == null) || (PaymentId?.Equals(other.PaymentId) == true)) &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((Reason == null && other.Reason == null) || (Reason?.Equals(other.Reason) == true)) &&
                ((RefundedMoney == null && other.RefundedMoney == null) || (RefundedMoney?.Equals(other.RefundedMoney) == true)) &&
                ((RequestIdempotenceKey == null && other.RequestIdempotenceKey == null) || (RequestIdempotenceKey?.Equals(other.RequestIdempotenceKey) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1278947048;

            if (PaymentId != null)
            {
               hashCode += PaymentId.GetHashCode();
            }

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (Reason != null)
            {
               hashCode += Reason.GetHashCode();
            }

            if (RefundedMoney != null)
            {
               hashCode += RefundedMoney.GetHashCode();
            }

            if (RequestIdempotenceKey != null)
            {
               hashCode += RequestIdempotenceKey.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(PaymentId,
                Type,
                Reason)
                .RefundedMoney(RefundedMoney)
                .RequestIdempotenceKey(RequestIdempotenceKey);
            return builder;
        }

        public class Builder
        {
            private string paymentId;
            private string type;
            private string reason;
            private Models.V1Money refundedMoney;
            private string requestIdempotenceKey;

            public Builder(string paymentId,
                string type,
                string reason)
            {
                this.paymentId = paymentId;
                this.type = type;
                this.reason = reason;
            }

            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            public Builder RefundedMoney(Models.V1Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

            public Builder RequestIdempotenceKey(string requestIdempotenceKey)
            {
                this.requestIdempotenceKey = requestIdempotenceKey;
                return this;
            }

            public V1CreateRefundRequest Build()
            {
                return new V1CreateRefundRequest(paymentId,
                    type,
                    reason,
                    refundedMoney,
                    requestIdempotenceKey);
            }
        }
    }
}