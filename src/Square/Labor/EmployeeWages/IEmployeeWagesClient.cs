using Square;
using Square.Core;

namespace Square.Labor.EmployeeWages;

public partial interface IEmployeeWagesClient
{
    /// <summary>
    /// Returns a paginated list of `EmployeeWage` instances for a business.
    /// </summary>
    Task<Pager<EmployeeWage>> ListAsync(
        ListEmployeeWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single `EmployeeWage` specified by `id`.
    /// </summary>
    Task<GetEmployeeWageResponse> GetAsync(
        GetEmployeeWagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
