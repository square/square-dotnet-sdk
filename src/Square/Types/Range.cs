using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The range of a number value between the specified lower and upper bounds.
/// </summary>
public record Range
{
    /// <summary>
    /// The lower bound of the number range. At least one of `min` or `max` must be specified.
    /// If unspecified, the results will have no minimum value.
    /// </summary>
    [JsonPropertyName("min")]
    public string? Min { get; set; }

    /// <summary>
    /// The upper bound of the number range. At least one of `min` or `max` must be specified.
    /// If unspecified, the results will have no maximum value.
    /// </summary>
    [JsonPropertyName("max")]
    public string? Max { get; set; }

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
