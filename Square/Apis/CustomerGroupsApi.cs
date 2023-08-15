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
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// CustomerGroupsApi.
    /// </summary>
    internal class CustomerGroupsApi : BaseApi, ICustomerGroupsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGroupsApi"/> class.
        /// </summary>
        internal CustomerGroupsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieves the list of customer groups of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListCustomerGroupsResponse response from the API call.</returns>
        public Models.ListCustomerGroupsResponse ListCustomerGroups(
                string cursor = null,
                int? limit = null)
            => CoreHelper.RunTask(ListCustomerGroupsAsync(cursor, limit));

        /// <summary>
        /// Retrieves the list of customer groups of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerGroupsResponse response from the API call.</returns>
        public async Task<Models.ListCustomerGroupsResponse> ListCustomerGroupsAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListCustomerGroupsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/customers/groups")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a new customer group for a business.
        /// The request must include the `name` value of the group.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerGroupResponse response from the API call.</returns>
        public Models.CreateCustomerGroupResponse CreateCustomerGroup(
                Models.CreateCustomerGroupRequest body)
            => CoreHelper.RunTask(CreateCustomerGroupAsync(body));

        /// <summary>
        /// Creates a new customer group for a business.
        /// The request must include the `name` value of the group.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerGroupResponse response from the API call.</returns>
        public async Task<Models.CreateCustomerGroupResponse> CreateCustomerGroupAsync(
                Models.CreateCustomerGroupRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateCustomerGroupResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/customers/groups")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to delete..</param>
        /// <returns>Returns the Models.DeleteCustomerGroupResponse response from the API call.</returns>
        public Models.DeleteCustomerGroupResponse DeleteCustomerGroup(
                string groupId)
            => CoreHelper.RunTask(DeleteCustomerGroupAsync(groupId));

        /// <summary>
        /// Deletes a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerGroupResponse response from the API call.</returns>
        public async Task<Models.DeleteCustomerGroupResponse> DeleteCustomerGroupAsync(
                string groupId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteCustomerGroupResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/customers/groups/{group_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("group_id", groupId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a specific customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to retrieve..</param>
        /// <returns>Returns the Models.RetrieveCustomerGroupResponse response from the API call.</returns>
        public Models.RetrieveCustomerGroupResponse RetrieveCustomerGroup(
                string groupId)
            => CoreHelper.RunTask(RetrieveCustomerGroupAsync(groupId));

        /// <summary>
        /// Retrieves a specific customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerGroupResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerGroupResponse> RetrieveCustomerGroupAsync(
                string groupId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveCustomerGroupResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/customers/groups/{group_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("group_id", groupId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateCustomerGroupResponse response from the API call.</returns>
        public Models.UpdateCustomerGroupResponse UpdateCustomerGroup(
                string groupId,
                Models.UpdateCustomerGroupRequest body)
            => CoreHelper.RunTask(UpdateCustomerGroupAsync(groupId, body));

        /// <summary>
        /// Updates a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCustomerGroupResponse response from the API call.</returns>
        public async Task<Models.UpdateCustomerGroupResponse> UpdateCustomerGroupAsync(
                string groupId,
                Models.UpdateCustomerGroupRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateCustomerGroupResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/customers/groups/{group_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("group_id", groupId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}