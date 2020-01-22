using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IOAuthApi
    {
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
        Models.RenewTokenResponse RenewToken(string clientId, Models.RenewTokenRequest body, string authorization);

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
        Task<Models.RenewTokenResponse> RenewTokenAsync(string clientId, Models.RenewTokenRequest body, string authorization, CancellationToken cancellationToken = default);

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
        Models.RevokeTokenResponse RevokeToken(Models.RevokeTokenRequest body, string authorization);

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
        Task<Models.RevokeTokenResponse> RevokeTokenAsync(Models.RevokeTokenRequest body, string authorization, CancellationToken cancellationToken = default);

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
        Models.ObtainTokenResponse ObtainToken(Models.ObtainTokenRequest body);

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
        Task<Models.ObtainTokenResponse> ObtainTokenAsync(Models.ObtainTokenRequest body, CancellationToken cancellationToken = default);

    }
}