using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.OAuth;

[Serializable]
public record RevokeTokenRequest
{
    /// <summary>
    /// The Square-issued ID for your application, which is available on the **OAuth** page in the
    /// [Developer Dashboard](https://developer.squareup.com/apps).
    /// </summary>
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The access token of the merchant whose token you want to revoke.
    /// Do not provide a value for `merchant_id` if you provide this parameter.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    /// <summary>
    /// The ID of the merchant whose token you want to revoke.
    /// Do not provide a value for `access_token` if you provide this parameter.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// If `true`, terminate the given single access token, but do not
    /// terminate the entire authorization.
    /// Default: `false`
    /// </summary>
    [JsonPropertyName("revoke_only_access_token")]
    public bool? RevokeOnlyAccessToken { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
