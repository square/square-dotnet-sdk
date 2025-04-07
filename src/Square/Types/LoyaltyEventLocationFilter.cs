using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter events by location.
/// </summary>
public record LoyaltyEventLocationFilter
{
    /// <summary>
    /// The [location](entity:Location) IDs for loyalty events to query.
    /// If multiple values are specified, the endpoint uses
    /// a logical OR to combine them.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string> LocationIds { get; set; } = new List<string>();

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
