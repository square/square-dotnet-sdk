using Square;
using Square.Core;

namespace Square.Orders.CustomAttributes;

public partial interface ICustomAttributesClient
{
    /// <summary>
    /// Deletes order [custom attributes](entity:CustomAttribute) as a bulk operation.
    ///
    /// Use this endpoint to delete one or more custom attributes from one or more orders.
    /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
    /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)
    ///
    /// This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete
    /// requests and returns a map of individual delete responses. Each delete request has a unique ID
    /// and provides an order ID and custom attribute. Each delete response is returned with the ID
    /// of the corresponding request.
    ///
    /// To delete a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BulkDeleteOrderCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteOrderCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates order [custom attributes](entity:CustomAttribute) as a bulk operation.
    ///
    /// Use this endpoint to delete one or more custom attributes from one or more orders.
    /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
    /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)
    ///
    /// This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides an order ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BulkUpsertOrderCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertOrderCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with an order.
    ///
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
    ///
    /// When all response pages are retrieved, the results include all custom attributes that are
    /// visible to the requesting application, including those that are owned by other applications
    /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<Pager<CustomAttribute>> ListAsync(
        ListCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with an order.
    ///
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    ///
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<RetrieveOrderCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for an order.
    ///
    /// Use this endpoint to set the value of a custom attribute for a specific order.
    /// A custom attribute is based on a custom attribute definition in a Square seller account. (To create a
    /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<UpsertOrderCustomAttributeResponse> UpsertAsync(
        UpsertOrderCustomAttributeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a [custom attribute](entity:CustomAttribute) associated with a customer profile.
    ///
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<DeleteOrderCustomAttributeResponse> DeleteAsync(
        DeleteCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
