using Square;
using Square.Default;

namespace Square.Default.OAuth;

public partial interface IOAuthClient
{
    /// <summary>
    /// Revokes an access token generated with the OAuth flow.
    ///
    /// If an account has more than one OAuth access token for your application, this
    /// endpoint revokes all of them, regardless of which token you specify.
    ///
    /// __Important:__ The `Authorization` header for this endpoint must have the
    /// following format:
    ///
    /// ```
    /// Authorization: Client APPLICATION_SECRET
    /// ```
    ///
    /// Replace `APPLICATION_SECRET` with the application secret on the **OAuth**
    /// page for your application in the Developer Dashboard.
    /// </summary>
    Task<RevokeTokenResponse> RevokeTokenAsync(
        RevokeTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns an OAuth access token and refresh token using the `authorization_code`
    /// or `refresh_token` grant type.
    ///
    /// When `grant_type` is `authorization_code`:
    /// - With the [code flow](https://developer.squareup.com/docs/oauth-api/overview#code-flow),
    /// provide `code`, `client_id`, and `client_secret`.
    /// - With the [PKCE flow](https://developer.squareup.com/docs/oauth-api/overview#pkce-flow),
    /// provide `code`, `client_id`, and `code_verifier`.
    ///
    /// When `grant_type` is `refresh_token`:
    /// - With the code flow, provide `refresh_token`, `client_id`, and `client_secret`.
    /// The response returns the same refresh token provided in the request.
    /// - With the PKCE flow, provide `refresh_token` and `client_id`. The response returns
    /// a new refresh token.
    ///
    /// You can use the `scopes` parameter to limit the set of permissions authorized by the
    /// access token. You can use the `short_lived` parameter to create an access token that
    /// expires in 24 hours.
    ///
    /// __Important:__ OAuth tokens should be encrypted and stored on a secure server.
    /// Application clients should never interact directly with OAuth tokens.
    /// </summary>
    Task<ObtainTokenResponse> ObtainTokenAsync(
        ObtainTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns information about an [OAuth access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-an-oauth-access-token) or an application’s [personal access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-a-personal-access-token).
    ///
    /// Add the access token to the Authorization header of the request.
    ///
    /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:
    ///
    /// ```
    /// Authorization: Bearer ACCESS_TOKEN
    /// ```
    ///
    /// where `ACCESS_TOKEN` is a
    /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
    ///
    /// If the access token is expired or not a valid access token, the endpoint returns an `UNAUTHORIZED` error.
    /// </summary>
    Task<RetrieveTokenStatusResponse> RetrieveTokenStatusAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task AuthorizeAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
