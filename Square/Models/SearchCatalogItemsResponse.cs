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
        /// Errors detected when the call to [SearchCatalogItems](#endpoint-Catalog-SearchCatalogItems) endpoint fails.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Returned items matching the specified query expressions.
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.CatalogObject> Items { get; }

        /// <summary>
        /// Pagination token used in the next request to return more of the search result.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Ids of returned item variations matching the specified query expression.
        /// </summary>
        [JsonProperty("matched_variation_ids")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.CatalogObject> items = new List<Models.CatalogObject>();
            private string cursor;
            private IList<string> matchedVariationIds = new List<string>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Items(IList<Models.CatalogObject> value)
            {
                items = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder MatchedVariationIds(IList<string> value)
            {
                matchedVariationIds = value;
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