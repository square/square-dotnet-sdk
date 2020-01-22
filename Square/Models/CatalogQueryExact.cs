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
        /// The name of the attribute to be searched.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName { get; }

        /// <summary>
        /// The desired value of the search attribute.
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