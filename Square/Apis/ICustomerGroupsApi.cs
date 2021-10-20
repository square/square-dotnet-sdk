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
    /// ICustomerGroupsApi.
    /// </summary>
    public interface ICustomerGroupsApi
    {
        /// <summary>
        /// Retrieves the list of customer groups of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. The limit is ignored if it is less than 1 or greater than 50. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <returns>Returns the Models.ListCustomerGroupsResponse response from the API call.</returns>
        Models.ListCustomerGroupsResponse ListCustomerGroups(
                string cursor = null,
                int? limit = null);

        /// <summary>
        /// Retrieves the list of customer groups of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. The limit is ignored if it is less than 1 or greater than 50. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerGroupsResponse response from the API call.</returns>
        Task<Models.ListCustomerGroupsResponse> ListCustomerGroupsAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new customer group for a business.
        /// The request must include the `name` value of the group.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerGroupResponse response from the API call.</returns>
        Models.CreateCustomerGroupResponse CreateCustomerGroup(
                Models.CreateCustomerGroupRequest body);

        /// <summary>
        /// Creates a new customer group for a business.
        /// The request must include the `name` value of the group.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerGroupResponse response from the API call.</returns>
        Task<Models.CreateCustomerGroupResponse> CreateCustomerGroupAsync(
                Models.CreateCustomerGroupRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to delete..</param>
        /// <returns>Returns the Models.DeleteCustomerGroupResponse response from the API call.</returns>
        Models.DeleteCustomerGroupResponse DeleteCustomerGroup(
                string groupId);

        /// <summary>
        /// Deletes a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerGroupResponse response from the API call.</returns>
        Task<Models.DeleteCustomerGroupResponse> DeleteCustomerGroupAsync(
                string groupId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to retrieve..</param>
        /// <returns>Returns the Models.RetrieveCustomerGroupResponse response from the API call.</returns>
        Models.RetrieveCustomerGroupResponse RetrieveCustomerGroup(
                string groupId);

        /// <summary>
        /// Retrieves a specific customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerGroupResponse response from the API call.</returns>
        Task<Models.RetrieveCustomerGroupResponse> RetrieveCustomerGroupAsync(
                string groupId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateCustomerGroupResponse response from the API call.</returns>
        Models.UpdateCustomerGroupResponse UpdateCustomerGroup(
                string groupId,
                Models.UpdateCustomerGroupRequest body);

        /// <summary>
        /// Updates a customer group as identified by the `group_id` value.
        /// </summary>
        /// <param name="groupId">Required parameter: The ID of the customer group to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCustomerGroupResponse response from the API call.</returns>
        Task<Models.UpdateCustomerGroupResponse> UpdateCustomerGroupAsync(
                string groupId,
                Models.UpdateCustomerGroupRequest body,
                CancellationToken cancellationToken = default);
    }
}