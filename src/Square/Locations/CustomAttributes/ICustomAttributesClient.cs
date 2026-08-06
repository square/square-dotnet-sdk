using Square;
using Square.Core;

namespace Square.Locations.CustomAttributes;

public partial interface ICustomAttributesClient
{
    /// <summary>
    /// Deletes [custom attributes](entity:CustomAttribute) for locations as a bulk operation.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BulkDeleteLocationCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteLocationCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates [custom attributes](entity:CustomAttribute) for locations as a bulk operation.
    /// Use this endpoint to set the value of one or more custom attributes for one or more locations.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which is
    /// created using the [CreateLocationCustomAttributeDefinition](api-endpoint:LocationCustomAttributes-CreateLocationCustomAttributeDefinition) endpoint.
    /// This `BulkUpsertLocationCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides a location ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BulkUpsertLocationCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertLocationCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a location.
    /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
    /// in the same call.
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
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with a location.
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<RetrieveLocationCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for a location.
    /// Use this endpoint to set the value of a custom attribute for a specified location.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which
    /// is created using the [CreateLocationCustomAttributeDefinition](api-endpoint:LocationCustomAttributes-CreateLocationCustomAttributeDefinition) endpoint.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<UpsertLocationCustomAttributeResponse> UpsertAsync(
        UpsertLocationCustomAttributeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a [custom attribute](entity:CustomAttribute) associated with a location.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<DeleteLocationCustomAttributeResponse> DeleteAsync(
        DeleteCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
