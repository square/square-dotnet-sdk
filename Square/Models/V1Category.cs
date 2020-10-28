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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The category's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id", NullValueHandling = NullValueHandling.Ignore)]
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



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder V2Id(string v2Id)
            {
                this.v2Id = v2Id;
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