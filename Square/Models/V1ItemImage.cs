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
    public class V1ItemImage 
    {
        public V1ItemImage(string id = null,
            string url = null)
        {
            Id = id;
            Url = url;
        }

        /// <summary>
        /// The image's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The image's publicly accessible URL.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Url(Url);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string url;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Url(string url)
            {
                this.url = url;
                return this;
            }

            public V1ItemImage Build()
            {
                return new V1ItemImage(id,
                    url);
            }
        }
    }
}