using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the `CreateMobileAuthorizationCode` endpoint.
/// </summary>
public record CreateMobileAuthorizationCodeResponse
{
    /// <summary>
    /// The generated authorization code that connects a mobile application instance
    /// to a Square account.
    /// </summary>
    [JsonPropertyName("authorization_code")]
    public string? AuthorizationCode { get; set; }

    /// <summary>
    /// The timestamp when `authorization_code` expires, in
    /// [RFC 3339](https://tools.ietf.org/html/rfc3339) format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
