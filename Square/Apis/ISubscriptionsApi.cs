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
    /// ISubscriptionsApi.
    /// </summary>
    public interface ISubscriptionsApi
    {
        /// <summary>
        /// Creates a subscription to a subscription plan by a customer.
        /// If you provide a card on file in the request, Square charges the card for.
        /// the subscription. Otherwise, Square bills an invoice to the customer's email.
        /// address. The subscription starts immediately, unless the request includes.
        /// the optional `start_date`. Each individual subscription is associated with a particular location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateSubscriptionResponse response from the API call.</returns>
        Models.CreateSubscriptionResponse CreateSubscription(
                Models.CreateSubscriptionRequest body);

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
        Task<Models.CreateSubscriptionResponse> CreateSubscriptionAsync(
                Models.CreateSubscriptionRequest body,
                CancellationToken cancellationToken = default);

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
        Models.SearchSubscriptionsResponse SearchSubscriptions(
                Models.SearchSubscriptionsRequest body);

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
        Task<Models.SearchSubscriptionsResponse> SearchSubscriptionsAsync(
                Models.SearchSubscriptionsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve..</param>
        /// <param name="include">Optional parameter: A query parameter to specify related information to be included in the response.   The supported query parameter values are:   - `actions`: to include scheduled actions on the targeted subscription..</param>
        /// <returns>Returns the Models.RetrieveSubscriptionResponse response from the API call.</returns>
        Models.RetrieveSubscriptionResponse RetrieveSubscription(
                string subscriptionId,
                string include = null);

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve..</param>
        /// <param name="include">Optional parameter: A query parameter to specify related information to be included in the response.   The supported query parameter values are:   - `actions`: to include scheduled actions on the targeted subscription..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveSubscriptionResponse response from the API call.</returns>
        Task<Models.RetrieveSubscriptionResponse> RetrieveSubscriptionAsync(
                string subscriptionId,
                string include = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a subscription. You can set, modify, and clear the.
        /// `subscription` field values.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateSubscriptionResponse response from the API call.</returns>
        Models.UpdateSubscriptionResponse UpdateSubscription(
                string subscriptionId,
                Models.UpdateSubscriptionRequest body);

        /// <summary>
        /// Updates a subscription. You can set, modify, and clear the.
        /// `subscription` field values.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateSubscriptionResponse response from the API call.</returns>
        Task<Models.UpdateSubscriptionResponse> UpdateSubscriptionAsync(
                string subscriptionId,
                Models.UpdateSubscriptionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a scheduled action for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription the targeted action is to act upon..</param>
        /// <param name="actionId">Required parameter: The ID of the targeted action to be deleted..</param>
        /// <returns>Returns the Models.DeleteSubscriptionActionResponse response from the API call.</returns>
        Models.DeleteSubscriptionActionResponse DeleteSubscriptionAction(
                string subscriptionId,
                string actionId);

        /// <summary>
        /// Deletes a scheduled action for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription the targeted action is to act upon..</param>
        /// <param name="actionId">Required parameter: The ID of the targeted action to be deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteSubscriptionActionResponse response from the API call.</returns>
        Task<Models.DeleteSubscriptionActionResponse> DeleteSubscriptionActionAsync(
                string subscriptionId,
                string actionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Schedules a `CANCEL` action to cancel an active subscription .
        /// by setting the `canceled_date` field to the end of the active billing period .
        /// and changing the subscription status from ACTIVE to CANCELED after this date.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel..</param>
        /// <returns>Returns the Models.CancelSubscriptionResponse response from the API call.</returns>
        Models.CancelSubscriptionResponse CancelSubscription(
                string subscriptionId);

        /// <summary>
        /// Schedules a `CANCEL` action to cancel an active subscription .
        /// by setting the `canceled_date` field to the end of the active billing period .
        /// and changing the subscription status from ACTIVE to CANCELED after this date.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelSubscriptionResponse response from the API call.</returns>
        Task<Models.CancelSubscriptionResponse> CancelSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all events for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve the events for..</param>
        /// <param name="cursor">Optional parameter: When the total number of resulting subscription events exceeds the limit of a paged response,  specify the cursor returned from a preceding response here to fetch the next set of results. If the cursor is unset, the response contains the last page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The upper limit on the number of subscription events to return in a paged response..</param>
        /// <returns>Returns the Models.ListSubscriptionEventsResponse response from the API call.</returns>
        Models.ListSubscriptionEventsResponse ListSubscriptionEvents(
                string subscriptionId,
                string cursor = null,
                int? limit = null);

        /// <summary>
        /// Lists all events for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve the events for..</param>
        /// <param name="cursor">Optional parameter: When the total number of resulting subscription events exceeds the limit of a paged response,  specify the cursor returned from a preceding response here to fetch the next set of results. If the cursor is unset, the response contains the last page of the results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The upper limit on the number of subscription events to return in a paged response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListSubscriptionEventsResponse response from the API call.</returns>
        Task<Models.ListSubscriptionEventsResponse> ListSubscriptionEventsAsync(
                string subscriptionId,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Schedules a `PAUSE` action to pause an active subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to pause..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.PauseSubscriptionResponse response from the API call.</returns>
        Models.PauseSubscriptionResponse PauseSubscription(
                string subscriptionId,
                Models.PauseSubscriptionRequest body);

        /// <summary>
        /// Schedules a `PAUSE` action to pause an active subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to pause..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PauseSubscriptionResponse response from the API call.</returns>
        Task<Models.PauseSubscriptionResponse> PauseSubscriptionAsync(
                string subscriptionId,
                Models.PauseSubscriptionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to resume..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ResumeSubscriptionResponse response from the API call.</returns>
        Models.ResumeSubscriptionResponse ResumeSubscription(
                string subscriptionId,
                Models.ResumeSubscriptionRequest body);

        /// <summary>
        /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to resume..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResumeSubscriptionResponse response from the API call.</returns>
        Task<Models.ResumeSubscriptionResponse> ResumeSubscriptionAsync(
                string subscriptionId,
                Models.ResumeSubscriptionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Schedules a `SWAP_PLAN` action to swap a subscription plan in an existing subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to swap the subscription plan for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SwapPlanResponse response from the API call.</returns>
        Models.SwapPlanResponse SwapPlan(
                string subscriptionId,
                Models.SwapPlanRequest body);

        /// <summary>
        /// Schedules a `SWAP_PLAN` action to swap a subscription plan in an existing subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to swap the subscription plan for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SwapPlanResponse response from the API call.</returns>
        Task<Models.SwapPlanResponse> SwapPlanAsync(
                string subscriptionId,
                Models.SwapPlanRequest body,
                CancellationToken cancellationToken = default);
    }
}