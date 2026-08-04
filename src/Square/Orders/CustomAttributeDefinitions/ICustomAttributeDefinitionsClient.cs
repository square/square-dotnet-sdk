using Square;
using Square.Core;

namespace Square.Orders.CustomAttributeDefinitions;

public partial interface ICustomAttributeDefinitionsClient
{
    /// <summary>
    /// Lists the order-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    ///
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
    /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<Pager<CustomAttributeDefinition>> ListAsync(
        ListCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates an order-related custom attribute definition.  Use this endpoint to
    /// define a custom attribute that can be associated with orders.
    ///
    /// After creating a custom attribute definition, you can set the custom attribute for orders
    /// in the Square seller account.
    /// </summary>
    Task<CreateOrderCustomAttributeDefinitionResponse> CreateAsync(
        CreateOrderCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an order-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<RetrieveOrderCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an order-related custom attribute definition for a Square seller account.
    ///
    /// Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
    /// </summary>
    Task<UpdateOrderCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateOrderCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an order-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    Task<DeleteOrderCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
