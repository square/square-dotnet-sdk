using Square;
using Square.Core;

namespace Square.TransferOrders;

public partial interface ITransferOrdersClient
{
    /// <summary>
    /// Creates a new transfer order in [DRAFT](entity:TransferOrderStatus) status. A transfer order represents the intent
    /// to move [CatalogItemVariation](entity:CatalogItemVariation)s from one [Location](entity:Location) to another.
    /// The source and destination locations must be different and must belong to your Square account.
    ///
    /// In [DRAFT](entity:TransferOrderStatus) status, you can:
    /// - Add or remove items
    /// - Modify quantities
    /// - Update shipping information
    /// - Delete the entire order via [DeleteTransferOrder](api-endpoint:TransferOrders-DeleteTransferOrder)
    ///
    /// The request requires source_location_id and destination_location_id.
    /// Inventory levels are not affected until the order is started via
    /// [StartTransferOrder](api-endpoint:TransferOrders-StartTransferOrder).
    ///
    /// Common integration points:
    /// - Sync with warehouse management systems
    /// - Automate regular stock transfers
    /// - Initialize transfers from inventory optimization systems
    ///
    /// Creates a [transfer_order.created](webhook:transfer_order.created) webhook event.
    /// </summary>
    Task<CreateTransferOrderResponse> CreateAsync(
        CreateTransferOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for transfer orders using filters. Returns a paginated list of matching
    /// [TransferOrder](entity:TransferOrder)s sorted by creation date.
    ///
    /// Common search scenarios:
    /// - Find orders for a source [Location](entity:Location)
    /// - Find orders for a destination [Location](entity:Location)
    /// - Find orders in a particular [TransferOrderStatus](entity:TransferOrderStatus)
    /// </summary>
    Task<Pager<TransferOrder>> SearchAsync(
        SearchTransferOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific [TransferOrder](entity:TransferOrder) by ID. Returns the complete
    /// order details including:
    ///
    /// - Basic information (status, dates, notes)
    /// - Line items with ordered and received quantities
    /// - Source and destination [Location](entity:Location)s
    /// - Tracking information (if available)
    /// </summary>
    Task<RetrieveTransferOrderResponse> GetAsync(
        GetTransferOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing transfer order. This endpoint supports sparse updates,
    /// allowing you to modify specific fields without affecting others.
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    Task<UpdateTransferOrderResponse> UpdateAsync(
        UpdateTransferOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a transfer order in [DRAFT](entity:TransferOrderStatus) status.
    /// Only draft orders can be deleted. Once an order is started via
    /// [StartTransferOrder](api-endpoint:TransferOrders-StartTransferOrder), it can no longer be deleted.
    ///
    /// Creates a [transfer_order.deleted](webhook:transfer_order.deleted) webhook event.
    /// </summary>
    Task<DeleteTransferOrderResponse> DeleteAsync(
        DeleteTransferOrdersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a transfer order in [STARTED](entity:TransferOrderStatus) or
    /// [PARTIALLY_RECEIVED](entity:TransferOrderStatus) status. Any unreceived quantities will no
    /// longer be receivable and will be immediately returned to the source [Location](entity:Location)'s inventory.
    ///
    /// Common reasons for cancellation:
    /// - Items no longer needed at destination
    /// - Source location needs the inventory
    /// - Order created in error
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    Task<CancelTransferOrderResponse> CancelAsync(
        CancelTransferOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Records receipt of [CatalogItemVariation](entity:CatalogItemVariation)s for a transfer order.
    /// This endpoint supports partial receiving - you can receive items in multiple batches.
    ///
    /// For each line item, you can specify:
    /// - Quantity received in good condition (added to destination inventory with [InventoryState](entity:InventoryState) of IN_STOCK)
    /// - Quantity damaged during transit/handling (added to destination inventory with [InventoryState](entity:InventoryState) of WASTE)
    /// - Quantity canceled (returned to source location's inventory)
    ///
    /// The order must be in [STARTED](entity:TransferOrderStatus) or [PARTIALLY_RECEIVED](entity:TransferOrderStatus) status.
    /// Received quantities are added to the destination [Location](entity:Location)'s inventory according to their condition.
    /// Canceled quantities are immediately returned to the source [Location](entity:Location)'s inventory.
    ///
    /// When all items are either received, damaged, or canceled, the order moves to
    /// [COMPLETED](entity:TransferOrderStatus) status.
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    Task<ReceiveTransferOrderResponse> ReceiveAsync(
        ReceiveTransferOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes a [DRAFT](entity:TransferOrderStatus) transfer order to [STARTED](entity:TransferOrderStatus) status.
    /// This decrements inventory at the source [Location](entity:Location) and marks it as in-transit.
    ///
    /// The order must be in [DRAFT](entity:TransferOrderStatus) status and have all required fields populated.
    /// Once started, the order can no longer be deleted, but it can be canceled via
    /// [CancelTransferOrder](api-endpoint:TransferOrders-CancelTransferOrder).
    ///
    /// Creates a [transfer_order.updated](webhook:transfer_order.updated) webhook event.
    /// </summary>
    Task<StartTransferOrderResponse> StartAsync(
        StartTransferOrderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
