using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about the change that triggered the event.
/// </summary>
public record CustomerCreatedEventEventContext
{
    /// <summary>
    /// Information about the merge operation associated with the event.
    /// </summary>
    [JsonPropertyName("merge")]
    public CustomerCreatedEventEventContextMerge? Merge { get; set; }

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
