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
    public class ListEmployeesResponse 
    {
        public ListEmployeesResponse(IList<Models.Employee> employees = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            Employees = employees;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Getter for employees
        /// </summary>
        [JsonProperty("employees")]
        public IList<Models.Employee> Employees { get; }

        /// <summary>
        /// The token to be used to retrieve the next page of results.
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
                .Employees(Employees)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Employee> employees = new List<Models.Employee>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Employees(IList<Models.Employee> value)
            {
                employees = value;
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

            public ListEmployeesResponse Build()
            {
                return new ListEmployeesResponse(employees,
                    cursor,
                    errors);
            }
        }
    }
}