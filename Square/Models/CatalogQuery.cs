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
    public class CatalogQuery 
    {
        public CatalogQuery(Models.CatalogQuerySortedAttribute sortedAttributeQuery = null,
            Models.CatalogQueryExact exactQuery = null,
            Models.CatalogQuerySet setQuery = null,
            Models.CatalogQueryPrefix prefixQuery = null,
            Models.CatalogQueryRange rangeQuery = null,
            Models.CatalogQueryText textQuery = null,
            Models.CatalogQueryItemsForTax itemsForTaxQuery = null,
            Models.CatalogQueryItemsForModifierList itemsForModifierListQuery = null,
            Models.CatalogQueryItemsForItemOptions itemsForItemOptionsQuery = null,
            Models.CatalogQueryItemVariationsForItemOptionValues itemVariationsForItemOptionValuesQuery = null)
        {
            SortedAttributeQuery = sortedAttributeQuery;
            ExactQuery = exactQuery;
            SetQuery = setQuery;
            PrefixQuery = prefixQuery;
            RangeQuery = rangeQuery;
            TextQuery = textQuery;
            ItemsForTaxQuery = itemsForTaxQuery;
            ItemsForModifierListQuery = itemsForModifierListQuery;
            ItemsForItemOptionsQuery = itemsForItemOptionsQuery;
            ItemVariationsForItemOptionValuesQuery = itemVariationsForItemOptionValuesQuery;
        }

        /// <summary>
        /// The query expression to specify the key to sort search results.
        /// </summary>
        [JsonProperty("sorted_attribute_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQuerySortedAttribute SortedAttributeQuery { get; }

        /// <summary>
        /// The query filter to return the search result by exact match of the specified attribute name and value.
        /// </summary>
        [JsonProperty("exact_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryExact ExactQuery { get; }

        /// <summary>
        /// The query filter to return the search result(s) by exact match of the specified `attribute_name` and any of
        /// the `attribute_values`.
        /// </summary>
        [JsonProperty("set_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQuerySet SetQuery { get; }

        /// <summary>
        /// The query filter to return the search result whose named attribute values are prefixed by the specified attribute value.
        /// </summary>
        [JsonProperty("prefix_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryPrefix PrefixQuery { get; }

        /// <summary>
        /// The query filter to return the search result whose named attribute values fall between the specified range.
        /// </summary>
        [JsonProperty("range_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryRange RangeQuery { get; }

        /// <summary>
        /// The query filter to return the search result whose searchable attribute values contain all of the specified keywords or tokens, independent of the token order or case.
        /// </summary>
        [JsonProperty("text_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryText TextQuery { get; }

        /// <summary>
        /// The query filter to return the items containing the specified tax IDs.
        /// </summary>
        [JsonProperty("items_for_tax_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryItemsForTax ItemsForTaxQuery { get; }

        /// <summary>
        /// The query filter to return the items containing the specified modifier list IDs.
        /// </summary>
        [JsonProperty("items_for_modifier_list_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryItemsForModifierList ItemsForModifierListQuery { get; }

        /// <summary>
        /// The query filter to return the items containing the specified item option IDs.
        /// </summary>
        [JsonProperty("items_for_item_options_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryItemsForItemOptions ItemsForItemOptionsQuery { get; }

        /// <summary>
        /// The query filter to return the item variations containing the specified item option value IDs.
        /// </summary>
        [JsonProperty("item_variations_for_item_option_values_query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQueryItemVariationsForItemOptionValues ItemVariationsForItemOptionValuesQuery { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SortedAttributeQuery(SortedAttributeQuery)
                .ExactQuery(ExactQuery)
                .SetQuery(SetQuery)
                .PrefixQuery(PrefixQuery)
                .RangeQuery(RangeQuery)
                .TextQuery(TextQuery)
                .ItemsForTaxQuery(ItemsForTaxQuery)
                .ItemsForModifierListQuery(ItemsForModifierListQuery)
                .ItemsForItemOptionsQuery(ItemsForItemOptionsQuery)
                .ItemVariationsForItemOptionValuesQuery(ItemVariationsForItemOptionValuesQuery);
            return builder;
        }

        public class Builder
        {
            private Models.CatalogQuerySortedAttribute sortedAttributeQuery;
            private Models.CatalogQueryExact exactQuery;
            private Models.CatalogQuerySet setQuery;
            private Models.CatalogQueryPrefix prefixQuery;
            private Models.CatalogQueryRange rangeQuery;
            private Models.CatalogQueryText textQuery;
            private Models.CatalogQueryItemsForTax itemsForTaxQuery;
            private Models.CatalogQueryItemsForModifierList itemsForModifierListQuery;
            private Models.CatalogQueryItemsForItemOptions itemsForItemOptionsQuery;
            private Models.CatalogQueryItemVariationsForItemOptionValues itemVariationsForItemOptionValuesQuery;



            public Builder SortedAttributeQuery(Models.CatalogQuerySortedAttribute sortedAttributeQuery)
            {
                this.sortedAttributeQuery = sortedAttributeQuery;
                return this;
            }

            public Builder ExactQuery(Models.CatalogQueryExact exactQuery)
            {
                this.exactQuery = exactQuery;
                return this;
            }

            public Builder SetQuery(Models.CatalogQuerySet setQuery)
            {
                this.setQuery = setQuery;
                return this;
            }

            public Builder PrefixQuery(Models.CatalogQueryPrefix prefixQuery)
            {
                this.prefixQuery = prefixQuery;
                return this;
            }

            public Builder RangeQuery(Models.CatalogQueryRange rangeQuery)
            {
                this.rangeQuery = rangeQuery;
                return this;
            }

            public Builder TextQuery(Models.CatalogQueryText textQuery)
            {
                this.textQuery = textQuery;
                return this;
            }

            public Builder ItemsForTaxQuery(Models.CatalogQueryItemsForTax itemsForTaxQuery)
            {
                this.itemsForTaxQuery = itemsForTaxQuery;
                return this;
            }

            public Builder ItemsForModifierListQuery(Models.CatalogQueryItemsForModifierList itemsForModifierListQuery)
            {
                this.itemsForModifierListQuery = itemsForModifierListQuery;
                return this;
            }

            public Builder ItemsForItemOptionsQuery(Models.CatalogQueryItemsForItemOptions itemsForItemOptionsQuery)
            {
                this.itemsForItemOptionsQuery = itemsForItemOptionsQuery;
                return this;
            }

            public Builder ItemVariationsForItemOptionValuesQuery(Models.CatalogQueryItemVariationsForItemOptionValues itemVariationsForItemOptionValuesQuery)
            {
                this.itemVariationsForItemOptionValuesQuery = itemVariationsForItemOptionValuesQuery;
                return this;
            }

            public CatalogQuery Build()
            {
                return new CatalogQuery(sortedAttributeQuery,
                    exactQuery,
                    setQuery,
                    prefixQuery,
                    rangeQuery,
                    textQuery,
                    itemsForTaxQuery,
                    itemsForModifierListQuery,
                    itemsForItemOptionsQuery,
                    itemVariationsForItemOptionValuesQuery);
            }
        }
    }
}