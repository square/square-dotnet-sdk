using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record OauthAuthorizationRevokedEventRevocationObject
{
    /// <summary>
    /// Timestamp of when the revocation event occurred, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("revoked_at")]
    public string? RevokedAt { get; set; }

    /// <summary>
    /// Type of client that performed the revocation, either APPLICATION, MERCHANT, or SQUARE.
    /// See [OauthAuthorizationRevokedEventRevokerType](#type-oauthauthorizationrevokedeventrevokertype) for possible values
    /// </summary>
    [JsonPropertyName("revoker_type")]
    public OauthAuthorizationRevokedEventRevokerType? RevokerType { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
