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
    public class CatalogCustomAttributeDefinitionNumberConfig 
    {
        public CatalogCustomAttributeDefinitionNumberConfig(int? precision = null)
        {
            Precision = precision;
        }

        /// <summary>
        /// An integer between 0 and 5 that represents the maximum number of
        /// positions allowed after the decimal in number custom attribute values
        /// For example:
        /// - if the precision is 0, the quantity can be 1, 2, 3, etc.
        /// - if the precision is 1, the quantity can be 0.1, 0.2, etc.
        /// - if the precision is 2, the quantity can be 0.01, 0.12, etc.
        /// Default: 5
        /// </summary>
        [JsonProperty("precision")]
        public int? Precision { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Precision(Precision);
            return builder;
        }

        public class Builder
        {
            private int? precision;

            public Builder() { }
            public Builder Precision(int? value)
            {
                precision = value;
                return this;
            }

            public CatalogCustomAttributeDefinitionNumberConfig Build()
            {
                return new CatalogCustomAttributeDefinitionNumberConfig(precision);
            }
        }
    }
}