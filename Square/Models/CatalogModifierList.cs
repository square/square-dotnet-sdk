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
    /// CatalogModifierList.
    /// </summary>
    public class CatalogModifierList
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogModifierList"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="selectionType">selection_type.</param>
        /// <param name="modifiers">modifiers.</param>
        /// <param name="imageIds">image_ids.</param>
        public CatalogModifierList(
            string name = null,
            int? ordinal = null,
            string selectionType = null,
            IList<Models.CatalogObject> modifiers = null,
            IList<string> imageIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "ordinal", false },
                { "modifiers", false },
                { "image_ids", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (ordinal != null)
            {
                shouldSerialize["ordinal"] = true;
                this.Ordinal = ordinal;
            }

            this.SelectionType = selectionType;
            if (modifiers != null)
            {
                shouldSerialize["modifiers"] = true;
                this.Modifiers = modifiers;
            }

            if (imageIds != null)
            {
                shouldSerialize["image_ids"] = true;
                this.ImageIds = imageIds;
            }

        }
        internal CatalogModifierList(Dictionary<string, bool> shouldSerialize,
            string name = null,
            int? ordinal = null,
            string selectionType = null,
            IList<Models.CatalogObject> modifiers = null,
            IList<string> imageIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Ordinal = ordinal;
            SelectionType = selectionType;
            Modifiers = modifiers;
            ImageIds = imageIds;
        }

        /// <summary>
        /// The name for the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Determines where this modifier list appears in a list of `CatalogModifierList` values.
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// Indicates whether a CatalogModifierList supports multiple selections.
        /// </summary>
        [JsonProperty("selection_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectionType { get; }

        /// <summary>
        /// The options included in the `CatalogModifierList`.
        /// You must include at least one `CatalogModifier`.
        /// Each CatalogObject must have type `MODIFIER` and contain
        /// `CatalogModifier` data.
        /// </summary>
        [JsonProperty("modifiers")]
        public IList<Models.CatalogObject> Modifiers { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogModifierList` instance.
        /// Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        /// </summary>
        [JsonProperty("image_ids")]
        public IList<string> ImageIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogModifierList : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeOrdinal()
        {
            return this.shouldSerialize["ordinal"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiers()
        {
            return this.shouldSerialize["modifiers"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeImageIds()
        {
            return this.shouldSerialize["image_ids"];
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

            return obj is CatalogModifierList other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true)) &&
                ((this.SelectionType == null && other.SelectionType == null) || (this.SelectionType?.Equals(other.SelectionType) == true)) &&
                ((this.Modifiers == null && other.Modifiers == null) || (this.Modifiers?.Equals(other.Modifiers) == true)) &&
                ((this.ImageIds == null && other.ImageIds == null) || (this.ImageIds?.Equals(other.ImageIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1226843592;
            hashCode = HashCode.Combine(this.Name, this.Ordinal, this.SelectionType, this.Modifiers, this.ImageIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
            toStringOutput.Add($"this.SelectionType = {(this.SelectionType == null ? "null" : this.SelectionType.ToString())}");
            toStringOutput.Add($"this.Modifiers = {(this.Modifiers == null ? "null" : $"[{string.Join(", ", this.Modifiers)} ]")}");
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .Ordinal(this.Ordinal)
                .SelectionType(this.SelectionType)
                .Modifiers(this.Modifiers)
                .ImageIds(this.ImageIds);
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
                { "ordinal", false },
                { "modifiers", false },
                { "image_ids", false },
            };

            private string name;
            private int? ordinal;
            private string selectionType;
            private IList<Models.CatalogObject> modifiers;
            private IList<string> imageIds;

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
             /// SelectionType.
             /// </summary>
             /// <param name="selectionType"> selectionType. </param>
             /// <returns> Builder. </returns>
            public Builder SelectionType(string selectionType)
            {
                this.selectionType = selectionType;
                return this;
            }

             /// <summary>
             /// Modifiers.
             /// </summary>
             /// <param name="modifiers"> modifiers. </param>
             /// <returns> Builder. </returns>
            public Builder Modifiers(IList<Models.CatalogObject> modifiers)
            {
                shouldSerialize["modifiers"] = true;
                this.modifiers = modifiers;
                return this;
            }

             /// <summary>
             /// ImageIds.
             /// </summary>
             /// <param name="imageIds"> imageIds. </param>
             /// <returns> Builder. </returns>
            public Builder ImageIds(IList<string> imageIds)
            {
                shouldSerialize["image_ids"] = true;
                this.imageIds = imageIds;
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
            public void UnsetOrdinal()
            {
                this.shouldSerialize["ordinal"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifiers()
            {
                this.shouldSerialize["modifiers"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetImageIds()
            {
                this.shouldSerialize["image_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogModifierList. </returns>
            public CatalogModifierList Build()
            {
                return new CatalogModifierList(shouldSerialize,
                    this.name,
                    this.ordinal,
                    this.selectionType,
                    this.modifiers,
                    this.imageIds);
            }
        }
    }
}