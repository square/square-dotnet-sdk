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
    /// CatalogQuery.
    /// </summary>
    public class CatalogQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQuery"/> class.
        /// </summary>
        /// <param name="sortedAttributeQuery">sorted_attribute_query.</param>
        /// <param name="exactQuery">exact_query.</param>
        /// <param name="setQuery">set_query.</param>
        /// <param name="prefixQuery">prefix_query.</param>
        /// <param name="rangeQuery">range_query.</param>
        /// <param name="textQuery">text_query.</param>
        /// <param name="itemsForTaxQuery">items_for_tax_query.</param>
        /// <param name="itemsForModifierListQuery">items_for_modifier_list_query.</param>
        /// <param name="itemsForItemOptionsQuery">items_for_item_options_query.</param>
        /// <param name="itemVariationsForItemOptionValuesQuery">item_variations_for_item_option_values_query.</param>
        public CatalogQuery(
            Models.CatalogQuerySortedAttribute sortedAttributeQuery = null,
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
            this.SortedAttributeQuery = sortedAttributeQuery;
            this.ExactQuery = exactQuery;
            this.SetQuery = setQuery;
            this.PrefixQuery = prefixQuery;
            this.RangeQuery = rangeQuery;
            this.TextQuery = textQuery;
            this.ItemsForTaxQuery = itemsForTaxQuery;
            this.ItemsForModifierListQuery = itemsForModifierListQuery;
            this.ItemsForItemOptionsQuery = itemsForItemOptionsQuery;
            this.ItemVariationsForItemOptionValuesQuery = itemVariationsForItemOptionValuesQuery;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuery : ({string.Join(", ", toStringOutput)})";
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
            return obj is CatalogQuery other &&                ((this.SortedAttributeQuery == null && other.SortedAttributeQuery == null) || (this.SortedAttributeQuery?.Equals(other.SortedAttributeQuery) == true)) &&
                ((this.ExactQuery == null && other.ExactQuery == null) || (this.ExactQuery?.Equals(other.ExactQuery) == true)) &&
                ((this.SetQuery == null && other.SetQuery == null) || (this.SetQuery?.Equals(other.SetQuery) == true)) &&
                ((this.PrefixQuery == null && other.PrefixQuery == null) || (this.PrefixQuery?.Equals(other.PrefixQuery) == true)) &&
                ((this.RangeQuery == null && other.RangeQuery == null) || (this.RangeQuery?.Equals(other.RangeQuery) == true)) &&
                ((this.TextQuery == null && other.TextQuery == null) || (this.TextQuery?.Equals(other.TextQuery) == true)) &&
                ((this.ItemsForTaxQuery == null && other.ItemsForTaxQuery == null) || (this.ItemsForTaxQuery?.Equals(other.ItemsForTaxQuery) == true)) &&
                ((this.ItemsForModifierListQuery == null && other.ItemsForModifierListQuery == null) || (this.ItemsForModifierListQuery?.Equals(other.ItemsForModifierListQuery) == true)) &&
                ((this.ItemsForItemOptionsQuery == null && other.ItemsForItemOptionsQuery == null) || (this.ItemsForItemOptionsQuery?.Equals(other.ItemsForItemOptionsQuery) == true)) &&
                ((this.ItemVariationsForItemOptionValuesQuery == null && other.ItemVariationsForItemOptionValuesQuery == null) || (this.ItemVariationsForItemOptionValuesQuery?.Equals(other.ItemVariationsForItemOptionValuesQuery) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1871698487;
            hashCode = HashCode.Combine(this.SortedAttributeQuery, this.ExactQuery, this.SetQuery, this.PrefixQuery, this.RangeQuery, this.TextQuery, this.ItemsForTaxQuery);

            hashCode = HashCode.Combine(hashCode, this.ItemsForModifierListQuery, this.ItemsForItemOptionsQuery, this.ItemVariationsForItemOptionValuesQuery);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SortedAttributeQuery = {(this.SortedAttributeQuery == null ? "null" : this.SortedAttributeQuery.ToString())}");
            toStringOutput.Add($"this.ExactQuery = {(this.ExactQuery == null ? "null" : this.ExactQuery.ToString())}");
            toStringOutput.Add($"this.SetQuery = {(this.SetQuery == null ? "null" : this.SetQuery.ToString())}");
            toStringOutput.Add($"this.PrefixQuery = {(this.PrefixQuery == null ? "null" : this.PrefixQuery.ToString())}");
            toStringOutput.Add($"this.RangeQuery = {(this.RangeQuery == null ? "null" : this.RangeQuery.ToString())}");
            toStringOutput.Add($"this.TextQuery = {(this.TextQuery == null ? "null" : this.TextQuery.ToString())}");
            toStringOutput.Add($"this.ItemsForTaxQuery = {(this.ItemsForTaxQuery == null ? "null" : this.ItemsForTaxQuery.ToString())}");
            toStringOutput.Add($"this.ItemsForModifierListQuery = {(this.ItemsForModifierListQuery == null ? "null" : this.ItemsForModifierListQuery.ToString())}");
            toStringOutput.Add($"this.ItemsForItemOptionsQuery = {(this.ItemsForItemOptionsQuery == null ? "null" : this.ItemsForItemOptionsQuery.ToString())}");
            toStringOutput.Add($"this.ItemVariationsForItemOptionValuesQuery = {(this.ItemVariationsForItemOptionValuesQuery == null ? "null" : this.ItemVariationsForItemOptionValuesQuery.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SortedAttributeQuery(this.SortedAttributeQuery)
                .ExactQuery(this.ExactQuery)
                .SetQuery(this.SetQuery)
                .PrefixQuery(this.PrefixQuery)
                .RangeQuery(this.RangeQuery)
                .TextQuery(this.TextQuery)
                .ItemsForTaxQuery(this.ItemsForTaxQuery)
                .ItemsForModifierListQuery(this.ItemsForModifierListQuery)
                .ItemsForItemOptionsQuery(this.ItemsForItemOptionsQuery)
                .ItemVariationsForItemOptionValuesQuery(this.ItemVariationsForItemOptionValuesQuery);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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

             /// <summary>
             /// SortedAttributeQuery.
             /// </summary>
             /// <param name="sortedAttributeQuery"> sortedAttributeQuery. </param>
             /// <returns> Builder. </returns>
            public Builder SortedAttributeQuery(Models.CatalogQuerySortedAttribute sortedAttributeQuery)
            {
                this.sortedAttributeQuery = sortedAttributeQuery;
                return this;
            }

             /// <summary>
             /// ExactQuery.
             /// </summary>
             /// <param name="exactQuery"> exactQuery. </param>
             /// <returns> Builder. </returns>
            public Builder ExactQuery(Models.CatalogQueryExact exactQuery)
            {
                this.exactQuery = exactQuery;
                return this;
            }

             /// <summary>
             /// SetQuery.
             /// </summary>
             /// <param name="setQuery"> setQuery. </param>
             /// <returns> Builder. </returns>
            public Builder SetQuery(Models.CatalogQuerySet setQuery)
            {
                this.setQuery = setQuery;
                return this;
            }

             /// <summary>
             /// PrefixQuery.
             /// </summary>
             /// <param name="prefixQuery"> prefixQuery. </param>
             /// <returns> Builder. </returns>
            public Builder PrefixQuery(Models.CatalogQueryPrefix prefixQuery)
            {
                this.prefixQuery = prefixQuery;
                return this;
            }

             /// <summary>
             /// RangeQuery.
             /// </summary>
             /// <param name="rangeQuery"> rangeQuery. </param>
             /// <returns> Builder. </returns>
            public Builder RangeQuery(Models.CatalogQueryRange rangeQuery)
            {
                this.rangeQuery = rangeQuery;
                return this;
            }

             /// <summary>
             /// TextQuery.
             /// </summary>
             /// <param name="textQuery"> textQuery. </param>
             /// <returns> Builder. </returns>
            public Builder TextQuery(Models.CatalogQueryText textQuery)
            {
                this.textQuery = textQuery;
                return this;
            }

             /// <summary>
             /// ItemsForTaxQuery.
             /// </summary>
             /// <param name="itemsForTaxQuery"> itemsForTaxQuery. </param>
             /// <returns> Builder. </returns>
            public Builder ItemsForTaxQuery(Models.CatalogQueryItemsForTax itemsForTaxQuery)
            {
                this.itemsForTaxQuery = itemsForTaxQuery;
                return this;
            }

             /// <summary>
             /// ItemsForModifierListQuery.
             /// </summary>
             /// <param name="itemsForModifierListQuery"> itemsForModifierListQuery. </param>
             /// <returns> Builder. </returns>
            public Builder ItemsForModifierListQuery(Models.CatalogQueryItemsForModifierList itemsForModifierListQuery)
            {
                this.itemsForModifierListQuery = itemsForModifierListQuery;
                return this;
            }

             /// <summary>
             /// ItemsForItemOptionsQuery.
             /// </summary>
             /// <param name="itemsForItemOptionsQuery"> itemsForItemOptionsQuery. </param>
             /// <returns> Builder. </returns>
            public Builder ItemsForItemOptionsQuery(Models.CatalogQueryItemsForItemOptions itemsForItemOptionsQuery)
            {
                this.itemsForItemOptionsQuery = itemsForItemOptionsQuery;
                return this;
            }

             /// <summary>
             /// ItemVariationsForItemOptionValuesQuery.
             /// </summary>
             /// <param name="itemVariationsForItemOptionValuesQuery"> itemVariationsForItemOptionValuesQuery. </param>
             /// <returns> Builder. </returns>
            public Builder ItemVariationsForItemOptionValuesQuery(Models.CatalogQueryItemVariationsForItemOptionValues itemVariationsForItemOptionValuesQuery)
            {
                this.itemVariationsForItemOptionValuesQuery = itemVariationsForItemOptionValuesQuery;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQuery. </returns>
            public CatalogQuery Build()
            {
                return new CatalogQuery(
                    this.sortedAttributeQuery,
                    this.exactQuery,
                    this.setQuery,
                    this.prefixQuery,
                    this.rangeQuery,
                    this.textQuery,
                    this.itemsForTaxQuery,
                    this.itemsForModifierListQuery,
                    this.itemsForItemOptionsQuery,
                    this.itemVariationsForItemOptionValuesQuery);
            }
        }
    }
}