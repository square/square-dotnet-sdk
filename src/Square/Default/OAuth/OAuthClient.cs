using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.OAuth;

public partial class OAuthClient : IOAuthClient
{
    private RawClient _client;

    internal OAuthClient(RawClient client)
    {
        _client = client;
    }

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
    /// <example><code>
    /// await client.Default.OAuth.RevokeTokenAsync(
    ///     new RevokeTokenRequest { ClientId = "CLIENT_ID", AccessToken = "ACCESS_TOKEN" }
    /// );
    /// </code></example>
    public async Task<RevokeTokenResponse> RevokeTokenAsync(
        RevokeTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "oauth2/revoke",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<RevokeTokenResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

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
    /// <example><code>
    /// await client.Default.OAuth.ObtainTokenAsync(
    ///     new ObtainTokenRequest
    ///     {
    ///         ClientId = "sq0idp-uaPHILoPzWZk3tlJqlML0g",
    ///         ClientSecret = "sq0csp-30a-4C_tVOnTh14Piza2BfTPBXyLafLPWSzY1qAjeBfM",
    ///         Code = "sq0cgb-l0SBqxs4uwxErTVyYOdemg",
    ///         GrantType = "authorization_code",
    ///     }
    /// );
    /// </code></example>
    public async Task<ObtainTokenResponse> ObtainTokenAsync(
        ObtainTokenRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "oauth2/token",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ObtainTokenResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

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
    /// <example><code>
    /// await client.Default.OAuth.RetrieveTokenStatusAsync();
    /// </code></example>
    public async Task<RetrieveTokenStatusResponse> RetrieveTokenStatusAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "oauth2/token/status",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<RetrieveTokenStatusResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <example><code>
    /// await client.Default.OAuth.AuthorizeAsync();
    /// </code></example>
    public async Task AuthorizeAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "oauth2/authorize",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
