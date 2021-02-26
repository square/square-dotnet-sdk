
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOption : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"DisplayName = {(DisplayName == null ? "null" : DisplayName == string.Empty ? "" : DisplayName)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"ShowColors = {(ShowColors == null ? "null" : ShowColors.ToString())}");
            toStringOutput.Add($"Values = {(Values == null ? "null" : $"[{ string.Join(", ", Values)} ]")}");
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

            return obj is CatalogItemOption other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((DisplayName == null && other.DisplayName == null) || (DisplayName?.Equals(other.DisplayName) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((ShowColors == null && other.ShowColors == null) || (ShowColors?.Equals(other.ShowColors) == true)) &&
                ((Values == null && other.Values == null) || (Values?.Equals(other.Values) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1353145437;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (DisplayName != null)
            {
               hashCode += DisplayName.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (ShowColors != null)
            {
               hashCode += ShowColors.GetHashCode();
            }

            if (Values != null)
            {
               hashCode += Values.GetHashCode();
            }

            return hashCode;
        }

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