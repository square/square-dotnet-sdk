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
    public class RetrieveEmployeeResponse 
    {
        public RetrieveEmployeeResponse(Models.Employee employee = null,
            IList<Models.Error> errors = null)
        {
            Employee = employee;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// An employee object that is used by the external API.
        /// </summary>
        [JsonProperty("employee")]
        public Models.Employee Employee { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Employee(Employee)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.Employee employee;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Employee(Models.Employee value)
            {
                employee = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public RetrieveEmployeeResponse Build()
            {
                return new RetrieveEmployeeResponse(employee,
                    errors);
            }
        }
    }
}