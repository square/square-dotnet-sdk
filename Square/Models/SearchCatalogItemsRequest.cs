namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// SearchCatalogItemsRequest.
    /// </summary>
    public class SearchCatalogItemsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCatalogItemsRequest"/> class.
        /// </summary>
        /// <param name="textFilter">text_filter.</param>
        /// <param name="categoryIds">category_ids.</param>
        /// <param name="stockLevels">stock_levels.</param>
        /// <param name="enabledLocationIds">enabled_location_ids.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="productTypes">product_types.</param>
        /// <param name="customAttributeFilters">custom_attribute_filters.</param>
        public SearchCatalogItemsRequest(
            string textFilter = null,
            IList<string> categoryIds = null,
            IList<string> stockLevels = null,
            IList<string> enabledLocationIds = null,
            string cursor = null,
            int? limit = null,
            string sortOrder = null,
            IList<string> productTypes = null,
            IList<Models.CustomAttributeFilter> customAttributeFilters = null)
        {
            this.TextFilter = textFilter;
            this.CategoryIds = categoryIds;
            this.StockLevels = stockLevels;
            this.EnabledLocationIds = enabledLocationIds;
            this.Cursor = cursor;
            this.Limit = limit;
            this.SortOrder = sortOrder;
            this.ProductTypes = productTypes;
            this.CustomAttributeFilters = customAttributeFilters;
        }

        /// <summary>
        /// The text filter expression to return items or item variations containing specified text in
        /// the `name`, `description`, or `abbreviation` attribute value of an item, or in
        /// the `name`, `sku`, or `upc` attribute value of an item variation.
        /// </summary>
        [JsonProperty("text_filter", NullValueHandling = NullValueHandling.Ignore)]
        public string TextFilter { get; }

        /// <summary>
        /// The category id query expression to return items containing the specified category IDs.
        /// </summary>
        [JsonProperty("category_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CategoryIds { get; }

        /// <summary>
        /// The stock-level query expression to return item variations with the specified stock levels.
        /// See [SearchCatalogItemsRequestStockLevel](#type-searchcatalogitemsrequeststocklevel) for possible values
        /// </summary>
        [JsonProperty("stock_levels", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> StockLevels { get; }

        /// <summary>
        /// The enabled-location query expression to return items and item variations having specified enabled locations.
        /// </summary>
        [JsonProperty("enabled_location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> EnabledLocationIds { get; }

        /// <summary>
        /// The pagination token, returned in the previous response, used to fetch the next batch of pending results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return per page. The default value is 100.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// The product types query expression to return items or item variations having the specified product types.
        /// </summary>
        [JsonProperty("product_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ProductTypes { get; }

        /// <summary>
        /// The customer-attribute filter to return items or item variations matching the specified
        /// custom attribute expressions. A maximum number of 10 custom attribute expressions are supported in
        /// a single call to the [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) endpoint.
        /// </summary>
        [JsonProperty("custom_attribute_filters", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomAttributeFilter> CustomAttributeFilters { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogItemsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is SearchCatalogItemsRequest other &&                ((this.TextFilter == null && other.TextFilter == null) || (this.TextFilter?.Equals(other.TextFilter) == true)) &&
                ((this.CategoryIds == null && other.CategoryIds == null) || (this.CategoryIds?.Equals(other.CategoryIds) == true)) &&
                ((this.StockLevels == null && other.StockLevels == null) || (this.StockLevels?.Equals(other.StockLevels) == true)) &&
                ((this.EnabledLocationIds == null && other.EnabledLocationIds == null) || (this.EnabledLocationIds?.Equals(other.EnabledLocationIds) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true)) &&
                ((this.ProductTypes == null && other.ProductTypes == null) || (this.ProductTypes?.Equals(other.ProductTypes) == true)) &&
                ((this.CustomAttributeFilters == null && other.CustomAttributeFilters == null) || (this.CustomAttributeFilters?.Equals(other.CustomAttributeFilters) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 737510073;
            hashCode = HashCode.Combine(this.TextFilter, this.CategoryIds, this.StockLevels, this.EnabledLocationIds, this.Cursor, this.Limit, this.SortOrder);

            hashCode = HashCode.Combine(hashCode, this.ProductTypes, this.CustomAttributeFilters);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TextFilter = {(this.TextFilter == null ? "null" : this.TextFilter == string.Empty ? "" : this.TextFilter)}");
            toStringOutput.Add($"this.CategoryIds = {(this.CategoryIds == null ? "null" : $"[{string.Join(", ", this.CategoryIds)} ]")}");
            toStringOutput.Add($"this.StockLevels = {(this.StockLevels == null ? "null" : $"[{string.Join(", ", this.StockLevels)} ]")}");
            toStringOutput.Add($"this.EnabledLocationIds = {(this.EnabledLocationIds == null ? "null" : $"[{string.Join(", ", this.EnabledLocationIds)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
            toStringOutput.Add($"this.ProductTypes = {(this.ProductTypes == null ? "null" : $"[{string.Join(", ", this.ProductTypes)} ]")}");
            toStringOutput.Add($"this.CustomAttributeFilters = {(this.CustomAttributeFilters == null ? "null" : $"[{string.Join(", ", this.CustomAttributeFilters)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TextFilter(this.TextFilter)
                .CategoryIds(this.CategoryIds)
                .StockLevels(this.StockLevels)
                .EnabledLocationIds(this.EnabledLocationIds)
                .Cursor(this.Cursor)
                .Limit(this.Limit)
                .SortOrder(this.SortOrder)
                .ProductTypes(this.ProductTypes)
                .CustomAttributeFilters(this.CustomAttributeFilters);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string textFilter;
            private IList<string> categoryIds;
            private IList<string> stockLevels;
            private IList<string> enabledLocationIds;
            private string cursor;
            private int? limit;
            private string sortOrder;
            private IList<string> productTypes;
            private IList<Models.CustomAttributeFilter> customAttributeFilters;

             /// <summary>
             /// TextFilter.
             /// </summary>
             /// <param name="textFilter"> textFilter. </param>
             /// <returns> Builder. </returns>
            public Builder TextFilter(string textFilter)
            {
                this.textFilter = textFilter;
                return this;
            }

             /// <summary>
             /// CategoryIds.
             /// </summary>
             /// <param name="categoryIds"> categoryIds. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryIds(IList<string> categoryIds)
            {
                this.categoryIds = categoryIds;
                return this;
            }

             /// <summary>
             /// StockLevels.
             /// </summary>
             /// <param name="stockLevels"> stockLevels. </param>
             /// <returns> Builder. </returns>
            public Builder StockLevels(IList<string> stockLevels)
            {
                this.stockLevels = stockLevels;
                return this;
            }

             /// <summary>
             /// EnabledLocationIds.
             /// </summary>
             /// <param name="enabledLocationIds"> enabledLocationIds. </param>
             /// <returns> Builder. </returns>
            public Builder EnabledLocationIds(IList<string> enabledLocationIds)
            {
                this.enabledLocationIds = enabledLocationIds;
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
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

             /// <summary>
             /// ProductTypes.
             /// </summary>
             /// <param name="productTypes"> productTypes. </param>
             /// <returns> Builder. </returns>
            public Builder ProductTypes(IList<string> productTypes)
            {
                this.productTypes = productTypes;
                return this;
            }

             /// <summary>
             /// CustomAttributeFilters.
             /// </summary>
             /// <param name="customAttributeFilters"> customAttributeFilters. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributeFilters(IList<Models.CustomAttributeFilter> customAttributeFilters)
            {
                this.customAttributeFilters = customAttributeFilters;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchCatalogItemsRequest. </returns>
            public SearchCatalogItemsRequest Build()
            {
                return new SearchCatalogItemsRequest(
                    this.textFilter,
                    this.categoryIds,
                    this.stockLevels,
                    this.enabledLocationIds,
                    this.cursor,
                    this.limit,
                    this.sortOrder,
                    this.productTypes,
                    this.customAttributeFilters);
            }
        }
    }
}