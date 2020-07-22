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
    public class CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection 
    {
        public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(string name,
            string uid = null)
        {
            Uid = uid;
            Name = name;
        }

        /// <summary>
        /// Unique ID set by Square.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// Selection name, unique within `allowed_selections`.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Name)
                .Uid(Uid);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string uid;

            public Builder(string name)
            {
                this.name = name;
            }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(name,
                    uid);
            }
        }
    }
}