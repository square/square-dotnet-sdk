using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The hours of operation for a location.
/// </summary>
public record BusinessHours
{
    /// <summary>
    /// The list of time periods during which the business is open. There can be at most 10 periods per day.
    /// </summary>
    [JsonPropertyName("periods")]
    public IEnumerable<BusinessHoursPeriod>? Periods { get; set; }

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
