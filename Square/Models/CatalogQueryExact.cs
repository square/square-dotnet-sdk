
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
    public class CatalogQueryExact 
    {
        public CatalogQueryExact(string attributeName,
            string attributeValue)
        {
            AttributeName = attributeName;
            AttributeValue = attributeValue;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryExact : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AttributeName = {(AttributeName == null ? "null" : AttributeName == string.Empty ? "" : AttributeName)}");
            toStringOutput.Add($"AttributeValue = {(AttributeValue == null ? "null" : AttributeValue == string.Empty ? "" : AttributeValue)}");
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

            return obj is CatalogQueryExact other &&
                ((AttributeName == null && other.AttributeName == null) || (AttributeName?.Equals(other.AttributeName) == true)) &&
                ((AttributeValue == null && other.AttributeValue == null) || (AttributeValue?.Equals(other.AttributeValue) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -743751554;

            if (AttributeName != null)
            {
               hashCode += AttributeName.GetHashCode();
            }

            if (AttributeValue != null)
            {
               hashCode += AttributeValue.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(AttributeName,
                AttributeValue);
            return builder;
        }

        public class Builder
        {
            private string attributeName;
            private string attributeValue;

            public Builder(string attributeName,
                string attributeValue)
            {
                this.attributeName = attributeName;
                this.attributeValue = attributeValue;
            }

            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

            public Builder AttributeValue(string attributeValue)
            {
                this.attributeValue = attributeValue;
                return this;
            }

            public CatalogQueryExact Build()
            {
                return new CatalogQueryExact(attributeName,
                    attributeValue);
            }
        }
    }
}