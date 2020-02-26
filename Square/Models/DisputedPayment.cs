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
    public class DisputedPayment 
    {
        public DisputedPayment(string paymentId = null)
        {
            PaymentId = paymentId;
        }

        /// <summary>
        /// Square-generated unique ID of the payment being disputed.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(PaymentId);
            return builder;
        }

        public class Builder
        {
            private string paymentId;

            public Builder() { }
            public Builder PaymentId(string value)
            {
                paymentId = value;
                return this;
            }

            public DisputedPayment Build()
            {
                return new DisputedPayment(paymentId);
            }
        }
    }
}