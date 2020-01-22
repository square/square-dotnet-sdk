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
    public class UpdateCustomerResponse 
    {
        public UpdateCustomerResponse(IList<Models.Error> errors = null,
            Models.Customer customer = null)
        {
            Errors = errors;
            Customer = customer;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a Square customer profile, which can have one or more
        /// cards on file associated with it.
        /// </summary>
        [JsonProperty("customer")]
        public Models.Customer Customer { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Customer(Customer);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.Customer customer;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Customer(Models.Customer value)
            {
                customer = value;
                return this;
            }

            public UpdateCustomerResponse Build()
            {
                return new UpdateCustomerResponse(errors,
                    customer);
            }
        }
    }
}