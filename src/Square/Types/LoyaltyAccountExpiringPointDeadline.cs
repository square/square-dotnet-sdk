using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a set of points for a loyalty account that are scheduled to expire on a specific date.
/// </summary>
public record LoyaltyAccountExpiringPointDeadline
{
    /// <summary>
    /// The number of points scheduled to expire at the `expires_at` timestamp.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The timestamp of when the points are scheduled to expire, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public required string ExpiresAt { get; set; }

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
