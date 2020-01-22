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
    public class CatalogQueryFilteredItems 
    {
        public CatalogQueryFilteredItems(string textFilter = null,
            bool? searchVendorCode = null,
            IList<string> categoryIds = null,
            IList<string> stockLevels = null,
            IList<string> enabledLocationIds = null,
            IList<string> vendorIds = null,
            IList<string> productTypes = null,
            IList<Models.CatalogQueryFilteredItemsCustomAttributeFilter> customAttributeFilters = null,
            IList<string> doesNotExist = null,
            string sortOrder = null)
        {
            TextFilter = textFilter;
            SearchVendorCode = searchVendorCode;
            CategoryIds = categoryIds;
            StockLevels = stockLevels;
            EnabledLocationIds = enabledLocationIds;
            VendorIds = vendorIds;
            ProductTypes = productTypes;
            CustomAttributeFilters = customAttributeFilters;
            DoesNotExist = doesNotExist;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// Getter for text_filter
        /// </summary>
        [JsonProperty("text_filter")]
        public string TextFilter { get; }

        /// <summary>
        /// Getter for search_vendor_code
        /// </summary>
        [JsonProperty("search_vendor_code")]
        public bool? SearchVendorCode { get; }

        /// <summary>
        /// Getter for category_ids
        /// </summary>
        [JsonProperty("category_ids")]
        public IList<string> CategoryIds { get; }

        /// <summary>
        /// See [CatalogQueryFilteredItemsStockLevel](#type-catalogqueryfiltereditemsstocklevel) for possible values
        /// </summary>
        [JsonProperty("stock_levels")]
        public IList<string> StockLevels { get; }

        /// <summary>
        /// Getter for enabled_location_ids
        /// </summary>
        [JsonProperty("enabled_location_ids")]
        public IList<string> EnabledLocationIds { get; }

        /// <summary>
        /// Getter for vendor_ids
        /// </summary>
        [JsonProperty("vendor_ids")]
        public IList<string> VendorIds { get; }

        /// <summary>
        /// See [CatalogItemProductType](#type-catalogitemproducttype) for possible values
        /// </summary>
        [JsonProperty("product_types")]
        public IList<string> ProductTypes { get; }

        /// <summary>
        /// Getter for custom_attribute_filters
        /// </summary>
        [JsonProperty("custom_attribute_filters")]
        public IList<Models.CatalogQueryFilteredItemsCustomAttributeFilter> CustomAttributeFilters { get; }

        /// <summary>
        /// See [CatalogQueryFilteredItemsNullableAttribute](#type-catalogqueryfiltereditemsnullableattribute) for possible values
        /// </summary>
        [JsonProperty("does_not_exist")]
        public IList<string> DoesNotExist { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TextFilter(TextFilter)
                .SearchVendorCode(SearchVendorCode)
                .CategoryIds(CategoryIds)
                .StockLevels(StockLevels)
                .EnabledLocationIds(EnabledLocationIds)
                .VendorIds(VendorIds)
                .ProductTypes(ProductTypes)
                .CustomAttributeFilters(CustomAttributeFilters)
                .DoesNotExist(DoesNotExist)
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string textFilter;
            private bool? searchVendorCode;
            private IList<string> categoryIds = new List<string>();
            private IList<string> stockLevels = new List<string>();
            private IList<string> enabledLocationIds = new List<string>();
            private IList<string> vendorIds = new List<string>();
            private IList<string> productTypes = new List<string>();
            private IList<Models.CatalogQueryFilteredItemsCustomAttributeFilter> customAttributeFilters = new List<Models.CatalogQueryFilteredItemsCustomAttributeFilter>();
            private IList<string> doesNotExist = new List<string>();
            private string sortOrder;

            public Builder() { }
            public Builder TextFilter(string value)
            {
                textFilter = value;
                return this;
            }

            public Builder SearchVendorCode(bool? value)
            {
                searchVendorCode = value;
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

            public Builder VendorIds(IList<string> value)
            {
                vendorIds = value;
                return this;
            }

            public Builder ProductTypes(IList<string> value)
            {
                productTypes = value;
                return this;
            }

            public Builder CustomAttributeFilters(IList<Models.CatalogQueryFilteredItemsCustomAttributeFilter> value)
            {
                customAttributeFilters = value;
                return this;
            }

            public Builder DoesNotExist(IList<string> value)
            {
                doesNotExist = value;
                return this;
            }

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public CatalogQueryFilteredItems Build()
            {
                return new CatalogQueryFilteredItems(textFilter,
                    searchVendorCode,
                    categoryIds,
                    stockLevels,
                    enabledLocationIds,
                    vendorIds,
                    productTypes,
                    customAttributeFilters,
                    doesNotExist,
                    sortOrder);
            }
        }
    }
}