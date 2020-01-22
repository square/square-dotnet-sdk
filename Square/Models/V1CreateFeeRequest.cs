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
    public class V1CreateFeeRequest 
    {
        public V1CreateFeeRequest(Models.V1Fee body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1Fee
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Fee Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Fee body;

            public Builder() { }
            public Builder Body(Models.V1Fee value)
            {
                body = value;
                return this;
            }

            public V1CreateFeeRequest Build()
            {
                return new V1CreateFeeRequest(body);
            }
        }
    }
}