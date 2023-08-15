namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// GetEmployeeWageResponse.
    /// </summary>
    public class GetEmployeeWageResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEmployeeWageResponse"/> class.
        /// </summary>
        /// <param name="employeeWage">employee_wage.</param>
        /// <param name="errors">errors.</param>
        public GetEmployeeWageResponse(
            Models.EmployeeWage employeeWage = null,
            IList<Models.Error> errors = null)
        {
            this.EmployeeWage = employeeWage;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The hourly wage rate that an employee earns on a `Shift` for doing the job specified by the `title` property of this object. Deprecated at version 2020-08-26. Use [TeamMemberWage](entity:TeamMemberWage).
        /// </summary>
        [JsonProperty("employee_wage", NullValueHandling = NullValueHandling.Ignore)]
        public Models.EmployeeWage EmployeeWage { get; }

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

            return $"GetEmployeeWageResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is GetEmployeeWageResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.EmployeeWage == null && other.EmployeeWage == null) || (this.EmployeeWage?.Equals(other.EmployeeWage) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 702273580;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.EmployeeWage, this.Errors);

            return hashCode;
        }
        internal GetEmployeeWageResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.EmployeeWage = {(this.EmployeeWage == null ? "null" : this.EmployeeWage.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeWage(this.EmployeeWage)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.EmployeeWage employeeWage;
            private IList<Models.Error> errors;

             /// <summary>
             /// EmployeeWage.
             /// </summary>
             /// <param name="employeeWage"> employeeWage. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeWage(Models.EmployeeWage employeeWage)
            {
                this.employeeWage = employeeWage;
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
            /// <returns> GetEmployeeWageResponse. </returns>
            public GetEmployeeWageResponse Build()
            {
                return new GetEmployeeWageResponse(
                    this.employeeWage,
                    this.errors);
            }
        }
    }
}