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
    public class V1UpdateFeeRequest 
    {
        public V1UpdateFeeRequest(Models.V1Fee body)
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
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Fee body;

            public Builder(Models.V1Fee body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1Fee value)
            {
                body = value;
                return this;
            }

            public V1UpdateFeeRequest Build()
            {
                return new V1UpdateFeeRequest(body);
            }
        }
    }
}