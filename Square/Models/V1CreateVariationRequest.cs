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
    public class V1CreateVariationRequest 
    {
        public V1CreateVariationRequest(Models.V1Variation body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1Variation
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Variation Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Variation body;

            public Builder() { }
            public Builder Body(Models.V1Variation value)
            {
                body = value;
                return this;
            }

            public V1CreateVariationRequest Build()
            {
                return new V1CreateVariationRequest(body);
            }
        }
    }
}