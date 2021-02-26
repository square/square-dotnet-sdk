
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CatalogQueryRange 
    {
        public CatalogQueryRange(string attributeName,
            long? attributeMinValue = null,
            long? attributeMaxValue = null)
        {
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
        [JsonProperty("attribute_min_value", NullValueHandling = NullValueHandling.Ignore)]
        public long? AttributeMinValue { get; }

        /// <summary>
        /// The desired maximum value for the search attribute (inclusive).
        /// </summary>
        [JsonProperty("attribute_max_value", NullValueHandling = NullValueHandling.Ignore)]
        public long? AttributeMaxValue { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryRange : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AttributeName = {(AttributeName == null ? "null" : AttributeName == string.Empty ? "" : AttributeName)}");
            toStringOutput.Add($"AttributeMinValue = {(AttributeMinValue == null ? "null" : AttributeMinValue.ToString())}");
            toStringOutput.Add($"AttributeMaxValue = {(AttributeMaxValue == null ? "null" : AttributeMaxValue.ToString())}");
        }

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
                ((AttributeName == null && other.AttributeName == null) || (AttributeName?.Equals(other.AttributeName) == true)) &&
                ((AttributeMinValue == null && other.AttributeMinValue == null) || (AttributeMinValue?.Equals(other.AttributeMinValue) == true)) &&
                ((AttributeMaxValue == null && other.AttributeMaxValue == null) || (AttributeMaxValue?.Equals(other.AttributeMaxValue) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 946255455;

            if (AttributeName != null)
            {
               hashCode += AttributeName.GetHashCode();
            }

            if (AttributeMinValue != null)
            {
               hashCode += AttributeMinValue.GetHashCode();
            }

            if (AttributeMaxValue != null)
            {
               hashCode += AttributeMaxValue.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(AttributeName)
                .AttributeMinValue(AttributeMinValue)
                .AttributeMaxValue(AttributeMaxValue);
            return builder;
        }

        public class Builder
        {
            private string attributeName;
            private long? attributeMinValue;
            private long? attributeMaxValue;

            public Builder(string attributeName)
            {
                this.attributeName = attributeName;
            }

            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

            public Builder AttributeMinValue(long? attributeMinValue)
            {
                this.attributeMinValue = attributeMinValue;
                return this;
            }

            public Builder AttributeMaxValue(long? attributeMaxValue)
            {
                this.attributeMaxValue = attributeMaxValue;
                return this;
            }

            public CatalogQueryRange Build()
            {
                return new CatalogQueryRange(attributeName,
                    attributeMinValue,
                    attributeMaxValue);
            }
        }
    }
}