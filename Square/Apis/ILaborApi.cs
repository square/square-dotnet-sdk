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

namespace Square.Apis
{
    /// <summary>
    /// ILaborApi.
    /// </summary>
    public interface ILaborApi
    {
        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter the returned `BreakType` results to only those that are associated with the specified location..</param>
        /// <param name="limit">Optional parameter: The maximum number of `BreakType` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `BreakType` results to fetch..</param>
        /// <returns>Returns the Models.ListBreakTypesResponse response from the API call.</returns>
        Models.ListBreakTypesResponse ListBreakTypes(
                string locationId = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter the returned `BreakType` results to only those that are associated with the specified location..</param>
        /// <param name="limit">Optional parameter: The maximum number of `BreakType` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `BreakType` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBreakTypesResponse response from the API call.</returns>
        Task<Models.ListBreakTypesResponse> ListBreakTypesAsync(
                string locationId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

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
        Models.CreateBreakTypeResponse CreateBreakType(
                Models.CreateBreakTypeRequest body);

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
        Task<Models.CreateBreakTypeResponse> CreateBreakTypeAsync(
                Models.CreateBreakTypeRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being deleted..</param>
        /// <returns>Returns the Models.DeleteBreakTypeResponse response from the API call.</returns>
        Models.DeleteBreakTypeResponse DeleteBreakType(
                string id);

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBreakTypeResponse response from the API call.</returns>
        Task<Models.DeleteBreakTypeResponse> DeleteBreakTypeAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `BreakType` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being retrieved..</param>
        /// <returns>Returns the Models.GetBreakTypeResponse response from the API call.</returns>
        Models.GetBreakTypeResponse GetBreakType(
                string id);

        /// <summary>
        /// Returns a single `BreakType` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBreakTypeResponse response from the API call.</returns>
        Task<Models.GetBreakTypeResponse> GetBreakTypeAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBreakTypeResponse response from the API call.</returns>
        Models.UpdateBreakTypeResponse UpdateBreakType(
                string id,
                Models.UpdateBreakTypeRequest body);

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBreakTypeResponse response from the API call.</returns>
        Task<Models.UpdateBreakTypeResponse> UpdateBreakTypeAsync(
                string id,
                Models.UpdateBreakTypeRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter the returned wages to only those that are associated with the specified employee..</param>
        /// <param name="limit">Optional parameter: The maximum number of `EmployeeWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <returns>Returns the Models.ListEmployeeWagesResponse response from the API call.</returns>
        [Obsolete]
        Models.ListEmployeeWagesResponse ListEmployeeWages(
                string employeeId = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter the returned wages to only those that are associated with the specified employee..</param>
        /// <param name="limit">Optional parameter: The maximum number of `EmployeeWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEmployeeWagesResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.ListEmployeeWagesResponse> ListEmployeeWagesAsync(
                string employeeId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `EmployeeWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `EmployeeWage` being retrieved..</param>
        /// <returns>Returns the Models.GetEmployeeWageResponse response from the API call.</returns>
        [Obsolete]
        Models.GetEmployeeWageResponse GetEmployeeWage(
                string id);

        /// <summary>
        /// Returns a single `EmployeeWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `EmployeeWage` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetEmployeeWageResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.GetEmployeeWageResponse> GetEmployeeWageAsync(
                string id,
                CancellationToken cancellationToken = default);

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
        Models.CreateShiftResponse CreateShift(
                Models.CreateShiftRequest body);

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
        Task<Models.CreateShiftResponse> CreateShiftAsync(
                Models.CreateShiftRequest body,
                CancellationToken cancellationToken = default);

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
        Models.SearchShiftsResponse SearchShifts(
                Models.SearchShiftsRequest body);

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
        Task<Models.SearchShiftsResponse> SearchShiftsAsync(
                Models.SearchShiftsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being deleted..</param>
        /// <returns>Returns the Models.DeleteShiftResponse response from the API call.</returns>
        Models.DeleteShiftResponse DeleteShift(
                string id);

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteShiftResponse response from the API call.</returns>
        Task<Models.DeleteShiftResponse> DeleteShiftAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `Shift` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being retrieved..</param>
        /// <returns>Returns the Models.GetShiftResponse response from the API call.</returns>
        Models.GetShiftResponse GetShift(
                string id);

        /// <summary>
        /// Returns a single `Shift` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetShiftResponse response from the API call.</returns>
        Task<Models.GetShiftResponse> GetShiftAsync(
                string id,
                CancellationToken cancellationToken = default);

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
        Models.UpdateShiftResponse UpdateShift(
                string id,
                Models.UpdateShiftRequest body);

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
        Task<Models.UpdateShiftResponse> UpdateShiftAsync(
                string id,
                Models.UpdateShiftRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter the returned wages to only those that are associated with the specified team member..</param>
        /// <param name="limit">Optional parameter: The maximum number of `TeamMemberWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <returns>Returns the Models.ListTeamMemberWagesResponse response from the API call.</returns>
        Models.ListTeamMemberWagesResponse ListTeamMemberWages(
                string teamMemberId = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter the returned wages to only those that are associated with the specified team member..</param>
        /// <param name="limit">Optional parameter: The maximum number of `TeamMemberWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberWagesResponse response from the API call.</returns>
        Task<Models.ListTeamMemberWagesResponse> ListTeamMemberWagesAsync(
                string teamMemberId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `TeamMemberWage` being retrieved..</param>
        /// <returns>Returns the Models.GetTeamMemberWageResponse response from the API call.</returns>
        Models.GetTeamMemberWageResponse GetTeamMemberWage(
                string id);

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `TeamMemberWage` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTeamMemberWageResponse response from the API call.</returns>
        Task<Models.GetTeamMemberWageResponse> GetTeamMemberWageAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of `WorkweekConfigs` results to return per page..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `WorkweekConfig` results to fetch..</param>
        /// <returns>Returns the Models.ListWorkweekConfigsResponse response from the API call.</returns>
        Models.ListWorkweekConfigsResponse ListWorkweekConfigs(
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of `WorkweekConfigs` results to return per page..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `WorkweekConfig` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWorkweekConfigsResponse response from the API call.</returns>
        Task<Models.ListWorkweekConfigsResponse> ListWorkweekConfigsAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `WorkweekConfig` object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWorkweekConfigResponse response from the API call.</returns>
        Models.UpdateWorkweekConfigResponse UpdateWorkweekConfig(
                string id,
                Models.UpdateWorkweekConfigRequest body);

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `WorkweekConfig` object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWorkweekConfigResponse response from the API call.</returns>
        Task<Models.UpdateWorkweekConfigResponse> UpdateWorkweekConfigAsync(
                string id,
                Models.UpdateWorkweekConfigRequest body,
                CancellationToken cancellationToken = default);
    }
}