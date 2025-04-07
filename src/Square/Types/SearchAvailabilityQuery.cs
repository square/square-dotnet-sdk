using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query used to search for buyer-accessible availabilities of bookings.
/// </summary>
public record SearchAvailabilityQuery
{
    /// <summary>
    /// The query filter to search for buyer-accessible availabilities of existing bookings.
    /// </summary>
    [JsonPropertyName("filter")]
    public required SearchAvailabilityFilter Filter { get; set; }

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
