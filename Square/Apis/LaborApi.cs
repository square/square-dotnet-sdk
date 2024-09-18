using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;
using System.Net.Http;

namespace Square.Apis
{
    /// <summary>
    /// LaborApi.
    /// </summary>
    internal class LaborApi : BaseApi, ILaborApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaborApi"/> class.
        /// </summary>
        internal LaborApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter the returned `BreakType` results to only those that are associated with the specified location..</param>
        /// <param name="limit">Optional parameter: The maximum number of `BreakType` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `BreakType` results to fetch..</param>
        /// <returns>Returns the Models.ListBreakTypesResponse response from the API call.</returns>
        public Models.ListBreakTypesResponse ListBreakTypes(
                string locationId = null,
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListBreakTypesAsync(locationId, limit, cursor));

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter the returned `BreakType` results to only those that are associated with the specified location..</param>
        /// <param name="limit">Optional parameter: The maximum number of `BreakType` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `BreakType` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBreakTypesResponse response from the API call.</returns>
        public async Task<Models.ListBreakTypesResponse> ListBreakTypesAsync(
                string locationId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListBreakTypesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/break-types")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `break_name`.
        /// - `expected_duration`.
        /// - `is_paid`.
        /// You can only have three `BreakType` instances per location. If you attempt to add a fourth.
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location.".
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBreakTypeResponse response from the API call.</returns>
        public Models.CreateBreakTypeResponse CreateBreakType(
                Models.CreateBreakTypeRequest body)
            => CoreHelper.RunTask(CreateBreakTypeAsync(body));

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `break_name`.
        /// - `expected_duration`.
        /// - `is_paid`.
        /// You can only have three `BreakType` instances per location. If you attempt to add a fourth.
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location.".
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBreakTypeResponse response from the API call.</returns>
        public async Task<Models.CreateBreakTypeResponse> CreateBreakTypeAsync(
                Models.CreateBreakTypeRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateBreakTypeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/labor/break-types")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being deleted..</param>
        /// <returns>Returns the Models.DeleteBreakTypeResponse response from the API call.</returns>
        public Models.DeleteBreakTypeResponse DeleteBreakType(
                string id)
            => CoreHelper.RunTask(DeleteBreakTypeAsync(id));

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBreakTypeResponse response from the API call.</returns>
        public async Task<Models.DeleteBreakTypeResponse> DeleteBreakTypeAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteBreakTypeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/labor/break-types/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a single `BreakType` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being retrieved..</param>
        /// <returns>Returns the Models.GetBreakTypeResponse response from the API call.</returns>
        public Models.GetBreakTypeResponse GetBreakType(
                string id)
            => CoreHelper.RunTask(GetBreakTypeAsync(id));

        /// <summary>
        /// Returns a single `BreakType` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBreakTypeResponse response from the API call.</returns>
        public async Task<Models.GetBreakTypeResponse> GetBreakTypeAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetBreakTypeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/break-types/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBreakTypeResponse response from the API call.</returns>
        public Models.UpdateBreakTypeResponse UpdateBreakType(
                string id,
                Models.UpdateBreakTypeRequest body)
            => CoreHelper.RunTask(UpdateBreakTypeAsync(id, body));

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBreakTypeResponse response from the API call.</returns>
        public async Task<Models.UpdateBreakTypeResponse> UpdateBreakTypeAsync(
                string id,
                Models.UpdateBreakTypeRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateBreakTypeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/labor/break-types/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("id", id))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter the returned wages to only those that are associated with the specified employee..</param>
        /// <param name="limit">Optional parameter: The maximum number of `EmployeeWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <returns>Returns the Models.ListEmployeeWagesResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListEmployeeWagesResponse ListEmployeeWages(
                string employeeId = null,
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListEmployeeWagesAsync(employeeId, limit, cursor));

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter the returned wages to only those that are associated with the specified employee..</param>
        /// <param name="limit">Optional parameter: The maximum number of `EmployeeWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEmployeeWagesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListEmployeeWagesResponse> ListEmployeeWagesAsync(
                string employeeId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListEmployeeWagesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/employee-wages")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("employee_id", employeeId))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a single `EmployeeWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `EmployeeWage` being retrieved..</param>
        /// <returns>Returns the Models.GetEmployeeWageResponse response from the API call.</returns>
        [Obsolete]
        public Models.GetEmployeeWageResponse GetEmployeeWage(
                string id)
            => CoreHelper.RunTask(GetEmployeeWageAsync(id));

        /// <summary>
        /// Returns a single `EmployeeWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `EmployeeWage` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetEmployeeWageResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.GetEmployeeWageResponse> GetEmployeeWageAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetEmployeeWageResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/employee-wages/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete workday for a single team member.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `team_member_id`.
        /// - `start_at`.
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:.
        /// - The `status` of the new `Shift` is `OPEN` and the team member has another.
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future.
        /// - The `start_at` or `end_at` date overlaps another shift for the same team member.
        /// - The `Break` instances are set in the request and a break `start_at`.
        /// is before the `Shift.start_at`, a break `end_at` is after.
        /// the `Shift.end_at`, or both.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateShiftResponse response from the API call.</returns>
        public Models.CreateShiftResponse CreateShift(
                Models.CreateShiftRequest body)
            => CoreHelper.RunTask(CreateShiftAsync(body));

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete workday for a single team member.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `team_member_id`.
        /// - `start_at`.
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:.
        /// - The `status` of the new `Shift` is `OPEN` and the team member has another.
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future.
        /// - The `start_at` or `end_at` date overlaps another shift for the same team member.
        /// - The `Break` instances are set in the request and a break `start_at`.
        /// is before the `Shift.start_at`, a break `end_at` is after.
        /// the `Shift.end_at`, or both.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateShiftResponse response from the API call.</returns>
        public async Task<Models.CreateShiftResponse> CreateShiftAsync(
                Models.CreateShiftRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateShiftResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/labor/shifts")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:.
        /// - Location IDs.
        /// - Team member IDs.
        /// - Shift status (`OPEN` or `CLOSED`).
        /// - Shift start.
        /// - Shift end.
        /// - Workday details.
        /// The list can be sorted by:.
        /// - `START_AT`.
        /// - `END_AT`.
        /// - `CREATED_AT`.
        /// - `UPDATED_AT`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchShiftsResponse response from the API call.</returns>
        public Models.SearchShiftsResponse SearchShifts(
                Models.SearchShiftsRequest body)
            => CoreHelper.RunTask(SearchShiftsAsync(body));

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:.
        /// - Location IDs.
        /// - Team member IDs.
        /// - Shift status (`OPEN` or `CLOSED`).
        /// - Shift start.
        /// - Shift end.
        /// - Workday details.
        /// The list can be sorted by:.
        /// - `START_AT`.
        /// - `END_AT`.
        /// - `CREATED_AT`.
        /// - `UPDATED_AT`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchShiftsResponse response from the API call.</returns>
        public async Task<Models.SearchShiftsResponse> SearchShiftsAsync(
                Models.SearchShiftsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchShiftsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/labor/shifts/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being deleted..</param>
        /// <returns>Returns the Models.DeleteShiftResponse response from the API call.</returns>
        public Models.DeleteShiftResponse DeleteShift(
                string id)
            => CoreHelper.RunTask(DeleteShiftAsync(id));

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteShiftResponse response from the API call.</returns>
        public async Task<Models.DeleteShiftResponse> DeleteShiftAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteShiftResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/labor/shifts/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a single `Shift` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being retrieved..</param>
        /// <returns>Returns the Models.GetShiftResponse response from the API call.</returns>
        public Models.GetShiftResponse GetShift(
                string id)
            => CoreHelper.RunTask(GetShiftAsync(id));

        /// <summary>
        /// Returns a single `Shift` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetShiftResponse response from the API call.</returns>
        public async Task<Models.GetShiftResponse> GetShiftAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetShiftResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/shifts/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have.
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`.
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateShiftResponse response from the API call.</returns>
        public Models.UpdateShiftResponse UpdateShift(
                string id,
                Models.UpdateShiftRequest body)
            => CoreHelper.RunTask(UpdateShiftAsync(id, body));

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have.
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`.
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateShiftResponse response from the API call.</returns>
        public async Task<Models.UpdateShiftResponse> UpdateShiftAsync(
                string id,
                Models.UpdateShiftRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateShiftResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/labor/shifts/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("id", id))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter the returned wages to only those that are associated with the specified team member..</param>
        /// <param name="limit">Optional parameter: The maximum number of `TeamMemberWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <returns>Returns the Models.ListTeamMemberWagesResponse response from the API call.</returns>
        public Models.ListTeamMemberWagesResponse ListTeamMemberWages(
                string teamMemberId = null,
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListTeamMemberWagesAsync(teamMemberId, limit, cursor));

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter the returned wages to only those that are associated with the specified team member..</param>
        /// <param name="limit">Optional parameter: The maximum number of `TeamMemberWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberWagesResponse response from the API call.</returns>
        public async Task<Models.ListTeamMemberWagesResponse> ListTeamMemberWagesAsync(
                string teamMemberId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListTeamMemberWagesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/team-member-wages")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("team_member_id", teamMemberId))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `TeamMemberWage` being retrieved..</param>
        /// <returns>Returns the Models.GetTeamMemberWageResponse response from the API call.</returns>
        public Models.GetTeamMemberWageResponse GetTeamMemberWage(
                string id)
            => CoreHelper.RunTask(GetTeamMemberWageAsync(id));

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `TeamMemberWage` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTeamMemberWageResponse response from the API call.</returns>
        public async Task<Models.GetTeamMemberWageResponse> GetTeamMemberWageAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetTeamMemberWageResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/team-member-wages/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of `WorkweekConfigs` results to return per page..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `WorkweekConfig` results to fetch..</param>
        /// <returns>Returns the Models.ListWorkweekConfigsResponse response from the API call.</returns>
        public Models.ListWorkweekConfigsResponse ListWorkweekConfigs(
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListWorkweekConfigsAsync(limit, cursor));

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of `WorkweekConfigs` results to return per page..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `WorkweekConfig` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWorkweekConfigsResponse response from the API call.</returns>
        public async Task<Models.ListWorkweekConfigsResponse> ListWorkweekConfigsAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListWorkweekConfigsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/labor/workweek-configs")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `WorkweekConfig` object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWorkweekConfigResponse response from the API call.</returns>
        public Models.UpdateWorkweekConfigResponse UpdateWorkweekConfig(
                string id,
                Models.UpdateWorkweekConfigRequest body)
            => CoreHelper.RunTask(UpdateWorkweekConfigAsync(id, body));

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `WorkweekConfig` object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWorkweekConfigResponse response from the API call.</returns>
        public async Task<Models.UpdateWorkweekConfigResponse> UpdateWorkweekConfigAsync(
                string id,
                Models.UpdateWorkweekConfigRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateWorkweekConfigResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/labor/workweek-configs/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("id", id))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}