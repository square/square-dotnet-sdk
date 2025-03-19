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
    /// BulkUpsertLocationCustomAttributesResponse.
    /// </summary>
    public class BulkUpsertLocationCustomAttributesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertLocationCustomAttributesResponse"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        /// <param name="errors">errors.</param>
        public BulkUpsertLocationCustomAttributesResponse(
            IDictionary<
                string,
                Models.BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse
            > values = null,
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
        /// A map of responses that correspond to individual upsert requests. Each response has the
        /// same ID as the corresponding request and contains either a `location_id` and `custom_attribute` or an `errors` field.
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<
            string,
            Models.BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse
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
            return $"BulkUpsertLocationCustomAttributesResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkUpsertLocationCustomAttributesResponse other
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
            var hashCode = 756289060;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Values, this.Errors);

            return hashCode;
        }

        internal BulkUpsertLocationCustomAttributesResponse ContextSetter(HttpContext context)
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
            var builder = new Builder().Values(this.Values).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<
                string,
                Models.BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse
            > values;
            private IList<Models.Error> errors;

            /// <summary>
            /// Values.
            /// </summary>
            /// <param name="values"> values. </param>
            /// <returns> Builder. </returns>
            public Builder Values(
                IDictionary<
                    string,
                    Models.BulkUpsertLocationCustomAttributesResponseLocationCustomAttributeUpsertResponse
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
            /// <returns> BulkUpsertLocationCustomAttributesResponse. </returns>
            public BulkUpsertLocationCustomAttributesResponse Build()
            {
                return new BulkUpsertLocationCustomAttributesResponse(this.values, this.errors);
            }
        }
    }
}
