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
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Request.Configuration;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// SubscriptionsApi.
    /// </summary>
    internal class SubscriptionsApi : BaseApi, ISubscriptionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal SubscriptionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

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
        {
            Task<Models.CreateSubscriptionResponse> t = this.CreateSubscriptionAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        {
            Task<Models.SearchSubscriptionsResponse> t = this.SearchSubscriptionsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchSubscriptionsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to retrieve..</param>
        /// <param name="include">Optional parameter: A query parameter to specify related information to be included in the response.   The supported query parameter values are:   - `actions`: to include scheduled actions on the targeted subscription..</param>
        /// <returns>Returns the Models.RetrieveSubscriptionResponse response from the API call.</returns>
        public Models.RetrieveSubscriptionResponse RetrieveSubscription(
                string subscriptionId,
                string include = null)
        {
            Task<Models.RetrieveSubscriptionResponse> t = this.RetrieveSubscriptionAsync(subscriptionId, include);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "include", include },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        {
            Task<Models.UpdateSubscriptionResponse> t = this.UpdateSubscriptionAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a scheduled action for a subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription the targeted action is to act upon..</param>
        /// <param name="actionId">Required parameter: The ID of the targeted action to be deleted..</param>
        /// <returns>Returns the Models.DeleteSubscriptionActionResponse response from the API call.</returns>
        public Models.DeleteSubscriptionActionResponse DeleteSubscriptionAction(
                string subscriptionId,
                string actionId)
        {
            Task<Models.DeleteSubscriptionActionResponse> t = this.DeleteSubscriptionActionAsync(subscriptionId, actionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}/actions/{action_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
                { "action_id", actionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteSubscriptionActionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Schedules a `CANCEL` action to cancel an active subscription .
        /// by setting the `canceled_date` field to the end of the active billing period .
        /// and changing the subscription status from ACTIVE to CANCELED after this date.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to cancel..</param>
        /// <returns>Returns the Models.CancelSubscriptionResponse response from the API call.</returns>
        public Models.CancelSubscriptionResponse CancelSubscription(
                string subscriptionId)
        {
            Task<Models.CancelSubscriptionResponse> t = this.CancelSubscriptionAsync(subscriptionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}/cancel");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CancelSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        {
            Task<Models.ListSubscriptionEventsResponse> t = this.ListSubscriptionEventsAsync(subscriptionId, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}/events");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "limit", limit },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListSubscriptionEventsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Schedules a `PAUSE` action to pause an active subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to pause..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.PauseSubscriptionResponse response from the API call.</returns>
        public Models.PauseSubscriptionResponse PauseSubscription(
                string subscriptionId,
                Models.PauseSubscriptionRequest body)
        {
            Task<Models.PauseSubscriptionResponse> t = this.PauseSubscriptionAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}/pause");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.PauseSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to resume..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ResumeSubscriptionResponse response from the API call.</returns>
        public Models.ResumeSubscriptionResponse ResumeSubscription(
                string subscriptionId,
                Models.ResumeSubscriptionRequest body)
        {
            Task<Models.ResumeSubscriptionResponse> t = this.ResumeSubscriptionAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}/resume");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ResumeSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Schedules a `SWAP_PLAN` action to swap a subscription plan in an existing subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: The ID of the subscription to swap the subscription plan for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SwapPlanResponse response from the API call.</returns>
        public Models.SwapPlanResponse SwapPlan(
                string subscriptionId,
                Models.SwapPlanRequest body)
        {
            Task<Models.SwapPlanResponse> t = this.SwapPlanAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/subscriptions/{subscription_id}/swap-plan");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "subscription_id", subscriptionId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SwapPlanResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}