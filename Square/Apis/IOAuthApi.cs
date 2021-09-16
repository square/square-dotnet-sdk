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
    /// IOAuthApi.
    /// </summary>
    public interface IOAuthApi
    {
        /// <summary>
        /// `RenewToken` is deprecated. For information about refreshing OAuth access tokens, see.
        /// [Migrate from Renew to Refresh OAuth Tokens](https://developer.squareup.com/docs/oauth-api/migrate-to-refresh-tokens)..
        /// Renews an OAuth access token before it expires..
        /// OAuth access tokens besides your application's personal access token expire after __30 days__..
        /// You can also renew expired tokens within __15 days__ of their expiration..
        /// You cannot renew an access token that has been expired for more than 15 days..
        /// Instead, the associated user must re-complete the OAuth flow from the beginning..
        /// __Important:__ The `Authorization` header for this endpoint must have the.
        /// following format:.
        /// ```.
        /// Authorization: Client APPLICATION_SECRET.
        /// ```.
        /// Replace `APPLICATION_SECRET` with the application secret on the Credentials.
        /// page in the [developer dashboard](https://developer.squareup.com/apps)..
        /// </summary>
        /// <param name="clientId">Required parameter: Your application ID, available from the OAuth page for your  application on the Developer Dashboard..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET.</param>
        /// <returns>Returns the Models.RenewTokenResponse response from the API call.</returns>
        [Obsolete]
        Models.RenewTokenResponse RenewToken(
                string clientId,
                Models.RenewTokenRequest body,
                string authorization);

        /// <summary>
        /// `RenewToken` is deprecated. For information about refreshing OAuth access tokens, see.
        /// [Migrate from Renew to Refresh OAuth Tokens](https://developer.squareup.com/docs/oauth-api/migrate-to-refresh-tokens)..
        /// Renews an OAuth access token before it expires..
        /// OAuth access tokens besides your application's personal access token expire after __30 days__..
        /// You can also renew expired tokens within __15 days__ of their expiration..
        /// You cannot renew an access token that has been expired for more than 15 days..
        /// Instead, the associated user must re-complete the OAuth flow from the beginning..
        /// __Important:__ The `Authorization` header for this endpoint must have the.
        /// following format:.
        /// ```.
        /// Authorization: Client APPLICATION_SECRET.
        /// ```.
        /// Replace `APPLICATION_SECRET` with the application secret on the Credentials.
        /// page in the [developer dashboard](https://developer.squareup.com/apps)..
        /// </summary>
        /// <param name="clientId">Required parameter: Your application ID, available from the OAuth page for your  application on the Developer Dashboard..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RenewTokenResponse response from the API call.</returns>
        [Obsolete]
        Task<Models.RenewTokenResponse> RenewTokenAsync(
                string clientId,
                Models.RenewTokenRequest body,
                string authorization,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Revokes an access token generated with the OAuth flow..
        /// If an account has more than one OAuth access token for your application, this.
        /// endpoint revokes all of them, regardless of which token you specify. When an.
        /// OAuth access token is revoked, all of the active subscriptions associated.
        /// with that OAuth token are canceled immediately..
        /// __Important:__ The `Authorization` header for this endpoint must have the.
        /// following format:.
        /// ```.
        /// Authorization: Client APPLICATION_SECRET.
        /// ```.
        /// Replace `APPLICATION_SECRET` with the application secret on the OAuth.
        /// page for your application on the Developer Dashboard..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET.</param>
        /// <returns>Returns the Models.RevokeTokenResponse response from the API call.</returns>
        Models.RevokeTokenResponse RevokeToken(
                Models.RevokeTokenRequest body,
                string authorization);

        /// <summary>
        /// Revokes an access token generated with the OAuth flow..
        /// If an account has more than one OAuth access token for your application, this.
        /// endpoint revokes all of them, regardless of which token you specify. When an.
        /// OAuth access token is revoked, all of the active subscriptions associated.
        /// with that OAuth token are canceled immediately..
        /// __Important:__ The `Authorization` header for this endpoint must have the.
        /// following format:.
        /// ```.
        /// Authorization: Client APPLICATION_SECRET.
        /// ```.
        /// Replace `APPLICATION_SECRET` with the application secret on the OAuth.
        /// page for your application on the Developer Dashboard..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RevokeTokenResponse response from the API call.</returns>
        Task<Models.RevokeTokenResponse> RevokeTokenAsync(
                Models.RevokeTokenRequest body,
                string authorization,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns an OAuth access token and a refresh token unless the .
        /// `short_lived` parameter is set to `true`, in which case the endpoint .
        /// returns only an access token..
        /// The `grant_type` parameter specifies the type of OAuth request. If .
        /// `grant_type` is `authorization_code`, you must include the authorization .
        /// code you received when a seller granted you authorization. If `grant_type` .
        /// is `refresh_token`, you must provide a valid refresh token. If you are using .
        /// an old version of the Square APIs (prior to March 13, 2019), `grant_type` .
        /// can be `migration_token` and you must provide a valid migration token..
        /// You can use the `scopes` parameter to limit the set of permissions granted .
        /// to the access token and refresh token. You can use the `short_lived` parameter .
        /// to create an access token that expires in 24 hours..
        /// __Note:__ OAuth tokens should be encrypted and stored on a secure server. .
        /// Application clients should never interact directly with OAuth tokens..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ObtainTokenResponse response from the API call.</returns>
        Models.ObtainTokenResponse ObtainToken(
                Models.ObtainTokenRequest body);

        /// <summary>
        /// Returns an OAuth access token and a refresh token unless the .
        /// `short_lived` parameter is set to `true`, in which case the endpoint .
        /// returns only an access token..
        /// The `grant_type` parameter specifies the type of OAuth request. If .
        /// `grant_type` is `authorization_code`, you must include the authorization .
        /// code you received when a seller granted you authorization. If `grant_type` .
        /// is `refresh_token`, you must provide a valid refresh token. If you are using .
        /// an old version of the Square APIs (prior to March 13, 2019), `grant_type` .
        /// can be `migration_token` and you must provide a valid migration token..
        /// You can use the `scopes` parameter to limit the set of permissions granted .
        /// to the access token and refresh token. You can use the `short_lived` parameter .
        /// to create an access token that expires in 24 hours..
        /// __Note:__ OAuth tokens should be encrypted and stored on a secure server. .
        /// Application clients should never interact directly with OAuth tokens..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ObtainTokenResponse response from the API call.</returns>
        Task<Models.ObtainTokenResponse> ObtainTokenAsync(
                Models.ObtainTokenRequest body,
                CancellationToken cancellationToken = default);
    }
}