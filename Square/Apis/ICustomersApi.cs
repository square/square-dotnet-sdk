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
    /// ICustomersApi.
    /// </summary>
    public interface ICustomersApi
    {
        /// <summary>
        /// Lists customer profiles associated with a Square account..
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages..
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="sortField">Optional parameter: Indicates how customers should be sorted.  Default: `DEFAULT`..</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  Default: `ASC`..</param>
        /// <returns>Returns the Models.ListCustomersResponse response from the API call.</returns>
        Models.ListCustomersResponse ListCustomers(
                string cursor = null,
                string sortField = null,
                string sortOrder = null);

        /// <summary>
        /// Lists customer profiles associated with a Square account..
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages..
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="sortField">Optional parameter: Indicates how customers should be sorted.  Default: `DEFAULT`..</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  Default: `ASC`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomersResponse response from the API call.</returns>
        Task<Models.ListCustomersResponse> ListCustomersAsync(
                string cursor = null,
                string sortField = null,
                string sortOrder = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new customer for a business..
        /// You must provide at least one of the following values in your request to this.
        /// endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// - `company_name`.
        /// - `email_address`.
        /// - `phone_number`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerResponse response from the API call.</returns>
        Models.CreateCustomerResponse CreateCustomer(
                Models.CreateCustomerRequest body);

        /// <summary>
        /// Creates a new customer for a business..
        /// You must provide at least one of the following values in your request to this.
        /// endpoint:.
        /// - `given_name`.
        /// - `family_name`.
        /// - `company_name`.
        /// - `email_address`.
        /// - `phone_number`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerResponse response from the API call.</returns>
        Task<Models.CreateCustomerResponse> CreateCustomerAsync(
                Models.CreateCustomerRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches the customer profiles associated with a Square account using a supported query filter..
        /// Calling `SearchCustomers` without any explicit query filter returns all.
        /// customer profiles ordered alphabetically based on `given_name` and.
        /// `family_name`..
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCustomersResponse response from the API call.</returns>
        Models.SearchCustomersResponse SearchCustomers(
                Models.SearchCustomersRequest body);

        /// <summary>
        /// Searches the customer profiles associated with a Square account using a supported query filter..
        /// Calling `SearchCustomers` without any explicit query filter returns all.
        /// customer profiles ordered alphabetically based on `given_name` and.
        /// `family_name`..
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCustomersResponse response from the API call.</returns>
        Task<Models.SearchCustomersResponse> SearchCustomersAsync(
                Models.SearchCustomersRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a customer profile from a business. This operation also unlinks any associated cards on file. .
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile. .
        /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete..</param>
        /// <param name="version">Optional parameter: The current version of the customer profile.   As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile)..</param>
        /// <returns>Returns the Models.DeleteCustomerResponse response from the API call.</returns>
        Models.DeleteCustomerResponse DeleteCustomer(
                string customerId,
                long? version = null);

        /// <summary>
        /// Deletes a customer profile from a business. This operation also unlinks any associated cards on file. .
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile. .
        /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete..</param>
        /// <param name="version">Optional parameter: The current version of the customer profile.   As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerResponse response from the API call.</returns>
        Task<Models.DeleteCustomerResponse> DeleteCustomerAsync(
                string customerId,
                long? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details for a single customer..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve..</param>
        /// <returns>Returns the Models.RetrieveCustomerResponse response from the API call.</returns>
        Models.RetrieveCustomerResponse RetrieveCustomer(
                string customerId);

        /// <summary>
        /// Returns details for a single customer..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerResponse response from the API call.</returns>
        Task<Models.RetrieveCustomerResponse> RetrieveCustomerAsync(
                string customerId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a customer profile. To change an attribute, specify the new value. To remove an attribute, specify the value as an empty string or empty object..
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile..
        /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile..
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards)..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateCustomerResponse response from the API call.</returns>
        Models.UpdateCustomerResponse UpdateCustomer(
                string customerId,
                Models.UpdateCustomerRequest body);

        /// <summary>
        /// Updates a customer profile. To change an attribute, specify the new value. To remove an attribute, specify the value as an empty string or empty object..
        /// As a best practice, you should include the `version` field in the request to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. The value must be set to the current version of the customer profile..
        /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile..
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards)..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCustomerResponse response from the API call.</returns>
        Task<Models.UpdateCustomerResponse> UpdateCustomerAsync(
                string customerId,
                Models.UpdateCustomerRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a card on file to an existing customer..
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple.
        /// calls with the same card nonce return the same card record that was created.
        /// with the provided nonce during the _first_ call..
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        Models.CreateCustomerCardResponse CreateCustomerCard(
                string customerId,
                Models.CreateCustomerCardRequest body);

        /// <summary>
        /// Adds a card on file to an existing customer..
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple.
        /// calls with the same card nonce return the same card record that was created.
        /// with the provided nonce during the _first_ call..
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.CreateCustomerCardResponse> CreateCustomerCardAsync(
                string customerId,
                Models.CreateCustomerCardRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a card on file from a customer..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to..</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete..</param>
        /// <returns>Returns the Models.DeleteCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        Models.DeleteCustomerCardResponse DeleteCustomerCard(
                string customerId,
                string cardId);

        /// <summary>
        /// Removes a card on file from a customer..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to..</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.DeleteCustomerCardResponse> DeleteCustomerCardAsync(
                string customerId,
                string cardId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a group membership from a customer..
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from..</param>
        /// <returns>Returns the Models.RemoveGroupFromCustomerResponse response from the API call.</returns>
        Models.RemoveGroupFromCustomerResponse RemoveGroupFromCustomer(
                string customerId,
                string groupId);

        /// <summary>
        /// Removes a group membership from a customer..
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RemoveGroupFromCustomerResponse response from the API call.</returns>
        Task<Models.RemoveGroupFromCustomerResponse> RemoveGroupFromCustomerAsync(
                string customerId,
                string groupId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a group membership to a customer..
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to..</param>
        /// <returns>Returns the Models.AddGroupToCustomerResponse response from the API call.</returns>
        Models.AddGroupToCustomerResponse AddGroupToCustomer(
                string customerId,
                string groupId);

        /// <summary>
        /// Adds a group membership to a customer..
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value..
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AddGroupToCustomerResponse response from the API call.</returns>
        Task<Models.AddGroupToCustomerResponse> AddGroupToCustomerAsync(
                string customerId,
                string groupId,
                CancellationToken cancellationToken = default);
    }
}