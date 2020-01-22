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
    public class V1CreateEmployeeRoleRequest 
    {
        public V1CreateEmployeeRoleRequest(Models.V1EmployeeRole employeeRole = null)
        {
            EmployeeRole = employeeRole;
        }

        /// <summary>
        /// V1EmployeeRole
        /// </summary>
        [JsonProperty("employee_role")]
        public Models.V1EmployeeRole EmployeeRole { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeRole(EmployeeRole);
            return builder;
        }

        public class Builder
        {
            private Models.V1EmployeeRole employeeRole;

            public Builder() { }
            public Builder EmployeeRole(Models.V1EmployeeRole value)
            {
                employeeRole = value;
                return this;
            }

            public V1CreateEmployeeRoleRequest Build()
            {
                return new V1CreateEmployeeRoleRequest(employeeRole);
            }
        }
    }
}