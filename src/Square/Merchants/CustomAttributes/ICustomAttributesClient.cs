using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributes;

public partial interface ICustomAttributesClient
{
    /// <summary>
    /// Deletes [custom attributes](entity:CustomAttribute) for a merchant as a bulk operation.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BulkDeleteMerchantCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteMerchantCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates [custom attributes](entity:CustomAttribute) for a merchant as a bulk operation.
    /// Use this endpoint to set the value of one or more custom attributes for a merchant.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which is
    /// created using the [CreateMerchantCustomAttributeDefinition](api-endpoint:MerchantCustomAttributes-CreateMerchantCustomAttributeDefinition) endpoint.
    /// This `BulkUpsertMerchantCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
    /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID
    /// and provides a merchant ID and custom attribute. Each upsert response is returned with the ID
    /// of the corresponding request.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<BulkUpsertMerchantCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertMerchantCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the [custom attributes](entity:CustomAttribute) associated with a merchant.
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
    /// Retrieves a [custom attribute](entity:CustomAttribute) associated with a merchant.
    /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition
    /// in the same call.
    /// To retrieve a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<RetrieveMerchantCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates a [custom attribute](entity:CustomAttribute) for a merchant.
    /// Use this endpoint to set the value of a custom attribute for a specified merchant.
    /// A custom attribute is based on a custom attribute definition in a Square seller account, which
    /// is created using the [CreateMerchantCustomAttributeDefinition](api-endpoint:MerchantCustomAttributes-CreateMerchantCustomAttributeDefinition) endpoint.
    /// To create or update a custom attribute owned by another application, the `visibility` setting
    /// must be `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<UpsertMerchantCustomAttributeResponse> UpsertAsync(
        UpsertMerchantCustomAttributeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a [custom attribute](entity:CustomAttribute) associated with a merchant.
    /// To delete a custom attribute owned by another application, the `visibility` setting must be
    /// `VISIBILITY_READ_WRITE_VALUES`.
    /// </summary>
    Task<DeleteMerchantCustomAttributeResponse> DeleteAsync(
        DeleteCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
