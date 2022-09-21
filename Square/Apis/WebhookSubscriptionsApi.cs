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
    /// WebhookSubscriptionsApi.
    /// </summary>
    internal class WebhookSubscriptionsApi : BaseApi, IWebhookSubscriptionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookSubscriptionsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal WebhookSubscriptionsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Lists all webhook event types that can be subscribed to.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <returns>Returns the Models.ListWebhookEventTypesResponse response from the API call.</returns>
        public Models.ListWebhookEventTypesResponse ListWebhookEventTypes(
                string apiVersion = null)
        {
            Task<Models.ListWebhookEventTypesResponse> t = this.ListWebhookEventTypesAsync(apiVersion);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists all webhook event types that can be subscribed to.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWebhookEventTypesResponse response from the API call.</returns>
        public async Task<Models.ListWebhookEventTypesResponse> ListWebhookEventTypesAsync(
                string apiVersion = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/event-types");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "api_version", apiVersion },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListWebhookEventTypesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Lists all webhook subscriptions owned by your application.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled [Subscription]($m/WebhookSubscription)s. By default, all enabled [Subscription]($m/WebhookSubscription)s are returned..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the [Subscription]($m/WebhookSubscription) was created with the specified order. This field defaults to ASC..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value.  Default: 100.</param>
        /// <returns>Returns the Models.ListWebhookSubscriptionsResponse response from the API call.</returns>
        public Models.ListWebhookSubscriptionsResponse ListWebhookSubscriptions(
                string cursor = null,
                bool? includeDisabled = false,
                string sortOrder = null,
                int? limit = null)
        {
            Task<Models.ListWebhookSubscriptionsResponse> t = this.ListWebhookSubscriptionsAsync(cursor, includeDisabled, sortOrder, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists all webhook subscriptions owned by your application.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="includeDisabled">Optional parameter: Includes disabled [Subscription]($m/WebhookSubscription)s. By default, all enabled [Subscription]($m/WebhookSubscription)s are returned..</param>
        /// <param name="sortOrder">Optional parameter: Sorts the returned list by when the [Subscription]($m/WebhookSubscription) was created with the specified order. This field defaults to ASC..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value.  Default: 100.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWebhookSubscriptionsResponse response from the API call.</returns>
        public async Task<Models.ListWebhookSubscriptionsResponse> ListWebhookSubscriptionsAsync(
                string cursor = null,
                bool? includeDisabled = false,
                string sortOrder = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "include_disabled", (includeDisabled != null) ? includeDisabled : false },
                { "sort_order", sortOrder },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListWebhookSubscriptionsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a webhook subscription.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateWebhookSubscriptionResponse response from the API call.</returns>
        public Models.CreateWebhookSubscriptionResponse CreateWebhookSubscription(
                Models.CreateWebhookSubscriptionRequest body)
        {
            Task<Models.CreateWebhookSubscriptionResponse> t = this.CreateWebhookSubscriptionAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a webhook subscription.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.CreateWebhookSubscriptionResponse> CreateWebhookSubscriptionAsync(
                Models.CreateWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateWebhookSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to delete..</param>
        /// <returns>Returns the Models.DeleteWebhookSubscriptionResponse response from the API call.</returns>
        public Models.DeleteWebhookSubscriptionResponse DeleteWebhookSubscription(
                string subscriptionId)
        {
            Task<Models.DeleteWebhookSubscriptionResponse> t = this.DeleteWebhookSubscriptionAsync(subscriptionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.DeleteWebhookSubscriptionResponse> DeleteWebhookSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions/{subscription_id}");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteWebhookSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a webhook subscription identified by its ID.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveWebhookSubscriptionResponse response from the API call.</returns>
        public Models.RetrieveWebhookSubscriptionResponse RetrieveWebhookSubscription(
                string subscriptionId)
        {
            Task<Models.RetrieveWebhookSubscriptionResponse> t = this.RetrieveWebhookSubscriptionAsync(subscriptionId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a webhook subscription identified by its ID.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.RetrieveWebhookSubscriptionResponse> RetrieveWebhookSubscriptionAsync(
                string subscriptionId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions/{subscription_id}");

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
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveWebhookSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionResponse response from the API call.</returns>
        public Models.UpdateWebhookSubscriptionResponse UpdateWebhookSubscription(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionRequest body)
        {
            Task<Models.UpdateWebhookSubscriptionResponse> t = this.UpdateWebhookSubscriptionAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a webhook subscription.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.UpdateWebhookSubscriptionResponse> UpdateWebhookSubscriptionAsync(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions/{subscription_id}");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateWebhookSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a webhook subscription by replacing the existing signature key with a new one.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionSignatureKeyResponse response from the API call.</returns>
        public Models.UpdateWebhookSubscriptionSignatureKeyResponse UpdateWebhookSubscriptionSignatureKey(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionSignatureKeyRequest body)
        {
            Task<Models.UpdateWebhookSubscriptionSignatureKeyResponse> t = this.UpdateWebhookSubscriptionSignatureKeyAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a webhook subscription by replacing the existing signature key with a new one.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWebhookSubscriptionSignatureKeyResponse response from the API call.</returns>
        public async Task<Models.UpdateWebhookSubscriptionSignatureKeyResponse> UpdateWebhookSubscriptionSignatureKeyAsync(
                string subscriptionId,
                Models.UpdateWebhookSubscriptionSignatureKeyRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions/{subscription_id}/signature-key");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateWebhookSubscriptionSignatureKeyResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Tests a webhook subscription by sending a test event to the notification URL.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to test..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.TestWebhookSubscriptionResponse response from the API call.</returns>
        public Models.TestWebhookSubscriptionResponse TestWebhookSubscription(
                string subscriptionId,
                Models.TestWebhookSubscriptionRequest body)
        {
            Task<Models.TestWebhookSubscriptionResponse> t = this.TestWebhookSubscriptionAsync(subscriptionId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Tests a webhook subscription by sending a test event to the notification URL.
        /// </summary>
        /// <param name="subscriptionId">Required parameter: [REQUIRED] The ID of the [Subscription]($m/WebhookSubscription) to test..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.TestWebhookSubscriptionResponse response from the API call.</returns>
        public async Task<Models.TestWebhookSubscriptionResponse> TestWebhookSubscriptionAsync(
                string subscriptionId,
                Models.TestWebhookSubscriptionRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/webhooks/subscriptions/{subscription_id}/test");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.TestWebhookSubscriptionResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}