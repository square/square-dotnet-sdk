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
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// BulkDeleteOrderCustomAttributesResponse.
    /// </summary>
    public class BulkDeleteOrderCustomAttributesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteOrderCustomAttributesResponse"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        /// <param name="errors">errors.</param>
        public BulkDeleteOrderCustomAttributesResponse(
            IDictionary<string, Models.DeleteOrderCustomAttributeResponse> values,
            IList<Models.Error> errors = null
        )
        {
            this.Errors = errors;
            this.Values = values;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// A map of responses that correspond to individual delete requests. Each response has the same ID
        /// as the corresponding request and contains either a `custom_attribute` or an `errors` field.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<string, Models.DeleteOrderCustomAttributeResponse> Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkDeleteOrderCustomAttributesResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkDeleteOrderCustomAttributesResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Values == null && other.Values == null
                    || this.Values?.Equals(other.Values) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 391071317;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Values);

            return hashCode;
        }

        internal BulkDeleteOrderCustomAttributesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"Values = {(this.Values == null ? "null" : this.Values.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Values).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.DeleteOrderCustomAttributeResponse> values;
            private IList<Models.Error> errors;

            /// <summary>
            /// Initialize Builder for BulkDeleteOrderCustomAttributesResponse.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(IDictionary<string, Models.DeleteOrderCustomAttributeResponse> values)
            {
                this.values = values;
            }

            /// <summary>
            /// Values.
            /// </summary>
            /// <param name="values"> values. </param>
            /// <returns> Builder. </returns>
            public Builder Values(
                IDictionary<string, Models.DeleteOrderCustomAttributeResponse> values
            )
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
            /// <returns> BulkDeleteOrderCustomAttributesResponse. </returns>
            public BulkDeleteOrderCustomAttributesResponse Build()
            {
                return new BulkDeleteOrderCustomAttributesResponse(this.values, this.errors);
            }
        }
    }
}
