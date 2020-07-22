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
        [JsonProperty("sorted_attribute_query")]
        public Models.CatalogQuerySortedAttribute SortedAttributeQuery { get; }

        /// <summary>
        /// The query filter to return the serch result by exact match of the specified attribute name and value.
        /// </summary>
        [JsonProperty("exact_query")]
        public Models.CatalogQueryExact ExactQuery { get; }

        /// <summary>
        /// The query filter to return the search result whose named attribute values are prefixed by the specified attribute value.
        /// </summary>
        [JsonProperty("prefix_query")]
        public Models.CatalogQueryPrefix PrefixQuery { get; }

        /// <summary>
        /// The query filter to return the search result whose named attribute values fall between the specified range.
        /// </summary>
        [JsonProperty("range_query")]
        public Models.CatalogQueryRange RangeQuery { get; }

        /// <summary>
        /// The query filter to return the search result whose searchable attribute values contain all of the specified keywords or tokens, independent of the token order or case.
        /// </summary>
        [JsonProperty("text_query")]
        public Models.CatalogQueryText TextQuery { get; }

        /// <summary>
        /// The query filter to return the items containing the specified tax IDs.
        /// </summary>
        [JsonProperty("items_for_tax_query")]
        public Models.CatalogQueryItemsForTax ItemsForTaxQuery { get; }

        /// <summary>
        /// The query filter to return the items containing the specified modifier list IDs.
        /// </summary>
        [JsonProperty("items_for_modifier_list_query")]
        public Models.CatalogQueryItemsForModifierList ItemsForModifierListQuery { get; }

        /// <summary>
        /// The query filter to return the items containing the specified item option IDs.
        /// </summary>
        [JsonProperty("items_for_item_options_query")]
        public Models.CatalogQueryItemsForItemOptions ItemsForItemOptionsQuery { get; }

        /// <summary>
        /// The query filter to return the item variations containing the specified item option value IDs.
        /// </summary>
        [JsonProperty("item_variations_for_item_option_values_query")]
        public Models.CatalogQueryItemVariationsForItemOptionValues ItemVariationsForItemOptionValuesQuery { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SortedAttributeQuery(SortedAttributeQuery)
                .ExactQuery(ExactQuery)
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
            private Models.CatalogQueryPrefix prefixQuery;
            private Models.CatalogQueryRange rangeQuery;
            private Models.CatalogQueryText textQuery;
            private Models.CatalogQueryItemsForTax itemsForTaxQuery;
            private Models.CatalogQueryItemsForModifierList itemsForModifierListQuery;
            private Models.CatalogQueryItemsForItemOptions itemsForItemOptionsQuery;
            private Models.CatalogQueryItemVariationsForItemOptionValues itemVariationsForItemOptionValuesQuery;

            public Builder() { }
            public Builder SortedAttributeQuery(Models.CatalogQuerySortedAttribute value)
            {
                sortedAttributeQuery = value;
                return this;
            }

            public Builder ExactQuery(Models.CatalogQueryExact value)
            {
                exactQuery = value;
                return this;
            }

            public Builder PrefixQuery(Models.CatalogQueryPrefix value)
            {
                prefixQuery = value;
                return this;
            }

            public Builder RangeQuery(Models.CatalogQueryRange value)
            {
                rangeQuery = value;
                return this;
            }

            public Builder TextQuery(Models.CatalogQueryText value)
            {
                textQuery = value;
                return this;
            }

            public Builder ItemsForTaxQuery(Models.CatalogQueryItemsForTax value)
            {
                itemsForTaxQuery = value;
                return this;
            }

            public Builder ItemsForModifierListQuery(Models.CatalogQueryItemsForModifierList value)
            {
                itemsForModifierListQuery = value;
                return this;
            }

            public Builder ItemsForItemOptionsQuery(Models.CatalogQueryItemsForItemOptions value)
            {
                itemsForItemOptionsQuery = value;
                return this;
            }

            public Builder ItemVariationsForItemOptionValuesQuery(Models.CatalogQueryItemVariationsForItemOptionValues value)
            {
                itemVariationsForItemOptionValuesQuery = value;
                return this;
            }

            public CatalogQuery Build()
            {
                return new CatalogQuery(sortedAttributeQuery,
                    exactQuery,
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