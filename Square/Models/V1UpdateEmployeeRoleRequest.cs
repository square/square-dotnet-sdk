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
    public class V1UpdateEmployeeRoleRequest 
    {
        public V1UpdateEmployeeRoleRequest(Models.V1EmployeeRole body)
        {
            Body = body;
        }

        /// <summary>
        /// V1EmployeeRole
        /// </summary>
        [JsonProperty("body")]
        public Models.V1EmployeeRole Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1EmployeeRole body;

            public Builder(Models.V1EmployeeRole body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1EmployeeRole value)
            {
                body = value;
                return this;
            }

            public V1UpdateEmployeeRoleRequest Build()
            {
                return new V1UpdateEmployeeRoleRequest(body);
            }
        }
    }
}