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
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;
using Square.Exceptions;

namespace Square.Apis
{
    internal class OAuthApi: BaseApi, IOAuthApi
    {
        internal OAuthApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// `RenewToken` is deprecated. For information about refreshing OAuth access tokens, see
        /// [Renew OAuth Token](https://developer.squareup.com/docs/oauth-api/cookbook/renew-oauth-tokens).
        /// Renews an OAuth access token before it expires.
        /// OAuth access tokens besides your application's personal access token expire after __30 days__.
        /// You can also renew expired tokens within __15 days__ of their expiration.
        /// You cannot renew an access token that has been expired for more than 15 days.
        /// Instead, the associated user must re-complete the OAuth flow from the beginning.
        /// __Important:__ The `Authorization` header for this endpoint must have the
        /// following format:
        /// ```
        /// Authorization: Client APPLICATION_SECRET
        /// ```
        /// Replace `APPLICATION_SECRET` with the application secret on the Credentials
        /// page in the [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        /// <param name="clientId">Required parameter: Your application ID, available from the [application dashboard](https://connect.squareup.com/apps).</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET</param>
        /// <return>Returns the Models.RenewTokenResponse response from the API call</return>
        [Obsolete]
        public Models.RenewTokenResponse RenewToken(string clientId, Models.RenewTokenRequest body, string authorization)
        {
            Task<Models.RenewTokenResponse> t = RenewTokenAsync(clientId, body, authorization);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// `RenewToken` is deprecated. For information about refreshing OAuth access tokens, see
        /// [Renew OAuth Token](https://developer.squareup.com/docs/oauth-api/cookbook/renew-oauth-tokens).
        /// Renews an OAuth access token before it expires.
        /// OAuth access tokens besides your application's personal access token expire after __30 days__.
        /// You can also renew expired tokens within __15 days__ of their expiration.
        /// You cannot renew an access token that has been expired for more than 15 days.
        /// Instead, the associated user must re-complete the OAuth flow from the beginning.
        /// __Important:__ The `Authorization` header for this endpoint must have the
        /// following format:
        /// ```
        /// Authorization: Client APPLICATION_SECRET
        /// ```
        /// Replace `APPLICATION_SECRET` with the application secret on the Credentials
        /// page in the [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        /// <param name="clientId">Required parameter: Your application ID, available from the [application dashboard](https://connect.squareup.com/apps).</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET</param>
        /// <return>Returns the Models.RenewTokenResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.RenewTokenResponse> RenewTokenAsync(string clientId, Models.RenewTokenRequest body, string authorization, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/oauth2/clients/{client_id}/access-token/renew");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "client_id", clientId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Authorization", authorization },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.RenewTokenResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Revokes an access token generated with the OAuth flow.
        /// If an account has more than one OAuth access token for your application, this
        /// endpoint revokes all of them, regardless of which token you specify. When an
        /// OAuth access token is revoked, all of the active subscriptions associated
        /// with that OAuth token are canceled immediately.
        /// __Important:__ The `Authorization` header for this endpoint must have the
        /// following format:
        /// ```
        /// Authorization: Client APPLICATION_SECRET
        /// ```
        /// Replace `APPLICATION_SECRET` with the application secret on the Credentials
        /// page in the [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET</param>
        /// <return>Returns the Models.RevokeTokenResponse response from the API call</return>
        public Models.RevokeTokenResponse RevokeToken(Models.RevokeTokenRequest body, string authorization)
        {
            Task<Models.RevokeTokenResponse> t = RevokeTokenAsync(body, authorization);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Revokes an access token generated with the OAuth flow.
        /// If an account has more than one OAuth access token for your application, this
        /// endpoint revokes all of them, regardless of which token you specify. When an
        /// OAuth access token is revoked, all of the active subscriptions associated
        /// with that OAuth token are canceled immediately.
        /// __Important:__ The `Authorization` header for this endpoint must have the
        /// following format:
        /// ```
        /// Authorization: Client APPLICATION_SECRET
        /// ```
        /// Replace `APPLICATION_SECRET` with the application secret on the Credentials
        /// page in the [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET</param>
        /// <return>Returns the Models.RevokeTokenResponse response from the API call</return>
        public async Task<Models.RevokeTokenResponse> RevokeTokenAsync(Models.RevokeTokenRequest body, string authorization, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/oauth2/revoke");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Authorization", authorization },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.RevokeTokenResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns an OAuth access token.
        /// The endpoint supports distinct methods of obtaining OAuth access tokens.
        /// Applications specify a method by adding the `grant_type` parameter
        /// in the request and also provide relevant information.
        /// For more information, see [OAuth access token management](https://developer.squareup.com/docs/authz/oauth/how-it-works#oauth-access-token-management).
        /// __Note:__ Regardless of the method application specified,
        /// the endpoint always returns two items; an OAuth access token and
        /// a refresh token in the response.
        /// __OAuth tokens should only live on secure servers. Application clients
        /// should never interact directly with OAuth tokens__.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.ObtainTokenResponse response from the API call</return>
        public Models.ObtainTokenResponse ObtainToken(Models.ObtainTokenRequest body)
        {
            Task<Models.ObtainTokenResponse> t = ObtainTokenAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns an OAuth access token.
        /// The endpoint supports distinct methods of obtaining OAuth access tokens.
        /// Applications specify a method by adding the `grant_type` parameter
        /// in the request and also provide relevant information.
        /// For more information, see [OAuth access token management](https://developer.squareup.com/docs/authz/oauth/how-it-works#oauth-access-token-management).
        /// __Note:__ Regardless of the method application specified,
        /// the endpoint always returns two items; an OAuth access token and
        /// a refresh token in the response.
        /// __OAuth tokens should only live on secure servers. Application clients
        /// should never interact directly with OAuth tokens__.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.ObtainTokenResponse response from the API call</return>
        public async Task<Models.ObtainTokenResponse> ObtainTokenAsync(Models.ObtainTokenRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/oauth2/token");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", config.SquareVersion }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ObtainTokenResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}