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
    /// BulkRetrieveCustomersResponse.
    /// </summary>
    public class BulkRetrieveCustomersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkRetrieveCustomersResponse"/> class.
        /// </summary>
        /// <param name="responses">responses.</param>
        /// <param name="errors">errors.</param>
        public BulkRetrieveCustomersResponse(
            IDictionary<string, Models.RetrieveCustomerResponse> responses = null,
            IList<Models.Error> errors = null)
        {
            this.Responses = responses;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A map of responses that correspond to individual retrieve requests, represented by
        /// key-value pairs.
        /// Each key is the customer ID that was specified for a retrieve request and each value
        /// is the corresponding response.
        /// If the request succeeds, the value is the requested customer profile.
        /// If the request fails, the value contains any errors that occurred during the request.
        /// </summary>
        [JsonProperty("responses", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.RetrieveCustomerResponse> Responses { get; }

        /// <summary>
        /// Any top-level errors that prevented the bulk operation from running.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkRetrieveCustomersResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkRetrieveCustomersResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Responses == null && other.Responses == null ||
                 this.Responses?.Equals(other.Responses) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -624365229;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Responses, this.Errors);

            return hashCode;
        }

        internal BulkRetrieveCustomersResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"Responses = {(this.Responses == null ? "null" : this.Responses.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Responses(this.Responses)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.RetrieveCustomerResponse> responses;
            private IList<Models.Error> errors;

             /// <summary>
             /// Responses.
             /// </summary>
             /// <param name="responses"> responses. </param>
             /// <returns> Builder. </returns>
            public Builder Responses(IDictionary<string, Models.RetrieveCustomerResponse> responses)
            {
                this.responses = responses;
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
            /// <returns> BulkRetrieveCustomersResponse. </returns>
            public BulkRetrieveCustomersResponse Build()
            {
                return new BulkRetrieveCustomersResponse(
                    this.responses,
                    this.errors);
            }
        }
    }
}