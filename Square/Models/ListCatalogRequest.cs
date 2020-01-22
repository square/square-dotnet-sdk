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
    public class ListCatalogRequest 
    {
        public ListCatalogRequest(string cursor = null,
            string types = null)
        {
            Cursor = cursor;
            Types = types;
        }

        /// <summary>
        /// The pagination cursor returned in the previous response. Leave unset for an initial request.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// An optional case-insensitive, comma-separated list of object types to retrieve, for example
        /// `ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.
        /// The legal values are taken from the CatalogObjectType enum:
        /// `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,
        /// `MODIFIER`, `MODIFIER_LIST`, or `IMAGE`.
        /// </summary>
        [JsonProperty("types")]
        public string Types { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .Types(Types);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private string types;

            public Builder() { }
            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Types(string value)
            {
                types = value;
                return this;
            }

            public ListCatalogRequest Build()
            {
                return new ListCatalogRequest(cursor,
                    types);
            }
        }
    }
}