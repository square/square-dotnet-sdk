
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
    public class SearchCatalogItemsRequest 
    {
        public SearchCatalogItemsRequest(string textFilter = null,
            IList<string> categoryIds = null,
            IList<string> stockLevels = null,
            IList<string> enabledLocationIds = null,
            string cursor = null,
            int? limit = null,
            string sortOrder = null,
            IList<string> productTypes = null,
            IList<Models.CustomAttributeFilter> customAttributeFilters = null)
        {
            TextFilter = textFilter;
            CategoryIds = categoryIds;
            StockLevels = stockLevels;
            EnabledLocationIds = enabledLocationIds;
            Cursor = cursor;
            Limit = limit;
            SortOrder = sortOrder;
            ProductTypes = productTypes;
            CustomAttributeFilters = customAttributeFilters;
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
        /// a single call to the [SearchCatalogItems](#endpoint-Catalog-SearchCatalogItems) endpoint.
        /// </summary>
        [JsonProperty("custom_attribute_filters", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomAttributeFilter> CustomAttributeFilters { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogItemsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TextFilter = {(TextFilter == null ? "null" : TextFilter == string.Empty ? "" : TextFilter)}");
            toStringOutput.Add($"CategoryIds = {(CategoryIds == null ? "null" : $"[{ string.Join(", ", CategoryIds)} ]")}");
            toStringOutput.Add($"StockLevels = {(StockLevels == null ? "null" : $"[{ string.Join(", ", StockLevels)} ]")}");
            toStringOutput.Add($"EnabledLocationIds = {(EnabledLocationIds == null ? "null" : $"[{ string.Join(", ", EnabledLocationIds)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
            toStringOutput.Add($"SortOrder = {(SortOrder == null ? "null" : SortOrder.ToString())}");
            toStringOutput.Add($"ProductTypes = {(ProductTypes == null ? "null" : $"[{ string.Join(", ", ProductTypes)} ]")}");
            toStringOutput.Add($"CustomAttributeFilters = {(CustomAttributeFilters == null ? "null" : $"[{ string.Join(", ", CustomAttributeFilters)} ]")}");
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

            return obj is SearchCatalogItemsRequest other &&
                ((TextFilter == null && other.TextFilter == null) || (TextFilter?.Equals(other.TextFilter) == true)) &&
                ((CategoryIds == null && other.CategoryIds == null) || (CategoryIds?.Equals(other.CategoryIds) == true)) &&
                ((StockLevels == null && other.StockLevels == null) || (StockLevels?.Equals(other.StockLevels) == true)) &&
                ((EnabledLocationIds == null && other.EnabledLocationIds == null) || (EnabledLocationIds?.Equals(other.EnabledLocationIds) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((SortOrder == null && other.SortOrder == null) || (SortOrder?.Equals(other.SortOrder) == true)) &&
                ((ProductTypes == null && other.ProductTypes == null) || (ProductTypes?.Equals(other.ProductTypes) == true)) &&
                ((CustomAttributeFilters == null && other.CustomAttributeFilters == null) || (CustomAttributeFilters?.Equals(other.CustomAttributeFilters) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 737510073;

            if (TextFilter != null)
            {
               hashCode += TextFilter.GetHashCode();
            }

            if (CategoryIds != null)
            {
               hashCode += CategoryIds.GetHashCode();
            }

            if (StockLevels != null)
            {
               hashCode += StockLevels.GetHashCode();
            }

            if (EnabledLocationIds != null)
            {
               hashCode += EnabledLocationIds.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            if (SortOrder != null)
            {
               hashCode += SortOrder.GetHashCode();
            }

            if (ProductTypes != null)
            {
               hashCode += ProductTypes.GetHashCode();
            }

            if (CustomAttributeFilters != null)
            {
               hashCode += CustomAttributeFilters.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TextFilter(TextFilter)
                .CategoryIds(CategoryIds)
                .StockLevels(StockLevels)
                .EnabledLocationIds(EnabledLocationIds)
                .Cursor(Cursor)
                .Limit(Limit)
                .SortOrder(SortOrder)
                .ProductTypes(ProductTypes)
                .CustomAttributeFilters(CustomAttributeFilters);
            return builder;
        }

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



            public Builder TextFilter(string textFilter)
            {
                this.textFilter = textFilter;
                return this;
            }

            public Builder CategoryIds(IList<string> categoryIds)
            {
                this.categoryIds = categoryIds;
                return this;
            }

            public Builder StockLevels(IList<string> stockLevels)
            {
                this.stockLevels = stockLevels;
                return this;
            }

            public Builder EnabledLocationIds(IList<string> enabledLocationIds)
            {
                this.enabledLocationIds = enabledLocationIds;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            public Builder ProductTypes(IList<string> productTypes)
            {
                this.productTypes = productTypes;
                return this;
            }

            public Builder CustomAttributeFilters(IList<Models.CustomAttributeFilter> customAttributeFilters)
            {
                this.customAttributeFilters = customAttributeFilters;
                return this;
            }

            public SearchCatalogItemsRequest Build()
            {
                return new SearchCatalogItemsRequest(textFilter,
                    categoryIds,
                    stockLevels,
                    enabledLocationIds,
                    cursor,
                    limit,
                    sortOrder,
                    productTypes,
                    customAttributeFilters);
            }
        }
    }
}