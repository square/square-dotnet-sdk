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
    public class V1CreateDiscountRequest 
    {
        public V1CreateDiscountRequest(Models.V1Discount body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1Discount
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Discount Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Discount body;

            public Builder() { }
            public Builder Body(Models.V1Discount value)
            {
                body = value;
                return this;
            }

            public V1CreateDiscountRequest Build()
            {
                return new V1CreateDiscountRequest(body);
            }
        }
    }
}