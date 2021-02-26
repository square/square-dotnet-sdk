
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
    public class CatalogQueryItemsForModifierList 
    {
        public CatalogQueryItemsForModifierList(IList<string> modifierListIds)
        {
            ModifierListIds = modifierListIds;
        }

        /// <summary>
        /// A set of `CatalogModifierList` IDs to be used to find associated `CatalogItem`s.
        /// </summary>
        [JsonProperty("modifier_list_ids")]
        public IList<string> ModifierListIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemsForModifierList : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ModifierListIds = {(ModifierListIds == null ? "null" : $"[{ string.Join(", ", ModifierListIds)} ]")}");
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

            return obj is CatalogQueryItemsForModifierList other &&
                ((ModifierListIds == null && other.ModifierListIds == null) || (ModifierListIds?.Equals(other.ModifierListIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 969503410;

            if (ModifierListIds != null)
            {
               hashCode += ModifierListIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(ModifierListIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> modifierListIds;

            public Builder(IList<string> modifierListIds)
            {
                this.modifierListIds = modifierListIds;
            }

            public Builder ModifierListIds(IList<string> modifierListIds)
            {
                this.modifierListIds = modifierListIds;
                return this;
            }

            public CatalogQueryItemsForModifierList Build()
            {
                return new CatalogQueryItemsForModifierList(modifierListIds);
            }
        }
    }
}