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
        /// <param name="clientId">Required parameter: Your application ID, available from the [developer dashboard](https://developer.squareup.com/apps)..</param>
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
        /// <param name="clientId">Required parameter: Your application ID, available from the [developer dashboard](https://developer.squareup.com/apps)..</param>
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
        /// page in the [developer dashboard](https://developer.squareup.com/apps)..
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
        /// page in the [developer dashboard](https://developer.squareup.com/apps)..
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
        /// Returns an OAuth access token..
        /// The endpoint supports distinct methods of obtaining OAuth access tokens..
        /// Applications specify a method by adding the `grant_type` parameter.
        /// in the request and also provide relevant information..
        /// __Note:__ Regardless of the method application specified,.
        /// the endpoint always returns two items; an OAuth access token and.
        /// a refresh token in the response..
        /// __OAuth tokens should only live on secure servers. Application clients.
        /// should never interact directly with OAuth tokens__..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ObtainTokenResponse response from the API call.</returns>
        Models.ObtainTokenResponse ObtainToken(
                Models.ObtainTokenRequest body);

        /// <summary>
        /// Returns an OAuth access token..
        /// The endpoint supports distinct methods of obtaining OAuth access tokens..
        /// Applications specify a method by adding the `grant_type` parameter.
        /// in the request and also provide relevant information..
        /// __Note:__ Regardless of the method application specified,.
        /// the endpoint always returns two items; an OAuth access token and.
        /// a refresh token in the response..
        /// __OAuth tokens should only live on secure servers. Application clients.
        /// should never interact directly with OAuth tokens__..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ObtainTokenResponse response from the API call.</returns>
        Task<Models.ObtainTokenResponse> ObtainTokenAsync(
                Models.ObtainTokenRequest body,
                CancellationToken cancellationToken = default);
    }
}