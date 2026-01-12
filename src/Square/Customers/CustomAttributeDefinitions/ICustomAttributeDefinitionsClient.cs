using Square;
using Square.Core;

namespace Square.Customers.CustomAttributeDefinitions;

public partial interface ICustomAttributeDefinitionsClient
{
    /// <summary>
    /// Lists the customer-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
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
    /// Creates a customer-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to define a custom attribute that can be associated with customer profiles.
    ///
    /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
    /// for a custom attribute. After the definition is created, you can call
    /// [UpsertCustomerCustomAttribute](api-endpoint:CustomerCustomAttributes-UpsertCustomerCustomAttribute) or
    /// [BulkUpsertCustomerCustomAttributes](api-endpoint:CustomerCustomAttributes-BulkUpsertCustomerCustomAttributes)
    /// to set the custom attribute for customer profiles in the seller's Customer Directory.
    ///
    /// Sellers can view all custom attributes in exported customer data, including those set to
    /// `VISIBILITY_HIDDEN`.
    /// </summary>
    Task<CreateCustomerCustomAttributeDefinitionResponse> CreateAsync(
        CreateCustomerCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a customer-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<GetCustomerCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a customer-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    ///
    /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
    /// `schema` for a `Selection` data type.
    ///
    /// Only the definition owner can update a custom attribute definition. Note that sellers can view
    /// all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
    /// </summary>
    Task<UpdateCustomerCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateCustomerCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a customer-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    ///
    /// Deleting a custom attribute definition also deletes the corresponding custom attribute from
    /// all customer profiles in the seller's Customer Directory.
    ///
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    Task<DeleteCustomerCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates [custom attributes](entity:CustomAttribute) for customer profiles as a bulk operation.
    ///
    /// Use this endpoint to set the value of one or more custom attributes for one or more customer profiles.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which is
    /// created using the [CreateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-CreateCustomerCustomAttributeDefinition) endpoint.
    ///
    /// This `BulkUpsertCustomerCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides a customer ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    ///
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
    /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BatchUpsertCustomerCustomAttributesResponse> BatchUpsertAsync(
        BatchUpsertCustomerCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
