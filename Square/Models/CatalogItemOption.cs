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
            IList<Models.CatalogObject> values = null)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            ShowColors = showColors;
            Values = values;
        }

        /// <summary>
        /// The item option's display name for the seller. Must be unique across
        /// all item options. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The item option's display name for the customer. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; }

        /// <summary>
        /// The item option's human-readable description. Displayed in the Square
        /// Point of Sale app for the seller and in the Online Store or on receipts for
        /// the buyer. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// If true, display colors for entries in `values` when present.
        /// </summary>
        [JsonProperty("show_colors", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowColors { get; }

        /// <summary>
        /// A list of CatalogObjects containing the
        /// `CatalogItemOptionValue`s for this item.
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Values { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .DisplayName(DisplayName)
                .Description(Description)
                .ShowColors(ShowColors)
                .Values(Values);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string displayName;
            private string description;
            private bool? showColors;
            private IList<Models.CatalogObject> values;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder DisplayName(string displayName)
            {
                this.displayName = displayName;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder ShowColors(bool? showColors)
            {
                this.showColors = showColors;
                return this;
            }

            public Builder Values(IList<Models.CatalogObject> values)
            {
                this.values = values;
                return this;
            }

            public CatalogItemOption Build()
            {
                return new CatalogItemOption(name,
                    displayName,
                    description,
                    showColors,
                    values);
            }
        }
    }
}