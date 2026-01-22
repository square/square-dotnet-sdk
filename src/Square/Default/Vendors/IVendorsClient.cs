using Square;

namespace Square.Default;

public partial interface IVendorsClient
{
    /// <summary>
    /// Creates one or more [Vendor](entity:Vendor) objects to represent suppliers to a seller.
    /// </summary>
    Task<BatchCreateVendorsResponse> BatchCreateAsync(
        BatchCreateVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves one or more vendors of specified [Vendor](entity:Vendor) IDs.
    /// </summary>
    Task<BatchGetVendorsResponse> BatchGetAsync(
        BatchGetVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates one or more of existing [Vendor](entity:Vendor) objects as suppliers to a seller.
    /// </summary>
    Task<BatchUpdateVendorsResponse> BatchUpdateAsync(
        BatchUpdateVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a single [Vendor](entity:Vendor) object to represent a supplier to a seller.
    /// </summary>
    Task<CreateVendorResponse> CreateAsync(
        CreateVendorRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for vendors using a filter against supported [Vendor](entity:Vendor) properties and a supported sorter.
    /// </summary>
    Task<SearchVendorsResponse> SearchAsync(
        SearchVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the vendor of a specified [Vendor](entity:Vendor) ID.
    /// </summary>
    Task<GetVendorResponse> GetAsync(
        GetVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing [Vendor](entity:Vendor) object as a supplier to a seller.
    /// </summary>
    Task<UpdateVendorResponse> UpdateAsync(
        UpdateVendorsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
