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
        [JsonProperty("refunded_money")]
        public Models.V1Money RefundedMoney { get; }

        /// <summary>
        /// An optional key to ensure idempotence if you issue the same PARTIAL refund request more than once.
        /// </summary>
        [JsonProperty("request_idempotence_key")]
        public string RequestIdempotenceKey { get; }

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
            public Builder PaymentId(string value)
            {
                paymentId = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Reason(string value)
            {
                reason = value;
                return this;
            }

            public Builder RefundedMoney(Models.V1Money value)
            {
                refundedMoney = value;
                return this;
            }

            public Builder RequestIdempotenceKey(string value)
            {
                requestIdempotenceKey = value;
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