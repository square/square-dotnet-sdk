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
    public interface ILaborApi
    {
        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter Break Types returned to only those that are associated with the specified location.</param>
        /// <param name="limit">Optional parameter: Maximum number of Break Types to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Break Type results to fetch.</param>
        /// <return>Returns the Models.ListBreakTypesResponse response from the API call</return>
        Models.ListBreakTypesResponse ListBreakTypes(string locationId = null, int? limit = null, string cursor = null);

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter Break Types returned to only those that are associated with the specified location.</param>
        /// <param name="limit">Optional parameter: Maximum number of Break Types to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Break Type results to fetch.</param>
        /// <return>Returns the Models.ListBreakTypesResponse response from the API call</return>
        Task<Models.ListBreakTypesResponse> ListBreakTypesAsync(string locationId = null, int? limit = null, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `break_name`
        /// - `expected_duration`
        /// - `is_paid`
        /// You can only have 3 `BreakType` instances per location. If you attempt to add a 4th
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateBreakTypeResponse response from the API call</return>
        Models.CreateBreakTypeResponse CreateBreakType(Models.CreateBreakTypeRequest body);

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `break_name`
        /// - `expected_duration`
        /// - `is_paid`
        /// You can only have 3 `BreakType` instances per location. If you attempt to add a 4th
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateBreakTypeResponse response from the API call</return>
        Task<Models.CreateBreakTypeResponse> CreateBreakTypeAsync(Models.CreateBreakTypeRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being deleted.</param>
        /// <return>Returns the Models.DeleteBreakTypeResponse response from the API call</return>
        Models.DeleteBreakTypeResponse DeleteBreakType(string id);

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being deleted.</param>
        /// <return>Returns the Models.DeleteBreakTypeResponse response from the API call</return>
        Task<Models.DeleteBreakTypeResponse> DeleteBreakTypeAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `BreakType` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being retrieved.</param>
        /// <return>Returns the Models.GetBreakTypeResponse response from the API call</return>
        Models.GetBreakTypeResponse GetBreakType(string id);

        /// <summary>
        /// Returns a single `BreakType` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being retrieved.</param>
        /// <return>Returns the Models.GetBreakTypeResponse response from the API call</return>
        Task<Models.GetBreakTypeResponse> GetBreakTypeAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateBreakTypeResponse response from the API call</return>
        Models.UpdateBreakTypeResponse UpdateBreakType(string id, Models.UpdateBreakTypeRequest body);

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `BreakType` being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateBreakTypeResponse response from the API call</return>
        Task<Models.UpdateBreakTypeResponse> UpdateBreakTypeAsync(string id, Models.UpdateBreakTypeRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter wages returned to only those that are associated with the specified employee.</param>
        /// <param name="limit">Optional parameter: Maximum number of Employee Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListEmployeeWagesResponse response from the API call</return>
        [Obsolete]
        Models.ListEmployeeWagesResponse ListEmployeeWages(string employeeId = null, int? limit = null, string cursor = null);

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter wages returned to only those that are associated with the specified employee.</param>
        /// <param name="limit">Optional parameter: Maximum number of Employee Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListEmployeeWagesResponse response from the API call</return>
        [Obsolete]
        Task<Models.ListEmployeeWagesResponse> ListEmployeeWagesAsync(string employeeId = null, int? limit = null, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `EmployeeWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `EmployeeWage` being retrieved.</param>
        /// <return>Returns the Models.GetEmployeeWageResponse response from the API call</return>
        [Obsolete]
        Models.GetEmployeeWageResponse GetEmployeeWage(string id);

        /// <summary>
        /// Returns a single `EmployeeWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `EmployeeWage` being retrieved.</param>
        /// <return>Returns the Models.GetEmployeeWageResponse response from the API call</return>
        [Obsolete]
        Task<Models.GetEmployeeWageResponse> GetEmployeeWageAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete work day for a single employee.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `employee_id`
        /// - `start_at`
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
        /// - The `status` of the new `Shift` is `OPEN` and the employee has another
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future
        /// - the `start_at` or `end_at` overlaps another shift for the same employee
        /// - If `Break`s are set in the request, a break `start_at`
        /// must not be before the `Shift.start_at`. A break `end_at` must not be after
        /// the `Shift.end_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateShiftResponse response from the API call</return>
        Models.CreateShiftResponse CreateShift(Models.CreateShiftRequest body);

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete work day for a single employee.
        /// You must provide the following values in your request to this
        /// endpoint:
        /// - `location_id`
        /// - `employee_id`
        /// - `start_at`
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
        /// - The `status` of the new `Shift` is `OPEN` and the employee has another
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future
        /// - the `start_at` or `end_at` overlaps another shift for the same employee
        /// - If `Break`s are set in the request, a break `start_at`
        /// must not be before the `Shift.start_at`. A break `end_at` must not be after
        /// the `Shift.end_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateShiftResponse response from the API call</return>
        Task<Models.CreateShiftResponse> CreateShiftAsync(Models.CreateShiftRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:
        /// - Location IDs **and**
        /// - employee IDs **and**
        /// - shift status (`OPEN`, `CLOSED`) **and**
        /// - shift start **and**
        /// - shift end **and**
        /// - work day details
        /// The list can be sorted by:
        /// - `start_at`
        /// - `end_at`
        /// - `created_at`
        /// - `updated_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchShiftsResponse response from the API call</return>
        Models.SearchShiftsResponse SearchShifts(Models.SearchShiftsRequest body);

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:
        /// - Location IDs **and**
        /// - employee IDs **and**
        /// - shift status (`OPEN`, `CLOSED`) **and**
        /// - shift start **and**
        /// - shift end **and**
        /// - work day details
        /// The list can be sorted by:
        /// - `start_at`
        /// - `end_at`
        /// - `created_at`
        /// - `updated_at`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchShiftsResponse response from the API call</return>
        Task<Models.SearchShiftsResponse> SearchShiftsAsync(Models.SearchShiftsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being deleted.</param>
        /// <return>Returns the Models.DeleteShiftResponse response from the API call</return>
        Models.DeleteShiftResponse DeleteShift(string id);

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being deleted.</param>
        /// <return>Returns the Models.DeleteShiftResponse response from the API call</return>
        Task<Models.DeleteShiftResponse> DeleteShiftAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `Shift` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being retrieved.</param>
        /// <return>Returns the Models.GetShiftResponse response from the API call</return>
        Models.GetShiftResponse GetShift(string id);

        /// <summary>
        /// Returns a single `Shift` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `Shift` being retrieved.</param>
        /// <return>Returns the Models.GetShiftResponse response from the API call</return>
        Task<Models.GetShiftResponse> GetShiftAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Breaks` in the `Shift` have
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the shift must be complete with `end_at`
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: ID of the object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateShiftResponse response from the API call</return>
        Models.UpdateShiftResponse UpdateShift(string id, Models.UpdateShiftRequest body);

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Breaks` in the `Shift` have
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the shift must be complete with `end_at`
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: ID of the object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateShiftResponse response from the API call</return>
        Task<Models.UpdateShiftResponse> UpdateShiftAsync(string id, Models.UpdateShiftRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter wages returned to only those that are associated with the specified team member.</param>
        /// <param name="limit">Optional parameter: Maximum number of Team Member Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListTeamMemberWagesResponse response from the API call</return>
        Models.ListTeamMemberWagesResponse ListTeamMemberWages(string teamMemberId = null, int? limit = null, string cursor = null);

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter wages returned to only those that are associated with the specified team member.</param>
        /// <param name="limit">Optional parameter: Maximum number of Team Member Wages to return per page. Can range between 1 and 200. The default is the maximum at 200.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Employee Wage results to fetch.</param>
        /// <return>Returns the Models.ListTeamMemberWagesResponse response from the API call</return>
        Task<Models.ListTeamMemberWagesResponse> ListTeamMemberWagesAsync(string teamMemberId = null, int? limit = null, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `TeamMemberWage` being retrieved.</param>
        /// <return>Returns the Models.GetTeamMemberWageResponse response from the API call</return>
        Models.GetTeamMemberWageResponse GetTeamMemberWage(string id);

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by id.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `TeamMemberWage` being retrieved.</param>
        /// <return>Returns the Models.GetTeamMemberWageResponse response from the API call</return>
        Task<Models.GetTeamMemberWageResponse> GetTeamMemberWageAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: Maximum number of Workweek Configs to return per page.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Workweek Config results to fetch.</param>
        /// <return>Returns the Models.ListWorkweekConfigsResponse response from the API call</return>
        Models.ListWorkweekConfigsResponse ListWorkweekConfigs(int? limit = null, string cursor = null);

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: Maximum number of Workweek Configs to return per page.</param>
        /// <param name="cursor">Optional parameter: Pointer to the next page of Workweek Config results to fetch.</param>
        /// <return>Returns the Models.ListWorkweekConfigsResponse response from the API call</return>
        Task<Models.ListWorkweekConfigsResponse> ListWorkweekConfigsAsync(int? limit = null, string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `WorkweekConfig` object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateWorkweekConfigResponse response from the API call</return>
        Models.UpdateWorkweekConfigResponse UpdateWorkweekConfig(string id, Models.UpdateWorkweekConfigRequest body);

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: UUID for the `WorkweekConfig` object being updated.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateWorkweekConfigResponse response from the API call</return>
        Task<Models.UpdateWorkweekConfigResponse> UpdateWorkweekConfigAsync(string id, Models.UpdateWorkweekConfigRequest body, CancellationToken cancellationToken = default);

    }
}