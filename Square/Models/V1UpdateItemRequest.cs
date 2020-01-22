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
    public class V1UpdateItemRequest 
    {
        public V1UpdateItemRequest(Models.V1Item body)
        {
            Body = body;
        }

        /// <summary>
        /// V1Item
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Item Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Item body;

            public Builder(Models.V1Item body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1Item value)
            {
                body = value;
                return this;
            }

            public V1UpdateItemRequest Build()
            {
                return new V1UpdateItemRequest(body);
            }
        }
    }
}