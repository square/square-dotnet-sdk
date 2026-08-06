using Square;
using Square.Core;

namespace Square.Labor.BreakTypes;

public partial interface IBreakTypesClient
{
    /// <summary>
    /// Returns a paginated list of `BreakType` instances for a business.
    /// </summary>
    Task<Pager<BreakType>> ListAsync(
        ListBreakTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new `BreakType`.
    ///
    /// A `BreakType` is a template for creating `Break` objects.
    /// You must provide the following values in your request to this
    /// endpoint:
    ///
    /// - `location_id`
    /// - `break_name`
    /// - `expected_duration`
    /// - `is_paid`
    ///
    /// You can only have three `BreakType` instances per location. If you attempt to add a fourth
    /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
    /// is returned.
    /// </summary>
    Task<CreateBreakTypeResponse> CreateAsync(
        CreateBreakTypeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single `BreakType` specified by `id`.
    /// </summary>
    Task<GetBreakTypeResponse> GetAsync(
        GetBreakTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing `BreakType`.
    /// </summary>
    Task<UpdateBreakTypeResponse> UpdateAsync(
        UpdateBreakTypeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an existing `BreakType`.
    ///
    /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
    /// </summary>
    Task<DeleteBreakTypeResponse> DeleteAsync(
        DeleteBreakTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
