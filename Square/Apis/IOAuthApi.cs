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
        /// Revokes an access token generated with the OAuth flow.
        /// If an account has more than one OAuth access token for your application, this.
        /// endpoint revokes all of them, regardless of which token you specify. .
        /// __Important:__ The `Authorization` header for this endpoint must have the.
        /// following format:.
        /// ```.
        /// Authorization: Client APPLICATION_SECRET.
        /// ```.
        /// Replace `APPLICATION_SECRET` with the application secret on the **OAuth**.
        /// page for your application in the Developer Dashboard.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="authorization">Required parameter: Client APPLICATION_SECRET.</param>
        /// <returns>Returns the Models.RevokeTokenResponse response from the API call.</returns>
        Models.RevokeTokenResponse RevokeToken(
                Models.RevokeTokenRequest body,
                string authorization);

        /// <summary>
        /// Revokes an access token generated with the OAuth flow.
        /// If an account has more than one OAuth access token for your application, this.
        /// endpoint revokes all of them, regardless of which token you specify. .
        /// __Important:__ The `Authorization` header for this endpoint must have the.
        /// following format:.
        /// ```.
        /// Authorization: Client APPLICATION_SECRET.
        /// ```.
        /// Replace `APPLICATION_SECRET` with the application secret on the **OAuth**.
        /// page for your application in the Developer Dashboard.
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
        /// returns only an access token.
        /// The `grant_type` parameter specifies the type of OAuth request. If .
        /// `grant_type` is `authorization_code`, you must include the authorization .
        /// code you received when a seller granted you authorization. If `grant_type` .
        /// is `refresh_token`, you must provide a valid refresh token. If you're using .
        /// an old version of the Square APIs (prior to March 13, 2019), `grant_type` .
        /// can be `migration_token` and you must provide a valid migration token.
        /// You can use the `scopes` parameter to limit the set of permissions granted .
        /// to the access token and refresh token. You can use the `short_lived` parameter .
        /// to create an access token that expires in 24 hours.
        /// __Note:__ OAuth tokens should be encrypted and stored on a secure server. .
        /// Application clients should never interact directly with OAuth tokens.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.ObtainTokenResponse response from the API call.</returns>
        Models.ObtainTokenResponse ObtainToken(
                Models.ObtainTokenRequest body);

        /// <summary>
        /// Returns an OAuth access token and a refresh token unless the .
        /// `short_lived` parameter is set to `true`, in which case the endpoint .
        /// returns only an access token.
        /// The `grant_type` parameter specifies the type of OAuth request. If .
        /// `grant_type` is `authorization_code`, you must include the authorization .
        /// code you received when a seller granted you authorization. If `grant_type` .
        /// is `refresh_token`, you must provide a valid refresh token. If you're using .
        /// an old version of the Square APIs (prior to March 13, 2019), `grant_type` .
        /// can be `migration_token` and you must provide a valid migration token.
        /// You can use the `scopes` parameter to limit the set of permissions granted .
        /// to the access token and refresh token. You can use the `short_lived` parameter .
        /// to create an access token that expires in 24 hours.
        /// __Note:__ OAuth tokens should be encrypted and stored on a secure server. .
        /// Application clients should never interact directly with OAuth tokens.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ObtainTokenResponse response from the API call.</returns>
        Task<Models.ObtainTokenResponse> ObtainTokenAsync(
                Models.ObtainTokenRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns information about an [OAuth access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-an-oauth-access-token) or an application’s [personal access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-a-personal-access-token).
        /// Add the access token to the Authorization header of the request.
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:.
        /// ```.
        /// Authorization: Bearer ACCESS_TOKEN.
        /// ```.
        /// where `ACCESS_TOKEN` is a.
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
        /// If the access token is expired or not a valid access token, the endpoint returns an `UNAUTHORIZED` error.
        /// </summary>
        /// <returns>Returns the Models.RetrieveTokenStatusResponse response from the API call.</returns>
        Models.RetrieveTokenStatusResponse RetrieveTokenStatus();

        /// <summary>
        /// Returns information about an [OAuth access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-an-oauth-access-token) or an application’s [personal access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-a-personal-access-token).
        /// Add the access token to the Authorization header of the request.
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:.
        /// ```.
        /// Authorization: Bearer ACCESS_TOKEN.
        /// ```.
        /// where `ACCESS_TOKEN` is a.
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
        /// If the access token is expired or not a valid access token, the endpoint returns an `UNAUTHORIZED` error.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTokenStatusResponse response from the API call.</returns>
        Task<Models.RetrieveTokenStatusResponse> RetrieveTokenStatusAsync(CancellationToken cancellationToken = default);
    }
}