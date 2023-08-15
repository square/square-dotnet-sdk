namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CatalogItemOptionValue.
    /// </summary>
    public class CatalogItemOptionValue
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "item_option_id", false },
                { "name", false },
                { "description", false },
                { "color", false },
                { "ordinal", false }
            };

            if (itemOptionId != null)
            {
                shouldSerialize["item_option_id"] = true;
                this.ItemOptionId = itemOptionId;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            if (color != null)
            {
                shouldSerialize["color"] = true;
                this.Color = color;
            }

            if (ordinal != null)
            {
                shouldSerialize["ordinal"] = true;
                this.Ordinal = ordinal;
            }

        }
        internal CatalogItemOptionValue(Dictionary<string, bool> shouldSerialize,
            string itemOptionId = null,
            string name = null,
            string description = null,
            string color = null,
            int? ordinal = null)
        {
            this.shouldSerialize = shouldSerialize;
            ItemOptionId = itemOptionId;
            Name = name;
            Description = description;
            Color = color;
            Ordinal = ordinal;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemOptionValue : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemOptionId()
        {
            return this.shouldSerialize["item_option_id"];
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
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeColor()
        {
            return this.shouldSerialize["color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrdinal()
        {
            return this.shouldSerialize["ordinal"];
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
            return obj is CatalogItemOptionValue other &&                ((this.ItemOptionId == null && other.ItemOptionId == null) || (this.ItemOptionId?.Equals(other.ItemOptionId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Color == null && other.Color == null) || (this.Color?.Equals(other.Color) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1107154058;
            hashCode = HashCode.Combine(this.ItemOptionId, this.Name, this.Description, this.Color, this.Ordinal);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemOptionId = {(this.ItemOptionId == null ? "null" : this.ItemOptionId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.Color = {(this.Color == null ? "null" : this.Color)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "item_option_id", false },
                { "name", false },
                { "description", false },
                { "color", false },
                { "ordinal", false },
            };

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
                shouldSerialize["item_option_id"] = true;
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
                shouldSerialize["name"] = true;
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
                shouldSerialize["description"] = true;
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
                shouldSerialize["color"] = true;
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
                shouldSerialize["ordinal"] = true;
                this.ordinal = ordinal;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemOptionId()
            {
                this.shouldSerialize["item_option_id"] = false;
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
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetColor()
            {
                this.shouldSerialize["color"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrdinal()
            {
                this.shouldSerialize["ordinal"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemOptionValue. </returns>
            public CatalogItemOptionValue Build()
            {
                return new CatalogItemOptionValue(shouldSerialize,
                    this.itemOptionId,
                    this.name,
                    this.description,
                    this.color,
                    this.ordinal);
            }
        }
    }
}