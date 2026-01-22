using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Customers;

public partial interface ICustomAttributesClient
{
    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a customer profile.
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
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with a customer profile.
    ///
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    ///
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<GetCustomerCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for a customer profile.
    ///
    /// Use this endpoint to set the value of a custom attribute for a specified customer profile.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which
    /// is created using the [CreateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-CreateCustomerCustomAttributeDefinition) endpoint.
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<UpsertCustomerCustomAttributeResponse> UpsertAsync(
        UpsertCustomerCustomAttributeRequest request,
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
    Task<DeleteCustomerCustomAttributeResponse> DeleteAsync(
        DeleteCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
