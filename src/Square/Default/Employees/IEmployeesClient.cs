using Square;
using Square.Core;

namespace Square.Default;

public partial interface IEmployeesClient
{
    Task<Pager<Employee>> ListAsync(
        ListEmployeesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task<GetEmployeeResponse> GetAsync(
        GetEmployeesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
