using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Employees;

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
