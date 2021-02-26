
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
    public class CatalogQuerySet 
    {
        public CatalogQuerySet(string attributeName,
            IList<string> attributeValues)
        {
            AttributeName = attributeName;
            AttributeValues = attributeValues;
        }

        /// <summary>
        /// The name of the attribute to be searched. Matching of the attribute name is exact.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired values of the search attribute. Matching of the attribute values is exact and case insensitive.
        /// A maximum of 250 values may be searched in a request.
        /// </summary>
        [JsonProperty("attribute_values")]
        public IList<string> AttributeValues { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuerySet : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AttributeName = {(AttributeName == null ? "null" : AttributeName == string.Empty ? "" : AttributeName)}");
            toStringOutput.Add($"AttributeValues = {(AttributeValues == null ? "null" : $"[{ string.Join(", ", AttributeValues)} ]")}");
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

            return obj is CatalogQuerySet other &&
                ((AttributeName == null && other.AttributeName == null) || (AttributeName?.Equals(other.AttributeName) == true)) &&
                ((AttributeValues == null && other.AttributeValues == null) || (AttributeValues?.Equals(other.AttributeValues) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 478444029;

            if (AttributeName != null)
            {
               hashCode += AttributeName.GetHashCode();
            }

            if (AttributeValues != null)
            {
               hashCode += AttributeValues.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(AttributeName,
                AttributeValues);
            return builder;
        }

        public class Builder
        {
            private string attributeName;
            private IList<string> attributeValues;

            public Builder(string attributeName,
                IList<string> attributeValues)
            {
                this.attributeName = attributeName;
                this.attributeValues = attributeValues;
            }

            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

            public Builder AttributeValues(IList<string> attributeValues)
            {
                this.attributeValues = attributeValues;
                return this;
            }

            public CatalogQuerySet Build()
            {
                return new CatalogQuerySet(attributeName,
                    attributeValues);
            }
        }
    }
}