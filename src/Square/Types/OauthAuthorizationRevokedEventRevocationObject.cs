using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record OauthAuthorizationRevokedEventRevocationObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
