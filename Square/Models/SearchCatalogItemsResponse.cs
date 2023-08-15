namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// SearchCatalogItemsResponse.
    /// </summary>
    public class SearchCatalogItemsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCatalogItemsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="items">items.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="matchedVariationIds">matched_variation_ids.</param>
        public SearchCatalogItemsResponse(
            IList<Models.Error> errors = null,
            IList<Models.CatalogObject> items = null,
            string cursor = null,
            IList<string> matchedVariationIds = null)
        {
            this.Errors = errors;
            this.Items = items;
            this.Cursor = cursor;
            this.MatchedVariationIds = matchedVariationIds;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogItemsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is SearchCatalogItemsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Items == null && other.Items == null) || (this.Items?.Equals(other.Items) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.MatchedVariationIds == null && other.MatchedVariationIds == null) || (this.MatchedVariationIds?.Equals(other.MatchedVariationIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1398933799;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Items, this.Cursor, this.MatchedVariationIds);

            return hashCode;
        }
        internal SearchCatalogItemsResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Items = {(this.Items == null ? "null" : $"[{string.Join(", ", this.Items)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.MatchedVariationIds = {(this.MatchedVariationIds == null ? "null" : $"[{string.Join(", ", this.MatchedVariationIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Items(this.Items)
                .Cursor(this.Cursor)
                .MatchedVariationIds(this.MatchedVariationIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.CatalogObject> items;
            private string cursor;
            private IList<string> matchedVariationIds;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// Items.
             /// </summary>
             /// <param name="items"> items. </param>
             /// <returns> Builder. </returns>
            public Builder Items(IList<Models.CatalogObject> items)
            {
                this.items = items;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// MatchedVariationIds.
             /// </summary>
             /// <param name="matchedVariationIds"> matchedVariationIds. </param>
             /// <returns> Builder. </returns>
            public Builder MatchedVariationIds(IList<string> matchedVariationIds)
            {
                this.matchedVariationIds = matchedVariationIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchCatalogItemsResponse. </returns>
            public SearchCatalogItemsResponse Build()
            {
                return new SearchCatalogItemsResponse(
                    this.errors,
                    this.items,
                    this.cursor,
                    this.matchedVariationIds);
            }
        }
    }
}