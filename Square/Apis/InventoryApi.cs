using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;
using System.Net.Http;

namespace Square.Apis
{
    /// <summary>
    /// InventoryApi.
    /// </summary>
    internal class InventoryApi : BaseApi, IInventoryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryApi"/> class.
        /// </summary>
        internal InventoryApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveInventoryAdjustmentResponse DeprecatedRetrieveInventoryAdjustment(
                string adjustmentId)
            => CoreHelper.RunTask(DeprecatedRetrieveInventoryAdjustmentAsync(adjustmentId));

        /// <summary>
        /// Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveInventoryAdjustmentResponse> DeprecatedRetrieveInventoryAdjustmentAsync(
                string adjustmentId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryAdjustmentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/adjustment/{adjustment_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("adjustment_id", adjustmentId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns the [InventoryAdjustment]($m/InventoryAdjustment) object.
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        public Models.RetrieveInventoryAdjustmentResponse RetrieveInventoryAdjustment(
                string adjustmentId)
            => CoreHelper.RunTask(RetrieveInventoryAdjustmentAsync(adjustmentId));

        /// <summary>
        /// Returns the [InventoryAdjustment]($m/InventoryAdjustment) object.
        /// with the provided `adjustment_id`.
        /// </summary>
        /// <param name="adjustmentId">Required parameter: ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryAdjustmentResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryAdjustmentResponse> RetrieveInventoryAdjustmentAsync(
                string adjustmentId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryAdjustmentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/adjustments/{adjustment_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("adjustment_id", adjustmentId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        [Obsolete]
        public Models.BatchChangeInventoryResponse DeprecatedBatchChangeInventory(
                Models.BatchChangeInventoryRequest body)
            => CoreHelper.RunTask(DeprecatedBatchChangeInventoryAsync(body));

        /// <summary>
        /// Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.BatchChangeInventoryResponse> DeprecatedBatchChangeInventoryAsync(
                Models.BatchChangeInventoryRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BatchChangeInventoryResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/inventory/batch-change")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        public Models.BatchRetrieveInventoryChangesResponse DeprecatedBatchRetrieveInventoryChanges(
                Models.BatchRetrieveInventoryChangesRequest body)
            => CoreHelper.RunTask(DeprecatedBatchRetrieveInventoryChangesAsync(body));

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryChangesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.BatchRetrieveInventoryChangesResponse> DeprecatedBatchRetrieveInventoryChangesAsync(
                Models.BatchRetrieveInventoryChangesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BatchRetrieveInventoryChangesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/inventory/batch-retrieve-changes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        [Obsolete]
        public Models.BatchRetrieveInventoryCountsResponse DeprecatedBatchRetrieveInventoryCounts(
                Models.BatchRetrieveInventoryCountsRequest body)
            => CoreHelper.RunTask(DeprecatedBatchRetrieveInventoryCountsAsync(body));

        /// <summary>
        /// Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveInventoryCountsResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.BatchRetrieveInventoryCountsResponse> DeprecatedBatchRetrieveInventoryCountsAsync(
                Models.BatchRetrieveInventoryCountsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BatchRetrieveInventoryCountsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/inventory/batch-retrieve-counts")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects.
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        public Models.BatchChangeInventoryResponse BatchChangeInventory(
                Models.BatchChangeInventoryRequest body)
            => CoreHelper.RunTask(BatchChangeInventoryAsync(body));

        /// <summary>
        /// Applies adjustments and counts to the provided item quantities.
        /// On success: returns the current calculated counts for all objects.
        /// referenced in the request.
        /// On failure: returns a list of related errors.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchChangeInventoryResponse response from the API call.</returns>
        public async Task<Models.BatchChangeInventoryResponse> BatchChangeInventoryAsync(
                Models.BatchChangeInventoryRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BatchChangeInventoryResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/inventory/changes/batch-create")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.BatchRetrieveInventoryChangesResponse BatchRetrieveInventoryChanges(
                Models.BatchRetrieveInventoryChangesRequest body)
            => CoreHelper.RunTask(BatchRetrieveInventoryChangesAsync(body));

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
        public async Task<Models.BatchRetrieveInventoryChangesResponse> BatchRetrieveInventoryChangesAsync(
                Models.BatchRetrieveInventoryChangesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BatchRetrieveInventoryChangesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/inventory/changes/batch-retrieve")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.BatchRetrieveInventoryCountsResponse BatchRetrieveInventoryCounts(
                Models.BatchRetrieveInventoryCountsRequest body)
            => CoreHelper.RunTask(BatchRetrieveInventoryCountsAsync(body));

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
        public async Task<Models.BatchRetrieveInventoryCountsResponse> BatchRetrieveInventoryCountsAsync(
                Models.BatchRetrieveInventoryCountsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BatchRetrieveInventoryCountsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/inventory/counts/batch-retrieve")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveInventoryPhysicalCountResponse DeprecatedRetrieveInventoryPhysicalCount(
                string physicalCountId)
            => CoreHelper.RunTask(DeprecatedRetrieveInventoryPhysicalCountAsync(physicalCountId));

        /// <summary>
        /// Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL.
        /// is updated to conform to the standard convention.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveInventoryPhysicalCountResponse> DeprecatedRetrieveInventoryPhysicalCountAsync(
                string physicalCountId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryPhysicalCountResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/physical-count/{physical_count_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("physical_count_id", physicalCountId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns the [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        public Models.RetrieveInventoryPhysicalCountResponse RetrieveInventoryPhysicalCount(
                string physicalCountId)
            => CoreHelper.RunTask(RetrieveInventoryPhysicalCountAsync(physicalCountId));

        /// <summary>
        /// Returns the [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// object with the provided `physical_count_id`.
        /// </summary>
        /// <param name="physicalCountId">Required parameter: ID of the [InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryPhysicalCountResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryPhysicalCountResponse> RetrieveInventoryPhysicalCountAsync(
                string physicalCountId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryPhysicalCountResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/physical-counts/{physical_count_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("physical_count_id", physicalCountId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns the [InventoryTransfer]($m/InventoryTransfer) object.
        /// with the provided `transfer_id`.
        /// </summary>
        /// <param name="transferId">Required parameter: ID of the [InventoryTransfer](entity:InventoryTransfer) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveInventoryTransferResponse response from the API call.</returns>
        public Models.RetrieveInventoryTransferResponse RetrieveInventoryTransfer(
                string transferId)
            => CoreHelper.RunTask(RetrieveInventoryTransferAsync(transferId));

        /// <summary>
        /// Returns the [InventoryTransfer]($m/InventoryTransfer) object.
        /// with the provided `transfer_id`.
        /// </summary>
        /// <param name="transferId">Required parameter: ID of the [InventoryTransfer](entity:InventoryTransfer) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveInventoryTransferResponse response from the API call.</returns>
        public async Task<Models.RetrieveInventoryTransferResponse> RetrieveInventoryTransferAsync(
                string transferId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryTransferResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/transfers/{transfer_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("transfer_id", transferId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.RetrieveInventoryCountResponse RetrieveInventoryCount(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null)
            => CoreHelper.RunTask(RetrieveInventoryCountAsync(catalogObjectId, locationIds, cursor));

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
        public async Task<Models.RetrieveInventoryCountResponse> RetrieveInventoryCountAsync(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryCountResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/{catalog_object_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("catalog_object_id", catalogObjectId))
                      .Query(_query => _query.Setup("location_ids", locationIds))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.RetrieveInventoryChangesResponse RetrieveInventoryChanges(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null)
            => CoreHelper.RunTask(RetrieveInventoryChangesAsync(catalogObjectId, locationIds, cursor));

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
        public async Task<Models.RetrieveInventoryChangesResponse> RetrieveInventoryChangesAsync(
                string catalogObjectId,
                string locationIds = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveInventoryChangesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/inventory/{catalog_object_id}/changes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("catalog_object_id", catalogObjectId))
                      .Query(_query => _query.Setup("location_ids", locationIds))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}