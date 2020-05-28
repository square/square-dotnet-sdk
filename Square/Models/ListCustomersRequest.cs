using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ListCustomersRequest 
    {
        public ListCustomersRequest(string cursor = null,
            string sortField = null,
            string sortOrder = null)
        {
            Cursor = cursor;
            SortField = sortField;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Specifies customer attributes as the sort key to customer profiles returned from a search.
        /// </summary>
        [JsonProperty("sort_field")]
        public string SortField { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .SortField(SortField)
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private string sortField;
            private string sortOrder;

            public Builder() { }
            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder SortField(string value)
            {
                sortField = value;
                return this;
            }

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public ListCustomersRequest Build()
            {
                return new ListCustomersRequest(cursor,
                    sortField,
                    sortOrder);
            }
        }
    }
}