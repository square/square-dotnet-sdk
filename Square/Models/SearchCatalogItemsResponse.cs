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
    public class SearchCatalogItemsResponse 
    {
        public SearchCatalogItemsResponse(IList<Models.Error> errors = null,
            IList<Models.CatalogObject> items = null,
            string cursor = null,
            IList<string> matchedVariationIds = null)
        {
            Errors = errors;
            Items = items;
            Cursor = cursor;
            MatchedVariationIds = matchedVariationIds;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Returned items matching the specified query expressions.
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Items { get; }

        /// <summary>
        /// Pagination token used in the next request to return more of the search result.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Ids of returned item variations matching the specified query expression.
        /// </summary>
        [JsonProperty("matched_variation_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> MatchedVariationIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Items(Items)
                .Cursor(Cursor)
                .MatchedVariationIds(MatchedVariationIds);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.CatalogObject> items;
            private string cursor;
            private IList<string> matchedVariationIds;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Items(IList<Models.CatalogObject> items)
            {
                this.items = items;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder MatchedVariationIds(IList<string> matchedVariationIds)
            {
                this.matchedVariationIds = matchedVariationIds;
                return this;
            }

            public SearchCatalogItemsResponse Build()
            {
                return new SearchCatalogItemsResponse(errors,
                    items,
                    cursor,
                    matchedVariationIds);
            }
        }
    }
}