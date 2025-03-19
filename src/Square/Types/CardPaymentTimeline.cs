using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The timeline for card payments.
/// </summary>
public record CardPaymentTimeline
{
    /// <summary>
    /// The timestamp when the payment was authorized, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("authorized_at")]
    public string? AuthorizedAt { get; set; }

    /// <summary>
    /// The timestamp when the payment was captured, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("captured_at")]
    public string? CapturedAt { get; set; }

    /// <summary>
    /// The timestamp when the payment was voided, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("voided_at")]
    public string? VoidedAt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
