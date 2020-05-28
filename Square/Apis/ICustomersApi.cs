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
    public interface ICustomersApi
    {
        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.</param>
        /// <param name="sortField">Optional parameter: Indicates how Customers should be sorted.  Default: `DEFAULT`.</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether Customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  Default: `ASC`.</param>
        /// <return>Returns the Models.ListCustomersResponse response from the API call</return>
        Models.ListCustomersResponse ListCustomers(string cursor = null, string sortField = null, string sortOrder = null);

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.</param>
        /// <param name="sortField">Optional parameter: Indicates how Customers should be sorted.  Default: `DEFAULT`.</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether Customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  Default: `ASC`.</param>
        /// <return>Returns the Models.ListCustomersResponse response from the API call</return>
        Task<Models.ListCustomersResponse> ListCustomersAsync(string cursor = null, string sortField = null, string sortOrder = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new customer for a business, which can have associated cards on file.
        /// You must provide __at least one__ of the following values in your request to this
        /// endpoint:
        /// - `given_name`
        /// - `family_name`
        /// - `company_name`
        /// - `email_address`
        /// - `phone_number`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerResponse response from the API call</return>
        Models.CreateCustomerResponse CreateCustomer(Models.CreateCustomerRequest body);

        /// <summary>
        /// Creates a new customer for a business, which can have associated cards on file.
        /// You must provide __at least one__ of the following values in your request to this
        /// endpoint:
        /// - `given_name`
        /// - `family_name`
        /// - `company_name`
        /// - `email_address`
        /// - `phone_number`
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerResponse response from the API call</return>
        Task<Models.CreateCustomerResponse> CreateCustomerAsync(Models.CreateCustomerRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches the customer profiles associated with a Square account using 
        /// one or more supported query filters. 
        /// Calling `SearchCustomers` without any explicit query filter returns all
        /// customer profiles ordered alphabetically based on `given_name` and
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCustomersResponse response from the API call</return>
        Models.SearchCustomersResponse SearchCustomers(Models.SearchCustomersRequest body);

        /// <summary>
        /// Searches the customer profiles associated with a Square account using 
        /// one or more supported query filters. 
        /// Calling `SearchCustomers` without any explicit query filter returns all
        /// customer profiles ordered alphabetically based on `given_name` and
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available 
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated 
        /// profiles can take closer to one minute or longer, espeically during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCustomersResponse response from the API call</return>
        Task<Models.SearchCustomersResponse> SearchCustomersAsync(Models.SearchCustomersRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a customer from a business, along with any linked cards on file. When two profiles
        /// are merged into a single profile, that profile is assigned a new `customer_id`. You must use the
        /// new `customer_id` to delete merged profiles.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete.</param>
        /// <return>Returns the Models.DeleteCustomerResponse response from the API call</return>
        Models.DeleteCustomerResponse DeleteCustomer(string customerId);

        /// <summary>
        /// Deletes a customer from a business, along with any linked cards on file. When two profiles
        /// are merged into a single profile, that profile is assigned a new `customer_id`. You must use the
        /// new `customer_id` to delete merged profiles.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete.</param>
        /// <return>Returns the Models.DeleteCustomerResponse response from the API call</return>
        Task<Models.DeleteCustomerResponse> DeleteCustomerAsync(string customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve.</param>
        /// <return>Returns the Models.RetrieveCustomerResponse response from the API call</return>
        Models.RetrieveCustomerResponse RetrieveCustomer(string customerId);

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve.</param>
        /// <return>Returns the Models.RetrieveCustomerResponse response from the API call</return>
        Task<Models.RetrieveCustomerResponse> RetrieveCustomerAsync(string customerId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the details of an existing customer. When two profiles are merged
        /// into a single profile, that profile is assigned a new `customer_id`. You must use
        /// the new `customer_id` to update merged profiles.
        /// You cannot edit a customer's cards on file with this endpoint. To make changes
        /// to a card on file, you must delete the existing card on file with the
        /// [DeleteCustomerCard](#endpoint-deletecustomercard) endpoint, then create a new one with the
        /// [CreateCustomerCard](#endpoint-createcustomercard) endpoint.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateCustomerResponse response from the API call</return>
        Models.UpdateCustomerResponse UpdateCustomer(string customerId, Models.UpdateCustomerRequest body);

        /// <summary>
        /// Updates the details of an existing customer. When two profiles are merged
        /// into a single profile, that profile is assigned a new `customer_id`. You must use
        /// the new `customer_id` to update merged profiles.
        /// You cannot edit a customer's cards on file with this endpoint. To make changes
        /// to a card on file, you must delete the existing card on file with the
        /// [DeleteCustomerCard](#endpoint-deletecustomercard) endpoint, then create a new one with the
        /// [CreateCustomerCard](#endpoint-createcustomercard) endpoint.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateCustomerResponse response from the API call</return>
        Task<Models.UpdateCustomerResponse> UpdateCustomerAsync(string customerId, Models.UpdateCustomerRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
        /// calls with the same card nonce return the same card record that was created
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerCardResponse response from the API call</return>
        Models.CreateCustomerCardResponse CreateCustomerCard(string customerId, Models.CreateCustomerCardRequest body);

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
        /// calls with the same card nonce return the same card record that was created
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateCustomerCardResponse response from the API call</return>
        Task<Models.CreateCustomerCardResponse> CreateCustomerCardAsync(string customerId, Models.CreateCustomerCardRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to.</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete.</param>
        /// <return>Returns the Models.DeleteCustomerCardResponse response from the API call</return>
        Models.DeleteCustomerCardResponse DeleteCustomerCard(string customerId, string cardId);

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to.</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete.</param>
        /// <return>Returns the Models.DeleteCustomerCardResponse response from the API call</return>
        Task<Models.DeleteCustomerCardResponse> DeleteCustomerCardAsync(string customerId, string cardId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes a group membership from a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from.</param>
        /// <return>Returns the Models.RemoveGroupFromCustomerResponse response from the API call</return>
        Models.RemoveGroupFromCustomerResponse RemoveGroupFromCustomer(string customerId, string groupId);

        /// <summary>
        /// Removes a group membership from a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from.</param>
        /// <return>Returns the Models.RemoveGroupFromCustomerResponse response from the API call</return>
        Task<Models.RemoveGroupFromCustomerResponse> RemoveGroupFromCustomerAsync(string customerId, string groupId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a group membership to a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to.</param>
        /// <return>Returns the Models.AddGroupToCustomerResponse response from the API call</return>
        Models.AddGroupToCustomerResponse AddGroupToCustomer(string customerId, string groupId);

        /// <summary>
        /// Adds a group membership to a customer. 
        /// The customer is identified by the `customer_id` value 
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group.</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to.</param>
        /// <return>Returns the Models.AddGroupToCustomerResponse response from the API call</return>
        Task<Models.AddGroupToCustomerResponse> AddGroupToCustomerAsync(string customerId, string groupId, CancellationToken cancellationToken = default);

    }
}