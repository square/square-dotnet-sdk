using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributeDefinitions;

public partial interface ICustomAttributeDefinitionsClient
{
    /// <summary>
    /// Lists the merchant-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
    /// When all response pages are retrieved, the results include all custom attribute definitions
    /// that are visible to the requesting application, including those that are created by other
    /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<Pager<CustomAttributeDefinition>> ListAsync(
        ListCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to define a custom attribute that can be associated with a merchant connecting to your application.
    /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
    /// for a custom attribute. After the definition is created, you can call
    /// [UpsertMerchantCustomAttribute](api-endpoint:MerchantCustomAttributes-UpsertMerchantCustomAttribute) or
    /// [BulkUpsertMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkUpsertMerchantCustomAttributes)
    /// to set the custom attribute for a merchant.
    /// </summary>
    Task<CreateMerchantCustomAttributeDefinitionResponse> CreateAsync(
        CreateMerchantCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<RetrieveMerchantCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
    /// `schema` for a `Selection` data type.
    /// Only the definition owner can update a custom attribute definition.
    /// </summary>
    Task<UpdateMerchantCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateMerchantCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// Deleting a custom attribute definition also deletes the corresponding custom attribute from
    /// the merchant.
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    Task<DeleteMerchantCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
