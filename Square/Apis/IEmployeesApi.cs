using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IEmployeesApi
    {
        /// <summary>
        /// ListEmployees
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: </param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by.</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page.</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results.</param>
        /// <return>Returns the Models.ListEmployeesResponse response from the API call</return>
        [Obsolete]
        Models.ListEmployeesResponse ListEmployees(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// ListEmployees
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: </param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by.</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page.</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results.</param>
        /// <return>Returns the Models.ListEmployeesResponse response from the API call</return>
        [Obsolete]
        Task<Models.ListEmployeesResponse> ListEmployeesAsync(
                string locationId = null,
                string status = null,
                int? limit = null,
                string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// RetrieveEmployee
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested.</param>
        /// <return>Returns the Models.RetrieveEmployeeResponse response from the API call</return>
        [Obsolete]
        Models.RetrieveEmployeeResponse RetrieveEmployee(string id);

        /// <summary>
        /// RetrieveEmployee
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested.</param>
        /// <return>Returns the Models.RetrieveEmployeeResponse response from the API call</return>
        [Obsolete]
        Task<Models.RetrieveEmployeeResponse> RetrieveEmployeeAsync(string id, CancellationToken cancellationToken = default);

    }
}