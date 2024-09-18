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
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CreateOrderCustomAttributeDefinitionRequest.
    /// </summary>
    public class CreateOrderCustomAttributeDefinitionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCustomAttributeDefinitionRequest"/> class.
        /// </summary>
        /// <param name="customAttributeDefinition">custom_attribute_definition.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateOrderCustomAttributeDefinitionRequest(
            Models.CustomAttributeDefinition customAttributeDefinition,
            string idempotencyKey = null)
        {
            this.CustomAttributeDefinition = customAttributeDefinition;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Represents a definition for custom attribute values. A custom attribute definition
        /// specifies the key, visibility, schema, and other properties for a custom attribute.
        /// </summary>
        [JsonProperty("custom_attribute_definition")]
        public Models.CustomAttributeDefinition CustomAttributeDefinition { get; }

        /// <summary>
        /// A unique identifier for this request, used to ensure idempotency.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateOrderCustomAttributeDefinitionRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateOrderCustomAttributeDefinitionRequest other &&                ((this.CustomAttributeDefinition == null && other.CustomAttributeDefinition == null) || (this.CustomAttributeDefinition?.Equals(other.CustomAttributeDefinition) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1027175361;
            hashCode = HashCode.Combine(this.CustomAttributeDefinition, this.IdempotencyKey);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomAttributeDefinition = {(this.CustomAttributeDefinition == null ? "null" : this.CustomAttributeDefinition.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CustomAttributeDefinition)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomAttributeDefinition customAttributeDefinition;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CreateOrderCustomAttributeDefinitionRequest.
            /// </summary>
            /// <param name="customAttributeDefinition"> customAttributeDefinition. </param>
            public Builder(
                Models.CustomAttributeDefinition customAttributeDefinition)
            {
                this.customAttributeDefinition = customAttributeDefinition;
            }

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
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateOrderCustomAttributeDefinitionRequest. </returns>
            public CreateOrderCustomAttributeDefinitionRequest Build()
            {
                return new CreateOrderCustomAttributeDefinitionRequest(
                    this.customAttributeDefinition,
                    this.idempotencyKey);
            }
        }
    }
}