using System.Text.Json.Serialization;
using Square.Core;

namespace Square.OAuth;

[Serializable]
public record ObtainTokenRequest
{
    /// <summary>
    /// The Square-issued ID of your application, which is available as the **Application ID**
    /// on the **OAuth** page in the [Developer Console](https://developer.squareup.com/apps).
    ///
    /// Required for the code flow and PKCE flow for any grant type.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The secret key for your application, which is available as the **Application secret**
    /// on the **OAuth** page in the [Developer Console](https://developer.squareup.com/apps).
    ///
    /// Required for the code flow for any grant type. Don't confuse your client secret with your
    /// personal access token.
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    /// <summary>
    /// The authorization code to exchange for an OAuth access token. This is the `code`
    /// value that Square sent to your redirect URL in the authorization response.
    ///
    /// Required for the code flow and PKCE flow if `grant_type` is `authorization_code`.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The redirect URL for your application, which you registered as the **Redirect URL**
    /// on the **OAuth** page in the [Developer Console](https://developer.squareup.com/apps).
    ///
    /// Required for the code flow and PKCE flow if `grant_type` is `authorization_code` and
    /// you provided the `redirect_uri` parameter in your authorization URL.
    /// </summary>
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    /// <summary>
    /// The method used to obtain an OAuth access token. The request must include the
    /// credential that corresponds to the specified grant type. Valid values are:
    /// - `authorization_code` - Requires the `code` field.
    /// - `refresh_token` - Requires the `refresh_token` field.
    /// - `migration_token` - LEGACY for access tokens obtained using a Square API version prior
    /// to 2019-03-13. Requires the `migration_token` field.
    /// </summary>
    [JsonPropertyName("grant_type")]
    public required string GrantType { get; set; }

    /// <summary>
    /// A valid refresh token used to generate a new OAuth access token. This is a
    /// refresh token that was returned in a previous `ObtainToken` response.
    ///
    /// Required for the code flow and PKCE flow if `grant_type` is `refresh_token`.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// __LEGACY__ A valid access token (obtained using a Square API version prior to 2019-03-13)
    /// used to generate a new OAuth access token.
    ///
    /// Required if `grant_type` is `migration_token`. For more information, see
    /// [Migrate to Using Refresh Tokens](https://developer.squareup.com/docs/oauth-api/migrate-to-refresh-tokens).
    /// </summary>
    [JsonPropertyName("migration_token")]
    public string? MigrationToken { get; set; }

    /// <summary>
    /// The list of permissions that are explicitly requested for the access token.
    /// For example, ["MERCHANT_PROFILE_READ","PAYMENTS_READ","BANK_ACCOUNTS_READ"].
    ///
    /// The returned access token is limited to the permissions that are the intersection
    /// of these requested permissions and those authorized by the provided `refresh_token`.
    ///
    /// Optional for the code flow and PKCE flow if `grant_type` is `refresh_token`.
    /// </summary>
    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    /// <summary>
    /// Indicates whether the returned access token should expire in 24 hours.
    ///
    /// Optional for the code flow and PKCE flow for any grant type. The default value is `false`.
    /// </summary>
    [JsonPropertyName("short_lived")]
    public bool? ShortLived { get; set; }

    /// <summary>
    /// The secret your application generated for the authorization request used to
    /// obtain the authorization code. This is the source of the `code_challenge` hash you
    /// provided in your authorization URL.
    ///
    /// Required for the PKCE flow if `grant_type` is `authorization_code`.
    /// </summary>
    [JsonPropertyName("code_verifier")]
    public string? CodeVerifier { get; set; }

    /// <summary>
    /// Indicates whether to use a JWT (JSON Web Token) as the OAuth access token.
    /// When set to `true`, the OAuth flow returns a JWT to your application, used in the
    /// same way as a regular token. The default value is `false`.
    /// </summary>
    [JsonPropertyName("use_jwt")]
    public bool? UseJwt { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
