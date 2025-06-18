using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the loyalty program associated with a `loyalty.program.created` event.
/// </summary>
public record LoyaltyProgramCreatedEventObject
{
    /// <summary>
    /// The loyalty program that was created.
    /// </summary>
    [JsonPropertyName("loyalty_program")]
    public LoyaltyProgram? LoyaltyProgram { get; set; }

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
