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
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// WebhookSubscriptionsApi.
    /// </summary>
    internal class WebhookSubscriptionsApi : BaseApi, IWebhookSubscriptionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookSubscriptionsApi"/> class.
        /// </summary>
        internal WebhookSubscriptionsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Lists all webhook event types that can be subscribed to.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <returns>Returns the Models.ListWebhookEventTypesResponse response from the API call.</returns>
        public Models.ListWebhookEventTypesResponse ListWebhookEventTypes(
                string apiVersion = null)
            => CoreHelper.RunTask(ListWebhookEventTypesAsync(apiVersion));

        /// <summary>
        /// Lists all webhook event types that can be subscribed to.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWebhookEventTypesResponse response from the API call.</returns>
        public async Task<Models.ListWebhookEventTypesResponse> ListWebhookEventTypesAsync(
                string apiVersion = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListWebhookEventTypesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/webhooks/event-types")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("api_version", apiVersion))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists all webhook subscriptions owned by your application.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled [Subscription](entity:WebhookSubscription)s. By default, all enabled [Subscription](entity:WebhookSubscription)s are returned..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the [Subscription](entity:WebhookSubscription) was created with the specified order. This field defaults to ASC..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value.  Default: 100.</param>
        /// <returns>Returns the Models.ListWebhookSubscriptionsResponse response from the API call.</returns>
        public Models.ListWebhookSubscriptionsResponse ListWebhookSubscriptions(
                string cursor = null,
                bool? includeDisabled = false,
                string sortOrder = null,
                int? limit = null)
            => CoreHelper.RunTask(ListWebhookSubscriptionsAsync(cursor, includeDisabled, sortOrder, limit));

        /// <summary>
        /// Lists all webhook subscriptions owned by your application.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled [Subscription](entity:WebhookSubscription)s. By default, all enabled [Subscription](entity:WebhookSubscription)s are returned..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the [Subscription](entity:WebhookSubscription) was created with the specified order. This field defaults to ASC..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value.  Default: 100.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWebhookSubscriptionsResponse response from the API call.</returns>
        public async Task<Models.ListWebhookSubscriptionsResponse> ListWebhookSubscriptionsAsync(
                string cursor = null,
                bool? includeDisabled = false,
                string sortOrder = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListWebhookSubscriptionsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/webhooks/subscriptions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("include_disabled", (includeDisabled != null) ? includeDisabled : false))
                      .Query(_query => _query.Setup("sort_order", sortOrder))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a webhook subscription.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateWebhookSubscriptionResponse response from the API call.</returns>
        public Models.CreateWebhookSubscriptionResponse CreateWebhookSubscription(
                Models.CreateWebhookSubscriptionRequest body)
            => CoreHelper.RunTask(CreateWebhookSubscriptionAsync(body));

        /// <summary>
        /// Creates a webhook subscription.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.CreateWebhookSubscriptionResponse> CreateWebhookSubscriptionAsync(
                Models.CreateWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateWebhookSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/webhooks/subscriptions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to delete..</param>
        /// <returns>Returns the Models.DeleteWebhookSubscriptionResponse response from the API call.</returns>
        public Models.DeleteWebhookSubscriptionResponse DeleteWebhookSubscription(
                string subscriptionId)
            => CoreHelper.RunTask(DeleteWebhookSubscriptionAsync(subscriptionId));

        /// <summary>
        /// Deletes a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.DeleteWebhookSubscriptionResponse> DeleteWebhookSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteWebhookSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/webhooks/subscriptions/{subscription_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a webhook subscription identified by its ID.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveWebhookSubscriptionResponse response from the API call.</returns>
        public Models.RetrieveWebhookSubscriptionResponse RetrieveWebhookSubscription(
                string subscriptionId)
            => CoreHelper.RunTask(RetrieveWebhookSubscriptionAsync(subscriptionId));

        /// <summary>
        /// Retrieves a webhook subscription identified by its ID.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.RetrieveWebhookSubscriptionResponse> RetrieveWebhookSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveWebhookSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/webhooks/subscriptions/{subscription_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionResponse response from the API call.</returns>
        public Models.UpdateWebhookSubscriptionResponse UpdateWebhookSubscription(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionRequest body)
            => CoreHelper.RunTask(UpdateWebhookSubscriptionAsync(subscriptionId, body));

        /// <summary>
        /// Updates a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.UpdateWebhookSubscriptionResponse> UpdateWebhookSubscriptionAsync(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateWebhookSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/webhooks/subscriptions/{subscription_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates a webhook subscription by replacing the existing signature key with a new one.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionSignatureKeyResponse response from the API call.</returns>
        public Models.UpdateWebhookSubscriptionSignatureKeyResponse UpdateWebhookSubscriptionSignatureKey(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionSignatureKeyRequest body)
            => CoreHelper.RunTask(UpdateWebhookSubscriptionSignatureKeyAsync(subscriptionId, body));

        /// <summary>
        /// Updates a webhook subscription by replacing the existing signature key with a new one.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionSignatureKeyResponse response from the API call.</returns>
        public async Task<Models.UpdateWebhookSubscriptionSignatureKeyResponse> UpdateWebhookSubscriptionSignatureKeyAsync(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionSignatureKeyRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateWebhookSubscriptionSignatureKeyResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/webhooks/subscriptions/{subscription_id}/signature-key")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Tests a webhook subscription by sending a test event to the notification URL.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to test..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.TestWebhookSubscriptionResponse response from the API call.</returns>
        public Models.TestWebhookSubscriptionResponse TestWebhookSubscription(
                string subscriptionId,
                Models.TestWebhookSubscriptionRequest body)
            => CoreHelper.RunTask(TestWebhookSubscriptionAsync(subscriptionId, body));

        /// <summary>
        /// Tests a webhook subscription by sending a test event to the notification URL.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to test..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.TestWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.TestWebhookSubscriptionResponse> TestWebhookSubscriptionAsync(
                string subscriptionId,
                Models.TestWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.TestWebhookSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/webhooks/subscriptions/{subscription_id}/test")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}