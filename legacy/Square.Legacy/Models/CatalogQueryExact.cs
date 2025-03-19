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
    /// CatalogQueryExact.
    /// </summary>
    public class CatalogQueryExact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryExact"/> class.
        /// </summary>
        /// <param name="attributeName">attribute_name.</param>
        /// <param name="attributeValue">attribute_value.</param>
        public CatalogQueryExact(string attributeName, string attributeValue)
        {
            this.AttributeName = attributeName;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// The name of the attribute to be searched. Matching of the attribute name is exact.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired value of the search attribute. Matching of the attribute value is case insensitive and can be partial.
        /// For example, if a specified value of "sma", objects with the named attribute value of "Small", "small" are both matched.
        /// </summary>
        [JsonProperty("attribute_value")]
        public string AttributeValue { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogQueryExact : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CatalogQueryExact other
                && (
                    this.AttributeName == null && other.AttributeName == null
                    || this.AttributeName?.Equals(other.AttributeName) == true
                )
                && (
                    this.AttributeValue == null && other.AttributeValue == null
                    || this.AttributeValue?.Equals(other.AttributeValue) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -743751554;
            hashCode = HashCode.Combine(hashCode, this.AttributeName, this.AttributeValue);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AttributeName = {this.AttributeName ?? "null"}");
            toStringOutput.Add($"this.AttributeValue = {this.AttributeValue ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.AttributeName, this.AttributeValue);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string attributeName;
            private string attributeValue;

            /// <summary>
            /// Initialize Builder for CatalogQueryExact.
            /// </summary>
            /// <param name="attributeName"> attributeName. </param>
            /// <param name="attributeValue"> attributeValue. </param>
            public Builder(string attributeName, string attributeValue)
            {
                this.attributeName = attributeName;
                this.attributeValue = attributeValue;
            }

            /// <summary>
            /// AttributeName.
            /// </summary>
            /// <param name="attributeName"> attributeName. </param>
            /// <returns> Builder. </returns>
            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

            /// <summary>
            /// AttributeValue.
            /// </summary>
            /// <param name="attributeValue"> attributeValue. </param>
            /// <returns> Builder. </returns>
            public Builder AttributeValue(string attributeValue)
            {
                this.attributeValue = attributeValue;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryExact. </returns>
            public CatalogQueryExact Build()
            {
                return new CatalogQueryExact(this.attributeName, this.attributeValue);
            }
        }
    }
}
