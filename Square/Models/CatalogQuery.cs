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
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("sorted_attribute_query")]
        public Models.CatalogQuerySortedAttribute SortedAttributeQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("exact_query")]
        public Models.CatalogQueryExact ExactQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("prefix_query")]
        public Models.CatalogQueryPrefix PrefixQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("range_query")]
        public Models.CatalogQueryRange RangeQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("text_query")]
        public Models.CatalogQueryText TextQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("items_for_tax_query")]
        public Models.CatalogQueryItemsForTax ItemsForTaxQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("items_for_modifier_list_query")]
        public Models.CatalogQueryItemsForModifierList ItemsForModifierListQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("items_for_item_options_query")]
        public Models.CatalogQueryItemsForItemOptions ItemsForItemOptionsQuery { get; }

        /// <summary>
        /// TODO: Write general description for this method
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