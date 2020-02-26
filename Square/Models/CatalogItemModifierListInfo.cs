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
            private IList<Models.CatalogModifierOverride> modifierOverrides = new List<Models.CatalogModifierOverride>();
            private int? minSelectedModifiers;
            private int? maxSelectedModifiers;
            private bool? enabled;

            public Builder(string modifierListId)
            {
                this.modifierListId = modifierListId;
            }
            public Builder ModifierListId(string value)
            {
                modifierListId = value;
                return this;
            }

            public Builder ModifierOverrides(IList<Models.CatalogModifierOverride> value)
            {
                modifierOverrides = value;
                return this;
            }

            public Builder MinSelectedModifiers(int? value)
            {
                minSelectedModifiers = value;
                return this;
            }

            public Builder MaxSelectedModifiers(int? value)
            {
                maxSelectedModifiers = value;
                return this;
            }

            public Builder Enabled(bool? value)
            {
                enabled = value;
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