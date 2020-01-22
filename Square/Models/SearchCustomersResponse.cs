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
    public class SearchCustomersResponse 
    {
        public SearchCustomersResponse(IList<Models.Error> errors = null,
            IList<Models.Customer> customers = null,
            string cursor = null)
        {
            Errors = errors;
            Customers = customers;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// An array of `Customer` objects that match a query.
        /// </summary>
        [JsonProperty("customers")]
        public IList<Models.Customer> Customers { get; }

        /// <summary>
        /// A pagination cursor that can be used during subsequent calls
        /// to SearchCustomers to retrieve the next set of results associated
        /// with the original query. Pagination cursors are only present when
        /// a request succeeds and additional results are available.
        /// See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Customers(Customers)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.Customer> customers = new List<Models.Customer>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Customers(IList<Models.Customer> value)
            {
                customers = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public SearchCustomersResponse Build()
            {
                return new SearchCustomersResponse(errors,
                    customers,
                    cursor);
            }
        }
    }
}