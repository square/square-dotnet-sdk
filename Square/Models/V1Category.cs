using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Category 
    {
        public V1Category(string id = null,
            string name = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The category's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The category's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id")]
        public string V2Id { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string v2Id;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder V2Id(string value)
            {
                v2Id = value;
                return this;
            }

            public V1Category Build()
            {
                return new V1Category(id,
                    name,
                    v2Id);
            }
        }
    }
}