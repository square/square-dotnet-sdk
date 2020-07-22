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
    public class CatalogItemOption 
    {
        public CatalogItemOption(string name = null,
            string displayName = null,
            string description = null,
            bool? showColors = null,
            IList<Models.CatalogObject> values = null,
            long? itemCount = null)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            ShowColors = showColors;
            Values = values;
            ItemCount = itemCount;
        }

        /// <summary>
        /// The item option's display name for the seller. Must be unique across
        /// all item options. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The item option's display name for the customer. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; }

        /// <summary>
        /// The item option's human-readable description. Displayed in the Square
        /// Point of Sale app for the seller and in the Online Store or on receipts for
        /// the buyer. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// If true, display colors for entries in `values` when present.
        /// </summary>
        [JsonProperty("show_colors")]
        public bool? ShowColors { get; }

        /// <summary>
        /// A list of CatalogObjects containing the
        /// `CatalogItemOptionValue`s for this item.
        /// </summary>
        [JsonProperty("values")]
        public IList<Models.CatalogObject> Values { get; }

        /// <summary>
        /// The number of `CatalogItem`s currently associated
        /// with this item option. Present only if the `include_counts` was specified
        /// in the request. Any count over 100 will be returned as `100`.
        /// </summary>
        [JsonProperty("item_count")]
        public long? ItemCount { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .DisplayName(DisplayName)
                .Description(Description)
                .ShowColors(ShowColors)
                .Values(Values)
                .ItemCount(ItemCount);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string displayName;
            private string description;
            private bool? showColors;
            private IList<Models.CatalogObject> values = new List<Models.CatalogObject>();
            private long? itemCount;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder DisplayName(string value)
            {
                displayName = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder ShowColors(bool? value)
            {
                showColors = value;
                return this;
            }

            public Builder Values(IList<Models.CatalogObject> value)
            {
                values = value;
                return this;
            }

            public Builder ItemCount(long? value)
            {
                itemCount = value;
                return this;
            }

            public CatalogItemOption Build()
            {
                return new CatalogItemOption(name,
                    displayName,
                    description,
                    showColors,
                    values,
                    itemCount);
            }
        }
    }
}