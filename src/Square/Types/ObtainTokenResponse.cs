using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an [ObtainToken](api-endpoint:OAuth-ObtainToken) response.
/// </summary>
public record ObtainTokenResponse
{
    /// <summary>
    /// An OAuth access token used to authorize Square API requests on behalf of the seller.
    /// Include this token as a bearer token in the `Authorization` header of your API requests.
    ///
    /// OAuth access tokens expire in 30 days (except `short_lived` access tokens). You should call
    /// `ObtainToken` and provide the returned `refresh_token` to get a new access token well before
    /// the current one expires. For more information, see [OAuth API: Walkthrough](https://developer.squareup.com/docs/oauth-api/walkthrough).
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    /// The type of access token. This value is always `bearer`.
    /// </summary>
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    /// <summary>
    /// The timestamp of when the `access_token` expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    /// <summary>
    /// The ID of the authorizing [merchant](entity:Merchant) (seller), which represents a business.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// __LEGACY__ The ID of merchant's subscription.
    /// The ID is only present if the merchant signed up for a subscription plan during authorization.
    /// </summary>
    [JsonPropertyName("subscription_id")]
    public string? SubscriptionId { get; set; }

    /// <summary>
    /// __LEGACY__ The ID of the subscription plan the merchant signed
    /// up for. The ID is only present if the merchant signed up for a subscription plan during
    /// authorization.
    /// </summary>
    [JsonPropertyName("plan_id")]
    public string? PlanId { get; set; }

    /// <summary>
    /// The OpenID token that belongs to this person. This token is only present if the
    /// `OPENID` scope is included in the authorization request.
    ///
    /// Deprecated at version 2021-09-15. Square doesn't support OpenID or other single sign-on (SSO)
    /// protocols on top of OAuth.
    /// </summary>
    [JsonPropertyName("id_token")]
    public string? IdToken { get; set; }

    /// <summary>
    /// A refresh token that can be used in an `ObtainToken` request to generate a new access token.
    ///
    /// With the code flow:
    /// - For the `authorization_code` grant type, the refresh token is multi-use and never expires.
    /// - For the `refresh_token` grant type, the response returns the same refresh token.
    ///
    /// With the PKCE flow:
    /// - For the `authorization_code` grant type, the refresh token is single-use and expires in 90 days.
    /// - For the `refresh_token` grant type, the refresh token is a new single-use refresh token that expires in 90 days.
    ///
    /// For more information, see [Refresh, Revoke, and Limit the Scope of OAuth Tokens](https://developer.squareup.com/docs/oauth-api/refresh-revoke-limit-scope).
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Indicates whether the access_token is short lived. If `true`, the access token expires
    /// in 24 hours. If `false`, the access token expires in 30 days.
    /// </summary>
    [JsonPropertyName("short_lived")]
    public bool? ShortLived { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The timestamp of when the `refresh_token` expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm)
    /// format.
    ///
    /// This field is only returned for the PKCE flow.
    /// </summary>
    [JsonPropertyName("refresh_token_expires_at")]
    public string? RefreshTokenExpiresAt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
