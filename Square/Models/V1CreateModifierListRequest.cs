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
    public class V1CreateModifierListRequest 
    {
        public V1CreateModifierListRequest(Models.V1ModifierList body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1ModifierList
        /// </summary>
        [JsonProperty("body")]
        public Models.V1ModifierList Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1ModifierList body;

            public Builder() { }
            public Builder Body(Models.V1ModifierList value)
            {
                body = value;
                return this;
            }

            public V1CreateModifierListRequest Build()
            {
                return new V1CreateModifierListRequest(body);
            }
        }
    }
}