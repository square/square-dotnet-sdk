
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
    public class CatalogQueryPrefix 
    {
        public CatalogQueryPrefix(string attributeName,
            string attributePrefix)
        {
            AttributeName = attributeName;
            AttributePrefix = attributePrefix;
        }

        /// <summary>
        /// The name of the attribute to be searched.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired prefix of the search attribute value.
        /// </summary>
        [JsonProperty("attribute_prefix")]
        public string AttributePrefix { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryPrefix : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AttributeName = {(AttributeName == null ? "null" : AttributeName == string.Empty ? "" : AttributeName)}");
            toStringOutput.Add($"AttributePrefix = {(AttributePrefix == null ? "null" : AttributePrefix == string.Empty ? "" : AttributePrefix)}");
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

            return obj is CatalogQueryPrefix other &&
                ((AttributeName == null && other.AttributeName == null) || (AttributeName?.Equals(other.AttributeName) == true)) &&
                ((AttributePrefix == null && other.AttributePrefix == null) || (AttributePrefix?.Equals(other.AttributePrefix) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -167354518;

            if (AttributeName != null)
            {
               hashCode += AttributeName.GetHashCode();
            }

            if (AttributePrefix != null)
            {
               hashCode += AttributePrefix.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(AttributeName,
                AttributePrefix);
            return builder;
        }

        public class Builder
        {
            private string attributeName;
            private string attributePrefix;

            public Builder(string attributeName,
                string attributePrefix)
            {
                this.attributeName = attributeName;
                this.attributePrefix = attributePrefix;
            }

            public Builder AttributeName(string attributeName)
            {
                this.attributeName = attributeName;
                return this;
            }

            public Builder AttributePrefix(string attributePrefix)
            {
                this.attributePrefix = attributePrefix;
                return this;
            }

            public CatalogQueryPrefix Build()
            {
                return new CatalogQueryPrefix(attributeName,
                    attributePrefix);
            }
        }
    }
}