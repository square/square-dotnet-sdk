namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// V1CreateEmployeeRoleRequest.
    /// </summary>
    public class V1CreateEmployeeRoleRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1CreateEmployeeRoleRequest"/> class.
        /// </summary>
        /// <param name="employeeRole">employee_role.</param>
        public V1CreateEmployeeRoleRequest(
            Models.V1EmployeeRole employeeRole = null)
        {
            this.EmployeeRole = employeeRole;
        }

        /// <summary>
        /// V1EmployeeRole
        /// </summary>
        [JsonProperty("employee_role", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1EmployeeRole EmployeeRole { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1CreateEmployeeRoleRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.EmployeeRole == null && other.EmployeeRole == null) || (this.EmployeeRole?.Equals(other.EmployeeRole) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1970733130;

            if (this.EmployeeRole != null)
            {
               hashCode += this.EmployeeRole.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EmployeeRole = {(this.EmployeeRole == null ? "null" : this.EmployeeRole.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeRole(this.EmployeeRole);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.V1EmployeeRole employeeRole;

             /// <summary>
             /// EmployeeRole.
             /// </summary>
             /// <param name="employeeRole"> employeeRole. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeRole(Models.V1EmployeeRole employeeRole)
            {
                this.employeeRole = employeeRole;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1CreateEmployeeRoleRequest. </returns>
            public V1CreateEmployeeRoleRequest Build()
            {
                return new V1CreateEmployeeRoleRequest(
                    this.employeeRole);
            }
        }
    }
}