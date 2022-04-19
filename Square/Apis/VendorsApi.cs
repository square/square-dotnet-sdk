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
    /// VendorsApi.
    /// </summary>
    internal class VendorsApi : BaseApi, IVendorsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal VendorsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Creates one or more [Vendor]($m/Vendor) objects to represent suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateVendorsResponse response from the API call.</returns>
        public Models.BulkCreateVendorsResponse BulkCreateVendors(
                Models.BulkCreateVendorsRequest body)
        {
            Task<Models.BulkCreateVendorsResponse> t = this.BulkCreateVendorsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates one or more [Vendor]($m/Vendor) objects to represent suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkCreateVendorsResponse response from the API call.</returns>
        public async Task<Models.BulkCreateVendorsResponse> BulkCreateVendorsAsync(
                Models.BulkCreateVendorsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/bulk-create");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkCreateVendorsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves one or more vendors of specified [Vendor]($m/Vendor) IDs.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveVendorsResponse response from the API call.</returns>
        public Models.BulkRetrieveVendorsResponse BulkRetrieveVendors(
                Models.BulkRetrieveVendorsRequest body)
        {
            Task<Models.BulkRetrieveVendorsResponse> t = this.BulkRetrieveVendorsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves one or more vendors of specified [Vendor]($m/Vendor) IDs.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveVendorsResponse response from the API call.</returns>
        public async Task<Models.BulkRetrieveVendorsResponse> BulkRetrieveVendorsAsync(
                Models.BulkRetrieveVendorsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/bulk-retrieve");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkRetrieveVendorsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates one or more of existing [Vendor]($m/Vendor) objects as suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateVendorsResponse response from the API call.</returns>
        public Models.BulkUpdateVendorsResponse BulkUpdateVendors(
                Models.BulkUpdateVendorsRequest body)
        {
            Task<Models.BulkUpdateVendorsResponse> t = this.BulkUpdateVendorsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates one or more of existing [Vendor]($m/Vendor) objects as suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpdateVendorsResponse response from the API call.</returns>
        public async Task<Models.BulkUpdateVendorsResponse> BulkUpdateVendorsAsync(
                Models.BulkUpdateVendorsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/bulk-update");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.BulkUpdateVendorsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a single [Vendor]($m/Vendor) object to represent a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateVendorResponse response from the API call.</returns>
        public Models.CreateVendorResponse CreateVendor(
                Models.CreateVendorRequest body)
        {
            Task<Models.CreateVendorResponse> t = this.CreateVendorAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a single [Vendor]($m/Vendor) object to represent a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateVendorResponse response from the API call.</returns>
        public async Task<Models.CreateVendorResponse> CreateVendorAsync(
                Models.CreateVendorRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/create");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateVendorResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches for vendors using a filter against supported [Vendor]($m/Vendor) properties and a supported sorter.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchVendorsResponse response from the API call.</returns>
        public Models.SearchVendorsResponse SearchVendors(
                Models.SearchVendorsRequest body)
        {
            Task<Models.SearchVendorsResponse> t = this.SearchVendorsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for vendors using a filter against supported [Vendor]($m/Vendor) properties and a supported sorter.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchVendorsResponse response from the API call.</returns>
        public async Task<Models.SearchVendorsResponse> SearchVendorsAsync(
                Models.SearchVendorsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/search");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchVendorsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves the vendor of a specified [Vendor]($m/Vendor) ID.
        /// </summary>
        /// <param name="vendorId">Required parameter: ID of the [Vendor]($m/Vendor) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveVendorResponse response from the API call.</returns>
        public Models.RetrieveVendorResponse RetrieveVendor(
                string vendorId)
        {
            Task<Models.RetrieveVendorResponse> t = this.RetrieveVendorAsync(vendorId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves the vendor of a specified [Vendor]($m/Vendor) ID.
        /// </summary>
        /// <param name="vendorId">Required parameter: ID of the [Vendor]($m/Vendor) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveVendorResponse response from the API call.</returns>
        public async Task<Models.RetrieveVendorResponse> RetrieveVendorAsync(
                string vendorId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/{vendor_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "vendor_id", vendorId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveVendorResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates an existing [Vendor]($m/Vendor) object as a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="vendorId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.UpdateVendorResponse response from the API call.</returns>
        public Models.UpdateVendorResponse UpdateVendor(
                Models.UpdateVendorRequest body,
                string vendorId)
        {
            Task<Models.UpdateVendorResponse> t = this.UpdateVendorAsync(body, vendorId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an existing [Vendor]($m/Vendor) object as a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="vendorId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateVendorResponse response from the API call.</returns>
        public async Task<Models.UpdateVendorResponse> UpdateVendorAsync(
                Models.UpdateVendorRequest body,
                string vendorId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/vendors/{vendor_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "vendor_id", vendorId },
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

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateVendorResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}