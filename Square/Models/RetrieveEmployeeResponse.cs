
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
        [JsonProperty("employee", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Employee Employee { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveEmployeeResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Employee = {(Employee == null ? "null" : Employee.ToString())}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
        }

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

            return obj is RetrieveEmployeeResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Employee == null && other.Employee == null) || (Employee?.Equals(other.Employee) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1660147655;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Employee != null)
            {
               hashCode += Employee.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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
            private IList<Models.Error> errors;



            public Builder Employee(Models.Employee employee)
            {
                this.employee = employee;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
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