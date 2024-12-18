using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CreateCheckoutResponse.
    /// </summary>
    public class CreateCheckoutResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCheckoutResponse"/> class.
        /// </summary>
        /// <param name="checkout">checkout.</param>
        /// <param name="errors">errors.</param>
        public CreateCheckoutResponse(
            Models.Checkout checkout = null,
            IList<Models.Error> errors = null)
        {
            this.Checkout = checkout;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateCheckoutResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CreateCheckoutResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Checkout == null && other.Checkout == null ||
                 this.Checkout?.Equals(other.Checkout) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2102268765;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Checkout, this.Errors);

            return hashCode;
        }

        internal CreateCheckoutResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Checkout = {(this.Checkout == null ? "null" : this.Checkout.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Checkout(this.Checkout)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Checkout checkout;
            private IList<Models.Error> errors;

             /// <summary>
             /// Checkout.
             /// </summary>
             /// <param name="checkout"> checkout. </param>
             /// <returns> Builder. </returns>
            public Builder Checkout(Models.Checkout checkout)
            {
                this.checkout = checkout;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateCheckoutResponse. </returns>
            public CreateCheckoutResponse Build()
            {
                return new CreateCheckoutResponse(
                    this.checkout,
                    this.errors);
            }
        }
    }
}