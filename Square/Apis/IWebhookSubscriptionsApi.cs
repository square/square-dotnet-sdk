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
    /// IWebhookSubscriptionsApi.
    /// </summary>
    public interface IWebhookSubscriptionsApi
    {
        /// <summary>
        /// Lists all webhook event types that can be subscribed to.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <returns>Returns the Models.ListWebhookEventTypesResponse response from the API call.</returns>
        Models.ListWebhookEventTypesResponse ListWebhookEventTypes(
                string apiVersion = null);

        /// <summary>
        /// Lists all webhook event types that can be subscribed to.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWebhookEventTypesResponse response from the API call.</returns>
        Task<Models.ListWebhookEventTypesResponse> ListWebhookEventTypesAsync(
                string apiVersion = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all webhook subscriptions owned by your application.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled [Subscription]($m/WebhookSubscription)s. By default, all enabled [Subscription]($m/WebhookSubscription)s are returned..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the [Subscription]($m/WebhookSubscription) was created with the specified order. This field defaults to ASC..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value.  Default: 100.</param>
        /// <returns>Returns the Models.ListWebhookSubscriptionsResponse response from the API call.</returns>
        Models.ListWebhookSubscriptionsResponse ListWebhookSubscriptions(
                string cursor = null,
                bool? includeDisabled = false,
                string sortOrder = null,
                int? limit = null);

        /// <summary>
        /// Lists all webhook subscriptions owned by your application.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled [Subscription]($m/WebhookSubscription)s. By default, all enabled [Subscription]($m/WebhookSubscription)s are returned..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the [Subscription]($m/WebhookSubscription) was created with the specified order. This field defaults to ASC..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value.  Default: 100.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWebhookSubscriptionsResponse response from the API call.</returns>
        Task<Models.ListWebhookSubscriptionsResponse> ListWebhookSubscriptionsAsync(
                string cursor = null,
                bool? includeDisabled = false,
                string sortOrder = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a webhook subscription.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateWebhookSubscriptionResponse response from the API call.</returns>
        Models.CreateWebhookSubscriptionResponse CreateWebhookSubscription(
                Models.CreateWebhookSubscriptionRequest body);

        /// <summary>
        /// Creates a webhook subscription.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateWebhookSubscriptionResponse response from the API call.</returns>
        Task<Models.CreateWebhookSubscriptionResponse> CreateWebhookSubscriptionAsync(
                Models.CreateWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to delete..</param>
        /// <returns>Returns the Models.DeleteWebhookSubscriptionResponse response from the API call.</returns>
        Models.DeleteWebhookSubscriptionResponse DeleteWebhookSubscription(
                string subscriptionId);

        /// <summary>
        /// Deletes a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteWebhookSubscriptionResponse response from the API call.</returns>
        Task<Models.DeleteWebhookSubscriptionResponse> DeleteWebhookSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a webhook subscription identified by its ID.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveWebhookSubscriptionResponse response from the API call.</returns>
        Models.RetrieveWebhookSubscriptionResponse RetrieveWebhookSubscription(
                string subscriptionId);

        /// <summary>
        /// Retrieves a webhook subscription identified by its ID.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveWebhookSubscriptionResponse response from the API call.</returns>
        Task<Models.RetrieveWebhookSubscriptionResponse> RetrieveWebhookSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionResponse response from the API call.</returns>
        Models.UpdateWebhookSubscriptionResponse UpdateWebhookSubscription(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionRequest body);

        /// <summary>
        /// Updates a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionResponse response from the API call.</returns>
        Task<Models.UpdateWebhookSubscriptionResponse> UpdateWebhookSubscriptionAsync(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a webhook subscription by replacing the existing signature key with a new one.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionSignatureKeyResponse response from the API call.</returns>
        Models.UpdateWebhookSubscriptionSignatureKeyResponse UpdateWebhookSubscriptionSignatureKey(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionSignatureKeyRequest body);

        /// <summary>
        /// Updates a webhook subscription by replacing the existing signature key with a new one.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionSignatureKeyResponse response from the API call.</returns>
        Task<Models.UpdateWebhookSubscriptionSignatureKeyResponse> UpdateWebhookSubscriptionSignatureKeyAsync(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionSignatureKeyRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Tests a webhook subscription by sending a test event to the notification URL.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to test..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.TestWebhookSubscriptionResponse response from the API call.</returns>
        Models.TestWebhookSubscriptionResponse TestWebhookSubscription(
                string subscriptionId,
                Models.TestWebhookSubscriptionRequest body);

        /// <summary>
        /// Tests a webhook subscription by sending a test event to the notification URL.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to test..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.TestWebhookSubscriptionResponse response from the API call.</returns>
        Task<Models.TestWebhookSubscriptionResponse> TestWebhookSubscriptionAsync(
                string subscriptionId,
                Models.TestWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default);
    }
}