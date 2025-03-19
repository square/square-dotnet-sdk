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
    /// BulkDeleteMerchantCustomAttributesResponse.
    /// </summary>
    public class BulkDeleteMerchantCustomAttributesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteMerchantCustomAttributesResponse"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        /// <param name="errors">errors.</param>
        public BulkDeleteMerchantCustomAttributesResponse(
            IDictionary<
                string,
                Models.BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
            > values,
            IList<Models.Error> errors = null
        )
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
        public IDictionary<
            string,
            Models.BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
        > Values { get; }

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
            return $"BulkDeleteMerchantCustomAttributesResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkDeleteMerchantCustomAttributesResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Values == null && other.Values == null
                    || this.Values?.Equals(other.Values) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1928958579;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Values, this.Errors);

            return hashCode;
        }

        internal BulkDeleteMerchantCustomAttributesResponse ContextSetter(HttpContext context)
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
                $"Values = {(this.Values == null ? "null" : this.Values.ToString())}"
            );
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
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
            private IDictionary<
                string,
                Models.BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
            > values;
            private IList<Models.Error> errors;

            /// <summary>
            /// Initialize Builder for BulkDeleteMerchantCustomAttributesResponse.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(
                IDictionary<
                    string,
                    Models.BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
                > values
            )
            {
                this.values = values;
            }

            /// <summary>
            /// Values.
            /// </summary>
            /// <param name="values"> values. </param>
            /// <returns> Builder. </returns>
            public Builder Values(
                IDictionary<
                    string,
                    Models.BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse
                > values
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
            /// <returns> BulkDeleteMerchantCustomAttributesResponse. </returns>
            public BulkDeleteMerchantCustomAttributesResponse Build()
            {
                return new BulkDeleteMerchantCustomAttributesResponse(this.values, this.errors);
            }
        }
    }
}
