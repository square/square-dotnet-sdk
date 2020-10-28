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
    public class RetrieveCustomerResponse 
    {
        public RetrieveCustomerResponse(IList<Models.Error> errors = null,
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
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a Square customer profile, which can have one or more
        /// cards on file associated with it.
        /// </summary>
        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;
            private Models.Customer customer;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Customer(Models.Customer customer)
            {
                this.customer = customer;
                return this;
            }

            public RetrieveCustomerResponse Build()
            {
                return new RetrieveCustomerResponse(errors,
                    customer);
            }
        }
    }
}