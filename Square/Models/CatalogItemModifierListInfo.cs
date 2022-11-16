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
    /// CatalogItemModifierListInfo.
    /// </summary>
    public class CatalogItemModifierListInfo
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemModifierListInfo"/> class.
        /// </summary>
        /// <param name="modifierListId">modifier_list_id.</param>
        /// <param name="modifierOverrides">modifier_overrides.</param>
        /// <param name="minSelectedModifiers">min_selected_modifiers.</param>
        /// <param name="maxSelectedModifiers">max_selected_modifiers.</param>
        /// <param name="enabled">enabled.</param>
        public CatalogItemModifierListInfo(
            string modifierListId,
            IList<Models.CatalogModifierOverride> modifierOverrides = null,
            int? minSelectedModifiers = null,
            int? maxSelectedModifiers = null,
            bool? enabled = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "modifier_overrides", false },
                { "min_selected_modifiers", false },
                { "max_selected_modifiers", false },
                { "enabled", false }
            };

            this.ModifierListId = modifierListId;
            if (modifierOverrides != null)
            {
                shouldSerialize["modifier_overrides"] = true;
                this.ModifierOverrides = modifierOverrides;
            }

            if (minSelectedModifiers != null)
            {
                shouldSerialize["min_selected_modifiers"] = true;
                this.MinSelectedModifiers = minSelectedModifiers;
            }

            if (maxSelectedModifiers != null)
            {
                shouldSerialize["max_selected_modifiers"] = true;
                this.MaxSelectedModifiers = maxSelectedModifiers;
            }

            if (enabled != null)
            {
                shouldSerialize["enabled"] = true;
                this.Enabled = enabled;
            }

        }
        internal CatalogItemModifierListInfo(Dictionary<string, bool> shouldSerialize,
            string modifierListId,
            IList<Models.CatalogModifierOverride> modifierOverrides = null,
            int? minSelectedModifiers = null,
            int? maxSelectedModifiers = null,
            bool? enabled = null)
        {
            this.shouldSerialize = shouldSerialize;
            ModifierListId = modifierListId;
            ModifierOverrides = modifierOverrides;
            MinSelectedModifiers = minSelectedModifiers;
            MaxSelectedModifiers = maxSelectedModifiers;
            Enabled = enabled;
        }

        /// <summary>
        /// The ID of the `CatalogModifierList` controlled by this `CatalogModifierListInfo`.
        /// </summary>
        [JsonProperty("modifier_list_id")]
        public string ModifierListId { get; }

        /// <summary>
        /// A set of `CatalogModifierOverride` objects that override whether a given `CatalogModifier` is enabled by default.
        /// </summary>
        [JsonProperty("modifier_overrides")]
        public IList<Models.CatalogModifierOverride> ModifierOverrides { get; }

        /// <summary>
        /// If 0 or larger, the smallest number of `CatalogModifier`s that must be selected from this `CatalogModifierList`.
        /// </summary>
        [JsonProperty("min_selected_modifiers")]
        public int? MinSelectedModifiers { get; }

        /// <summary>
        /// If 0 or larger, the largest number of `CatalogModifier`s that can be selected from this `CatalogModifierList`.
        /// </summary>
        [JsonProperty("max_selected_modifiers")]
        public int? MaxSelectedModifiers { get; }

        /// <summary>
        /// If `true`, enable this `CatalogModifierList`. The default value is `true`.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemModifierListInfo : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifierOverrides()
        {
            return this.shouldSerialize["modifier_overrides"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMinSelectedModifiers()
        {
            return this.shouldSerialize["min_selected_modifiers"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxSelectedModifiers()
        {
            return this.shouldSerialize["max_selected_modifiers"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnabled()
        {
            return this.shouldSerialize["enabled"];
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

            return obj is CatalogItemModifierListInfo other &&
                ((this.ModifierListId == null && other.ModifierListId == null) || (this.ModifierListId?.Equals(other.ModifierListId) == true)) &&
                ((this.ModifierOverrides == null && other.ModifierOverrides == null) || (this.ModifierOverrides?.Equals(other.ModifierOverrides) == true)) &&
                ((this.MinSelectedModifiers == null && other.MinSelectedModifiers == null) || (this.MinSelectedModifiers?.Equals(other.MinSelectedModifiers) == true)) &&
                ((this.MaxSelectedModifiers == null && other.MaxSelectedModifiers == null) || (this.MaxSelectedModifiers?.Equals(other.MaxSelectedModifiers) == true)) &&
                ((this.Enabled == null && other.Enabled == null) || (this.Enabled?.Equals(other.Enabled) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1904387422;
            hashCode = HashCode.Combine(this.ModifierListId, this.ModifierOverrides, this.MinSelectedModifiers, this.MaxSelectedModifiers, this.Enabled);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ModifierListId = {(this.ModifierListId == null ? "null" : this.ModifierListId == string.Empty ? "" : this.ModifierListId)}");
            toStringOutput.Add($"this.ModifierOverrides = {(this.ModifierOverrides == null ? "null" : $"[{string.Join(", ", this.ModifierOverrides)} ]")}");
            toStringOutput.Add($"this.MinSelectedModifiers = {(this.MinSelectedModifiers == null ? "null" : this.MinSelectedModifiers.ToString())}");
            toStringOutput.Add($"this.MaxSelectedModifiers = {(this.MaxSelectedModifiers == null ? "null" : this.MaxSelectedModifiers.ToString())}");
            toStringOutput.Add($"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ModifierListId)
                .ModifierOverrides(this.ModifierOverrides)
                .MinSelectedModifiers(this.MinSelectedModifiers)
                .MaxSelectedModifiers(this.MaxSelectedModifiers)
                .Enabled(this.Enabled);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "modifier_overrides", false },
                { "min_selected_modifiers", false },
                { "max_selected_modifiers", false },
                { "enabled", false },
            };

            private string modifierListId;
            private IList<Models.CatalogModifierOverride> modifierOverrides;
            private int? minSelectedModifiers;
            private int? maxSelectedModifiers;
            private bool? enabled;

            public Builder(
                string modifierListId)
            {
                this.modifierListId = modifierListId;
            }

             /// <summary>
             /// ModifierListId.
             /// </summary>
             /// <param name="modifierListId"> modifierListId. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListId(string modifierListId)
            {
                this.modifierListId = modifierListId;
                return this;
            }

             /// <summary>
             /// ModifierOverrides.
             /// </summary>
             /// <param name="modifierOverrides"> modifierOverrides. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierOverrides(IList<Models.CatalogModifierOverride> modifierOverrides)
            {
                shouldSerialize["modifier_overrides"] = true;
                this.modifierOverrides = modifierOverrides;
                return this;
            }

             /// <summary>
             /// MinSelectedModifiers.
             /// </summary>
             /// <param name="minSelectedModifiers"> minSelectedModifiers. </param>
             /// <returns> Builder. </returns>
            public Builder MinSelectedModifiers(int? minSelectedModifiers)
            {
                shouldSerialize["min_selected_modifiers"] = true;
                this.minSelectedModifiers = minSelectedModifiers;
                return this;
            }

             /// <summary>
             /// MaxSelectedModifiers.
             /// </summary>
             /// <param name="maxSelectedModifiers"> maxSelectedModifiers. </param>
             /// <returns> Builder. </returns>
            public Builder MaxSelectedModifiers(int? maxSelectedModifiers)
            {
                shouldSerialize["max_selected_modifiers"] = true;
                this.maxSelectedModifiers = maxSelectedModifiers;
                return this;
            }

             /// <summary>
             /// Enabled.
             /// </summary>
             /// <param name="enabled"> enabled. </param>
             /// <returns> Builder. </returns>
            public Builder Enabled(bool? enabled)
            {
                shouldSerialize["enabled"] = true;
                this.enabled = enabled;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifierOverrides()
            {
                this.shouldSerialize["modifier_overrides"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMinSelectedModifiers()
            {
                this.shouldSerialize["min_selected_modifiers"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMaxSelectedModifiers()
            {
                this.shouldSerialize["max_selected_modifiers"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEnabled()
            {
                this.shouldSerialize["enabled"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemModifierListInfo. </returns>
            public CatalogItemModifierListInfo Build()
            {
                return new CatalogItemModifierListInfo(shouldSerialize,
                    this.modifierListId,
                    this.modifierOverrides,
                    this.minSelectedModifiers,
                    this.maxSelectedModifiers,
                    this.enabled);
            }
        }
    }
}