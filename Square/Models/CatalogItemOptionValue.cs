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
    public class CatalogItemOptionValue 
    {
        public CatalogItemOptionValue(string itemOptionId = null,
            string name = null,
            string description = null,
            string color = null,
            int? ordinal = null,
            long? itemVariationCount = null)
        {
            ItemOptionId = itemOptionId;
            Name = name;
            Description = description;
            Color = color;
            Ordinal = ordinal;
            ItemVariationCount = itemVariationCount;
        }

        /// <summary>
        /// Unique ID of the associated item option.
        /// </summary>
        [JsonProperty("item_option_id")]
        public string ItemOptionId { get; }

        /// <summary>
        /// Name of this item option value. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A human-readable description for the option value. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The HTML-supported hex color for the item option (e.g., "#ff8d4e85").
        /// Only displayed if `show_colors` is enabled on the parent `ItemOption`. When
        /// left unset, `color` defaults to white ("#ffffff") when `show_colors` is
        /// enabled on the parent `ItemOption`.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; }

        /// <summary>
        /// Determines where this option value appears in a list of option values.
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// The number of `CatalogItemVariation`s that
        /// currently use this item option value. Present only if `retrieve_counts`
        /// was specified on the request used to retrieve the parent item option of this
        /// value.
        /// </summary>
        [JsonProperty("item_variation_count")]
        public long? ItemVariationCount { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(ItemOptionId)
                .Name(Name)
                .Description(Description)
                .Color(Color)
                .Ordinal(Ordinal)
                .ItemVariationCount(ItemVariationCount);
            return builder;
        }

        public class Builder
        {
            private string itemOptionId;
            private string name;
            private string description;
            private string color;
            private int? ordinal;
            private long? itemVariationCount;

            public Builder() { }
            public Builder ItemOptionId(string value)
            {
                itemOptionId = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder Color(string value)
            {
                color = value;
                return this;
            }

            public Builder Ordinal(int? value)
            {
                ordinal = value;
                return this;
            }

            public Builder ItemVariationCount(long? value)
            {
                itemVariationCount = value;
                return this;
            }

            public CatalogItemOptionValue Build()
            {
                return new CatalogItemOptionValue(itemOptionId,
                    name,
                    description,
                    color,
                    ordinal,
                    itemVariationCount);
            }
        }
    }
}