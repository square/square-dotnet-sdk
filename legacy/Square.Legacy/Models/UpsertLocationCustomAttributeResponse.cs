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
    /// UpsertLocationCustomAttributeResponse.
    /// </summary>
    public class UpsertLocationCustomAttributeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertLocationCustomAttributeResponse"/> class.
        /// </summary>
        /// <param name="customAttribute">custom_attribute.</param>
        /// <param name="errors">errors.</param>
        public UpsertLocationCustomAttributeResponse(
            Models.CustomAttribute customAttribute = null,
            IList<Models.Error> errors = null
        )
        {
            this.CustomAttribute = customAttribute;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A custom attribute value. Each custom attribute value has a corresponding
        /// `CustomAttributeDefinition` object.
        /// </summary>
        [JsonProperty("custom_attribute", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomAttribute CustomAttribute { get; }

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
            return $"UpsertLocationCustomAttributeResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpsertLocationCustomAttributeResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.CustomAttribute == null && other.CustomAttribute == null
                    || this.CustomAttribute?.Equals(other.CustomAttribute) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1916863375;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.CustomAttribute, this.Errors);

            return hashCode;
        }

        internal UpsertLocationCustomAttributeResponse ContextSetter(HttpContext context)
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
                $"this.CustomAttribute = {(this.CustomAttribute == null ? "null" : this.CustomAttribute.ToString())}"
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
            var builder = new Builder().CustomAttribute(this.CustomAttribute).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomAttribute customAttribute;
            private IList<Models.Error> errors;

            /// <summary>
            /// CustomAttribute.
            /// </summary>
            /// <param name="customAttribute"> customAttribute. </param>
            /// <returns> Builder. </returns>
            public Builder CustomAttribute(Models.CustomAttribute customAttribute)
            {
                this.customAttribute = customAttribute;
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
            /// <returns> UpsertLocationCustomAttributeResponse. </returns>
            public UpsertLocationCustomAttributeResponse Build()
            {
                return new UpsertLocationCustomAttributeResponse(this.customAttribute, this.errors);
            }
        }
    }
}
