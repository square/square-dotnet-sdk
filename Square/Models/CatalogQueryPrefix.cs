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
            public Builder AttributeName(string value)
            {
                attributeName = value;
                return this;
            }

            public Builder AttributePrefix(string value)
            {
                attributePrefix = value;
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