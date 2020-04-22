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
    public class CreateTerminalCheckoutResponse 
    {
        public CreateTerminalCheckoutResponse(IList<Models.Error> errors = null,
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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for checkout
        /// </summary>
        [JsonProperty("checkout")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.TerminalCheckout checkout;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Checkout(Models.TerminalCheckout value)
            {
                checkout = value;
                return this;
            }

            public CreateTerminalCheckoutResponse Build()
            {
                return new CreateTerminalCheckoutResponse(errors,
                    checkout);
            }
        }
    }
}