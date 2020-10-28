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
    public class GetTerminalCheckoutResponse 
    {
        public GetTerminalCheckoutResponse(IList<Models.Error> errors = null,
            Models.TerminalCheckout checkout = null)
        {
            Errors = errors;
            Checkout = checkout;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for checkout
        /// </summary>
        [JsonProperty("checkout", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckout Checkout { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Checkout(Checkout);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.TerminalCheckout checkout;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Checkout(Models.TerminalCheckout checkout)
            {
                this.checkout = checkout;
                return this;
            }

            public GetTerminalCheckoutResponse Build()
            {
                return new GetTerminalCheckoutResponse(errors,
                    checkout);
            }
        }
    }
}