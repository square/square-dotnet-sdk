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
    /// SubscriptionsApi.
    /// </summary>
    internal class SubscriptionsApi : BaseApi, ISubscriptionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsApi"/> class.
        /// </summary>
        internal SubscriptionsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Creates a subscription to a subscription plan by a customer.
        /// If you provide a card on file in the request, Square charges the card for.
        /// the subscription. Otherwise, Square bills an invoice to the customer's email.
        /// address. The subscription starts immediately, unless the request includes.
        /// the optional `start_date`. Each individual subscription is associated with a particular location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateSubscriptionResponse response from the API call.</returns>
        public Models.CreateSubscriptionResponse CreateSubscription(
                Models.CreateSubscriptionRequest body)
            => CoreHelper.RunTask(CreateSubscriptionAsync(body));

        /// <summary>
        /// Creates a subscription to a subscription plan by a customer.
        /// If you provide a card on file in the request, Square charges the card for.
        /// the subscription. Otherwise, Square bills an invoice to the customer's email.
        /// address. The subscription starts immediately, unless the request includes.
        /// the optional `start_date`. Each individual subscription is associated with a particular location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateSubscriptionResponse response from the API call.</returns>
        public async Task<Models.CreateSubscriptionResponse> CreateSubscriptionAsync(
                Models.CreateSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/subscriptions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.CreateSubscriptionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Searches for subscriptions.
        /// Results are ordered chronologically by subscription creation date. If.
        /// the request specifies more than one location ID,.
        /// the endpoint orders the result.
        /// by location ID, and then by creation date within each location. If no locations are given.
        /// in the query, all locations are searched.
        /// You can also optionally specify `customer_ids` to search by customer.
        /// If left unset, all customers.
        /// associated with the specified locations are returned.
        /// If the request specifies customer IDs, the endpoint orders results.
        /// first by location, within location by customer ID, and within.
        /// customer by subscription creation date.
        /// For more information, see.
        /// [Retrieve subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchSubscriptionsResponse response from the API call.</returns>
        public Models.SearchSubscriptionsResponse SearchSubscriptions(
                Models.SearchSubscriptionsRequest body)
            => CoreHelper.RunTask(SearchSubscriptionsAsync(body));

        /// <summary>
        /// Searches for subscriptions.
        /// Results are ordered chronologically by subscription creation date. If.
        /// the request specifies more than one location ID,.
        /// the endpoint orders the result.
        /// by location ID, and then by creation date within each location. If no locations are given.
        /// in the query, all locations are searched.
        /// You can also optionally specify `customer_ids` to search by customer.
        /// If left unset, all customers.
        /// associated with the specified locations are returned.
        /// If the request specifies customer IDs, the endpoint orders results.
        /// first by location, within location by customer ID, and within.
        /// customer by subscription creation date.
        /// For more information, see.
        /// [Retrieve subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchSubscriptionsResponse response from the API call.</returns>
        public async Task<Models.SearchSubscriptionsResponse> SearchSubscriptionsAsync(
                Models.SearchSubscriptionsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchSubscriptionsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/subscriptions/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.SearchSubscriptionsResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve..</param>
        /// <param name="include">Optional parameter: A query parameter to specify related information to be included in the response.   The supported query parameter values are:   - `actions`: to include scheduled actions on the targeted subscription..</param>
        /// <returns>Returns the Models.RetrieveSubscriptionResponse response from the API call.</returns>
        public Models.RetrieveSubscriptionResponse RetrieveSubscription(
                string subscriptionId,
                string include = null)
            => CoreHelper.RunTask(RetrieveSubscriptionAsync(subscriptionId, include));

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve..</param>
        /// <param name="include">Optional parameter: A query parameter to specify related information to be included in the response.   The supported query parameter values are:   - `actions`: to include scheduled actions on the targeted subscription..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveSubscriptionResponse response from the API call.</returns>
        public async Task<Models.RetrieveSubscriptionResponse> RetrieveSubscriptionAsync(
                string subscriptionId,
                string include = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/subscriptions/{subscription_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Query(_query => _query.Setup("include", include))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.RetrieveSubscriptionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates a subscription. You can set, modify, and clear the.
        /// `subscription` field values.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateSubscriptionResponse response from the API call.</returns>
        public Models.UpdateSubscriptionResponse UpdateSubscription(
                string subscriptionId,
                Models.UpdateSubscriptionRequest body)
            => CoreHelper.RunTask(UpdateSubscriptionAsync(subscriptionId, body));

        /// <summary>
        /// Updates a subscription. You can set, modify, and clear the.
        /// `subscription` field values.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateSubscriptionResponse response from the API call.</returns>
        public async Task<Models.UpdateSubscriptionResponse> UpdateSubscriptionAsync(
                string subscriptionId,
                Models.UpdateSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/subscriptions/{subscription_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.UpdateSubscriptionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes a scheduled action for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription the targeted action is to act upon..</param>
        /// <param name="actionId">Required parameter: The ID of the targeted action to be deleted..</param>
        /// <returns>Returns the Models.DeleteSubscriptionActionResponse response from the API call.</returns>
        public Models.DeleteSubscriptionActionResponse DeleteSubscriptionAction(
                string subscriptionId,
                string actionId)
            => CoreHelper.RunTask(DeleteSubscriptionActionAsync(subscriptionId, actionId));

        /// <summary>
        /// Deletes a scheduled action for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription the targeted action is to act upon..</param>
        /// <param name="actionId">Required parameter: The ID of the targeted action to be deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteSubscriptionActionResponse response from the API call.</returns>
        public async Task<Models.DeleteSubscriptionActionResponse> DeleteSubscriptionActionAsync(
                string subscriptionId,
                string actionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteSubscriptionActionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/subscriptions/{subscription_id}/actions/{action_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Template(_template => _template.Setup("action_id", actionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.DeleteSubscriptionActionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Schedules a `CANCEL` action to cancel an active subscription .
        /// by setting the `canceled_date` field to the end of the active billing period .
        /// and changing the subscription status from ACTIVE to CANCELED after this date.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel..</param>
        /// <returns>Returns the Models.CancelSubscriptionResponse response from the API call.</returns>
        public Models.CancelSubscriptionResponse CancelSubscription(
                string subscriptionId)
            => CoreHelper.RunTask(CancelSubscriptionAsync(subscriptionId));

        /// <summary>
        /// Schedules a `CANCEL` action to cancel an active subscription .
        /// by setting the `canceled_date` field to the end of the active billing period .
        /// and changing the subscription status from ACTIVE to CANCELED after this date.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelSubscriptionResponse response from the API call.</returns>
        public async Task<Models.CancelSubscriptionResponse> CancelSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/subscriptions/{subscription_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.CancelSubscriptionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Lists all events for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve the events for..</param>
        /// <param name="cursor">Optional parameter: When the total number of resulting subscription events exceeds the limit of a paged response,  specify the cursor returned from a preceding response here to fetch the next set of results. If the cursor is unset, the response contains the last page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The upper limit on the number of subscription events to return in a paged response..</param>
        /// <returns>Returns the Models.ListSubscriptionEventsResponse response from the API call.</returns>
        public Models.ListSubscriptionEventsResponse ListSubscriptionEvents(
                string subscriptionId,
                string cursor = null,
                int? limit = null)
            => CoreHelper.RunTask(ListSubscriptionEventsAsync(subscriptionId, cursor, limit));

        /// <summary>
        /// Lists all events for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve the events for..</param>
        /// <param name="cursor">Optional parameter: When the total number of resulting subscription events exceeds the limit of a paged response,  specify the cursor returned from a preceding response here to fetch the next set of results. If the cursor is unset, the response contains the last page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The upper limit on the number of subscription events to return in a paged response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListSubscriptionEventsResponse response from the API call.</returns>
        public async Task<Models.ListSubscriptionEventsResponse> ListSubscriptionEventsAsync(
                string subscriptionId,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListSubscriptionEventsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/subscriptions/{subscription_id}/events")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.ListSubscriptionEventsResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Schedules a `PAUSE` action to pause an active subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to pause..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.PauseSubscriptionResponse response from the API call.</returns>
        public Models.PauseSubscriptionResponse PauseSubscription(
                string subscriptionId,
                Models.PauseSubscriptionRequest body)
            => CoreHelper.RunTask(PauseSubscriptionAsync(subscriptionId, body));

        /// <summary>
        /// Schedules a `PAUSE` action to pause an active subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to pause..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PauseSubscriptionResponse response from the API call.</returns>
        public async Task<Models.PauseSubscriptionResponse> PauseSubscriptionAsync(
                string subscriptionId,
                Models.PauseSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PauseSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/subscriptions/{subscription_id}/pause")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.PauseSubscriptionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to resume..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ResumeSubscriptionResponse response from the API call.</returns>
        public Models.ResumeSubscriptionResponse ResumeSubscription(
                string subscriptionId,
                Models.ResumeSubscriptionRequest body)
            => CoreHelper.RunTask(ResumeSubscriptionAsync(subscriptionId, body));

        /// <summary>
        /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to resume..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResumeSubscriptionResponse response from the API call.</returns>
        public async Task<Models.ResumeSubscriptionResponse> ResumeSubscriptionAsync(
                string subscriptionId,
                Models.ResumeSubscriptionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ResumeSubscriptionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/subscriptions/{subscription_id}/resume")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.ResumeSubscriptionResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Schedules a `SWAP_PLAN` action to swap a subscription plan in an existing subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to swap the subscription plan for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SwapPlanResponse response from the API call.</returns>
        public Models.SwapPlanResponse SwapPlan(
                string subscriptionId,
                Models.SwapPlanRequest body)
            => CoreHelper.RunTask(SwapPlanAsync(subscriptionId, body));

        /// <summary>
        /// Schedules a `SWAP_PLAN` action to swap a subscription plan in an existing subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to swap the subscription plan for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SwapPlanResponse response from the API call.</returns>
        public async Task<Models.SwapPlanResponse> SwapPlanAsync(
                string subscriptionId,
                Models.SwapPlanRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SwapPlanResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/subscriptions/{subscription_id}/swap-plan")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("subscription_id", subscriptionId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.SwapPlanResponse>(_response)))
              .ExecuteAsync(cancellationToken);
    }
}