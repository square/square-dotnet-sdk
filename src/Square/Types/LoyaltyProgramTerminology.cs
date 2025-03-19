using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the naming used for loyalty points.
/// </summary>
public record LoyaltyProgramTerminology
{
    /// <summary>
    /// A singular unit for a point (for example, 1 point is called 1 star).
    /// </summary>
    [JsonPropertyName("one")]
    public required string One { get; set; }

    /// <summary>
    /// A plural unit for point (for example, 10 points is called 10 stars).
    /// </summary>
    [JsonPropertyName("other")]
    public required string Other { get; set; }

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
