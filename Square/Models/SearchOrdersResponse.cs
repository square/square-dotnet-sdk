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
        [JsonProperty("order_entries")]
        public IList<Models.OrderEntry> OrderEntries { get; }

        /// <summary>
        /// List of
        /// [Order](#type-order) objects that match query conditions. Populated only if
        /// `return_entries` in the request is set to `false`.
        /// </summary>
        [JsonProperty("orders")]
        public IList<Models.Order> Orders { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset,
        /// this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// [Errors](#type-error) encountered during the search.
        /// </summary>
        [JsonProperty("errors")]
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
            private IList<Models.OrderEntry> orderEntries = new List<Models.OrderEntry>();
            private IList<Models.Order> orders = new List<Models.Order>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder OrderEntries(IList<Models.OrderEntry> value)
            {
                orderEntries = value;
                return this;
            }

            public Builder Orders(IList<Models.Order> value)
            {
                orders = value;
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