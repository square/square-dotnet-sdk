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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// RetrieveEmployeeResponse.
    /// </summary>
    public class RetrieveEmployeeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveEmployeeResponse"/> class.
        /// </summary>
        /// <param name="employee">employee.</param>
        /// <param name="errors">errors.</param>
        public RetrieveEmployeeResponse(
            Models.Employee employee = null,
            IList<Models.Error> errors = null)
        {
            this.Employee = employee;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// An employee object that is used by the external API.
        /// </summary>
        [JsonProperty("employee", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Employee Employee { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveEmployeeResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveEmployeeResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Employee == null && other.Employee == null) || (this.Employee?.Equals(other.Employee) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1660147655;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Employee, this.Errors);

            return hashCode;
        }
        internal RetrieveEmployeeResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Employee = {(this.Employee == null ? "null" : this.Employee.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Employee(this.Employee)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Employee employee;
            private IList<Models.Error> errors;

             /// <summary>
             /// Employee.
             /// </summary>
             /// <param name="employee"> employee. </param>
             /// <returns> Builder. </returns>
            public Builder Employee(Models.Employee employee)
            {
                this.employee = employee;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveEmployeeResponse. </returns>
            public RetrieveEmployeeResponse Build()
            {
                return new RetrieveEmployeeResponse(
                    this.employee,
                    this.errors);
            }
        }
    }
}