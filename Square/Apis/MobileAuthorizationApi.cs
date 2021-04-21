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
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// MobileAuthorizationApi.
    /// </summary>
    internal class MobileAuthorizationApi : BaseApi, IMobileAuthorizationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileAuthorizationApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal MobileAuthorizationApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Generates code to authorize a mobile application to connect to a Square card reader.
        /// Authorization codes are one-time-use and expire __60 minutes__ after being issued..
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:.
        /// ```.
        /// Authorization: Bearer ACCESS_TOKEN.
        /// ```.
        /// Replace `ACCESS_TOKEN` with a.
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateMobileAuthorizationCodeResponse response from the API call.</returns>
        public Models.CreateMobileAuthorizationCodeResponse CreateMobileAuthorizationCode(
                Models.CreateMobileAuthorizationCodeRequest body)
        {
            Task<Models.CreateMobileAuthorizationCodeResponse> t = this.CreateMobileAuthorizationCodeAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Generates code to authorize a mobile application to connect to a Square card reader.
        /// Authorization codes are one-time-use and expire __60 minutes__ after being issued..
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:.
        /// ```.
        /// Authorization: Bearer ACCESS_TOKEN.
        /// ```.
        /// Replace `ACCESS_TOKEN` with a.
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateMobileAuthorizationCodeResponse response from the API call.</returns>
        public async Task<Models.CreateMobileAuthorizationCodeResponse> CreateMobileAuthorizationCodeAsync(
                Models.CreateMobileAuthorizationCodeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/mobile/authorization-code");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
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
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateMobileAuthorizationCodeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}