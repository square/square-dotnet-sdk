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
    /// V1UpdateEmployeeRequest.
    /// </summary>
    public class V1UpdateEmployeeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1UpdateEmployeeRequest"/> class.
        /// </summary>
        /// <param name="body">body.</param>
        public V1UpdateEmployeeRequest(
            Models.V1Employee body)
        {
            this.Body = body;
        }

        /// <summary>
        /// Represents one of a business's employees.
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Employee Body { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1UpdateEmployeeRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1UpdateEmployeeRequest other &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1555706988;

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
            private Models.V1Employee body;

            public Builder(
                Models.V1Employee body)
            {
                this.body = body;
            }

             /// <summary>
             /// Body.
             /// </summary>
             /// <param name="body"> body. </param>
             /// <returns> Builder. </returns>
            public Builder Body(Models.V1Employee body)
            {
                this.body = body;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1UpdateEmployeeRequest. </returns>
            public V1UpdateEmployeeRequest Build()
            {
                return new V1UpdateEmployeeRequest(
                    this.body);
            }
        }
    }
}