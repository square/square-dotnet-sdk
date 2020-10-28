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
    public class RegisterDomainResponse 
    {
        public RegisterDomainResponse(IList<Models.Error> errors = null,
            string status = null)
        {
            Errors = errors;
            Status = status;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The status of domain registration.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private string status;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public RegisterDomainResponse Build()
            {
                return new RegisterDomainResponse(errors,
                    status);
            }
        }
    }
}