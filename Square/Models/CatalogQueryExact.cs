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
            public Builder AttributeName(string value)
            {
                attributeName = value;
                return this;
            }

            public Builder AttributeValue(string value)
            {
                attributeValue = value;
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