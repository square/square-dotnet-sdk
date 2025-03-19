using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// CustomersApi.
    /// </summary>
    internal class CustomersApi : BaseApi, ICustomersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersApi"/> class.
        /// </summary>
        internal CustomersApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="sortField">Optional parameter: Indicates how customers should be sorted.  The default value is `DEFAULT`..</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  The default value is `ASC`..</param>
        /// <param name="count">Optional parameter: Indicates whether to return the total count of customers in the `count` field of the response.  The default value is `false`..</param>
        /// <returns>Returns the Models.ListCustomersResponse response from the API call.</returns>
        public Models.ListCustomersResponse ListCustomers(
            string cursor = null,
            int? limit = null,
            string sortField = null,
            string sortOrder = null,
            bool? count = false
        ) => CoreHelper.RunTask(ListCustomersAsync(cursor, limit, sortField, sortOrder, count));

        /// <summary>
        /// Lists customer profiles associated with a Square account.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="sortField">Optional parameter: Indicates how customers should be sorted.  The default value is `DEFAULT`..</param>
        /// <param name="sortOrder">Optional parameter: Indicates whether customers should be sorted in ascending (`ASC`) or descending (`DESC`) order.  The default value is `ASC`..</param>
        /// <param name="count">Optional parameter: Indicates whether to return the total count of customers in the `count` field of the response.  The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomersResponse response from the API call.</returns>
        public async Task<Models.ListCustomersResponse> ListCustomersAsync(
            string cursor = null,
            int? limit = null,
            string sortField = null,
            string sortOrder = null,
            bool? count = false,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListCustomersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/customers")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Query(_query => _query.Setup("cursor", cursor))
                                .Query(_query => _query.Setup("limit", limit))
                                .Query(_query => _query.Setup("sort_field", sortField))
                                .Query(_query => _query.Setup("sort_order", sortOrder))
                                .Query(_query => _query.Setup("count", count ?? false))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new customer for a business.
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
        public Models.CreateCustomerResponse CreateCustomer(Models.CreateCustomerRequest body) =>
            CoreHelper.RunTask(CreateCustomerAsync(body));

        /// <summary>
        /// Creates a new customer for a business.
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
        public async Task<Models.CreateCustomerResponse> CreateCustomerAsync(
            Models.CreateCustomerRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.CreateCustomerResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates multiple [customer profiles]($m/Customer) for a business.
        /// This endpoint takes a map of individual create requests and returns a map of responses.
        /// You must provide at least one of the following values in each create request:.
        /// - `given_name`.
        /// - `family_name`.
        /// - `company_name`.
        /// - `email_address`.
        /// - `phone_number`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateCustomersResponse response from the API call.</returns>
        public Models.BulkCreateCustomersResponse BulkCreateCustomers(
            Models.BulkCreateCustomersRequest body
        ) => CoreHelper.RunTask(BulkCreateCustomersAsync(body));

        /// <summary>
        /// Creates multiple [customer profiles]($m/Customer) for a business.
        /// This endpoint takes a map of individual create requests and returns a map of responses.
        /// You must provide at least one of the following values in each create request:.
        /// - `given_name`.
        /// - `family_name`.
        /// - `company_name`.
        /// - `email_address`.
        /// - `phone_number`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkCreateCustomersResponse response from the API call.</returns>
        public async Task<Models.BulkCreateCustomersResponse> BulkCreateCustomersAsync(
            Models.BulkCreateCustomersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkCreateCustomersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/bulk-create")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes multiple customer profiles.
        /// The endpoint takes a list of customer IDs and returns a map of responses.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteCustomersResponse response from the API call.</returns>
        public Models.BulkDeleteCustomersResponse BulkDeleteCustomers(
            Models.BulkDeleteCustomersRequest body
        ) => CoreHelper.RunTask(BulkDeleteCustomersAsync(body));

        /// <summary>
        /// Deletes multiple customer profiles.
        /// The endpoint takes a list of customer IDs and returns a map of responses.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteCustomersResponse response from the API call.</returns>
        public async Task<Models.BulkDeleteCustomersResponse> BulkDeleteCustomersAsync(
            Models.BulkDeleteCustomersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkDeleteCustomersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/bulk-delete")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves multiple customer profiles.
        /// This endpoint takes a list of customer IDs and returns a map of responses.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveCustomersResponse response from the API call.</returns>
        public Models.BulkRetrieveCustomersResponse BulkRetrieveCustomers(
            Models.BulkRetrieveCustomersRequest body
        ) => CoreHelper.RunTask(BulkRetrieveCustomersAsync(body));

        /// <summary>
        /// Retrieves multiple customer profiles.
        /// This endpoint takes a list of customer IDs and returns a map of responses.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveCustomersResponse response from the API call.</returns>
        public async Task<Models.BulkRetrieveCustomersResponse> BulkRetrieveCustomersAsync(
            Models.BulkRetrieveCustomersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkRetrieveCustomersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/bulk-retrieve")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates multiple customer profiles.
        /// This endpoint takes a map of individual update requests and returns a map of responses.
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateCustomersResponse response from the API call.</returns>
        public Models.BulkUpdateCustomersResponse BulkUpdateCustomers(
            Models.BulkUpdateCustomersRequest body
        ) => CoreHelper.RunTask(BulkUpdateCustomersAsync(body));

        /// <summary>
        /// Updates multiple customer profiles.
        /// This endpoint takes a map of individual update requests and returns a map of responses.
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpdateCustomersResponse response from the API call.</returns>
        public async Task<Models.BulkUpdateCustomersResponse> BulkUpdateCustomersAsync(
            Models.BulkUpdateCustomersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkUpdateCustomersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/bulk-update")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Searches the customer profiles associated with a Square account using one or more supported query filters.
        /// Calling `SearchCustomers` without any explicit query filter returns all.
        /// customer profiles ordered alphabetically based on `given_name` and.
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCustomersResponse response from the API call.</returns>
        public Models.SearchCustomersResponse SearchCustomers(Models.SearchCustomersRequest body) =>
            CoreHelper.RunTask(SearchCustomersAsync(body));

        /// <summary>
        /// Searches the customer profiles associated with a Square account using one or more supported query filters.
        /// Calling `SearchCustomers` without any explicit query filter returns all.
        /// customer profiles ordered alphabetically based on `given_name` and.
        /// `family_name`.
        /// Under normal operating conditions, newly created or updated customer profiles become available.
        /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated.
        /// profiles can take closer to one minute or longer, especially during network incidents and outages.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCustomersResponse response from the API call.</returns>
        public async Task<Models.SearchCustomersResponse> SearchCustomersAsync(
            Models.SearchCustomersRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.SearchCustomersResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/search")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a customer profile from a business. This operation also unlinks any associated cards on file.
        /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete..</param>
        /// <param name="version">Optional parameter: The current version of the customer profile.  As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile)..</param>
        /// <returns>Returns the Models.DeleteCustomerResponse response from the API call.</returns>
        public Models.DeleteCustomerResponse DeleteCustomer(
            string customerId,
            long? version = null
        ) => CoreHelper.RunTask(DeleteCustomerAsync(customerId, version));

        /// <summary>
        /// Deletes a customer profile from a business. This operation also unlinks any associated cards on file.
        /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to delete..</param>
        /// <param name="version">Optional parameter: The current version of the customer profile.  As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerResponse response from the API call.</returns>
        public async Task<Models.DeleteCustomerResponse> DeleteCustomerAsync(
            string customerId,
            long? version = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.DeleteCustomerResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Delete, "/v2/customers/{customer_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Query(_query => _query.Setup("version", version))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve..</param>
        /// <returns>Returns the Models.RetrieveCustomerResponse response from the API call.</returns>
        public Models.RetrieveCustomerResponse RetrieveCustomer(string customerId) =>
            CoreHelper.RunTask(RetrieveCustomerAsync(customerId));

        /// <summary>
        /// Returns details for a single customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerResponse> RetrieveCustomerAsync(
            string customerId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveCustomerResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/customers/{customer_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template =>
                                _template.Setup("customer_id", customerId)
                            )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates a customer profile. This endpoint supports sparse updates, so only new or changed fields are required in the request.
        /// To add or update a field, specify the new value. To remove a field, specify `null`.
        /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards).
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateCustomerResponse response from the API call.</returns>
        public Models.UpdateCustomerResponse UpdateCustomer(
            string customerId,
            Models.UpdateCustomerRequest body
        ) => CoreHelper.RunTask(UpdateCustomerAsync(customerId, body));

        /// <summary>
        /// Updates a customer profile. This endpoint supports sparse updates, so only new or changed fields are required in the request.
        /// To add or update a field, specify the new value. To remove a field, specify `null`.
        /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
        /// You cannot use this endpoint to change cards on file. To make changes, use the [Cards API]($e/Cards) or [Gift Cards API]($e/GiftCards).
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCustomerResponse response from the API call.</returns>
        public async Task<Models.UpdateCustomerResponse> UpdateCustomerAsync(
            string customerId,
            Models.UpdateCustomerRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpdateCustomerResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/customers/{customer_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple.
        /// calls with the same card nonce return the same card record that was created.
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateCustomerCardResponse CreateCustomerCard(
            string customerId,
            Models.CreateCustomerCardRequest body
        ) => CoreHelper.RunTask(CreateCustomerCardAsync(customerId, body));

        /// <summary>
        /// Adds a card on file to an existing customer.
        /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple.
        /// calls with the same card nonce return the same card record that was created.
        /// with the provided nonce during the _first_ call.
        /// </summary>
        /// <param name="customerId">Required parameter: The Square ID of the customer profile the card is linked to..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateCustomerCardResponse> CreateCustomerCardAsync(
            string customerId,
            Models.CreateCustomerCardRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.CreateCustomerCardResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/{customer_id}/cards")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to..</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete..</param>
        /// <returns>Returns the Models.DeleteCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public Models.DeleteCustomerCardResponse DeleteCustomerCard(
            string customerId,
            string cardId
        ) => CoreHelper.RunTask(DeleteCustomerCardAsync(customerId, cardId));

        /// <summary>
        /// Removes a card on file from a customer.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer that the card on file belongs to..</param>
        /// <param name="cardId">Required parameter: The ID of the card on file to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerCardResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.DeleteCustomerCardResponse> DeleteCustomerCardAsync(
            string customerId,
            string cardId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.DeleteCustomerCardResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Delete, "/v2/customers/{customer_id}/cards/{card_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Template(_template => _template.Setup("card_id", cardId))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Removes a group membership from a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from..</param>
        /// <returns>Returns the Models.RemoveGroupFromCustomerResponse response from the API call.</returns>
        public Models.RemoveGroupFromCustomerResponse RemoveGroupFromCustomer(
            string customerId,
            string groupId
        ) => CoreHelper.RunTask(RemoveGroupFromCustomerAsync(customerId, groupId));

        /// <summary>
        /// Removes a group membership from a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to remove from the group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to remove the customer from..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RemoveGroupFromCustomerResponse response from the API call.</returns>
        public async Task<Models.RemoveGroupFromCustomerResponse> RemoveGroupFromCustomerAsync(
            string customerId,
            string groupId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RemoveGroupFromCustomerResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Delete, "/v2/customers/{customer_id}/groups/{group_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Template(_template => _template.Setup("group_id", groupId))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a group membership to a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to..</param>
        /// <returns>Returns the Models.AddGroupToCustomerResponse response from the API call.</returns>
        public Models.AddGroupToCustomerResponse AddGroupToCustomer(
            string customerId,
            string groupId
        ) => CoreHelper.RunTask(AddGroupToCustomerAsync(customerId, groupId));

        /// <summary>
        /// Adds a group membership to a customer.
        /// The customer is identified by the `customer_id` value.
        /// and the customer group is identified by the `group_id` value.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the customer to add to a group..</param>
        /// <param name="groupId">Required parameter: The ID of the customer group to add the customer to..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AddGroupToCustomerResponse response from the API call.</returns>
        public async Task<Models.AddGroupToCustomerResponse> AddGroupToCustomerAsync(
            string customerId,
            string groupId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.AddGroupToCustomerResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/customers/{customer_id}/groups/{group_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Template(_template => _template.Setup("group_id", groupId))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
