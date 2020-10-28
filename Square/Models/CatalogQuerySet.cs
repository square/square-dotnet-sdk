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