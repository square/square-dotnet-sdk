using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// EmployeesApi.
    /// </summary>
    internal class EmployeesApi : BaseApi, IEmployeesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesApi"/> class.
        /// </summary>
        internal EmployeesApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// ListEmployees EndPoint.
        /// </summary>
        /// <param name="locationId">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Specifies the EmployeeStatus to filter the employee by..</param>
        /// <param name="limit">Optional parameter: The number of employees to be returned on each page..</param>
        /// <param name="cursor">Optional parameter: The token required to retrieve the specified page of results..</param>
        /// <returns>Returns the Models.ListEmployeesResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListEmployeesResponse ListEmployees(
            string locationId = null,
            string status = null,
            int? limit = null,
            string cursor = null
        ) => CoreHelper.RunTask(ListEmployeesAsync(locationId, status, limit, cursor));

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
        public async Task<Models.ListEmployeesResponse> ListEmployeesAsync(
            string locationId = null,
            string status = null,
            int? limit = null,
            string cursor = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListEmployeesResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/employees")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Query(_query => _query.Setup("location_id", locationId))
                                .Query(_query => _query.Setup("status", status))
                                .Query(_query => _query.Setup("limit", limit))
                                .Query(_query => _query.Setup("cursor", cursor))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// RetrieveEmployee EndPoint.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested..</param>
        /// <returns>Returns the Models.RetrieveEmployeeResponse response from the API call.</returns>
        [Obsolete]
        public Models.RetrieveEmployeeResponse RetrieveEmployee(string id) =>
            CoreHelper.RunTask(RetrieveEmployeeAsync(id));

        /// <summary>
        /// RetrieveEmployee EndPoint.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the employee that was requested..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveEmployeeResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.RetrieveEmployeeResponse> RetrieveEmployeeAsync(
            string id,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveEmployeeResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/employees/{id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template => _template.Setup("id", id))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
