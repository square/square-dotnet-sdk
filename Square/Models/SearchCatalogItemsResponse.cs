
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogItemsResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Items = {(Items == null ? "null" : $"[{ string.Join(", ", Items)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"MatchedVariationIds = {(MatchedVariationIds == null ? "null" : $"[{ string.Join(", ", MatchedVariationIds)} ]")}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is SearchCatalogItemsResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Items == null && other.Items == null) || (Items?.Equals(other.Items) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((MatchedVariationIds == null && other.MatchedVariationIds == null) || (MatchedVariationIds?.Equals(other.MatchedVariationIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1398933799;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Items != null)
            {
               hashCode += Items.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (MatchedVariationIds != null)
            {
               hashCode += MatchedVariationIds.GetHashCode();
            }

            return hashCode;
        }

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