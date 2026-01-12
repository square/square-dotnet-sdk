using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Inventory;

public partial interface IInventoryClient
{
    /// <summary>
    /// Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    Task<GetInventoryAdjustmentResponse> DeprecatedGetAdjustmentAsync(
        DeprecatedGetAdjustmentInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the [InventoryAdjustment](entity:InventoryAdjustment) object
    /// with the provided `adjustment_id`.
    /// </summary>
    Task<GetInventoryAdjustmentResponse> GetAdjustmentAsync(
        GetAdjustmentInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    Task<BatchChangeInventoryResponse> DeprecatedBatchChangeAsync(
        BatchChangeInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    Task<BatchGetInventoryChangesResponse> DeprecatedBatchGetChangesAsync(
        BatchRetrieveInventoryChangesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    Task<BatchGetInventoryCountsResponse> DeprecatedBatchGetCountsAsync(
        BatchGetInventoryCountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies adjustments and counts to the provided item quantities.
    ///
    /// On success: returns the current calculated counts for all objects
    /// referenced in the request.
    /// On failure: returns a list of related errors.
    /// </summary>
    Task<BatchChangeInventoryResponse> BatchCreateChangesAsync(
        BatchChangeInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns historical physical counts and adjustments based on the
    /// provided filter criteria.
    ///
    /// Results are paginated and sorted in ascending order according their
    /// `occurred_at` timestamp (oldest first).
    ///
    /// BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
    /// that cannot be handled by other, simpler endpoints.
    /// </summary>
    Task<Pager<InventoryChange>> BatchGetChangesAsync(
        BatchRetrieveInventoryChangesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns current counts for the provided
    /// [CatalogObject](entity:CatalogObject)s at the requested
    /// [Location](entity:Location)s.
    ///
    /// Results are paginated and sorted in descending order according to their
    /// `calculated_at` timestamp (newest first).
    ///
    /// When `updated_after` is specified, only counts that have changed since that
    /// time (based on the server timestamp for the most recent change) are
    /// returned. This allows clients to perform a "sync" operation, for example
    /// in response to receiving a Webhook notification.
    /// </summary>
    Task<Pager<InventoryCount>> BatchGetCountsAsync(
        BatchGetInventoryCountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL
    /// is updated to conform to the standard convention.
    /// </summary>
    Task<GetInventoryPhysicalCountResponse> DeprecatedGetPhysicalCountAsync(
        DeprecatedGetPhysicalCountInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the [InventoryPhysicalCount](entity:InventoryPhysicalCount)
    /// object with the provided `physical_count_id`.
    /// </summary>
    Task<GetInventoryPhysicalCountResponse> GetPhysicalCountAsync(
        GetPhysicalCountInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the [InventoryTransfer](entity:InventoryTransfer) object
    /// with the provided `transfer_id`.
    /// </summary>
    Task<GetInventoryTransferResponse> GetTransferAsync(
        GetTransferInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the current calculated stock count for a given
    /// [CatalogObject](entity:CatalogObject) at a given set of
    /// [Location](entity:Location)s. Responses are paginated and unsorted.
    /// For more sophisticated queries, use a batch endpoint.
    /// </summary>
    Task<Pager<InventoryCount>> GetAsync(
        GetInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a set of physical counts and inventory adjustments for the
    /// provided [CatalogObject](entity:CatalogObject) at the requested
    /// [Location](entity:Location)s.
    ///
    /// You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges)
    /// and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.
    ///
    /// Results are paginated and sorted in descending order according to their
    /// `occurred_at` timestamp (newest first).
    ///
    /// There are no limits on how far back the caller can page. This endpoint can be
    /// used to display recent changes for a specific item. For more
    /// sophisticated queries, use a batch endpoint.
    /// </summary>
    Task<Pager<InventoryChange>> ChangesAsync(
        ChangesInventoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
