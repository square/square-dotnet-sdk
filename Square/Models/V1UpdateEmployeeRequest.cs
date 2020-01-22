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
    public class V1UpdateEmployeeRequest 
    {
        public V1UpdateEmployeeRequest(Models.V1Employee body)
        {
            Body = body;
        }

        /// <summary>
        /// Represents one of a business's employees.
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Employee Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Employee body;

            public Builder(Models.V1Employee body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1Employee value)
            {
                body = value;
                return this;
            }

            public V1UpdateEmployeeRequest Build()
            {
                return new V1UpdateEmployeeRequest(body);
            }
        }
    }
}