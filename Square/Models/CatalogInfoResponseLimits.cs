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
    /// CatalogInfoResponseLimits.
    /// </summary>
    public class CatalogInfoResponseLimits
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogInfoResponseLimits"/> class.
        /// </summary>
        /// <param name="batchUpsertMaxObjectsPerBatch">batch_upsert_max_objects_per_batch.</param>
        /// <param name="batchUpsertMaxTotalObjects">batch_upsert_max_total_objects.</param>
        /// <param name="batchRetrieveMaxObjectIds">batch_retrieve_max_object_ids.</param>
        /// <param name="searchMaxPageLimit">search_max_page_limit.</param>
        /// <param name="batchDeleteMaxObjectIds">batch_delete_max_object_ids.</param>
        /// <param name="updateItemTaxesMaxItemIds">update_item_taxes_max_item_ids.</param>
        /// <param name="updateItemTaxesMaxTaxesToEnable">update_item_taxes_max_taxes_to_enable.</param>
        /// <param name="updateItemTaxesMaxTaxesToDisable">update_item_taxes_max_taxes_to_disable.</param>
        /// <param name="updateItemModifierListsMaxItemIds">update_item_modifier_lists_max_item_ids.</param>
        /// <param name="updateItemModifierListsMaxModifierListsToEnable">update_item_modifier_lists_max_modifier_lists_to_enable.</param>
        /// <param name="updateItemModifierListsMaxModifierListsToDisable">update_item_modifier_lists_max_modifier_lists_to_disable.</param>
        public CatalogInfoResponseLimits(
            int? batchUpsertMaxObjectsPerBatch = null,
            int? batchUpsertMaxTotalObjects = null,
            int? batchRetrieveMaxObjectIds = null,
            int? searchMaxPageLimit = null,
            int? batchDeleteMaxObjectIds = null,
            int? updateItemTaxesMaxItemIds = null,
            int? updateItemTaxesMaxTaxesToEnable = null,
            int? updateItemTaxesMaxTaxesToDisable = null,
            int? updateItemModifierListsMaxItemIds = null,
            int? updateItemModifierListsMaxModifierListsToEnable = null,
            int? updateItemModifierListsMaxModifierListsToDisable = null)
        {
            this.BatchUpsertMaxObjectsPerBatch = batchUpsertMaxObjectsPerBatch;
            this.BatchUpsertMaxTotalObjects = batchUpsertMaxTotalObjects;
            this.BatchRetrieveMaxObjectIds = batchRetrieveMaxObjectIds;
            this.SearchMaxPageLimit = searchMaxPageLimit;
            this.BatchDeleteMaxObjectIds = batchDeleteMaxObjectIds;
            this.UpdateItemTaxesMaxItemIds = updateItemTaxesMaxItemIds;
            this.UpdateItemTaxesMaxTaxesToEnable = updateItemTaxesMaxTaxesToEnable;
            this.UpdateItemTaxesMaxTaxesToDisable = updateItemTaxesMaxTaxesToDisable;
            this.UpdateItemModifierListsMaxItemIds = updateItemModifierListsMaxItemIds;
            this.UpdateItemModifierListsMaxModifierListsToEnable = updateItemModifierListsMaxModifierListsToEnable;
            this.UpdateItemModifierListsMaxModifierListsToDisable = updateItemModifierListsMaxModifierListsToDisable;
        }

        /// <summary>
        /// The maximum number of objects that may appear within a single batch in a
        /// `/v2/catalog/batch-upsert` request.
        /// </summary>
        [JsonProperty("batch_upsert_max_objects_per_batch", NullValueHandling = NullValueHandling.Ignore)]
        public int? BatchUpsertMaxObjectsPerBatch { get; }

        /// <summary>
        /// The maximum number of objects that may appear across all batches in a
        /// `/v2/catalog/batch-upsert` request.
        /// </summary>
        [JsonProperty("batch_upsert_max_total_objects", NullValueHandling = NullValueHandling.Ignore)]
        public int? BatchUpsertMaxTotalObjects { get; }

        /// <summary>
        /// The maximum number of object IDs that may appear in a `/v2/catalog/batch-retrieve`
        /// request.
        /// </summary>
        [JsonProperty("batch_retrieve_max_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int? BatchRetrieveMaxObjectIds { get; }

        /// <summary>
        /// The maximum number of results that may be returned in a page of a
        /// `/v2/catalog/search` response.
        /// </summary>
        [JsonProperty("search_max_page_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? SearchMaxPageLimit { get; }

        /// <summary>
        /// The maximum number of object IDs that may be included in a single
        /// `/v2/catalog/batch-delete` request.
        /// </summary>
        [JsonProperty("batch_delete_max_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int? BatchDeleteMaxObjectIds { get; }

        /// <summary>
        /// The maximum number of item IDs that may be included in a single
        /// `/v2/catalog/update-item-taxes` request.
        /// </summary>
        [JsonProperty("update_item_taxes_max_item_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdateItemTaxesMaxItemIds { get; }

        /// <summary>
        /// The maximum number of tax IDs to be enabled that may be included in a single
        /// `/v2/catalog/update-item-taxes` request.
        /// </summary>
        [JsonProperty("update_item_taxes_max_taxes_to_enable", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdateItemTaxesMaxTaxesToEnable { get; }

        /// <summary>
        /// The maximum number of tax IDs to be disabled that may be included in a single
        /// `/v2/catalog/update-item-taxes` request.
        /// </summary>
        [JsonProperty("update_item_taxes_max_taxes_to_disable", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdateItemTaxesMaxTaxesToDisable { get; }

        /// <summary>
        /// The maximum number of item IDs that may be included in a single
        /// `/v2/catalog/update-item-modifier-lists` request.
        /// </summary>
        [JsonProperty("update_item_modifier_lists_max_item_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdateItemModifierListsMaxItemIds { get; }

        /// <summary>
        /// The maximum number of modifier list IDs to be enabled that may be included in
        /// a single `/v2/catalog/update-item-modifier-lists` request.
        /// </summary>
        [JsonProperty("update_item_modifier_lists_max_modifier_lists_to_enable", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdateItemModifierListsMaxModifierListsToEnable { get; }

        /// <summary>
        /// The maximum number of modifier list IDs to be disabled that may be included in
        /// a single `/v2/catalog/update-item-modifier-lists` request.
        /// </summary>
        [JsonProperty("update_item_modifier_lists_max_modifier_lists_to_disable", NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdateItemModifierListsMaxModifierListsToDisable { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogInfoResponseLimits : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogInfoResponseLimits other &&
                ((this.BatchUpsertMaxObjectsPerBatch == null && other.BatchUpsertMaxObjectsPerBatch == null) || (this.BatchUpsertMaxObjectsPerBatch?.Equals(other.BatchUpsertMaxObjectsPerBatch) == true)) &&
                ((this.BatchUpsertMaxTotalObjects == null && other.BatchUpsertMaxTotalObjects == null) || (this.BatchUpsertMaxTotalObjects?.Equals(other.BatchUpsertMaxTotalObjects) == true)) &&
                ((this.BatchRetrieveMaxObjectIds == null && other.BatchRetrieveMaxObjectIds == null) || (this.BatchRetrieveMaxObjectIds?.Equals(other.BatchRetrieveMaxObjectIds) == true)) &&
                ((this.SearchMaxPageLimit == null && other.SearchMaxPageLimit == null) || (this.SearchMaxPageLimit?.Equals(other.SearchMaxPageLimit) == true)) &&
                ((this.BatchDeleteMaxObjectIds == null && other.BatchDeleteMaxObjectIds == null) || (this.BatchDeleteMaxObjectIds?.Equals(other.BatchDeleteMaxObjectIds) == true)) &&
                ((this.UpdateItemTaxesMaxItemIds == null && other.UpdateItemTaxesMaxItemIds == null) || (this.UpdateItemTaxesMaxItemIds?.Equals(other.UpdateItemTaxesMaxItemIds) == true)) &&
                ((this.UpdateItemTaxesMaxTaxesToEnable == null && other.UpdateItemTaxesMaxTaxesToEnable == null) || (this.UpdateItemTaxesMaxTaxesToEnable?.Equals(other.UpdateItemTaxesMaxTaxesToEnable) == true)) &&
                ((this.UpdateItemTaxesMaxTaxesToDisable == null && other.UpdateItemTaxesMaxTaxesToDisable == null) || (this.UpdateItemTaxesMaxTaxesToDisable?.Equals(other.UpdateItemTaxesMaxTaxesToDisable) == true)) &&
                ((this.UpdateItemModifierListsMaxItemIds == null && other.UpdateItemModifierListsMaxItemIds == null) || (this.UpdateItemModifierListsMaxItemIds?.Equals(other.UpdateItemModifierListsMaxItemIds) == true)) &&
                ((this.UpdateItemModifierListsMaxModifierListsToEnable == null && other.UpdateItemModifierListsMaxModifierListsToEnable == null) || (this.UpdateItemModifierListsMaxModifierListsToEnable?.Equals(other.UpdateItemModifierListsMaxModifierListsToEnable) == true)) &&
                ((this.UpdateItemModifierListsMaxModifierListsToDisable == null && other.UpdateItemModifierListsMaxModifierListsToDisable == null) || (this.UpdateItemModifierListsMaxModifierListsToDisable?.Equals(other.UpdateItemModifierListsMaxModifierListsToDisable) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 163529302;

            if (this.BatchUpsertMaxObjectsPerBatch != null)
            {
               hashCode += this.BatchUpsertMaxObjectsPerBatch.GetHashCode();
            }

            if (this.BatchUpsertMaxTotalObjects != null)
            {
               hashCode += this.BatchUpsertMaxTotalObjects.GetHashCode();
            }

            if (this.BatchRetrieveMaxObjectIds != null)
            {
               hashCode += this.BatchRetrieveMaxObjectIds.GetHashCode();
            }

            if (this.SearchMaxPageLimit != null)
            {
               hashCode += this.SearchMaxPageLimit.GetHashCode();
            }

            if (this.BatchDeleteMaxObjectIds != null)
            {
               hashCode += this.BatchDeleteMaxObjectIds.GetHashCode();
            }

            if (this.UpdateItemTaxesMaxItemIds != null)
            {
               hashCode += this.UpdateItemTaxesMaxItemIds.GetHashCode();
            }

            if (this.UpdateItemTaxesMaxTaxesToEnable != null)
            {
               hashCode += this.UpdateItemTaxesMaxTaxesToEnable.GetHashCode();
            }

            if (this.UpdateItemTaxesMaxTaxesToDisable != null)
            {
               hashCode += this.UpdateItemTaxesMaxTaxesToDisable.GetHashCode();
            }

            if (this.UpdateItemModifierListsMaxItemIds != null)
            {
               hashCode += this.UpdateItemModifierListsMaxItemIds.GetHashCode();
            }

            if (this.UpdateItemModifierListsMaxModifierListsToEnable != null)
            {
               hashCode += this.UpdateItemModifierListsMaxModifierListsToEnable.GetHashCode();
            }

            if (this.UpdateItemModifierListsMaxModifierListsToDisable != null)
            {
               hashCode += this.UpdateItemModifierListsMaxModifierListsToDisable.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BatchUpsertMaxObjectsPerBatch = {(this.BatchUpsertMaxObjectsPerBatch == null ? "null" : this.BatchUpsertMaxObjectsPerBatch.ToString())}");
            toStringOutput.Add($"this.BatchUpsertMaxTotalObjects = {(this.BatchUpsertMaxTotalObjects == null ? "null" : this.BatchUpsertMaxTotalObjects.ToString())}");
            toStringOutput.Add($"this.BatchRetrieveMaxObjectIds = {(this.BatchRetrieveMaxObjectIds == null ? "null" : this.BatchRetrieveMaxObjectIds.ToString())}");
            toStringOutput.Add($"this.SearchMaxPageLimit = {(this.SearchMaxPageLimit == null ? "null" : this.SearchMaxPageLimit.ToString())}");
            toStringOutput.Add($"this.BatchDeleteMaxObjectIds = {(this.BatchDeleteMaxObjectIds == null ? "null" : this.BatchDeleteMaxObjectIds.ToString())}");
            toStringOutput.Add($"this.UpdateItemTaxesMaxItemIds = {(this.UpdateItemTaxesMaxItemIds == null ? "null" : this.UpdateItemTaxesMaxItemIds.ToString())}");
            toStringOutput.Add($"this.UpdateItemTaxesMaxTaxesToEnable = {(this.UpdateItemTaxesMaxTaxesToEnable == null ? "null" : this.UpdateItemTaxesMaxTaxesToEnable.ToString())}");
            toStringOutput.Add($"this.UpdateItemTaxesMaxTaxesToDisable = {(this.UpdateItemTaxesMaxTaxesToDisable == null ? "null" : this.UpdateItemTaxesMaxTaxesToDisable.ToString())}");
            toStringOutput.Add($"this.UpdateItemModifierListsMaxItemIds = {(this.UpdateItemModifierListsMaxItemIds == null ? "null" : this.UpdateItemModifierListsMaxItemIds.ToString())}");
            toStringOutput.Add($"this.UpdateItemModifierListsMaxModifierListsToEnable = {(this.UpdateItemModifierListsMaxModifierListsToEnable == null ? "null" : this.UpdateItemModifierListsMaxModifierListsToEnable.ToString())}");
            toStringOutput.Add($"this.UpdateItemModifierListsMaxModifierListsToDisable = {(this.UpdateItemModifierListsMaxModifierListsToDisable == null ? "null" : this.UpdateItemModifierListsMaxModifierListsToDisable.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BatchUpsertMaxObjectsPerBatch(this.BatchUpsertMaxObjectsPerBatch)
                .BatchUpsertMaxTotalObjects(this.BatchUpsertMaxTotalObjects)
                .BatchRetrieveMaxObjectIds(this.BatchRetrieveMaxObjectIds)
                .SearchMaxPageLimit(this.SearchMaxPageLimit)
                .BatchDeleteMaxObjectIds(this.BatchDeleteMaxObjectIds)
                .UpdateItemTaxesMaxItemIds(this.UpdateItemTaxesMaxItemIds)
                .UpdateItemTaxesMaxTaxesToEnable(this.UpdateItemTaxesMaxTaxesToEnable)
                .UpdateItemTaxesMaxTaxesToDisable(this.UpdateItemTaxesMaxTaxesToDisable)
                .UpdateItemModifierListsMaxItemIds(this.UpdateItemModifierListsMaxItemIds)
                .UpdateItemModifierListsMaxModifierListsToEnable(this.UpdateItemModifierListsMaxModifierListsToEnable)
                .UpdateItemModifierListsMaxModifierListsToDisable(this.UpdateItemModifierListsMaxModifierListsToDisable);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? batchUpsertMaxObjectsPerBatch;
            private int? batchUpsertMaxTotalObjects;
            private int? batchRetrieveMaxObjectIds;
            private int? searchMaxPageLimit;
            private int? batchDeleteMaxObjectIds;
            private int? updateItemTaxesMaxItemIds;
            private int? updateItemTaxesMaxTaxesToEnable;
            private int? updateItemTaxesMaxTaxesToDisable;
            private int? updateItemModifierListsMaxItemIds;
            private int? updateItemModifierListsMaxModifierListsToEnable;
            private int? updateItemModifierListsMaxModifierListsToDisable;

             /// <summary>
             /// BatchUpsertMaxObjectsPerBatch.
             /// </summary>
             /// <param name="batchUpsertMaxObjectsPerBatch"> batchUpsertMaxObjectsPerBatch. </param>
             /// <returns> Builder. </returns>
            public Builder BatchUpsertMaxObjectsPerBatch(int? batchUpsertMaxObjectsPerBatch)
            {
                this.batchUpsertMaxObjectsPerBatch = batchUpsertMaxObjectsPerBatch;
                return this;
            }

             /// <summary>
             /// BatchUpsertMaxTotalObjects.
             /// </summary>
             /// <param name="batchUpsertMaxTotalObjects"> batchUpsertMaxTotalObjects. </param>
             /// <returns> Builder. </returns>
            public Builder BatchUpsertMaxTotalObjects(int? batchUpsertMaxTotalObjects)
            {
                this.batchUpsertMaxTotalObjects = batchUpsertMaxTotalObjects;
                return this;
            }

             /// <summary>
             /// BatchRetrieveMaxObjectIds.
             /// </summary>
             /// <param name="batchRetrieveMaxObjectIds"> batchRetrieveMaxObjectIds. </param>
             /// <returns> Builder. </returns>
            public Builder BatchRetrieveMaxObjectIds(int? batchRetrieveMaxObjectIds)
            {
                this.batchRetrieveMaxObjectIds = batchRetrieveMaxObjectIds;
                return this;
            }

             /// <summary>
             /// SearchMaxPageLimit.
             /// </summary>
             /// <param name="searchMaxPageLimit"> searchMaxPageLimit. </param>
             /// <returns> Builder. </returns>
            public Builder SearchMaxPageLimit(int? searchMaxPageLimit)
            {
                this.searchMaxPageLimit = searchMaxPageLimit;
                return this;
            }

             /// <summary>
             /// BatchDeleteMaxObjectIds.
             /// </summary>
             /// <param name="batchDeleteMaxObjectIds"> batchDeleteMaxObjectIds. </param>
             /// <returns> Builder. </returns>
            public Builder BatchDeleteMaxObjectIds(int? batchDeleteMaxObjectIds)
            {
                this.batchDeleteMaxObjectIds = batchDeleteMaxObjectIds;
                return this;
            }

             /// <summary>
             /// UpdateItemTaxesMaxItemIds.
             /// </summary>
             /// <param name="updateItemTaxesMaxItemIds"> updateItemTaxesMaxItemIds. </param>
             /// <returns> Builder. </returns>
            public Builder UpdateItemTaxesMaxItemIds(int? updateItemTaxesMaxItemIds)
            {
                this.updateItemTaxesMaxItemIds = updateItemTaxesMaxItemIds;
                return this;
            }

             /// <summary>
             /// UpdateItemTaxesMaxTaxesToEnable.
             /// </summary>
             /// <param name="updateItemTaxesMaxTaxesToEnable"> updateItemTaxesMaxTaxesToEnable. </param>
             /// <returns> Builder. </returns>
            public Builder UpdateItemTaxesMaxTaxesToEnable(int? updateItemTaxesMaxTaxesToEnable)
            {
                this.updateItemTaxesMaxTaxesToEnable = updateItemTaxesMaxTaxesToEnable;
                return this;
            }

             /// <summary>
             /// UpdateItemTaxesMaxTaxesToDisable.
             /// </summary>
             /// <param name="updateItemTaxesMaxTaxesToDisable"> updateItemTaxesMaxTaxesToDisable. </param>
             /// <returns> Builder. </returns>
            public Builder UpdateItemTaxesMaxTaxesToDisable(int? updateItemTaxesMaxTaxesToDisable)
            {
                this.updateItemTaxesMaxTaxesToDisable = updateItemTaxesMaxTaxesToDisable;
                return this;
            }

             /// <summary>
             /// UpdateItemModifierListsMaxItemIds.
             /// </summary>
             /// <param name="updateItemModifierListsMaxItemIds"> updateItemModifierListsMaxItemIds. </param>
             /// <returns> Builder. </returns>
            public Builder UpdateItemModifierListsMaxItemIds(int? updateItemModifierListsMaxItemIds)
            {
                this.updateItemModifierListsMaxItemIds = updateItemModifierListsMaxItemIds;
                return this;
            }

             /// <summary>
             /// UpdateItemModifierListsMaxModifierListsToEnable.
             /// </summary>
             /// <param name="updateItemModifierListsMaxModifierListsToEnable"> updateItemModifierListsMaxModifierListsToEnable. </param>
             /// <returns> Builder. </returns>
            public Builder UpdateItemModifierListsMaxModifierListsToEnable(int? updateItemModifierListsMaxModifierListsToEnable)
            {
                this.updateItemModifierListsMaxModifierListsToEnable = updateItemModifierListsMaxModifierListsToEnable;
                return this;
            }

             /// <summary>
             /// UpdateItemModifierListsMaxModifierListsToDisable.
             /// </summary>
             /// <param name="updateItemModifierListsMaxModifierListsToDisable"> updateItemModifierListsMaxModifierListsToDisable. </param>
             /// <returns> Builder. </returns>
            public Builder UpdateItemModifierListsMaxModifierListsToDisable(int? updateItemModifierListsMaxModifierListsToDisable)
            {
                this.updateItemModifierListsMaxModifierListsToDisable = updateItemModifierListsMaxModifierListsToDisable;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogInfoResponseLimits. </returns>
            public CatalogInfoResponseLimits Build()
            {
                return new CatalogInfoResponseLimits(
                    this.batchUpsertMaxObjectsPerBatch,
                    this.batchUpsertMaxTotalObjects,
                    this.batchRetrieveMaxObjectIds,
                    this.searchMaxPageLimit,
                    this.batchDeleteMaxObjectIds,
                    this.updateItemTaxesMaxItemIds,
                    this.updateItemTaxesMaxTaxesToEnable,
                    this.updateItemTaxesMaxTaxesToDisable,
                    this.updateItemModifierListsMaxItemIds,
                    this.updateItemModifierListsMaxModifierListsToEnable,
                    this.updateItemModifierListsMaxModifierListsToDisable);
            }
        }
    }
}