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
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// UpdateOrderCustomAttributeDefinitionRequest.
    /// </summary>
    public class UpdateOrderCustomAttributeDefinitionRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCustomAttributeDefinitionRequest"/> class.
        /// </summary>
        /// <param name="customAttributeDefinition">custom_attribute_definition.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public UpdateOrderCustomAttributeDefinitionRequest(
            Models.CustomAttributeDefinition customAttributeDefinition,
            string idempotencyKey = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "idempotency_key", false } };
            this.CustomAttributeDefinition = customAttributeDefinition;

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }
        }

        internal UpdateOrderCustomAttributeDefinitionRequest(
            Dictionary<string, bool> shouldSerialize,
            Models.CustomAttributeDefinition customAttributeDefinition,
            string idempotencyKey = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            CustomAttributeDefinition = customAttributeDefinition;
            IdempotencyKey = idempotencyKey;
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
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateOrderCustomAttributeDefinitionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIdempotencyKey()
        {
            return this.shouldSerialize["idempotency_key"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpdateOrderCustomAttributeDefinitionRequest other
                && (
                    this.CustomAttributeDefinition == null
                        && other.CustomAttributeDefinition == null
                    || this.CustomAttributeDefinition?.Equals(other.CustomAttributeDefinition)
                        == true
                )
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 585420618;
            hashCode = HashCode.Combine(
                hashCode,
                this.CustomAttributeDefinition,
                this.IdempotencyKey
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.CustomAttributeDefinition = {(this.CustomAttributeDefinition == null ? "null" : this.CustomAttributeDefinition.ToString())}"
            );
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.CustomAttributeDefinition).IdempotencyKey(
                this.IdempotencyKey
            );
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false },
            };

            private Models.CustomAttributeDefinition customAttributeDefinition;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for UpdateOrderCustomAttributeDefinitionRequest.
            /// </summary>
            /// <param name="customAttributeDefinition"> customAttributeDefinition. </param>
            public Builder(Models.CustomAttributeDefinition customAttributeDefinition)
            {
                this.customAttributeDefinition = customAttributeDefinition;
            }

            /// <summary>
            /// CustomAttributeDefinition.
            /// </summary>
            /// <param name="customAttributeDefinition"> customAttributeDefinition. </param>
            /// <returns> Builder. </returns>
            public Builder CustomAttributeDefinition(
                Models.CustomAttributeDefinition customAttributeDefinition
            )
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
                shouldSerialize["idempotency_key"] = true;
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIdempotencyKey()
            {
                this.shouldSerialize["idempotency_key"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateOrderCustomAttributeDefinitionRequest. </returns>
            public UpdateOrderCustomAttributeDefinitionRequest Build()
            {
                return new UpdateOrderCustomAttributeDefinitionRequest(
                    shouldSerialize,
                    this.customAttributeDefinition,
                    this.idempotencyKey
                );
            }
        }
    }
}
