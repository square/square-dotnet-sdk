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
    /// UpdateItemModifierListsRequest.
    /// </summary>
    public class UpdateItemModifierListsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemModifierListsRequest"/> class.
        /// </summary>
        /// <param name="itemIds">item_ids.</param>
        /// <param name="modifierListsToEnable">modifier_lists_to_enable.</param>
        /// <param name="modifierListsToDisable">modifier_lists_to_disable.</param>
        public UpdateItemModifierListsRequest(
            IList<string> itemIds,
            IList<string> modifierListsToEnable = null,
            IList<string> modifierListsToDisable = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "modifier_lists_to_enable", false },
                { "modifier_lists_to_disable", false }
            };

            this.ItemIds = itemIds;
            if (modifierListsToEnable != null)
            {
                shouldSerialize["modifier_lists_to_enable"] = true;
                this.ModifierListsToEnable = modifierListsToEnable;
            }

            if (modifierListsToDisable != null)
            {
                shouldSerialize["modifier_lists_to_disable"] = true;
                this.ModifierListsToDisable = modifierListsToDisable;
            }

        }
        internal UpdateItemModifierListsRequest(Dictionary<string, bool> shouldSerialize,
            IList<string> itemIds,
            IList<string> modifierListsToEnable = null,
            IList<string> modifierListsToDisable = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        /// At least one of `modifier_lists_to_enable` or `modifier_lists_to_disable` must be specified.
        /// </summary>
        [JsonProperty("modifier_lists_to_enable")]
        public IList<string> ModifierListsToEnable { get; }

        /// <summary>
        /// The IDs of the CatalogModifierList objects to disable for the CatalogItem.
        /// At least one of `modifier_lists_to_enable` or `modifier_lists_to_disable` must be specified.
        /// </summary>
        [JsonProperty("modifier_lists_to_disable")]
        public IList<string> ModifierListsToDisable { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateItemModifierListsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifierListsToEnable()
        {
            return this.shouldSerialize["modifier_lists_to_enable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifierListsToDisable()
        {
            return this.shouldSerialize["modifier_lists_to_disable"];
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
            return obj is UpdateItemModifierListsRequest other &&                ((this.ItemIds == null && other.ItemIds == null) || (this.ItemIds?.Equals(other.ItemIds) == true)) &&
                ((this.ModifierListsToEnable == null && other.ModifierListsToEnable == null) || (this.ModifierListsToEnable?.Equals(other.ModifierListsToEnable) == true)) &&
                ((this.ModifierListsToDisable == null && other.ModifierListsToDisable == null) || (this.ModifierListsToDisable?.Equals(other.ModifierListsToDisable) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1248477288;
            hashCode = HashCode.Combine(this.ItemIds, this.ModifierListsToEnable, this.ModifierListsToDisable);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemIds = {(this.ItemIds == null ? "null" : $"[{string.Join(", ", this.ItemIds)} ]")}");
            toStringOutput.Add($"this.ModifierListsToEnable = {(this.ModifierListsToEnable == null ? "null" : $"[{string.Join(", ", this.ModifierListsToEnable)} ]")}");
            toStringOutput.Add($"this.ModifierListsToDisable = {(this.ModifierListsToDisable == null ? "null" : $"[{string.Join(", ", this.ModifierListsToDisable)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ItemIds)
                .ModifierListsToEnable(this.ModifierListsToEnable)
                .ModifierListsToDisable(this.ModifierListsToDisable);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "modifier_lists_to_enable", false },
                { "modifier_lists_to_disable", false },
            };

            private IList<string> itemIds;
            private IList<string> modifierListsToEnable;
            private IList<string> modifierListsToDisable;

            /// <summary>
            /// Initialize Builder for UpdateItemModifierListsRequest.
            /// </summary>
            /// <param name="itemIds"> itemIds. </param>
            public Builder(
                IList<string> itemIds)
            {
                this.itemIds = itemIds;
            }

             /// <summary>
             /// ItemIds.
             /// </summary>
             /// <param name="itemIds"> itemIds. </param>
             /// <returns> Builder. </returns>
            public Builder ItemIds(IList<string> itemIds)
            {
                this.itemIds = itemIds;
                return this;
            }

             /// <summary>
             /// ModifierListsToEnable.
             /// </summary>
             /// <param name="modifierListsToEnable"> modifierListsToEnable. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListsToEnable(IList<string> modifierListsToEnable)
            {
                shouldSerialize["modifier_lists_to_enable"] = true;
                this.modifierListsToEnable = modifierListsToEnable;
                return this;
            }

             /// <summary>
             /// ModifierListsToDisable.
             /// </summary>
             /// <param name="modifierListsToDisable"> modifierListsToDisable. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListsToDisable(IList<string> modifierListsToDisable)
            {
                shouldSerialize["modifier_lists_to_disable"] = true;
                this.modifierListsToDisable = modifierListsToDisable;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifierListsToEnable()
            {
                this.shouldSerialize["modifier_lists_to_enable"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifierListsToDisable()
            {
                this.shouldSerialize["modifier_lists_to_disable"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateItemModifierListsRequest. </returns>
            public UpdateItemModifierListsRequest Build()
            {
                return new UpdateItemModifierListsRequest(shouldSerialize,
                    this.itemIds,
                    this.modifierListsToEnable,
                    this.modifierListsToDisable);
            }
        }
    }
}