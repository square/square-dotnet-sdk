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
    public class CatalogCategory 
    {
        public CatalogCategory(string name = null)
        {
            Name = name;
        }

        /// <summary>
        /// The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name);
            return builder;
        }

        public class Builder
        {
            private string name;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public CatalogCategory Build()
            {
                return new CatalogCategory(name);
            }
        }
    }
}