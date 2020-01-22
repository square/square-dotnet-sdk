using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class RefundPaymentResponse 
    {
        public RefundPaymentResponse(IList<Models.Error> errors = null,
            Models.PaymentRefund refund = null)
        {
            Errors = errors;
            Refund = refund;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a refund of a payment made using Square. Contains information on
        /// the original payment and the amount of money refunded.
        /// </summary>
        [JsonProperty("refund")]
        public Models.PaymentRefund Refund { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Refund(Refund);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.PaymentRefund refund;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Refund(Models.PaymentRefund value)
            {
                refund = value;
                return this;
            }

            public RefundPaymentResponse Build()
            {
                return new RefundPaymentResponse(errors,
                    refund);
            }
        }
    }
}