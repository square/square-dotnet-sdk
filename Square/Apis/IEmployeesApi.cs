namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Square;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// IEmployeesApi.
    /// </summary>
    public interface IEmployeesApi
    {
        /// <summary>
        /// ListEmployees EndPoint.
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by..</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page..</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results..</param>
        /// <returns>Returns the Models.ListEmployeesResponse response from the API call.</returns>
        [Obsolete]
        Models.ListEmployeesResponse ListEmployees(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// ListEmployees EndPoint.
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by..</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page..</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEmployeesResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.ListEmployeesResponse> ListEmployeesAsync(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// RetrieveEmployee EndPoint.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested..</param>
        /// <returns>Returns the Models.RetrieveEmployeeResponse response from the API call.</returns>
        [Obsolete]
        Models.RetrieveEmployeeResponse RetrieveEmployee(
                string id);

        /// <summary>
        /// RetrieveEmployee EndPoint.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveEmployeeResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.RetrieveEmployeeResponse> RetrieveEmployeeAsync(
                string id,
                CancellationToken cancellationToken = default);
    }
}