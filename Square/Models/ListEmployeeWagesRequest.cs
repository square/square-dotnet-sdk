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
    /// ListEmployeeWagesRequest.
    /// </summary>
    public class ListEmployeeWagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListEmployeeWagesRequest"/> class.
        /// </summary>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public ListEmployeeWagesRequest(
            string employeeId = null,
            int? limit = null,
            string cursor = null)
        {
            this.EmployeeId = employeeId;
            this.Limit = limit;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Filter wages returned to only those that are associated with the specified employee.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// Maximum number of Employee Wages to return per page. Can range between
        /// 1 and 200. The default is the maximum at 200.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Pointer to the next page of Employee Wage results to fetch.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListEmployeeWagesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListEmployeeWagesRequest other &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -902472069;

            if (this.EmployeeId != null)
            {
               hashCode += this.EmployeeId.GetHashCode();
            }

            if (this.Limit != null)
            {
               hashCode += this.Limit.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId == string.Empty ? "" : this.EmployeeId)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeId(this.EmployeeId)
                .Limit(this.Limit)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string employeeId;
            private int? limit;
            private string cursor;

             /// <summary>
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
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
            /// Builds class object.
            /// </summary>
            /// <returns> ListEmployeeWagesRequest. </returns>
            public ListEmployeeWagesRequest Build()
            {
                return new ListEmployeeWagesRequest(
                    this.employeeId,
                    this.limit,
                    this.cursor);
            }
        }
    }
}