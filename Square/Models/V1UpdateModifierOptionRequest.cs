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
    public class V1UpdateModifierOptionRequest 
    {
        public V1UpdateModifierOptionRequest(Models.V1ModifierOption body)
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
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1ModifierOption body;

            public Builder(Models.V1ModifierOption body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1ModifierOption value)
            {
                body = value;
                return this;
            }

            public V1UpdateModifierOptionRequest Build()
            {
                return new V1UpdateModifierOptionRequest(body);
            }
        }
    }
}