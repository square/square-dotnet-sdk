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
        [JsonProperty("text_filter")]
        public string TextFilter { get; }

        /// <summary>
        /// The category id query expression to return items containing the specified category IDs.
        /// </summary>
        [JsonProperty("category_ids")]
        public IList<string> CategoryIds { get; }

        /// <summary>
        /// The stock-level query expression to return item variations with the specified stock levels.
        /// See [SearchCatalogItemsRequestStockLevel](#type-searchcatalogitemsrequeststocklevel) for possible values
        /// </summary>
        [JsonProperty("stock_levels")]
        public IList<string> StockLevels { get; }

        /// <summary>
        /// The enabled-location query expression to return items and item variations having specified enabled locations.
        /// </summary>
        [JsonProperty("enabled_location_ids")]
        public IList<string> EnabledLocationIds { get; }

        /// <summary>
        /// The pagination token, returned in the previous response, used to fetch the next batch of pending results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return per page. The default value is 100.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <summary>
        /// The product types query expression to return items or item variations having the specified product types.
        /// See [CatalogItemProductType](#type-catalogitemproducttype) for possible values
        /// </summary>
        [JsonProperty("product_types")]
        public IList<string> ProductTypes { get; }

        /// <summary>
        /// The customer-attribute filter to return items or item variations matching the specified
        /// custom attribute expressions. A maximum number of 10 custom attribute expressions are supported in
        /// a single call to the [SearchCatalogItems](#endpoint-Catalog-SearchCatalogItems) endpoint.
        /// </summary>
        [JsonProperty("custom_attribute_filters")]
        public IList<Models.CustomAttributeFilter> CustomAttributeFilters { get; }

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
            private IList<string> categoryIds = new List<string>();
            private IList<string> stockLevels = new List<string>();
            private IList<string> enabledLocationIds = new List<string>();
            private string cursor;
            private int? limit;
            private string sortOrder;
            private IList<string> productTypes = new List<string>();
            private IList<Models.CustomAttributeFilter> customAttributeFilters = new List<Models.CustomAttributeFilter>();

            public Builder() { }
            public Builder TextFilter(string value)
            {
                textFilter = value;
                return this;
            }

            public Builder CategoryIds(IList<string> value)
            {
                categoryIds = value;
                return this;
            }

            public Builder StockLevels(IList<string> value)
            {
                stockLevels = value;
                return this;
            }

            public Builder EnabledLocationIds(IList<string> value)
            {
                enabledLocationIds = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public Builder ProductTypes(IList<string> value)
            {
                productTypes = value;
                return this;
            }

            public Builder CustomAttributeFilters(IList<Models.CustomAttributeFilter> value)
            {
                customAttributeFilters = value;
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