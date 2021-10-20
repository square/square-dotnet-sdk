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
    using Square.Utilities;

    /// <summary>
    /// CatalogQueryRange.
    /// </summary>
    public class CatalogQueryRange
    {
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
            this.AttributeName = attributeName;
            this.AttributeMinValue = attributeMinValue;
            this.AttributeMaxValue = attributeMaxValue;
        }

        /// <summary>
        /// The name of the attribute to be searched.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired minimum value for the search attribute (inclusive).
        /// </summary>
        [JsonProperty("attribute_min_value", NullValueHandling = NullValueHandling.Ignore)]
        public long? AttributeMinValue { get; }

        /// <summary>
        /// The desired maximum value for the search attribute (inclusive).
        /// </summary>
        [JsonProperty("attribute_max_value", NullValueHandling = NullValueHandling.Ignore)]
        public long? AttributeMaxValue { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryRange : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogQueryRange other &&
                ((this.AttributeName == null && other.AttributeName == null) || (this.AttributeName?.Equals(other.AttributeName) == true)) &&
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
            toStringOutput.Add($"this.AttributeName = {(this.AttributeName == null ? "null" : this.AttributeName == string.Empty ? "" : this.AttributeName)}");
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
            private string attributeName;
            private long? attributeMinValue;
            private long? attributeMaxValue;

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
                this.attributeMaxValue = attributeMaxValue;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryRange. </returns>
            public CatalogQueryRange Build()
            {
                return new CatalogQueryRange(
                    this.attributeName,
                    this.attributeMinValue,
                    this.attributeMaxValue);
            }
        }
    }
}