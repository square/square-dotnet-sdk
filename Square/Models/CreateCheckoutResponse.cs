
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
        [JsonProperty("checkout", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Checkout Checkout { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCheckoutResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Checkout = {(Checkout == null ? "null" : Checkout.ToString())}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is CreateCheckoutResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Checkout == null && other.Checkout == null) || (Checkout?.Equals(other.Checkout) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -2102268765;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Checkout != null)
            {
               hashCode += Checkout.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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
            private IList<Models.Error> errors;



            public Builder Checkout(Models.Checkout checkout)
            {
                this.checkout = checkout;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
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