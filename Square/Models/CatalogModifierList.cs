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

namespace Square.Models
{
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
        /// <param name="modifierType">modifier_type.</param>
        /// <param name="maxLength">max_length.</param>
        /// <param name="textRequired">text_required.</param>
        /// <param name="internalName">internal_name.</param>
        public CatalogModifierList(
            string name = null,
            int? ordinal = null,
            string selectionType = null,
            IList<Models.CatalogObject> modifiers = null,
            IList<string> imageIds = null,
            string modifierType = null,
            int? maxLength = null,
            bool? textRequired = null,
            string internalName = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "ordinal", false },
                { "modifiers", false },
                { "image_ids", false },
                { "max_length", false },
                { "text_required", false },
                { "internal_name", false }
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

            this.ModifierType = modifierType;
            if (maxLength != null)
            {
                shouldSerialize["max_length"] = true;
                this.MaxLength = maxLength;
            }

            if (textRequired != null)
            {
                shouldSerialize["text_required"] = true;
                this.TextRequired = textRequired;
            }

            if (internalName != null)
            {
                shouldSerialize["internal_name"] = true;
                this.InternalName = internalName;
            }

        }
        internal CatalogModifierList(Dictionary<string, bool> shouldSerialize,
            string name = null,
            int? ordinal = null,
            string selectionType = null,
            IList<Models.CatalogObject> modifiers = null,
            IList<string> imageIds = null,
            string modifierType = null,
            int? maxLength = null,
            bool? textRequired = null,
            string internalName = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Ordinal = ordinal;
            SelectionType = selectionType;
            Modifiers = modifiers;
            ImageIds = imageIds;
            ModifierType = modifierType;
            MaxLength = maxLength;
            TextRequired = textRequired;
            InternalName = internalName;
        }

        /// <summary>
        /// The name of the `CatalogModifierList` instance. This is a searchable attribute for use in applicable query filters, and its value length is of
        /// Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The position of this `CatalogModifierList` within a list of `CatalogModifierList` instances.
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// Indicates whether a CatalogModifierList supports multiple selections.
        /// </summary>
        [JsonProperty("selection_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectionType { get; }

        /// <summary>
        /// A non-empty list of `CatalogModifier` objects to be included in the `CatalogModifierList`,
        /// for non text-based modifiers when the `modifier_type` attribute is `LIST`. Each element of this list
        /// is a `CatalogObject` instance of the `MODIFIER` type, containing the following attributes:
        /// ```
        /// {
        /// "id": "{{catalog_modifier_id}}",
        /// "type": "MODIFIER",
        /// "modifier_data": {{a CatalogModifier instance>}}
        /// }
        /// ```
        /// </summary>
        [JsonProperty("modifiers")]
        public IList<Models.CatalogObject> Modifiers { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogModifierList` instance.
        /// Currently these images are not displayed on Square products, but may be displayed in 3rd-party applications.
        /// </summary>
        [JsonProperty("image_ids")]
        public IList<string> ImageIds { get; }

        /// <summary>
        /// Defines the type of `CatalogModifierList`.
        /// </summary>
        [JsonProperty("modifier_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierType { get; }

        /// <summary>
        /// The maximum length, in Unicode points, of the text string of the text-based modifier as represented by
        /// this `CatalogModifierList` object with the `modifier_type` set to `TEXT`.
        /// </summary>
        [JsonProperty("max_length")]
        public int? MaxLength { get; }

        /// <summary>
        /// Whether the text string must be a non-empty string (`true`) or not (`false`) for a text-based modifier
        /// as represented by this `CatalogModifierList` object with the `modifier_type` set to `TEXT`.
        /// </summary>
        [JsonProperty("text_required")]
        public bool? TextRequired { get; }

        /// <summary>
        /// A note for internal use by the business.
        /// For example, for a text-based modifier applied to a T-shirt item, if the buyer-supplied text of "Hello, Kitty!"
        /// is to be printed on the T-shirt, this `internal_name` attribute can be "Use italic face" as
        /// an instruction for the business to follow.
        /// For non text-based modifiers, this `internal_name` attribute can be
        /// used to include SKUs, internal codes, or supplemental descriptions for internal use.
        /// </summary>
        [JsonProperty("internal_name")]
        public string InternalName { get; }

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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxLength()
        {
            return this.shouldSerialize["max_length"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTextRequired()
        {
            return this.shouldSerialize["text_required"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInternalName()
        {
            return this.shouldSerialize["internal_name"];
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
            return obj is CatalogModifierList other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true)) &&
                ((this.SelectionType == null && other.SelectionType == null) || (this.SelectionType?.Equals(other.SelectionType) == true)) &&
                ((this.Modifiers == null && other.Modifiers == null) || (this.Modifiers?.Equals(other.Modifiers) == true)) &&
                ((this.ImageIds == null && other.ImageIds == null) || (this.ImageIds?.Equals(other.ImageIds) == true)) &&
                ((this.ModifierType == null && other.ModifierType == null) || (this.ModifierType?.Equals(other.ModifierType) == true)) &&
                ((this.MaxLength == null && other.MaxLength == null) || (this.MaxLength?.Equals(other.MaxLength) == true)) &&
                ((this.TextRequired == null && other.TextRequired == null) || (this.TextRequired?.Equals(other.TextRequired) == true)) &&
                ((this.InternalName == null && other.InternalName == null) || (this.InternalName?.Equals(other.InternalName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 35199234;
            hashCode = HashCode.Combine(this.Name, this.Ordinal, this.SelectionType, this.Modifiers, this.ImageIds, this.ModifierType, this.MaxLength);

            hashCode = HashCode.Combine(hashCode, this.TextRequired, this.InternalName);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
            toStringOutput.Add($"this.SelectionType = {(this.SelectionType == null ? "null" : this.SelectionType.ToString())}");
            toStringOutput.Add($"this.Modifiers = {(this.Modifiers == null ? "null" : $"[{string.Join(", ", this.Modifiers)} ]")}");
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
            toStringOutput.Add($"this.ModifierType = {(this.ModifierType == null ? "null" : this.ModifierType.ToString())}");
            toStringOutput.Add($"this.MaxLength = {(this.MaxLength == null ? "null" : this.MaxLength.ToString())}");
            toStringOutput.Add($"this.TextRequired = {(this.TextRequired == null ? "null" : this.TextRequired.ToString())}");
            toStringOutput.Add($"this.InternalName = {(this.InternalName == null ? "null" : this.InternalName)}");
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
                .ImageIds(this.ImageIds)
                .ModifierType(this.ModifierType)
                .MaxLength(this.MaxLength)
                .TextRequired(this.TextRequired)
                .InternalName(this.InternalName);
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
                { "max_length", false },
                { "text_required", false },
                { "internal_name", false },
            };

            private string name;
            private int? ordinal;
            private string selectionType;
            private IList<Models.CatalogObject> modifiers;
            private IList<string> imageIds;
            private string modifierType;
            private int? maxLength;
            private bool? textRequired;
            private string internalName;

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
             /// ModifierType.
             /// </summary>
             /// <param name="modifierType"> modifierType. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierType(string modifierType)
            {
                this.modifierType = modifierType;
                return this;
            }

             /// <summary>
             /// MaxLength.
             /// </summary>
             /// <param name="maxLength"> maxLength. </param>
             /// <returns> Builder. </returns>
            public Builder MaxLength(int? maxLength)
            {
                shouldSerialize["max_length"] = true;
                this.maxLength = maxLength;
                return this;
            }

             /// <summary>
             /// TextRequired.
             /// </summary>
             /// <param name="textRequired"> textRequired. </param>
             /// <returns> Builder. </returns>
            public Builder TextRequired(bool? textRequired)
            {
                shouldSerialize["text_required"] = true;
                this.textRequired = textRequired;
                return this;
            }

             /// <summary>
             /// InternalName.
             /// </summary>
             /// <param name="internalName"> internalName. </param>
             /// <returns> Builder. </returns>
            public Builder InternalName(string internalName)
            {
                shouldSerialize["internal_name"] = true;
                this.internalName = internalName;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMaxLength()
            {
                this.shouldSerialize["max_length"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTextRequired()
            {
                this.shouldSerialize["text_required"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetInternalName()
            {
                this.shouldSerialize["internal_name"] = false;
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
                    this.imageIds,
                    this.modifierType,
                    this.maxLength,
                    this.textRequired,
                    this.internalName);
            }
        }
    }
}