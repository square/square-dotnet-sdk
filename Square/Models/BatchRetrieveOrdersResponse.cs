namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// BatchRetrieveOrdersResponse.
    /// </summary>
    public class BatchRetrieveOrdersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveOrdersResponse"/> class.
        /// </summary>
        /// <param name="orders">orders.</param>
        /// <param name="errors">errors.</param>
        public BatchRetrieveOrdersResponse(
            IList<Models.Order> orders = null,
            IList<Models.Error> errors = null)
        {
            this.Orders = orders;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The requested orders. This will omit any requested orders that do not exist.
        /// </summary>
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Order> Orders { get; }

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

            return $"BatchRetrieveOrdersResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BatchRetrieveOrdersResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Orders == null && other.Orders == null) || (this.Orders?.Equals(other.Orders) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1621858028;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Orders != null)
            {
               hashCode += this.Orders.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Orders = {(this.Orders == null ? "null" : $"[{string.Join(", ", this.Orders)} ]")}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Orders(this.Orders)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Order> orders;
            private IList<Models.Error> errors;

             /// <summary>
             /// Orders.
             /// </summary>
             /// <param name="orders"> orders. </param>
             /// <returns> Builder. </returns>
            public Builder Orders(IList<Models.Order> orders)
            {
                this.orders = orders;
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
            /// <returns> BatchRetrieveOrdersResponse. </returns>
            public BatchRetrieveOrdersResponse Build()
            {
                return new BatchRetrieveOrdersResponse(
                    this.orders,
                    this.errors);
            }
        }
    }
}