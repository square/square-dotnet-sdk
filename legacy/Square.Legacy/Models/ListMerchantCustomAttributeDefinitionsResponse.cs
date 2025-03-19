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
    /// ListMerchantCustomAttributeDefinitionsResponse.
    /// </summary>
    public class ListMerchantCustomAttributeDefinitionsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListMerchantCustomAttributeDefinitionsResponse"/> class.
        /// </summary>
        /// <param name="customAttributeDefinitions">custom_attribute_definitions.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListMerchantCustomAttributeDefinitionsResponse(
            IList<Models.CustomAttributeDefinition> customAttributeDefinitions = null,
            string cursor = null,
            IList<Models.Error> errors = null
        )
        {
            this.CustomAttributeDefinitions = customAttributeDefinitions;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The retrieved custom attribute definitions. If no custom attribute definitions are found,
        /// Square returns an empty object (`{}`).
        /// </summary>
        [JsonProperty("custom_attribute_definitions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomAttributeDefinition> CustomAttributeDefinitions { get; }

        /// <summary>
        /// The cursor to provide in your next call to this endpoint to retrieve the next page of
        /// results for your original request. This field is present only if the request succeeded and
        /// additional results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

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
            return $"ListMerchantCustomAttributeDefinitionsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListMerchantCustomAttributeDefinitionsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.CustomAttributeDefinitions == null
                        && other.CustomAttributeDefinitions == null
                    || this.CustomAttributeDefinitions?.Equals(other.CustomAttributeDefinitions)
                        == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1382853041;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(
                hashCode,
                this.CustomAttributeDefinitions,
                this.Cursor,
                this.Errors
            );

            return hashCode;
        }

        internal ListMerchantCustomAttributeDefinitionsResponse ContextSetter(HttpContext context)
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
                $"this.CustomAttributeDefinitions = {(this.CustomAttributeDefinitions == null ? "null" : $"[{string.Join(", ", this.CustomAttributeDefinitions)} ]")}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
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
            var builder = new Builder()
                .CustomAttributeDefinitions(this.CustomAttributeDefinitions)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.CustomAttributeDefinition> customAttributeDefinitions;
            private string cursor;
            private IList<Models.Error> errors;

            /// <summary>
            /// CustomAttributeDefinitions.
            /// </summary>
            /// <param name="customAttributeDefinitions"> customAttributeDefinitions. </param>
            /// <returns> Builder. </returns>
            public Builder CustomAttributeDefinitions(
                IList<Models.CustomAttributeDefinition> customAttributeDefinitions
            )
            {
                this.customAttributeDefinitions = customAttributeDefinitions;
                return this;
            }

            /// <summary>
            /// Cursor.
            /// </summary>
            /// <param name="cursor"> cursor. </param>
            /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
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
            /// <returns> ListMerchantCustomAttributeDefinitionsResponse. </returns>
            public ListMerchantCustomAttributeDefinitionsResponse Build()
            {
                return new ListMerchantCustomAttributeDefinitionsResponse(
                    this.customAttributeDefinitions,
                    this.cursor,
                    this.errors
                );
            }
        }
    }
}
