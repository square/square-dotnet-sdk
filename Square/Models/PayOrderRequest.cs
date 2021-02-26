
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
    public class PayOrderRequest 
    {
        public PayOrderRequest(string idempotencyKey,
            int? orderVersion = null,
            IList<string> paymentIds = null)
        {
            IdempotencyKey = idempotencyKey;
            OrderVersion = orderVersion;
            PaymentIds = paymentIds;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this request among requests you've sent. If
        /// you're unsure whether a particular payment request was completed successfully, you can reattempt
        /// it with the same idempotency key without worrying about duplicate payments.
        /// See [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The version of the order being paid. If not supplied, the latest version will be paid.
        /// </summary>
        [JsonProperty("order_version", NullValueHandling = NullValueHandling.Ignore)]
        public int? OrderVersion { get; }

        /// <summary>
        /// The IDs of the [payments](#type-payment) to collect.
        /// The payment total must match the order total.
        /// </summary>
        [JsonProperty("payment_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> PaymentIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PayOrderRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"OrderVersion = {(OrderVersion == null ? "null" : OrderVersion.ToString())}");
            toStringOutput.Add($"PaymentIds = {(PaymentIds == null ? "null" : $"[{ string.Join(", ", PaymentIds)} ]")}");
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

            return obj is PayOrderRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((OrderVersion == null && other.OrderVersion == null) || (OrderVersion?.Equals(other.OrderVersion) == true)) &&
                ((PaymentIds == null && other.PaymentIds == null) || (PaymentIds?.Equals(other.PaymentIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -320446863;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (OrderVersion != null)
            {
               hashCode += OrderVersion.GetHashCode();
            }

            if (PaymentIds != null)
            {
               hashCode += PaymentIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey)
                .OrderVersion(OrderVersion)
                .PaymentIds(PaymentIds);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private int? orderVersion;
            private IList<string> paymentIds;

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder OrderVersion(int? orderVersion)
            {
                this.orderVersion = orderVersion;
                return this;
            }

            public Builder PaymentIds(IList<string> paymentIds)
            {
                this.paymentIds = paymentIds;
                return this;
            }

            public PayOrderRequest Build()
            {
                return new PayOrderRequest(idempotencyKey,
                    orderVersion,
                    paymentIds);
            }
        }
    }
}