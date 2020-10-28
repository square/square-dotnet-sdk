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



            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
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