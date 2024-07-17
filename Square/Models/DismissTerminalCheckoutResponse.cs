namespace Square.Models
{
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

    /// <summary>
    /// DismissTerminalCheckoutResponse.
    /// </summary>
    public class DismissTerminalCheckoutResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DismissTerminalCheckoutResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="checkout">checkout.</param>
        public DismissTerminalCheckoutResponse(
            IList<Models.Error> errors = null,
            Models.TerminalCheckout checkout = null)
        {
            this.Errors = errors;
            this.Checkout = checkout;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a checkout processed by the Square Terminal.
        /// </summary>
        [JsonProperty("checkout", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckout Checkout { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DismissTerminalCheckoutResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is DismissTerminalCheckoutResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Checkout == null && other.Checkout == null) || (this.Checkout?.Equals(other.Checkout) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1550979533;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Checkout);

            return hashCode;
        }
        internal DismissTerminalCheckoutResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Checkout = {(this.Checkout == null ? "null" : this.Checkout.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Checkout(this.Checkout);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.TerminalCheckout checkout;

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
             /// Checkout.
             /// </summary>
             /// <param name="checkout"> checkout. </param>
             /// <returns> Builder. </returns>
            public Builder Checkout(Models.TerminalCheckout checkout)
            {
                this.checkout = checkout;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DismissTerminalCheckoutResponse. </returns>
            public DismissTerminalCheckoutResponse Build()
            {
                return new DismissTerminalCheckoutResponse(
                    this.errors,
                    this.checkout);
            }
        }
    }
}