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
    /// IV1EmployeesApi.
    /// </summary>
    public interface IV1EmployeesApi
    {
        /// <summary>
        /// Provides summary information for all of a business's employees..
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.      Default value: ASC.</param>
        /// <param name="beginUpdatedAt">Optional parameter: If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endUpdatedAt">Optional parameter: If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format..</param>
        /// <param name="beginCreatedAt">Optional parameter: If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format..</param>
        /// <param name="endCreatedAt">Optional parameter: If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format..</param>
        /// <param name="status">Optional parameter: If provided, the endpoint returns only employee entities with the specified status (ACTIVE or INACTIVE)..</param>
        /// <param name="externalId">Optional parameter: If provided, the endpoint returns only employee entities with the specified external_id..</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns>Returns the List<Models.V1Employee> response from the API call.</returns>
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
        /// Provides summary information for all of a business's employees..
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.      Default value: ASC.</param>
        /// <param name="beginUpdatedAt">Optional parameter: If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format.</param>
        /// <param name="endUpdatedAt">Optional parameter: If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format..</param>
        /// <param name="beginCreatedAt">Optional parameter: If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format..</param>
        /// <param name="endCreatedAt">Optional parameter: If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format..</param>
        /// <param name="status">Optional parameter: If provided, the endpoint returns only employee entities with the specified status (ACTIVE or INACTIVE)..</param>
        /// <param name="externalId">Optional parameter: If provided, the endpoint returns only employee entities with the specified external_id..</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List<Models.V1Employee> response from the API call.</returns>
        Task<List<Models.V1Employee>> ListEmployeesAsync(
                string order = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                string beginCreatedAt = null,
                string endCreatedAt = null,
                string status = null,
                string externalId = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        ///  Use the CreateEmployee endpoint to add an employee to a Square.
        /// account. Employees created with the Connect API have an initial status.
        /// of `INACTIVE`. Inactive employees cannot sign in to Square Point of Sale.
        /// until they are activated from the Square Dashboard. Employee status.
        /// cannot be changed with the Connect API..
        /// Employee entities cannot be deleted. To disable employee profiles,.
        /// set the employee's status to <code>INACTIVE</code>.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        Models.V1Employee CreateEmployee(
                Models.V1Employee body);

        /// <summary>
        ///  Use the CreateEmployee endpoint to add an employee to a Square.
        /// account. Employees created with the Connect API have an initial status.
        /// of `INACTIVE`. Inactive employees cannot sign in to Square Point of Sale.
        /// until they are activated from the Square Dashboard. Employee status.
        /// cannot be changed with the Connect API..
        /// Employee entities cannot be deleted. To disable employee profiles,.
        /// set the employee's status to <code>INACTIVE</code>.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        Task<Models.V1Employee> CreateEmployeeAsync(
                Models.V1Employee body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single employee..
        /// </summary>
        /// <param name="employeeId">Required parameter: The employee's ID..</param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        Models.V1Employee RetrieveEmployee(
                string employeeId);

        /// <summary>
        /// Provides the details for a single employee..
        /// </summary>
        /// <param name="employeeId">Required parameter: The employee's ID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        Task<Models.V1Employee> RetrieveEmployeeAsync(
                string employeeId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// UpdateEmployee.
        /// </summary>
        /// <param name="employeeId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        Models.V1Employee UpdateEmployee(
                string employeeId,
                Models.V1Employee body);

        /// <summary>
        /// UpdateEmployee.
        /// </summary>
        /// <param name="employeeId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        Task<Models.V1Employee> UpdateEmployeeAsync(
                string employeeId,
                Models.V1Employee body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides summary information for all of a business's employee roles..
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.Default value: ASC.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns>Returns the List<Models.V1EmployeeRole> response from the API call.</returns>
        List<Models.V1EmployeeRole> ListEmployeeRoles(
                string order = null,
                int? limit = null,
                string batchToken = null);

        /// <summary>
        /// Provides summary information for all of a business's employee roles..
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.Default value: ASC.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List<Models.V1EmployeeRole> response from the API call.</returns>
        Task<List<Models.V1EmployeeRole>> ListEmployeeRolesAsync(
                string order = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an employee role you can then assign to employees..
        /// Square accounts can include any number of roles that can be assigned to.
        /// employees. These roles define the actions and permissions granted to an.
        /// employee with that role. For example, an employee with a "Shift Manager".
        /// role might be able to issue refunds in Square Point of Sale, whereas an.
        /// employee with a "Clerk" role might not..
        /// Roles are assigned with the [V1UpdateEmployee]($e/V1Employees/UpdateEmployeeRole).
        /// endpoint. An employee can have only one role at a time..
        /// If an employee has no role, they have none of the permissions associated.
        /// with roles. All employees can accept payments with Square Point of Sale..
        /// </summary>
        /// <param name="body">Required parameter: An EmployeeRole object with a name and permissions, and an optional owner flag..</param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        Models.V1EmployeeRole CreateEmployeeRole(
                Models.V1EmployeeRole body);

        /// <summary>
        /// Creates an employee role you can then assign to employees..
        /// Square accounts can include any number of roles that can be assigned to.
        /// employees. These roles define the actions and permissions granted to an.
        /// employee with that role. For example, an employee with a "Shift Manager".
        /// role might be able to issue refunds in Square Point of Sale, whereas an.
        /// employee with a "Clerk" role might not..
        /// Roles are assigned with the [V1UpdateEmployee]($e/V1Employees/UpdateEmployeeRole).
        /// endpoint. An employee can have only one role at a time..
        /// If an employee has no role, they have none of the permissions associated.
        /// with roles. All employees can accept payments with Square Point of Sale..
        /// </summary>
        /// <param name="body">Required parameter: An EmployeeRole object with a name and permissions, and an optional owner flag..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        Task<Models.V1EmployeeRole> CreateEmployeeRoleAsync(
                Models.V1EmployeeRole body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides the details for a single employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The role's ID..</param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        Models.V1EmployeeRole RetrieveEmployeeRole(
                string roleId);

        /// <summary>
        /// Provides the details for a single employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The role's ID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        Task<Models.V1EmployeeRole> RetrieveEmployeeRoleAsync(
                string roleId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Modifies the details of an employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        Models.V1EmployeeRole UpdateEmployeeRole(
                string roleId,
                Models.V1EmployeeRole body);

        /// <summary>
        /// Modifies the details of an employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        Task<Models.V1EmployeeRole> UpdateEmployeeRoleAsync(
                string roleId,
                Models.V1EmployeeRole body,
                CancellationToken cancellationToken = default);
    }
}