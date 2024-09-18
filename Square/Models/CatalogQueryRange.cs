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
    /// CatalogQueryRange.
    /// </summary>
    public class CatalogQueryRange
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryRange"/> class.
        /// </summary>
        /// <param name="attributeName">attribute_name.</param>
        /// <param name="attributeMinValue">attribute_min_value.</param>
        /// <param name="attributeMaxValue">attribute_max_value.</param>
        public CatalogQueryRange(
            string attributeName,
            long? attributeMinValue = null,
            long? attributeMaxValue = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "attribute_min_value", false },
                { "attribute_max_value", false }
            };

            this.AttributeName = attributeName;
            if (attributeMinValue != null)
            {
                shouldSerialize["attribute_min_value"] = true;
                this.AttributeMinValue = attributeMinValue;
            }

            if (attributeMaxValue != null)
            {
                shouldSerialize["attribute_max_value"] = true;
                this.AttributeMaxValue = attributeMaxValue;
            }

        }
        internal CatalogQueryRange(Dictionary<string, bool> shouldSerialize,
            string attributeName,
            long? attributeMinValue = null,
            long? attributeMaxValue = null)
        {
            this.shouldSerialize = shouldSerialize;
            AttributeName = attributeName;
            AttributeMinValue = attributeMinValue;
            AttributeMaxValue = attributeMaxValue;
        }

        /// <summary>
        /// The name of the attribute to be searched.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired minimum value for the search attribute (inclusive).
        /// </summary>
        [JsonProperty("attribute_min_value")]
        public long? AttributeMinValue { get; }

        /// <summary>
        /// The desired maximum value for the search attribute (inclusive).
        /// </summary>
        [JsonProperty("attribute_max_value")]
        public long? AttributeMaxValue { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryRange : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAttributeMinValue()
        {
            return this.shouldSerialize["attribute_min_value"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAttributeMaxValue()
        {
            return this.shouldSerialize["attribute_max_value"];
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
            return obj is CatalogQueryRange other &&                ((this.AttributeName == null && other.AttributeName == null) || (this.AttributeName?.Equals(other.AttributeName) == true)) &&
                ((this.AttributeMinValue == null && other.AttributeMinValue == null) || (this.AttributeMinValue?.Equals(other.AttributeMinValue) == true)) &&
                ((this.AttributeMaxValue == null && other.AttributeMaxValue == null) || (this.AttributeMaxValue?.Equals(other.AttributeMaxValue) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 946255455;
            hashCode = HashCode.Combine(this.AttributeName, this.AttributeMinValue, this.AttributeMaxValue);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AttributeName = {(this.AttributeName == null ? "null" : this.AttributeName)}");
            toStringOutput.Add($"this.AttributeMinValue = {(this.AttributeMinValue == null ? "null" : this.AttributeMinValue.ToString())}");
            toStringOutput.Add($"this.AttributeMaxValue = {(this.AttributeMaxValue == null ? "null" : this.AttributeMaxValue.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AttributeName)
                .AttributeMinValue(this.AttributeMinValue)
                .AttributeMaxValue(this.AttributeMaxValue);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "attribute_min_value", false },
                { "attribute_max_value", false },
            };

            private string attributeName;
            private long? attributeMinValue;
            private long? attributeMaxValue;

            /// <summary>
            /// Initialize Builder for CatalogQueryRange.
            /// </summary>
            /// <param name="attributeName"> attributeName. </param>
            public Builder(
                string attributeName)
            {
                this.attributeName = attributeName;
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
             /// AttributeMinValue.
             /// </summary>
             /// <param name="attributeMinValue"> attributeMinValue. </param>
             /// <returns> Builder. </returns>
            public Builder AttributeMinValue(long? attributeMinValue)
            {
                shouldSerialize["attribute_min_value"] = true;
                this.attributeMinValue = attributeMinValue;
                return this;
            }

             /// <summary>
             /// AttributeMaxValue.
             /// </summary>
             /// <param name="attributeMaxValue"> attributeMaxValue. </param>
             /// <returns> Builder. </returns>
            public Builder AttributeMaxValue(long? attributeMaxValue)
            {
                shouldSerialize["attribute_max_value"] = true;
                this.attributeMaxValue = attributeMaxValue;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAttributeMinValue()
            {
                this.shouldSerialize["attribute_min_value"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAttributeMaxValue()
            {
                this.shouldSerialize["attribute_max_value"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryRange. </returns>
            public CatalogQueryRange Build()
            {
                return new CatalogQueryRange(shouldSerialize,
                    this.attributeName,
                    this.attributeMinValue,
                    this.attributeMaxValue);
            }
        }
    }
}