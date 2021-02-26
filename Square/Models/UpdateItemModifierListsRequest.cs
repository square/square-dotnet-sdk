
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
    public class UpdateItemModifierListsRequest 
    {
        public UpdateItemModifierListsRequest(IList<string> itemIds,
            IList<string> modifierListsToEnable = null,
            IList<string> modifierListsToDisable = null)
        {
            ItemIds = itemIds;
            ModifierListsToEnable = modifierListsToEnable;
            ModifierListsToDisable = modifierListsToDisable;
        }

        /// <summary>
        /// The IDs of the catalog items associated with the CatalogModifierList objects being updated.
        /// </summary>
        [JsonProperty("item_ids")]
        public IList<string> ItemIds { get; }

        /// <summary>
        /// The IDs of the CatalogModifierList objects to enable for the CatalogItem.
        /// </summary>
        [JsonProperty("modifier_lists_to_enable", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ModifierListsToEnable { get; }

        /// <summary>
        /// The IDs of the CatalogModifierList objects to disable for the CatalogItem.
        /// </summary>
        [JsonProperty("modifier_lists_to_disable", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ModifierListsToDisable { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateItemModifierListsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemIds = {(ItemIds == null ? "null" : $"[{ string.Join(", ", ItemIds)} ]")}");
            toStringOutput.Add($"ModifierListsToEnable = {(ModifierListsToEnable == null ? "null" : $"[{ string.Join(", ", ModifierListsToEnable)} ]")}");
            toStringOutput.Add($"ModifierListsToDisable = {(ModifierListsToDisable == null ? "null" : $"[{ string.Join(", ", ModifierListsToDisable)} ]")}");
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

            return obj is UpdateItemModifierListsRequest other &&
                ((ItemIds == null && other.ItemIds == null) || (ItemIds?.Equals(other.ItemIds) == true)) &&
                ((ModifierListsToEnable == null && other.ModifierListsToEnable == null) || (ModifierListsToEnable?.Equals(other.ModifierListsToEnable) == true)) &&
                ((ModifierListsToDisable == null && other.ModifierListsToDisable == null) || (ModifierListsToDisable?.Equals(other.ModifierListsToDisable) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1248477288;

            if (ItemIds != null)
            {
               hashCode += ItemIds.GetHashCode();
            }

            if (ModifierListsToEnable != null)
            {
               hashCode += ModifierListsToEnable.GetHashCode();
            }

            if (ModifierListsToDisable != null)
            {
               hashCode += ModifierListsToDisable.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(ItemIds)
                .ModifierListsToEnable(ModifierListsToEnable)
                .ModifierListsToDisable(ModifierListsToDisable);
            return builder;
        }

        public class Builder
        {
            private IList<string> itemIds;
            private IList<string> modifierListsToEnable;
            private IList<string> modifierListsToDisable;

            public Builder(IList<string> itemIds)
            {
                this.itemIds = itemIds;
            }

            public Builder ItemIds(IList<string> itemIds)
            {
                this.itemIds = itemIds;
                return this;
            }

            public Builder ModifierListsToEnable(IList<string> modifierListsToEnable)
            {
                this.modifierListsToEnable = modifierListsToEnable;
                return this;
            }

            public Builder ModifierListsToDisable(IList<string> modifierListsToDisable)
            {
                this.modifierListsToDisable = modifierListsToDisable;
                return this;
            }

            public UpdateItemModifierListsRequest Build()
            {
                return new UpdateItemModifierListsRequest(itemIds,
                    modifierListsToEnable,
                    modifierListsToDisable);
            }
        }
    }
}