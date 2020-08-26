using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IInventoryApi
    {
        /// <summary>
        /// Returns the [InventoryAdjustment](#type-inventoryadjustment) object
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](#type-inventoryadjustment) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call</return>
        Models.RetrieveInventoryAdjustmentResponse RetrieveInventoryAdjustment(string adjustmentId);

        /// <summary>
        /// Returns the [InventoryAdjustment](#type-inventoryadjustment) object
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](#type-inventoryadjustment) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call</return>
        Task<Models.RetrieveInventoryAdjustmentResponse> RetrieveInventoryAdjustmentAsync(string adjustmentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchChangeInventoryResponse response from the API call</return>
        Models.BatchChangeInventoryResponse BatchChangeInventory(Models.BatchChangeInventoryRequest body);

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchChangeInventoryResponse response from the API call</return>
        Task<Models.BatchChangeInventoryResponse> BatchChangeInventoryAsync(Models.BatchChangeInventoryRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns historical physical counts and adjustments based on the
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call</return>
        Models.BatchRetrieveInventoryChangesResponse BatchRetrieveInventoryChanges(Models.BatchRetrieveInventoryChangesRequest body);

        /// <summary>
        /// Returns historical physical counts and adjustments based on the
        /// provided filter criteria.
        /// Results are paginated and sorted in ascending order according their
        /// `occurred_at` timestamp (oldest first).
        /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
        /// that cannot be handled by other, simpler endpoints.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call</return>
        Task<Models.BatchRetrieveInventoryChangesResponse> BatchRetrieveInventoryChangesAsync(Models.BatchRetrieveInventoryChangesRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns current counts for the provided
        /// [CatalogObject](#type-catalogobject)s at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that
        /// time (based on the server timestamp for the most recent change) are
        /// returned. This allows clients to perform a "sync" operation, for example
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call</return>
        Models.BatchRetrieveInventoryCountsResponse BatchRetrieveInventoryCounts(Models.BatchRetrieveInventoryCountsRequest body);

        /// <summary>
        /// Returns current counts for the provided
        /// [CatalogObject](#type-catalogobject)s at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `calculated_at` timestamp (newest first).
        /// When `updated_after` is specified, only counts that have changed since that
        /// time (based on the server timestamp for the most recent change) are
        /// returned. This allows clients to perform a "sync" operation, for example
        /// in response to receiving a Webhook notification.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call</return>
        Task<Models.BatchRetrieveInventoryCountsResponse> BatchRetrieveInventoryCountsAsync(Models.BatchRetrieveInventoryCountsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the [InventoryPhysicalCount](#type-inventoryphysicalcount)
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](#type-inventoryphysicalcount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call</return>
        Models.RetrieveInventoryPhysicalCountResponse RetrieveInventoryPhysicalCount(string physicalCountId);

        /// <summary>
        /// Returns the [InventoryPhysicalCount](#type-inventoryphysicalcount)
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](#type-inventoryphysicalcount) to retrieve.</param>
        /// <return>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call</return>
        Task<Models.RetrieveInventoryPhysicalCountResponse> RetrieveInventoryPhysicalCountAsync(string physicalCountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the current calculated stock count for a given
        /// [CatalogObject](#type-catalogobject) at a given set of
        /// [Location](#type-location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryCountResponse response from the API call</return>
        Models.RetrieveInventoryCountResponse RetrieveInventoryCount(string catalogObjectId, string locationIds = null, string cursor = null);

        /// <summary>
        /// Retrieves the current calculated stock count for a given
        /// [CatalogObject](#type-catalogobject) at a given set of
        /// [Location](#type-location)s. Responses are paginated and unsorted.
        /// For more sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryCountResponse response from the API call</return>
        Task<Models.RetrieveInventoryCountResponse> RetrieveInventoryCountAsync(string catalogObjectId, string locationIds = null, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the
        /// provided [CatalogObject](#type-catalogobject) at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be 
        /// used to display recent changes for a specific item. For more
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryChangesResponse response from the API call</return>
        Models.RetrieveInventoryChangesResponse RetrieveInventoryChanges(string catalogObjectId, string locationIds = null, string cursor = null);

        /// <summary>
        /// Returns a set of physical counts and inventory adjustments for the
        /// provided [CatalogObject](#type-catalogobject) at the requested
        /// [Location](#type-location)s.
        /// Results are paginated and sorted in descending order according to their
        /// `occurred_at` timestamp (newest first).
        /// There are no limits on how far back the caller can page. This endpoint can be 
        /// used to display recent changes for a specific item. For more
        /// sophisticated queries, use a batch endpoint.
        /// </summary>
        /// <param name="catalogObjectId">Required parameter: ID of the [CatalogObject](#type-catalogobject) to retrieve.</param>
        /// <param name="locationIds">Optional parameter: The [Location](#type-location) IDs to look up as a comma-separated list. An empty list queries all locations.</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.</param>
        /// <return>Returns the Models.RetrieveInventoryChangesResponse response from the API call</return>
        Task<Models.RetrieveInventoryChangesResponse> RetrieveInventoryChangesAsync(string catalogObjectId, string locationIds = null, string cursor = null, CancellationToken cancellationToken = default);

    }
}