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
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "display_name", false },
                { "description", false },
                { "show_colors", false },
                { "values", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (displayName != null)
            {
                shouldSerialize["display_name"] = true;
                this.DisplayName = displayName;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            if (showColors != null)
            {
                shouldSerialize["show_colors"] = true;
                this.ShowColors = showColors;
            }

            if (values != null)
            {
                shouldSerialize["values"] = true;
                this.Values = values;
            }

        }
        internal CatalogItemOption(Dictionary<string, bool> shouldSerialize,
            string name = null,
            string displayName = null,
            string description = null,
            bool? showColors = null,
            IList<Models.CatalogObject> values = null)
        {
            this.shouldSerialize = shouldSerialize;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOption : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDisplayName()
        {
            return this.shouldSerialize["display_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeShowColors()
        {
            return this.shouldSerialize["show_colors"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValues()
        {
            return this.shouldSerialize["values"];
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "display_name", false },
                { "description", false },
                { "show_colors", false },
                { "values", false },
            };

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
                shouldSerialize["name"] = true;
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
                shouldSerialize["display_name"] = true;
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
                shouldSerialize["description"] = true;
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
                shouldSerialize["show_colors"] = true;
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
                shouldSerialize["values"] = true;
                this.values = values;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDisplayName()
            {
                this.shouldSerialize["display_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetShowColors()
            {
                this.shouldSerialize["show_colors"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetValues()
            {
                this.shouldSerialize["values"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOption. </returns>
            public CatalogItemOption Build()
            {
                return new CatalogItemOption(shouldSerialize,
                    this.name,
                    this.displayName,
                    this.description,
                    this.showColors,
                    this.values);
            }
        }
    }
}