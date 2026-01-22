using Square;
using Square.Default;

namespace Square.Default.Catalog;

public partial interface IObjectClient
{
    /// <summary>
    /// Creates a new or updates the specified [CatalogObject](entity:CatalogObject).
    ///
    /// To ensure consistency, only one update request is processed at a time per seller account.
    /// While one (batch or non-batch) update request is being processed, other (batched and non-batched)
    /// update requests are rejected with the `429` error code.
    /// </summary>
    Task<UpsertCatalogObjectResponse> UpsertAsync(
        UpsertCatalogObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single [CatalogItem](entity:CatalogItem) as a
    /// [CatalogObject](entity:CatalogObject) based on the provided ID. The returned
    /// object includes all of the relevant [CatalogItem](entity:CatalogItem)
    /// information including: [CatalogItemVariation](entity:CatalogItemVariation)
    /// children, references to its
    /// [CatalogModifierList](entity:CatalogModifierList) objects, and the ids of
    /// any [CatalogTax](entity:CatalogTax) objects that apply to it.
    /// </summary>
    Task<GetCatalogObjectResponse> GetAsync(
        GetObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a single [CatalogObject](entity:CatalogObject) based on the
    /// provided ID and returns the set of successfully deleted IDs in the response.
    /// Deletion is a cascading event such that all children of the targeted object
    /// are also deleted. For example, deleting a [CatalogItem](entity:CatalogItem)
    /// will also delete all of its
    /// [CatalogItemVariation](entity:CatalogItemVariation) children.
    ///
    /// To ensure consistency, only one delete request is processed at a time per seller account.
    /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched)
    /// delete requests are rejected with the `429` error code.
    /// </summary>
    Task<DeleteCatalogObjectResponse> DeleteAsync(
        DeleteObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
