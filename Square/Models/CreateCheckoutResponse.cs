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
    public class CreateCheckoutResponse 
    {
        public CreateCheckoutResponse(Models.Checkout checkout = null,
            IList<Models.Error> errors = null)
        {
            Checkout = checkout;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Square Checkout lets merchants accept online payments for supported
        /// payment types using a checkout workflow hosted on squareup.com.
        /// </summary>
        [JsonProperty("checkout")]
        public Models.Checkout Checkout { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Checkout(Checkout)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.Checkout checkout;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Checkout(Models.Checkout value)
            {
                checkout = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public CreateCheckoutResponse Build()
            {
                return new CreateCheckoutResponse(checkout,
                    errors);
            }
        }
    }
}