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
    public class CatalogInfoResponseLimits 
    {
        public CatalogInfoResponseLimits(int? batchUpsertMaxObjectsPerBatch = null,
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
            BatchUpsertMaxObjectsPerBatch = batchUpsertMaxObjectsPerBatch;
            BatchUpsertMaxTotalObjects = batchUpsertMaxTotalObjects;
            BatchRetrieveMaxObjectIds = batchRetrieveMaxObjectIds;
            SearchMaxPageLimit = searchMaxPageLimit;
            BatchDeleteMaxObjectIds = batchDeleteMaxObjectIds;
            UpdateItemTaxesMaxItemIds = updateItemTaxesMaxItemIds;
            UpdateItemTaxesMaxTaxesToEnable = updateItemTaxesMaxTaxesToEnable;
            UpdateItemTaxesMaxTaxesToDisable = updateItemTaxesMaxTaxesToDisable;
            UpdateItemModifierListsMaxItemIds = updateItemModifierListsMaxItemIds;
            UpdateItemModifierListsMaxModifierListsToEnable = updateItemModifierListsMaxModifierListsToEnable;
            UpdateItemModifierListsMaxModifierListsToDisable = updateItemModifierListsMaxModifierListsToDisable;
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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BatchUpsertMaxObjectsPerBatch(BatchUpsertMaxObjectsPerBatch)
                .BatchUpsertMaxTotalObjects(BatchUpsertMaxTotalObjects)
                .BatchRetrieveMaxObjectIds(BatchRetrieveMaxObjectIds)
                .SearchMaxPageLimit(SearchMaxPageLimit)
                .BatchDeleteMaxObjectIds(BatchDeleteMaxObjectIds)
                .UpdateItemTaxesMaxItemIds(UpdateItemTaxesMaxItemIds)
                .UpdateItemTaxesMaxTaxesToEnable(UpdateItemTaxesMaxTaxesToEnable)
                .UpdateItemTaxesMaxTaxesToDisable(UpdateItemTaxesMaxTaxesToDisable)
                .UpdateItemModifierListsMaxItemIds(UpdateItemModifierListsMaxItemIds)
                .UpdateItemModifierListsMaxModifierListsToEnable(UpdateItemModifierListsMaxModifierListsToEnable)
                .UpdateItemModifierListsMaxModifierListsToDisable(UpdateItemModifierListsMaxModifierListsToDisable);
            return builder;
        }

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



            public Builder BatchUpsertMaxObjectsPerBatch(int? batchUpsertMaxObjectsPerBatch)
            {
                this.batchUpsertMaxObjectsPerBatch = batchUpsertMaxObjectsPerBatch;
                return this;
            }

            public Builder BatchUpsertMaxTotalObjects(int? batchUpsertMaxTotalObjects)
            {
                this.batchUpsertMaxTotalObjects = batchUpsertMaxTotalObjects;
                return this;
            }

            public Builder BatchRetrieveMaxObjectIds(int? batchRetrieveMaxObjectIds)
            {
                this.batchRetrieveMaxObjectIds = batchRetrieveMaxObjectIds;
                return this;
            }

            public Builder SearchMaxPageLimit(int? searchMaxPageLimit)
            {
                this.searchMaxPageLimit = searchMaxPageLimit;
                return this;
            }

            public Builder BatchDeleteMaxObjectIds(int? batchDeleteMaxObjectIds)
            {
                this.batchDeleteMaxObjectIds = batchDeleteMaxObjectIds;
                return this;
            }

            public Builder UpdateItemTaxesMaxItemIds(int? updateItemTaxesMaxItemIds)
            {
                this.updateItemTaxesMaxItemIds = updateItemTaxesMaxItemIds;
                return this;
            }

            public Builder UpdateItemTaxesMaxTaxesToEnable(int? updateItemTaxesMaxTaxesToEnable)
            {
                this.updateItemTaxesMaxTaxesToEnable = updateItemTaxesMaxTaxesToEnable;
                return this;
            }

            public Builder UpdateItemTaxesMaxTaxesToDisable(int? updateItemTaxesMaxTaxesToDisable)
            {
                this.updateItemTaxesMaxTaxesToDisable = updateItemTaxesMaxTaxesToDisable;
                return this;
            }

            public Builder UpdateItemModifierListsMaxItemIds(int? updateItemModifierListsMaxItemIds)
            {
                this.updateItemModifierListsMaxItemIds = updateItemModifierListsMaxItemIds;
                return this;
            }

            public Builder UpdateItemModifierListsMaxModifierListsToEnable(int? updateItemModifierListsMaxModifierListsToEnable)
            {
                this.updateItemModifierListsMaxModifierListsToEnable = updateItemModifierListsMaxModifierListsToEnable;
                return this;
            }

            public Builder UpdateItemModifierListsMaxModifierListsToDisable(int? updateItemModifierListsMaxModifierListsToDisable)
            {
                this.updateItemModifierListsMaxModifierListsToDisable = updateItemModifierListsMaxModifierListsToDisable;
                return this;
            }

            public CatalogInfoResponseLimits Build()
            {
                return new CatalogInfoResponseLimits(batchUpsertMaxObjectsPerBatch,
                    batchUpsertMaxTotalObjects,
                    batchRetrieveMaxObjectIds,
                    searchMaxPageLimit,
                    batchDeleteMaxObjectIds,
                    updateItemTaxesMaxItemIds,
                    updateItemTaxesMaxTaxesToEnable,
                    updateItemTaxesMaxTaxesToDisable,
                    updateItemModifierListsMaxItemIds,
                    updateItemModifierListsMaxModifierListsToEnable,
                    updateItemModifierListsMaxModifierListsToDisable);
            }
        }
    }
}