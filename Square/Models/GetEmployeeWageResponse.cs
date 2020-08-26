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
    public class GetEmployeeWageResponse 
    {
        public GetEmployeeWageResponse(Models.EmployeeWage employeeWage = null,
            IList<Models.Error> errors = null)
        {
            EmployeeWage = employeeWage;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The hourly wage rate that an employee will earn on a `Shift` for doing the job
        /// specified by the `title` property of this object. Deprecated at verison 2020-08-26. Use `TeamMemberWage` instead.
        /// </summary>
        [JsonProperty("employee_wage")]
        public Models.EmployeeWage EmployeeWage { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmployeeWage(EmployeeWage)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.EmployeeWage employeeWage;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder EmployeeWage(Models.EmployeeWage value)
            {
                employeeWage = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public GetEmployeeWageResponse Build()
            {
                return new GetEmployeeWageResponse(employeeWage,
                    errors);
            }
        }
    }
}