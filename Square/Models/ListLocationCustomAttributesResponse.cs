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
    /// ListLocationCustomAttributesResponse.
    /// </summary>
    public class ListLocationCustomAttributesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListLocationCustomAttributesResponse"/> class.
        /// </summary>
        /// <param name="customAttributes">custom_attributes.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListLocationCustomAttributesResponse(
            IList<Models.CustomAttribute> customAttributes = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.CustomAttributes = customAttributes;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The retrieved custom attributes. If `with_definitions` was set to `true` in the request,
        /// the custom attribute definition is returned in the `definition` field of each custom attribute.
        /// If no custom attributes are found, Square returns an empty object (`{}`).
        /// </summary>
        [JsonProperty("custom_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomAttribute> CustomAttributes { get; }

        /// <summary>
        /// The cursor to use in your next call to this endpoint to retrieve the next page of results
        /// for your original request. This field is present only if the request succeeded and additional
        /// results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
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

            return $"ListLocationCustomAttributesResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListLocationCustomAttributesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.CustomAttributes == null && other.CustomAttributes == null) || (this.CustomAttributes?.Equals(other.CustomAttributes) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -817984598;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.CustomAttributes, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListLocationCustomAttributesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.CustomAttributes = {(this.CustomAttributes == null ? "null" : $"[{string.Join(", ", this.CustomAttributes)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomAttributes(this.CustomAttributes)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.CustomAttribute> customAttributes;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// CustomAttributes.
             /// </summary>
             /// <param name="customAttributes"> customAttributes. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributes(IList<Models.CustomAttribute> customAttributes)
            {
                this.customAttributes = customAttributes;
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
            /// <returns> ListLocationCustomAttributesResponse. </returns>
            public ListLocationCustomAttributesResponse Build()
            {
                return new ListLocationCustomAttributesResponse(
                    this.customAttributes,
                    this.cursor,
                    this.errors);
            }
        }
    }
}