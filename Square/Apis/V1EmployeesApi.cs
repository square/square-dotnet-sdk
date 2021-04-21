namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// V1EmployeesApi.
    /// </summary>
    internal class V1EmployeesApi : BaseApi, IV1EmployeesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1EmployeesApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal V1EmployeesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

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
        /// <returns>Returns the List of Models.V1Employee response from the API call.</returns>
        public List<Models.V1Employee> ListEmployees(
                string order = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                string beginCreatedAt = null,
                string endCreatedAt = null,
                string status = null,
                string externalId = null,
                int? limit = null,
                string batchToken = null)
        {
            Task<List<Models.V1Employee>> t = this.ListEmployeesAsync(order, beginUpdatedAt, endUpdatedAt, beginCreatedAt, endCreatedAt, status, externalId, limit, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        /// <returns>Returns the List of Models.V1Employee response from the API call.</returns>
        public async Task<List<Models.V1Employee>> ListEmployeesAsync(
                string order = null,
                string beginUpdatedAt = null,
                string endUpdatedAt = null,
                string beginCreatedAt = null,
                string endCreatedAt = null,
                string status = null,
                string externalId = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/employees");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
                { "begin_updated_at", beginUpdatedAt },
                { "end_updated_at", endUpdatedAt },
                { "begin_created_at", beginCreatedAt },
                { "end_created_at", endCreatedAt },
                { "status", status },
                { "external_id", externalId },
                { "limit", limit },
                { "batch_token", batchToken },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModels = ApiHelper.JsonDeserialize<List<Models.V1Employee>>(response.Body);
            responseModels.ForEach(r => r.Context = context);
            return responseModels;
        }

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
        public Models.V1Employee CreateEmployee(
                Models.V1Employee body)
        {
            Task<Models.V1Employee> t = this.CreateEmployeeAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.V1Employee> CreateEmployeeAsync(
                Models.V1Employee body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/employees");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Employee>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides the details for a single employee..
        /// </summary>
        /// <param name="employeeId">Required parameter: The employee's ID..</param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        public Models.V1Employee RetrieveEmployee(
                string employeeId)
        {
            Task<Models.V1Employee> t = this.RetrieveEmployeeAsync(employeeId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the details for a single employee..
        /// </summary>
        /// <param name="employeeId">Required parameter: The employee's ID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        public async Task<Models.V1Employee> RetrieveEmployeeAsync(
                string employeeId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/employees/{employee_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "employee_id", employeeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Employee>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// UpdateEmployee.
        /// </summary>
        /// <param name="employeeId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        public Models.V1Employee UpdateEmployee(
                string employeeId,
                Models.V1Employee body)
        {
            Task<Models.V1Employee> t = this.UpdateEmployeeAsync(employeeId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// UpdateEmployee.
        /// </summary>
        /// <param name="employeeId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1Employee response from the API call.</returns>
        public async Task<Models.V1Employee> UpdateEmployeeAsync(
                string employeeId,
                Models.V1Employee body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/employees/{employee_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "employee_id", employeeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.V1Employee>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides summary information for all of a business's employee roles..
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.Default value: ASC.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <returns>Returns the List of Models.V1EmployeeRole response from the API call.</returns>
        public List<Models.V1EmployeeRole> ListEmployeeRoles(
                string order = null,
                int? limit = null,
                string batchToken = null)
        {
            Task<List<Models.V1EmployeeRole>> t = this.ListEmployeeRolesAsync(order, limit, batchToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides summary information for all of a business's employee roles..
        /// </summary>
        /// <param name="order">Optional parameter: The order in which employees are listed in the response, based on their created_at field.Default value: ASC.</param>
        /// <param name="limit">Optional parameter: The maximum integer number of employee entities to return in a single response. Default 100, maximum 200..</param>
        /// <param name="batchToken">Optional parameter: A pagination cursor to retrieve the next set of results for your original query to the endpoint..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.V1EmployeeRole response from the API call.</returns>
        public async Task<List<Models.V1EmployeeRole>> ListEmployeeRolesAsync(
                string order = null,
                int? limit = null,
                string batchToken = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/roles");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
                { "limit", limit },
                { "batch_token", batchToken },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModels = ApiHelper.JsonDeserialize<List<Models.V1EmployeeRole>>(response.Body);
            responseModels.ForEach(r => r.Context = context);
            return responseModels;
        }

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
        public Models.V1EmployeeRole CreateEmployeeRole(
                Models.V1EmployeeRole body)
        {
            Task<Models.V1EmployeeRole> t = this.CreateEmployeeRoleAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.V1EmployeeRole> CreateEmployeeRoleAsync(
                Models.V1EmployeeRole body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/roles");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.V1EmployeeRole>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Provides the details for a single employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The role's ID..</param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        public Models.V1EmployeeRole RetrieveEmployeeRole(
                string roleId)
        {
            Task<Models.V1EmployeeRole> t = this.RetrieveEmployeeRoleAsync(roleId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Provides the details for a single employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The role's ID..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        public async Task<Models.V1EmployeeRole> RetrieveEmployeeRoleAsync(
                string roleId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/roles/{role_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "role_id", roleId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.V1EmployeeRole>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Modifies the details of an employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        public Models.V1EmployeeRole UpdateEmployeeRole(
                string roleId,
                Models.V1EmployeeRole body)
        {
            Task<Models.V1EmployeeRole> t = this.UpdateEmployeeRoleAsync(roleId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Modifies the details of an employee role..
        /// </summary>
        /// <param name="roleId">Required parameter: The ID of the role to modify..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.V1EmployeeRole response from the API call.</returns>
        public async Task<Models.V1EmployeeRole> UpdateEmployeeRoleAsync(
                string roleId,
                Models.V1EmployeeRole body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v1/me/roles/{role_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "role_id", roleId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.V1EmployeeRole>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}