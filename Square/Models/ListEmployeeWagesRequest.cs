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
    public class ListEmployeeWagesRequest 
    {
        public ListEmployeeWagesRequest(string employeeId = null,
            int? limit = null,
            string cursor = null)
        {
            EmployeeId = employeeId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Filter wages returned to only those that are associated with the specified employee.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// Maximum number of Employee Wages to return per page. Can range between
        /// 1 and 200. The default is the maximum at 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Pointer to the next page of Employee Wage results to fetch.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeId(EmployeeId)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string employeeId;
            private int? limit;
            private string cursor;

            public Builder() { }
            public Builder EmployeeId(string value)
            {
                employeeId = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListEmployeeWagesRequest Build()
            {
                return new ListEmployeeWagesRequest(employeeId,
                    limit,
                    cursor);
            }
        }
    }
}