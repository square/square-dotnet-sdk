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
    public class SearchOrdersResponse 
    {
        public SearchOrdersResponse(IList<Models.OrderEntry> orderEntries = null,
            IList<Models.Order> orders = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            OrderEntries = orderEntries;
            Orders = orders;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// List of [OrderEntries](#type-orderentry) that fit the query
        /// conditions. Populated only if `return_entries` was set to `true` in the request.
        /// </summary>
        [JsonProperty("order_entries", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderEntry> OrderEntries { get; }

        /// <summary>
        /// List of
        /// [Order](#type-order) objects that match query conditions. Populated only if
        /// `return_entries` in the request is set to `false`.
        /// </summary>
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Order> Orders { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset,
        /// this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// [Errors](#type-error) encountered during the search.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderEntries(OrderEntries)
                .Orders(Orders)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.OrderEntry> orderEntries;
            private IList<Models.Order> orders;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder OrderEntries(IList<Models.OrderEntry> orderEntries)
            {
                this.orderEntries = orderEntries;
                return this;
            }

            public Builder Orders(IList<Models.Order> orders)
            {
                this.orders = orders;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public SearchOrdersResponse Build()
            {
                return new SearchOrdersResponse(orderEntries,
                    orders,
                    cursor,
                    errors);
            }
        }
    }
}