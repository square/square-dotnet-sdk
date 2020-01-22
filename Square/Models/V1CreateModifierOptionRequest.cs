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
    public class V1CreateModifierOptionRequest 
    {
        public V1CreateModifierOptionRequest(Models.V1ModifierOption body = null)
        {
            Body = body;
        }

        /// <summary>
        /// V1ModifierOption
        /// </summary>
        [JsonProperty("body")]
        public Models.V1ModifierOption Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Body(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1ModifierOption body;

            public Builder() { }
            public Builder Body(Models.V1ModifierOption value)
            {
                body = value;
                return this;
            }

            public V1CreateModifierOptionRequest Build()
            {
                return new V1CreateModifierOptionRequest(body);
            }
        }
    }
}