
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
            int? ordinal = null)
        {
            ItemOptionId = itemOptionId;
            Name = name;
            Description = description;
            Color = color;
            Ordinal = ordinal;
        }

        /// <summary>
        /// Unique ID of the associated item option.
        /// </summary>
        [JsonProperty("item_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemOptionId { get; }

        /// <summary>
        /// Name of this item option value. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// A human-readable description for the option value. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The HTML-supported hex color for the item option (e.g., "#ff8d4e85").
        /// Only displayed if `show_colors` is enabled on the parent `ItemOption`. When
        /// left unset, `color` defaults to white ("#ffffff") when `show_colors` is
        /// enabled on the parent `ItemOption`.
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; }

        /// <summary>
        /// Determines where this option value appears in a list of option values.
        /// </summary>
        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordinal { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionValue : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemOptionId = {(ItemOptionId == null ? "null" : ItemOptionId == string.Empty ? "" : ItemOptionId)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"Color = {(Color == null ? "null" : Color == string.Empty ? "" : Color)}");
            toStringOutput.Add($"Ordinal = {(Ordinal == null ? "null" : Ordinal.ToString())}");
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

            return obj is CatalogItemOptionValue other &&
                ((ItemOptionId == null && other.ItemOptionId == null) || (ItemOptionId?.Equals(other.ItemOptionId) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((Color == null && other.Color == null) || (Color?.Equals(other.Color) == true)) &&
                ((Ordinal == null && other.Ordinal == null) || (Ordinal?.Equals(other.Ordinal) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1107154058;

            if (ItemOptionId != null)
            {
               hashCode += ItemOptionId.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (Color != null)
            {
               hashCode += Color.GetHashCode();
            }

            if (Ordinal != null)
            {
               hashCode += Ordinal.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(ItemOptionId)
                .Name(Name)
                .Description(Description)
                .Color(Color)
                .Ordinal(Ordinal);
            return builder;
        }

        public class Builder
        {
            private string itemOptionId;
            private string name;
            private string description;
            private string color;
            private int? ordinal;



            public Builder ItemOptionId(string itemOptionId)
            {
                this.itemOptionId = itemOptionId;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder Color(string color)
            {
                this.color = color;
                return this;
            }

            public Builder Ordinal(int? ordinal)
            {
                this.ordinal = ordinal;
                return this;
            }

            public CatalogItemOptionValue Build()
            {
                return new CatalogItemOptionValue(itemOptionId,
                    name,
                    description,
                    color,
                    ordinal);
            }
        }
    }
}