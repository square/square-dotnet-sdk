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
    /// CreateCustomerCustomAttributeDefinitionResponse.
    /// </summary>
    public class CreateCustomerCustomAttributeDefinitionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCustomAttributeDefinitionResponse"/> class.
        /// </summary>
        /// <param name="customAttributeDefinition">custom_attribute_definition.</param>
        /// <param name="errors">errors.</param>
        public CreateCustomerCustomAttributeDefinitionResponse(
            Models.CustomAttributeDefinition customAttributeDefinition = null,
            IList<Models.Error> errors = null)
        {
            this.CustomAttributeDefinition = customAttributeDefinition;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Represents a definition for custom attribute values. A custom attribute definition
        /// specifies the key, visibility, schema, and other properties for a custom attribute.
        /// </summary>
        [JsonProperty("custom_attribute_definition", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomAttributeDefinition CustomAttributeDefinition { get; }

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

            return $"CreateCustomerCustomAttributeDefinitionResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCustomerCustomAttributeDefinitionResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.CustomAttributeDefinition == null && other.CustomAttributeDefinition == null) || (this.CustomAttributeDefinition?.Equals(other.CustomAttributeDefinition) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -523035623;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.CustomAttributeDefinition, this.Errors);

            return hashCode;
        }
        internal CreateCustomerCustomAttributeDefinitionResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.CustomAttributeDefinition = {(this.CustomAttributeDefinition == null ? "null" : this.CustomAttributeDefinition.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomAttributeDefinition(this.CustomAttributeDefinition)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomAttributeDefinition customAttributeDefinition;
            private IList<Models.Error> errors;

             /// <summary>
             /// CustomAttributeDefinition.
             /// </summary>
             /// <param name="customAttributeDefinition"> customAttributeDefinition. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributeDefinition(Models.CustomAttributeDefinition customAttributeDefinition)
            {
                this.customAttributeDefinition = customAttributeDefinition;
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
            /// <returns> CreateCustomerCustomAttributeDefinitionResponse. </returns>
            public CreateCustomerCustomAttributeDefinitionResponse Build()
            {
                return new CreateCustomerCustomAttributeDefinitionResponse(
                    this.customAttributeDefinition,
                    this.errors);
            }
        }
    }
}