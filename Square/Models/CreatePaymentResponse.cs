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
    public class CreatePaymentResponse 
    {
        public CreatePaymentResponse(IList<Models.Error> errors = null,
            Models.Payment payment = null)
        {
            Errors = errors;
            Payment = payment;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a payment processed by the Square API.
        /// </summary>
        [JsonProperty("payment")]
        public Models.Payment Payment { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Payment(Payment);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.Payment payment;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Payment(Models.Payment value)
            {
                payment = value;
                return this;
            }

            public CreatePaymentResponse Build()
            {
                return new CreatePaymentResponse(errors,
                    payment);
            }
        }
    }
}