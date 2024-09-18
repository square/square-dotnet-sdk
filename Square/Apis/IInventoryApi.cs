using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Http.Client;
using Square.Http.Request;
using Square.Http.Response;
using Square.Utilities;

namespace Square.Apis
{
    /// <summary>
    /// IInventoryApi.
    /// </summary>
    public interface IInventoryApi
    {
        /// <summary>
        /// Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        [Obsolete]
        Models.RetrieveInventoryAdjustmentResponse DeprecatedRetrieveInventoryAdjustment(
                string adjustmentId);

        /// <summary>
        /// Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.RetrieveInventoryAdjustmentResponse> DeprecatedRetrieveInventoryAdjustmentAsync(
                string adjustmentId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the [InventoryAdjustment]($m/InventoryAdjustment) object.
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        Models.RetrieveInventoryAdjustmentResponse RetrieveInventoryAdjustment(
                string adjustmentId);

        /// <summary>
        /// Returns the [InventoryAdjustment]($m/InventoryAdjustment) object.
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        Task<Models.RetrieveInventoryAdjustmentResponse> RetrieveInventoryAdjustmentAsync(
                string adjustmentId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        [Obsolete]
        Models.BatchChangeInventoryResponse DeprecatedBatchChangeInventory(
                Models.BatchChangeInventoryRequest body);

        /// <summary>
        /// Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.BatchChangeInventoryResponse> DeprecatedBatchChangeInventoryAsync(
                Models.BatchChangeInventoryRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        Models.BatchRetrieveInventoryChangesResponse DeprecatedBatchRetrieveInventoryChanges(
                Models.BatchRetrieveInventoryChangesRequest body);

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.BatchRetrieveInventoryChangesResponse> DeprecatedBatchRetrieveInventoryChangesAsync(
                Models.BatchRetrieveInventoryChangesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        [Obsolete]
        Models.BatchRetrieveInventoryCountsResponse DeprecatedBatchRetrieveInventoryCounts(
                Models.BatchRetrieveInventoryCountsRequest body);

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.BatchRetrieveInventoryCountsResponse> DeprecatedBatchRetrieveInventoryCountsAsync(
                Models.BatchRetrieveInventoryCountsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects.
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        Models.BatchChangeInventoryResponse BatchChangeInventory(
                Models.BatchChangeInventoryRequest body);

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects.
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        Task<Models.BatchChangeInventoryResponse> BatchChangeInventoryAsync(
                Models.BatchChangeInventoryRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns historical physical counts and adjustments based on the.
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their.
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries.
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        Models.BatchRetrieveInventoryChangesResponse BatchRetrieveInventoryChanges(
                Models.BatchRetrieveInventoryChangesRequest body);

        /// <summary>
        /// Returns historical physical counts and adjustments based on the.
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their.
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries.
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        Task<Models.BatchRetrieveInventoryChangesResponse> BatchRetrieveInventoryChangesAsync(
                Models.BatchRetrieveInventoryChangesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns current counts for the provided.
        /// [CatalogObject]($m/CatalogObject)s at the requested.
        /// [Location]($m/Location)s.
        /// Results are paginated and sorted in descending order according to their.
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that.
        /// time (based on the server timestamp for the most recent change) are.
        /// returned. This allows clients to perform a "sync" operation, for example.
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        Models.BatchRetrieveInventoryCountsResponse BatchRetrieveInventoryCounts(
                Models.BatchRetrieveInventoryCountsRequest body);

        /// <summary>
        /// Returns current counts for the provided.
        /// [CatalogObject]($m/CatalogObject)s at the requested.
        /// [Location]($m/Location)s.
        /// Results are paginated and sorted in descending order according to their.
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that.
        /// time (based on the server timestamp for the most recent change) are.
        /// returned. This allows clients to perform a "sync" operation, for example.
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        Task<Models.BatchRetrieveInventoryCountsResponse> BatchRetrieveInventoryCountsAsync(
                Models.BatchRetrieveInventoryCountsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        [Obsolete]
        Models.RetrieveInventoryPhysicalCountResponse DeprecatedRetrieveInventoryPhysicalCount(
                string physicalCountId);

        /// <summary>
        /// Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.RetrieveInventoryPhysicalCountResponse> DeprecatedRetrieveInventoryPhysicalCountAsync(
                string physicalCountId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        Models.RetrieveInventoryPhysicalCountResponse RetrieveInventoryPhysicalCount(
                string physicalCountId);

        /// <summary>
        /// Returns the [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        Task<Models.RetrieveInventoryPhysicalCountResponse> RetrieveInventoryPhysicalCountAsync(
                string physicalCountId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the [InventoryTransfer]($m/InventoryTransfer) object.
        /// with the provided `transfer_id`.
        /// </summary>
        /// <param name="transferId">Required parameter: ID of the [InventoryTransfer](entity:InventoryTransfer) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryTransferResponse response from the API call.</returns>
        Models.RetrieveInventoryTransferResponse RetrieveInventoryTransfer(
                string transferId);

        /// <summary>
        /// Returns the [InventoryTransfer]($m/InventoryTransfer) object.
        /// with the provided `transfer_id`.
        /// </summary>
        /// <param name="transferId">Required parameter: ID of the [InventoryTransfer](entity:InventoryTransfer) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryTransferResponse response from the API call.</returns>
        Task<Models.RetrieveInventoryTransferResponse> RetrieveInventoryTransferAsync(
                string transferId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the current calculated stock count for a given.
        /// [CatalogObject]($m/CatalogObject) at a given set of.
        /// [Location]($m/Location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](entity:CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location](entity:Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <returns>Returns the Models.RetrieveInventoryCountResponse response from the API call.</returns>
        Models.RetrieveInventoryCountResponse RetrieveInventoryCount(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null);

        /// <summary>
        /// Retrieves the current calculated stock count for a given.
        /// [CatalogObject]($m/CatalogObject) at a given set of.
        /// [Location]($m/Location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](entity:CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location](entity:Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryCountResponse response from the API call.</returns>
        Task<Models.RetrieveInventoryCountResponse> RetrieveInventoryCountAsync(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the.
        /// provided [CatalogObject](entity:CatalogObject) at the requested.
        /// [Location](entity:Location)s.
        /// You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges).
        /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
        /// Results are paginated and sorted in descending order according to their.
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be.
        /// used to display recent changes for a specific item. For more.
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](entity:CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location](entity:Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <returns>Returns the Models.RetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        Models.RetrieveInventoryChangesResponse RetrieveInventoryChanges(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null);

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the.
        /// provided [CatalogObject](entity:CatalogObject) at the requested.
        /// [Location](entity:Location)s.
        /// You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges).
        /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
        /// Results are paginated and sorted in descending order according to their.
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be.
        /// used to display recent changes for a specific item. For more.
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](entity:CatalogObject) to retrieve..</param>
        /// <param name="locationIds">Optional parameter: The [Location](entity:Location) IDs to look up as a comma-separated list. An empty list queries all locations..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.RetrieveInventoryChangesResponse> RetrieveInventoryChangesAsync(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null,
                CancellationToken cancellationToken = default);
    }
}