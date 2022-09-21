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
    /// ApplePayApi.
    /// </summary>
    internal class ApplePayApi : BaseApi, IApplePayApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplePayApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal ApplePayApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation.
        /// is performed on this domain by Apple to ensure that it is properly set up as.
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate.
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// Note: The SqPaymentForm library is deprecated as of May 13, 2021, and will only receive critical security updates until it is retired on October 31, 2022.
        /// You must migrate your payment form code to the Web Payments SDK to continue using your domain for Apple Pay. For more information on migrating to the Web Payments SDK, see [Migrate to the Web Payments SDK](https://developer.squareup.com/docs/web-payments/migrate).
        /// To learn more about the Web Payments SDK and how to add Apple Pay, see [Take an Apple Pay Payment](https://developer.squareup.com/docs/web-payments/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.RegisterDomainResponse response from the API call.</returns>
        public Models.RegisterDomainResponse RegisterDomain(
                Models.RegisterDomainRequest body)
        {
            Task<Models.RegisterDomainResponse> t = this.RegisterDomainAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Activates a domain for use with Apple Pay on the Web and Square. A validation.
        /// is performed on this domain by Apple to ensure that it is properly set up as.
        /// an Apple Pay enabled domain.
        /// This endpoint provides an easy way for platform developers to bulk activate.
        /// Apple Pay on the Web with Square for merchants using their platform.
        /// Note: The SqPaymentForm library is deprecated as of May 13, 2021, and will only receive critical security updates until it is retired on October 31, 2022.
        /// You must migrate your payment form code to the Web Payments SDK to continue using your domain for Apple Pay. For more information on migrating to the Web Payments SDK, see [Migrate to the Web Payments SDK](https://developer.squareup.com/docs/web-payments/migrate).
        /// To learn more about the Web Payments SDK and how to add Apple Pay, see [Take an Apple Pay Payment](https://developer.squareup.com/docs/web-payments/apple-pay).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RegisterDomainResponse response from the API call.</returns>
        public async Task<Models.RegisterDomainResponse> RegisterDomainAsync(
                Models.RegisterDomainRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/apple-pay/domains");

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

            var responseModel = ApiHelper.JsonDeserialize<Models.RegisterDomainResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}