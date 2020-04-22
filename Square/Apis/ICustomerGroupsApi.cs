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
    public interface ICustomerGroupsApi
    {
        /// <summary>
        /// Retrieves the list of customer groups of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.</param>
        /// <return>Returns the Models.ListCustomerGroupsResponse response from the API call</return>
        Models.ListCustomerGroupsResponse ListCustomerGroups(string cursor = null);

        /// <summary>
        /// Retrieves the list of customer groups of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.</param>
        /// <return>Returns the Models.ListCustomerGroupsResponse response from the API call</return>
        Task<Models.ListCustomerGroupsResponse> ListCustomerGroupsAsync(string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new customer group for a business. 
        /// The request must include the `name` value of the group.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerGroupResponse response from the API call</return>
        Models.CreateCustomerGroupResponse CreateCustomerGroup(Models.CreateCustomerGroupRequest body);

        /// <summary>
        /// Creates a new customer group for a business. 
        /// The request must include the `name` value of the group.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerGroupResponse response from the API call</return>
        Task<Models.CreateCustomerGroupResponse> CreateCustomerGroupAsync(Models.CreateCustomerGroupRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to delete.</param>
        /// <return>Returns the Models.DeleteCustomerGroupResponse response from the API call</return>
        Models.DeleteCustomerGroupResponse DeleteCustomerGroup(string groupId);

        /// <summary>
        /// Deletes a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to delete.</param>
        /// <return>Returns the Models.DeleteCustomerGroupResponse response from the API call</return>
        Task<Models.DeleteCustomerGroupResponse> DeleteCustomerGroupAsync(string groupId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to retrieve.</param>
        /// <return>Returns the Models.RetrieveCustomerGroupResponse response from the API call</return>
        Models.RetrieveCustomerGroupResponse RetrieveCustomerGroup(string groupId);

        /// <summary>
        /// Retrieves a specific customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to retrieve.</param>
        /// <return>Returns the Models.RetrieveCustomerGroupResponse response from the API call</return>
        Task<Models.RetrieveCustomerGroupResponse> RetrieveCustomerGroupAsync(string groupId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateCustomerGroupResponse response from the API call</return>
        Models.UpdateCustomerGroupResponse UpdateCustomerGroup(string groupId, Models.UpdateCustomerGroupRequest body);

        /// <summary>
        /// Updates a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateCustomerGroupResponse response from the API call</return>
        Task<Models.UpdateCustomerGroupResponse> UpdateCustomerGroupAsync(string groupId, Models.UpdateCustomerGroupRequest body, CancellationToken cancellationToken = default);

    }
}