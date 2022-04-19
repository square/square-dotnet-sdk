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
    /// InvoicesApi.
    /// </summary>
    internal class InvoicesApi : BaseApi, IInvoicesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal InvoicesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Returns a list of invoices for a given location. The response .
        /// is paginated. If truncated, the response includes a `cursor` that you    .
        /// use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server uses a default limit of 100 invoices..</param>
        /// <returns>Returns the Models.ListInvoicesResponse response from the API call.</returns>
        public Models.ListInvoicesResponse ListInvoices(
                string locationId,
                string cursor = null,
                int? limit = null)
        {
            Task<Models.ListInvoicesResponse> t = this.ListInvoicesAsync(locationId, cursor, limit);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of invoices for a given location. The response .
        /// is paginated. If truncated, the response includes a `cursor` that you    .
        /// use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location for which to list invoices..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint.  Provide this cursor to retrieve the next set of results for your original query.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of invoices to return (200 is the maximum `limit`).  If not provided, the server uses a default limit of 100 invoices..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListInvoicesResponse response from the API call.</returns>
        public async Task<Models.ListInvoicesResponse> ListInvoicesAsync(
                string locationId,
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.ListInvoicesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a draft [invoice]($m/Invoice) .
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. .
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateInvoiceResponse response from the API call.</returns>
        public Models.CreateInvoiceResponse CreateInvoice(
                Models.CreateInvoiceRequest body)
        {
            Task<Models.CreateInvoiceResponse> t = this.CreateInvoiceAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a draft [invoice]($m/Invoice) .
        /// for an order created using the Orders API.
        /// A draft invoice remains in your account and no action is taken. .
        /// You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateInvoiceResponse response from the API call.</returns>
        public async Task<Models.CreateInvoiceResponse> CreateInvoiceAsync(
                Models.CreateInvoiceRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateInvoiceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches for invoices from a location specified in .
        /// the filter. You can optionally specify customers in the filter for whom to .
        /// retrieve invoices. In the current implementation, you can only specify one location and .
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` .
        /// that you use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchInvoicesResponse response from the API call.</returns>
        public Models.SearchInvoicesResponse SearchInvoices(
                Models.SearchInvoicesRequest body)
        {
            Task<Models.SearchInvoicesResponse> t = this.SearchInvoicesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for invoices from a location specified in .
        /// the filter. You can optionally specify customers in the filter for whom to .
        /// retrieve invoices. In the current implementation, you can only specify one location and .
        /// optionally one customer.
        /// The response is paginated. If truncated, the response includes a `cursor` .
        /// that you use in a subsequent request to retrieve the next set of invoices.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchInvoicesResponse response from the API call.</returns>
        public async Task<Models.SearchInvoicesResponse> SearchInvoicesAsync(
                Models.SearchInvoicesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices/search");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchInvoicesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the .
        /// associated order status changes to CANCELED. You can only delete a draft .
        /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete..</param>
        /// <param name="version">Optional parameter: The version of the [invoice]($m/Invoice) to delete. If you do not know the version, you can call [GetInvoice]($e/Invoices/GetInvoice) or  [ListInvoices]($e/Invoices/ListInvoices)..</param>
        /// <returns>Returns the Models.DeleteInvoiceResponse response from the API call.</returns>
        public Models.DeleteInvoiceResponse DeleteInvoice(
                string invoiceId,
                int? version = null)
        {
            Task<Models.DeleteInvoiceResponse> t = this.DeleteInvoiceAsync(invoiceId, version);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes the specified invoice. When an invoice is deleted, the .
        /// associated order status changes to CANCELED. You can only delete a draft .
        /// invoice (you cannot delete a published invoice, including one that is scheduled for processing).
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to delete..</param>
        /// <param name="version">Optional parameter: The version of the [invoice]($m/Invoice) to delete. If you do not know the version, you can call [GetInvoice]($e/Invoices/GetInvoice) or  [ListInvoices]($e/Invoices/ListInvoices)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteInvoiceResponse response from the API call.</returns>
        public async Task<Models.DeleteInvoiceResponse> DeleteInvoiceAsync(
                string invoiceId,
                int? version = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices/{invoice_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "version", version },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null, queryParameters: queryParams);

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

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteInvoiceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to retrieve..</param>
        /// <returns>Returns the Models.GetInvoiceResponse response from the API call.</returns>
        public Models.GetInvoiceResponse GetInvoice(
                string invoiceId)
        {
            Task<Models.GetInvoiceResponse> t = this.GetInvoiceAsync(invoiceId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves an invoice by invoice ID.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetInvoiceResponse response from the API call.</returns>
        public async Task<Models.GetInvoiceResponse> GetInvoiceAsync(
                string invoiceId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices/{invoice_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.GetInvoiceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates an invoice by modifying fields, clearing fields, or both. For most updates, you can use a sparse .
        /// `Invoice` object to add fields or change values and use the `fields_to_clear` field to specify fields to clear. .
        /// However, some restrictions apply. For example, you cannot change the `order_id` or `location_id` field and you .
        /// must provide the complete `custom_fields` list to update a custom field. Published invoices have additional restrictions.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateInvoiceResponse response from the API call.</returns>
        public Models.UpdateInvoiceResponse UpdateInvoice(
                string invoiceId,
                Models.UpdateInvoiceRequest body)
        {
            Task<Models.UpdateInvoiceResponse> t = this.UpdateInvoiceAsync(invoiceId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an invoice by modifying fields, clearing fields, or both. For most updates, you can use a sparse .
        /// `Invoice` object to add fields or change values and use the `fields_to_clear` field to specify fields to clear. .
        /// However, some restrictions apply. For example, you cannot change the `order_id` or `location_id` field and you .
        /// must provide the complete `custom_fields` list to update a custom field. Published invoices have additional restrictions.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateInvoiceResponse response from the API call.</returns>
        public async Task<Models.UpdateInvoiceResponse> UpdateInvoiceAsync(
                string invoiceId,
                Models.UpdateInvoiceRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices/{invoice_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateInvoiceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for .
        /// the canceled invoice.
        /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice]($m/Invoice) to cancel..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelInvoiceResponse response from the API call.</returns>
        public Models.CancelInvoiceResponse CancelInvoice(
                string invoiceId,
                Models.CancelInvoiceRequest body)
        {
            Task<Models.CancelInvoiceResponse> t = this.CancelInvoiceAsync(invoiceId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels an invoice. The seller cannot collect payments for .
        /// the canceled invoice.
        /// You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the [invoice]($m/Invoice) to cancel..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelInvoiceResponse response from the API call.</returns>
        public async Task<Models.CancelInvoiceResponse> CancelInvoiceAsync(
                string invoiceId,
                Models.CancelInvoiceRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices/{invoice_id}/cancel");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.CancelInvoiceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Publishes the specified draft invoice. .
        /// After an invoice is published, Square .
        /// follows up based on the invoice configuration. For example, Square .
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does .
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. .
        /// The invoice `status` also changes from `DRAFT` to a status .
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if .
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the .
        /// invoice amount.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to publish..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.PublishInvoiceResponse response from the API call.</returns>
        public Models.PublishInvoiceResponse PublishInvoice(
                string invoiceId,
                Models.PublishInvoiceRequest body)
        {
            Task<Models.PublishInvoiceResponse> t = this.PublishInvoiceAsync(invoiceId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Publishes the specified draft invoice. .
        /// After an invoice is published, Square .
        /// follows up based on the invoice configuration. For example, Square .
        /// sends the invoice to the customer's email address, charges the customer's card on file, or does .
        /// nothing. Square also makes the invoice available on a Square-hosted invoice page. .
        /// The invoice `status` also changes from `DRAFT` to a status .
        /// based on the invoice configuration. For example, the status changes to `UNPAID` if .
        /// Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the .
        /// invoice amount.
        /// </summary>
        /// <param name="invoiceId">Required parameter: The ID of the invoice to publish..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PublishInvoiceResponse response from the API call.</returns>
        public async Task<Models.PublishInvoiceResponse> PublishInvoiceAsync(
                string invoiceId,
                Models.PublishInvoiceRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/invoices/{invoice_id}/publish");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "invoice_id", invoiceId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.PublishInvoiceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}