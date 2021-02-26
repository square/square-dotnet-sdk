
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1UpdateEmployeeRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Body = {(Body == null ? "null" : Body.ToString())}");
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

            return obj is V1UpdateEmployeeRequest other &&
                ((Body == null && other.Body == null) || (Body?.Equals(other.Body) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1555706988;

            if (Body != null)
            {
               hashCode += Body.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder Body(Models.V1Employee body)
            {
                this.body = body;
                return this;
            }

            public V1UpdateEmployeeRequest Build()
            {
                return new V1UpdateEmployeeRequest(body);
            }
        }
    }
}