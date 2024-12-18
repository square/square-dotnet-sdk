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
    /// BulkDeleteLocationCustomAttributesResponse.
    /// </summary>
    public class BulkDeleteLocationCustomAttributesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteLocationCustomAttributesResponse"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        /// <param name="errors">errors.</param>
        public BulkDeleteLocationCustomAttributesResponse(
            IDictionary<string, Models.BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse> values,
            IList<Models.Error> errors = null)
        {
            this.Values = values;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A map of responses that correspond to individual delete requests. Each response has the
        /// same key as the corresponding request.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<string, Models.BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse> Values { get; }

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
            return $"BulkDeleteLocationCustomAttributesResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkDeleteLocationCustomAttributesResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Values == null && other.Values == null ||
                 this.Values?.Equals(other.Values) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 851735464;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Values, this.Errors);

            return hashCode;
        }

        internal BulkDeleteLocationCustomAttributesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"Values = {(this.Values == null ? "null" : this.Values.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Values)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse> values;
            private IList<Models.Error> errors;

            /// <summary>
            /// Initialize Builder for BulkDeleteLocationCustomAttributesResponse.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(
                IDictionary<string, Models.BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse> values)
            {
                this.values = values;
            }

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IDictionary<string, Models.BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse> values)
            {
                this.values = values;
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
            /// <returns> BulkDeleteLocationCustomAttributesResponse. </returns>
            public BulkDeleteLocationCustomAttributesResponse Build()
            {
                return new BulkDeleteLocationCustomAttributesResponse(
                    this.values,
                    this.errors);
            }
        }
    }
}