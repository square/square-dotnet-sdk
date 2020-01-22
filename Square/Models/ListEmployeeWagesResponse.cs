using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ListEmployeeWagesResponse 
    {
        public ListEmployeeWagesResponse(IList<Models.EmployeeWage> employeeWages = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            EmployeeWages = employeeWages;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of Employee Wage results.
        /// </summary>
        [JsonProperty("employee_wages")]
        public IList<Models.EmployeeWage> EmployeeWages { get; }

        /// <summary>
        /// Value supplied in the subsequent request to fetch the next next page
        /// of Employee Wage results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeWages(EmployeeWages)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.EmployeeWage> employeeWages = new List<Models.EmployeeWage>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder EmployeeWages(IList<Models.EmployeeWage> value)
            {
                employeeWages = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public ListEmployeeWagesResponse Build()
            {
                return new ListEmployeeWagesResponse(employeeWages,
                    cursor,
                    errors);
            }
        }
    }
}