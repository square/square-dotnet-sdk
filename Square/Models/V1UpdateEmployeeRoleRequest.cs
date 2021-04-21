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
    /// V1UpdateEmployeeRoleRequest.
    /// </summary>
    public class V1UpdateEmployeeRoleRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1UpdateEmployeeRoleRequest"/> class.
        /// </summary>
        /// <param name="body">body.</param>
        public V1UpdateEmployeeRoleRequest(
            Models.V1EmployeeRole body)
        {
            this.Body = body;
        }

        /// <summary>
        /// V1EmployeeRole
        /// </summary>
        [JsonProperty("body")]
        public Models.V1EmployeeRole Body { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1UpdateEmployeeRoleRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1UpdateEmployeeRoleRequest other &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -787951512;

            if (this.Body != null)
            {
               hashCode += this.Body.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Body = {(this.Body == null ? "null" : this.Body.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Body);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.V1EmployeeRole body;

            public Builder(
                Models.V1EmployeeRole body)
            {
                this.body = body;
            }

             /// <summary>
             /// Body.
             /// </summary>
             /// <param name="body"> body. </param>
             /// <returns> Builder. </returns>
            public Builder Body(Models.V1EmployeeRole body)
            {
                this.body = body;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1UpdateEmployeeRoleRequest. </returns>
            public V1UpdateEmployeeRoleRequest Build()
            {
                return new V1UpdateEmployeeRoleRequest(
                    this.body);
            }
        }
    }
}