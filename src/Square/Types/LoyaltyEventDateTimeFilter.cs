using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter events by date time range.
/// </summary>
public record LoyaltyEventDateTimeFilter
{
    /// <summary>
    /// The `created_at` date time range used to filter the result.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required TimeRange CreatedAt { get; set; }

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
