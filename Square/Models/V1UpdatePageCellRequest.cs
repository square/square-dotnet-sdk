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
    public class V1UpdatePageCellRequest 
    {
        public V1UpdatePageCellRequest(Models.V1PageCell body)
        {
            Body = body;
        }

        /// <summary>
        /// V1PageCell
        /// </summary>
        [JsonProperty("body")]
        public Models.V1PageCell Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1PageCell body;

            public Builder(Models.V1PageCell body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1PageCell value)
            {
                body = value;
                return this;
            }

            public V1UpdatePageCellRequest Build()
            {
                return new V1UpdatePageCellRequest(body);
            }
        }
    }
}