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
    /// CatalogItemOptionValue.
    /// </summary>
    public class CatalogItemOptionValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemOptionValue"/> class.
        /// </summary>
        /// <param name="itemOptionId">item_option_id.</param>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="color">color.</param>
        /// <param name="ordinal">ordinal.</param>
        public CatalogItemOptionValue(
            string itemOptionId = null,
            string name = null,
            string description = null,
            string color = null,
            int? ordinal = null)
        {
            this.ItemOptionId = itemOptionId;
            this.Name = name;
            this.Description = description;
            this.Color = color;
            this.Ordinal = ordinal;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionValue : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogItemOptionValue other &&
                ((this.ItemOptionId == null && other.ItemOptionId == null) || (this.ItemOptionId?.Equals(other.ItemOptionId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Color == null && other.Color == null) || (this.Color?.Equals(other.Color) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1107154058;

            if (this.ItemOptionId != null)
            {
               hashCode += this.ItemOptionId.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Description != null)
            {
               hashCode += this.Description.GetHashCode();
            }

            if (this.Color != null)
            {
               hashCode += this.Color.GetHashCode();
            }

            if (this.Ordinal != null)
            {
               hashCode += this.Ordinal.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionId = {(this.ItemOptionId == null ? "null" : this.ItemOptionId == string.Empty ? "" : this.ItemOptionId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.Color = {(this.Color == null ? "null" : this.Color == string.Empty ? "" : this.Color)}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemOptionId(this.ItemOptionId)
                .Name(this.Name)
                .Description(this.Description)
                .Color(this.Color)
                .Ordinal(this.Ordinal);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string itemOptionId;
            private string name;
            private string description;
            private string color;
            private int? ordinal;

             /// <summary>
             /// ItemOptionId.
             /// </summary>
             /// <param name="itemOptionId"> itemOptionId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionId(string itemOptionId)
            {
                this.itemOptionId = itemOptionId;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

             /// <summary>
             /// Color.
             /// </summary>
             /// <param name="color"> color. </param>
             /// <returns> Builder. </returns>
            public Builder Color(string color)
            {
                this.color = color;
                return this;
            }

             /// <summary>
             /// Ordinal.
             /// </summary>
             /// <param name="ordinal"> ordinal. </param>
             /// <returns> Builder. </returns>
            public Builder Ordinal(int? ordinal)
            {
                this.ordinal = ordinal;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOptionValue. </returns>
            public CatalogItemOptionValue Build()
            {
                return new CatalogItemOptionValue(
                    this.itemOptionId,
                    this.name,
                    this.description,
                    this.color,
                    this.ordinal);
            }
        }
    }
}