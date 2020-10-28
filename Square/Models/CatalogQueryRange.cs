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