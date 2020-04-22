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
        [JsonProperty("order_version")]
        public int? OrderVersion { get; }

        /// <summary>
        /// The IDs of the [payments](#type-payment) to collect.
        /// The payment total must match the order total.
        /// </summary>
        [JsonProperty("payment_ids")]
        public IList<string> PaymentIds { get; }

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
            private IList<string> paymentIds = new List<string>();

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder OrderVersion(int? value)
            {
                orderVersion = value;
                return this;
            }

            public Builder PaymentIds(IList<string> value)
            {
                paymentIds = value;
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