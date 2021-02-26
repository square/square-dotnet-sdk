
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
        [JsonProperty("employee_role", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1EmployeeRole EmployeeRole { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1CreateEmployeeRoleRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"EmployeeRole = {(EmployeeRole == null ? "null" : EmployeeRole.ToString())}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is V1CreateEmployeeRoleRequest other &&
                ((EmployeeRole == null && other.EmployeeRole == null) || (EmployeeRole?.Equals(other.EmployeeRole) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1970733130;

            if (EmployeeRole != null)
            {
               hashCode += EmployeeRole.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeRole(EmployeeRole);
            return builder;
        }

        public class Builder
        {
            private Models.V1EmployeeRole employeeRole;



            public Builder EmployeeRole(Models.V1EmployeeRole employeeRole)
            {
                this.employeeRole = employeeRole;
                return this;
            }

            public V1CreateEmployeeRoleRequest Build()
            {
                return new V1CreateEmployeeRoleRequest(employeeRole);
            }
        }
    }
}