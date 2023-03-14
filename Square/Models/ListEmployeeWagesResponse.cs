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
    /// ListEmployeeWagesResponse.
    /// </summary>
    public class ListEmployeeWagesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListEmployeeWagesResponse"/> class.
        /// </summary>
        /// <param name="employeeWages">employee_wages.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListEmployeeWagesResponse(
            IList<Models.EmployeeWage> employeeWages = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.EmployeeWages = employeeWages;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of `EmployeeWage` results.
        /// </summary>
        [JsonProperty("employee_wages", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.EmployeeWage> EmployeeWages { get; }

        /// <summary>
        /// The value supplied in the subsequent request to fetch the next page
        /// of `EmployeeWage` results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

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

            return $"ListEmployeeWagesResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListEmployeeWagesResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.EmployeeWages == null && other.EmployeeWages == null) || (this.EmployeeWages?.Equals(other.EmployeeWages) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1030032936;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.EmployeeWages, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListEmployeeWagesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.EmployeeWages = {(this.EmployeeWages == null ? "null" : $"[{string.Join(", ", this.EmployeeWages)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeWages(this.EmployeeWages)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.EmployeeWage> employeeWages;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// EmployeeWages.
             /// </summary>
             /// <param name="employeeWages"> employeeWages. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeWages(IList<Models.EmployeeWage> employeeWages)
            {
                this.employeeWages = employeeWages;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
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
            /// <returns> ListEmployeeWagesResponse. </returns>
            public ListEmployeeWagesResponse Build()
            {
                return new ListEmployeeWagesResponse(
                    this.employeeWages,
                    this.cursor,
                    this.errors);
            }
        }
    }
}