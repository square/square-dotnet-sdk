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
    public class V1CreatePageRequest 
    {
        public V1CreatePageRequest(Models.V1Page body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1Page
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Page Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Page body;

            public Builder() { }
            public Builder Body(Models.V1Page value)
            {
                body = value;
                return this;
            }

            public V1CreatePageRequest Build()
            {
                return new V1CreatePageRequest(body);
            }
        }
    }
}