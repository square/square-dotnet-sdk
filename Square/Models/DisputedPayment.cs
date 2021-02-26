
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
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputedPayment : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"PaymentId = {(PaymentId == null ? "null" : PaymentId == string.Empty ? "" : PaymentId)}");
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

            return obj is DisputedPayment other &&
                ((PaymentId == null && other.PaymentId == null) || (PaymentId?.Equals(other.PaymentId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1880326021;

            if (PaymentId != null)
            {
               hashCode += PaymentId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PaymentId(PaymentId);
            return builder;
        }

        public class Builder
        {
            private string paymentId;



            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            public DisputedPayment Build()
            {
                return new DisputedPayment(paymentId);
            }
        }
    }
}