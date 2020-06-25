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
    public interface IV1EmployeesApi
    {
        /// <summary>
        /// Provides summary information for all of a business's employees.
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.      Default value: ASC</param>
        /// <param name="beginUpdatedAt">Optional parameter: If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format</param>
        /// <param name="endUpdatedAt">Optional parameter: If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="beginCreatedAt">Optional parameter: If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endCreatedAt">Optional parameter: If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="status">Optional parameter: If provided, the endpoint returns only employee entities with the specified status (ACTIVE or INACTIVE).</param>
        /// <param name="externalId">Optional parameter: If provided, the endpoint returns only employee entities with the specified external_id.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Employee> response from the API call</return>
        List<Models.V1Employee> ListEmployees(
                string order = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                string beginCreatedAt = null,
                string endCreatedAt = null,
                string status = null,
                string externalId = null,
                int? limit = null,
                string batchToken = null);

        /// <summary>
        /// Provides summary information for all of a business's employees.
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.      Default value: ASC</param>
        /// <param name="beginUpdatedAt">Optional parameter: If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format</param>
        /// <param name="endUpdatedAt">Optional parameter: If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="beginCreatedAt">Optional parameter: If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endCreatedAt">Optional parameter: If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="status">Optional parameter: If provided, the endpoint returns only employee entities with the specified status (ACTIVE or INACTIVE).</param>
        /// <param name="externalId">Optional parameter: If provided, the endpoint returns only employee entities with the specified external_id.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Employee> response from the API call</return>
        Task<List<Models.V1Employee>> ListEmployeesAsync(
                string order = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                string beginCreatedAt = null,
                string endCreatedAt = null,
                string status = null,
                string externalId = null,
                int? limit = null,
                string batchToken = null, CancellationToken cancellationToken = default);

        /// <summary>
        ///  Use the CreateEmployee endpoint to add an employee to a Square
        /// account. Employees created with the Connect API have an initial status
        /// of `INACTIVE`. Inactive employees cannot sign in to Square Point of Sale
        /// until they are activated from the Square Dashboard. Employee status
        /// cannot be changed with the Connect API.
        /// <aside class="important">
        /// Employee entities cannot be deleted. To disable employee profiles,
        /// set the employee's status to <code>INACTIVE</code>
        /// </aside>
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Employee response from the API call</return>
        Models.V1Employee CreateEmployee(Models.V1Employee body);

        /// <summary>
        ///  Use the CreateEmployee endpoint to add an employee to a Square
        /// account. Employees created with the Connect API have an initial status
        /// of `INACTIVE`. Inactive employees cannot sign in to Square Point of Sale
        /// until they are activated from the Square Dashboard. Employee status
        /// cannot be changed with the Connect API.
        /// <aside class="important">
        /// Employee entities cannot be deleted. To disable employee profiles,
        /// set the employee's status to <code>INACTIVE</code>
        /// </aside>
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Employee response from the API call</return>
        Task<Models.V1Employee> CreateEmployeeAsync(Models.V1Employee body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single employee.
        /// </summary>
        /// <param name="employeeId">Required parameter: The employee's ID.</param>
        /// <return>Returns the Models.V1Employee response from the API call</return>
        Models.V1Employee RetrieveEmployee(string employeeId);

        /// <summary>
        /// Provides the details for a single employee.
        /// </summary>
        /// <param name="employeeId">Required parameter: The employee's ID.</param>
        /// <return>Returns the Models.V1Employee response from the API call</return>
        Task<Models.V1Employee> RetrieveEmployeeAsync(string employeeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// UpdateEmployee
        /// </summary>
        /// <param name="employeeId">Required parameter: The ID of the role to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Employee response from the API call</return>
        Models.V1Employee UpdateEmployee(string employeeId, Models.V1Employee body);

        /// <summary>
        /// UpdateEmployee
        /// </summary>
        /// <param name="employeeId">Required parameter: The ID of the role to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Employee response from the API call</return>
        Task<Models.V1Employee> UpdateEmployeeAsync(string employeeId, Models.V1Employee body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides summary information for all of a business's employee roles.
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.Default value: ASC</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1EmployeeRole> response from the API call</return>
        List<Models.V1EmployeeRole> ListEmployeeRoles(string order = null, int? limit = null, string batchToken = null);

        /// <summary>
        /// Provides summary information for all of a business's employee roles.
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.Default value: ASC</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1EmployeeRole> response from the API call</return>
        Task<List<Models.V1EmployeeRole>> ListEmployeeRolesAsync(string order = null, int? limit = null, string batchToken = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an employee role you can then assign to employees.
        /// Square accounts can include any number of roles that can be assigned to
        /// employees. These roles define the actions and permissions granted to an
        /// employee with that role. For example, an employee with a "Shift Manager"
        /// role might be able to issue refunds in Square Point of Sale, whereas an
        /// employee with a "Clerk" role might not.
        /// Roles are assigned with the [V1UpdateEmployee](#endpoint-v1updateemployee)
        /// endpoint. An employee can have only one role at a time.
        /// If an employee has no role, they have none of the permissions associated
        /// with roles. All employees can accept payments with Square Point of Sale.
        /// </summary>
        /// <param name="body">Required parameter: An EmployeeRole object with a name and permissions, and an optional owner flag.</param>
        /// <return>Returns the Models.V1EmployeeRole response from the API call</return>
        Models.V1EmployeeRole CreateEmployeeRole(Models.V1EmployeeRole body);

        /// <summary>
        /// Creates an employee role you can then assign to employees.
        /// Square accounts can include any number of roles that can be assigned to
        /// employees. These roles define the actions and permissions granted to an
        /// employee with that role. For example, an employee with a "Shift Manager"
        /// role might be able to issue refunds in Square Point of Sale, whereas an
        /// employee with a "Clerk" role might not.
        /// Roles are assigned with the [V1UpdateEmployee](#endpoint-v1updateemployee)
        /// endpoint. An employee can have only one role at a time.
        /// If an employee has no role, they have none of the permissions associated
        /// with roles. All employees can accept payments with Square Point of Sale.
        /// </summary>
        /// <param name="body">Required parameter: An EmployeeRole object with a name and permissions, and an optional owner flag.</param>
        /// <return>Returns the Models.V1EmployeeRole response from the API call</return>
        Task<Models.V1EmployeeRole> CreateEmployeeRoleAsync(Models.V1EmployeeRole body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single employee role.
        /// </summary>
        /// <param name="roleId">Required parameter: The role's ID.</param>
        /// <return>Returns the Models.V1EmployeeRole response from the API call</return>
        Models.V1EmployeeRole RetrieveEmployeeRole(string roleId);

        /// <summary>
        /// Provides the details for a single employee role.
        /// </summary>
        /// <param name="roleId">Required parameter: The role's ID.</param>
        /// <return>Returns the Models.V1EmployeeRole response from the API call</return>
        Task<Models.V1EmployeeRole> RetrieveEmployeeRoleAsync(string roleId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an employee role.
        /// </summary>
        /// <param name="roleId">Required parameter: The ID of the role to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1EmployeeRole response from the API call</return>
        Models.V1EmployeeRole UpdateEmployeeRole(string roleId, Models.V1EmployeeRole body);

        /// <summary>
        /// Modifies the details of an employee role.
        /// </summary>
        /// <param name="roleId">Required parameter: The ID of the role to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1EmployeeRole response from the API call</return>
        Task<Models.V1EmployeeRole> UpdateEmployeeRoleAsync(string roleId, Models.V1EmployeeRole body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides summary information for all of a business's employee timecards.
        /// </summary>
        /// <param name="order">Optional parameter: The order in which timecards are listed in the response, based on their created_at field.</param>
        /// <param name="employeeId">Optional parameter: If provided, the endpoint returns only timecards for the employee with the specified ID.</param>
        /// <param name="beginClockinTime">Optional parameter: If filtering results by their clockin_time field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endClockinTime">Optional parameter: If filtering results by their clockin_time field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="beginClockoutTime">Optional parameter: If filtering results by their clockout_time field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endClockoutTime">Optional parameter: If filtering results by their clockout_time field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="beginUpdatedAt">Optional parameter: If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endUpdatedAt">Optional parameter: If filtering results by their updated_at field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="deleted">Optional parameter: If true, only deleted timecards are returned. If false, only valid timecards are returned.If you don't provide this parameter, both valid and deleted timecards are returned.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Timecard> response from the API call</return>
        [Obsolete]
        List<Models.V1Timecard> ListTimecards(
                string order = null,
                string employeeId = null,
                string beginClockinTime = null,
                string endClockinTime = null,
                string beginClockoutTime = null,
                string endClockoutTime = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                bool? deleted = false,
                int? limit = null,
                string batchToken = null);

        /// <summary>
        /// Provides summary information for all of a business's employee timecards.
        /// </summary>
        /// <param name="order">Optional parameter: The order in which timecards are listed in the response, based on their created_at field.</param>
        /// <param name="employeeId">Optional parameter: If provided, the endpoint returns only timecards for the employee with the specified ID.</param>
        /// <param name="beginClockinTime">Optional parameter: If filtering results by their clockin_time field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endClockinTime">Optional parameter: If filtering results by their clockin_time field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="beginClockoutTime">Optional parameter: If filtering results by their clockout_time field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endClockoutTime">Optional parameter: If filtering results by their clockout_time field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="beginUpdatedAt">Optional parameter: If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endUpdatedAt">Optional parameter: If filtering results by their updated_at field, the end of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="deleted">Optional parameter: If true, only deleted timecards are returned. If false, only valid timecards are returned.If you don't provide this parameter, both valid and deleted timecards are returned.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint.</param>
        /// <return>Returns the List<Models.V1Timecard> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Timecard>> ListTimecardsAsync(
                string order = null,
                string employeeId = null,
                string beginClockinTime = null,
                string endClockinTime = null,
                string beginClockoutTime = null,
                string endClockoutTime = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                bool? deleted = false,
                int? limit = null,
                string batchToken = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a timecard for an employee and clocks them in with an
        /// `API_CREATE` event and a `clockin_time` set to the current time unless
        /// the request provides a different value.
        /// To import timecards from another
        /// system (rather than clocking someone in). Specify the `clockin_time`
        /// and* `clockout_time` in the request.
        /// Timecards correspond to exactly one shift for a given employee, bounded
        /// by the `clockin_time` and `clockout_time` fields. An employee is
        /// considered clocked in if they have a timecard that doesn't have a
        /// `clockout_time` set. An employee that is currently clocked in cannot
        /// be clocked in a second time.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Timecard response from the API call</return>
        [Obsolete]
        Models.V1Timecard CreateTimecard(Models.V1Timecard body);

        /// <summary>
        /// Creates a timecard for an employee and clocks them in with an
        /// `API_CREATE` event and a `clockin_time` set to the current time unless
        /// the request provides a different value.
        /// To import timecards from another
        /// system (rather than clocking someone in). Specify the `clockin_time`
        /// and* `clockout_time` in the request.
        /// Timecards correspond to exactly one shift for a given employee, bounded
        /// by the `clockin_time` and `clockout_time` fields. An employee is
        /// considered clocked in if they have a timecard that doesn't have a
        /// `clockout_time` set. An employee that is currently clocked in cannot
        /// be clocked in a second time.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Timecard response from the API call</return>
        [Obsolete]
        Task<Models.V1Timecard> CreateTimecardAsync(Models.V1Timecard body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a timecard. Timecards can also be deleted through the
        /// Square Dashboard. Deleted timecards are still accessible through
        /// Connect API endpoints, but cannot be modified. The `deleted` field of
        /// the `Timecard` object indicates whether the timecard has been deleted.
        /// __Note__: By default, deleted timecards appear alongside valid timecards in
        /// results returned by the [ListTimecards](#endpoint-v1employees-listtimecards)
        /// endpoint. To filter deleted timecards, include the `deleted` query
        /// parameter in the list request.
        /// Only approved accounts can manage their employees with Square.
        /// Unapproved accounts cannot use employee management features with the
        /// API.
        /// </summary>
        /// <param name="timecardId">Required parameter: The ID of the timecard to delete.</param>
        /// <return>Returns the object response from the API call</return>
        [Obsolete]
        object DeleteTimecard(string timecardId);

        /// <summary>
        /// Deletes a timecard. Timecards can also be deleted through the
        /// Square Dashboard. Deleted timecards are still accessible through
        /// Connect API endpoints, but cannot be modified. The `deleted` field of
        /// the `Timecard` object indicates whether the timecard has been deleted.
        /// __Note__: By default, deleted timecards appear alongside valid timecards in
        /// results returned by the [ListTimecards](#endpoint-v1employees-listtimecards)
        /// endpoint. To filter deleted timecards, include the `deleted` query
        /// parameter in the list request.
        /// Only approved accounts can manage their employees with Square.
        /// Unapproved accounts cannot use employee management features with the
        /// API.
        /// </summary>
        /// <param name="timecardId">Required parameter: The ID of the timecard to delete.</param>
        /// <return>Returns the object response from the API call</return>
        [Obsolete]
        Task<object> DeleteTimecardAsync(string timecardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single timecard.
        /// <aside>
        /// Only approved accounts can manage their employees with Square.
        /// Unapproved accounts cannot use employee management features with the
        /// API.
        /// </aside>
        /// </summary>
        /// <param name="timecardId">Required parameter: The timecard's ID.</param>
        /// <return>Returns the Models.V1Timecard response from the API call</return>
        [Obsolete]
        Models.V1Timecard RetrieveTimecard(string timecardId);

        /// <summary>
        /// Provides the details for a single timecard.
        /// <aside>
        /// Only approved accounts can manage their employees with Square.
        /// Unapproved accounts cannot use employee management features with the
        /// API.
        /// </aside>
        /// </summary>
        /// <param name="timecardId">Required parameter: The timecard's ID.</param>
        /// <return>Returns the Models.V1Timecard response from the API call</return>
        [Obsolete]
        Task<Models.V1Timecard> RetrieveTimecardAsync(string timecardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of a timecard with an `API_EDIT` event for
        /// the timecard. Updating an active timecard with a `clockout_time`
        /// clocks the employee out.
        /// </summary>
        /// <param name="timecardId">Required parameter: TThe ID of the timecard to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request. See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Timecard response from the API call</return>
        [Obsolete]
        Models.V1Timecard UpdateTimecard(string timecardId, Models.V1Timecard body);

        /// <summary>
        /// Modifies the details of a timecard with an `API_EDIT` event for
        /// the timecard. Updating an active timecard with a `clockout_time`
        /// clocks the employee out.
        /// </summary>
        /// <param name="timecardId">Required parameter: TThe ID of the timecard to modify.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request. See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.V1Timecard response from the API call</return>
        [Obsolete]
        Task<Models.V1Timecard> UpdateTimecardAsync(string timecardId, Models.V1Timecard body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides summary information for all events associated with a
        /// particular timecard.
        /// <aside>
        /// Only approved accounts can manage their employees with Square.
        /// Unapproved accounts cannot use employee management features with the
        /// API.
        /// </aside>
        /// </summary>
        /// <param name="timecardId">Required parameter: The ID of the timecard to list events for.</param>
        /// <return>Returns the List<Models.V1TimecardEvent> response from the API call</return>
        [Obsolete]
        List<Models.V1TimecardEvent> ListTimecardEvents(string timecardId);

        /// <summary>
        /// Provides summary information for all events associated with a
        /// particular timecard.
        /// <aside>
        /// Only approved accounts can manage their employees with Square.
        /// Unapproved accounts cannot use employee management features with the
        /// API.
        /// </aside>
        /// </summary>
        /// <param name="timecardId">Required parameter: The ID of the timecard to list events for.</param>
        /// <return>Returns the List<Models.V1TimecardEvent> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1TimecardEvent>> ListTimecardEventsAsync(string timecardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for all of a location's cash drawer shifts during a date range. The date range you specify cannot exceed 90 days.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="order">Optional parameter: The order in which cash drawer shifts are listed in the response, based on their created_at field. Default value: ASC</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time minus 90 days.</param>
        /// <param name="endTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time.</param>
        /// <return>Returns the List<Models.V1CashDrawerShift> response from the API call</return>
        [Obsolete]
        List<Models.V1CashDrawerShift> ListCashDrawerShifts(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null);

        /// <summary>
        /// Provides the details for all of a location's cash drawer shifts during a date range. The date range you specify cannot exceed 90 days.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="order">Optional parameter: The order in which cash drawer shifts are listed in the response, based on their created_at field. Default value: ASC</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time minus 90 days.</param>
        /// <param name="endTime">Optional parameter: The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time.</param>
        /// <return>Returns the List<Models.V1CashDrawerShift> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1CashDrawerShift>> ListCashDrawerShiftsAsync(
                string locationId,
                string order = null,
                string beginTime = null,
                string endTime = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single cash drawer shift, including all events that occurred during the shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="shiftId">Required parameter: The shift's ID.</param>
        /// <return>Returns the Models.V1CashDrawerShift response from the API call</return>
        [Obsolete]
        Models.V1CashDrawerShift RetrieveCashDrawerShift(string locationId, string shiftId);

        /// <summary>
        /// Provides the details for a single cash drawer shift, including all events that occurred during the shift.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list cash drawer shifts for.</param>
        /// <param name="shiftId">Required parameter: The shift's ID.</param>
        /// <return>Returns the Models.V1CashDrawerShift response from the API call</return>
        [Obsolete]
        Task<Models.V1CashDrawerShift> RetrieveCashDrawerShiftAsync(string locationId, string shiftId, CancellationToken cancellationToken = default);

    }
}