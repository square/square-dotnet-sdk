
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
    public class CatalogItemModifierListInfo 
    {
        public CatalogItemModifierListInfo(string modifierListId,
            IList<Models.CatalogModifierOverride> modifierOverrides = null,
            int? minSelectedModifiers = null,
            int? maxSelectedModifiers = null,
            bool? enabled = null)
        {
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
        [JsonProperty("modifier_overrides", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogModifierOverride> ModifierOverrides { get; }

        /// <summary>
        /// If 0 or larger, the smallest number of `CatalogModifier`s that must be selected from this `CatalogModifierList`.
        /// </summary>
        [JsonProperty("min_selected_modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public int? MinSelectedModifiers { get; }

        /// <summary>
        /// If 0 or larger, the largest number of `CatalogModifier`s that can be selected from this `CatalogModifierList`.
        /// </summary>
        [JsonProperty("max_selected_modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxSelectedModifiers { get; }

        /// <summary>
        /// If `true`, enable this `CatalogModifierList`. The default value is `true`.
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemModifierListInfo : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ModifierListId = {(ModifierListId == null ? "null" : ModifierListId == string.Empty ? "" : ModifierListId)}");
            toStringOutput.Add($"ModifierOverrides = {(ModifierOverrides == null ? "null" : $"[{ string.Join(", ", ModifierOverrides)} ]")}");
            toStringOutput.Add($"MinSelectedModifiers = {(MinSelectedModifiers == null ? "null" : MinSelectedModifiers.ToString())}");
            toStringOutput.Add($"MaxSelectedModifiers = {(MaxSelectedModifiers == null ? "null" : MaxSelectedModifiers.ToString())}");
            toStringOutput.Add($"Enabled = {(Enabled == null ? "null" : Enabled.ToString())}");
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

            return obj is CatalogItemModifierListInfo other &&
                ((ModifierListId == null && other.ModifierListId == null) || (ModifierListId?.Equals(other.ModifierListId) == true)) &&
                ((ModifierOverrides == null && other.ModifierOverrides == null) || (ModifierOverrides?.Equals(other.ModifierOverrides) == true)) &&
                ((MinSelectedModifiers == null && other.MinSelectedModifiers == null) || (MinSelectedModifiers?.Equals(other.MinSelectedModifiers) == true)) &&
                ((MaxSelectedModifiers == null && other.MaxSelectedModifiers == null) || (MaxSelectedModifiers?.Equals(other.MaxSelectedModifiers) == true)) &&
                ((Enabled == null && other.Enabled == null) || (Enabled?.Equals(other.Enabled) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1904387422;

            if (ModifierListId != null)
            {
               hashCode += ModifierListId.GetHashCode();
            }

            if (ModifierOverrides != null)
            {
               hashCode += ModifierOverrides.GetHashCode();
            }

            if (MinSelectedModifiers != null)
            {
               hashCode += MinSelectedModifiers.GetHashCode();
            }

            if (MaxSelectedModifiers != null)
            {
               hashCode += MaxSelectedModifiers.GetHashCode();
            }

            if (Enabled != null)
            {
               hashCode += Enabled.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(ModifierListId)
                .ModifierOverrides(ModifierOverrides)
                .MinSelectedModifiers(MinSelectedModifiers)
                .MaxSelectedModifiers(MaxSelectedModifiers)
                .Enabled(Enabled);
            return builder;
        }

        public class Builder
        {
            private string modifierListId;
            private IList<Models.CatalogModifierOverride> modifierOverrides;
            private int? minSelectedModifiers;
            private int? maxSelectedModifiers;
            private bool? enabled;

            public Builder(string modifierListId)
            {
                this.modifierListId = modifierListId;
            }

            public Builder ModifierListId(string modifierListId)
            {
                this.modifierListId = modifierListId;
                return this;
            }

            public Builder ModifierOverrides(IList<Models.CatalogModifierOverride> modifierOverrides)
            {
                this.modifierOverrides = modifierOverrides;
                return this;
            }

            public Builder MinSelectedModifiers(int? minSelectedModifiers)
            {
                this.minSelectedModifiers = minSelectedModifiers;
                return this;
            }

            public Builder MaxSelectedModifiers(int? maxSelectedModifiers)
            {
                this.maxSelectedModifiers = maxSelectedModifiers;
                return this;
            }

            public Builder Enabled(bool? enabled)
            {
                this.enabled = enabled;
                return this;
            }

            public CatalogItemModifierListInfo Build()
            {
                return new CatalogItemModifierListInfo(modifierListId,
                    modifierOverrides,
                    minSelectedModifiers,
                    maxSelectedModifiers,
                    enabled);
            }
        }
    }
}