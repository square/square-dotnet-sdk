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
    using Square.Utilities;

    /// <summary>
    /// ListEmployeeWagesRequest.
    /// </summary>
    public class ListEmployeeWagesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "employee_id", false },
                { "limit", false },
                { "cursor", false }
            };

            if (employeeId != null)
            {
                shouldSerialize["employee_id"] = true;
                this.EmployeeId = employeeId;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

        }
        internal ListEmployeeWagesRequest(Dictionary<string, bool> shouldSerialize,
            string employeeId = null,
            int? limit = null,
            string cursor = null)
        {
            this.shouldSerialize = shouldSerialize;
            EmployeeId = employeeId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Filter the returned wages to only those that are associated with the specified employee.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The maximum number of `EmployeeWage` results to return per page. The number can range between
        /// 1 and 200. The default is 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pointer to the next page of `EmployeeWage` results to fetch.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListEmployeeWagesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmployeeId()
        {
            return this.shouldSerialize["employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
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
            return obj is ListEmployeeWagesRequest other &&                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -902472069;
            hashCode = HashCode.Combine(this.EmployeeId, this.Limit, this.Cursor);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "employee_id", false },
                { "limit", false },
                { "cursor", false },
            };

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
                shouldSerialize["employee_id"] = true;
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
                shouldSerialize["limit"] = true;
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
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmployeeId()
            {
                this.shouldSerialize["employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListEmployeeWagesRequest. </returns>
            public ListEmployeeWagesRequest Build()
            {
                return new ListEmployeeWagesRequest(shouldSerialize,
                    this.employeeId,
                    this.limit,
                    this.cursor);
            }
        }
    }
}