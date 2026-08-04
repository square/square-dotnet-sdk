using Square;
using Square.Core;

namespace Square.Locations.CustomAttributeDefinitions;

public partial interface ICustomAttributeDefinitionsClient
{
    /// <summary>
    /// Lists the location-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
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
    /// Creates a location-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to define a custom attribute that can be associated with locations.
    /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
    /// for a custom attribute. After the definition is created, you can call
    /// [UpsertLocationCustomAttribute](api-endpoint:LocationCustomAttributes-UpsertLocationCustomAttribute) or
    /// [BulkUpsertLocationCustomAttributes](api-endpoint:LocationCustomAttributes-BulkUpsertLocationCustomAttributes)
    /// to set the custom attribute for locations.
    /// </summary>
    Task<CreateLocationCustomAttributeDefinitionResponse> CreateAsync(
        CreateLocationCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a location-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// To retrieve a custom attribute definition created by another application, the `visibility`
    /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<RetrieveLocationCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a location-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
    /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
    /// `schema` for a `Selection` data type.
    /// Only the definition owner can update a custom attribute definition.
    /// </summary>
    Task<UpdateLocationCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateLocationCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a location-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
    /// Deleting a custom attribute definition also deletes the corresponding custom attribute from
    /// all locations.
    /// Only the definition owner can delete a custom attribute definition.
    /// </summary>
    Task<DeleteLocationCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
