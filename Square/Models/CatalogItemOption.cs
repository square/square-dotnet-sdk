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
    /// CatalogItemOption.
    /// </summary>
    public class CatalogItemOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemOption"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="displayName">display_name.</param>
        /// <param name="description">description.</param>
        /// <param name="showColors">show_colors.</param>
        /// <param name="values">values.</param>
        public CatalogItemOption(
            string name = null,
            string displayName = null,
            string description = null,
            bool? showColors = null,
            IList<Models.CatalogObject> values = null)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.Description = description;
            this.ShowColors = showColors;
            this.Values = values;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOption : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogItemOption other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.DisplayName == null && other.DisplayName == null) || (this.DisplayName?.Equals(other.DisplayName) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.ShowColors == null && other.ShowColors == null) || (this.ShowColors?.Equals(other.ShowColors) == true)) &&
                ((this.Values == null && other.Values == null) || (this.Values?.Equals(other.Values) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1353145437;
            hashCode = HashCode.Combine(this.Name, this.DisplayName, this.Description, this.ShowColors, this.Values);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.DisplayName = {(this.DisplayName == null ? "null" : this.DisplayName == string.Empty ? "" : this.DisplayName)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.ShowColors = {(this.ShowColors == null ? "null" : this.ShowColors.ToString())}");
            toStringOutput.Add($"this.Values = {(this.Values == null ? "null" : $"[{string.Join(", ", this.Values)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .DisplayName(this.DisplayName)
                .Description(this.Description)
                .ShowColors(this.ShowColors)
                .Values(this.Values);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string displayName;
            private string description;
            private bool? showColors;
            private IList<Models.CatalogObject> values;

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
             /// DisplayName.
             /// </summary>
             /// <param name="displayName"> displayName. </param>
             /// <returns> Builder. </returns>
            public Builder DisplayName(string displayName)
            {
                this.displayName = displayName;
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
             /// ShowColors.
             /// </summary>
             /// <param name="showColors"> showColors. </param>
             /// <returns> Builder. </returns>
            public Builder ShowColors(bool? showColors)
            {
                this.showColors = showColors;
                return this;
            }

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IList<Models.CatalogObject> values)
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOption. </returns>
            public CatalogItemOption Build()
            {
                return new CatalogItemOption(
                    this.name,
                    this.displayName,
                    this.description,
                    this.showColors,
                    this.values);
            }
        }
    }
}